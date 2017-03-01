using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
namespace LGD.UI.SystemSettings
{
    public partial class IPAddressSetting : Form
    {
        public String IPString { get; set; }
        public Boolean IsHost { get; set; }
        public IPAddressSetting()
        {
            InitializeComponent();
        }

        private void checkBox_IsHost_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_IsHost.CheckState.Equals(CheckState.Checked))
            {
                IPHostEntry host;
                string localIP = "";
                host = Dns.GetHostEntry(Dns.GetHostName());
                foreach (IPAddress ip in host.AddressList)
                {
                    if (ip.AddressFamily.ToString() == "InterNetwork")
                    {
                        localIP = ip.ToString();
                        break;
                    }
                }
                IPString = localIP;
            }
            else if (checkBox_IsHost.CheckState.Equals(CheckState.Unchecked))
            {
                if (isIPAdress(IPString))
                    FormConfig.fc.HostIP = IPString;
            }
        }
        private Boolean isIPAdress(String ipstring)
        {
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormConfig.SaveConfig();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
