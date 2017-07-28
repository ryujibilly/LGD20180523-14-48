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
            openFileDialog1.InitialDirectory = Tool.Config.CfgInfo.FoldBrowserPath;
        }

        private void button_OpenDBFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog(Owner) == DialogResult.OK)
            {
                //openFileDialog1.Filter = "数据库文件(*.db)|*.db|SQLite2(*.db2)|*.db2|SQLite3(*.db3)|*.db3|所有文件(*.*)|*.*";
                openFileDialog1.CheckFileExists = true;
                openFileDialog1.CheckPathExists = true;
                Tool.Config.CfgInfo.DBPath_Well = openFileDialog1.FileName;
                Tool.Config.SaveConfig();
                textBox_open_dbpathwell.Text = openFileDialog1.FileName;
            }
        }
    }
}
