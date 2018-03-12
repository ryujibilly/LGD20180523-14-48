using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
using LGD.DAL.SQLite;
using System.Threading;

namespace RealTimeDB
{
    public partial class TestForm_SynSaveSend : Form
    {
        public static SQLiteDBHelper realhelper = new SQLiteDBHelper();
        public TestForm_SynSaveSend()
        {
            InitializeComponent();
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            realhelper = new SQLiteDBHelper(Properties.Settings.Default.RealDBPath);
        }
        Thread saveThread = new Thread(new ThreadStart(saveData()));

        private static ThreadStart saveData()
        {
            throw new NotImplementedException();
        }
    }
}
