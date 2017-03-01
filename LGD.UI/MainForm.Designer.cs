namespace LGD.UI
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_SaveConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_IPAdress = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.实时控制ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.视图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.工具条ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.状态栏ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.内容ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button_DBManager = new System.Windows.Forms.Button();
            this.button_UnitSetting = new System.Windows.Forms.Button();
            this.button_SystemSeting = new System.Windows.Forms.Button();
            this.flowLayoutPanel_Parent = new System.Windows.Forms.FlowLayoutPanel();
            this.button_ProjectInfoManager = new System.Windows.Forms.Button();
            this.button_DataMonitor = new System.Windows.Forms.Button();
            this.button_WITSManager = new System.Windows.Forms.Button();
            this.button_ResultRelease = new System.Windows.Forms.Button();
            this.flowLayoutPanel_Child = new System.Windows.Forms.FlowLayoutPanel();
            this.button_AlarmSetting = new System.Windows.Forms.Button();
            this.button_AcqSetting = new System.Windows.Forms.Button();
            this.button_DBSetting = new System.Windows.Forms.Button();
            this.button_GlasProjectDataManager = new System.Windows.Forms.Button();
            this.button_SelectWITS = new System.Windows.Forms.Button();
            this.button_GlasProjectManager = new System.Windows.Forms.Button();
            this.button_DBAsyn_Backup = new System.Windows.Forms.Button();
            this.button_MonitorSetting = new System.Windows.Forms.Button();
            this.button_RealTimeMonitor_Playback = new System.Windows.Forms.Button();
            this.button_WITSCollectionManager = new System.Windows.Forms.Button();
            this.button_CurWITSConfig = new System.Windows.Forms.Button();
            this.button_WITSTransfer = new System.Windows.Forms.Button();
            this.button_ResultUpload = new System.Windows.Forms.Button();
            this.button_ResultBrowse = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.menuStrip1.SuspendLayout();
            this.flowLayoutPanel_Parent.SuspendLayout();
            this.flowLayoutPanel_Child.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.实时控制ToolStripMenuItem,
            this.视图ToolStripMenuItem,
            this.帮助ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1204, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_SaveConfig,
            this.ToolStripMenuItem_IPAdress,
            this.退出ToolStripMenuItem});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // ToolStripMenuItem_SaveConfig
            // 
            this.ToolStripMenuItem_SaveConfig.Name = "ToolStripMenuItem_SaveConfig";
            this.ToolStripMenuItem_SaveConfig.Size = new System.Drawing.Size(152, 22);
            this.ToolStripMenuItem_SaveConfig.Text = "保存";
            this.ToolStripMenuItem_SaveConfig.Click += new System.EventHandler(this.ToolStripMenuItem_SaveConfig_Click);
            // 
            // ToolStripMenuItem_IPAdress
            // 
            this.ToolStripMenuItem_IPAdress.Name = "ToolStripMenuItem_IPAdress";
            this.ToolStripMenuItem_IPAdress.Size = new System.Drawing.Size(152, 22);
            this.ToolStripMenuItem_IPAdress.Text = "IP地址设置";
            this.ToolStripMenuItem_IPAdress.Click += new System.EventHandler(this.ToolStripMenuItem_IPAdress_Click);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.退出ToolStripMenuItem.Text = "退出";
            // 
            // 实时控制ToolStripMenuItem
            // 
            this.实时控制ToolStripMenuItem.Name = "实时控制ToolStripMenuItem";
            this.实时控制ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.实时控制ToolStripMenuItem.Text = "实时控制";
            // 
            // 视图ToolStripMenuItem
            // 
            this.视图ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.工具条ToolStripMenuItem,
            this.状态栏ToolStripMenuItem});
            this.视图ToolStripMenuItem.Name = "视图ToolStripMenuItem";
            this.视图ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.视图ToolStripMenuItem.Text = "视图";
            // 
            // 工具条ToolStripMenuItem
            // 
            this.工具条ToolStripMenuItem.Name = "工具条ToolStripMenuItem";
            this.工具条ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.工具条ToolStripMenuItem.Text = "工具条";
            // 
            // 状态栏ToolStripMenuItem
            // 
            this.状态栏ToolStripMenuItem.Name = "状态栏ToolStripMenuItem";
            this.状态栏ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.状态栏ToolStripMenuItem.Text = "状态栏";
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.关于ToolStripMenuItem,
            this.内容ToolStripMenuItem});
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.帮助ToolStripMenuItem.Text = "帮助";
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.关于ToolStripMenuItem.Text = "关于";
            // 
            // 内容ToolStripMenuItem
            // 
            this.内容ToolStripMenuItem.Name = "内容ToolStripMenuItem";
            this.内容ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.内容ToolStripMenuItem.Text = "内容";
            // 
            // button_DBManager
            // 
            this.button_DBManager.Location = new System.Drawing.Point(124, 3);
            this.button_DBManager.Name = "button_DBManager";
            this.button_DBManager.Size = new System.Drawing.Size(115, 23);
            this.button_DBManager.TabIndex = 1;
            this.button_DBManager.Text = "数据库管理";
            this.button_DBManager.UseVisualStyleBackColor = true;
            this.button_DBManager.Click += new System.EventHandler(this.button_DBManager_Click);
            // 
            // button_UnitSetting
            // 
            this.button_UnitSetting.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button_UnitSetting.Location = new System.Drawing.Point(3, 3);
            this.button_UnitSetting.Name = "button_UnitSetting";
            this.button_UnitSetting.Size = new System.Drawing.Size(101, 56);
            this.button_UnitSetting.TabIndex = 0;
            this.button_UnitSetting.Text = "单位设置";
            this.button_UnitSetting.UseVisualStyleBackColor = true;
            this.button_UnitSetting.Click += new System.EventHandler(this.button_UnitSetting_Click);
            // 
            // button_SystemSeting
            // 
            this.button_SystemSeting.Location = new System.Drawing.Point(3, 3);
            this.button_SystemSeting.Name = "button_SystemSeting";
            this.button_SystemSeting.Size = new System.Drawing.Size(115, 23);
            this.button_SystemSeting.TabIndex = 0;
            this.button_SystemSeting.Text = "系统设置";
            this.button_SystemSeting.UseVisualStyleBackColor = true;
            this.button_SystemSeting.Click += new System.EventHandler(this.buttonSysSetting_Click);
            // 
            // flowLayoutPanel_Parent
            // 
            this.flowLayoutPanel_Parent.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.flowLayoutPanel_Parent.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flowLayoutPanel_Parent.Controls.Add(this.button_SystemSeting);
            this.flowLayoutPanel_Parent.Controls.Add(this.button_DBManager);
            this.flowLayoutPanel_Parent.Controls.Add(this.button_ProjectInfoManager);
            this.flowLayoutPanel_Parent.Controls.Add(this.button_DataMonitor);
            this.flowLayoutPanel_Parent.Controls.Add(this.button_WITSManager);
            this.flowLayoutPanel_Parent.Controls.Add(this.button_ResultRelease);
            this.flowLayoutPanel_Parent.Controls.Add(this.flowLayoutPanel_Child);
            this.flowLayoutPanel_Parent.Location = new System.Drawing.Point(12, 28);
            this.flowLayoutPanel_Parent.Name = "flowLayoutPanel_Parent";
            this.flowLayoutPanel_Parent.Size = new System.Drawing.Size(251, 618);
            this.flowLayoutPanel_Parent.TabIndex = 3;
            // 
            // button_ProjectInfoManager
            // 
            this.button_ProjectInfoManager.Location = new System.Drawing.Point(3, 32);
            this.button_ProjectInfoManager.Name = "button_ProjectInfoManager";
            this.button_ProjectInfoManager.Size = new System.Drawing.Size(115, 23);
            this.button_ProjectInfoManager.TabIndex = 4;
            this.button_ProjectInfoManager.Text = "GLAS工程管理";
            this.button_ProjectInfoManager.UseVisualStyleBackColor = true;
            this.button_ProjectInfoManager.Click += new System.EventHandler(this.button_ProjectInfoManager_Click);
            // 
            // button_DataMonitor
            // 
            this.button_DataMonitor.Location = new System.Drawing.Point(124, 32);
            this.button_DataMonitor.Name = "button_DataMonitor";
            this.button_DataMonitor.Size = new System.Drawing.Size(115, 23);
            this.button_DataMonitor.TabIndex = 6;
            this.button_DataMonitor.Text = "数据监视";
            this.button_DataMonitor.UseVisualStyleBackColor = true;
            this.button_DataMonitor.Click += new System.EventHandler(this.button_DataMonitor_Click);
            // 
            // button_WITSManager
            // 
            this.button_WITSManager.Location = new System.Drawing.Point(3, 61);
            this.button_WITSManager.Name = "button_WITSManager";
            this.button_WITSManager.Size = new System.Drawing.Size(115, 23);
            this.button_WITSManager.TabIndex = 7;
            this.button_WITSManager.Text = "WITS管理和传输";
            this.button_WITSManager.UseVisualStyleBackColor = true;
            this.button_WITSManager.Click += new System.EventHandler(this.button_WITSManager_Click);
            // 
            // button_ResultRelease
            // 
            this.button_ResultRelease.Location = new System.Drawing.Point(124, 61);
            this.button_ResultRelease.Name = "button_ResultRelease";
            this.button_ResultRelease.Size = new System.Drawing.Size(115, 23);
            this.button_ResultRelease.TabIndex = 7;
            this.button_ResultRelease.Text = "成果发布";
            this.button_ResultRelease.UseVisualStyleBackColor = true;
            this.button_ResultRelease.Click += new System.EventHandler(this.button_ResultRelease_Click);
            // 
            // flowLayoutPanel_Child
            // 
            this.flowLayoutPanel_Child.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.flowLayoutPanel_Child.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flowLayoutPanel_Child.Controls.Add(this.button_UnitSetting);
            this.flowLayoutPanel_Child.Controls.Add(this.button_AlarmSetting);
            this.flowLayoutPanel_Child.Controls.Add(this.button_AcqSetting);
            this.flowLayoutPanel_Child.Controls.Add(this.button_DBSetting);
            this.flowLayoutPanel_Child.Controls.Add(this.button_GlasProjectDataManager);
            this.flowLayoutPanel_Child.Controls.Add(this.button_SelectWITS);
            this.flowLayoutPanel_Child.Controls.Add(this.button_GlasProjectManager);
            this.flowLayoutPanel_Child.Controls.Add(this.button_DBAsyn_Backup);
            this.flowLayoutPanel_Child.Controls.Add(this.button_MonitorSetting);
            this.flowLayoutPanel_Child.Controls.Add(this.button_RealTimeMonitor_Playback);
            this.flowLayoutPanel_Child.Controls.Add(this.button_WITSCollectionManager);
            this.flowLayoutPanel_Child.Controls.Add(this.button_CurWITSConfig);
            this.flowLayoutPanel_Child.Controls.Add(this.button_WITSTransfer);
            this.flowLayoutPanel_Child.Controls.Add(this.button_ResultUpload);
            this.flowLayoutPanel_Child.Controls.Add(this.button_ResultBrowse);
            this.flowLayoutPanel_Child.Location = new System.Drawing.Point(3, 90);
            this.flowLayoutPanel_Child.Name = "flowLayoutPanel_Child";
            this.flowLayoutPanel_Child.Size = new System.Drawing.Size(221, 436);
            this.flowLayoutPanel_Child.TabIndex = 8;
            // 
            // button_AlarmSetting
            // 
            this.button_AlarmSetting.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button_AlarmSetting.Location = new System.Drawing.Point(110, 3);
            this.button_AlarmSetting.Name = "button_AlarmSetting";
            this.button_AlarmSetting.Size = new System.Drawing.Size(101, 56);
            this.button_AlarmSetting.TabIndex = 1;
            this.button_AlarmSetting.Text = "报警设置";
            this.button_AlarmSetting.UseVisualStyleBackColor = true;
            this.button_AlarmSetting.Click += new System.EventHandler(this.button_AlarmSetting_Click);
            // 
            // button_AcqSetting
            // 
            this.button_AcqSetting.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button_AcqSetting.Location = new System.Drawing.Point(3, 65);
            this.button_AcqSetting.Name = "button_AcqSetting";
            this.button_AcqSetting.Size = new System.Drawing.Size(101, 56);
            this.button_AcqSetting.TabIndex = 7;
            this.button_AcqSetting.Text = "采集机和数据库设置";
            this.button_AcqSetting.UseVisualStyleBackColor = true;
            this.button_AcqSetting.Click += new System.EventHandler(this.button_AcqSetting_Click);
            // 
            // button_DBSetting
            // 
            this.button_DBSetting.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button_DBSetting.Location = new System.Drawing.Point(110, 65);
            this.button_DBSetting.Name = "button_DBSetting";
            this.button_DBSetting.Size = new System.Drawing.Size(101, 56);
            this.button_DBSetting.TabIndex = 8;
            this.button_DBSetting.Text = "数据库配置及登录";
            this.button_DBSetting.UseVisualStyleBackColor = true;
            this.button_DBSetting.Click += new System.EventHandler(this.button_DBSetting_Click);
            // 
            // button_GlasProjectDataManager
            // 
            this.button_GlasProjectDataManager.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button_GlasProjectDataManager.Location = new System.Drawing.Point(3, 127);
            this.button_GlasProjectDataManager.Name = "button_GlasProjectDataManager";
            this.button_GlasProjectDataManager.Size = new System.Drawing.Size(101, 56);
            this.button_GlasProjectDataManager.TabIndex = 9;
            this.button_GlasProjectDataManager.Text = "管理GLAS工程数据";
            this.button_GlasProjectDataManager.UseVisualStyleBackColor = true;
            this.button_GlasProjectDataManager.Click += new System.EventHandler(this.button_GlasProjectDataManager_Click);
            // 
            // button_SelectWITS
            // 
            this.button_SelectWITS.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button_SelectWITS.Location = new System.Drawing.Point(110, 127);
            this.button_SelectWITS.Name = "button_SelectWITS";
            this.button_SelectWITS.Size = new System.Drawing.Size(101, 56);
            this.button_SelectWITS.TabIndex = 10;
            this.button_SelectWITS.Text = "查询WITS记录";
            this.button_SelectWITS.UseVisualStyleBackColor = true;
            this.button_SelectWITS.Click += new System.EventHandler(this.button_SelectWITS_Click);
            // 
            // button_GlasProjectManager
            // 
            this.button_GlasProjectManager.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button_GlasProjectManager.Location = new System.Drawing.Point(3, 189);
            this.button_GlasProjectManager.Name = "button_GlasProjectManager";
            this.button_GlasProjectManager.Size = new System.Drawing.Size(101, 56);
            this.button_GlasProjectManager.TabIndex = 10;
            this.button_GlasProjectManager.Text = "GLAS工程管理";
            this.button_GlasProjectManager.UseVisualStyleBackColor = true;
            this.button_GlasProjectManager.Click += new System.EventHandler(this.button_GlasProjectManager_Click);
            // 
            // button_DBAsyn_Backup
            // 
            this.button_DBAsyn_Backup.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button_DBAsyn_Backup.Location = new System.Drawing.Point(110, 189);
            this.button_DBAsyn_Backup.Name = "button_DBAsyn_Backup";
            this.button_DBAsyn_Backup.Size = new System.Drawing.Size(101, 56);
            this.button_DBAsyn_Backup.TabIndex = 11;
            this.button_DBAsyn_Backup.Text = "数据库同步和备份";
            this.button_DBAsyn_Backup.UseVisualStyleBackColor = true;
            this.button_DBAsyn_Backup.Click += new System.EventHandler(this.button_DBAsyn_Backup_Click);
            // 
            // button_MonitorSetting
            // 
            this.button_MonitorSetting.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button_MonitorSetting.Location = new System.Drawing.Point(3, 251);
            this.button_MonitorSetting.Name = "button_MonitorSetting";
            this.button_MonitorSetting.Size = new System.Drawing.Size(101, 56);
            this.button_MonitorSetting.TabIndex = 12;
            this.button_MonitorSetting.Text = "监视设置";
            this.button_MonitorSetting.UseVisualStyleBackColor = true;
            this.button_MonitorSetting.Click += new System.EventHandler(this.button_MonitorSetting_Click);
            // 
            // button_RealTimeMonitor_Playback
            // 
            this.button_RealTimeMonitor_Playback.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button_RealTimeMonitor_Playback.Location = new System.Drawing.Point(110, 251);
            this.button_RealTimeMonitor_Playback.Name = "button_RealTimeMonitor_Playback";
            this.button_RealTimeMonitor_Playback.Size = new System.Drawing.Size(101, 56);
            this.button_RealTimeMonitor_Playback.TabIndex = 13;
            this.button_RealTimeMonitor_Playback.Text = "实时监视和数据回放";
            this.button_RealTimeMonitor_Playback.UseVisualStyleBackColor = true;
            this.button_RealTimeMonitor_Playback.Click += new System.EventHandler(this.button_RealTimeMonitor_Playback_Click);
            // 
            // button_WITSCollectionManager
            // 
            this.button_WITSCollectionManager.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button_WITSCollectionManager.Location = new System.Drawing.Point(3, 313);
            this.button_WITSCollectionManager.Name = "button_WITSCollectionManager";
            this.button_WITSCollectionManager.Size = new System.Drawing.Size(101, 56);
            this.button_WITSCollectionManager.TabIndex = 14;
            this.button_WITSCollectionManager.Text = "管理WITS集";
            this.button_WITSCollectionManager.UseVisualStyleBackColor = true;
            this.button_WITSCollectionManager.Click += new System.EventHandler(this.button_WITSCollectionManager_Click);
            // 
            // button_CurWITSConfig
            // 
            this.button_CurWITSConfig.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button_CurWITSConfig.Location = new System.Drawing.Point(110, 313);
            this.button_CurWITSConfig.Name = "button_CurWITSConfig";
            this.button_CurWITSConfig.Size = new System.Drawing.Size(101, 56);
            this.button_CurWITSConfig.TabIndex = 14;
            this.button_CurWITSConfig.Text = "配置当前WITS集";
            this.button_CurWITSConfig.UseVisualStyleBackColor = true;
            this.button_CurWITSConfig.Click += new System.EventHandler(this.button_CurWITSConfig_Click);
            // 
            // button_WITSTransfer
            // 
            this.button_WITSTransfer.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button_WITSTransfer.Location = new System.Drawing.Point(3, 375);
            this.button_WITSTransfer.Name = "button_WITSTransfer";
            this.button_WITSTransfer.Size = new System.Drawing.Size(101, 56);
            this.button_WITSTransfer.TabIndex = 15;
            this.button_WITSTransfer.Text = "WITS传输";
            this.button_WITSTransfer.UseVisualStyleBackColor = true;
            this.button_WITSTransfer.Click += new System.EventHandler(this.button_WITSTransfer_Click);
            // 
            // button_ResultUpload
            // 
            this.button_ResultUpload.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button_ResultUpload.Location = new System.Drawing.Point(110, 375);
            this.button_ResultUpload.Name = "button_ResultUpload";
            this.button_ResultUpload.Size = new System.Drawing.Size(101, 56);
            this.button_ResultUpload.TabIndex = 16;
            this.button_ResultUpload.Text = "上传成果";
            this.button_ResultUpload.UseVisualStyleBackColor = true;
            this.button_ResultUpload.Click += new System.EventHandler(this.button_ResultUpload_Click);
            // 
            // button_ResultBrowse
            // 
            this.button_ResultBrowse.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button_ResultBrowse.Location = new System.Drawing.Point(3, 437);
            this.button_ResultBrowse.Name = "button_ResultBrowse";
            this.button_ResultBrowse.Size = new System.Drawing.Size(101, 56);
            this.button_ResultBrowse.TabIndex = 17;
            this.button_ResultBrowse.Text = "浏览成果";
            this.button_ResultBrowse.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 654);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1204, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1204, 676);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.flowLayoutPanel_Parent);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "LGD测井地质工程测控软件";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.flowLayoutPanel_Parent.ResumeLayout(false);
            this.flowLayoutPanel_Child.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_SaveConfig;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_IPAdress;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 实时控制ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 视图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 工具条ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 状态栏ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 内容ToolStripMenuItem;
        private System.Windows.Forms.Button button_DBManager;
        private System.Windows.Forms.Button button_UnitSetting;
        private System.Windows.Forms.Button button_SystemSeting;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel_Parent;
        private System.Windows.Forms.Button button_ProjectInfoManager;
        private System.Windows.Forms.Button button_DataMonitor;
        private System.Windows.Forms.Button button_WITSManager;
        private System.Windows.Forms.Button button_ResultRelease;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel_Child;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Button button_AlarmSetting;
        private System.Windows.Forms.Button button_AcqSetting;
        private System.Windows.Forms.Button button_DBSetting;
        private System.Windows.Forms.Button button_GlasProjectDataManager;
        private System.Windows.Forms.Button button_SelectWITS;
        private System.Windows.Forms.Button button_DBAsyn_Backup;
        private System.Windows.Forms.Button button_MonitorSetting;
        private System.Windows.Forms.Button button_RealTimeMonitor_Playback;
        private System.Windows.Forms.Button button_WITSCollectionManager;
        private System.Windows.Forms.Button button_CurWITSConfig;
        private System.Windows.Forms.Button button_WITSTransfer;
        private System.Windows.Forms.Button button_ResultUpload;
        private System.Windows.Forms.Button button_ResultBrowse;
        private System.Windows.Forms.Button button_GlasProjectManager;
    }
}

