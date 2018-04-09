namespace RealTimeDB
{
    partial class NetWorkSelections
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
            this.radioButton_Other = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_serviceUrl = new System.Windows.Forms.TextBox();
            this.radioButton_Inter = new System.Windows.Forms.RadioButton();
            this.radioButton_Intra = new System.Windows.Forms.RadioButton();
            this.button_OK = new System.Windows.Forms.Button();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton_Other);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox_serviceUrl);
            this.groupBox1.Controls.Add(this.radioButton_Inter);
            this.groupBox1.Controls.Add(this.radioButton_Intra);
            this.groupBox1.Location = new System.Drawing.Point(15, 18);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(540, 95);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "网络配置";
            // 
            // radioButton_Other
            // 
            this.radioButton_Other.AutoSize = true;
            this.radioButton_Other.Location = new System.Drawing.Point(375, 28);
            this.radioButton_Other.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radioButton_Other.Name = "radioButton_Other";
            this.radioButton_Other.Size = new System.Drawing.Size(50, 21);
            this.radioButton_Other.TabIndex = 4;
            this.radioButton_Other.TabStop = true;
            this.radioButton_Other.Text = "其他";
            this.radioButton_Other.UseVisualStyleBackColor = true;
            this.radioButton_Other.CheckedChanged += new System.EventHandler(this.radioButton_Other_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "http://";
            // 
            // textBox_serviceUrl
            // 
            this.textBox_serviceUrl.Enabled = false;
            this.textBox_serviceUrl.Location = new System.Drawing.Point(57, 54);
            this.textBox_serviceUrl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_serviceUrl.Name = "textBox_serviceUrl";
            this.textBox_serviceUrl.Size = new System.Drawing.Size(476, 23);
            this.textBox_serviceUrl.TabIndex = 2;
            this.textBox_serviceUrl.TextChanged += new System.EventHandler(this.textBox_serviceUrl_TextChanged);
            // 
            // radioButton_Inter
            // 
            this.radioButton_Inter.AutoSize = true;
            this.radioButton_Inter.Location = new System.Drawing.Point(229, 28);
            this.radioButton_Inter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radioButton_Inter.Name = "radioButton_Inter";
            this.radioButton_Inter.Size = new System.Drawing.Size(50, 21);
            this.radioButton_Inter.TabIndex = 1;
            this.radioButton_Inter.TabStop = true;
            this.radioButton_Inter.Text = "外网";
            this.radioButton_Inter.UseVisualStyleBackColor = true;
            this.radioButton_Inter.CheckedChanged += new System.EventHandler(this.radioButton_Inter_CheckedChanged);
            // 
            // radioButton_Intra
            // 
            this.radioButton_Intra.AutoSize = true;
            this.radioButton_Intra.Location = new System.Drawing.Point(82, 28);
            this.radioButton_Intra.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radioButton_Intra.Name = "radioButton_Intra";
            this.radioButton_Intra.Size = new System.Drawing.Size(50, 21);
            this.radioButton_Intra.TabIndex = 0;
            this.radioButton_Intra.TabStop = true;
            this.radioButton_Intra.Text = "内网";
            this.radioButton_Intra.UseVisualStyleBackColor = true;
            this.radioButton_Intra.CheckedChanged += new System.EventHandler(this.radioButton_Intra_CheckedChanged);
            // 
            // button_OK
            // 
            this.button_OK.Location = new System.Drawing.Point(84, 121);
            this.button_OK.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(87, 33);
            this.button_OK.TabIndex = 1;
            this.button_OK.Text = "确定";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // button_Cancel
            // 
            this.button_Cancel.Location = new System.Drawing.Point(381, 121);
            this.button_Cancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(87, 33);
            this.button_Cancel.TabIndex = 2;
            this.button_Cancel.Text = "取消";
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // NetWorkSelections
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 167);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_OK);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "NetWorkSelections";
            this.Text = "基地服务网络配置";
            this.Load += new System.EventHandler(this.NetWorkSelections_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton_Inter;
        private System.Windows.Forms.RadioButton radioButton_Intra;
        private System.Windows.Forms.TextBox textBox_serviceUrl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.RadioButton radioButton_Other;
    }
}