
namespace RealTimeDB
{
    partial class RealDBPusher
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
            this.button_getAllRegions = new System.Windows.Forms.Button();
            this.textBox_UserName = new System.Windows.Forms.TextBox();
            this.textBox_PassWord = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_ConnectTest = new System.Windows.Forms.Button();
            this.button_GetAllInstInfo = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button_OpenRemoteLog = new System.Windows.Forms.Button();
            this.button_OpenLocalLog = new System.Windows.Forms.Button();
            this.textBox_RemoteLog = new System.Windows.Forms.TextBox();
            this.textBox_LocalLog = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.openFileDialog_Local = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog_Remote = new System.Windows.Forms.OpenFileDialog();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button_AllNone = new System.Windows.Forms.Button();
            this.button_SelectAll = new System.Windows.Forms.Button();
            this.drilling_checkBox = new System.Windows.Forms.CheckBox();
            this.wellLog_checkBox = new System.Windows.Forms.CheckBox();
            this.logging_checkBox = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.WitsTable_treeView = new System.Windows.Forms.TreeView();
            this.comboBox_Inst = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox_Push = new System.Windows.Forms.GroupBox();
            this.button_Push = new System.Windows.Forms.Button();
            this.dateTimePicker_End = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_Begin = new System.Windows.Forms.DateTimePicker();
            this.checkBox_DateFromTop = new System.Windows.Forms.CheckBox();
            this.button_StartPush_Test = new System.Windows.Forms.Button();
            this.checkBox_DateToBottom = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.button_StopPush = new System.Windows.Forms.Button();
            this.checkBox_DataCover = new System.Windows.Forms.CheckBox();
            this.button_AdvancedOption = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.listBox_UpdateStatus = new System.Windows.Forms.ListBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.groupBox_StatusMonitor = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox_Push.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.groupBox_StatusMonitor.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_getAllRegions
            // 
            this.button_getAllRegions.Location = new System.Drawing.Point(500, 68);
            this.button_getAllRegions.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_getAllRegions.Name = "button_getAllRegions";
            this.button_getAllRegions.Size = new System.Drawing.Size(101, 36);
            this.button_getAllRegions.TabIndex = 0;
            this.button_getAllRegions.Text = "获取工区信息";
            this.button_getAllRegions.UseVisualStyleBackColor = true;
            this.button_getAllRegions.Click += new System.EventHandler(this.button_Connect_Click);
            // 
            // textBox_UserName
            // 
            this.textBox_UserName.Location = new System.Drawing.Point(73, 24);
            this.textBox_UserName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_UserName.Name = "textBox_UserName";
            this.textBox_UserName.Size = new System.Drawing.Size(116, 23);
            this.textBox_UserName.TabIndex = 1;
            this.textBox_UserName.Text = "yuwenmao";
            this.textBox_UserName.TextChanged += new System.EventHandler(this.textBox_UserName_TextChanged);
            // 
            // textBox_PassWord
            // 
            this.textBox_PassWord.Location = new System.Drawing.Point(73, 62);
            this.textBox_PassWord.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_PassWord.Name = "textBox_PassWord";
            this.textBox_PassWord.PasswordChar = '*';
            this.textBox_PassWord.Size = new System.Drawing.Size(116, 23);
            this.textBox_PassWord.TabIndex = 2;
            this.textBox_PassWord.Text = "123";
            this.textBox_PassWord.TextChanged += new System.EventHandler(this.textBox_PassWord_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "用户名";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "密  码";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(21, 101);
            this.textBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(116, 23);
            this.textBox3.TabIndex = 5;
            this.textBox3.Text = "1";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(145, 101);
            this.textBox4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(116, 23);
            this.textBox4.TabIndex = 6;
            this.textBox4.Text = "2";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(21, 139);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 33);
            this.button1.TabIndex = 7;
            this.button1.Text = "加法";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(131, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "=";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_ConnectTest);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBox4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox_UserName);
            this.groupBox1.Controls.Add(this.textBox_PassWord);
            this.groupBox1.Location = new System.Drawing.Point(1328, 32);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(355, 98);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "本地测试";
            // 
            // button_ConnectTest
            // 
            this.button_ConnectTest.Location = new System.Drawing.Point(197, 28);
            this.button_ConnectTest.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_ConnectTest.Name = "button_ConnectTest";
            this.button_ConnectTest.Size = new System.Drawing.Size(150, 55);
            this.button_ConnectTest.TabIndex = 12;
            this.button_ConnectTest.Text = "测试连接服务器";
            this.button_ConnectTest.UseVisualStyleBackColor = true;
            this.button_ConnectTest.Click += new System.EventHandler(this.button_ConnectTest_Click);
            // 
            // button_GetAllInstInfo
            // 
            this.button_GetAllInstInfo.Location = new System.Drawing.Point(381, 68);
            this.button_GetAllInstInfo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_GetAllInstInfo.Name = "button_GetAllInstInfo";
            this.button_GetAllInstInfo.Size = new System.Drawing.Size(101, 36);
            this.button_GetAllInstInfo.TabIndex = 11;
            this.button_GetAllInstInfo.Text = "获取仪器信息";
            this.button_GetAllInstInfo.UseVisualStyleBackColor = true;
            this.button_GetAllInstInfo.Click += new System.EventHandler(this.button_GetAllInstInfo_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button_OpenRemoteLog);
            this.groupBox2.Controls.Add(this.button_OpenLocalLog);
            this.groupBox2.Controls.Add(this.textBox_RemoteLog);
            this.groupBox2.Controls.Add(this.textBox_LocalLog);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(15, 18);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(534, 112);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "井 次 选 择";
            // 
            // button_OpenRemoteLog
            // 
            this.button_OpenRemoteLog.Location = new System.Drawing.Point(472, 67);
            this.button_OpenRemoteLog.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_OpenRemoteLog.Name = "button_OpenRemoteLog";
            this.button_OpenRemoteLog.Size = new System.Drawing.Size(52, 33);
            this.button_OpenRemoteLog.TabIndex = 5;
            this.button_OpenRemoteLog.Text = "选择";
            this.button_OpenRemoteLog.UseVisualStyleBackColor = true;
            this.button_OpenRemoteLog.Click += new System.EventHandler(this.button_OpenRemoteLog_Click);
            // 
            // button_OpenLocalLog
            // 
            this.button_OpenLocalLog.Location = new System.Drawing.Point(472, 28);
            this.button_OpenLocalLog.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_OpenLocalLog.Name = "button_OpenLocalLog";
            this.button_OpenLocalLog.Size = new System.Drawing.Size(52, 33);
            this.button_OpenLocalLog.TabIndex = 4;
            this.button_OpenLocalLog.Text = "选择";
            this.button_OpenLocalLog.UseVisualStyleBackColor = true;
            this.button_OpenLocalLog.Click += new System.EventHandler(this.button_OpenLocalLog_Click);
            // 
            // textBox_RemoteLog
            // 
            this.textBox_RemoteLog.Location = new System.Drawing.Point(80, 68);
            this.textBox_RemoteLog.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_RemoteLog.Name = "textBox_RemoteLog";
            this.textBox_RemoteLog.ReadOnly = true;
            this.textBox_RemoteLog.Size = new System.Drawing.Size(384, 23);
            this.textBox_RemoteLog.TabIndex = 3;
            // 
            // textBox_LocalLog
            // 
            this.textBox_LocalLog.Location = new System.Drawing.Point(80, 30);
            this.textBox_LocalLog.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_LocalLog.Name = "textBox_LocalLog";
            this.textBox_LocalLog.ReadOnly = true;
            this.textBox_LocalLog.Size = new System.Drawing.Size(384, 23);
            this.textBox_LocalLog.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 17);
            this.label5.TabIndex = 1;
            this.label5.Text = "远程井次";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "本地井次";
            // 
            // openFileDialog_Local
            // 
            this.openFileDialog_Local.FileName = "openFileDialog1";
            // 
            // openFileDialog_Remote
            // 
            this.openFileDialog_Remote.FileName = "openFileDialog2";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button_AllNone);
            this.groupBox3.Controls.Add(this.button_SelectAll);
            this.groupBox3.Controls.Add(this.drilling_checkBox);
            this.groupBox3.Controls.Add(this.wellLog_checkBox);
            this.groupBox3.Controls.Add(this.logging_checkBox);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.WitsTable_treeView);
            this.groupBox3.Controls.Add(this.comboBox_Inst);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Location = new System.Drawing.Point(15, 139);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Size = new System.Drawing.Size(534, 520);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "仪 器 信 息 选 择";
            // 
            // button_AllNone
            // 
            this.button_AllNone.Location = new System.Drawing.Point(310, 479);
            this.button_AllNone.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_AllNone.Name = "button_AllNone";
            this.button_AllNone.Size = new System.Drawing.Size(125, 33);
            this.button_AllNone.TabIndex = 12;
            this.button_AllNone.Text = "全不选";
            this.button_AllNone.UseVisualStyleBackColor = true;
            this.button_AllNone.Click += new System.EventHandler(this.button_AllNone_Click);
            // 
            // button_SelectAll
            // 
            this.button_SelectAll.Location = new System.Drawing.Point(84, 479);
            this.button_SelectAll.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_SelectAll.Name = "button_SelectAll";
            this.button_SelectAll.Size = new System.Drawing.Size(125, 33);
            this.button_SelectAll.TabIndex = 11;
            this.button_SelectAll.Text = "全  选";
            this.button_SelectAll.UseVisualStyleBackColor = true;
            this.button_SelectAll.Click += new System.EventHandler(this.button_SelectAll_Click);
            // 
            // drilling_checkBox
            // 
            this.drilling_checkBox.AutoSize = true;
            this.drilling_checkBox.Location = new System.Drawing.Point(433, 28);
            this.drilling_checkBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.drilling_checkBox.Name = "drilling_checkBox";
            this.drilling_checkBox.Size = new System.Drawing.Size(51, 21);
            this.drilling_checkBox.TabIndex = 10;
            this.drilling_checkBox.Text = "钻井";
            this.drilling_checkBox.UseVisualStyleBackColor = true;
            this.drilling_checkBox.CheckedChanged += new System.EventHandler(this.logging_checkBox_CheckedChanged);
            // 
            // wellLog_checkBox
            // 
            this.wellLog_checkBox.AutoSize = true;
            this.wellLog_checkBox.Location = new System.Drawing.Point(255, 28);
            this.wellLog_checkBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.wellLog_checkBox.Name = "wellLog_checkBox";
            this.wellLog_checkBox.Size = new System.Drawing.Size(51, 21);
            this.wellLog_checkBox.TabIndex = 9;
            this.wellLog_checkBox.Text = "录井";
            this.wellLog_checkBox.UseVisualStyleBackColor = true;
            this.wellLog_checkBox.CheckedChanged += new System.EventHandler(this.logging_checkBox_CheckedChanged);
            // 
            // logging_checkBox
            // 
            this.logging_checkBox.AutoSize = true;
            this.logging_checkBox.Location = new System.Drawing.Point(84, 28);
            this.logging_checkBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.logging_checkBox.Name = "logging_checkBox";
            this.logging_checkBox.Size = new System.Drawing.Size(51, 21);
            this.logging_checkBox.TabIndex = 8;
            this.logging_checkBox.Text = "测井";
            this.logging_checkBox.UseVisualStyleBackColor = true;
            this.logging_checkBox.CheckedChanged += new System.EventHandler(this.logging_checkBox_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 92);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 17);
            this.label8.TabIndex = 7;
            this.label8.Text = "数据记录:";
            // 
            // WitsTable_treeView
            // 
            this.WitsTable_treeView.CheckBoxes = true;
            this.WitsTable_treeView.Location = new System.Drawing.Point(13, 113);
            this.WitsTable_treeView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.WitsTable_treeView.Name = "WitsTable_treeView";
            this.WitsTable_treeView.Size = new System.Drawing.Size(511, 355);
            this.WitsTable_treeView.TabIndex = 6;
            this.WitsTable_treeView.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.WitsTable_treeView_AfterCheck);
            // 
            // comboBox_Inst
            // 
            this.comboBox_Inst.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Inst.FormattingEnabled = true;
            this.comboBox_Inst.Location = new System.Drawing.Point(84, 59);
            this.comboBox_Inst.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBox_Inst.Name = "comboBox_Inst";
            this.comboBox_Inst.Size = new System.Drawing.Size(439, 25);
            this.comboBox_Inst.TabIndex = 5;
            this.comboBox_Inst.SelectedIndexChanged += new System.EventHandler(this.comboBox_Inst_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 17);
            this.label7.TabIndex = 1;
            this.label7.Text = "类型：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "仪器：";
            // 
            // groupBox_Push
            // 
            this.groupBox_Push.Controls.Add(this.button_Push);
            this.groupBox_Push.Controls.Add(this.dateTimePicker_End);
            this.groupBox_Push.Controls.Add(this.button_GetAllInstInfo);
            this.groupBox_Push.Controls.Add(this.dateTimePicker_Begin);
            this.groupBox_Push.Controls.Add(this.checkBox_DateFromTop);
            this.groupBox_Push.Controls.Add(this.button_getAllRegions);
            this.groupBox_Push.Controls.Add(this.button_StartPush_Test);
            this.groupBox_Push.Controls.Add(this.checkBox_DateToBottom);
            this.groupBox_Push.Controls.Add(this.label10);
            this.groupBox_Push.Controls.Add(this.label9);
            this.groupBox_Push.Controls.Add(this.button_StopPush);
            this.groupBox_Push.Controls.Add(this.checkBox_DataCover);
            this.groupBox_Push.Controls.Add(this.button_AdvancedOption);
            this.groupBox_Push.Location = new System.Drawing.Point(556, 18);
            this.groupBox_Push.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox_Push.Name = "groupBox_Push";
            this.groupBox_Push.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox_Push.Size = new System.Drawing.Size(728, 112);
            this.groupBox_Push.TabIndex = 14;
            this.groupBox_Push.TabStop = false;
            this.groupBox_Push.Text = "推 送 选 项";
            // 
            // button_Push
            // 
            this.button_Push.Location = new System.Drawing.Point(133, 68);
            this.button_Push.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_Push.Name = "button_Push";
            this.button_Push.Size = new System.Drawing.Size(101, 36);
            this.button_Push.TabIndex = 10;
            this.button_Push.Text = "开始";
            this.button_Push.UseVisualStyleBackColor = true;
            this.button_Push.Click += new System.EventHandler(this.button_Push_Click);
            // 
            // dateTimePicker_End
            // 
            this.dateTimePicker_End.Location = new System.Drawing.Point(510, 24);
            this.dateTimePicker_End.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dateTimePicker_End.Name = "dateTimePicker_End";
            this.dateTimePicker_End.Size = new System.Drawing.Size(128, 23);
            this.dateTimePicker_End.TabIndex = 9;
            this.dateTimePicker_End.ValueChanged += new System.EventHandler(this.dateTimePicker_End_ValueChanged);
            // 
            // dateTimePicker_Begin
            // 
            this.dateTimePicker_Begin.Location = new System.Drawing.Point(189, 24);
            this.dateTimePicker_Begin.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dateTimePicker_Begin.Name = "dateTimePicker_Begin";
            this.dateTimePicker_Begin.Size = new System.Drawing.Size(128, 23);
            this.dateTimePicker_Begin.TabIndex = 8;
            this.dateTimePicker_Begin.ValueChanged += new System.EventHandler(this.dateTimePicker_Begin_ValueChanged);
            // 
            // checkBox_DateFromTop
            // 
            this.checkBox_DateFromTop.AutoSize = true;
            this.checkBox_DateFromTop.Location = new System.Drawing.Point(324, 27);
            this.checkBox_DateFromTop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkBox_DateFromTop.Name = "checkBox_DateFromTop";
            this.checkBox_DateFromTop.Size = new System.Drawing.Size(75, 21);
            this.checkBox_DateFromTop.TabIndex = 7;
            this.checkBox_DateFromTop.Text = "从头开始";
            this.checkBox_DateFromTop.UseVisualStyleBackColor = true;
            this.checkBox_DateFromTop.CheckedChanged += new System.EventHandler(this.checkBox_DateFromTop_CheckedChanged);
            // 
            // button_StartPush_Test
            // 
            this.button_StartPush_Test.Location = new System.Drawing.Point(626, 68);
            this.button_StartPush_Test.Name = "button_StartPush_Test";
            this.button_StartPush_Test.Size = new System.Drawing.Size(75, 36);
            this.button_StartPush_Test.TabIndex = 12;
            this.button_StartPush_Test.Text = "测试";
            // 
            // checkBox_DateToBottom
            // 
            this.checkBox_DateToBottom.AutoSize = true;
            this.checkBox_DateToBottom.Location = new System.Drawing.Point(645, 27);
            this.checkBox_DateToBottom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkBox_DateToBottom.Name = "checkBox_DateToBottom";
            this.checkBox_DateToBottom.Size = new System.Drawing.Size(75, 21);
            this.checkBox_DateToBottom.TabIndex = 6;
            this.checkBox_DateToBottom.Text = "持续更新";
            this.checkBox_DateToBottom.UseVisualStyleBackColor = true;
            this.checkBox_DateToBottom.CheckedChanged += new System.EventHandler(this.checkBox_DateToBottom_CheckedChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(441, 29);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 17);
            this.label10.TabIndex = 5;
            this.label10.Text = "结束时间";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(120, 29);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 17);
            this.label9.TabIndex = 4;
            this.label9.Text = "起始时间";
            // 
            // button_StopPush
            // 
            this.button_StopPush.Location = new System.Drawing.Point(255, 68);
            this.button_StopPush.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_StopPush.Name = "button_StopPush";
            this.button_StopPush.Size = new System.Drawing.Size(101, 36);
            this.button_StopPush.TabIndex = 3;
            this.button_StopPush.Text = "停止";
            this.button_StopPush.UseVisualStyleBackColor = true;
            this.button_StopPush.Click += new System.EventHandler(this.button_StopPush_Click);
            // 
            // checkBox_DataCover
            // 
            this.checkBox_DataCover.AutoSize = true;
            this.checkBox_DataCover.Location = new System.Drawing.Point(7, 77);
            this.checkBox_DataCover.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkBox_DataCover.Name = "checkBox_DataCover";
            this.checkBox_DataCover.Size = new System.Drawing.Size(75, 21);
            this.checkBox_DataCover.TabIndex = 1;
            this.checkBox_DataCover.Text = "数据覆盖";
            this.checkBox_DataCover.UseVisualStyleBackColor = true;
            this.checkBox_DataCover.CheckedChanged += new System.EventHandler(this.checkBox_DataCover_CheckedChanged);
            // 
            // button_AdvancedOption
            // 
            this.button_AdvancedOption.Location = new System.Drawing.Point(7, 28);
            this.button_AdvancedOption.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_AdvancedOption.Name = "button_AdvancedOption";
            this.button_AdvancedOption.Size = new System.Drawing.Size(101, 36);
            this.button_AdvancedOption.TabIndex = 0;
            this.button_AdvancedOption.Text = "高级设置";
            this.button_AdvancedOption.UseVisualStyleBackColor = true;
            this.button_AdvancedOption.Click += new System.EventHandler(this.button_AdvancedOption_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.listBox_UpdateStatus);
            this.groupBox4.Location = new System.Drawing.Point(558, 139);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox4.Size = new System.Drawing.Size(728, 520);
            this.groupBox4.TabIndex = 15;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "推 送 状 态";
            // 
            // listBox_UpdateStatus
            // 
            this.listBox_UpdateStatus.FormattingEnabled = true;
            this.listBox_UpdateStatus.ItemHeight = 17;
            this.listBox_UpdateStatus.Location = new System.Drawing.Point(6, 22);
            this.listBox_UpdateStatus.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.listBox_UpdateStatus.Name = "listBox_UpdateStatus";
            this.listBox_UpdateStatus.Size = new System.Drawing.Size(712, 480);
            this.listBox_UpdateStatus.TabIndex = 0;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(7, 21);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.Size = new System.Drawing.Size(409, 320);
            this.dataGridView2.TabIndex = 0;
            // 
            // groupBox_StatusMonitor
            // 
            this.groupBox_StatusMonitor.Controls.Add(this.dataGridView2);
            this.groupBox_StatusMonitor.Location = new System.Drawing.Point(1309, 790);
            this.groupBox_StatusMonitor.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox_StatusMonitor.Name = "groupBox_StatusMonitor";
            this.groupBox_StatusMonitor.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox_StatusMonitor.Size = new System.Drawing.Size(436, 350);
            this.groupBox_StatusMonitor.TabIndex = 16;
            this.groupBox_StatusMonitor.TabStop = false;
            this.groupBox_StatusMonitor.Text = "状态监视";
            // 
            // RealDBPusher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1294, 676);
            this.Controls.Add(this.groupBox_StatusMonitor);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox_Push);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "RealDBPusher";
            this.Text = "实时数据推送";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RealDBPusher_FormClosing);
            this.Load += new System.EventHandler(this.RealDBPusher_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox_Push.ResumeLayout(false);
            this.groupBox_Push.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.groupBox_StatusMonitor.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_getAllRegions;
        private System.Windows.Forms.TextBox textBox_UserName;
        private System.Windows.Forms.TextBox textBox_PassWord;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button_GetAllInstInfo;
        private System.Windows.Forms.Button button_ConnectTest;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_RemoteLog;
        private System.Windows.Forms.TextBox textBox_LocalLog;
        private System.Windows.Forms.Button button_OpenLocalLog;
        private System.Windows.Forms.Button button_OpenRemoteLog;
        private System.Windows.Forms.OpenFileDialog openFileDialog_Local;
        private System.Windows.Forms.OpenFileDialog openFileDialog_Remote;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox_Inst;
        private System.Windows.Forms.TreeView WitsTable_treeView;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox drilling_checkBox;
        private System.Windows.Forms.CheckBox wellLog_checkBox;
        private System.Windows.Forms.CheckBox logging_checkBox;
        private System.Windows.Forms.Button button_AllNone;
        private System.Windows.Forms.Button button_SelectAll;
        private System.Windows.Forms.GroupBox groupBox_Push;
        private System.Windows.Forms.Button button_AdvancedOption;
        private System.Windows.Forms.CheckBox checkBox_DataCover;
        private System.Windows.Forms.Button button_StopPush;
        private System.Windows.Forms.Button button_StartPush_Test;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox checkBox_DateFromTop;
        private System.Windows.Forms.CheckBox checkBox_DateToBottom;
        private System.Windows.Forms.DateTimePicker dateTimePicker_Begin;
        private System.Windows.Forms.DateTimePicker dateTimePicker_End;
        private System.Windows.Forms.Button button_Push;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dataGridView2;
        //private System.Windows.Forms.Timer timer_Push;
        private Tool.Timer.MMTimer timer_Push;
        private System.Windows.Forms.GroupBox groupBox_StatusMonitor;
        private System.Windows.Forms.ListBox listBox_UpdateStatus;
    }
}