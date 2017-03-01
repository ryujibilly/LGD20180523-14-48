namespace LGD.UI.SystemSettings
{
    partial class AlarmSetting
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
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button_WorkingCondition = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkBox_OutAlarm = new System.Windows.Forms.CheckBox();
            this.checkBox_logRecord = new System.Windows.Forms.CheckBox();
            this.checkBox_TextAlarm = new System.Windows.Forms.CheckBox();
            this.checkBox_FlashAlarm = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_SelectMusic = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button_TryAlarmMusic = new System.Windows.Forms.Button();
            this.radioButton_CustomAlarm = new System.Windows.Forms.RadioButton();
            this.radioButton_DefeaultAlarm = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button_DeleteAll = new System.Windows.Forms.Button();
            this.button_Delete = new System.Windows.Forms.Button();
            this.button_SelectAll = new System.Windows.Forms.Button();
            this.button_Select = new System.Windows.Forms.Button();
            this.listBox_Attribute = new System.Windows.Forms.ListBox();
            this.listBox_Table = new System.Windows.Forms.ListBox();
            this.openFileDialog_SelectMusic = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.button_DeleteAll);
            this.groupBox1.Controls.Add(this.button_Delete);
            this.groupBox1.Controls.Add(this.button_SelectAll);
            this.groupBox1.Controls.Add(this.button_Select);
            this.groupBox1.Controls.Add(this.listBox_Attribute);
            this.groupBox1.Controls.Add(this.listBox_Table);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(642, 506);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "报警数据源";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.numericUpDown1);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Location = new System.Drawing.Point(313, 173);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(317, 257);
            this.groupBox5.TabIndex = 10;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "报警门限设置";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(126, 19);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 21);
            this.numericUpDown1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "延迟时间(s):";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.button_WorkingCondition);
            this.groupBox4.Controls.Add(this.textBox2);
            this.groupBox4.Location = new System.Drawing.Point(7, 436);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(623, 57);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "工况设置";
            // 
            // button_WorkingCondition
            // 
            this.button_WorkingCondition.Location = new System.Drawing.Point(532, 19);
            this.button_WorkingCondition.Name = "button_WorkingCondition";
            this.button_WorkingCondition.Size = new System.Drawing.Size(83, 23);
            this.button_WorkingCondition.TabIndex = 1;
            this.button_WorkingCondition.Text = "工况";
            this.button_WorkingCondition.UseVisualStyleBackColor = true;
            this.button_WorkingCondition.Click += new System.EventHandler(this.button_WorkingCondition_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(7, 21);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(519, 21);
            this.textBox2.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkBox_OutAlarm);
            this.groupBox3.Controls.Add(this.checkBox_logRecord);
            this.groupBox3.Controls.Add(this.checkBox_TextAlarm);
            this.groupBox3.Controls.Add(this.checkBox_FlashAlarm);
            this.groupBox3.Controls.Add(this.checkBox1);
            this.groupBox3.Controls.Add(this.panel1);
            this.groupBox3.Location = new System.Drawing.Point(7, 164);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(299, 266);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "报警类型设置";
            // 
            // checkBox_OutAlarm
            // 
            this.checkBox_OutAlarm.AutoSize = true;
            this.checkBox_OutAlarm.Location = new System.Drawing.Point(6, 239);
            this.checkBox_OutAlarm.Name = "checkBox_OutAlarm";
            this.checkBox_OutAlarm.Size = new System.Drawing.Size(72, 16);
            this.checkBox_OutAlarm.TabIndex = 5;
            this.checkBox_OutAlarm.Text = "外部提示";
            this.checkBox_OutAlarm.UseVisualStyleBackColor = true;
            // 
            // checkBox_logRecord
            // 
            this.checkBox_logRecord.AutoSize = true;
            this.checkBox_logRecord.Location = new System.Drawing.Point(6, 217);
            this.checkBox_logRecord.Name = "checkBox_logRecord";
            this.checkBox_logRecord.Size = new System.Drawing.Size(72, 16);
            this.checkBox_logRecord.TabIndex = 4;
            this.checkBox_logRecord.Text = "日志记录";
            this.checkBox_logRecord.UseVisualStyleBackColor = true;
            // 
            // checkBox_TextAlarm
            // 
            this.checkBox_TextAlarm.AutoSize = true;
            this.checkBox_TextAlarm.Location = new System.Drawing.Point(7, 195);
            this.checkBox_TextAlarm.Name = "checkBox_TextAlarm";
            this.checkBox_TextAlarm.Size = new System.Drawing.Size(72, 16);
            this.checkBox_TextAlarm.TabIndex = 3;
            this.checkBox_TextAlarm.Text = "文本提示";
            this.checkBox_TextAlarm.UseVisualStyleBackColor = true;
            // 
            // checkBox_FlashAlarm
            // 
            this.checkBox_FlashAlarm.AutoSize = true;
            this.checkBox_FlashAlarm.Location = new System.Drawing.Point(7, 173);
            this.checkBox_FlashAlarm.Name = "checkBox_FlashAlarm";
            this.checkBox_FlashAlarm.Size = new System.Drawing.Size(72, 16);
            this.checkBox_FlashAlarm.TabIndex = 2;
            this.checkBox_FlashAlarm.Text = "闪烁提示";
            this.checkBox_FlashAlarm.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(6, 20);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(72, 16);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Text = "声音报警";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button_SelectMusic);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.button_TryAlarmMusic);
            this.panel1.Controls.Add(this.radioButton_CustomAlarm);
            this.panel1.Controls.Add(this.radioButton_DefeaultAlarm);
            this.panel1.Location = new System.Drawing.Point(6, 42);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(287, 124);
            this.panel1.TabIndex = 0;
            // 
            // button_SelectMusic
            // 
            this.button_SelectMusic.Location = new System.Drawing.Point(212, 89);
            this.button_SelectMusic.Name = "button_SelectMusic";
            this.button_SelectMusic.Size = new System.Drawing.Size(72, 23);
            this.button_SelectMusic.TabIndex = 4;
            this.button_SelectMusic.Text = "选择";
            this.button_SelectMusic.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(24, 91);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(182, 21);
            this.textBox1.TabIndex = 3;
            // 
            // button_TryAlarmMusic
            // 
            this.button_TryAlarmMusic.Location = new System.Drawing.Point(163, 56);
            this.button_TryAlarmMusic.Name = "button_TryAlarmMusic";
            this.button_TryAlarmMusic.Size = new System.Drawing.Size(75, 23);
            this.button_TryAlarmMusic.TabIndex = 2;
            this.button_TryAlarmMusic.Text = "试听";
            this.button_TryAlarmMusic.UseVisualStyleBackColor = true;
            // 
            // radioButton_CustomAlarm
            // 
            this.radioButton_CustomAlarm.AutoSize = true;
            this.radioButton_CustomAlarm.Location = new System.Drawing.Point(24, 59);
            this.radioButton_CustomAlarm.Name = "radioButton_CustomAlarm";
            this.radioButton_CustomAlarm.Size = new System.Drawing.Size(83, 16);
            this.radioButton_CustomAlarm.TabIndex = 1;
            this.radioButton_CustomAlarm.TabStop = true;
            this.radioButton_CustomAlarm.Text = "自定义声音";
            this.radioButton_CustomAlarm.UseVisualStyleBackColor = true;
            // 
            // radioButton_DefeaultAlarm
            // 
            this.radioButton_DefeaultAlarm.AutoSize = true;
            this.radioButton_DefeaultAlarm.Location = new System.Drawing.Point(24, 15);
            this.radioButton_DefeaultAlarm.Name = "radioButton_DefeaultAlarm";
            this.radioButton_DefeaultAlarm.Size = new System.Drawing.Size(83, 16);
            this.radioButton_DefeaultAlarm.TabIndex = 0;
            this.radioButton_DefeaultAlarm.TabStop = true;
            this.radioButton_DefeaultAlarm.Text = "默认报警声";
            this.radioButton_DefeaultAlarm.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listBox1);
            this.groupBox2.Location = new System.Drawing.Point(433, 20);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(203, 137);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "报警参数列表";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(6, 18);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(191, 112);
            this.listBox1.TabIndex = 6;
            // 
            // button_DeleteAll
            // 
            this.button_DeleteAll.Location = new System.Drawing.Point(337, 120);
            this.button_DeleteAll.Name = "button_DeleteAll";
            this.button_DeleteAll.Size = new System.Drawing.Size(75, 23);
            this.button_DeleteAll.TabIndex = 5;
            this.button_DeleteAll.Text = "<<";
            this.button_DeleteAll.UseVisualStyleBackColor = true;
            // 
            // button_Delete
            // 
            this.button_Delete.Location = new System.Drawing.Point(337, 90);
            this.button_Delete.Name = "button_Delete";
            this.button_Delete.Size = new System.Drawing.Size(75, 23);
            this.button_Delete.TabIndex = 4;
            this.button_Delete.Text = "<";
            this.button_Delete.UseVisualStyleBackColor = true;
            // 
            // button_SelectAll
            // 
            this.button_SelectAll.Location = new System.Drawing.Point(337, 61);
            this.button_SelectAll.Name = "button_SelectAll";
            this.button_SelectAll.Size = new System.Drawing.Size(75, 23);
            this.button_SelectAll.TabIndex = 3;
            this.button_SelectAll.Text = ">>";
            this.button_SelectAll.UseVisualStyleBackColor = true;
            // 
            // button_Select
            // 
            this.button_Select.Location = new System.Drawing.Point(337, 31);
            this.button_Select.Name = "button_Select";
            this.button_Select.Size = new System.Drawing.Size(75, 23);
            this.button_Select.TabIndex = 2;
            this.button_Select.Text = ">";
            this.button_Select.UseVisualStyleBackColor = true;
            // 
            // listBox_Attribute
            // 
            this.listBox_Attribute.FormattingEnabled = true;
            this.listBox_Attribute.ItemHeight = 12;
            this.listBox_Attribute.Items.AddRange(new object[] {
            "级联属性"});
            this.listBox_Attribute.Location = new System.Drawing.Point(176, 21);
            this.listBox_Attribute.Name = "listBox_Attribute";
            this.listBox_Attribute.Size = new System.Drawing.Size(130, 136);
            this.listBox_Attribute.TabIndex = 1;
            // 
            // listBox_Table
            // 
            this.listBox_Table.FormattingEnabled = true;
            this.listBox_Table.ItemHeight = 12;
            this.listBox_Table.Items.AddRange(new object[] {
            "钻进",
            "MWD",
            "LWD",
            "起钻",
            "下钻",
            "自定义1",
            "自定义2",
            "气测参数",
            "采集",
            "动态",
            "井压",
            "循环"});
            this.listBox_Table.Location = new System.Drawing.Point(6, 21);
            this.listBox_Table.Name = "listBox_Table";
            this.listBox_Table.Size = new System.Drawing.Size(145, 136);
            this.listBox_Table.TabIndex = 0;
            // 
            // openFileDialog_SelectMusic
            // 
            this.openFileDialog_SelectMusic.FileName = "openFileDialog1";
            // 
            // AlarmSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 531);
            this.Controls.Add(this.groupBox1);
            this.Name = "AlarmSetting";
            this.Text = "报警设置";
            this.groupBox1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox listBox_Attribute;
        private System.Windows.Forms.ListBox listBox_Table;
        private System.Windows.Forms.Button button_DeleteAll;
        private System.Windows.Forms.Button button_Delete;
        private System.Windows.Forms.Button button_SelectAll;
        private System.Windows.Forms.Button button_Select;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button_TryAlarmMusic;
        private System.Windows.Forms.RadioButton radioButton_CustomAlarm;
        private System.Windows.Forms.RadioButton radioButton_DefeaultAlarm;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.OpenFileDialog openFileDialog_SelectMusic;
        private System.Windows.Forms.Button button_SelectMusic;
        private System.Windows.Forms.CheckBox checkBox_OutAlarm;
        private System.Windows.Forms.CheckBox checkBox_logRecord;
        private System.Windows.Forms.CheckBox checkBox_TextAlarm;
        private System.Windows.Forms.CheckBox checkBox_FlashAlarm;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button_WorkingCondition;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label1;
    }
}