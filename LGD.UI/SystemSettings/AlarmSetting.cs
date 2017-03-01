using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LGD.UI.SystemSettings
{
    public partial class AlarmSetting : Form
    {
        public AlarmSetting()
        {
            InitializeComponent();
        }

        private void button_WorkingCondition_Click(object sender, EventArgs e)
        {
            WorkingCondition wc = new WorkingCondition();
            wc.ShowDialog();
        }
    }
}
