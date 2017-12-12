using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RealTimeDB
{
    public partial class AddItem : Form
    {
        private String itemName;
        /// <summary>
        /// 添加项名称
        /// </summary>
        public string ItemName
        {
            get
            {
                return itemName;
            }

            set
            {
                itemName = value;
            }
        }

        public AddItem()
        {
            InitializeComponent();
        }
        public AddItem(String labtext,String formtext)
        {
            InitializeComponent();
            this.label_Name.Text = labtext;
            this.Text = formtext;

        }



        private void AddItem_Load(object sender, EventArgs e)
        {

        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            ItemName = this.textBox1.Text;
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            ItemName = String.Empty;
        }
    }
}
