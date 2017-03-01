namespace LGD.UI.SystemSettings
{
    partial class ACQ_DB_Setting
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ACQ_DB_Setting));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_DBSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_AcqSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_ACQInstru = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_ACQChannel = new System.Windows.Forms.ToolStripMenuItem();
            this.采集ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_ACQ_OnOff = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_InstruTest = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Options = new System.Windows.Forms.ToolStripMenuItem();
            this.显示ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_ToolBar = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_StatusBar = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Help = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_About = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_HelpTopics = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.dataGridView_ACQ = new System.Windows.Forms.DataGridView();
            this.Column_ACQ_Para = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_ACQ_Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Para_Unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Calib_Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Value_Unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.dataSet1 = new System.Data.DataSet();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ACQ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.设置ToolStripMenuItem,
            this.采集ToolStripMenuItem,
            this.显示ToolStripMenuItem,
            this.ToolStripMenuItem_Help});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(695, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_Exit});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // ToolStripMenuItem_Exit
            // 
            this.ToolStripMenuItem_Exit.Name = "ToolStripMenuItem_Exit";
            this.ToolStripMenuItem_Exit.Size = new System.Drawing.Size(152, 22);
            this.ToolStripMenuItem_Exit.Text = "退出";
            this.ToolStripMenuItem_Exit.Click += new System.EventHandler(this.ToolStripMenuItem_Exit_Click);
            // 
            // 设置ToolStripMenuItem
            // 
            this.设置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_DBSetting,
            this.ToolStripMenuItem_AcqSetting});
            this.设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
            this.设置ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.设置ToolStripMenuItem.Text = "设置";
            // 
            // ToolStripMenuItem_DBSetting
            // 
            this.ToolStripMenuItem_DBSetting.Name = "ToolStripMenuItem_DBSetting";
            this.ToolStripMenuItem_DBSetting.Size = new System.Drawing.Size(152, 22);
            this.ToolStripMenuItem_DBSetting.Text = "数据库设置";
            this.ToolStripMenuItem_DBSetting.Click += new System.EventHandler(this.ToolStripMenuItem_DBSetting_Click);
            // 
            // ToolStripMenuItem_AcqSetting
            // 
            this.ToolStripMenuItem_AcqSetting.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_ACQInstru,
            this.ToolStripMenuItem_ACQChannel});
            this.ToolStripMenuItem_AcqSetting.Name = "ToolStripMenuItem_AcqSetting";
            this.ToolStripMenuItem_AcqSetting.Size = new System.Drawing.Size(152, 22);
            this.ToolStripMenuItem_AcqSetting.Text = "采集机设置";
            // 
            // ToolStripMenuItem_ACQInstru
            // 
            this.ToolStripMenuItem_ACQInstru.Name = "ToolStripMenuItem_ACQInstru";
            this.ToolStripMenuItem_ACQInstru.Size = new System.Drawing.Size(152, 22);
            this.ToolStripMenuItem_ACQInstru.Text = "设备";
            // 
            // ToolStripMenuItem_ACQChannel
            // 
            this.ToolStripMenuItem_ACQChannel.Name = "ToolStripMenuItem_ACQChannel";
            this.ToolStripMenuItem_ACQChannel.Size = new System.Drawing.Size(152, 22);
            this.ToolStripMenuItem_ACQChannel.Text = "通道";
            // 
            // 采集ToolStripMenuItem
            // 
            this.采集ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_ACQ_OnOff,
            this.ToolStripMenuItem_InstruTest,
            this.ToolStripMenuItem_Options});
            this.采集ToolStripMenuItem.Name = "采集ToolStripMenuItem";
            this.采集ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.采集ToolStripMenuItem.Text = "采集";
            // 
            // ToolStripMenuItem_ACQ_OnOff
            // 
            this.ToolStripMenuItem_ACQ_OnOff.Name = "ToolStripMenuItem_ACQ_OnOff";
            this.ToolStripMenuItem_ACQ_OnOff.Size = new System.Drawing.Size(153, 22);
            this.ToolStripMenuItem_ACQ_OnOff.Text = "开始/停止采集";
            // 
            // ToolStripMenuItem_InstruTest
            // 
            this.ToolStripMenuItem_InstruTest.Name = "ToolStripMenuItem_InstruTest";
            this.ToolStripMenuItem_InstruTest.Size = new System.Drawing.Size(153, 22);
            this.ToolStripMenuItem_InstruTest.Text = "设备测试";
            // 
            // ToolStripMenuItem_Options
            // 
            this.ToolStripMenuItem_Options.Name = "ToolStripMenuItem_Options";
            this.ToolStripMenuItem_Options.Size = new System.Drawing.Size(153, 22);
            this.ToolStripMenuItem_Options.Text = "选项";
            // 
            // 显示ToolStripMenuItem
            // 
            this.显示ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_ToolBar,
            this.ToolStripMenuItem_StatusBar});
            this.显示ToolStripMenuItem.Name = "显示ToolStripMenuItem";
            this.显示ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.显示ToolStripMenuItem.Text = "显示";
            // 
            // ToolStripMenuItem_ToolBar
            // 
            this.ToolStripMenuItem_ToolBar.Name = "ToolStripMenuItem_ToolBar";
            this.ToolStripMenuItem_ToolBar.Size = new System.Drawing.Size(152, 22);
            this.ToolStripMenuItem_ToolBar.Text = "工具栏";
            // 
            // ToolStripMenuItem_StatusBar
            // 
            this.ToolStripMenuItem_StatusBar.Name = "ToolStripMenuItem_StatusBar";
            this.ToolStripMenuItem_StatusBar.Size = new System.Drawing.Size(152, 22);
            this.ToolStripMenuItem_StatusBar.Text = "状态条";
            // 
            // ToolStripMenuItem_Help
            // 
            this.ToolStripMenuItem_Help.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_About,
            this.ToolStripMenuItem_HelpTopics});
            this.ToolStripMenuItem_Help.Name = "ToolStripMenuItem_Help";
            this.ToolStripMenuItem_Help.Size = new System.Drawing.Size(44, 21);
            this.ToolStripMenuItem_Help.Text = "帮助";
            // 
            // ToolStripMenuItem_About
            // 
            this.ToolStripMenuItem_About.Name = "ToolStripMenuItem_About";
            this.ToolStripMenuItem_About.Size = new System.Drawing.Size(152, 22);
            this.ToolStripMenuItem_About.Text = "关于";
            // 
            // ToolStripMenuItem_HelpTopics
            // 
            this.ToolStripMenuItem_HelpTopics.Name = "ToolStripMenuItem_HelpTopics";
            this.ToolStripMenuItem_HelpTopics.Size = new System.Drawing.Size(152, 22);
            this.ToolStripMenuItem_HelpTopics.Text = "帮助主体";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 25);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(695, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.ToolTipText = "设备";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = global::LGD.UI.Properties.Resources._32_266;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "toolStripButton2";
            // 
            // dataGridView_ACQ
            // 
            this.dataGridView_ACQ.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_ACQ.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_ACQ_Para,
            this.Column_ACQ_Value,
            this.Column_Para_Unit,
            this.Column_Calib_Value,
            this.Column_Value_Unit});
            this.dataGridView_ACQ.Location = new System.Drawing.Point(3, 3);
            this.dataGridView_ACQ.Name = "dataGridView_ACQ";
            this.dataGridView_ACQ.RowTemplate.Height = 23;
            this.dataGridView_ACQ.Size = new System.Drawing.Size(661, 429);
            this.dataGridView_ACQ.TabIndex = 2;
            // 
            // Column_ACQ_Para
            // 
            this.Column_ACQ_Para.Frozen = true;
            this.Column_ACQ_Para.HeaderText = "采集参数";
            this.Column_ACQ_Para.Name = "Column_ACQ_Para";
            this.Column_ACQ_Para.ReadOnly = true;
            this.Column_ACQ_Para.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Column_ACQ_Value
            // 
            this.Column_ACQ_Value.Frozen = true;
            this.Column_ACQ_Value.HeaderText = "采集值";
            this.Column_ACQ_Value.Name = "Column_ACQ_Value";
            this.Column_ACQ_Value.ReadOnly = true;
            // 
            // Column_Para_Unit
            // 
            this.Column_Para_Unit.Frozen = true;
            this.Column_Para_Unit.HeaderText = "单位";
            this.Column_Para_Unit.Name = "Column_Para_Unit";
            this.Column_Para_Unit.ReadOnly = true;
            // 
            // Column_Calib_Value
            // 
            this.Column_Calib_Value.Frozen = true;
            this.Column_Calib_Value.HeaderText = "标定值";
            this.Column_Calib_Value.Name = "Column_Calib_Value";
            this.Column_Calib_Value.ReadOnly = true;
            // 
            // Column_Value_Unit
            // 
            this.Column_Value_Unit.Frozen = true;
            this.Column_Value_Unit.HeaderText = "单位";
            this.Column_Value_Unit.Name = "Column_Value_Unit";
            this.Column_Value_Unit.ReadOnly = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(12, 53);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.textBox2);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.textBox1);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.comboBox1);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView_ACQ);
            this.splitContainer1.Size = new System.Drawing.Size(667, 479);
            this.splitContainer1.SplitterDistance = 40;
            this.splitContainer1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "设备:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(55, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(140, 20);
            this.comboBox1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(201, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "计算程序IP:";
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(278, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(138, 21);
            this.textBox1.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(443, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "发送计数:";
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(508, 12);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(84, 21);
            this.textBox2.TabIndex = 5;
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "NewDataSet";
            // 
            // ACQ_DB_Setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 544);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ACQ_DB_Setting";
            this.Text = "采集机和数据库设置";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ACQ)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Exit;
        private System.Windows.Forms.ToolStripMenuItem 设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_DBSetting;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_AcqSetting;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_ACQInstru;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_ACQChannel;
        private System.Windows.Forms.ToolStripMenuItem 采集ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_ACQ_OnOff;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_InstruTest;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Options;
        private System.Windows.Forms.ToolStripMenuItem 显示ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_ToolBar;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_StatusBar;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Help;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_About;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_HelpTopics;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.DataGridView dataGridView_ACQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_ACQ_Para;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_ACQ_Value;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Para_Unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Calib_Value;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Value_Unit;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Data.DataSet dataSet1;
    }
}