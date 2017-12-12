namespace WitsTransmission.WitsSend
{
    partial class TcpServerConfig_Form
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
            this.cancel_button = new System.Windows.Forms.Button();
            this.ensure_button = new System.Windows.Forms.Button();
            this.tcpServerPort_textBox = new System.Windows.Forms.TextBox();
            this.tcpServerPort_label = new System.Windows.Forms.Label();
            this.tcpServerIP_textBox = new System.Windows.Forms.TextBox();
            this.tcpServerIP_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cancel_button
            // 
            this.cancel_button.Location = new System.Drawing.Point(215, 192);
            this.cancel_button.Name = "cancel_button";
            this.cancel_button.Size = new System.Drawing.Size(75, 23);
            this.cancel_button.TabIndex = 17;
            this.cancel_button.Text = "取消";
            this.cancel_button.UseVisualStyleBackColor = true;
            this.cancel_button.Click += new System.EventHandler(this.cancel_button_Click);
            // 
            // ensure_button
            // 
            this.ensure_button.Location = new System.Drawing.Point(87, 192);
            this.ensure_button.Name = "ensure_button";
            this.ensure_button.Size = new System.Drawing.Size(75, 23);
            this.ensure_button.TabIndex = 16;
            this.ensure_button.Text = "确定";
            this.ensure_button.UseVisualStyleBackColor = true;
            this.ensure_button.Click += new System.EventHandler(this.ensure_button_Click);
            // 
            // tcpServerPort_textBox
            // 
            this.tcpServerPort_textBox.Location = new System.Drawing.Point(137, 114);
            this.tcpServerPort_textBox.MaxLength = 10;
            this.tcpServerPort_textBox.Name = "tcpServerPort_textBox";
            this.tcpServerPort_textBox.Size = new System.Drawing.Size(153, 21);
            this.tcpServerPort_textBox.TabIndex = 12;
            this.tcpServerPort_textBox.Click += new System.EventHandler(this.tcpServerPort_textBox_Click);
            this.tcpServerPort_textBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tcpServerPort_textBox_KeyPress);
            this.tcpServerPort_textBox.Leave += new System.EventHandler(this.tcpServerPort_textBox_Leave);
            // 
            // tcpServerPort_label
            // 
            this.tcpServerPort_label.AutoSize = true;
            this.tcpServerPort_label.Location = new System.Drawing.Point(85, 117);
            this.tcpServerPort_label.Name = "tcpServerPort_label";
            this.tcpServerPort_label.Size = new System.Drawing.Size(35, 12);
            this.tcpServerPort_label.TabIndex = 11;
            this.tcpServerPort_label.Text = "Port:";
            // 
            // tcpServerIP_textBox
            // 
            this.tcpServerIP_textBox.Location = new System.Drawing.Point(137, 55);
            this.tcpServerIP_textBox.MaxLength = 15;
            this.tcpServerIP_textBox.Name = "tcpServerIP_textBox";
            this.tcpServerIP_textBox.Size = new System.Drawing.Size(153, 21);
            this.tcpServerIP_textBox.TabIndex = 10;
            this.tcpServerIP_textBox.Text = "127.0.0.1";
            this.tcpServerIP_textBox.Click += new System.EventHandler(this.tcpServerIP_textBox_Click);
            this.tcpServerIP_textBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tcpServerIP_textBox_KeyPress);
            this.tcpServerIP_textBox.Leave += new System.EventHandler(this.tcpServerIP_textBox_Leave);
            // 
            // tcpServerIP_label
            // 
            this.tcpServerIP_label.AutoSize = true;
            this.tcpServerIP_label.Location = new System.Drawing.Point(85, 58);
            this.tcpServerIP_label.Name = "tcpServerIP_label";
            this.tcpServerIP_label.Size = new System.Drawing.Size(23, 12);
            this.tcpServerIP_label.TabIndex = 9;
            this.tcpServerIP_label.Text = "IP:";
            // 
            // TcpServerConfig_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 262);
            this.Controls.Add(this.cancel_button);
            this.Controls.Add(this.ensure_button);
            this.Controls.Add(this.tcpServerPort_textBox);
            this.Controls.Add(this.tcpServerPort_label);
            this.Controls.Add(this.tcpServerIP_textBox);
            this.Controls.Add(this.tcpServerIP_label);
            this.Name = "TcpServerConfig_Form";
            this.Text = "配置TcpServer";
            this.Load += new System.EventHandler(this.TcpServerConfig_Form_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancel_button;
        private System.Windows.Forms.Button ensure_button;
        private System.Windows.Forms.TextBox tcpServerPort_textBox;
        private System.Windows.Forms.Label tcpServerPort_label;
        private System.Windows.Forms.TextBox tcpServerIP_textBox;
        private System.Windows.Forms.Label tcpServerIP_label;
    }
}