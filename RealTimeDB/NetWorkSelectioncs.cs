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
    public partial class NetWorkSelections : Form
    {
        public string serviceURL = "";
        public NetWorkSelections()
        {
            InitializeComponent();
        }

        private void NetWorkSelections_Load(object sender, EventArgs e)
        {

        }
        //内网
        private void radioButton_Intra_CheckedChanged(object sender, EventArgs e)
        {
            this.serviceURL= "http://10.242.0.186/realdb/services/realdbservices";
            textBox_serviceUrl.Enabled = false;
        }

        private void radioButton_Inter_CheckedChanged(object sender, EventArgs e)
        {
            this.serviceURL = "http://113.200.64.43:2036/realdb/services/realdbservices";
            textBox_serviceUrl.Enabled = false;
        }

        private void radioButton_Other_CheckedChanged(object sender, EventArgs e)
        {
            this.textBox_serviceUrl.Enabled=true;
        }

        private void textBox_serviceUrl_TextChanged(object sender, EventArgs e)
        {
            this.serviceURL = "http://" + textBox_serviceUrl.Text.Trim();
        }
        private void button_OK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
