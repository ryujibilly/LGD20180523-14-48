using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Collections.Concurrent;
using System.Windows.Forms;
using LGD.DAL.SQLite;
using Tool;

namespace RealTimeDB
{
    public partial class RealTimeDBLogin : Form
    {
        private static String[] fragSep = new String[] {"!!\r\n","&&\r\n","!!","&&"};
        private static String[] dataSep = new String[] { "\r\n"};
        private static ConcurrentQueue<String> idQueue = new ConcurrentQueue<string>();
        private static ConcurrentQueue<WitsTable> tabQueue = new ConcurrentQueue<WitsTable>();
        List<String> namelist = new List<string>();
        public RealTimeDBLogin()
        {
            InitializeComponent();
            Tool.Config.GetConfig();
            openFileDialog_OpenDB.InitialDirectory = Tool.Config.CfgInfo.FoldBrowserPath;
            openFileDialog_ModDB.InitialDirectory = Tool.Config.CfgInfo.FoldBrowserPath;
        }
        /// <summary>
        /// 打开数据库文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_OpenDBFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog_OpenDB.ShowDialog(Owner) == DialogResult.OK)
            {
                //openFileDialog1.Filter = "数据库文件(*.db)|*.db|SQLite2(*.db2)|*.db2|SQLite3(*.db3)|*.db3|所有文件(*.*)|*.*";
                openFileDialog_OpenDB.CheckFileExists = true;
                openFileDialog_OpenDB.CheckPathExists = true;
                Config.CfgInfo.DBPath_Well = openFileDialog_OpenDB.FileName;
                Config.SaveConfig();
                textBox_open_dbpathwell.Text = openFileDialog_OpenDB.FileName;
            }
        }

        private void RealTimeDBLogin_Load(object sender, EventArgs e)
        {
            if(Config.CfgInfo.StaticDB_PATH!=null|| Config.CfgInfo.StaticDB_PATH != string.Empty)
            textBox_StaticDBPath.Text = Config.CfgInfo.StaticDB_PATH;
            textBox_NewDBPath.Text = Config.CfgInfo.FoldBrowserPath;
            folderBrowserDialog_NewProject.SelectedPath = Config.CfgInfo.FoldBrowserPath;
        }
        /// <summary>
        /// 指定模板库路径
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_OpenModDB_Click(object sender, EventArgs e)
        {
            if (openFileDialog_ModDB.ShowDialog(Owner) == DialogResult.OK)
            {
                //openFileDialog1.Filter = "数据库文件(*.db)|*.db|SQLite2(*.db2)|*.db2|SQLite3(*.db3)|*.db3|所有文件(*.*)|*.*";
                openFileDialog_ModDB.CheckFileExists = true;
                openFileDialog_ModDB.CheckPathExists = true;
                Config.CfgInfo.StaticDB_PATH = openFileDialog_ModDB.FileName;
                textBox_StaticDBPath.Text = openFileDialog_ModDB.FileName;
                Config.SaveConfig();
            }
        }
        /// <summary>
        /// 选择新建工区文件夹
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_NewDB_Click(object sender, EventArgs e)
        {
            if(folderBrowserDialog_NewProject.ShowDialog(Owner)==DialogResult.OK)
            {
                Config.CfgInfo.FoldBrowserPath = folderBrowserDialog_NewProject.SelectedPath;
                textBox_NewDBPath.Text = folderBrowserDialog_NewProject.SelectedPath;
                Config.SaveConfig();
            }
        }
        /// <summary>
        /// 向新建工区添加数据库模板的拷贝
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_NewProject_Click(object sender, EventArgs e)
        {
            try
            {
                if (Directory.Exists(Config.CfgInfo.FoldBrowserPath))
                {
                    string destPath = Config.CfgInfo.FoldBrowserPath+"\\" + textBox_new_wellname.Text.Trim() + "_" + textBox_new_wellid.Text.Trim() + "_" + textBox_new_welltime.Text.Trim() + ".db3";
                    if (new SQLiteDBHelper(Config.CfgInfo.StaticDB_PATH).DBCopy(Config.CfgInfo.StaticDB_PATH, destPath))
                        MessageBox.Show("工区及数据库创建成功！");
                    else MessageBox.Show("模板库的源路径或目标路径不存在，请检查文件！");
                }
                else
                {
                    Directory.CreateDirectory(Config.CfgInfo.StaticDB_PATH + "..\\" + textBox_new_wellname.Text.Trim() + "\\");
                    string destPath = Config.CfgInfo.FoldBrowserPath + textBox_new_wellname.Text.Trim() + "_" + textBox_new_wellid.Text.Trim() + "_" + textBox_new_welltime.Text.Trim() + ".db3";
                    if (SQLiteDBHelper._sqliteHelper.DBCopy(Config.CfgInfo.StaticDB_PATH, destPath))
                        MessageBox.Show("工区及数据库创建成功！");
                    else MessageBox.Show("模板库的源路径或目标路径不存在，请检查文件！");
                }
            }
            catch (Exception)
            {

                throw;
            }
    
        }

        private void button_NewDBFile_Click(object sender, EventArgs e)
        {
            SQLiteDBHelper _helper = new SQLiteDBHelper(Config.CfgInfo.StaticDB_PATH);
            string path = Config.CfgInfo.FoldBrowserPath+"\\" + textBox_new_wellname.Text.Trim() + "_" + textBox_new_wellid.Text.Trim() + "_" + textBox_new_welltime.Text.Trim() + ".db3";
            _helper.CreateDB(path, namelist);

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.CheckState == CheckState.Checked)
                namelist.Add("01");
            else namelist.Remove("01");
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.CheckState == CheckState.Checked)
                namelist.Add("02");
            else namelist.Remove("02");
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.CheckState == CheckState.Checked)
                namelist.Add("07");
            else namelist.Remove("07");
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.CheckState == CheckState.Checked)
                namelist.Add("08");
            else namelist.Remove("08");
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.CheckState == CheckState.Checked)
                namelist.Add("11");
            else namelist.Remove("11");
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.CheckState == CheckState.Checked)
                namelist.Add("12");
            else namelist.Remove("12");
        }

        private void button_Send_Click(object sender, EventArgs e)
        {
            SQLiteDBHelper _helper = new SQLiteDBHelper(Config.CfgInfo.DBPath_Well);
            ConcurrentQueue<String> frags = new ConcurrentQueue<string>();
            String[] tempFrags;
            String data;
            String tabid;
            WitsTable wt;
            String frag;
            data = textBox_SendData.Text.Trim();
            tempFrags=data.Split(fragSep, StringSplitOptions.RemoveEmptyEntries);
            foreach (String str in tempFrags)
                frags.Enqueue(str);
            while(frags.Count>0)
            {
                frags.TryDequeue(out frag);
                toWitsTable(frag, out tabid);
                if(tabQueue.Count>0)
                {
                    tabQueue.TryDequeue(out wt);
                    idQueue.TryDequeue(out tabid);
                    _helper.WitsTabAnalysis(tabid,wt);
                    _helper.InsertWitsData(tabid, wt);
                }
            }
        }
        public static void toWitsTable(String str,out String tabid)
        {
            WitsTable wt = new WitsTable();
            DataRow dr;
            ConcurrentQueue<String> itemIndexs = new ConcurrentQueue<string>();
            ConcurrentQueue<String> values = new ConcurrentQueue<string>();
            String[] temp;
            temp = str.Split(dataSep, StringSplitOptions.RemoveEmptyEntries);
            tabid=temp[0].Substring(0, 2);
            foreach (String var in temp)
            {
                itemIndexs.Enqueue(var.Substring(2, 2));
                values.Enqueue(var.Substring(4, var.Length - 4));
            }

            while(itemIndexs.Count>0&&values.Count>0)
            {
                String itemIndex;
                String value;
                itemIndexs.TryDequeue(out itemIndex);
                values.TryDequeue(out value);
                dr = wt.NewRow();
                dr.ItemArray = new String[] { itemIndex,value};
                wt.Rows.Add(dr);
            }
            idQueue.Enqueue(tabid);
            tabQueue.Enqueue(wt);
        }
    }
}
