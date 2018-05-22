namespace RealTimeDB
{
    partial class AdvancedOption
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button_ok = new System.Windows.Forms.Button();
            this.button_cancel = new System.Windows.Forms.Button();
            this.checkBox_hold = new System.Windows.Forms.CheckBox();
            this.numericUpDown_Fps = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_Repeat = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_Interval = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Fps)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Repeat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Interval)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "推送间隔(s):";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "重复推送次数:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "每次推送帧数:";
            // 
            // button_ok
            // 
            this.button_ok.Location = new System.Drawing.Point(55, 143);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(75, 23);
            this.button_ok.TabIndex = 7;
            this.button_ok.Text = "确定";
            this.button_ok.UseVisualStyleBackColor = true;
            this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
            // 
            // button_cancel
            // 
            this.button_cancel.Location = new System.Drawing.Point(192, 143);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(75, 23);
            this.button_cancel.TabIndex = 8;
            this.button_cancel.Text = "取消";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // checkBox_hold
            // 
            this.checkBox_hold.AutoSize = true;
            this.checkBox_hold.Checked = global::RealTimeDB.Properties.Settings.Default.HoldOn;
            this.checkBox_hold.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_hold.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::RealTimeDB.Properties.Settings.Default, "HoldOn", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBox_hold.Location = new System.Drawing.Point(240, 63);
            this.checkBox_hold.Name = "checkBox_hold";
            this.checkBox_hold.Size = new System.Drawing.Size(72, 16);
            this.checkBox_hold.TabIndex = 6;
            this.checkBox_hold.Text = "保持工作";
            this.checkBox_hold.UseVisualStyleBackColor = true;
            this.checkBox_hold.CheckedChanged += new System.EventHandler(this.checkBox_hold_CheckedChanged);
            // 
            // numericUpDown_Fps
            // 
            this.numericUpDown_Fps.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::RealTimeDB.Properties.Settings.Default, "FPS", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.numericUpDown_Fps.Location = new System.Drawing.Point(129, 98);
            this.numericUpDown_Fps.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown_Fps.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDown_Fps.Name = "numericUpDown_Fps";
            this.numericUpDown_Fps.Size = new System.Drawing.Size(95, 21);
            this.numericUpDown_Fps.TabIndex = 5;
            this.numericUpDown_Fps.Value = global::RealTimeDB.Properties.Settings.Default.FPS;
            this.numericUpDown_Fps.ValueChanged += new System.EventHandler(this.numericUpDown_Fps_ValueChanged);
            // 
            // numericUpDown_Repeat
            // 
            this.numericUpDown_Repeat.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::RealTimeDB.Properties.Settings.Default, "Repeat", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.numericUpDown_Repeat.Location = new System.Drawing.Point(129, 60);
            this.numericUpDown_Repeat.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown_Repeat.Name = "numericUpDown_Repeat";
            this.numericUpDown_Repeat.Size = new System.Drawing.Size(95, 21);
            this.numericUpDown_Repeat.TabIndex = 4;
            this.numericUpDown_Repeat.Value = global::RealTimeDB.Properties.Settings.Default.Repeat;
            this.numericUpDown_Repeat.ValueChanged += new System.EventHandler(this.numericUpDown_Repeat_ValueChanged);
            // 
            // numericUpDown_Interval
            // 
            this.numericUpDown_Interval.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::RealTimeDB.Properties.Settings.Default, "Interval", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.numericUpDown_Interval.Location = new System.Drawing.Point(129, 22);
            this.numericUpDown_Interval.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.numericUpDown_Interval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_Interval.Name = "numericUpDown_Interval";
            this.numericUpDown_Interval.Size = new System.Drawing.Size(95, 21);
            this.numericUpDown_Interval.TabIndex = 3;
            this.numericUpDown_Interval.Value = global::RealTimeDB.Properties.Settings.Default.Interval;
            this.numericUpDown_Interval.ValueChanged += new System.EventHandler(this.numericUpDown_Interval_ValueChanged);
            // 
            // AdvancedOption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 178);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.button_ok);
            this.Controls.Add(this.checkBox_hold);
            this.Controls.Add(this.numericUpDown_Fps);
            this.Controls.Add(this.numericUpDown_Repeat);
            this.Controls.Add(this.numericUpDown_Interval);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AdvancedOption";
            this.Text = "推送设置";
            this.Load += new System.EventHandler(this.AdvancedOption_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Fps)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Repeat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Interval)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDown_Interval;
        private System.Windows.Forms.NumericUpDown numericUpDown_Repeat;
        private System.Windows.Forms.NumericUpDown numericUpDown_Fps;
        private System.Windows.Forms.CheckBox checkBox_hold;
        private System.Windows.Forms.Button button_ok;
        private System.Windows.Forms.Button button_cancel;
    }
}