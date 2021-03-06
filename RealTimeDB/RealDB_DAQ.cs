﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text.RegularExpressions;
using System.IO;
using Tool.TCP;
using System.Diagnostics;

namespace RealTimeDB
{
    public partial class RealDB_DAQ : Form
    {
        private string hostIp = "0.0.0.0";
        private List<string> _iplist=new List<string>();
        private int _port = 9999;
        private int maxClient = 5;
        private AsyncSocketTCPServer _tcpserver;
        /// <summary>
        /// 本地IP地址 列表
        /// </summary>
        public List<string> Iplist
        {
            get { return _iplist; }
            set { _iplist = value; }
        }
        /// <summary>
        /// 作为TCP server的主机IP
        /// </summary>
        public string HostIp
        {
            get { return hostIp; }
            set { hostIp = value; }
        }
        /// <summary>
        /// 本地端口
        /// </summary>
        public int Port
        {
            get { return _port; }
            set { _port = value; }
        }
        /// <summary>
        /// 最大客户端连接数
        /// </summary>
        public int MaxClient
        {
            get
            {
                return maxClient;
            }

            set
            {
                maxClient = value;
            }
        }
        /// <summary>
        /// 异步tcp服务端
        /// </summary>
        public AsyncSocketTCPServer Tcpserver
        {
            get
            {
                return _tcpserver;
            }

            set
            {
                _tcpserver = value;
            }
        }

        public RealDB_DAQ()
        {
            InitializeComponent();
        }

        private void RealDB_DAQ_Load(object sender, EventArgs e)
        {
            Iplist.AddRange(GetLocalAddresses());
            comboBox_HostIP.Items.AddRange(Iplist.ToArray());
            comboBox_HostIP.Text = Iplist[0].ToString();
        }

        /// <summary>
        /// 获取本机地址列表
        /// </summary>
        public List<string> GetLocalAddresses()
        {
            // 获取主机名
            string strHostName = Dns.GetHostName();
            // 根据主机名进行查找
            IPHostEntry iphostentry = Dns.GetHostEntry(strHostName);
            List<string> retval = new List<string>();
            foreach (IPAddress ipaddress in iphostentry.AddressList)
                retval.Add(ipaddress.ToString());
            return retval;
        }

        private void comboBox_HostIP_SelectedIndexChanged(object sender, EventArgs e)
        {
            HostIp = comboBox_HostIP.SelectedItem.ToString();
        }
        private void textBox_HostPort_TextChanged(object sender, EventArgs e)
        {
            Port = int.Parse(textBox_HostPort.Text.Trim());
        }
        private void textBox_HostPort_Leave(object sender, EventArgs e)
        {
            try
            {
                if(IsInteger(textBox_HostPort.Text.Trim()))
                    Port = int.Parse(textBox_HostPort.Text.Trim());
                else MessageBox.Show("端口必须为正整数！");
            }
            catch (Exception ex)
            {
                MessageBox.Show("端口必须为正整数！"+ex.Message);
            }
        }

        protected bool IsInteger(string value)
        {
            string pattern = @"^[0-9]*[1-9][0-9]*$";
            return Regex.IsMatch(value, pattern);
        }

        private void button_Listening_Click(object sender, EventArgs e)
        {
            try
            {
                Tcpserver= new AsyncSocketTCPServer(IPAddress.Parse(HostIp), Port, MaxClient);
                groupBox1.Enabled = false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                groupBox1.Enabled = true;
            }

        }

        private void numericUpDown_MaxClient_ValueChanged(object sender, EventArgs e)
        {
            MaxClient = int.Parse(numericUpDown_MaxClient.Value.ToString());
        }

        private void button_Close_Click(object sender, EventArgs e)
        {
            if (Tcpserver.IsRunning)
            {
                Tcpserver.CloseAllClient();
                groupBox1.Enabled = true;
            }
            //foreach (AsyncSocketState s in Tcpserver.Clients)
            //    Tcpserver.Close(new AsyncSocketState(Tcpserver.Clients[0].ClientSocket));
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
