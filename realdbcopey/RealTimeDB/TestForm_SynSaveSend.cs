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
        private WitsTable wt = new WitsTable();
        public TestForm_SynSaveSend()
        {
            InitializeComponent();
            Thread saveThread = new Thread(new ThreadStart(saveData));
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            realhelper = new SQLiteDBHelper(Properties.Settings.Default.RealDBPath);
        }


        void saveData()
        {
            String[] colNames = { "WID", "SKNO", "RID", "SQID", "DATE", "TIME", "ACTC", "DBTM", "DBTV", "DMEA", "DVER", "BPOS", "ROPA", "HKLA", "HKLX", "WOBA", "WOBX", "TQA", "TQX", "RPMA", "SPPA", "CHKP", "SPM1", "SPM2", "SPM3", "TVA", "TVCA", "MFOP", "MFOA", "MFIA", "MDOA", "MDIA", "MTOA", "MTIA", "MCOA", "MCIA", "STKC", "LSTK", "DRTM", "GASA", "SPR1", "SPR2", "SPR3", "SPR4", "SPR5" };
            foreach (String col in colNames)
            {
                DataColumn dc = new DataColumn(col, System.Type.GetType("System.String"));
                wt.Columns.Add(dc);
            }
            realhelper.InsertWitsData("Shenkai","01",wt);
        }
    }
}
