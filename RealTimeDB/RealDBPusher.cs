using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using WebService;
using WebService.realdbws;
using Tool;
using Tool.Json;
using System.Web.Services.Protocols;
using System.Net;
using Newtonsoft;
using Newtonsoft.Json;
using System.Diagnostics;
using WitsTransmission;
using WitsTransmission.WellConfig;
using WitsTransmission.XMLUtil;
using LGD.DAL.SQLite;
using System.Collections.Concurrent;
using System.Threading;
using Tool.Timer;
using RealTimeDB;

namespace RealTimeDB
{

    public partial class RealDBPusher : Form
    {
        #region 字段、属性
        private DataTable JsonTable = new DataTable();
        private DataTable tsmdt = new DataTable();
        private String JsonString = string.Empty;
        private List<String> instName = new List<String>();
        private List<String> instDesc = new List<String>();
        private String curInst=String.Empty;
        private static SQLiteDBHelper realDBHelper;
        private String instru = "";
        private Thread statusThread;


        //treeview
        private bool isComboxInstClear = false;
        public XMLUtil m_xmlUtil = new XMLUtil();
        public List<CheckBox> m_checkBoxList = new List<CheckBox>();
        public List<String> m_recordAttributesList = new List<String>();
        public List<String> m_itemAttributesList = new List<String>();
        //保存WitsTable_treeView选择的表
        public List<String> m_selectedTableList = new List<string>();
        //保存Server选的的仪器及对应选择的表
        Dictionary<String, List<String>> m_selectServerToolDictionary = new Dictionary<string, List<string>>();
        //保存Client选的的仪器及对应选择的表
        Dictionary<String, List<String>> m_selectClientToolDictionary = new Dictionary<string, List<string>>();

        private List<List<String>> titleList = new List<List<string>>();
        //AdvancedOption
        private int interval=30;
        private int repeat=3;
        private int fps=100;
        private bool isHold=true;
        private bool isCover=true;

        //for test
        //WebService1 ws1 = new WebService1();

        //webservice url
        String url = "http://10.242.0.186/realdb/services/realdbservices";
        String user="yuwenmao";
        String password = "123";

        //Date & Time
        private String beginDate;
        private String beginTime;
        private String endDate;
        private String endTime;
        private bool isFromTopDateTime;
        private bool isToNowDateTime;
        public string Url
        {
            get
            {
                return url;
            }

            set
            {
                url = value;
            }
        }
        /// <summary>
        /// 仪器名称(英文)
        /// </summary>
        public List<string> InstName
        {
            get
            {
                return instName;
            }

            set
            {
                instName = value;
            }
        }
        /// <summary>
        /// 仪器描述(中文)
        /// </summary>
        public List<string> InstDesc
        {
            get
            {
                return instDesc;
            }

            set
            {
                instDesc = value;
            }
        }
        /// <summary>
        /// 当前所选仪器
        /// </summary>
        public string CurInst
        {
            get
            {
                return curInst;
            }

            set
            {
                curInst = value;
            }
        }
        /// <summary>
        /// 推送间隔
        /// </summary>
        public int Interval
        {
            get
            {
                return interval;
            }

            set
            {
                interval = value;
            }
        }
        /// <summary>
        /// 重复次数
        /// </summary>
        public int Repeat
        {
            get
            {
                return repeat;
            }

            set
            {
                repeat = value;
            }
        }
        /// <summary>
        /// 推送帧数
        /// </summary>
        public int Fps
        {
            get
            {
                return fps;
            }

            set
            {
                fps = value;
            }
        }
        /// <summary>
        /// 是否保持工作
        /// </summary>
        public bool IsHold
        {
            get
            {
                return isHold;
            }

            set
            {
                isHold = value;
            }
        }

        public bool IsCover
        {
            get
            {
                return isCover;
            }

            set
            {
                isCover = value;
            }
        }
        /// <summary>
        /// 本地井次对应的实时库
        /// </summary>
        public static SQLiteDBHelper RealDBHelper
        {
            get
            {
                return realDBHelper;
            }

            set
            {
                realDBHelper = value;
            }
        }
        /// <summary>
        /// 推送数据起始日期
        /// </summary>
        public string BeginDate
        {
            get
            {
                return beginDate;
            }

            set
            {
                beginDate = value;
            }
        }
        /// <summary>
        /// 推送数据起始时间
        /// </summary>
        public string BeginTime
        {
            get
            {
                return beginTime;
            }

            set
            {
                beginTime = value;
            }
        }
        /// <summary>
        /// 推送数据截至日期
        /// </summary>
        public string EndDate
        {
            get
            {
                return endDate;
            }

            set
            {
                endDate = value;
            }
        }
        /// <summary>
        /// 推送数据截至时间
        /// </summary>
        public string EndTime
        {
            get
            {
                return endTime;
            }

            set
            {
                endTime = value;
            }
        }
        /// <summary>
        /// 是否设置推送时间日期为从头开始
        /// </summary>
        public bool IsFromTopDateTime
        {
            get
            {
                return isFromTopDateTime;
            }

            set
            {
                isFromTopDateTime = value;
            }
        }
        /// <summary>
        /// 是否设置推送时间日期为最后一条数据
        /// </summary>
        public bool IsToNowDateTime
        {
            get
            {
                return isToNowDateTime;
            }

            set
            {
                isToNowDateTime = value;
            }
        }

        /// <summary>
        /// 仪器名
        /// </summary>
        public string Instru
        {
            get
            {
                return instru;
            }

            set
            {
                instru = value;
            }
        }
        /// <summary>
        /// 每张表的字段名列表
        /// </summary>
        public List<List<string>> TitleList
        {
            get
            {
                return titleList;
            }

            set
            {
                titleList = value;
            }
        }
        /// <summary>
        /// Status Monitor Data Table传输状态监视表
        /// </summary>
        public DataTable TSMdt
        {
            get
            {
                return tsmdt;
            }

            set
            {
                tsmdt = value;
            }
        }
        /// <summary>
        /// 更新推送状态信息
        /// </summary>
        public Thread StatusThread
        {
            get
            {
                return statusThread;
            }

            set
            {
                statusThread = value;
            }
        }
        #endregion

        public RealDBPusher()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //label3.Text = "=" + ws1.Add(int.Parse(textBox3.Text.Trim()), int.Parse(textBox4.Text.Trim()));
        }

        private void textBox_UserName_TextChanged(object sender, EventArgs e)
        {
            user = textBox_UserName.Text.Trim();
        }

        private void textBox_PassWord_TextChanged(object sender, EventArgs e)
        {
            password = textBox_PassWord.Text.Trim();
        }

        private void button_Connect_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = Pusher._pusher.GetAllRegions(out JsonString);
                //dataGridView1.DataSource = dt;
                //dataGridView1.Refresh();
            }
            catch (System.Exception)
            {
                throw;
            }

        }

        private void RealDBPusher_Load(object sender, EventArgs e)
        {
            timer_Push=new MMTimer(this.timer_Push_Tick);
            m_checkBoxList.Add(logging_checkBox);//测井
            m_checkBoxList.Add(wellLog_checkBox);//录井
            m_checkBoxList.Add(drilling_checkBox);//钻井
            isComboxInstClear = false;
            m_recordAttributesList.Add("index");
            m_recordAttributesList.Add("describe");
            m_itemAttributesList.Add("index");
            m_itemAttributesList.Add("describe");
            m_itemAttributesList.Add("short-mnemonic");
            //TSMdt = this.CreateStatusMonitorDT();
            //dataGridView_StatusMonitor.DataSource = TSMdt;
            StatusThread = new Thread(new ThreadStart(updatestatus));
            //pusher = new Pusher(textBox_UserName.Text, textBox_PassWord.Text);
            Pusher._pusher.ConnectTest();
            this.Interval = int.Parse(Properties.Settings.Default.Interval.ToString());
            this.Repeat = int.Parse(Properties.Settings.Default.Repeat.ToString());
            this.Fps = int.Parse(Properties.Settings.Default.FPS.ToString());
        }
        private DataTable CreateStatusMonitorDT()
        {
            DataTable dt = new DataTable("StatusMonitorDT");
            DataColumn dc1 = new DataColumn("表号");
            DataColumn dc2 = new DataColumn("累计传输记录/条");
            dt.Columns.Add(dc1);
            dt.Columns.Add(dc2);
            return dt;
        }

        private void button_GetAllInstInfo_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = Pusher._pusher.GetAllInstName(out JsonString);

                foreach(DataRow dr in dt.Rows)
                {
                    string name = dr[0].ToString();
                    string desc = dr[1].ToString();
                    InstName.Add(name);
                    InstDesc.Add(desc);
                }
                //从服务器获取仪器信息，并添加到仪器列表
                //comboBox_Inst.Items.Clear();
                //comboBox_Inst.Items.AddRange(InstDesc.ToArray<string>());
                //isComboxInstClear = true;
                //comboBox_Inst.SelectedIndex = 0;
                //dataGridView1.DataSource = dt;
                //dataGridView1.Refresh();
            }
            catch (System.Exception)
            {
                throw;
            }

        }

        private void button_ConnectTest_Click(object sender, EventArgs e)
        {
            //pusher = new Pusher(textBox_UserName.Text, textBox_PassWord.Text);
            if (Pusher._pusher.ConnectTest())
                MessageBox.Show("连接成功！");
            else MessageBox.Show("连接异常！");
        }

        private void comboBox_Inst_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = comboBox_Inst.SelectedIndex;
            //DataTable dt = pusher.GetInstInfoByName(CurInst, out JsonString);
            //dataGridView1.DataSource = dt;
            //dataGridView1.Refresh();

            WitsTable_treeView.Nodes.Clear();//清空树显示
            m_selectedTableList.Clear();//清空上次选择仪器所对应的所选的表
            String strSelected = comboBox_Inst.Items[index].ToString();
            Instru = strSelected;
            Pusher._pusher.Instname = Instru;
            //根据ComboBox选择，从WITS.xml中读取相应仪器的record信息，加载到WitsTable_treeView第一级节点
            List<List<String>> recordList = new List<List<String>>();
            recordList = m_xmlUtil.getSubChildNodes(m_xmlUtil.getChildNodes(m_xmlUtil.getRoot(m_xmlUtil.getDocument("WITS.xml"))), m_recordAttributesList, strSelected);
            m_xmlUtil.m_xmlReader.Close();
            foreach (List<String> recordAttributeList in recordList)
            {
                //添加TreeGridView的第一级节点
                TreeNode rootNode = new TreeNode();
                foreach (String strRecordAttribute in recordAttributeList)
                {
                    rootNode.Text += strRecordAttribute;
                }
                //根据ComboBox选择和record，从WITS.xml中读取相应仪器的某个record下的所有item信息，加载到WitsTable_treeView第二级节点
                List<List<String>> itemList = new List<List<String>>();
                itemList = m_xmlUtil.getSubSubChildNodes(m_xmlUtil.getSubChildNodes(m_xmlUtil.getChildNodes(m_xmlUtil.getRoot(m_xmlUtil.getDocument("WITS.xml"))), strSelected), m_itemAttributesList, "index", rootNode.Text.Substring(0, 2));
                m_xmlUtil.m_xmlReader.Close();
                foreach (List<String> itemAttributeList in itemList)
                {
                    TreeNode childNode = new TreeNode();
                    foreach (String strItemAttribute in itemAttributeList)
                    {
                        childNode.Text += strItemAttribute;
                    }
                    rootNode.Nodes.Add(childNode);
                }
                WitsTable_treeView.Nodes.Add(rootNode);
            }
        }

        private void button_OpenLocalLog_Click(object sender, EventArgs e)
        {
            WellConfig_Form wcf = new WellConfig_Form();
            wcf.ShowDialog();
            if (wcf.DialogResult == DialogResult.OK)
            {
                textBox_LocalLog.Text = wcf.getwellcountPath();
                RealDBHelper = new SQLiteDBHelper(wcf.getwellcountPath()+".db3");
                Pusher._pusher.Dbhelper = RealDBHelper;
                Properties.Settings.Default.RealDBPath = RealDBHelper.RealDBPath;
            }
        }

        private void logging_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!isComboxInstClear)
                comboBox_Inst.Items.Clear();
            //checkBox多选,获取所选控件的Text，存入m_toolTypeList
            foreach (CheckBox cb in m_checkBoxList)
            {
                if (cb.Checked == true)
                {
                    //根据选择，从ToolInfo.xml中读取相应仪器信息加入tool_comboBox控件
                    List<String> strList = new List<String>();
                    strList = m_xmlUtil.getSubChildNodes(m_xmlUtil.getChildNodes(m_xmlUtil.getRoot(m_xmlUtil.getDocument("ToolInfo.xml"))), "name", cb.Text);
                    m_xmlUtil.m_xmlReader.Close();
                    foreach (String str in strList)
                    {
                        //tool_comboBox中该项不存在，则添加
                        if (!comboBox_Inst.Items.Contains(str))
                        {
                            comboBox_Inst.Items.Add(str);
                            isComboxInstClear = true;
                        }
                    }
                }
                else
                {
                    //根据选择，从ToolInfo.xml中读取相应仪器信息，从tool_comboBox控件移除
                    List<String> strList = new List<String>();
                    strList = m_xmlUtil.getSubChildNodes(m_xmlUtil.getChildNodes(m_xmlUtil.getRoot(m_xmlUtil.getDocument("ToolInfo.xml"))), "name", cb.Text);
                    m_xmlUtil.m_xmlReader.Close();
                    foreach (String str in strList)
                    {
                        ////tool_comboBox中该项存在，则移除
                        if (comboBox_Inst.Items.Contains(str) && str != "Common")
                        {
                            comboBox_Inst.Items.Remove(str);
                        }
                        if (comboBox_Inst.Items.Count == 1 && str == "Common")
                        {
                            comboBox_Inst.Items.Remove(str);
                        }
                    }
                    if (comboBox_Inst.Items.Count == 0)
                    {
                        comboBox_Inst.ResetText();
                        WitsTable_treeView.Nodes.Clear();
                    }
                }
            }
        }

        private void WitsTable_treeView_AfterCheck(object sender, TreeViewEventArgs e)
        {
            String toolName = comboBox_Inst.SelectedItem.ToString();
            if (e.Action == TreeViewAction.ByMouse)
            {
                int k = 0;
                //如果是父节点并且是被选中的，被选中子节点被选中
                if (e.Node.Parent == null && e.Node.GetNodeCount(true) != 0 && e.Node.Checked)
                {
                    setChildNodeCheckedState(e.Node, true);
                }
                //如果是父节点并且不是被选中的，被选中子节点不被选中
                else if (e.Node.Parent == null && e.Node.GetNodeCount(true) != 0 && e.Node.Checked == false)
                {
                    setChildNodeCheckedState(e.Node, false);
                }
                //如果是子节点，并且是被选中的
                else if (e.Node.Parent != null && e.Node.Checked == true)
                {
                    setParentNodeCheckedState(e.Node, true);
                }
                //如果是子节点，并且不是被选中
                else if (e.Node.Parent != null && e.Node.Checked == false)
                {
                    //遍历所有的节点
                    for (int i = 0; i < e.Node.Parent.Nodes.Count; i++)
                    {
                        //如果有其中有一个被选中的,父节点也被选中
                        if (e.Node.Parent.Nodes[i].Checked)
                        {
                            k++;
                        }
                    }
                    if (k > 0)
                    {
                        setParentNodeCheckedState(e.Node, true);
                    }
                    else
                    {
                        setParentNodeCheckedState(e.Node, false);
                    }
                }
            }
            //父节点被选中，将其内容添加到m_selectedTableList
            if (e.Node.Parent == null && e.Node.GetNodeCount(true) != 0)
            {

                if (!m_selectServerToolDictionary.Keys.Contains(toolName))//不存在该仪器名
                {
                    m_selectedTableList.Clear();//清空上次选择仪器所对应的所选的表
                    if (e.Node.Checked)
                    {
                        m_selectedTableList.Add(e.Node.Text.ToString().Substring(0, 2));//如表号"01"
                    }
                    else
                    {
                        m_selectedTableList.Remove(e.Node.Text.ToString().Substring(0, 2));
                    }
                    List<String> selectedTableList = new List<string>();
                    foreach (String str in m_selectedTableList)
                    {
                        selectedTableList.Add(str);
                    }
                    m_selectServerToolDictionary.Add(toolName, selectedTableList);
                }
                else
                {
                    for (int i = 0; i < m_selectServerToolDictionary.Count; i++)
                    {
                        if (m_selectServerToolDictionary.ElementAt(i).Key == toolName)//与所选仪器名一致
                        {
                            if (e.Node.Checked)
                            {
                                m_selectedTableList.Add(e.Node.Text.ToString().Substring(0, 2));//如表号"01"
                            }
                            else
                            {
                                m_selectedTableList.Remove(e.Node.Text.ToString().Substring(0, 2));
                            }
                            List<String> selectedTableList = new List<string>();
                            foreach (String str in m_selectedTableList)
                            {
                                selectedTableList.Add(str);

                            }
                            //每次添加前移除，确保最后一次添加的是所选仪器对应所选的表全集
                            m_selectServerToolDictionary.Remove(toolName);
                            m_selectServerToolDictionary.Add(toolName, selectedTableList);
                        }
                    }
                }
            }
            Pusher._pusher.selectedTabList = this.m_selectedTableList;
        }
        //取消节点选中状态之后，取消所有父节点的选中状态
        private void setParentNodeCheckedState(TreeNode currNode, bool state)
        {
            TreeNode parentNode = currNode.Parent;
            parentNode.Checked = state;
            if (currNode.Parent.Parent != null)
            {
                setParentNodeCheckedState(currNode.Parent, state);
            }
        }
        //选中节点之后，选中节点的所有子节点
        private void setChildNodeCheckedState(TreeNode currNode, bool state)
        {
            TreeNodeCollection nodes = currNode.Nodes;
            if (nodes.Count > 0)
            {
                foreach (TreeNode tn in nodes)
                {
                    tn.Checked = state;
                    setChildNodeCheckedState(tn, state);
                }
            }
        }
        #region 全选或全不选
        //全选
        private void button_SelectAll_Click(object sender, EventArgs e)
        {
            CheckAllParentNodes(WitsTable_treeView, true, true);
        }
        //全不选
        private void button_AllNone_Click(object sender, EventArgs e)
        {
            CheckAllParentNodes(WitsTable_treeView, false, false);
        }

        //全选或全不选父节点
        public void CheckAllParentNodes(TreeView treeView, bool parentNodeChecked, bool nodeChecked)
        {
            foreach (TreeNode node in treeView.Nodes)
            {
                CheckAllChildNodes(node, node.Checked = nodeChecked);
                bool bol = parentNodeChecked;
                if (node.Parent != null)
                {
                    for (int i = 0; i < node.Parent.Nodes.Count; i++)
                    {
                        if (!node.Parent.Nodes[i].Checked)
                            bol = !parentNodeChecked;
                    }
                    node.Parent.Checked = bol;
                }
            }
        }
        //全选或全不选子节点
        public void CheckAllChildNodes(TreeNode treeNode, bool nodeChecked)
        {
            foreach (TreeNode node in treeNode.Nodes)
            {
                node.Checked = nodeChecked;
                if (node.Nodes.Count > 0)
                {
                    this.CheckAllChildNodes(node, nodeChecked);
                }
            }
        }
        #endregion
        /// <summary>
        /// 高级选项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_AdvancedOption_Click(object sender, EventArgs e)
        {
            AdvancedOption ao = new AdvancedOption();
            ao.ShowDialog();
            if(ao.DialogResult==DialogResult.OK)
            {
                Interval = ao.Interval;
                Repeat = ao.Repeat;
                Fps = ao.Fps;
                IsHold = ao.IsHold;
            }
            if(ao.DialogResult==DialogResult.No)
            {
                Interval = 30;
                Repeat = 3;
                Fps = 100;
                IsHold = false;
            }
        }

        private void checkBox_DataCover_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_DataCover.Checked)
                IsCover = true;
            else if (!checkBox_DataCover.Checked)
                IsCover = false;
        }

        private void dateTimePicker_Begin_ValueChanged(object sender, EventArgs e)
        {
            BeginDate = dateTimePicker_Begin.Value.Date.ToString("yyyyMMdd");
            BeginTime = "000000";
        }
        private void dateTimePicker_End_ValueChanged(object sender, EventArgs e)
        {
            EndDate = dateTimePicker_End.Value.Date.ToString("yyyyMMdd");
            EndTime = "235959";
        }

        private void checkBox_DateFromTop_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_DateFromTop.Checked)
            {
                BeginDate = "20000101";
                BeginTime = "000000";
                dateTimePicker_Begin.Enabled = false;
                IsFromTopDateTime = true;
            }
            else if (!checkBox_DateFromTop.Checked)
            {
                dateTimePicker_Begin.Enabled = true;
                IsFromTopDateTime = false;
            }

        }

        private void checkBox_DateToBottom_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox_DateToBottom.Checked)
            {
                dateTimePicker_End.Enabled = false;
                EndDate = DateTime.Now.Date.ToString("yyyyMMdd");
                EndTime = DateTime.Now.ToString("HHmmss");
                IsToNowDateTime = true;
            }
            else if (!checkBox_DateToBottom.Checked)
            {
                dateTimePicker_End.Enabled = true;
                IsToNowDateTime = false;
            }

        }

        /// <summary>
        /// 测试
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_testPush_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DataColumn dc1 = new DataColumn("序号");
            dc1.AllowDBNull = false;
            dc1.ReadOnly=true;
            DataColumn dc2 = new DataColumn("表名");
            dc2.AllowDBNull = false;
            dc2.ReadOnly = true;
            dt.Columns.Add(dc1);
            dt.Columns.Add(dc2);
            int i = 0;
            foreach(String str in m_selectedTableList)
            {
                DataRow dr = dt.NewRow();
                object[] item = new object[2];
                item[0]=(object)i++.ToString();
                item[1]=(object)str;
                dr.ItemArray = item;
                dt.Rows.Add(item);
                Thread.Sleep(Interval * 1000);
            }
            i = 0;
            //dataGridView1.DataSource = dt;
            //dataGridView1.Refresh();
        }



        private void button_Push_Click(object sender, EventArgs e)  
        {
            try
            {
                Pusher._pusher.SendSumDic.Clear();
                //创建发送计数字典！
                if (m_selectServerToolDictionary.Count > 0)
                    foreach (String recno in m_selectServerToolDictionary[Instru])
                        Pusher._pusher.SendSumDic.Add(recno, 0);
                timer_Push.Interval = Interval;
                Pusher._pusher.RowidTimer.Interval = Interval;
                Pusher._pusher.IsPushing = true;
                //获取字段名
                this.getTitleList();
                //推送计时器启动
                timer_Push.Start(true);
                //rowid对比计时器
                Pusher._pusher.RowidTimer.Start(true);
                //推送线程启动/继续
                if (!Pusher._pusher.PushingThread.IsAlive)
                {
                    Pusher._pusher.PushingThread.Start();
                    if (Pusher._pusher.PushingThread.ThreadState == System.Threading.ThreadState.Suspended)
                        Pusher._pusher.PushingThread.Resume();
                }
                //状态监视线程启动/继续
                if (!StatusThread.IsAlive)
                {
                    StatusThread.Start();
                    if (StatusThread.ThreadState == System.Threading.ThreadState.Suspended)
                        StatusThread.Resume();
                }
                dataGridView2.DataSource = Pusher._pusher.IndexTable;
                button_Push.Enabled = false;
                button_StopPush.Enabled = true;
            }
            catch (System.Exception ex)
            {
                button_Push.Enabled = true;
                button_StopPush.Enabled = false;
                Debug.WriteLine(ex.Message);
            }
        }
        void updatestatus()
        {
            try
            {
                while(true)
                {
                    if(Pusher._pusher.SendStatusQ.Count>0)
                    {
                        string status = "";
                        if (Pusher._pusher.SendStatusQ.TryDequeue(out status))
                        {
                            listBox_UpdateStatus.Items.Add(status);
                            listBox_UpdateStatus.SelectedIndex = listBox_UpdateStatus.Items.Count - 1;
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// 获取每个表的字段名
        /// </summary>
        private void getTitleList()
        {
            foreach(String tabname in m_selectedTableList)
            {
                List<String> tempList = new List<string>();
                tempList= RealDBHelper.getTitleList(tabname + "-" + Instru);
                TitleList.Add(tempList);
                Pusher._pusher.TitleDict.Add(tabname + "-" + Instru, tempList);
            }
            Pusher._pusher.TitleList = TitleList;
        }

        private void button_OpenRemoteLog_Click(object sender, EventArgs e)
        {
            RemoteWell rw = new RemoteWell();
            rw.ShowDialog();
            if(rw.DialogResult==DialogResult.OK)
            {
                Pusher._pusher.Logid = rw.LogId;
                textBox_RemoteLog.Text = @"//10.242.0.186//" + rw.RegionName + "/" + rw.WellName + "/" + rw.SelectedLogName;
            }
        }

        private void timer_Push_Tick(uint uTimerID, uint uMsg, UIntPtr dwUser, UIntPtr dw1, UIntPtr dw2)
        {
            try
            {
                if (!checkBox_DateToBottom.Checked)
                    Pusher._pusher.getData(RealDBHelper, m_selectedTableList, Instru, BeginDate, BeginTime, EndDate, EndTime);
                else
                {
                    if (Pusher._pusher.getData(RealDBHelper, m_selectedTableList, Instru, BeginDate, BeginTime, Fps))
                    {
                        timer_Push.Stop();
                    }
                    else
                    {
                        //TSMdt.Clear();
                        //foreach (String recno in Pusher._pusher.SendSumDic.Keys)
                        //{
                        //    DataRow dr = TSMdt.NewRow();
                        //    dr.ItemArray[0] = (object)recno;
                        //    dr.ItemArray[1] = (object)Pusher._pusher.SendSumDic[recno];
                        //    TSMdt.Rows.Add(dr);
                        //}
                        //dataGridView_StatusMonitor.DataSource = TSMdt;
                    }
                }
            }
            catch (System.Exception ex)
            {
                Debug.WriteLine(ex.Message + "RealDBPusher.cs-timer_Push_Tick()");
            }
 
        }

        private void button_StopPush_Click(object sender, EventArgs e)
        {
            try
            {
                Pusher._pusher.IsPushing = false;
                //推送线程 挂起
                Pusher._pusher.PushingThread.Suspend();
                //监控线程 挂起
                statusThread.Suspend();
                //计时器
                timer_Push.Stop();
                button_StopPush.Enabled = false;
                button_Push.Enabled = true;
            }
            catch (System.Exception)
            {
                button_StopPush.Enabled = true; 
                button_Push.Enabled = true;
            }
        }
        /// <summary>
        /// 关闭窗体前，保存推送状态到PushingInfo.xml文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RealDBPusher_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
