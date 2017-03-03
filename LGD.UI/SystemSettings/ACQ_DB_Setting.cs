using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace LGD.UI.SystemSettings
{
    public partial class ACQ_DB_Setting : Form
    {
        public ACQ_DB_Setting()
        {
            InitializeComponent();
            showToolBar = true;
            showStatusBar = true;
        }
        /// <summary>
        /// 显示工具栏
        /// </summary>
        private Boolean showToolBar { get; set; }
        /// <summary>
        /// 显示状态条
        /// </summary>
        private Boolean showStatusBar { get; set; }

        private void ToolStripMenuItem_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ToolStripMenuItem_DBSetting_Click(object sender, EventArgs e)
        {
            DBSetting dbs = new DBSetting();
            dbs.ShowDialog();
        }

        private void ACQ_DB_Setting_Load(object sender, EventArgs e)
        {
            dataSet1.BeginInit();
            toolStripStatusLabel1.Text = System.DateTime.Now.ToLongDateString();
            toolStripStatusLabel2.Text = System.DateTime.Now.ToLongTimeString();
            timer1.Start();
            if (showToolBar)
                toolStrip1.Show();
            else toolStrip1.Hide();
            if (showStatusBar)
                statusStrip1.Show();
            else statusStrip1.Show();

            ToolStripMenuItem_ToolBar.CheckState = CheckState.Checked;
            ToolStripMenuItem_StatusBar.CheckState = CheckState.Checked;
        }

        private void toolStripButton_Instru_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = System.DateTime.Now.ToLongDateString();
            toolStripStatusLabel2.Text = System.DateTime.Now.ToLongTimeString();
        }

        private void ToolStripMenuItem_ToolBar_Click(object sender, EventArgs e)
        {
            if (ToolStripMenuItem_ToolBar.CheckState.Equals(CheckState.Checked))
            {
                ToolStripMenuItem_ToolBar.CheckState = CheckState.Unchecked;
                showToolBar = false;
                toolStrip1.Hide();
            }
            else
            {
                ToolStripMenuItem_ToolBar.CheckState = CheckState.Checked;
                showToolBar = true;
                toolStrip1.Show();
            }
        }

        private void ToolStripMenuItem_StatusBar_Click(object sender, EventArgs e)
        {
            if (ToolStripMenuItem_StatusBar.CheckState.Equals(CheckState.Checked))
            {
                ToolStripMenuItem_StatusBar.CheckState = CheckState.Unchecked;
                showStatusBar = false;
                statusStrip1.Hide();
            }
            else
            {
                ToolStripMenuItem_StatusBar.CheckState = CheckState.Checked;
                showStatusBar = true;
                statusStrip1.Show();
            }
        }
    }
}
