namespace WitsTransmission.WitsReceive
{
    partial class RecConfig_Form
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
            this.netWorkSetting_groupBox = new System.Windows.Forms.GroupBox();
            this.tcpServer_groupBox = new System.Windows.Forms.GroupBox();
            this.tcpServerPort_textBox = new System.Windows.Forms.TextBox();
            this.tcpServerIP_textBox = new System.Windows.Forms.TextBox();
            this.tCPServerPort_label = new System.Windows.Forms.Label();
            this.tCPServerIP_label = new System.Windows.Forms.Label();
            this.toolInfo_groupBox = new System.Windows.Forms.GroupBox();
            this.tool_label = new System.Windows.Forms.Label();
            this.tool_comboBox = new System.Windows.Forms.ComboBox();
            this.toolType_label = new System.Windows.Forms.Label();
            this.drilling_checkBox = new System.Windows.Forms.CheckBox();
            this.wellLog_checkBox = new System.Windows.Forms.CheckBox();
            this.logging_checkBox = new System.Windows.Forms.CheckBox();
            this.noSelect_button = new System.Windows.Forms.Button();
            this.selectAll_button = new System.Windows.Forms.Button();
            this.WitsTable_treeView = new System.Windows.Forms.TreeView();
            this.serverStartup_button = new System.Windows.Forms.Button();
            this.reConnectInteval_label = new System.Windows.Forms.Label();
            this.reConnectInteval_numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.stopServer_button = new System.Windows.Forms.Button();
            this.tCPSetting_tabControl = new System.Windows.Forms.TabControl();
            this.tCPServer_tabPage = new System.Windows.Forms.TabPage();
            this.WitsRecords_groupBox = new System.Windows.Forms.GroupBox();
            this.tCPClient_tabPage = new System.Windows.Forms.TabPage();
            this.clientConnectStop_button = new System.Windows.Forms.Button();
            this.clientReConnectInteval_label = new System.Windows.Forms.Label();
            this.clientConnect_button = new System.Windows.Forms.Button();
            this.clientWitsRecords_groupBox = new System.Windows.Forms.GroupBox();
            this.clientWitsTable_treeView = new System.Windows.Forms.TreeView();
            this.clientSelectAll_button = new System.Windows.Forms.Button();
            this.clientNoSelect_button = new System.Windows.Forms.Button();
            this.clientNetWorkSetting_groupBox = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tCPClientPort_textBox = new System.Windows.Forms.TextBox();
            this.tCPClientIP_textBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TCPClientIP_label = new System.Windows.Forms.Label();
            this.clientReConnectInteval_numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.clientToolInfo_groupBox = new System.Windows.Forms.GroupBox();
            this.drilling_radioButton = new System.Windows.Forms.RadioButton();
            this.wellLog_radioButton = new System.Windows.Forms.RadioButton();
            this.logging_radioButton = new System.Windows.Forms.RadioButton();
            this.clientTool_label = new System.Windows.Forms.Label();
            this.clientTool_comboBox = new System.Windows.Forms.ComboBox();
            this.clientToolType_label = new System.Windows.Forms.Label();
            this.netWorkSetting_groupBox.SuspendLayout();
            this.tcpServer_groupBox.SuspendLayout();
            this.toolInfo_groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reConnectInteval_numericUpDown)).BeginInit();
            this.tCPSetting_tabControl.SuspendLayout();
            this.tCPServer_tabPage.SuspendLayout();
            this.WitsRecords_groupBox.SuspendLayout();
            this.tCPClient_tabPage.SuspendLayout();
            this.clientWitsRecords_groupBox.SuspendLayout();
            this.clientNetWorkSetting_groupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clientReConnectInteval_numericUpDown)).BeginInit();
            this.clientToolInfo_groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // netWorkSetting_groupBox
            // 
            this.netWorkSetting_groupBox.Controls.Add(this.tcpServer_groupBox);
            this.netWorkSetting_groupBox.Location = new System.Drawing.Point(6, 6);
            this.netWorkSetting_groupBox.Name = "netWorkSetting_groupBox";
            this.netWorkSetting_groupBox.Size = new System.Drawing.Size(264, 137);
            this.netWorkSetting_groupBox.TabIndex = 0;
            this.netWorkSetting_groupBox.TabStop = false;
            this.netWorkSetting_groupBox.Text = "网络设置";
            // 
            // tcpServer_groupBox
            // 
            this.tcpServer_groupBox.Controls.Add(this.tcpServerPort_textBox);
            this.tcpServer_groupBox.Controls.Add(this.tcpServerIP_textBox);
            this.tcpServer_groupBox.Controls.Add(this.tCPServerPort_label);
            this.tcpServer_groupBox.Controls.Add(this.tCPServerIP_label);
            this.tcpServer_groupBox.Location = new System.Drawing.Point(26, 20);
            this.tcpServer_groupBox.Name = "tcpServer_groupBox";
            this.tcpServer_groupBox.Size = new System.Drawing.Size(211, 103);
            this.tcpServer_groupBox.TabIndex = 0;
            this.tcpServer_groupBox.TabStop = false;
            // 
            // tcpServerPort_textBox
            // 
            this.tcpServerPort_textBox.Location = new System.Drawing.Point(55, 63);
            this.tcpServerPort_textBox.MaxLength = 10;
            this.tcpServerPort_textBox.Name = "tcpServerPort_textBox";
            this.tcpServerPort_textBox.Size = new System.Drawing.Size(135, 21);
            this.tcpServerPort_textBox.TabIndex = 3;
            this.tcpServerPort_textBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tcpServerPort_textBox_KeyPress);
            this.tcpServerPort_textBox.Leave += new System.EventHandler(this.tcpServerPort_textBox_Leave);
            // 
            // tcpServerIP_textBox
            // 
            this.tcpServerIP_textBox.Location = new System.Drawing.Point(54, 21);
            this.tcpServerIP_textBox.MaxLength = 15;
            this.tcpServerIP_textBox.Name = "tcpServerIP_textBox";
            this.tcpServerIP_textBox.Size = new System.Drawing.Size(136, 21);
            this.tcpServerIP_textBox.TabIndex = 2;
            this.tcpServerIP_textBox.Text = "127.0.0.1";
            this.tcpServerIP_textBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tcpServerIP_textBox_KeyPress);
            this.tcpServerIP_textBox.Leave += new System.EventHandler(this.tcpServerIP_textBox_Leave);
            // 
            // tCPServerPort_label
            // 
            this.tCPServerPort_label.AutoSize = true;
            this.tCPServerPort_label.Location = new System.Drawing.Point(14, 66);
            this.tCPServerPort_label.Name = "tCPServerPort_label";
            this.tCPServerPort_label.Size = new System.Drawing.Size(35, 12);
            this.tCPServerPort_label.TabIndex = 1;
            this.tCPServerPort_label.Text = "端口:";
            // 
            // tCPServerIP_label
            // 
            this.tCPServerIP_label.AutoSize = true;
            this.tCPServerIP_label.Location = new System.Drawing.Point(14, 21);
            this.tCPServerIP_label.Name = "tCPServerIP_label";
            this.tCPServerIP_label.Size = new System.Drawing.Size(23, 12);
            this.tCPServerIP_label.TabIndex = 0;
            this.tCPServerIP_label.Text = "IP:";
            // 
            // toolInfo_groupBox
            // 
            this.toolInfo_groupBox.Controls.Add(this.tool_label);
            this.toolInfo_groupBox.Controls.Add(this.tool_comboBox);
            this.toolInfo_groupBox.Controls.Add(this.toolType_label);
            this.toolInfo_groupBox.Controls.Add(this.drilling_checkBox);
            this.toolInfo_groupBox.Controls.Add(this.wellLog_checkBox);
            this.toolInfo_groupBox.Controls.Add(this.logging_checkBox);
            this.toolInfo_groupBox.Location = new System.Drawing.Point(6, 160);
            this.toolInfo_groupBox.Name = "toolInfo_groupBox";
            this.toolInfo_groupBox.Size = new System.Drawing.Size(264, 275);
            this.toolInfo_groupBox.TabIndex = 1;
            this.toolInfo_groupBox.TabStop = false;
            this.toolInfo_groupBox.Text = "仪器信息选择";
            // 
            // tool_label
            // 
            this.tool_label.AutoSize = true;
            this.tool_label.Location = new System.Drawing.Point(24, 147);
            this.tool_label.Name = "tool_label";
            this.tool_label.Size = new System.Drawing.Size(35, 12);
            this.tool_label.TabIndex = 10;
            this.tool_label.Text = "仪器:";
            // 
            // tool_comboBox
            // 
            this.tool_comboBox.FormattingEnabled = true;
            this.tool_comboBox.Location = new System.Drawing.Point(86, 144);
            this.tool_comboBox.Name = "tool_comboBox";
            this.tool_comboBox.Size = new System.Drawing.Size(145, 20);
            this.tool_comboBox.TabIndex = 9;
            this.tool_comboBox.SelectedIndexChanged += new System.EventHandler(this.tool_comboBox_SelectedIndexChanged);
            // 
            // toolType_label
            // 
            this.toolType_label.AutoSize = true;
            this.toolType_label.Location = new System.Drawing.Point(24, 32);
            this.toolType_label.Name = "toolType_label";
            this.toolType_label.Size = new System.Drawing.Size(35, 12);
            this.toolType_label.TabIndex = 3;
            this.toolType_label.Text = "类型:";
            // 
            // drilling_checkBox
            // 
            this.drilling_checkBox.AutoSize = true;
            this.drilling_checkBox.Location = new System.Drawing.Point(84, 111);
            this.drilling_checkBox.Name = "drilling_checkBox";
            this.drilling_checkBox.Size = new System.Drawing.Size(48, 16);
            this.drilling_checkBox.TabIndex = 2;
            this.drilling_checkBox.Text = "钻井";
            this.drilling_checkBox.UseVisualStyleBackColor = true;
            this.drilling_checkBox.CheckedChanged += new System.EventHandler(this.logging_checkBox_CheckedChanged);
            // 
            // wellLog_checkBox
            // 
            this.wellLog_checkBox.AutoSize = true;
            this.wellLog_checkBox.Location = new System.Drawing.Point(84, 71);
            this.wellLog_checkBox.Name = "wellLog_checkBox";
            this.wellLog_checkBox.Size = new System.Drawing.Size(48, 16);
            this.wellLog_checkBox.TabIndex = 1;
            this.wellLog_checkBox.Text = "录井";
            this.wellLog_checkBox.UseVisualStyleBackColor = true;
            this.wellLog_checkBox.CheckedChanged += new System.EventHandler(this.logging_checkBox_CheckedChanged);
            // 
            // logging_checkBox
            // 
            this.logging_checkBox.AutoSize = true;
            this.logging_checkBox.Location = new System.Drawing.Point(84, 31);
            this.logging_checkBox.Name = "logging_checkBox";
            this.logging_checkBox.Size = new System.Drawing.Size(48, 16);
            this.logging_checkBox.TabIndex = 0;
            this.logging_checkBox.Text = "测井";
            this.logging_checkBox.UseVisualStyleBackColor = true;
            this.logging_checkBox.CheckedChanged += new System.EventHandler(this.logging_checkBox_CheckedChanged);
            // 
            // noSelect_button
            // 
            this.noSelect_button.Location = new System.Drawing.Point(204, 382);
            this.noSelect_button.Name = "noSelect_button";
            this.noSelect_button.Size = new System.Drawing.Size(75, 23);
            this.noSelect_button.TabIndex = 13;
            this.noSelect_button.Text = "全不选";
            this.noSelect_button.UseVisualStyleBackColor = true;
            this.noSelect_button.Click += new System.EventHandler(this.noSelect_button_Click);
            // 
            // selectAll_button
            // 
            this.selectAll_button.Location = new System.Drawing.Point(63, 382);
            this.selectAll_button.Name = "selectAll_button";
            this.selectAll_button.Size = new System.Drawing.Size(75, 23);
            this.selectAll_button.TabIndex = 12;
            this.selectAll_button.Text = "全选";
            this.selectAll_button.UseVisualStyleBackColor = true;
            this.selectAll_button.Click += new System.EventHandler(this.selectAll_button_Click);
            // 
            // WitsTable_treeView
            // 
            this.WitsTable_treeView.CheckBoxes = true;
            this.WitsTable_treeView.Location = new System.Drawing.Point(6, 31);
            this.WitsTable_treeView.Name = "WitsTable_treeView";
            this.WitsTable_treeView.Size = new System.Drawing.Size(334, 330);
            this.WitsTable_treeView.TabIndex = 6;
            this.WitsTable_treeView.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.WitsTable_treeView_AfterCheck);
            // 
            // serverStartup_button
            // 
            this.serverStartup_button.Location = new System.Drawing.Point(116, 457);
            this.serverStartup_button.Name = "serverStartup_button";
            this.serverStartup_button.Size = new System.Drawing.Size(75, 23);
            this.serverStartup_button.TabIndex = 13;
            this.serverStartup_button.Text = "启动";
            this.serverStartup_button.UseVisualStyleBackColor = true;
            this.serverStartup_button.Click += new System.EventHandler(this.serverStartup_button_Click);
            // 
            // reConnectInteval_label
            // 
            this.reConnectInteval_label.AutoSize = true;
            this.reConnectInteval_label.Location = new System.Drawing.Point(238, 462);
            this.reConnectInteval_label.Name = "reConnectInteval_label";
            this.reConnectInteval_label.Size = new System.Drawing.Size(59, 12);
            this.reConnectInteval_label.TabIndex = 14;
            this.reConnectInteval_label.Text = "重连间隔:";
            // 
            // reConnectInteval_numericUpDown
            // 
            this.reConnectInteval_numericUpDown.Location = new System.Drawing.Point(309, 458);
            this.reConnectInteval_numericUpDown.Name = "reConnectInteval_numericUpDown";
            this.reConnectInteval_numericUpDown.Size = new System.Drawing.Size(69, 21);
            this.reConnectInteval_numericUpDown.TabIndex = 15;
            // 
            // stopServer_button
            // 
            this.stopServer_button.Location = new System.Drawing.Point(424, 455);
            this.stopServer_button.Name = "stopServer_button";
            this.stopServer_button.Size = new System.Drawing.Size(75, 23);
            this.stopServer_button.TabIndex = 16;
            this.stopServer_button.Text = "停止";
            this.stopServer_button.UseVisualStyleBackColor = true;
            this.stopServer_button.Click += new System.EventHandler(this.stopServer_button_Click);
            // 
            // tCPSetting_tabControl
            // 
            this.tCPSetting_tabControl.Controls.Add(this.tCPServer_tabPage);
            this.tCPSetting_tabControl.Controls.Add(this.tCPClient_tabPage);
            this.tCPSetting_tabControl.Location = new System.Drawing.Point(26, 12);
            this.tCPSetting_tabControl.Name = "tCPSetting_tabControl";
            this.tCPSetting_tabControl.SelectedIndex = 0;
            this.tCPSetting_tabControl.Size = new System.Drawing.Size(669, 524);
            this.tCPSetting_tabControl.TabIndex = 17;
            this.tCPSetting_tabControl.Selected += new System.Windows.Forms.TabControlEventHandler(this.tCPSetting_tabControl_Selected);
            // 
            // tCPServer_tabPage
            // 
            this.tCPServer_tabPage.Controls.Add(this.WitsRecords_groupBox);
            this.tCPServer_tabPage.Controls.Add(this.stopServer_button);
            this.tCPServer_tabPage.Controls.Add(this.netWorkSetting_groupBox);
            this.tCPServer_tabPage.Controls.Add(this.reConnectInteval_numericUpDown);
            this.tCPServer_tabPage.Controls.Add(this.toolInfo_groupBox);
            this.tCPServer_tabPage.Controls.Add(this.reConnectInteval_label);
            this.tCPServer_tabPage.Controls.Add(this.serverStartup_button);
            this.tCPServer_tabPage.Location = new System.Drawing.Point(4, 22);
            this.tCPServer_tabPage.Name = "tCPServer_tabPage";
            this.tCPServer_tabPage.Padding = new System.Windows.Forms.Padding(3);
            this.tCPServer_tabPage.Size = new System.Drawing.Size(661, 498);
            this.tCPServer_tabPage.TabIndex = 0;
            this.tCPServer_tabPage.Text = "TCPServer";
            this.tCPServer_tabPage.UseVisualStyleBackColor = true;
            // 
            // WitsRecords_groupBox
            // 
            this.WitsRecords_groupBox.Controls.Add(this.WitsTable_treeView);
            this.WitsRecords_groupBox.Controls.Add(this.selectAll_button);
            this.WitsRecords_groupBox.Controls.Add(this.noSelect_button);
            this.WitsRecords_groupBox.Location = new System.Drawing.Point(299, 6);
            this.WitsRecords_groupBox.Name = "WitsRecords_groupBox";
            this.WitsRecords_groupBox.Size = new System.Drawing.Size(344, 429);
            this.WitsRecords_groupBox.TabIndex = 17;
            this.WitsRecords_groupBox.TabStop = false;
            this.WitsRecords_groupBox.Text = "数据记录选择";
            // 
            // tCPClient_tabPage
            // 
            this.tCPClient_tabPage.Controls.Add(this.clientConnectStop_button);
            this.tCPClient_tabPage.Controls.Add(this.clientReConnectInteval_label);
            this.tCPClient_tabPage.Controls.Add(this.clientConnect_button);
            this.tCPClient_tabPage.Controls.Add(this.clientWitsRecords_groupBox);
            this.tCPClient_tabPage.Controls.Add(this.clientNetWorkSetting_groupBox);
            this.tCPClient_tabPage.Controls.Add(this.clientReConnectInteval_numericUpDown);
            this.tCPClient_tabPage.Controls.Add(this.clientToolInfo_groupBox);
            this.tCPClient_tabPage.Location = new System.Drawing.Point(4, 22);
            this.tCPClient_tabPage.Name = "tCPClient_tabPage";
            this.tCPClient_tabPage.Padding = new System.Windows.Forms.Padding(3);
            this.tCPClient_tabPage.Size = new System.Drawing.Size(661, 498);
            this.tCPClient_tabPage.TabIndex = 1;
            this.tCPClient_tabPage.Text = "TCPClient";
            this.tCPClient_tabPage.UseVisualStyleBackColor = true;
            // 
            // clientConnectStop_button
            // 
            this.clientConnectStop_button.Location = new System.Drawing.Point(430, 461);
            this.clientConnectStop_button.Name = "clientConnectStop_button";
            this.clientConnectStop_button.Size = new System.Drawing.Size(75, 23);
            this.clientConnectStop_button.TabIndex = 23;
            this.clientConnectStop_button.Text = "停止";
            this.clientConnectStop_button.UseVisualStyleBackColor = true;
            this.clientConnectStop_button.Click += new System.EventHandler(this.clientConnectStop_button_Click);
            // 
            // clientReConnectInteval_label
            // 
            this.clientReConnectInteval_label.AutoSize = true;
            this.clientReConnectInteval_label.Location = new System.Drawing.Point(244, 468);
            this.clientReConnectInteval_label.Name = "clientReConnectInteval_label";
            this.clientReConnectInteval_label.Size = new System.Drawing.Size(59, 12);
            this.clientReConnectInteval_label.TabIndex = 21;
            this.clientReConnectInteval_label.Text = "重连间隔:";
            // 
            // clientConnect_button
            // 
            this.clientConnect_button.Location = new System.Drawing.Point(122, 463);
            this.clientConnect_button.Name = "clientConnect_button";
            this.clientConnect_button.Size = new System.Drawing.Size(75, 23);
            this.clientConnect_button.TabIndex = 20;
            this.clientConnect_button.Text = "连接";
            this.clientConnect_button.UseVisualStyleBackColor = true;
            this.clientConnect_button.Click += new System.EventHandler(this.clientConnect_button_Click);
            // 
            // clientWitsRecords_groupBox
            // 
            this.clientWitsRecords_groupBox.Controls.Add(this.clientWitsTable_treeView);
            this.clientWitsRecords_groupBox.Controls.Add(this.clientSelectAll_button);
            this.clientWitsRecords_groupBox.Controls.Add(this.clientNoSelect_button);
            this.clientWitsRecords_groupBox.Location = new System.Drawing.Point(305, 12);
            this.clientWitsRecords_groupBox.Name = "clientWitsRecords_groupBox";
            this.clientWitsRecords_groupBox.Size = new System.Drawing.Size(344, 429);
            this.clientWitsRecords_groupBox.TabIndex = 24;
            this.clientWitsRecords_groupBox.TabStop = false;
            this.clientWitsRecords_groupBox.Text = "数据记录选择";
            // 
            // clientWitsTable_treeView
            // 
            this.clientWitsTable_treeView.CheckBoxes = true;
            this.clientWitsTable_treeView.Location = new System.Drawing.Point(6, 31);
            this.clientWitsTable_treeView.Name = "clientWitsTable_treeView";
            this.clientWitsTable_treeView.Size = new System.Drawing.Size(334, 330);
            this.clientWitsTable_treeView.TabIndex = 6;
            this.clientWitsTable_treeView.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.clientWitsTable_treeView_AfterCheck);
            // 
            // clientSelectAll_button
            // 
            this.clientSelectAll_button.Location = new System.Drawing.Point(63, 382);
            this.clientSelectAll_button.Name = "clientSelectAll_button";
            this.clientSelectAll_button.Size = new System.Drawing.Size(75, 23);
            this.clientSelectAll_button.TabIndex = 12;
            this.clientSelectAll_button.Text = "全选";
            this.clientSelectAll_button.UseVisualStyleBackColor = true;
            this.clientSelectAll_button.Click += new System.EventHandler(this.clientSelectAll_button_Click);
            // 
            // clientNoSelect_button
            // 
            this.clientNoSelect_button.Location = new System.Drawing.Point(204, 382);
            this.clientNoSelect_button.Name = "clientNoSelect_button";
            this.clientNoSelect_button.Size = new System.Drawing.Size(75, 23);
            this.clientNoSelect_button.TabIndex = 13;
            this.clientNoSelect_button.Text = "全不选";
            this.clientNoSelect_button.UseVisualStyleBackColor = true;
            this.clientNoSelect_button.Click += new System.EventHandler(this.clientNoSelect_button_Click);
            // 
            // clientNetWorkSetting_groupBox
            // 
            this.clientNetWorkSetting_groupBox.Controls.Add(this.groupBox1);
            this.clientNetWorkSetting_groupBox.Location = new System.Drawing.Point(12, 12);
            this.clientNetWorkSetting_groupBox.Name = "clientNetWorkSetting_groupBox";
            this.clientNetWorkSetting_groupBox.Size = new System.Drawing.Size(264, 137);
            this.clientNetWorkSetting_groupBox.TabIndex = 18;
            this.clientNetWorkSetting_groupBox.TabStop = false;
            this.clientNetWorkSetting_groupBox.Text = "网络设置";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tCPClientPort_textBox);
            this.groupBox1.Controls.Add(this.tCPClientIP_textBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.TCPClientIP_label);
            this.groupBox1.Location = new System.Drawing.Point(26, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(211, 103);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // tCPClientPort_textBox
            // 
            this.tCPClientPort_textBox.Location = new System.Drawing.Point(55, 63);
            this.tCPClientPort_textBox.MaxLength = 10;
            this.tCPClientPort_textBox.Name = "tCPClientPort_textBox";
            this.tCPClientPort_textBox.Size = new System.Drawing.Size(135, 21);
            this.tCPClientPort_textBox.TabIndex = 3;
            this.tCPClientPort_textBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tCPClientPort_textBox_KeyPress);
            this.tCPClientPort_textBox.Leave += new System.EventHandler(this.tCPClientPort_textBox_Leave);
            // 
            // tCPClientIP_textBox
            // 
            this.tCPClientIP_textBox.Location = new System.Drawing.Point(54, 21);
            this.tCPClientIP_textBox.MaxLength = 15;
            this.tCPClientIP_textBox.Name = "tCPClientIP_textBox";
            this.tCPClientIP_textBox.Size = new System.Drawing.Size(136, 21);
            this.tCPClientIP_textBox.TabIndex = 2;
            this.tCPClientIP_textBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tCPClientIP_textBox_KeyPress);
            this.tCPClientIP_textBox.Leave += new System.EventHandler(this.tCPClientIP_textBox_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "端口:";
            // 
            // TCPClientIP_label
            // 
            this.TCPClientIP_label.AutoSize = true;
            this.TCPClientIP_label.Location = new System.Drawing.Point(14, 21);
            this.TCPClientIP_label.Name = "TCPClientIP_label";
            this.TCPClientIP_label.Size = new System.Drawing.Size(23, 12);
            this.TCPClientIP_label.TabIndex = 0;
            this.TCPClientIP_label.Text = "IP:";
            // 
            // clientReConnectInteval_numericUpDown
            // 
            this.clientReConnectInteval_numericUpDown.Location = new System.Drawing.Point(315, 464);
            this.clientReConnectInteval_numericUpDown.Name = "clientReConnectInteval_numericUpDown";
            this.clientReConnectInteval_numericUpDown.Size = new System.Drawing.Size(69, 21);
            this.clientReConnectInteval_numericUpDown.TabIndex = 22;
            // 
            // clientToolInfo_groupBox
            // 
            this.clientToolInfo_groupBox.Controls.Add(this.drilling_radioButton);
            this.clientToolInfo_groupBox.Controls.Add(this.wellLog_radioButton);
            this.clientToolInfo_groupBox.Controls.Add(this.logging_radioButton);
            this.clientToolInfo_groupBox.Controls.Add(this.clientTool_label);
            this.clientToolInfo_groupBox.Controls.Add(this.clientTool_comboBox);
            this.clientToolInfo_groupBox.Controls.Add(this.clientToolType_label);
            this.clientToolInfo_groupBox.Location = new System.Drawing.Point(12, 166);
            this.clientToolInfo_groupBox.Name = "clientToolInfo_groupBox";
            this.clientToolInfo_groupBox.Size = new System.Drawing.Size(264, 275);
            this.clientToolInfo_groupBox.TabIndex = 19;
            this.clientToolInfo_groupBox.TabStop = false;
            this.clientToolInfo_groupBox.Text = "仪器信息选择";
            // 
            // drilling_radioButton
            // 
            this.drilling_radioButton.AutoSize = true;
            this.drilling_radioButton.Location = new System.Drawing.Point(89, 104);
            this.drilling_radioButton.Name = "drilling_radioButton";
            this.drilling_radioButton.Size = new System.Drawing.Size(47, 16);
            this.drilling_radioButton.TabIndex = 13;
            this.drilling_radioButton.TabStop = true;
            this.drilling_radioButton.Text = "钻井";
            this.drilling_radioButton.UseVisualStyleBackColor = true;
            this.drilling_radioButton.CheckedChanged += new System.EventHandler(this.logging_radioButton_CheckedChanged);
            // 
            // wellLog_radioButton
            // 
            this.wellLog_radioButton.AutoSize = true;
            this.wellLog_radioButton.Location = new System.Drawing.Point(89, 67);
            this.wellLog_radioButton.Name = "wellLog_radioButton";
            this.wellLog_radioButton.Size = new System.Drawing.Size(47, 16);
            this.wellLog_radioButton.TabIndex = 12;
            this.wellLog_radioButton.TabStop = true;
            this.wellLog_radioButton.Text = "录井";
            this.wellLog_radioButton.UseVisualStyleBackColor = true;
            this.wellLog_radioButton.CheckedChanged += new System.EventHandler(this.logging_radioButton_CheckedChanged);
            // 
            // logging_radioButton
            // 
            this.logging_radioButton.AutoSize = true;
            this.logging_radioButton.Location = new System.Drawing.Point(89, 30);
            this.logging_radioButton.Name = "logging_radioButton";
            this.logging_radioButton.Size = new System.Drawing.Size(47, 16);
            this.logging_radioButton.TabIndex = 11;
            this.logging_radioButton.TabStop = true;
            this.logging_radioButton.Text = "测井";
            this.logging_radioButton.UseVisualStyleBackColor = true;
            this.logging_radioButton.CheckedChanged += new System.EventHandler(this.logging_radioButton_CheckedChanged);
            // 
            // clientTool_label
            // 
            this.clientTool_label.AutoSize = true;
            this.clientTool_label.Location = new System.Drawing.Point(24, 147);
            this.clientTool_label.Name = "clientTool_label";
            this.clientTool_label.Size = new System.Drawing.Size(35, 12);
            this.clientTool_label.TabIndex = 10;
            this.clientTool_label.Text = "仪器:";
            // 
            // clientTool_comboBox
            // 
            this.clientTool_comboBox.FormattingEnabled = true;
            this.clientTool_comboBox.Location = new System.Drawing.Point(86, 144);
            this.clientTool_comboBox.Name = "clientTool_comboBox";
            this.clientTool_comboBox.Size = new System.Drawing.Size(145, 20);
            this.clientTool_comboBox.TabIndex = 9;
            this.clientTool_comboBox.SelectedIndexChanged += new System.EventHandler(this.clientTool_comboBox_SelectedIndexChanged);
            // 
            // clientToolType_label
            // 
            this.clientToolType_label.AutoSize = true;
            this.clientToolType_label.Location = new System.Drawing.Point(24, 32);
            this.clientToolType_label.Name = "clientToolType_label";
            this.clientToolType_label.Size = new System.Drawing.Size(35, 12);
            this.clientToolType_label.TabIndex = 3;
            this.clientToolType_label.Text = "类型:";
            // 
            // RecConfig_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 548);
            this.Controls.Add(this.tCPSetting_tabControl);
            this.Name = "RecConfig_Form";
            this.Text = "Wits接收配置";
            this.Load += new System.EventHandler(this.RecConfig_Form_Load);
            this.netWorkSetting_groupBox.ResumeLayout(false);
            this.tcpServer_groupBox.ResumeLayout(false);
            this.tcpServer_groupBox.PerformLayout();
            this.toolInfo_groupBox.ResumeLayout(false);
            this.toolInfo_groupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reConnectInteval_numericUpDown)).EndInit();
            this.tCPSetting_tabControl.ResumeLayout(false);
            this.tCPServer_tabPage.ResumeLayout(false);
            this.tCPServer_tabPage.PerformLayout();
            this.WitsRecords_groupBox.ResumeLayout(false);
            this.tCPClient_tabPage.ResumeLayout(false);
            this.tCPClient_tabPage.PerformLayout();
            this.clientWitsRecords_groupBox.ResumeLayout(false);
            this.clientNetWorkSetting_groupBox.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clientReConnectInteval_numericUpDown)).EndInit();
            this.clientToolInfo_groupBox.ResumeLayout(false);
            this.clientToolInfo_groupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox netWorkSetting_groupBox;
        private System.Windows.Forms.GroupBox tcpServer_groupBox;
        private System.Windows.Forms.TextBox tcpServerPort_textBox;
        private System.Windows.Forms.TextBox tcpServerIP_textBox;
        private System.Windows.Forms.Label tCPServerPort_label;
        private System.Windows.Forms.Label tCPServerIP_label;
        private System.Windows.Forms.GroupBox toolInfo_groupBox;
        private System.Windows.Forms.Button noSelect_button;
        private System.Windows.Forms.Button selectAll_button;
        private System.Windows.Forms.Label tool_label;
        private System.Windows.Forms.ComboBox tool_comboBox;
        private System.Windows.Forms.TreeView WitsTable_treeView;
        private System.Windows.Forms.Label toolType_label;
        private System.Windows.Forms.CheckBox drilling_checkBox;
        private System.Windows.Forms.CheckBox wellLog_checkBox;
        private System.Windows.Forms.CheckBox logging_checkBox;
        private System.Windows.Forms.Button serverStartup_button;
        private System.Windows.Forms.Label reConnectInteval_label;
        private System.Windows.Forms.NumericUpDown reConnectInteval_numericUpDown;
        private System.Windows.Forms.Button stopServer_button;
        private System.Windows.Forms.TabControl tCPSetting_tabControl;
        private System.Windows.Forms.TabPage tCPServer_tabPage;
        private System.Windows.Forms.TabPage tCPClient_tabPage;
        private System.Windows.Forms.GroupBox WitsRecords_groupBox;
        private System.Windows.Forms.Button clientConnectStop_button;
        private System.Windows.Forms.Label clientReConnectInteval_label;
        private System.Windows.Forms.Button clientConnect_button;
        private System.Windows.Forms.GroupBox clientWitsRecords_groupBox;
        private System.Windows.Forms.TreeView clientWitsTable_treeView;
        private System.Windows.Forms.Button clientSelectAll_button;
        private System.Windows.Forms.Button clientNoSelect_button;
        private System.Windows.Forms.GroupBox clientNetWorkSetting_groupBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tCPClientPort_textBox;
        private System.Windows.Forms.TextBox tCPClientIP_textBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label TCPClientIP_label;
        private System.Windows.Forms.NumericUpDown clientReConnectInteval_numericUpDown;
        private System.Windows.Forms.GroupBox clientToolInfo_groupBox;
        private System.Windows.Forms.Label clientTool_label;
        private System.Windows.Forms.ComboBox clientTool_comboBox;
        private System.Windows.Forms.Label clientToolType_label;
        private System.Windows.Forms.RadioButton drilling_radioButton;
        private System.Windows.Forms.RadioButton wellLog_radioButton;
        private System.Windows.Forms.RadioButton logging_radioButton;
    }
}