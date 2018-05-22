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
    public partial class AdvancedOption : Form
    {

        private int interval = 30;
        private int repeat = 3;
        private int fps = 100;
        private bool isHold = false;
        /// <summary>
        /// 推送间隔
        /// </summary>
        public int Interval
        {
            get
            {
                return interval;
            }

            set
            {
                interval = value;
            }
        }
        /// <summary>
        /// 重复次数
        /// </summary>
        public int Repeat
        {
            get
            {
                return repeat;
            }

            set
            {
                repeat = value;
            }
        }
        /// <summary>
        /// 推送帧数
        /// </summary>
        public int Fps
        {
            get
            {
                return fps;
            }

            set
            {
                fps = value;
            }
        }
        /// <summary>
        /// 保持工作
        /// </summary>
        public bool IsHold
        {
            get
            {
                return isHold;
            }

            set
            {
                isHold = value;
            }
        }

        public AdvancedOption()
        {
            InitializeComponent();
        }

        private void AdvancedOption_Load(object sender, EventArgs e)
        {
            this.numericUpDown_Interval.Value = Properties.Settings.Default.Interval;
            this.numericUpDown_Repeat.Value = Properties.Settings.Default.Repeat;
            this.numericUpDown_Fps.Value = Properties.Settings.Default.FPS;
        }

        private void numericUpDown_Interval_ValueChanged(object sender, EventArgs e)
        {
            Interval = (int)numericUpDown_Interval.Value;
            Properties.Settings.Default.Interval= this.numericUpDown_Interval.Value;
        }

        private void numericUpDown_Repeat_ValueChanged(object sender, EventArgs e)
        {
            Repeat = (int)numericUpDown_Repeat.Value;
            Properties.Settings.Default.Repeat= this.numericUpDown_Repeat.Value;
        }

        private void numericUpDown_Fps_ValueChanged(object sender, EventArgs e)
        {
            Fps = (int)numericUpDown_Fps.Value;
            Properties.Settings.Default.FPS= this.numericUpDown_Fps.Value ;
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Interval = (int)numericUpDown_Interval.Value;
            Repeat = (int)numericUpDown_Repeat.Value;
            Fps = (int)numericUpDown_Fps.Value;
            this.Close();
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void checkBox_hold_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_hold.Checked)
                IsHold = true;
            else if (!checkBox_hold.Checked)
                IsHold = false;
        }
    }
}
