using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WitsTransmission.WitsSend
{
    public partial class TcpClientConfig_Form : Form
    {
        public String m_strIP;
        public String m_strPort;
        
        public String getIP()
        {
            return m_strIP;
        }

        public void setIP(String str)
        {
            m_strIP = str;
        }

        public String getPort()
        {
            return m_strPort;
        }

        public void setPort(String str)
        {
            m_strPort = str;
        }

        public TcpClientConfig_Form()
        {
            InitializeComponent();
        }

        private void TcpClientConfig_Form_Load(object sender, EventArgs e)
        {

        }

        private void tcpClientIP_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //48代表0，57代表9，8代表空格，46代表小数点
            if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 8) && (e.KeyChar != 46))
            {
                e.Handled = true;
            }
        }

        private void tcpClientIP_textBox_Leave(object sender, EventArgs e)
        {
            try
            {
                string[] strSplit = { "." };
                string str = tcpClientIP_textBox.Text;
                string[] strArray = str.Split(strSplit, StringSplitOptions.RemoveEmptyEntries);
                if (strArray.Count() < 4)
                {
                    MessageBox.Show("输入的IP地址非法！");
                    tcpClientIP_textBox.Focus();
                    return;
                }
                foreach (string element in strArray)
                {
                    int nElement = int.Parse(element);
                    if ((nElement < 0) || (nElement > 255))
                    {
                        MessageBox.Show("输入的IP地址非法！");
                        tcpClientIP_textBox.Focus();
                        return;
                    }
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tcpClientPort_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //48代表0，57代表9，8代表空格
            if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 8))
            {
                e.Handled = true;
            }
        }

        private void tcpClientPort_textBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tcpClientPort_textBox.Text))
            {
                MessageBox.Show("未输入端口号！");
                tcpClientPort_textBox.Focus();
            }
        }

        private void ensure_button_Click(object sender, EventArgs e)
        {
            setIP(tcpClientIP_textBox.Text.ToString());
            setPort(tcpClientPort_textBox.Text.ToString());
            this.Close();
        }

        private void cancel_button_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
