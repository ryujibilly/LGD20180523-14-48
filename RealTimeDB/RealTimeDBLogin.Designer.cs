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
            this.textBox_open_dbpathwell = new System.Windows.Forms.TextBox();
            this.button_OpenDBFile = new System.Windows.Forms.Button();
            this.tabControl_OpenorCreate = new System.Windows.Forms.TabControl();
            this.tabPage_ModDB = new System.Windows.Forms.TabPage();
            this.button_OpenModDB = new System.Windows.Forms.Button();
            this.textBox_StaticDBPath = new System.Windows.Forms.TextBox();
            this.tabPage_OpenDB = new System.Windows.Forms.TabPage();
            this.textBox_open_wells = new System.Windows.Forms.TextBox();
            this.textBox_open_wellname = new System.Windows.Forms.TextBox();
            this.textBox_open_wellid = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage_NewDB = new System.Windows.Forms.TabPage();
            this.textBox_new_welltime = new System.Windows.Forms.TextBox();
            this.textBox_new_wellname = new System.Windows.Forms.TextBox();
            this.textBox_new_wellid = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button_NewDB = new System.Windows.Forms.Button();
            this.textBox_NewDBPath = new System.Windows.Forms.TextBox();
            this.openFileDialog_OpenDB = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog_ModDB = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog_NewProject = new System.Windows.Forms.FolderBrowserDialog();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.tabControl_OpenorCreate.SuspendLayout();
            this.tabPage_ModDB.SuspendLayout();
            this.tabPage_OpenDB.SuspendLayout();
            this.tabPage_NewDB.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_open_dbpathwell
            // 
            this.textBox_open_dbpathwell.Enabled = false;
            this.textBox_open_dbpathwell.Location = new System.Drawing.Point(8, 53);
            this.textBox_open_dbpathwell.Margin = new System.Windows.Forms.Padding(5);
            this.textBox_open_dbpathwell.Name = "textBox_open_dbpathwell";
            this.textBox_open_dbpathwell.Size = new System.Drawing.Size(399, 29);
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
            this.tabControl_OpenorCreate.Controls.Add(this.tabPage_ModDB);
            this.tabControl_OpenorCreate.Controls.Add(this.tabPage_NewDB);
            this.tabControl_OpenorCreate.Controls.Add(this.tabPage_OpenDB);
            this.tabControl_OpenorCreate.Location = new System.Drawing.Point(12, 12);
            this.tabControl_OpenorCreate.Name = "tabControl_OpenorCreate";
            this.tabControl_OpenorCreate.SelectedIndex = 0;
            this.tabControl_OpenorCreate.Size = new System.Drawing.Size(429, 314);
            this.tabControl_OpenorCreate.TabIndex = 3;
            // 
            // tabPage_ModDB
            // 
            this.tabPage_ModDB.Controls.Add(this.button_OpenModDB);
            this.tabPage_ModDB.Controls.Add(this.textBox_StaticDBPath);
            this.tabPage_ModDB.Location = new System.Drawing.Point(4, 30);
            this.tabPage_ModDB.Name = "tabPage_ModDB";
            this.tabPage_ModDB.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_ModDB.Size = new System.Drawing.Size(421, 280);
            this.tabPage_ModDB.TabIndex = 2;
            this.tabPage_ModDB.Text = "选择工区根目录";
            this.tabPage_ModDB.UseVisualStyleBackColor = true;
            // 
            // button_OpenModDB
            // 
            this.button_OpenModDB.Location = new System.Drawing.Point(8, 8);
            this.button_OpenModDB.Margin = new System.Windows.Forms.Padding(5);
            this.button_OpenModDB.Name = "button_OpenModDB";
            this.button_OpenModDB.Size = new System.Drawing.Size(155, 29);
            this.button_OpenModDB.TabIndex = 4;
            this.button_OpenModDB.Text = "根目录及模板库";
            this.button_OpenModDB.UseVisualStyleBackColor = true;
            this.button_OpenModDB.Click += new System.EventHandler(this.button_OpenModDB_Click);
            // 
            // textBox_StaticDBPath
            // 
            this.textBox_StaticDBPath.Enabled = false;
            this.textBox_StaticDBPath.Location = new System.Drawing.Point(8, 47);
            this.textBox_StaticDBPath.Margin = new System.Windows.Forms.Padding(5);
            this.textBox_StaticDBPath.Name = "textBox_StaticDBPath";
            this.textBox_StaticDBPath.Size = new System.Drawing.Size(405, 29);
            this.textBox_StaticDBPath.TabIndex = 3;
            // 
            // tabPage_OpenDB
            // 
            this.tabPage_OpenDB.Controls.Add(this.textBox_open_wells);
            this.tabPage_OpenDB.Controls.Add(this.textBox_open_wellname);
            this.tabPage_OpenDB.Controls.Add(this.textBox_open_wellid);
            this.tabPage_OpenDB.Controls.Add(this.label3);
            this.tabPage_OpenDB.Controls.Add(this.label2);
            this.tabPage_OpenDB.Controls.Add(this.label1);
            this.tabPage_OpenDB.Controls.Add(this.button_OpenDBFile);
            this.tabPage_OpenDB.Controls.Add(this.textBox_open_dbpathwell);
            this.tabPage_OpenDB.Location = new System.Drawing.Point(4, 30);
            this.tabPage_OpenDB.Name = "tabPage_OpenDB";
            this.tabPage_OpenDB.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_OpenDB.Size = new System.Drawing.Size(421, 280);
            this.tabPage_OpenDB.TabIndex = 0;
            this.tabPage_OpenDB.Text = "打开数据库";
            this.tabPage_OpenDB.UseVisualStyleBackColor = true;
            // 
            // textBox_open_wells
            // 
            this.textBox_open_wells.Enabled = false;
            this.textBox_open_wells.Location = new System.Drawing.Point(71, 229);
            this.textBox_open_wells.Name = "textBox_open_wells";
            this.textBox_open_wells.Size = new System.Drawing.Size(336, 29);
            this.textBox_open_wells.TabIndex = 8;
            // 
            // textBox_open_wellname
            // 
            this.textBox_open_wellname.Enabled = false;
            this.textBox_open_wellname.Location = new System.Drawing.Point(71, 169);
            this.textBox_open_wellname.Name = "textBox_open_wellname";
            this.textBox_open_wellname.Size = new System.Drawing.Size(336, 29);
            this.textBox_open_wellname.TabIndex = 7;
            // 
            // textBox_open_wellid
            // 
            this.textBox_open_wellid.Enabled = false;
            this.textBox_open_wellid.Location = new System.Drawing.Point(71, 109);
            this.textBox_open_wellid.Name = "textBox_open_wellid";
            this.textBox_open_wellid.Size = new System.Drawing.Size(336, 29);
            this.textBox_open_wellid.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 232);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 21);
            this.label3.TabIndex = 5;
            this.label3.Text = "井次";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 172);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 21);
            this.label2.TabIndex = 4;
            this.label2.Text = "井名";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 21);
            this.label1.TabIndex = 3;
            this.label1.Text = "井号";
            // 
            // tabPage_NewDB
            // 
            this.tabPage_NewDB.Controls.Add(this.textBox_new_welltime);
            this.tabPage_NewDB.Controls.Add(this.textBox_new_wellname);
            this.tabPage_NewDB.Controls.Add(this.textBox_new_wellid);
            this.tabPage_NewDB.Controls.Add(this.label4);
            this.tabPage_NewDB.Controls.Add(this.label5);
            this.tabPage_NewDB.Controls.Add(this.label6);
            this.tabPage_NewDB.Controls.Add(this.button_NewDB);
            this.tabPage_NewDB.Controls.Add(this.textBox_NewDBPath);
            this.tabPage_NewDB.Location = new System.Drawing.Point(4, 30);
            this.tabPage_NewDB.Name = "tabPage_NewDB";
            this.tabPage_NewDB.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_NewDB.Size = new System.Drawing.Size(421, 280);
            this.tabPage_NewDB.TabIndex = 1;
            this.tabPage_NewDB.Text = "新建工区";
            this.tabPage_NewDB.UseVisualStyleBackColor = true;
            // 
            // textBox_new_welltime
            // 
            this.textBox_new_welltime.Enabled = false;
            this.textBox_new_welltime.Location = new System.Drawing.Point(71, 229);
            this.textBox_new_welltime.Name = "textBox_new_welltime";
            this.textBox_new_welltime.Size = new System.Drawing.Size(336, 29);
            this.textBox_new_welltime.TabIndex = 16;
            // 
            // textBox_new_wellname
            // 
            this.textBox_new_wellname.Enabled = false;
            this.textBox_new_wellname.Location = new System.Drawing.Point(71, 169);
            this.textBox_new_wellname.Name = "textBox_new_wellname";
            this.textBox_new_wellname.Size = new System.Drawing.Size(336, 29);
            this.textBox_new_wellname.TabIndex = 15;
            // 
            // textBox_new_wellid
            // 
            this.textBox_new_wellid.Enabled = false;
            this.textBox_new_wellid.Location = new System.Drawing.Point(71, 109);
            this.textBox_new_wellid.Name = "textBox_new_wellid";
            this.textBox_new_wellid.Size = new System.Drawing.Size(336, 29);
            this.textBox_new_wellid.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 232);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 21);
            this.label4.TabIndex = 13;
            this.label4.Text = "井次";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 172);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 21);
            this.label5.TabIndex = 12;
            this.label5.Text = "井名";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 112);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 21);
            this.label6.TabIndex = 11;
            this.label6.Text = "井号";
            // 
            // button_NewDB
            // 
            this.button_NewDB.Location = new System.Drawing.Point(8, 8);
            this.button_NewDB.Margin = new System.Windows.Forms.Padding(5);
            this.button_NewDB.Name = "button_NewDB";
            this.button_NewDB.Size = new System.Drawing.Size(141, 29);
            this.button_NewDB.TabIndex = 10;
            this.button_NewDB.Text = "新工区目录";
            this.button_NewDB.UseVisualStyleBackColor = true;
            this.button_NewDB.Click += new System.EventHandler(this.button_NewDB_Click);
            // 
            // textBox_NewDBPath
            // 
            this.textBox_NewDBPath.Enabled = false;
            this.textBox_NewDBPath.Location = new System.Drawing.Point(8, 53);
            this.textBox_NewDBPath.Margin = new System.Windows.Forms.Padding(5);
            this.textBox_NewDBPath.Name = "textBox_NewDBPath";
            this.textBox_NewDBPath.Size = new System.Drawing.Size(399, 29);
            this.textBox_NewDBPath.TabIndex = 9;
            // 
            // openFileDialog_OpenDB
            // 
            this.openFileDialog_OpenDB.DefaultExt = "*.db";
            this.openFileDialog_OpenDB.FileName = global::RealTimeDB.Properties.Settings.Default.DBPath_Well;
            this.openFileDialog_OpenDB.Filter = "数据库文件(*.db)|*.db|SQLite2(*.db2)|*.db2|SQLite3(*.db3)|*.db3|所有文件(*.*)|*.*";
            this.openFileDialog_OpenDB.RestoreDirectory = true;
            this.openFileDialog_OpenDB.Title = "选择实时数据库SQLite文件";
            // 
            // openFileDialog_ModDB
            // 
            this.openFileDialog_ModDB.DefaultExt = "*.db";
            this.openFileDialog_ModDB.Filter = "数据库文件(*.db)|*.db|SQLite2(*.db2)|*.db2|SQLite3(*.db3)|*.db3|所有文件(*.*)|*.*";
            this.openFileDialog_ModDB.Title = "选择模板数据库SQLite文件";
            // 
            // folderBrowserDialog_NewProject
            // 
            this.folderBrowserDialog_NewProject.Description = "选择新工区的根目录，用于创建模板数据库的拷贝";
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(447, 13);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(241, 313);
            this.treeView1.TabIndex = 4;
            // 
            // RealTimeDBLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 333);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.tabControl_OpenorCreate);
            this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "RealTimeDBLogin";
            this.Text = "数据库及工区配置";
            this.Load += new System.EventHandler(this.RealTimeDBLogin_Load);
            this.tabControl_OpenorCreate.ResumeLayout(false);
            this.tabPage_ModDB.ResumeLayout(false);
            this.tabPage_ModDB.PerformLayout();
            this.tabPage_OpenDB.ResumeLayout(false);
            this.tabPage_OpenDB.PerformLayout();
            this.tabPage_NewDB.ResumeLayout(false);
            this.tabPage_NewDB.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_open_dbpathwell;
        private System.Windows.Forms.Button button_OpenDBFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog_OpenDB;
        private System.Windows.Forms.TabControl tabControl_OpenorCreate;
        private System.Windows.Forms.TabPage tabPage_OpenDB;
        private System.Windows.Forms.TabPage tabPage_NewDB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_open_wells;
        private System.Windows.Forms.TextBox textBox_open_wellname;
        private System.Windows.Forms.TextBox textBox_open_wellid;
        private System.Windows.Forms.TabPage tabPage_ModDB;
        private System.Windows.Forms.Button button_OpenModDB;
        private System.Windows.Forms.TextBox textBox_StaticDBPath;
        private System.Windows.Forms.OpenFileDialog openFileDialog_ModDB;
        private System.Windows.Forms.TextBox textBox_new_welltime;
        private System.Windows.Forms.TextBox textBox_new_wellname;
        private System.Windows.Forms.TextBox textBox_new_wellid;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button_NewDB;
        private System.Windows.Forms.TextBox textBox_NewDBPath;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog_NewProject;
        private System.Windows.Forms.TreeView treeView1;
    }
}