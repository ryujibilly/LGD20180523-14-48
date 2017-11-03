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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button_GetAllInstInfo = new System.Windows.Forms.Button();
            this.button_ConnectTest = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_LocalLog = new System.Windows.Forms.TextBox();
            this.textBox_RemoteLog = new System.Windows.Forms.TextBox();
            this.button_OpenLocalLog = new System.Windows.Forms.Button();
            this.button_OpenRemoteLog = new System.Windows.Forms.Button();
            this.openFileDialog_Local = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog_Remote = new System.Windows.Forms.OpenFileDialog();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_getAllRegions
            // 
            this.button_getAllRegions.Location = new System.Drawing.Point(693, 178);
            this.button_getAllRegions.Name = "button_getAllRegions";
            this.button_getAllRegions.Size = new System.Drawing.Size(145, 23);
            this.button_getAllRegions.TabIndex = 0;
            this.button_getAllRegions.Text = "获取工区信息";
            this.button_getAllRegions.UseVisualStyleBackColor = true;
            this.button_getAllRegions.Click += new System.EventHandler(this.button_Connect_Click);
            // 
            // textBox_UserName
            // 
            this.textBox_UserName.Location = new System.Drawing.Point(63, 17);
            this.textBox_UserName.Name = "textBox_UserName";
            this.textBox_UserName.Size = new System.Drawing.Size(100, 21);
            this.textBox_UserName.TabIndex = 1;
            this.textBox_UserName.Text = "yuwenmao";
            this.textBox_UserName.TextChanged += new System.EventHandler(this.textBox_UserName_TextChanged);
            // 
            // textBox_PassWord
            // 
            this.textBox_PassWord.Location = new System.Drawing.Point(63, 44);
            this.textBox_PassWord.Name = "textBox_PassWord";
            this.textBox_PassWord.PasswordChar = '*';
            this.textBox_PassWord.Size = new System.Drawing.Size(100, 21);
            this.textBox_PassWord.TabIndex = 2;
            this.textBox_PassWord.Text = "123";
            this.textBox_PassWord.TextChanged += new System.EventHandler(this.textBox_PassWord_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "用户名";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "密  码";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(18, 71);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 21);
            this.textBox3.TabIndex = 5;
            this.textBox3.Text = "1";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(124, 71);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 21);
            this.textBox4.TabIndex = 6;
            this.textBox4.Text = "2";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(18, 98);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "加法";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(112, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 12);
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
            this.groupBox1.Location = new System.Drawing.Point(693, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(304, 134);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "本地测试";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(522, 249);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(476, 256);
            this.dataGridView1.TabIndex = 10;
            // 
            // button_GetAllInstInfo
            // 
            this.button_GetAllInstInfo.Location = new System.Drawing.Point(693, 220);
            this.button_GetAllInstInfo.Name = "button_GetAllInstInfo";
            this.button_GetAllInstInfo.Size = new System.Drawing.Size(145, 23);
            this.button_GetAllInstInfo.TabIndex = 11;
            this.button_GetAllInstInfo.Text = "获取仪器信息";
            this.button_GetAllInstInfo.UseVisualStyleBackColor = true;
            this.button_GetAllInstInfo.Click += new System.EventHandler(this.button_GetAllInstInfo_Click);
            // 
            // button_ConnectTest
            // 
            this.button_ConnectTest.Location = new System.Drawing.Point(169, 20);
            this.button_ConnectTest.Name = "button_ConnectTest";
            this.button_ConnectTest.Size = new System.Drawing.Size(129, 39);
            this.button_ConnectTest.TabIndex = 12;
            this.button_ConnectTest.Text = "测试连接服务器";
            this.button_ConnectTest.UseVisualStyleBackColor = true;
            this.button_ConnectTest.Click += new System.EventHandler(this.button_ConnectTest_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button_OpenRemoteLog);
            this.groupBox2.Controls.Add(this.button_OpenLocalLog);
            this.groupBox2.Controls.Add(this.textBox_RemoteLog);
            this.groupBox2.Controls.Add(this.textBox_LocalLog);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(13, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(503, 100);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "井次选择";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "本地井次";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 1;
            this.label5.Text = "远程井次";
            // 
            // textBox_LocalLog
            // 
            this.textBox_LocalLog.Location = new System.Drawing.Point(69, 21);
            this.textBox_LocalLog.Name = "textBox_LocalLog";
            this.textBox_LocalLog.Size = new System.Drawing.Size(377, 21);
            this.textBox_LocalLog.TabIndex = 2;
            // 
            // textBox_RemoteLog
            // 
            this.textBox_RemoteLog.Location = new System.Drawing.Point(69, 48);
            this.textBox_RemoteLog.Name = "textBox_RemoteLog";
            this.textBox_RemoteLog.Size = new System.Drawing.Size(377, 21);
            this.textBox_RemoteLog.TabIndex = 3;
            // 
            // button_OpenLocalLog
            // 
            this.button_OpenLocalLog.Location = new System.Drawing.Point(452, 19);
            this.button_OpenLocalLog.Name = "button_OpenLocalLog";
            this.button_OpenLocalLog.Size = new System.Drawing.Size(45, 23);
            this.button_OpenLocalLog.TabIndex = 4;
            this.button_OpenLocalLog.Text = "选择";
            this.button_OpenLocalLog.UseVisualStyleBackColor = true;
            // 
            // button_OpenRemoteLog
            // 
            this.button_OpenRemoteLog.Location = new System.Drawing.Point(452, 46);
            this.button_OpenRemoteLog.Name = "button_OpenRemoteLog";
            this.button_OpenRemoteLog.Size = new System.Drawing.Size(45, 23);
            this.button_OpenRemoteLog.TabIndex = 5;
            this.button_OpenRemoteLog.Text = "选择";
            this.button_OpenRemoteLog.UseVisualStyleBackColor = true;
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
            this.groupBox3.Controls.Add(this.treeView1);
            this.groupBox3.Controls.Add(this.comboBox1);
            this.groupBox3.Controls.Add(this.radioButton3);
            this.groupBox3.Controls.Add(this.radioButton2);
            this.groupBox3.Controls.Add(this.radioButton1);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Location = new System.Drawing.Point(13, 119);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(503, 384);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "仪器信息选择";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "仪器：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 64);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 1;
            this.label7.Text = "类型：";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(113, 62);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(47, 16);
            this.radioButton1.TabIndex = 2;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "测井";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(233, 62);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(47, 16);
            this.radioButton2.TabIndex = 3;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "录井";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(348, 62);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(47, 16);
            this.radioButton3.TabIndex = 4;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "钻井";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(69, 23);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(377, 20);
            this.comboBox1.TabIndex = 5;
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(7, 80);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(490, 306);
            this.treeView1.TabIndex = 6;
            // 
            // RealDBPusher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1009, 515);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button_GetAllInstInfo);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button_getAllRegions);
            this.Name = "RealDBPusher";
            this.Text = "实时数据推送";
            this.Load += new System.EventHandler(this.RealDBPusher_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
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
        private System.Windows.Forms.DataGridView dataGridView1;
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
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TreeView treeView1;
    }
}