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

namespace RealTimeDB
{
    public partial class RealDBPusher : Form
    {

        private Pusher pusher = new Pusher();
        private DataTable JsonTable = new DataTable();
        private String JsonString = string.Empty;

        //for test
        //WebService1 ws1 = new WebService1();

        //webservice url
        String url = "http://10.242.0.186/realdb/services/realdbservices";
        String user="yuwenmao";
        String password = "123";

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

        public RealDBPusher()
        {
            InitializeComponent();
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
                DataTable dt = pusher.GetAllRegions(out JsonString);
                dataGridView1.DataSource = dt;
                dataGridView1.Refresh();
            }
            catch (System.Exception)
            {
                throw;
            }

        }

        private void RealDBPusher_Load(object sender, EventArgs e)
        {

        }

        private void button_GetAllInstInfo_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = pusher.GetAllInstName(out JsonString);
                dataGridView1.DataSource = dt;
                dataGridView1.Refresh();
            }
            catch (System.Exception)
            {
                throw;
            }

        }

        private void button_ConnectTest_Click(object sender, EventArgs e)
        {
            pusher = new Pusher(textBox_UserName.Text, textBox_PassWord.Text);
            if (pusher.ConnectTest())
                MessageBox.Show("连接成功！");
            else MessageBox.Show("连接异常！");
        }
    }
}
