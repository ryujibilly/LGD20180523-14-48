using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RealTimeDB
{
    public partial class RealTimeDBLogin : Form
    {
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
                Tool.Config.CfgInfo.DBPath_Well = openFileDialog_OpenDB.FileName;
                Properties.Settings.Default.DBPath_Well= openFileDialog_OpenDB.FileName;
                Tool.Config.SaveConfig();
                textBox_open_dbpathwell.Text = openFileDialog_OpenDB.FileName;
            }
        }

        private void RealTimeDBLogin_Load(object sender, EventArgs e)
        {

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
                Tool.Config.CfgInfo.StaticDB_PATH = openFileDialog_ModDB.FileName;
                textBox_StaticDBPath.Text = openFileDialog_ModDB.FileName;
                Tool.Config.SaveConfig();
            }
        }
        /// <summary>
        /// 新工区里创建模板数据库的拷贝
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_NewDB_Click(object sender, EventArgs e)
        {
            if(folderBrowserDialog_NewProject.ShowDialog(Owner)==DialogResult.OK)
            {
                Tool.Config.CfgInfo.FoldBrowserPath = folderBrowserDialog_NewProject.SelectedPath;
                textBox_NewDBPath.Text = folderBrowserDialog_NewProject.SelectedPath;
                Tool.Config.SaveConfig();
            }
        }
    }
}
