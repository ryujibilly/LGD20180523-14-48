using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using WitsTransmission.TCPUtil;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Collections.Concurrent;
using System.Threading;
using LGD.DAL.SQLite;
using WitsTransmission.Model;
using System.Diagnostics;

namespace WitsTransmission
{
    public partial class Main_Form : Form
    {
        WellConfig.WellConfig_Form m_wellConfig_From;
        WitsReceive.RecConfig_Form m_recConfig_Form;
        WitsSend.SendConfig_Form m_sendConfig_Form;
        public List<String> m_selcetedTableList = new List<String>();
        //创建DataTable,用于保存解析后的WITS数据
        public DataTable m_witsDataDT = new DataTable();//存解析一帧所有数据，用于显示
        private String m_contentWitsData;//用于接收消息发送来的content数据
        //wits字典用于查询Index对应的CurveName（短助记符）
        private WitsTableDictionary m_CurveNameDictionary = new WitsTableDictionary();
        //curveName字典，保存所有所选仪器和表号及对应的曲线名（短助记符）
        private Dictionary<String, Dictionary<String, DataTable>> m_curveNameDictionary = new Dictionary<string, Dictionary<string, DataTable>>();
        //字典以键值对形式存一次接收解析出的各个WITS表，用于写库和发送
        private Dictionary<String, Dictionary<String, WitsTable>> m_witsTableDictionary = new Dictionary<string, Dictionary<String, WitsTable>>();
        //用于写库和发送，此队列自带线程安全锁
        bool m_isWriteDB = false;
        public ConcurrentQueue<DataTable> m_tempTableQueue = new ConcurrentQueue<DataTable>();
        //写库线程
        public Thread m_writeDBThread;
        //创建模板DB，仅用于第一次连接数据库
        SQLiteDBHelper m_realDBHelper;
        //创建存数据的DB
        SQLiteDBHelper m_dBHelper;
        //自定义消息
        public const int USER = 0x500;
        public const int CONTENTMESSAGE = USER + 1;
        //定义为private对象，避免锁不可控
        private Object messageLock;
        private Object dtLock;
        //重写窗体的消息处理函数DefWndProc，从中加入自己定义消息　MYMESSAGE　的检测的处理入口
        protected override void DefWndProc(ref Message m)
        {
            messageLock = new Object();//实现临界区同步锁
            lock (messageLock)
            {
                switch (m.Msg)
                {
                    //接收自定义消息CONTENTMESSAGE，一次接收的WITS数据并显示其参数
                    case CONTENTMESSAGE:
                        WitsTransmission.TCPUtil.SendDataStruct contentStruct = new WitsTransmission.TCPUtil.SendDataStruct();//这是创建自定义信息的结构
                        Type mytype = contentStruct.GetType();
                        contentStruct = (WitsTransmission.TCPUtil.SendDataStruct)m.GetLParam(mytype);//这里获取的就是作为LParam参数发送来的信息的结构
                        m_contentWitsData = contentStruct.lpData; //显示收到的自定义信息
                        //启动解析WITS帧线程
                        ParseWitsData(m_contentWitsData);
                        //启动写库线程
                        m_isWriteDB = true;
                        if (!m_writeDBThread.IsAlive)
                        {
                            m_writeDBThread.Start();
                        }
                        break;
                    default:
                        base.DefWndProc(ref m);
                        break;
                }
            }
            messageLock = null;
        }
        public Main_Form()
        {
            InitializeComponent();
        }

        private void Main_Form_Load(object sender, EventArgs e)
        {
            //为m_witsDataDT添加列 
            DataColumn dc1 = new DataColumn("TableNo", Type.GetType("System.String"));
            DataColumn dc2 = new DataColumn("ItemIndex", Type.GetType("System.String"));
            DataColumn dc3 = new DataColumn("Value", Type.GetType("System.String"));
            m_witsDataDT.Columns.Add(dc1);
            m_witsDataDT.Columns.Add(dc2);
            m_witsDataDT.Columns.Add(dc3);
            m_receiveWitsData_dataSet.Tables.Add(m_witsDataDT);
            //根据内容自动调整列宽
            receiveWitsData_dataGridView.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
            //receiveWitsData_dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells; 
            /*//为m_witsTable添加列 
            DataColumn dcWits1 = new DataColumn("ItemIndex", Type.GetType("System.String"));
            DataColumn dcWits2 = new DataColumn("Value", Type.GetType("System.String"));
            m_witsTable.Columns.Add(dcWits1);
            m_witsTable.Columns.Add(dcWits2);*/
            m_writeDBThread = new Thread(new ThreadStart(this._WriteDBThreadProcess));
        }

        private void recConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_recConfig_Form = new WitsReceive.RecConfig_Form();
            m_recConfig_Form.Show();//使用模态窗口，关闭后资源仍然存在，需手动释放
        }

        private void wellConfig_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_wellConfig_From = new WellConfig.WellConfig_Form();
            m_wellConfig_From.Show();
        }

        private void sendConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_sendConfig_Form = new WitsSend.SendConfig_Form();
            m_sendConfig_Form.Show();
        }

        //解析一次接收到的数据
        void ParseWitsData(String strContent)
        {
            //包含表结尾标志
            if (strContent.Contains("!!\r\n"))
            {
                string[] strTableSplit = { "!!\r\n" };
                //将一帧拆成多个表
                string[] strTableArray = strContent.Split(strTableSplit, StringSplitOptions.RemoveEmptyEntries);
                //按表入队
                foreach (string elementTable in strTableArray)
                {
                    if (elementTable.StartsWith("&&\r\n"))
                    {
                        //存一张表
                        DataTable tempTable = new DataTable();
                        //为m_tempTable添加列 
                        DataColumn dctemp1 = new DataColumn("TableNo", Type.GetType("System.String"));
                        DataColumn dctemp2 = new DataColumn("ItemIndex", Type.GetType("System.String"));
                        DataColumn dctemp3 = new DataColumn("Value", Type.GetType("System.String"));
                        tempTable.Columns.Add(dctemp1);
                        tempTable.Columns.Add(dctemp2);
                        tempTable.Columns.Add(dctemp3);
                        string[] strlineSplit = { "\r\n" };
                        string[] strLineArray = elementTable.Split(strlineSplit, StringSplitOptions.RemoveEmptyEntries);
                        //解析一张表
                        foreach (string elementLine in strLineArray)
                        {
                            if (elementLine.Length > 4)//一行信息完整,排除了帧头&&和帧尾！！
                            {
                                if (elementLine != "&&" || elementLine != "!!")//不是表头和表尾标志
                                {
                                    String str1 = elementLine.Substring(0, 2);
                                    String str2 = elementLine.Substring(2, 2);
                                    String str3 = elementLine.Substring(4, elementLine.Length - 4);
                                    DataRow dr = m_witsDataDT.NewRow();
                                    dr["TableNo"] = str1;
                                    dr["ItemIndex"] = str2;
                                    dr["Value"] = str3;
                                    //存接收的一帧数据（多表数据），用于显示
                                    m_witsDataDT.Rows.Add(dr);
                                    DataRow drTemp = tempTable.NewRow();
                                    drTemp["TableNo"] = str1;
                                    drTemp["ItemIndex"] = str2;
                                    drTemp["Value"] = str3;
                                    tempTable.Rows.Add(drTemp);
                                 }
                            }
                        }
                        //将解析出的一张表入队
                        if (tempTable.Rows.Count > 0)
                        {
                            m_tempTableQueue.Enqueue(tempTable);
                        }
                    }
                }
                //receiveWitsData_dataGridView显示一次接收到的数据
                receiveWitsData_dataGridView.DataSource = m_witsDataDT;
                receiveWitsData_dataGridView.FirstDisplayedScrollingRowIndex = receiveWitsData_dataGridView.Rows.Count-1;
                receiveWitsData_dataGridView.Refresh();
                //根据内容自动调整列宽
                receiveWitsData_dataGridView.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
                if (m_witsDataDT.Rows.Count>=1000)//显示1000行，清空
                {
                    m_witsDataDT.Clear();
                }
            }
        }
        
        //写库线程处理
        void _WriteDBThreadProcess()
        {
            createCurveNameDictionaryAndDB();
            //写入数据到数据库相应的表中
            while (m_isWriteDB)
            {
                try
                {
                    dtLock = new Object();
                    lock (dtLock)
                    {
                        DataTable dt = new DataTable();
                        if (m_tempTableQueue.TryDequeue(out dt))
                        {
                            Stopwatch sw = new Stopwatch();
                            sw.Start();
                            ParseTableData(dt, 0);
                            sw.Stop();
                            long time = sw.ElapsedMilliseconds;
                        }
                    }
                    dtLock = null;
                }
                catch (Exception e)
                {
                    System.Diagnostics.Trace.WriteLine("Main::WriteDBThreadProcess()->" + e.Message);
                }
            }
        }

        //创建curveName字典和数据库及其表
        private void createCurveNameDictionaryAndDB()
        {
            //创建数据库
            if (m_wellConfig_From.getwellcountPath() == "" || m_wellConfig_From.getwellcountPath() == null)
            {
                MessageBox.Show("未配置井路径，请配置！");
                return;
            }
            String wellcountPath = m_wellConfig_From.getwellcountPath();
            String wellcount = m_wellConfig_From.getwellcount();
            String filename = wellcount + ".db3";
            String dbPath = m_wellConfig_From.creatDirectory(wellcountPath, filename);
            m_realDBHelper = m_wellConfig_From.getRealDBHelper();
            m_realDBHelper.CreateDB(dbPath);
            //m_realDBHelper.InsertWellInfo(dbPath);
            m_dBHelper = new SQLiteDBHelper(dbPath);
            m_dBHelper.CreateDB(dbPath);
            List<String> serverTableList = new List<string>();
            List<String> clientTableList = new List<string>();
            DataTable curveNameTable = new DataTable();
            List<String> curveNameList = new List<string>();
            //获取Server和Client所选仪器及对应选择的表号
            Dictionary<String, List<String>> selectServerToolDictionary = m_recConfig_Form.getSelectServerToolDictionary();
            Dictionary<String, List<String>> selectClientToolDictionary = m_recConfig_Form.getSelectClientToolDictionary();
            //创建曲线字典和wits表
            if (selectServerToolDictionary != null)
            {
                foreach (String toolName in selectServerToolDictionary.Keys)
                {
                    if (selectServerToolDictionary.TryGetValue(toolName, out serverTableList))
                    {
                        //根据toolName创建Wits表字典，供查询index对应的curveName（短助记符）
                        Dictionary<String, DataTable> curveNameDictionary = m_CurveNameDictionary.createDictionary(toolName, serverTableList);
                        m_curveNameDictionary.Add(toolName, m_CurveNameDictionary.createDictionary(toolName, serverTableList));
                        serverTableList.Clear();
                        //同一个仪器名下的wits表
                        Dictionary<String, WitsTable> witsTableDic = new Dictionary<string, WitsTable>();
                        //创建数据库表和WITS表
                        foreach (String tableNo in curveNameDictionary.Keys)
                        {
                            if (curveNameDictionary.TryGetValue(tableNo, out curveNameTable))
                            {
                                for (int i = 0; i < curveNameTable.Rows.Count; i++)
                                {
                                    curveNameList.Add(curveNameTable.Rows[i][1].ToString());
                                }
                                m_dBHelper.CreateTabs(toolName, tableNo, curveNameList);
                                WitsTable witsTable = new WitsTable(toolName, tableNo, curveNameList);
                                witsTableDic.Add(tableNo, witsTable);
                                curveNameTable.Clear();
                                curveNameList.Clear();
                            }
                        }
                        m_witsTableDictionary.Add(toolName, witsTableDic);
                    }
                }
            }
            if (selectClientToolDictionary != null)
            {
                foreach (String toolName in selectClientToolDictionary.Keys)
                {
                    if (selectClientToolDictionary.TryGetValue(toolName, out clientTableList))
                    {
                        //根据toolName创建Wits表字典，供查询index对应的curveName（短助记符）
                        Dictionary<String, DataTable> curveNameDictionary = m_CurveNameDictionary.createDictionary(toolName, clientTableList);
                        m_curveNameDictionary.Add(toolName, m_CurveNameDictionary.createDictionary(toolName, clientTableList));
                        clientTableList.Clear();
                        //同一个仪器名下的wits表
                        Dictionary<String, WitsTable> witsTableDic = new Dictionary<string, WitsTable>();
                        //创建数据库表和WITS表
                        foreach (String tableNo in curveNameDictionary.Keys)
                        {
                            if (curveNameDictionary.TryGetValue(tableNo, out curveNameTable))
                            {
                                for (int i = 0; i < curveNameTable.Rows.Count; i++)
                                {
                                    curveNameList.Add(curveNameTable.Rows[i][1].ToString());
                                }
                                m_dBHelper.CreateTabs(toolName, tableNo, curveNameList);
                                WitsTable witsTable = new WitsTable(toolName, tableNo, curveNameList);
                                witsTableDic.Add(tableNo, witsTable);
                                curveNameTable.Clear();
                                curveNameList.Clear();
                            }
                        }
                        m_witsTableDictionary.Add(toolName, witsTableDic);
                    }
                }
            }
        }

        //根据数据源tempTable取出表号，查字典将curveName和Value值对应，然后写入相应数据库表中
        private void ParseTableData(DataTable tempTable, int columnIndex)
        {
            if (tempTable == null || tempTable.Rows.Count<=0)
            {
                return;
            }
            Dictionary<string, DataTable> curveNameDictionary = new Dictionary<string, DataTable>();
            DataTable dataTable = new DataTable();
            WitsTable witsTable = new WitsTable();
            //取出TableNo
            List<string> TableNolist = new List<string>();
            foreach (DataRow dr in tempTable.Rows)
            {
                string value = dr[columnIndex].ToString();
                if (!TableNolist.Contains(value))
                {
                    TableNolist.Add(value);
                }
            }
            //获取WitsTable用于保存解析后的数据，作为发送给数据库的数据源
            foreach (string toolName in m_curveNameDictionary.Keys)
            {
                if (m_curveNameDictionary.TryGetValue(toolName, out curveNameDictionary))
                {
                    foreach (string tableNo in curveNameDictionary.Keys)
                    {
                        //本次数据，含此表号，继续查询
                        if (TableNolist.Contains(tableNo))
                        {
                            if (curveNameDictionary.TryGetValue(tableNo, out dataTable))
                            {
                                    //根据TableNolist中TableNo,取出相应行的"ItemIndex"和"Value"
                                    foreach (DataRow drTemp in tempTable.Rows)
                                    {
                                        //该行第一列值与TableNo一致
                                        if (tableNo == drTemp[columnIndex].ToString())
                                        {
                                            //给dataTable赋值，将值与curveName对应
                                            foreach (DataRow dr in dataTable.Rows)
                                            {
                                                //通过tempTable的index和dataTable的ItemIndex匹配，给dataTable赋值
                                                if (drTemp["ItemIndex"].ToString() == dr["ItemIndex"].ToString())
                                                {
                                                    dr["Value"] = drTemp[columnIndex + 2];
                                                }
                                            }
                                        }
                                    }
                                    foreach (String strKey in m_witsTableDictionary[toolName].Keys)
                                    {
                                        if (strKey == tableNo)
                                        {
                                            if (m_witsTableDictionary[toolName].TryGetValue(tableNo, out witsTable))
                                            {
                                                DataRow witsRow = witsTable.NewRow();
                                                foreach (DataRow dr in dataTable.Rows)
                                                {
                                                    //两个curveName匹配，给witsTable赋值
                                                    if (witsTable.Columns.Contains(dr["curveName"].ToString()))
                                                    {
                                                        witsRow[dr["curveName"].ToString()] = dr["Value"];
                                                    }
                                                }
                                                witsTable.Rows.Add(witsRow);
                                                Stopwatch sw = new Stopwatch();
                                                sw.Start();
                                                m_dBHelper.InsertWitsData(toolName,tableNo, witsTable);
                                                sw.Stop();
                                                long time1 = sw.ElapsedMilliseconds;
                                                witsTable.Clear();
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
           }
        //receiveWitsData_dataGridView显示行号
        private void receiveWitsData_dataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (int i = 0; i < e.RowCount; i++)
            {
                this.receiveWitsData_dataGridView.Rows[e.RowIndex + i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                this.receiveWitsData_dataGridView.Rows[e.RowIndex + i].HeaderCell.Value = (e.RowIndex + i + 1).ToString();
            }
            for (int i = e.RowIndex + e.RowCount; i < this.receiveWitsData_dataGridView.Rows.Count; i++)
            {
                this.receiveWitsData_dataGridView.Rows[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                this.receiveWitsData_dataGridView.Rows[i].HeaderCell.Value = (i + 1).ToString();
            }        
        }

        private void receiveWitsData_dataGridView_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (receiveWitsData_dataGridView.Rows.Count != 0)
            {
                for (int i = 0; i < e.RowCount; i++)
                {
                    this.receiveWitsData_dataGridView.Rows[e.RowIndex + i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    this.receiveWitsData_dataGridView.Rows[e.RowIndex + i].HeaderCell.Value = (e.RowIndex + i + 1).ToString();
                }

                for (int i = e.RowIndex + e.RowCount; i < this.receiveWitsData_dataGridView.Rows.Count; i++)
                {
                    this.receiveWitsData_dataGridView.Rows[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    this.receiveWitsData_dataGridView.Rows[i].HeaderCell.Value = (i + 1).ToString();
                }
            }
        }
    }
}
