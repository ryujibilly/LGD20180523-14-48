using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LGD.DAL.SQLite
{
    /// <summary>
    /// wits0 表名
    /// </summary>
    public class TabName
    {
        #region wits0 表
        public static readonly TabName _tabName=new TabName();
        public string tab01 = "[01_General Time-Based]";
        public string tab02 = "[02_Drilling - Depth Based]";
        public string tab07 = "[07_Survey/Directional]";
        public string tab08 = "[08_MWD Formation Evaluation]";
        public string tab09 = "[09_MWD Mechanical]";
        public string tab11 = "[11_Mud Tank Volumes]";
        public string tab12 = "[12_Chromatograph Cycle-Based]";
        public string tab15 = "[15_Cuttings / Lithology]";
        public string tab19 = "[19_Configuration]";
        public string tab51 = "[51_APS-WPR]";
        public string tab55 = "[55_APS-PWD]";
        #endregion

        #region wits集合/记录
        public string tab00 = "[00_WitsData]";
        public string tab_1 = "[-1_Collection-Index]";
        public string tab_2 = "[-2_Common-Index]";
        public string tab_3 = "[-3_APS-Index]";
        public string tab_4 = "[-4_shenkai-Index]";
        public string tab_5 = "[-5_BakerHughes-Index]";
        public string tab_6 = "[-6_APS_SureShot-Index]";
        public string tab_7 = "[-7_ACE-Index]";
        #endregion
    }
}
