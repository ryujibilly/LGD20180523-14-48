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
    public partial class RealTimeDBManager : Form
    {
        #region 属性、字段
        private string workplace = "";
        private string staticDB_Path = "";
        private string dbPath_Well = "";
        private string xmlpath = "";

        /// <summary>
        /// XML文件绝对地址
        /// </summary>
        public string Xmlpath
        {
            get { return xmlpath; }
            set { xmlpath = value; }
        }
        /// <summary>
        /// 工区路径
        /// </summary>
        public string Workplace
        {
            get { return workplace; }
            set { workplace = value; }
        }

        /// <summary>
        /// 静态数据库文件路径
        /// </summary>
        public string StaticDB_Path
        {
            get { return staticDB_Path; }
            set { staticDB_Path = value; }
        }

        /// <summary>
        /// 单井数据文件路径
        /// </summary>
        public string DbPath_Well
        {
            get { return dbPath_Well; }
            set { dbPath_Well = value; }
        }
        #endregion

        public RealTimeDBManager()
        {
            InitializeComponent();
        }

        private void RealTimeDBManager_Load(object sender, EventArgs e)
        {
            Tool.Config.GetConfig();
        }

        private void 数据库配置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RealTimeDBLogin rtDBLogin = new RealTimeDBLogin();
            rtDBLogin.MdiParent = this;
            rtDBLogin.Show();
        }

        private void 数据采集ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RealDB_DAQ rtdaq = new RealDB_DAQ();
            rtdaq.MdiParent = this;
            rtdaq.Show();
        }
    }
}
