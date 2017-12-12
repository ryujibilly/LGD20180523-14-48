namespace WitsTransmission
{
    partial class Main_Form
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.File_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wellConfig_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.WitsReceive_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RecConfig_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.WitsSend_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendConfigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_receiveWitsData_dataSet = new System.Data.DataSet();
            this.receiveWitsDataView_groupBox = new System.Windows.Forms.GroupBox();
            this.receiveWitsData_dataGridView = new System.Windows.Forms.DataGridView();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_receiveWitsData_dataSet)).BeginInit();
            this.receiveWitsDataView_groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.receiveWitsData_dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.File_ToolStripMenuItem,
            this.WitsReceive_ToolStripMenuItem,
            this.WitsSend_ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(617, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.TabStop = true;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // File_ToolStripMenuItem
            // 
            this.File_ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wellConfig_ToolStripMenuItem});
            this.File_ToolStripMenuItem.Name = "File_ToolStripMenuItem";
            this.File_ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F)));
            this.File_ToolStripMenuItem.Size = new System.Drawing.Size(53, 21);
            this.File_ToolStripMenuItem.Text = "File(F)";
            // 
            // wellConfig_ToolStripMenuItem
            // 
            this.wellConfig_ToolStripMenuItem.Name = "wellConfig_ToolStripMenuItem";
            this.wellConfig_ToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.wellConfig_ToolStripMenuItem.Text = "WellConfig";
            this.wellConfig_ToolStripMenuItem.Click += new System.EventHandler(this.wellConfig_ToolStripMenuItem_Click);
            // 
            // WitsReceive_ToolStripMenuItem
            // 
            this.WitsReceive_ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RecConfig_ToolStripMenuItem});
            this.WitsReceive_ToolStripMenuItem.Name = "WitsReceive_ToolStripMenuItem";
            this.WitsReceive_ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.R)));
            this.WitsReceive_ToolStripMenuItem.Size = new System.Drawing.Size(105, 21);
            this.WitsReceive_ToolStripMenuItem.Text = "WitsReceive(R)";
            // 
            // RecConfig_ToolStripMenuItem
            // 
            this.RecConfig_ToolStripMenuItem.Name = "RecConfig_ToolStripMenuItem";
            this.RecConfig_ToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.RecConfig_ToolStripMenuItem.Text = "RecConfig";
            this.RecConfig_ToolStripMenuItem.Click += new System.EventHandler(this.recConfigToolStripMenuItem_Click);
            // 
            // WitsSend_ToolStripMenuItem
            // 
            this.WitsSend_ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sendConfigToolStripMenuItem});
            this.WitsSend_ToolStripMenuItem.Name = "WitsSend_ToolStripMenuItem";
            this.WitsSend_ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.S)));
            this.WitsSend_ToolStripMenuItem.Size = new System.Drawing.Size(89, 21);
            this.WitsSend_ToolStripMenuItem.Text = "WitsSend(S)";
            // 
            // sendConfigToolStripMenuItem
            // 
            this.sendConfigToolStripMenuItem.Name = "sendConfigToolStripMenuItem";
            this.sendConfigToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.sendConfigToolStripMenuItem.Text = "SendConfig";
            this.sendConfigToolStripMenuItem.Click += new System.EventHandler(this.sendConfigToolStripMenuItem_Click);
            // 
            // m_receiveWitsData_dataSet
            // 
            this.m_receiveWitsData_dataSet.DataSetName = "NewDataSet";
            // 
            // receiveWitsDataView_groupBox
            // 
            this.receiveWitsDataView_groupBox.Controls.Add(this.receiveWitsData_dataGridView);
            this.receiveWitsDataView_groupBox.Location = new System.Drawing.Point(26, 44);
            this.receiveWitsDataView_groupBox.Name = "receiveWitsDataView_groupBox";
            this.receiveWitsDataView_groupBox.Size = new System.Drawing.Size(567, 481);
            this.receiveWitsDataView_groupBox.TabIndex = 1;
            this.receiveWitsDataView_groupBox.TabStop = false;
            // 
            // receiveWitsData_dataGridView
            // 
            this.receiveWitsData_dataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.receiveWitsData_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.receiveWitsData_dataGridView.GridColor = System.Drawing.SystemColors.Control;
            this.receiveWitsData_dataGridView.Location = new System.Drawing.Point(17, 20);
            this.receiveWitsData_dataGridView.MultiSelect = false;
            this.receiveWitsData_dataGridView.Name = "receiveWitsData_dataGridView";
            this.receiveWitsData_dataGridView.ReadOnly = true;
            this.receiveWitsData_dataGridView.RowTemplate.Height = 23;
            this.receiveWitsData_dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.receiveWitsData_dataGridView.Size = new System.Drawing.Size(532, 443);
            this.receiveWitsData_dataGridView.TabIndex = 0;
            this.receiveWitsData_dataGridView.TabStop = false;
            this.receiveWitsData_dataGridView.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.receiveWitsData_dataGridView_RowsAdded);
            this.receiveWitsData_dataGridView.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.receiveWitsData_dataGridView_RowsRemoved);
            // 
            // Main_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 537);
            this.Controls.Add(this.receiveWitsDataView_groupBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main_Form";
            this.Text = "WitsTransmission";
            this.Load += new System.EventHandler(this.Main_Form_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_receiveWitsData_dataSet)).EndInit();
            this.receiveWitsDataView_groupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.receiveWitsData_dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem File_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem WitsReceive_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem WitsSend_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RecConfig_ToolStripMenuItem;
        private System.Data.DataSet m_receiveWitsData_dataSet;
        private System.Windows.Forms.GroupBox receiveWitsDataView_groupBox;
        private System.Windows.Forms.DataGridView receiveWitsData_dataGridView;
        private System.Windows.Forms.ToolStripMenuItem wellConfig_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sendConfigToolStripMenuItem;
    }
}

