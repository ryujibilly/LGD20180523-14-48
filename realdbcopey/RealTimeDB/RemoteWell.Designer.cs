namespace RealTimeDB
{
    partial class RemoteWell
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
            this.components = new System.ComponentModel.Container();
            this.treeView_remoteWell = new System.Windows.Forms.TreeView();
            this.button_Ok = new System.Windows.Forms.Button();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenuStrip_Region = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuStrip_Well = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuStrip_Log = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.AddRegion_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddWell_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddLog_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip_Region.SuspendLayout();
            this.contextMenuStrip_Well.SuspendLayout();
            this.contextMenuStrip_Log.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView_remoteWell
            // 
            this.treeView_remoteWell.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.treeView_remoteWell.Location = new System.Drawing.Point(13, 33);
            this.treeView_remoteWell.Margin = new System.Windows.Forms.Padding(4);
            this.treeView_remoteWell.Name = "treeView_remoteWell";
            this.treeView_remoteWell.Size = new System.Drawing.Size(568, 384);
            this.treeView_remoteWell.TabIndex = 0;
            this.treeView_remoteWell.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_remoteWell_AfterSelect);
            this.treeView_remoteWell.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView_remoteWell_NodeMouseClick);
            // 
            // button_Ok
            // 
            this.button_Ok.Location = new System.Drawing.Point(81, 427);
            this.button_Ok.Margin = new System.Windows.Forms.Padding(4);
            this.button_Ok.Name = "button_Ok";
            this.button_Ok.Size = new System.Drawing.Size(134, 41);
            this.button_Ok.TabIndex = 1;
            this.button_Ok.Text = "确 定";
            this.button_Ok.UseVisualStyleBackColor = true;
            this.button_Ok.Click += new System.EventHandler(this.button_Ok_Click);
            // 
            // button_Cancel
            // 
            this.button_Cancel.Location = new System.Drawing.Point(351, 427);
            this.button_Cancel.Margin = new System.Windows.Forms.Padding(4);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(134, 41);
            this.button_Cancel.TabIndex = 2;
            this.button_Cancel.Text = "取 消";
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "选择远程井次";
            // 
            // contextMenuStrip_Region
            // 
            this.contextMenuStrip_Region.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddRegion_ToolStripMenuItem});
            this.contextMenuStrip_Region.Name = "contextMenuStrip_Region";
            this.contextMenuStrip_Region.Size = new System.Drawing.Size(125, 26);
            this.contextMenuStrip_Region.Text = "工区操作";
            // 
            // contextMenuStrip_Well
            // 
            this.contextMenuStrip_Well.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddWell_ToolStripMenuItem});
            this.contextMenuStrip_Well.Name = "contextMenuStrip_Well";
            this.contextMenuStrip_Well.Size = new System.Drawing.Size(113, 26);
            this.contextMenuStrip_Well.Text = "井操作";
            // 
            // contextMenuStrip_Log
            // 
            this.contextMenuStrip_Log.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddLog_ToolStripMenuItem});
            this.contextMenuStrip_Log.Name = "contextMenuStrip_Log";
            this.contextMenuStrip_Log.Size = new System.Drawing.Size(125, 26);
            this.contextMenuStrip_Log.Text = "井次操作";
            // 
            // AddRegion_ToolStripMenuItem
            // 
            this.AddRegion_ToolStripMenuItem.Name = "AddRegion_ToolStripMenuItem";
            this.AddRegion_ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.AddRegion_ToolStripMenuItem.Text = "添加工区";
            this.AddRegion_ToolStripMenuItem.Click += new System.EventHandler(this.AddRegion_ToolStripMenuItem_Click);
            // 
            // AddWell_ToolStripMenuItem
            // 
            this.AddWell_ToolStripMenuItem.Name = "AddWell_ToolStripMenuItem";
            this.AddWell_ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.AddWell_ToolStripMenuItem.Text = "添加井";
            this.AddWell_ToolStripMenuItem.Click += new System.EventHandler(this.AddWell_ToolStripMenuItem_Click);
            // 
            // AddLog_ToolStripMenuItem
            // 
            this.AddLog_ToolStripMenuItem.Name = "AddLog_ToolStripMenuItem";
            this.AddLog_ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.AddLog_ToolStripMenuItem.Text = "添加井次";
            this.AddLog_ToolStripMenuItem.Click += new System.EventHandler(this.AddLog_ToolStripMenuItem_Click);
            // 
            // RemoteWell
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 484);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_Ok);
            this.Controls.Add(this.treeView_remoteWell);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "RemoteWell";
            this.Text = "远 程 井 次";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Load += new System.EventHandler(this.RemoteWell_Load);
            this.contextMenuStrip_Region.ResumeLayout(false);
            this.contextMenuStrip_Well.ResumeLayout(false);
            this.contextMenuStrip_Log.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView_remoteWell;
        private System.Windows.Forms.Button button_Ok;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_Region;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_Well;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_Log;
        private System.Windows.Forms.ToolStripMenuItem AddRegion_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddWell_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddLog_ToolStripMenuItem;
    }
}