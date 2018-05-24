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
using LGD.DAL.SQLite.RealDB;

namespace LGD.DAL.SQLite
{
    /// <summary> 
    /// 说明：这是一个针对System.Data.SQLite的数据库常规操作封装的通用类。 
    ///  2017-7-27
    /// </summary>    
    public partial class SQLiteDBHelper:RealDBHelper
    {
        #region 字段、属性
        /// <summary>
        /// 单例模式对象
        /// </summary>
        public static SQLiteDBHelper _sqliteHelper = new SQLiteDBHelper();
        private String dataSource = String.Empty;
        private String targetDBPath = String.Empty;
        private String dbPath = String.Empty;
        private String connectionString = String.Empty;
        private SQLiteTransaction dbTransaction = null;
        private bool inTransaction = false;
        private List<string> tablist = new List<string>();
        private String _lastDateTimeValue = null;
        private String _firstDateTimeValue = null;
        private int startindex = 0;

        /// <summary>
        /// 初始值
        /// </summary>
        public String _FirstDateTimeValue
        {
            get { return _firstDateTimeValue; }
            set { _firstDateTimeValue = value; }
        }
        /// <summary>
        /// 上一次传的Value
        /// </summary>
        public String _LastDateTimeValue
        {
            get { return _lastDateTimeValue; }
            set { _lastDateTimeValue = value; }
        }
        /// <summary>
        /// 当前数据库文件路径
        /// </summary>
        public String DBPath
        {
            get { return dbPath; }
            set { dbPath = value; }
        }
        /// <summary>
        /// 数据库连接
        /// </summary>
        public string ConnectionString
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
        #region 数据库连接必要条件参数
        private SQLiteConnection dbConnection = null;
        //private SQLiteConnection targetDBConnection = null;
        /// <summary>
        /// 当前数据库连接
        /// </summary>
        public SQLiteConnection DbConnection
        {
            get
            {
                if (this.dbConnection == null)
                {
                    // 若没打开，就变成自动打开关闭的
                    this.Open();
                    this.AutoOpenClose = true;
                }
                return this.dbConnection;
            }
            set
            {
                this.dbConnection = value;
            }
        }
        private SQLiteCommand dbCommand = null;
        /// <summary>
        /// 当前数据库 命令
        /// </summary>
        public SQLiteCommand DbCommand
        {
            get
            {
                return this.dbCommand;
            }
            set
            {
                this.dbCommand = value;
            }
        }
        private SQLiteDataAdapter dbDataAdapter = null;
        /// <summary>
        /// 当前数据库适配器
        /// </summary>
        public SQLiteDataAdapter DbDataAdapter
        {
            get
            {
                return this.dbDataAdapter;
            }
            set
            {
                this.dbDataAdapter = value;
            }
        }


        /// <summary>
        /// 是否已采用事务
        /// </summary>
        public bool InTransaction
        {
            get
            {
                return this.inTransaction;
            }
            set
            {
                this.inTransaction = value;
            }
        }
        private bool autoOpenClose = false;
        /// <summary>
        /// 默认打开关闭数据库选项（默认为否）
        /// </summary>
        public bool AutoOpenClose
        {
            get
            {
                return autoOpenClose;
            }
            set
            {
                autoOpenClose = value;
            }
        }
        /// <summary>
        /// RealData实时库数据表集合：表名"01"，"02"... ...
        /// </summary>
        public List<string> Tablist
        {
            get
            {
                return tablist;
            }

            set
            {
                tablist = value;
            }
        }
        /// <summary>
        /// 推送数据起始索引值
        /// </summary>
        public int Startindex
        {
            get
            {
                return startindex;
            }

            set
            {
                startindex = value;
            }
        }


        #endregion

        #endregion
        /// <summary> 
        /// 构造函数 
        /// </summary> 
        public SQLiteDBHelper()
        {
            this.ConnectionString = string.Empty;
            this.ConnectionString = "Data Source=" + dbPath;
        }

        public SQLiteDBHelper(String path)
        {
            this.ConnectionString = string.Empty;
            this.ConnectionString = "Data Source=" + path;
        }

        /// <summary>
        /// 这时主要的获取数据库连接的方法
        /// </summary>
        /// <returns>数据库连接</returns>
        public IDbConnection Open()
        {
            this.Open(this.ConnectionString);
            return this.dbConnection;
        }

        /// <summary>
        /// 获得新的数据库连接
        /// </summary>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <returns>数据库连接</returns>
        public IDbConnection Open(string connectionString)
        {
            // 若是空的话才打开
            if (this.dbConnection == null || this.dbConnection.State == ConnectionState.Closed)
            {
                this.ConnectionString = connectionString;
                this.dbConnection = new SQLiteConnection(this.ConnectionString);
                this.dbConnection.Open();
            }

            this.AutoOpenClose = false;
            return this.dbConnection;
        }

        #region 建立、拷贝本地数据库

        /// <summary> 
        /// 创建空SQLite数据库文件
        /// </summary> 
        /// <param name="dbPath">要创建的SQLite数据库文件路径</param> 
        public void CreateDB()
        {
            if (!File.Exists(dbPath))
            {
                // 自动打开
                if (this.DbConnection == null)
                {
                    this.AutoOpenClose = true;
                    this.Open();
                }
                else if (this.DbConnection.State == ConnectionState.Closed)
                {
                    this.Open();
                }
                this.dbCommand = this.DbConnection.CreateCommand();
                this.dbCommand.CommandText = "CREATE TABLE Demo(id integer NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE)";
                this.dbCommand.ExecuteNonQuery();
                this.dbCommand.CommandText = "DROP TABLE Demo";
                this.dbCommand.ExecuteNonQuery();
            }
        }
        /// <summary> 
        /// 创建SQLite数据库文件 
        /// </summary> 
        /// <param name="dbPath">要创建的SQLite数据库文件路径</param> 
        public bool CreateDB(String DBName)
        {
            try
            {
                if (!File.Exists(dbPath))
                {
                    // 自动打开
                    if (this.DbConnection == null)
                    {
                        this.AutoOpenClose = true;
                        this.Open();
                    }
                    else if (this.DbConnection.State == ConnectionState.Closed)
                    {
                        this.Open();
                    }
                    SQLiteConnection.CreateFile(DBName);
                    return true;
                }
                else return false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(">>>SQLiteDBHelper.cs ->CreateDB(String DBName)数据库创建异常！<<<\r\t" + ex.Message);
                return false;
            }

        }
        /// <summary>
        /// 创建带表的SQLite数据库文件
        /// </summary>
        /// <param name="path">要创建的SQLite数据库文件路径</param>
        /// <param name="instru">仪器</param>
        /// <param name="tabid">表ID</param>
        /// <param name="shotname">短助记符列表</param>
        /// <returns>创建成功与否</returns>

        public bool CreateDB(String path,String instru,String tabid,List<String> shotname)
        {
            if (!File.Exists(path))
            {
                // 自动打开
                if (this.DbConnection == null)
                {
                    this.AutoOpenClose = true;
                    this.Open();
                }
                else if (this.DbConnection.State == ConnectionState.Closed)
                {
                    this.Open();
                }
                SQLiteConnection.CreateFile(path);
                ///
                SQLiteDBHelper _sqlitehelper = new SQLiteDBHelper(path);
                try
                {
                    if (_sqlitehelper.CreateTabs(instru,tabid,shotname) > 0)
                    return true;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(">>>SQLiteDBHelper.cs ->CreateDB(path,instru,tabid,shotname)数据库创建异常！<<<\r\t" + ex.Message);
                    return false;
                }
            }
            return false;
        }

        /// <summary>
        /// 在当前RealData数据库创建指定 wits集（namelist）的数据表
        /// </summary>
        /// <param name="con">当前数据库SQLiteConnection</param>
        /// <param name="namelist">表号List</param>
        /// <returns>创建表的个数</returns>
        public int CreateTabs(String instru,String tabid,List<String> shotname)
        {
            int sum = 0;
            SQLiteConnection con = this.DbConnection;
            SQLiteTransaction tran = con.BeginTransaction();
            SQLiteCommand cmd = new SQLiteCommand(con);
            cmd.Transaction = tran;
            try
            {
                // 自动打开
                if (con == null)
                {
                    con.Open();
                }
                else if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                String cmdtext ="CREATE TABLE [" + tabid + "-" + instru + "] (WID VARCHAR,";
                for (int i = 1; i <shotname.Count - 1; i++)
                    cmdtext += shotname[i] + " VARCHAR,";
                cmdtext += shotname[shotname.Count-1] + " VARCHAR,PRIMARY KEY (DATE,TIME));";
                cmd.CommandText = cmdtext;
                cmd.ExecuteNonQuery();
                sum++;
                tran.Commit();
                return sum;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(">>>SQLiteDBHelper.cs-->CreateTabs() 创建RealData数据表异常！<<<\r\t"+ex.Message);
                tran.Rollback();
                return -1;
            }
        }
        /// <summary>
        /// 拷贝数据库文件
        /// </summary>
        /// <param name="sourcepath">源数据库路径</param>
        /// <param name="destpath">目标数据库路径</param>
        public bool DBCopy(String sourcepath, String destpath)
        {
            try
            {
                if (File.Exists(sourcepath))
                {
                    // 自动打开
                    if (this.DbConnection == null)
                    {
                        this.AutoOpenClose = true;
                        this.Open();
                    }
                    else if (this.DbConnection.State == ConnectionState.Closed)
                    {
                        this.Open();
                    }
                    File.Copy(sourcepath, destpath);
                    return true;
                }
                else return false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(">>>SQLiteDBHelper.cs ->DBCopy()数据库拷贝异常！<<<\r\t" + ex.Message);
                return false;
            }
        }
        /// <summary>
        /// 创建SQLite图版数据库表 
        /// </summary>
        /// <param name="con">数据库连接</param>
        /// <param name="tableName">表名</param>
        public void Create_ChartTable(SQLiteConnection con, String tableName)
        {
            try
            {
                // 自动打开
                if (con == null)
                {
                    con.Open();
                }
                else if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                dbCommand = con.CreateCommand();
                dbCommand.CommandText = "CREATE TABLE [" + tableName + "] (ID INTEGER PRIMARY KEY ASC AUTOINCREMENT NOT NULL UNIQUE, ParameterName VARCHAR( 30 )  NOT NULL DEFAULT ( '' ), ParameterValue REAL( 15 ) NOT NULL DEFAULT ( -999.25 ), XValue REAL( 15 ) NOT NULL DEFAULT ( -999.25 ), YValue REAL( 15 ) NOT NULL DEFAULT ( -999.25 ) )";
                dbCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message + "创建SQLite数据表异常！");
            }

        }
        /// <summary>
        /// 创建SQLite数据库表 
        /// </summary>
        /// <param name="con">数据库连接</param>
        /// <param name="tableName">表名</param>
        public void Create_WellTable(SQLiteConnection con, String tableName)
        {
            try
            {
                // 自动打开
                if (con == null)
                {
                    con.Open();
                }
                else if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                dbCommand = con.CreateCommand();
                dbCommand.CommandText = "CREATE TABLE [" + tableName + "] ( ID INTEGER PRIMARY KEY ASC AUTOINCREMENT NOT NULL UNIQUE, Time VARCHAR(13)    NOT NULL  DEFAULT('000101/000000'),  Depth NUMERIC(8, 2)  NOT NULL DEFAULT(-999.25), RPCECHM_AC  REAL(15) NOT NULL DEFAULT(-999.25), RPCECSHM_AC REAL(15) NOT NULL  DEFAULT(-999.25), PRCECLM_AC  REAL(15) NOT NULL DEFAULT(-999.25), RPCECLSM_AC REAL(15) NOT NULL DEFAULT(-999.25), RACECHM_AC  REAL(15) NOT NULL  DEFAULT(-999.25), RACECSHM_AC REAL(15) NOT NULL  DEFAULT(-999.25), RACECLM_AC  REAL(15)  NOT NULL   DEFAULT(-999.25), RACECLSM_AC REAL(15)   NOT NULL   DEFAULT(-999.25))";
                dbCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message + "创建SQLite数据表异常！");
            }
        }

        #endregion

        #region 写库\查询
        /// <summary>
        /// 填写单井信息
        /// </summary>
        /// <param name="wellName">井名</param>
        /// <param name="logName">井次</param>
        /// <param name="regionName">工区名</param>
        /// <param name="wellId">井号</param>
        /// <param name="logId">井次号</param>
        /// <param name="regionId">工区号</param>
        /// <param name="DBPath">数据库文件所在地址</param>
        public bool InsertWellInfo(String wellName,String logName,String regionName, String wellId, String logId, String regionId, String DBPath)
        {
            SQLiteConnection conn = this.DbConnection;
            SQLiteTransaction tran = conn.BeginTransaction();
            SQLiteCommand cmd = new SQLiteCommand(conn);
            cmd.Transaction = tran;
            try
            {
                this.Open();
                cmd.CommandText = "insert into [WellInfo] values(@LogName,@WellName,@RegionName,@LogId, @WellId,@RegionId,@DBPath)";
                cmd.Parameters.AddRange(new[]{
                        new SQLiteParameter("@LogName",logName),
                        new SQLiteParameter("@WellName",wellName),
                        new SQLiteParameter("@RegionName",regionName),
                        new SQLiteParameter("@LogId",logId),
                        new SQLiteParameter("@WellId",wellId),
                        new SQLiteParameter("@RegionId",regionId),
                        new SQLiteParameter("@DBPath",DBPath)
                    });
                cmd.ExecuteNonQuery();
                tran.Commit();
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(">>>SQLiteHelper.cs-->InsertWellInfo(,,)-->填写井信息事务异常!<<<---- \r\t" + ex.Message);
                tran.Rollback();
                return false;
            }
        }
        /// <summary>
        /// 获取井信息数据记录
        /// </summary>
        /// <param name="logName">井次</param>
        /// <returns>一条记录的List《String》</returns>
        public List<String> getWellInfo(String logname)
        {
            List<String> wellInfo = new List<string>();
            SQLiteConnection conn = DbConnection;
            SQLiteCommand cmd = new SQLiteCommand(conn);
            int i = 0;
            try
            {
                Open();
                cmd.CommandText = "select * from [WellInfo] where LogName="+ logname;
                SQLiteDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while(dr.Read())
                {
                    wellInfo.Add(dr[i++].ToString());
                }
                return wellInfo;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(">>>SQLiteHelper.cs-->getWellInfo(String logname)-->获取井信息查询异常!<<<---- \r\t" + ex.Message);
                return null;
            }
        }
        public String GetFirstRec(String tabname)
        {
            try
            {
                String firstrec = null;
                String date = null;
                String time = null;
                SQLiteConnection conn = DbConnection;
                SQLiteCommand cmd = new SQLiteCommand(conn);
                Open();
                cmd.CommandText = "select [DATE],[TIME] from [" + tabname + "] limit 0,1";
                SQLiteDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    date = dr["DATE"].ToString();
                    time = dr["TIME"].ToString();
                }
                firstrec = date + time;
                return firstrec;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(">>>SQLiteHelper.cs-->GetFirstRec(String tabname)-->获取井信息查询异常!<<<---- \r\t" + ex.Message);
                return null;
            }
        }

        public String GetLastRec(String tabname)
        {
            try
            {
                String lastrec = null;
                String date = null;
                String time = null;
                SQLiteConnection conn = DbConnection;
                SQLiteCommand cmd = new SQLiteCommand(conn);
                Open();
                cmd.CommandText = "select [DATE],[TIME] from [" + tabname + "] order by rowid desc limit 0,1";
                SQLiteDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    date = dr["DATE"].ToString();
                    time = dr["TIME"].ToString();
                }
                lastrec = date + time;
                return lastrec;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(">>>SQLiteHelper.cs-->GetLastRec(String tabname)-->获取井信息查询异常!<<<---- \r\t" + ex.Message);
                return null;
            }
        }
        /// <summary>
        /// 将动态WitTable对象的数据写入数据库表中
        /// </summary>
        /// <param name="Instru">仪器</param>
        /// <param name="tabID">表号</param>
        /// <param name="wt">动态witstable表</param>
        /// <returns>写入记录数量 :-1表示异常，》=0表示写入记录数量</returns>
        public int InsertWitsData(String Instru,String tabID, WitsTable wt)
        {
            _FirstDateTimeValue = GetFirstRec(tabID + "-" + Instru);
            _LastDateTimeValue = GetLastRec(tabID + "-" + Instru);
            WitsTable wtCopy = (WitsTable)wt.Copy();
            List<String> colnames = new List<string>();
            String cmdtext = "";
            int sum = 0;
            SQLiteConnection conn = this.DbConnection;
            SQLiteTransaction tran = conn.BeginTransaction();
            SQLiteCommand cmd = new SQLiteCommand(conn);
            cmd.Transaction = tran;
            List<String> value;
            try
            {
                //获取列名（短助记符集合）
                foreach (DataColumn col in wt.Columns)
                    colnames.Add(col.ColumnName);
                Open();
                //校正后数据
                while (wtCopy.getNextRow(out value))
                {
                    String datetime = value[4]+value[5];
                    cmdtext = "insert into[" + tabID + "-" + Instru + "] values(";
                    for (int i = 0; i <=wt.Columns.Count - 2; i++)
                    {
                        cmdtext += "@" + wt.Columns[i].ColumnName + ",";
                        if (((i == 4) || (i == 5)) && _FirstDateTimeValue.Length > 0)
                        {
                            if ((i == 4) && ((datetime == _LastDateTimeValue) || (datetime == _FirstDateTimeValue)))
                            {
                                value[4] = DateTime.Now.ToString("yyyyMMdd");
                                cmd.Parameters.AddWithValue("@" + wt.Columns[4].ColumnName, value[4]);
                            }
                            if ((i == 5) && ((datetime == _LastDateTimeValue) || (datetime == _FirstDateTimeValue)))
                            {
                                value[5] = DateTime.Now.ToString("HHmmss");
                                cmd.Parameters.AddWithValue("@" + wt.Columns[5].ColumnName, value[5]);
                            }
                        }
                        else
                            cmd.Parameters.AddWithValue("@" + wt.Columns[i].ColumnName, value[i].ToString());
                    }
                    cmdtext += "@" + wt.Columns[wt.Columns.Count - 1].ColumnName + ")";
                    cmd.Parameters.AddWithValue("@"+ wt.Columns[wt.Columns.Count - 1].ColumnName,
                        value[value.Count-1].ToString());
                    //设置带参数的Transact-SQL语句 "insert into ["+tabID+"-"+Instru+"] values(@...)";
                    cmd.CommandText = cmdtext;
                    cmd.ExecuteNonQuery();
                    sum++;
                }
                tran.Commit();
                return sum;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(">>>SQLiteHelper.cs-->InsertWitsData(String,WitsTable)-->tran事务异常!<<<---- \r\t" + ex.Message);
                tran.Rollback();
                return -1;
            }
        }
        public void getWitsData(String date,String time)
        {

        }

        /// <summary>
        /// wits0记录的入表解析（拆分wits数据，分表入库）
        /// </summary>
        /// <returns></returns>
        public int WitsTabAnalysis(String tabID,WitsTable wt)
        {
            WitsTable wtCopy = (WitsTable)wt.Copy();
            int sum = 0;
            SQLiteConnection conn = this.DbConnection;
            SQLiteTransaction tran = conn.BeginTransaction();
            SQLiteCommand cmd = new SQLiteCommand(conn);
            cmd.Transaction = tran;
            List<String> value;
            try
            {
                this.Open();
                //校正后数据
                while (wtCopy.getNextRow(out value))
                {
                    //设置带参数的Transact-SQL语句
                    cmd.CommandText = "insert into [" + tabID + "] values(@ID,@ItemIndex, @Value)";
                    cmd.Parameters.AddRange(new[]
                    {
                        new SQLiteParameter("@Value",value)
                    });
                    cmd.ExecuteNonQuery();
                    sum++;
                }
                tran.Commit();
                return sum;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(">>>SQLiteHelper.cs-->WitsTabAnalysis(String,WitsTable)-->tran事务异常!<<<---- \r\t" + ex.Message);
                tran.Rollback();
                return -1;
            }
        }
        /// <summary>
        /// 获取当前Date Time 对应的 rowid索引值
        /// </summary>
        /// <param name="instru">仪器名</param>
        /// <param name="tabid">表号</param>
        /// <param name="_date">日期</param>
        /// <param name="_time">时间</param>
        /// <returns>返回rowid</returns>
        public int getCurrentIndex(String tabname, String _date,String _time)
        {
            // 自动打开
            if (this.DbConnection == null)
            {
                this.AutoOpenClose = true;
                this.Open();
            }
            else if (this.DbConnection.State == ConnectionState.Closed)
            {
                this.Open();
            }
            SQLiteConnection conn = this.dbConnection;
            this.DbCommand = this.DbConnection.CreateCommand();
            try
            {
                string strSQL = "select [rowid] from [" + tabname + "] where [DATE]>=" + _date + " AND [TIME]>=" + _time + " limit 0,1";
                this.DbCommand.CommandText = strSQL;
                dbDataAdapter = new SQLiteDataAdapter(this.DbCommand);
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                dbDataAdapter.Fill(ds);
                dt = ds.Tables[0];
                int rowid = int.Parse(dt.Rows[0].ItemArray[0].ToString());
                return rowid;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(">>>SQLiteHelper.cs-->getCurrentIndex()-->tran事务异常!<<<---- \r\t" + ex.Message);
                return -1;
            }
        }
        #endregion

        #region 数据推送

        /// <summary>
        /// 获取推送的数据DataTable--通过时间索引(定时定量)
        /// </summary>
        /// <param name="instru">仪器序号</param>
        /// <param name="tabid">表号集合</param>
        /// <param name="startDate">起始日期</param>
        /// <param name="startTime">起始时间</param>
        /// <param name="endDate">截止日期</param>
        /// <param name="endTime">截至时间</param>
        /// <returns></returns>
        public DataTable getPushingData( String instru,String tabid,String startDate,String startTime,String endDate,String endTime)
        {
            // 自动打开
            if (this.DbConnection == null)
            {
                this.AutoOpenClose = true;
                this.Open();
            }
            else if (this.DbConnection.State == ConnectionState.Closed)
            {
                this.Open();
            }
            SQLiteConnection conn = this.dbConnection;
            this.DbCommand = this.DbConnection.CreateCommand();
            try
            {
                string strSQL = string.Format(@"SELECT * FROM [" + tabid + "-" + instru + "] WHERE [DATE]>" + startDate + " AND [TIME]>"
                    + startTime + " AND [DATE]<" + endDate + " AND [TIME]<" + endTime, tabid+"-"+instru);
                this.DbCommand.CommandText = strSQL;
                dbDataAdapter = new SQLiteDataAdapter(this.DbCommand);
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                dbDataAdapter.Fill(ds);
                dt = ds.Tables[0];
                dt.TableName = tabid + "-" + instru;
                return dt;
            }
            catch (Exception ex) 
            {
                Debug.WriteLine(">>>SQLiteHelper.cs-->getPushingData(String instru,String tabid,String startDate,String startTime,String endDate,String endTime)-->tran事务异常!<<<---- \r\t" + ex.Message);
                return null;
            }
        }

        /// <summary>
        /// 获取推送的数据DataTable--返回 rowid 
        /// </summary>
        /// <param name="instru">仪器序号</param>
        /// <param name="tabid">表号集合</param>
        /// <param name="startDate">起始日期</param>
        /// <param name="startTime">起始时间</param>
        /// <param name="startindex">记录起始索引位置</param>
        /// <param name="fps">每帧推送记录数</param>
        /// <param name="rowidstart">起始rowid</param>
        /// <param name="rowidend">截至rowid</param>
        /// <returns>指定DataTable</returns>
        public DataTable getPushingData(String instru, String tabid,int startindex,int fps,out int rowidstart,out int rowidend)
        {
            
            // 自动打开
            if (this.DbConnection == null)
            {
                this.AutoOpenClose = true;
                this.Open();
            }
            else if (this.DbConnection.State == ConnectionState.Closed)
            {
                this.Open();
            }
            SQLiteConnection conn = this.dbConnection;
            this.DbCommand = this.DbConnection.CreateCommand();
            try
            {
                string strSQL = string.Format(@"SELECT rowid,* FROM [" + tabid + "-" + instru + "] "+" limit "+startindex+","+fps, tabid + "-" + instru);
                this.DbCommand.CommandText = strSQL;
                dbDataAdapter = new SQLiteDataAdapter(this.DbCommand);
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                dbDataAdapter.Fill(ds);
                dt = ds.Tables[0];
                dt.TableName = tabid + "-" + instru;
                rowidstart = int.Parse(dt.Rows[0].ItemArray[0].ToString());
                rowidend = int.Parse(dt.Rows[dt.Rows.Count - 1].ItemArray[0].ToString());
                return dt;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(">>>SQLiteHelper.cs-->getPushingData(String instru, String tabid,int startindex,int fps,out int rowidstart,out int rowidend)异常!<<<---- \r\t" + ex.Message);
                rowidstart = -1;
                rowidend = -1;
                return null;
            }
        }

        /// <summary>
        /// 获取推送的数据DataTable--通过时间索引(实时至最新，并返回lastrowid)
        /// </summary>
        /// <param name="instru">仪器序号</param>
        /// <param name="tabid">表号集合</param>
        /// <param name="startrowid">起始rowid</param>
        /// <param name="endrowid">发送截至rowid</param>
        /// <returns></returns>
        public DataTable getPushingData(String instru, String tabid,int startrowid,out int endrowid)
        {
            // 自动打开
            if (this.DbConnection == null)
            {
                this.AutoOpenClose = true;
                this.Open();
            }
            else if (this.DbConnection.State == ConnectionState.Closed)
            {
                this.Open();
            }
            SQLiteConnection conn = this.dbConnection;
            this.DbCommand = this.DbConnection.CreateCommand();
            try
            {
                string strSQL = string.Format(@"SELECT rowid,* FROM [" + tabid + "-" + instru + "] WHERE [rowid]>" + startrowid,tabid + "-" + instru);
                this.DbCommand.CommandText = strSQL;
                dbDataAdapter = new SQLiteDataAdapter(this.DbCommand);
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                dbDataAdapter.Fill(ds);
                dt = ds.Tables[0];
                dt.TableName = tabid + "-" + instru;
                endrowid = int.Parse(dt.Rows[dt.Rows.Count - 1].ItemArray[0].ToString());
                return dt;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(">>>SQLiteHelper.cs-->getPushingData(String instru, String tabid, int startrowid,out int endrowid)-->tran事务异常!<<<---- \r\t" + ex.Message);
                endrowid = -1;
                return null;
            }
        }
        /// <summary>
        /// 获取该表最大rowid
        /// </summary>
        /// <param name="tabname">表名</param>
        /// <returns>rowid</returns>
        public int getLastRowID(String tabname,String instruname)
        {
            int lastrowid = 0;
            // 自动打开
            if (this.DbConnection == null)
            {
                this.AutoOpenClose = true;
                this.Open();
            }
            else if (this.DbConnection.State == ConnectionState.Closed)
            {
                this.Open();
            }
            SQLiteConnection conn = this.dbConnection;
            this.DbCommand = this.DbConnection.CreateCommand();
            try
            {
                //select rowid from [01-Shenkai] order by rowid desc limit 0,1 获取最后一条记录的 rowid
                string strSQL = string.Format(@"SELECT rowid FROM [" + tabname +"-"+ instruname + "] order by rowid desc limit 0,1", tabname + "-" + instruname);
                this.DbCommand.CommandText = strSQL;
                dbDataAdapter = new SQLiteDataAdapter(this.DbCommand);
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                dbDataAdapter.Fill(ds);
                dt = ds.Tables[0];
                lastrowid = int.Parse(dt.Rows[0].ItemArray[0].ToString());
                return lastrowid;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(">>>SQLiteHelper.cs-->getLastRowID()-->tran事务异常!<<<---- \r\t" + ex.Message);
                return -1;
            }
        }

        public List<String> getTitleList(String tabname)
        {
            List<String> sqllist = new List<string>();
            // 自动打开
            if (this.DbConnection == null)
            {
                this.AutoOpenClose = true;
                this.Open();
            }
            else if (this.DbConnection.State == ConnectionState.Closed)
            {
                this.Open();
            }
            SQLiteConnection conn = this.dbConnection;
            this.DbCommand = this.DbConnection.CreateCommand();
            try
            {
                string strSQL = string.Format(@"pragma table_info(["+tabname+"])");
                this.DbCommand.CommandText = strSQL;
                dbDataAdapter = new SQLiteDataAdapter(this.DbCommand);
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                dbDataAdapter.Fill(ds);
                dt = ds.Tables[0];
                for (int i = 0; i < dt.Rows.Count; i++)
                    sqllist.Add(dt.Rows[i].ItemArray[1].ToString());
                return sqllist;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }

        private void convertDDL2List(String str)
        {
            String[] sep = { "[", "]" };
            
            String[] substr =str.Split(sep, StringSplitOptions.RemoveEmptyEntries);

        }
        #endregion

        #region 判断表是否存在

        /// <summary>
        /// 判断表是否存在
        /// true:存在；false:不存在
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <returns></returns>
        public bool IsExistTable(string tableName)
        {
            // 自动打开
            if (this.DbConnection == null)
            {
                this.AutoOpenClose = true;
                this.Open();
            }
            else if (this.DbConnection.State == ConnectionState.Closed)
            {
                this.Open();
            }
            this.dbCommand = this.DbConnection.CreateCommand();
            string strSQL = string.Format("select * from sqlite_master where [type]='table' and [name]='{0}'", tableName);
            this.dbCommand.CommandText = strSQL;
            DataSet ds = new DataSet();
            dbDataAdapter = new SQLiteDataAdapter(this.dbCommand);
            dbDataAdapter.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
                return true;
            else
                return false;
        }

        #endregion

        #region ExecuteNonQuery

        /// <summary>
        /// 执行查询
        /// </summary>
        /// <param name="commandText">sql查询</param>
        /// <returns>影响行数</returns>
        public int ExecuteNonQuery(string commandText)
        {
            return ExecuteNonQuery(commandText, null);
        }
        /// <summary> 
        /// 对SQLite数据库执行增删改操作，返回受影响的行数。 
        /// </summary> 
        /// <param name="commandText">要执行的增删改的SQL语句</param> 
        /// <param name="parameters">执行增删改语句所需要的参数，参数必须以它们在SQL语句中的顺序为准</param> 
        /// <returns></returns> 
        public int ExecuteNonQuery(string commandText, SQLiteParameter[] parameters)
        {
            // 自动打开
            if (this.DbConnection == null)
            {
                this.AutoOpenClose = true;
                this.Open();
            }
            else if (this.DbConnection.State == ConnectionState.Closed)
            {
                this.Open();
            }
            this.dbCommand = this.DbConnection.CreateCommand();
            this.dbCommand.CommandText = commandText;
            if (this.dbTransaction != null)
            {
                this.dbCommand.Transaction = this.dbTransaction;
            }
            if (parameters != null)
            {
                this.dbCommand.Parameters.Clear();
                for (int i = 0; i < parameters.Length; i++)
                {
                    this.dbCommand.Parameters.Add(parameters[i]);
                }
            }
            int returnValue = this.dbCommand.ExecuteNonQuery();
            // 自动关闭           
            this.dbCommand.Parameters.Clear();
            return returnValue;
        }

        #endregion

        #region ExecuteReader

        /// <summary>
        /// 执行一个查询语句，返回一个关联的SQLiteDataReader实例 
        /// </summary>
        /// <param name="commandText"></param>
        /// <returns></returns>
        public SQLiteDataReader ExecuteReader(string commandText)
        {
            return ExecuteReader(commandText, null);
        }

        /// <summary> 
        /// 执行一个查询语句，返回一个关联的SQLiteDataReader实例 
        /// </summary> 
        /// <param name="commandText">要执行的查询语句</param> 
        /// <param name="dbParameters">执行SQL查询语句所需要的参数，参数必须以它们在SQL语句中的顺序为准</param> 
        /// <returns></returns> 
        public SQLiteDataReader ExecuteReader(string commandText, SQLiteParameter[] dbParameters)
        {
            // 自动打开
            if (this.DbConnection == null)
            {
                this.AutoOpenClose = true;
                this.Open();
            }
            else if (this.DbConnection.State == ConnectionState.Closed)
            {
                this.Open();
            }

            this.dbCommand = this.DbConnection.CreateCommand();
            this.dbCommand.CommandText = commandText;
            if (dbParameters != null)
            {
                this.dbCommand.Parameters.Clear();
                for (int i = 0; i < dbParameters.Length; i++)
                {
                    if (dbParameters[i] != null)
                    {
                        this.dbCommand.Parameters.Add(dbParameters[i]);
                    }
                }
            }
            // 这里要关闭数据库才可以的
            SQLiteDataReader dbDataReader = null;
            dbDataReader = this.dbCommand.ExecuteReader(CommandBehavior.CloseConnection);
            return dbDataReader;
        }

        #endregion

        #region ExecuteDataTable

        public DataTable ExecuteDataTable(string commandText)
        {
            return ExecuteDataTable(commandText, null);
        }
        /// <summary> 
        /// 执行一个查询语句，返回一个包含查询结果的DataTable 
        /// </summary> 
        /// <param name="sql">要执行的查询语句</param> 
        /// <param name="parameters">执行SQL查询语句所需要的参数，参数必须以它们在SQL语句中的顺序为准</param> 
        /// <returns></returns> 
        public DataTable ExecuteDataTable(string commandText, SQLiteParameter[] parameters)
        {
            // 自动打开
            if (this.DbConnection == null)
            {
                this.AutoOpenClose = true;
                this.Open();
            }
            else if (this.DbConnection.State == ConnectionState.Closed)
            {
                this.Open();
            }
            this.dbCommand = this.DbConnection.CreateCommand();
            this.dbCommand.CommandText = commandText;
            if (parameters != null)
            {
                this.dbCommand.Parameters.AddRange(parameters);
            }
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(this.dbCommand);
            DataTable data = new DataTable();
            adapter.Fill(data);
            // 自动关闭
            if (this.AutoOpenClose)
            {
                this.Close();
            }
            return data;
        }
        #endregion

        #region ExecuteScalar

        /// <summary>
        /// 执行一个查询语句，返回查询结果的第一行第一列 
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="dbParameters"></param>
        /// <returns></returns>
        public Object ExecuteScalar(string commandText)
        {
            return ExecuteScalar(commandText, null);
        }
        /// <summary> 
        /// 执行一个查询语句，返回查询结果的第一行第一列 
        /// </summary> 
        /// <param name="sql">要执行的查询语句</param> 
        /// <param name="dbParameters">执行SQL查询语句所需要的参数，参数必须以它们在SQL语句中的顺序为准</param> 
        /// <returns></returns> 
        public Object ExecuteScalar(string commandText, SQLiteParameter[] dbParameters)
        {
            // 自动打开
            if (this.DbConnection == null)
            {
                this.AutoOpenClose = true;
                this.Open();
            }
            else if (this.DbConnection.State == ConnectionState.Closed)
            {
                this.Open();
            }

            this.dbCommand = this.DbConnection.CreateCommand();
            this.dbCommand.CommandText = commandText;
            if (this.dbTransaction != null)
            {
                this.dbCommand.Transaction = this.dbTransaction;
            }
            if (dbParameters != null)
            {
                this.dbCommand.Parameters.Clear();
                for (int i = 0; i < dbParameters.Length; i++)
                {
                    if (dbParameters[i] != null)
                    {
                        this.dbCommand.Parameters.Add(dbParameters[i]);
                    }
                }
            }
            object returnValue = this.dbCommand.ExecuteScalar();
            // 自动关闭
            if (this.AutoOpenClose)
            {
                this.Close();
            }
            else
            {
                this.dbCommand.Parameters.Clear();
            }
            return returnValue;
        }

        #endregion

        #region GetSchema 查询数据库中的所有数据类型信息 
        public DataTable GetSchema()
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                DataTable data = connection.GetSchema("TABLES");
                connection.Close();
                //foreach (DataColumn column in data.Columns) 
                //{ 
                //  Console.WriteLine(column.ColumnName); 
                //} 
                return data;
            }
        }
        #endregion

        #region public IDbTransaction BeginTransaction() 事务开始
        /// <summary>
        /// 事务开始
        /// </summary>
        /// <returns>事务</returns>
        public IDbTransaction BeginTransaction()
        {
            if (!this.InTransaction)
            {
                this.InTransaction = true;
                this.dbTransaction = this.DbConnection.BeginTransaction();
            }

            return this.dbTransaction;
        }
        #endregion

        #region public void CommitTransaction() 提交事务
        /// <summary>
        /// 提交事务
        /// </summary>
        public void CommitTransaction()
        {
            if (this.InTransaction)
            {
                this.InTransaction = false;
                this.dbTransaction.Commit();
            }
        }
        #endregion

        #region public void RollbackTransaction() 回滚事务
        /// <summary>
        /// 回滚事务
        /// </summary>
        public void RollbackTransaction()
        {
            if (this.InTransaction)
            {
                this.InTransaction = false;
                this.dbTransaction.Rollback();
            }

        }
        #endregion

        #region public void Close() 关闭数据库连接
        /// <summary>
        /// 关闭数据库连接
        /// </summary>
        public void Close()
        {
            if (this.dbConnection != null)
            {
                this.dbConnection.Close();
                this.dbConnection.Dispose();
            }

            this.Dispose();
        }
        #endregion

        #region public void Dispose() 内存回收
        /// <summary>
        /// 内存回收
        /// </summary>
        public void Dispose()
        {
            if (this.dbCommand != null)
            {
                this.dbCommand.Dispose();
            }
            if (this.dbDataAdapter != null)
            {
                this.dbDataAdapter.Dispose();
            }
            this.dbConnection = null;
        }
        #endregion
    }
}