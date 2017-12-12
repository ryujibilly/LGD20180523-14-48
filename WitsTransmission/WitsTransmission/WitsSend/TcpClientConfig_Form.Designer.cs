namespace WitsTransmission.WitsSend
{
    partial class TcpClientConfig_Form
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
            this.tcpClientIP_label = new System.Windows.Forms.Label();
            this.tcpClientIP_textBox = new System.Windows.Forms.TextBox();
            this.tcpClientPort_label = new System.Windows.Forms.Label();
            this.tcpClientPort_textBox = new System.Windows.Forms.TextBox();
            this.reconnectInterval_label = new System.Windows.Forms.Label();
            this.reconnectInterval_numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.second_label = new System.Windows.Forms.Label();
            this.ensure_button = new System.Windows.Forms.Button();
            this.cancel_button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.reconnectInterval_numericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // tcpClientIP_label
            // 
            this.tcpClientIP_label.AutoSize = true;
            this.tcpClientIP_label.Location = new System.Drawing.Point(84, 38);
            this.tcpClientIP_label.Name = "tcpClientIP_label";
            this.tcpClientIP_label.Size = new System.Drawing.Size(23, 12);
            this.tcpClientIP_label.TabIndex = 0;
            this.tcpClientIP_label.Text = "IP:";
            // 
            // tcpClientIP_textBox
            // 
            this.tcpClientIP_textBox.Location = new System.Drawing.Point(136, 35);
            this.tcpClientIP_textBox.MaxLength = 15;
            this.tcpClientIP_textBox.Name = "tcpClientIP_textBox";
            this.tcpClientIP_textBox.Size = new System.Drawing.Size(153, 21);
            this.tcpClientIP_textBox.TabIndex = 1;
            this.tcpClientIP_textBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tcpClientIP_textBox_KeyPress);
            this.tcpClientIP_textBox.Leave += new System.EventHandler(this.tcpClientIP_textBox_Leave);
            // 
            // tcpClientPort_label
            // 
            this.tcpClientPort_label.AutoSize = true;
            this.tcpClientPort_label.Location = new System.Drawing.Point(84, 97);
            this.tcpClientPort_label.Name = "tcpClientPort_label";
            this.tcpClientPort_label.Size = new System.Drawing.Size(35, 12);
            this.tcpClientPort_label.TabIndex = 2;
            this.tcpClientPort_label.Text = "Port:";
            // 
            // tcpClientPort_textBox
            // 
            this.tcpClientPort_textBox.Location = new System.Drawing.Point(136, 94);
            this.tcpClientPort_textBox.MaxLength = 10;
            this.tcpClientPort_textBox.Name = "tcpClientPort_textBox";
            this.tcpClientPort_textBox.Size = new System.Drawing.Size(153, 21);
            this.tcpClientPort_textBox.TabIndex = 3;
            this.tcpClientPort_textBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tcpClientPort_textBox_KeyPress);
            this.tcpClientPort_textBox.Leave += new System.EventHandler(this.tcpClientPort_textBox_Leave);
            // 
            // reconnectInterval_label
            // 
            this.reconnectInterval_label.AutoSize = true;
            this.reconnectInterval_label.Location = new System.Drawing.Point(67, 156);
            this.reconnectInterval_label.Name = "reconnectInterval_label";
            this.reconnectInterval_label.Size = new System.Drawing.Size(65, 12);
            this.reconnectInterval_label.TabIndex = 4;
            this.reconnectInterval_label.Text = "重连间隔：";
            // 
            // reconnectInterval_numericUpDown
            // 
            this.reconnectInterval_numericUpDown.Location = new System.Drawing.Point(136, 153);
            this.reconnectInterval_numericUpDown.Name = "reconnectInterval_numericUpDown";
            this.reconnectInterval_numericUpDown.Size = new System.Drawing.Size(120, 21);
            this.reconnectInterval_numericUpDown.TabIndex = 5;
            // 
            // second_label
            // 
            this.second_label.AutoSize = true;
            this.second_label.Location = new System.Drawing.Point(267, 156);
            this.second_label.Name = "second_label";
            this.second_label.Size = new System.Drawing.Size(11, 12);
            this.second_label.TabIndex = 6;
            this.second_label.Text = "s";
            // 
            // ensure_button
            // 
            this.ensure_button.Location = new System.Drawing.Point(86, 206);
            this.ensure_button.Name = "ensure_button";
            this.ensure_button.Size = new System.Drawing.Size(75, 23);
            this.ensure_button.TabIndex = 7;
            this.ensure_button.Text = "确定";
            this.ensure_button.UseVisualStyleBackColor = true;
            this.ensure_button.Click += new System.EventHandler(this.ensure_button_Click);
            // 
            // cancel_button
            // 
            this.cancel_button.Location = new System.Drawing.Point(214, 206);
            this.cancel_button.Name = "cancel_button";
            this.cancel_button.Size = new System.Drawing.Size(75, 23);
            this.cancel_button.TabIndex = 8;
            this.cancel_button.Text = "取消";
            this.cancel_button.UseVisualStyleBackColor = true;
            this.cancel_button.Click += new System.EventHandler(this.cancel_button_Click);
            // 
            // TcpClientConfig_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 263);
            this.Controls.Add(this.cancel_button);
            this.Controls.Add(this.ensure_button);
            this.Controls.Add(this.second_label);
            this.Controls.Add(this.reconnectInterval_numericUpDown);
            this.Controls.Add(this.reconnectInterval_label);
            this.Controls.Add(this.tcpClientPort_textBox);
            this.Controls.Add(this.tcpClientPort_label);
            this.Controls.Add(this.tcpClientIP_textBox);
            this.Controls.Add(this.tcpClientIP_label);
            this.Name = "TcpClientConfig_Form";
            this.Text = "配置TcpClient";
            this.Load += new System.EventHandler(this.TcpClientConfig_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.reconnectInterval_numericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label tcpClientIP_label;
        private System.Windows.Forms.TextBox tcpClientIP_textBox;
        private System.Windows.Forms.Label tcpClientPort_label;
        private System.Windows.Forms.TextBox tcpClientPort_textBox;
        private System.Windows.Forms.Label reconnectInterval_label;
        private System.Windows.Forms.NumericUpDown reconnectInterval_numericUpDown;
        private System.Windows.Forms.Label second_label;
        private System.Windows.Forms.Button ensure_button;
        private System.Windows.Forms.Button cancel_button;
    }
}