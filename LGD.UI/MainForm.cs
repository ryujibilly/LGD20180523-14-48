using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LGD.UI.SystemSettings;

namespace LGD.UI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            //父容器
            flowLayoutPanel_Child.Parent = flowLayoutPanel_Parent;
            //隐藏
            flowLayoutPanel_Child.FlowDirection= FlowDirection.TopDown;
            //初始状态
            button_ResultUpload.Show();
            button_ResultBrowse.Show();
            button_UnitSetting.Hide();
            button_AlarmSetting.Hide();
            button_AcqSetting.Hide();
            button_DBSetting.Hide();
            button_GlasProjectDataManager.Hide();
            button_SelectWITS.Hide();
            button_DBAsyn_Backup.Hide();
            button_GlasProjectManager.Hide();
            button_MonitorSetting.Hide();
            button_RealTimeMonitor_Playback.Hide();
            button_WITSCollectionManager.Hide();
            button_CurWITSConfig.Hide();
            button_WITSTransfer.Hide();
        }


        private void MainForm_Load(object sender, EventArgs e)
        {

        }
        #region 功能模块Panel控件
        /// <summary>
        /// 系统设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSysSetting_Click(object sender, EventArgs e)
        {
            flowLayoutPanel_Parent.Controls.SetChildIndex(flowLayoutPanel_Child,1);
            flowLayoutPanel_Child.Show();
            button_UnitSetting.Show();
            button_AlarmSetting.Show();
            button_AcqSetting.Show();
            //隐藏控件
            button_DBSetting.Hide();
            button_GlasProjectDataManager.Hide();
            button_SelectWITS.Hide();
            button_DBAsyn_Backup.Hide();
            button_GlasProjectManager.Hide();
            button_MonitorSetting.Hide();
            button_RealTimeMonitor_Playback.Hide();
            button_WITSCollectionManager.Hide();
            button_CurWITSConfig.Hide();
            button_WITSTransfer.Hide();
            button_ResultUpload.Hide();
            button_ResultBrowse.Hide();
        }
        /// <summary>
        /// 数据库管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_DBManager_Click(object sender, EventArgs e)
        {
            flowLayoutPanel_Parent.Controls.SetChildIndex(flowLayoutPanel_Child, 2);
            flowLayoutPanel_Child.Show();
            button_DBSetting.Show();
            button_GlasProjectDataManager.Show();
            button_SelectWITS.Show();
            button_DBAsyn_Backup.Show();
            //隐藏控件
            button_UnitSetting.Hide();
            button_AlarmSetting.Hide();
            button_AcqSetting.Hide();
            button_GlasProjectManager.Hide();
            button_MonitorSetting.Hide();
            button_RealTimeMonitor_Playback.Hide();
            button_WITSCollectionManager.Hide();
            button_CurWITSConfig.Hide();
            button_WITSTransfer.Hide();
            button_ResultUpload.Hide();
            button_ResultBrowse.Hide();
        }
        /// <summary>
        /// Glas工程管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void button_ProjectInfoManager_Click(object sender, EventArgs e)
        {
            flowLayoutPanel_Parent.Controls.SetChildIndex(flowLayoutPanel_Child, 3);
            flowLayoutPanel_Child.Show();
            button_GlasProjectManager.Show();
            //隐藏控件
            button_UnitSetting.Hide();
            button_AlarmSetting.Hide();
            button_AcqSetting.Hide();
            button_DBSetting.Hide();
            button_SelectWITS.Hide();
            button_GlasProjectDataManager.Hide();
            button_DBAsyn_Backup.Hide();
            button_MonitorSetting.Hide();
            button_RealTimeMonitor_Playback.Hide();
            button_WITSCollectionManager.Hide();
            button_CurWITSConfig.Hide();
            button_WITSTransfer.Hide();
            button_ResultUpload.Hide();
            button_ResultBrowse.Hide();
        }

        /// <summary>
        /// 数据监视
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_DataMonitor_Click(object sender, EventArgs e)
        {
            flowLayoutPanel_Parent.Controls.SetChildIndex(flowLayoutPanel_Child, 4);
            flowLayoutPanel_Child.Show();
            button_MonitorSetting.Show();
            button_RealTimeMonitor_Playback.Show();

            button_UnitSetting.Hide();
            button_AlarmSetting.Hide();
            button_AcqSetting.Hide();
            button_DBSetting.Hide();
            button_GlasProjectDataManager.Hide();
            button_SelectWITS.Hide();
            button_DBAsyn_Backup.Hide();
            button_GlasProjectManager.Hide();
            button_WITSCollectionManager.Hide();
            button_CurWITSConfig.Hide();
            button_WITSTransfer.Hide();
            button_ResultUpload.Hide();
            button_ResultBrowse.Hide();
        }
        /// <summary>
        /// WITS管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_WITSManager_Click(object sender, EventArgs e)
        {
            flowLayoutPanel_Parent.Controls.SetChildIndex(flowLayoutPanel_Child, 5);
            flowLayoutPanel_Child.Show();
            button_WITSCollectionManager.Show();
            button_CurWITSConfig.Show();
            button_WITSTransfer.Show();

            button_UnitSetting.Hide();
            button_AlarmSetting.Hide();
            button_AcqSetting.Hide();
            button_DBSetting.Hide();
            button_GlasProjectDataManager.Hide();
            button_SelectWITS.Hide();
            button_DBAsyn_Backup.Hide();
            button_GlasProjectManager.Hide();
            button_MonitorSetting.Hide();
            button_RealTimeMonitor_Playback.Hide();
            button_ResultUpload.Hide();
            button_ResultBrowse.Hide();
        }
        /// <summary>
        /// 成果发布
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_ResultRelease_Click(object sender, EventArgs e)
        {
            flowLayoutPanel_Parent.Controls.SetChildIndex(flowLayoutPanel_Child, 6);
            flowLayoutPanel_Child.Show();
            button_ResultUpload.Show();
            button_ResultBrowse.Show();
            button_UnitSetting.Hide();
            button_AlarmSetting.Hide();
            button_AcqSetting.Hide();
            button_DBSetting.Hide();
            button_GlasProjectDataManager.Hide();
            button_SelectWITS.Hide();
            button_DBAsyn_Backup.Hide();
            button_GlasProjectManager.Hide();
            button_MonitorSetting.Hide();
            button_RealTimeMonitor_Playback.Hide();
            button_WITSCollectionManager.Hide();
            button_CurWITSConfig.Hide();
            button_WITSTransfer.Hide();
        }

        private void DockTop(Button b)
        {
            b.Dock = DockStyle.Top;
        }
        private void DockBottom(Button b)
        {
            b.Dock = DockStyle.Bottom;
        }
        private void DockFill(FlowLayoutPanel p)
        {
            p.Show();
            p.Dock = DockStyle.Fill;
        }
        private void PanelHide(FlowLayoutPanel p)
        {
            p.Hide();
        }
        #endregion



        #region 模块子窗口
        private void button_UnitSetting_Click(object sender, EventArgs e)
        {

        }
        private void button_AlarmSetting_Click(object sender, EventArgs e)
        {
            AlarmSetting alarmsetting= new AlarmSetting();
            alarmsetting.Show();
        }

        private void button_AcqSetting_Click(object sender, EventArgs e)
        {
            ACQ_DB_Setting ads = new ACQ_DB_Setting();
            ads.Show();
        }

        private void button_DBSetting_Click(object sender, EventArgs e)
        {
            
        }

        private void button_GlasProjectDataManager_Click(object sender, EventArgs e)
        {

        }

        private void button_SelectWITS_Click(object sender, EventArgs e)
        {

        }

        private void button_GlasProjectManager_Click(object sender, EventArgs e)
        {

        }

        private void button_DBAsyn_Backup_Click(object sender, EventArgs e)
        {

        }

        private void button_MonitorSetting_Click(object sender, EventArgs e)
        {

        }

        private void button_RealTimeMonitor_Playback_Click(object sender, EventArgs e)
        {

        }

        private void button_WITSCollectionManager_Click(object sender, EventArgs e)
        {

        }

        private void button_CurWITSConfig_Click(object sender, EventArgs e)
        {

        }

        private void button_WITSTransfer_Click(object sender, EventArgs e)
        {

        }

        private void button_ResultUpload_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region 工具栏
        private void ToolStripMenuItem_SaveConfig_Click(object sender, EventArgs e)
        {
            FormConfig.SaveConfig();
        }

        private void ToolStripMenuItem_IPAdress_Click(object sender, EventArgs e)
        {
            SystemSettings.IPAddressSetting ipadress = new SystemSettings.IPAddressSetting();
            ipadress.ShowDialog();
        }
        #endregion
    }
}
