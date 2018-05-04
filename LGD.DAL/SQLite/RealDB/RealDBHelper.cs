using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Configuration;
using System.Data.Common;
using System.Data.SQLite;
using System.IO;
using System.Diagnostics;
using System.Collections.Concurrent;
using Tool;

namespace LGD.DAL.SQLite.RealDB
{
    /// <summary>
    /// RealDB 的数据库访问类-SQLiteHelper
    /// </summary>
    public class RealDBHelper
    {
        #region 属性 字段
        private String dbPath = String.Empty;
        private String connectionString = String.Empty;
        /// <summary>
        /// 当前数据库文件路径
        /// </summary>
        public String RealDBPath
        {
            get { return dbPath; }
            set { dbPath = value; }
        }
        /// <summary>
        /// 数据库连接
        /// </summary>
        public string RealConnectionString
        {
            get
            {
                return this.connectionString;
            }
            set
            {
                this.connectionString = value;
            }
        }
        #endregion
        /// <summary> 
        /// 构造函数 
        /// </summary> 
        public RealDBHelper()
        {
            RealConnectionString = "Data Source=" + RealDBPath;
        }

        public RealDBHelper(String path)
        {
            RealConnectionString = "Data Source=" + path;
        }

        public static RealDBHelper _realDBHelper = new RealDBHelper();
        #region RealDB 数据库DDL语句
        public const String DDL_01 = "CREATE TABLE [01_General Time-Based] (      WID   VARCHAR PRIMARY KEY                   NOT NULL,     SKNO  VARCHAR,     RID   VARCHAR,     SQID  VARCHAR,     DATE  VARCHAR,     TIME  VARCHAR,     ACTC  VARCHAR,     DEPTH VARCHAR,     DBTV  VARCHAR,     DVEA  VARCHAR,     DVER  VARCHAR,     BPOS  VARCHAR,     ROPA  VARCHAR,     HKLA  VARCHAR,     HKLX  VARCHAR,     WOBA  VARCHAR,     WOBX  VARCHAR,     TQA   VARCHAR,     TQX   VARCHAR,     RPMA  VARCHAR,     SPPA  VARCHAR,     CHKP  VARCHAR,     SPM1  VARCHAR,     SPM2  VARCHAR,     SPM3  VARCHAR,     TVA   VARCHAR,     TVCA  VARCHAR,     MFOP  VARCHAR,     MFOA  VARCHAR,     MFIA  VARCHAR,     MDOA  VARCHAR,     MDIA  VARCHAR,     MTOA  VARCHAR,     MTIA  VARCHAR,     MCOA  VARCHAR,     MCIA  VARCHAR,     STKC  VARCHAR,     LSTK  VARCHAR,     DRTM  VARCHAR,     GASA  VARCHAR,     SPR1  VARCHAR,     SPR2  VARCHAR,     SPR3  VARCHAR,     SPR4  VARCHAR,     SPR5  VARCHAR  ); ";
        public const String DDL_02 = "CREATE TABLE [02_Drilling - Depth Based] (      WID   VARCHAR PRIMARY KEY                   NOT NULL,     SKNO  VARCHAR,     RID   VARCHAR,     SQID  VARCHAR,     DATE  VARCHAR,     TIME  VARCHAR,     ACTC  VARCHAR,     DEPTH VARCHAR,     DVER  VARCHAR,     ROPA  VARCHAR,     WOBA  VARCHAR,     HKLA  VARCHAR,     SPPA  VARCHAR,     TQA   VARCHAR,     RPMA  VARCHAR,     BRVC  VARCHAR,     MDIA  VARCHAR,     ECDT  VARCHAR,     MFIA  VARCHAR,     MFOA  VARCHAR,     MFOP  VARCHAR,     TVA   VARCHAR,     CPDI  VARCHAR,     CPDC  VARCHAR,     BDTI  VARCHAR,     BDDI  VARCHAR,     DXC   VARCHAR,     SPR1  VARCHAR,     SPR2  VARCHAR,     SPR3  VARCHAR,     SPR4  VARCHAR,     SPR5  VARCHAR,     SPR6  VARCHAR,     SPR7  VARCHAR,     SPR8  VARCHAR,     SPR9  VARCHAR  ); ";
        public const String DDL_07 = "CREATE TABLE [07_Survey/Directional] (      WID   VARCHAR PRIMARY KEY                   NOT NULL,     SKNO  VARCHAR,     RID   VARCHAR,     SQID  VARCHAR,     DATE  VARCHAR,     TIME  VARCHAR,     ACTC  VARCHAR,     DEPTH VARCHAR,     VDSVV VARCHAR,     PASS  VARCHAR,     DMEA  VARCHAR,     STYP  VARCHAR,     SINC  VARCHAR,     SAZU  VARCHAR,     SAZC  VARCHAR,     SMTF  VARCHAR,     SGTF  VARCHAR,     SNS   VARCHAR,     SEW   VARCHAR,     SDLS  VARCHAR,     SWLK  VARCHAR,     SPR1  VARCHAR,     SPR2  VARCHAR,     SPR3  VARCHAR,     SPR4  VARCHAR,     SPR5  VARCHAR  );";
        public const String DDL_08 = "CREATE TABLE [08_MWD Formation Evaluation] (      WID     VARCHAR PRIMARY KEY                     NOT NULL,     SKNO    VARCHAR,     RID     VARCHAR,     SQID    VARCHAR,     DATE    VARCHAR,     TIME    VARCHAR,     ACTC    VARCHAR,     DMEA    VARCHAR,     DVER    VARCHAR,     DEPTH   VARCHAR,     DBTV    VARCHAR,     PASS    VARCHAR,     DR1M    VARCHAR,     DR1V    VARCHAR,     MR1     VARCHAR,     MR1C    VARCHAR,     DR2M    VARCHAR,     DR2V    VARCHAR,     MR2     VARCHAR,     MR2C    VARCHAR,     DG1M    VARCHAR,     DG1V    VARCHAR,     MG1     VARCHAR,     MG1C    VARCHAR,     DG2M    VARCHAR,     DG2V    VARCHAR,     MG2     VARCHAR,     MG2C    VARCHAR,     DP1M    VARCHAR,     DP1V    VARCHAR,     MPO1    VARCHAR,     DP2M    VARCHAR,     DENDEP  VARCHAR,     DENVDEP VARCHAR,     DENU    VARCHAR,     DEND    VARCHAR,     DENL    VARCHAR,     DENR    VARCHAR,     DFDM    VARCHAR,     DFDV    VARCHAR,     MFD     VARCHAR,     DCLM    VARCHAR,     DCLV    VARCHAR,     MCLP    VARCHAR,     MFPP    VARCHAR,     MFFP    VARCHAR,     GRDEP   VARCHAR,     GRVDEP  VARCHAR,     GRU     VARCHAR,     GRD     VARCHAR,     GRL     VARCHAR,     GRR     VARCHAR,     SPR7    VARCHAR,     SPR8    VARCHAR,     SPR9    VARCHAR  ); ";
        public const String DDL_09 = "CREATE TABLE [09_MWD Mechanical] (      WID   VARCHAR PRIMARY KEY                   NOT NULL,     SKNO  VARCHAR,     RID   VARCHAR,     SQID  VARCHAR,     DATE  VARCHAR,     TIME  VARCHAR,     ACTC  VARCHAR,     DMEA  VARCHAR,     DVER  VARCHAR,     DEPTH VARCHAR,     DBTV  VARCHAR,     PASS  VARCHAR,     MBPA  VARCHAR,     MBPI  VARCHAR,     MWBA  VARCHAR,     MWBX  VARCHAR,     MTQA  VARCHAR,     MTQX  VARCHAR,     MMRP  VARCHAR,     MALT  VARCHAR,     SPR1  VARCHAR,     SPR2  VARCHAR,     SPR3  VARCHAR,     SPR4  VARCHAR,     SPR5  VARCHAR,     SPR6  VARCHAR,     SPR7  VARCHAR,     SPR8  VARCHAR,     SPR9  VARCHAR  );";
        public const String DDL_11 = "CREATE TABLE [11_Mud Tank Volumes] (      WID  VARCHAR PRIMARY KEY                  NOT NULL,     SKNO VARCHAR,     RID  VARCHAR,     SQID VARCHAR,     DATE VARCHAR,     TIME VARCHAR,     ACTC VARCHAR,     DMEA VARCHAR,     DVER VARCHAR,     TVT  VARCHAR,     TVA  VARCHAR,     TVCT VARCHAR,     TVCA VARCHAR,     TVRT VARCHAR,     TV01 VARCHAR,     TV02 VARCHAR,     TV03 VARCHAR,     TV04 VARCHAR,     TV05 VARCHAR,     TV06 VARCHAR,     TV07 VARCHAR,     TV08 VARCHAR,     TV09 VARCHAR,     TV10 VARCHAR,     TV11 VARCHAR,     TV12 VARCHAR,     TV13 VARCHAR,     TV14 VARCHAR,     TTV1 VARCHAR,     TTV2 VARCHAR,     SPR1 VARCHAR,     SPR2 VARCHAR,     SPR3 VARCHAR,     SPR4 VARCHAR,     SPR5 VARCHAR  ); ";
        public const String DDL_12 = "CREATE TABLE [12_Chromatograph Cycle-Based] (      WID  VARCHAR PRIMARY KEY                  NOT NULL,     SKNO VARCHAR,     RID  VARCHAR,     WQID VARCHAR,     DATE VARCHAR,     TIME VARCHAR,     ACTC VARCHAR,     DCHM VARCHAR,     DCHV VARCHAR,     DCHR VARCHAR,     TCHR VARCHAR,     METH VARCHAR,     ETH  VARCHAR,     PRP  VARCHAR,     IBUT VARCHAR,     NBUT VARCHAR,     IPEN VARCHAR,     NPEN VARCHAR,     EPEN VARCHAR,     IHEX VARCHAR,     NHEX VARCHAR,     CO2  VARCHAR,     ACET VARCHAR,     SPR1 VARCHAR,     SPR2 VARCHAR,     SPR3 VARCHAR,     SPR4 VARCHAR,     SPR5 VARCHAR  ); ";
        public const String DDL_15 = "CREATE TABLE [15_Cuttings / Lithology] (      WID    VARCHAR PRIMARY KEY                    NOT NULL,     SKNO   VARCHAR,     RID    VARCHAR,     SQID   VARCHAR,     DATE   VARCHAR,     TIME   VARCHAR,     ACTC   VARCHAR,     DSAM   VARCHAR,     DSAV   VARCHAR,     [DESC] VARCHAR,     L1TY   VARCHAR,     L1PC   VARCHAR,     L1CL   VARCHAR,     L1CO   VARCHAR,     L1TX   VARCHAR,     L1HD   VARCHAR,     L1SZ   VARCHAR,     L1RD   VARCHAR,     L1SO   VARCHAR,     L1MC   VARCHAR,     L1AC   VARCHAR,     L1PO   VARCHAR,     L1PE   VARCHAR,     L2TY   VARCHAR,     L2PC   VARCHAR,     L2CL   VARCHAR,     L2CO   VARCHAR,     L2TX   VARCHAR,     L2HD   VARCHAR,     L2SZ   VARCHAR,     L2RD   VARCHAR,     L2SO   VARCHAR,     L2MC   VARCHAR,     L2AC   VARCHAR,     L2PO   VARCHAR,     L2PE   VARCHAR,     L3TY   VARCHAR,     L3PC   VARCHAR,     L3CL   VARCHAR,     L4TY   VARCHAR,     L4PC   VARCHAR,     L4CL   VARCHAR,     L5TY   VARCHAR,     L5PC   VARCHAR,     L5CL   VARCHAR,     FOSS   VARCHAR,     SHOW   VARCHAR,     BDEN   VARCHAR,     GCUT   VARCHAR,     CCAL   VARCHAR,     CDOL   VARCHAR,     CEC    VARCHAR,     CAV    VARCHAR,     SDEN   VARCHAR,     SPR1   VARCHAR,     SPR2   VARCHAR,     SPR3   VARCHAR,     SPR4   VARCHAR,     SPR5   VARCHAR  ); ";
        public const String DDL_19 = "CREATE TABLE [19_Configuration] (      WID  VARCHAR PRIMARY KEY                  NOT NULL,     SKNO VARCHAR,     RID  VARCHAR,     WQID VARCHAR,     DATE VARCHAR,     TIME VARCHAR,     ACTC VARCHAR,     DMEA VARCHAR,     DVER VARCHAR,     DSNO VARCHAR,     D1OD VARCHAR,     D1ID VARCHAR,     D1JI VARCHAR,     D1JO VARCHAR,     D1MA VARCHAR,     D1LE VARCHAR,     D2OD VARCHAR,     D2ID VARCHAR,     D2JI VARCHAR,     D2JO VARCHAR,     D2MA VARCHAR,     D2LE VARCHAR,     D3OD VARCHAR,     D3ID VARCHAR,     D3JI VARCHAR,     D3JO VARCHAR,     D3MA VARCHAR,     D3LE VARCHAR,     D4OD VARCHAR,     D4ID VARCHAR,     D4JI VARCHAR,     D4JO VARCHAR,     D4MA VARCHAR,     D4LE VARCHAR,     D5OD VARCHAR,     D5ID VARCHAR,     D5JI VARCHAR,     D5JO VARCHAR,     D5MA VARCHAR,     D5LE VARCHAR,     D6OD VARCHAR,     D6ID VARCHAR,     D6JI VARCHAR,     D6JO VARCHAR,     D6MA VARCHAR,     KID  VARCHAR,     KLEN VARCHAR,     SLEN VARCHAR,     SJNT VARCHAR,     HLNO VARCHAR,     H1DI VARCHAR,     H1LE VARCHAR,     H2DI VARCHAR,     H2LE VARCHAR,     H3DI VARCHAR,     H3LE VARCHAR,     H4DI VARCHAR,     H4LE VARCHAR,     H5DI VARCHAR,     P1CA VARCHAR,     P1EF VARCHAR,     P2CA VARCHAR,     P2EF VARCHAR,     P3CA VARCHAR,     P3EF VARCHAR,     RIGC VARCHAR,     TRRT VARCHAR,     KLID VARCHAR,     KLJD VARCHAR,     KLJF VARCHAR,     KLLE VARCHAR,     CHID VARCHAR,     CHJD VARCHAR,     CHJF VARCHAR,     CHLE VARCHAR,     DCGM VARCHAR,     DCGV VARCHAR,     DPTM VARCHAR,     DPTV VARCHAR,     FPIT VARCHAR,     CONT VARCHAR,     RIG  VARCHAR,     RTYP VARCHAR,     VEN1 VARCHAR,     VEN2 VARCHAR,     VEN3 VARCHAR,     VEN4 VARCHAR,     VEN5 VARCHAR,     VEN6 VARCHAR,     SPR1 VARCHAR,     SPR2 VARCHAR,     SPR3 VARCHAR,     SPR4 VARCHAR,     SPR5 VARCHAR  ); ";
        public const String DDL_51 = "CREATE TABLE [51_APS-WPR] (      WID                 VARCHAR PRIMARY KEY                                 NOT NULL,     SKNO                VARCHAR,     RID                 VARCHAR,     SQID                VARCHAR,     DATE                VARCHAR,     TIME                VARCHAR,     PASSNUMBER          VARCHAR,     WPRSENSORDEPTH      VARCHAR,     ACCEPTED            VARCHAR,     WPRSENSORTOOLSTATUS VARCHAR,     RPCECHX             VARCHAR,     RPCECSHX            VARCHAR,     RPCECLX             VARCHAR,     RPCECSLX            VARCHAR,     RACECHX             VARCHAR,     RACECSHX            VARCHAR,     RACECLX             VARCHAR,     RACECSLX            VARCHAR,     WPRTEMPERATURE      VARCHAR,     RPCECHXSTATUS       VARCHAR,     RPCECSHXSTATUS      VARCHAR,     RPCECLXSTATUS       VARCHAR,     RPCECSLXSTATUS      VARCHAR,     RACECHXSTATUS       VARCHAR,     RACECSHXSTATUS      VARCHAR,     RACECLXSTATUS       VARCHAR,     RACECSLXSTATUS      VARCHAR,     TRSTATUS            VARCHAR  ); ";
        public const String DDL_55 = "CREATE TABLE [55_APS-PWD] (      WID                    VARCHAR PRIMARY KEY                                    NOT NULL,     SKNO                   VARCHAR,     RID                    VARCHAR,     SQID                   VARCHAR,     DATE                   VARCHAR,     TIME                   VARCHAR,     PASSNUMBER             VARCHAR,     PWDSENSORDEPTH         VARCHAR,     ACCEPTED               VARCHAR,     ANNNULARPRESSURE       VARCHAR,     MINIMUMANNULARPRESSURE VARCHAR,     MAXIMUMANNULARPRESSURE VARCHAR,     BOREPRESSURE           VARCHAR,     MINIMUMBOREPRESSURE    VARCHAR,     MAXIMUMBOREPRESSURE    VARCHAR,     ANNULARTEMPERATURE     VARCHAR,     BORETEMPERATURE        VARCHAR,     EQUIVALENTMUDWEIGHT    VARCHAR,     PANNXSTATUS            VARCHAR,     PMNANNXSTATUS          VARCHAR,     PMXANNXSTATUS          VARCHAR,     PBORXSTATUS            VARCHAR,     PMNBORXSTATUS          VARCHAR,     PMXBORXSTATUS          VARCHAR,     TANNSTATUS             VARCHAR,     TBORSTATUS             VARCHAR,     EMWSTATUS              VARCHAR  ); ";
        #endregion
        #region 获取工程信息

        #endregion

        #region 保存wits0记录

        #endregion

        #region 创建 拷贝 本地数据库
        ///// <summary>
        ///// 创建RealDB数据库文件
        ///// </summary>
        ///// <param name="path">要创建的RealDB数据库文件路径</param>
        ///// <param name="nl">的list</param>
        ///// <returns>创建成功or失败</returns>
        //public bool CreateRealDB(String path, List<String> nl)
        //{
        //    if (!File.Exists(path))
        //    {
        //        // 自动打开
        //        if (this.DbConnection == null)
        //        {
        //            this.AutoOpenClose = true;
        //            this.Open();
        //        }
        //        else if (this.DbConnection.State == ConnectionState.Closed)
        //        {
        //            this.Open();
        //        }
        //        SQLiteConnection.CreateFile(path);
        //        RealDBHelper _realhelper = new RealDBHelper(path);
        //        try
        //        {
        //            if (_realhelper.CreateRealDBTabs(nl) > 0)
        //                return true;
        //        }
        //        catch (Exception ex)
        //        {
        //            Debug.WriteLine(">>>RealDBHelper.cs ->CreateRealDB(,)数据库创建异常！<<<\r\t" + ex.Message);
        //            return false;
        //        }
        //    }
        //    return false;
        //}

        ///// <summary>
        ///// 在当前RealData数据库创建指定 wits集（namelist）的数据表
        ///// </summary>
        ///// <param name="con">当前数据库SQLiteConnection</param>
        ///// <param name="namelist">表号List</param>
        ///// <returns>创建表的个数</returns>
        //public int CreateRealDBTabs(List<String> namelist)
        //{
        //    int sum = 0;
        //    SQLiteConnection con = this.DbConnection;
        //    SQLiteTransaction tran = con.BeginTransaction();
        //    SQLiteCommand cmd = new SQLiteCommand(con);
        //    cmd.Transaction = tran;
        //    try
        //    {
        //        // 自动打开
        //        if (con == null)
        //        {
        //            con.Open();
        //        }
        //        else if (con.State == ConnectionState.Closed)
        //        {
        //            con.Open();
        //        }
        //        foreach (String tabname in namelist)
        //        {
        //            //01~55 wits0标准表

        //            switch(tabname)
        //            {
        //                case "01":
        //                    cmd.CommandText = DDL_01;
        //                    cmd.ExecuteNonQuery();
        //                    sum++;
        //                    break;
        //                case "02":
        //                    cmd.CommandText = DDL_02;
        //                    cmd.ExecuteNonQuery();
        //                    sum++;
        //                    break;
        //                case "07":
        //                    cmd.CommandText = DDL_07;
        //                    cmd.ExecuteNonQuery();
        //                    sum++;
        //                    break;
        //                case "08":
        //                    cmd.CommandText = DDL_08;
        //                    cmd.ExecuteNonQuery();
        //                    sum++;
        //                    break;
        //                case "09":
        //                    cmd.CommandText = DDL_09;
        //                    cmd.ExecuteNonQuery();
        //                    sum++;
        //                    break;
        //                case "11":
        //                    cmd.CommandText = DDL_11;
        //                    cmd.ExecuteNonQuery();
        //                    sum++;
        //                    break;
        //                case "12":
        //                    cmd.CommandText = DDL_12;
        //                    cmd.ExecuteNonQuery();
        //                    sum++;
        //                    break;
        //                case "15":
        //                    cmd.CommandText = DDL_15;
        //                    cmd.ExecuteNonQuery();
        //                    sum++;
        //                    break;
        //                case "19":
        //                    cmd.CommandText = DDL_19;
        //                    cmd.ExecuteNonQuery();
        //                    sum++;
        //                    break;
        //                case "51":
        //                    cmd.CommandText = DDL_51;
        //                    cmd.ExecuteNonQuery();
        //                    sum++;
        //                    break;
        //                case "55":
        //                    cmd.CommandText = DDL_55;
        //                    cmd.ExecuteNonQuery();
        //                    sum++;
        //                    break;
        //            }
        //        }
        //        tran.Commit();
        //        return sum;
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine(">>>RealDBHelper.cs-->CreateRealDBTabs() 创建RealData数据表异常！<<<\r\t" + ex.Message);
        //        tran.Rollback();
        //        return -1;
        //    }
        //}
        #endregion
    }
}
