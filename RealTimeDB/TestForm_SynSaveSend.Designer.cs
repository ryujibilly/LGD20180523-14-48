namespace RealTimeDB
{
    partial class TestForm_SynSaveSend
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
            this.button_Save = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // button_Save
            // 
            this.button_Save.Location = new System.Drawing.Point(32, 25);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(114, 30);
            this.button_Save.TabIndex = 0;
            this.button_Save.Text = "存储";
            this.button_Save.UseVisualStyleBackColor = true;
            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // TestForm_SynSaveSend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 96);
            this.Controls.Add(this.button_Save);
            this.Name = "TestForm_SynSaveSend";
            this.Text = "同步测试";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_Save;
        private System.Windows.Forms.Timer timer1;
    }
}