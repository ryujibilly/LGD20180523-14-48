namespace WitsTransmission.WitsSend
{
    partial class SendConfig_Form
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("TcpClient");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("TcpServer");
            this.tcpMode_groupBox = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tcpMode_treeView = new System.Windows.Forms.TreeView();
            this.DataDisplay_groupBox = new System.Windows.Forms.GroupBox();
            this.DataDisplay_tabControl = new System.Windows.Forms.TabControl();
            this.tcpMode_groupBox.SuspendLayout();
            this.DataDisplay_groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcpMode_groupBox
            // 
            this.tcpMode_groupBox.Controls.Add(this.label1);
            this.tcpMode_groupBox.Controls.Add(this.tcpMode_treeView);
            this.tcpMode_groupBox.Location = new System.Drawing.Point(12, 12);
            this.tcpMode_groupBox.Name = "tcpMode_groupBox";
            this.tcpMode_groupBox.Size = new System.Drawing.Size(184, 374);
            this.tcpMode_groupBox.TabIndex = 0;
            this.tcpMode_groupBox.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "模式：";
            // 
            // tcpMode_treeView
            // 
            this.tcpMode_treeView.Location = new System.Drawing.Point(6, 42);
            this.tcpMode_treeView.Name = "tcpMode_treeView";
            treeNode1.Name = "TcpClient";
            treeNode1.Text = "TcpClient";
            treeNode2.Name = "TcpServer";
            treeNode2.Text = "TcpServer";
            this.tcpMode_treeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            this.tcpMode_treeView.Size = new System.Drawing.Size(172, 314);
            this.tcpMode_treeView.TabIndex = 0;
            this.tcpMode_treeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tcpMode_treeView_AfterSelect);
            this.tcpMode_treeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tcpMode_treeView_NodeMouseClick);
            // 
            // DataDisplay_groupBox
            // 
            this.DataDisplay_groupBox.Controls.Add(this.DataDisplay_tabControl);
            this.DataDisplay_groupBox.Location = new System.Drawing.Point(215, 12);
            this.DataDisplay_groupBox.Name = "DataDisplay_groupBox";
            this.DataDisplay_groupBox.Size = new System.Drawing.Size(346, 374);
            this.DataDisplay_groupBox.TabIndex = 1;
            this.DataDisplay_groupBox.TabStop = false;
            // 
            // DataDisplay_tabControl
            // 
            this.DataDisplay_tabControl.Location = new System.Drawing.Point(24, 20);
            this.DataDisplay_tabControl.Name = "DataDisplay_tabControl";
            this.DataDisplay_tabControl.SelectedIndex = 0;
            this.DataDisplay_tabControl.Size = new System.Drawing.Size(305, 336);
            this.DataDisplay_tabControl.TabIndex = 0;
            // 
            // SendConfig_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 398);
            this.Controls.Add(this.DataDisplay_groupBox);
            this.Controls.Add(this.tcpMode_groupBox);
            this.Name = "SendConfig_Form";
            this.Text = "Wits发送配置";
            this.Load += new System.EventHandler(this.SendConfig_Form_Load);
            this.tcpMode_groupBox.ResumeLayout(false);
            this.tcpMode_groupBox.PerformLayout();
            this.DataDisplay_groupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox tcpMode_groupBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TreeView tcpMode_treeView;
        private System.Windows.Forms.GroupBox DataDisplay_groupBox;
        private System.Windows.Forms.TabControl DataDisplay_tabControl;
    }
}