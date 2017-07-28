namespace RealTimeDB
{
    partial class RealTimeDBLogin
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("工区1");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("工区2");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("工区3");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("工区目录", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3});
            this.textBox_open_dbpathwell = new System.Windows.Forms.TextBox();
            this.button_OpenDBFile = new System.Windows.Forms.Button();
            this.tabControl_OpenorCreate = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.textBox_open_wells = new System.Windows.Forms.TextBox();
            this.textBox_open_wellname = new System.Windows.Forms.TextBox();
            this.textBox_open_wellid = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tabControl_OpenorCreate.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_open_dbpathwell
            // 
            this.textBox_open_dbpathwell.Enabled = false;
            this.textBox_open_dbpathwell.Location = new System.Drawing.Point(159, 9);
            this.textBox_open_dbpathwell.Margin = new System.Windows.Forms.Padding(5);
            this.textBox_open_dbpathwell.Name = "textBox_open_dbpathwell";
            this.textBox_open_dbpathwell.Size = new System.Drawing.Size(379, 29);
            this.textBox_open_dbpathwell.TabIndex = 1;
            // 
            // button_OpenDBFile
            // 
            this.button_OpenDBFile.Location = new System.Drawing.Point(8, 8);
            this.button_OpenDBFile.Margin = new System.Windows.Forms.Padding(5);
            this.button_OpenDBFile.Name = "button_OpenDBFile";
            this.button_OpenDBFile.Size = new System.Drawing.Size(141, 29);
            this.button_OpenDBFile.TabIndex = 2;
            this.button_OpenDBFile.Text = "打开数据库文件";
            this.button_OpenDBFile.UseVisualStyleBackColor = true;
            this.button_OpenDBFile.Click += new System.EventHandler(this.button_OpenDBFile_Click);
            // 
            // tabControl_OpenorCreate
            // 
            this.tabControl_OpenorCreate.Controls.Add(this.tabPage1);
            this.tabControl_OpenorCreate.Controls.Add(this.tabPage2);
            this.tabControl_OpenorCreate.Location = new System.Drawing.Point(170, 13);
            this.tabControl_OpenorCreate.Name = "tabControl_OpenorCreate";
            this.tabControl_OpenorCreate.SelectedIndex = 0;
            this.tabControl_OpenorCreate.Size = new System.Drawing.Size(554, 298);
            this.tabControl_OpenorCreate.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.textBox_open_wells);
            this.tabPage1.Controls.Add(this.textBox_open_wellname);
            this.tabPage1.Controls.Add(this.textBox_open_wellid);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.button_OpenDBFile);
            this.tabPage1.Controls.Add(this.textBox_open_dbpathwell);
            this.tabPage1.Location = new System.Drawing.Point(4, 30);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(546, 264);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "打开数据库";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // textBox_open_wells
            // 
            this.textBox_open_wells.Enabled = false;
            this.textBox_open_wells.Location = new System.Drawing.Point(98, 208);
            this.textBox_open_wells.Name = "textBox_open_wells";
            this.textBox_open_wells.Size = new System.Drawing.Size(336, 29);
            this.textBox_open_wells.TabIndex = 8;
            // 
            // textBox_open_wellname
            // 
            this.textBox_open_wellname.Enabled = false;
            this.textBox_open_wellname.Location = new System.Drawing.Point(98, 133);
            this.textBox_open_wellname.Name = "textBox_open_wellname";
            this.textBox_open_wellname.Size = new System.Drawing.Size(336, 29);
            this.textBox_open_wellname.TabIndex = 7;
            // 
            // textBox_open_wellid
            // 
            this.textBox_open_wellid.Enabled = false;
            this.textBox_open_wellid.Location = new System.Drawing.Point(98, 61);
            this.textBox_open_wellid.Name = "textBox_open_wellid";
            this.textBox_open_wellid.Size = new System.Drawing.Size(336, 29);
            this.textBox_open_wellid.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 211);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 21);
            this.label3.TabIndex = 5;
            this.label3.Text = "井次";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 21);
            this.label2.TabIndex = 4;
            this.label2.Text = "井名";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 21);
            this.label1.TabIndex = 3;
            this.label1.Text = "井号";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 30);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(546, 264);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "新建数据库";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(13, 13);
            this.treeView1.Margin = new System.Windows.Forms.Padding(4);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "workplace1";
            treeNode1.Text = "工区1";
            treeNode2.Name = "workplace2";
            treeNode2.Text = "工区2";
            treeNode3.Name = "workplace3";
            treeNode3.Text = "工区3";
            treeNode4.Name = "rootNode";
            treeNode4.Text = "工区目录";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode4});
            this.treeView1.Size = new System.Drawing.Size(150, 298);
            this.treeView1.TabIndex = 4;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "*.db";
            this.openFileDialog1.FileName = global::RealTimeDB.Properties.Settings.Default.DBPath_Well;
            this.openFileDialog1.Filter = "数据库文件(*.db)|*.db|SQLite2(*.db2)|*.db2|SQLite3(*.db3)|*.db3|所有文件(*.*)|*.*";
            this.openFileDialog1.RestoreDirectory = true;
            this.openFileDialog1.Title = "选择实时数据库SQLite文件";
            // 
            // RealTimeDBLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 324);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.tabControl_OpenorCreate);
            this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "RealTimeDBLogin";
            this.Text = "数据库配置";
            this.tabControl_OpenorCreate.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_open_dbpathwell;
        private System.Windows.Forms.Button button_OpenDBFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TabControl tabControl_OpenorCreate;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_open_wells;
        private System.Windows.Forms.TextBox textBox_open_wellname;
        private System.Windows.Forms.TextBox textBox_open_wellid;
    }
}