using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LGD.UI.SystemSettings
{
    public partial class ACQ_DB_Setting : Form
    {
        public ACQ_DB_Setting()
        {
            InitializeComponent();
        }

        private void ToolStripMenuItem_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ToolStripMenuItem_DBSetting_Click(object sender, EventArgs e)
        {
            DBSetting dbs = new DBSetting();
            dbs.ShowDialog();
        }
    }
}
