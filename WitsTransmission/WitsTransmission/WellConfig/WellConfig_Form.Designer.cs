namespace WitsTransmission.WellConfig
{
    partial class WellConfig_Form
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
            this.wellConfig_groupBox = new System.Windows.Forms.GroupBox();
            this.currentPath_label = new System.Windows.Forms.Label();
            this.wellConfig_treeView = new System.Windows.Forms.TreeView();
            this.getWellMessage_button = new System.Windows.Forms.Button();
            this.finishConfig_button = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.currentPath_textBox = new System.Windows.Forms.TextBox();
            this.wellConfig_groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // wellConfig_groupBox
            // 
            this.wellConfig_groupBox.Controls.Add(this.currentPath_textBox);
            this.wellConfig_groupBox.Controls.Add(this.currentPath_label);
            this.wellConfig_groupBox.Controls.Add(this.wellConfig_treeView);
            this.wellConfig_groupBox.Location = new System.Drawing.Point(12, 12);
            this.wellConfig_groupBox.Name = "wellConfig_groupBox";
            this.wellConfig_groupBox.Size = new System.Drawing.Size(496, 308);
            this.wellConfig_groupBox.TabIndex = 0;
            this.wellConfig_groupBox.TabStop = false;
            // 
            // currentPath_label
            // 
            this.currentPath_label.AutoSize = true;
            this.currentPath_label.Location = new System.Drawing.Point(22, 23);
            this.currentPath_label.Name = "currentPath_label";
            this.currentPath_label.Size = new System.Drawing.Size(65, 12);
            this.currentPath_label.TabIndex = 1;
            this.currentPath_label.Text = "当前路径：";
            // 
            // wellConfig_treeView
            // 
            this.wellConfig_treeView.Location = new System.Drawing.Point(20, 56);
            this.wellConfig_treeView.Name = "wellConfig_treeView";
            this.wellConfig_treeView.Size = new System.Drawing.Size(453, 236);
            this.wellConfig_treeView.TabIndex = 0;
            this.wellConfig_treeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.wellConfig_treeView_AfterSelect);
            this.wellConfig_treeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.wellConfig_treeView_NodeMouseClick);
            // 
            // getWellMessage_button
            // 
            this.getWellMessage_button.Location = new System.Drawing.Point(116, 331);
            this.getWellMessage_button.Name = "getWellMessage_button";
            this.getWellMessage_button.Size = new System.Drawing.Size(75, 23);
            this.getWellMessage_button.TabIndex = 1;
            this.getWellMessage_button.Text = "获取信息";
            this.getWellMessage_button.UseVisualStyleBackColor = true;
            this.getWellMessage_button.Click += new System.EventHandler(this.getWellMessage_button_Click);
            // 
            // finishConfig_button
            // 
            this.finishConfig_button.Location = new System.Drawing.Point(294, 331);
            this.finishConfig_button.Name = "finishConfig_button";
            this.finishConfig_button.Size = new System.Drawing.Size(75, 23);
            this.finishConfig_button.TabIndex = 2;
            this.finishConfig_button.Text = "完成";
            this.finishConfig_button.UseVisualStyleBackColor = true;
            this.finishConfig_button.Click += new System.EventHandler(this.finishConfig_button_Click);
            // 
            // currentPath_textBox
            // 
            this.currentPath_textBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::WitsTransmission.Properties.Settings.Default, "m_strWellcountPath", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.currentPath_textBox.Location = new System.Drawing.Point(92, 20);
            this.currentPath_textBox.Name = "currentPath_textBox";
            this.currentPath_textBox.Size = new System.Drawing.Size(381, 21);
            this.currentPath_textBox.TabIndex = 2;
            this.currentPath_textBox.Text = global::WitsTransmission.Properties.Settings.Default.m_strWellcountPath;
            // 
            // WellConfig_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 366);
            this.Controls.Add(this.finishConfig_button);
            this.Controls.Add(this.getWellMessage_button);
            this.Controls.Add(this.wellConfig_groupBox);
            this.Name = "WellConfig_Form";
            this.Text = "配置井信息";
            this.Load += new System.EventHandler(this.WellConfig_Form_Load);
            this.wellConfig_groupBox.ResumeLayout(false);
            this.wellConfig_groupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox wellConfig_groupBox;
        private System.Windows.Forms.TreeView wellConfig_treeView;
        private System.Windows.Forms.Button getWellMessage_button;
        private System.Windows.Forms.Button finishConfig_button;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox currentPath_textBox;
        private System.Windows.Forms.Label currentPath_label;
    }
}