namespace RealTimeDB
{
    partial class RealDB_DAQ
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numericUpDown_MaxClient = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox_HostIP = new System.Windows.Forms.ComboBox();
            this.textBox_HostPort = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button_Close = new System.Windows.Forms.Button();
            this.button_Listening = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_MaxClient)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numericUpDown_MaxClient);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.comboBox_HostIP);
            this.groupBox1.Controls.Add(this.textBox_HostPort);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(336, 93);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "TCP/IP服务端配置";
            // 
            // numericUpDown_MaxClient
            // 
            this.numericUpDown_MaxClient.Location = new System.Drawing.Point(251, 57);
            this.numericUpDown_MaxClient.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDown_MaxClient.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_MaxClient.Name = "numericUpDown_MaxClient";
            this.numericUpDown_MaxClient.Size = new System.Drawing.Size(70, 21);
            this.numericUpDown_MaxClient.TabIndex = 9;
            this.numericUpDown_MaxClient.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown_MaxClient.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_MaxClient.ValueChanged += new System.EventHandler(this.numericUpDown_MaxClient_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(168, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "最大客户端数";
            // 
            // comboBox_HostIP
            // 
            this.comboBox_HostIP.FormattingEnabled = true;
            this.comboBox_HostIP.Location = new System.Drawing.Point(67, 30);
            this.comboBox_HostIP.Name = "comboBox_HostIP";
            this.comboBox_HostIP.Size = new System.Drawing.Size(143, 20);
            this.comboBox_HostIP.TabIndex = 3;
            this.comboBox_HostIP.SelectedIndexChanged += new System.EventHandler(this.comboBox_HostIP_SelectedIndexChanged);
            // 
            // textBox_HostPort
            // 
            this.textBox_HostPort.Location = new System.Drawing.Point(67, 56);
            this.textBox_HostPort.Name = "textBox_HostPort";
            this.textBox_HostPort.Size = new System.Drawing.Size(74, 21);
            this.textBox_HostPort.TabIndex = 2;
            this.textBox_HostPort.Text = "9001";
            this.textBox_HostPort.TextChanged += new System.EventHandler(this.textBox_HostPort_TextChanged);
            this.textBox_HostPort.Leave += new System.EventHandler(this.textBox_HostPort_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "本机端口";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "本机IP";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "客户端列表";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(23, 133);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(311, 256);
            this.listBox1.TabIndex = 6;
            // 
            // button_Close
            // 
            this.button_Close.Location = new System.Drawing.Point(355, 72);
            this.button_Close.Name = "button_Close";
            this.button_Close.Size = new System.Drawing.Size(87, 23);
            this.button_Close.TabIndex = 5;
            this.button_Close.Text = "关闭服务器";
            this.button_Close.UseVisualStyleBackColor = true;
            this.button_Close.Click += new System.EventHandler(this.button_Close_Click);
            // 
            // button_Listening
            // 
            this.button_Listening.Location = new System.Drawing.Point(355, 35);
            this.button_Listening.Name = "button_Listening";
            this.button_Listening.Size = new System.Drawing.Size(87, 23);
            this.button_Listening.TabIndex = 4;
            this.button_Listening.Text = "建立服务器";
            this.button_Listening.UseVisualStyleBackColor = true;
            this.button_Listening.Click += new System.EventHandler(this.button_Listening_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(506, 13);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(248, 376);
            this.textBox1.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(776, 68);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "写入";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // RealDB_DAQ
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(937, 404);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button_Listening);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button_Close);
            this.Controls.Add(this.listBox1);
            this.Name = "RealDB_DAQ";
            this.Text = "RealDB_DAQ";
            this.Load += new System.EventHandler(this.RealDB_DAQ_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_MaxClient)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox_HostPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_HostIP;
        private System.Windows.Forms.Button button_Listening;
        private System.Windows.Forms.Button button_Close;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDown_MaxClient;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
    }
}