﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Configuration;
using System.Data.Common;
using System.Data.SQLite;
using System.IO;
using System.ComponentModel;
using System.Diagnostics;

namespace LGD.DAL.SQLite
{
    /// <summary> 
    /// 说明：这是一个针对System.Data.SQLite的数据库常规操作封装的通用类。 
    ///  2017-7-27
    /// </summary>    
    public class SQLiteDBHelper
    {
        #region 字段、属性
        /// <summary>
        /// 单例模式对象
        /// </summary>
        public static SQLiteDBHelper _sqliteHelper = new SQLiteDBHelper();

        private String targetDBPath = String.Empty;
        private String dbPath = String.Empty;
        private String connectionString = String.Empty;
        private String targetConString= String.Empty;
        private SQLiteTransaction dbTransaction = null;
        private bool inTransaction = false;
        /// <summary>
        /// 当前数据库文件路径
        /// </summary>
        public String DBPath
        {
            get { return dbPath; }
            set { dbPath = value; }
        }
        /// <summary>
        /// 目标数据库文件路径
        /// </summary>
        public string TargetDBPath
        {
            get
            {
                return TargetDBPath;
            }

            set
            {
                TargetDBPath = value;
            }
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
        /// <summary>
        /// 目标数据库连接字符串
        /// </summary>
        public string TargetConString
        {
            get
            {
                return targetConString;
            }

            set
            {
                targetConString = value;
            }
        }

        #region 数据库连接必要条件参数
        private SQLiteConnection dbConnection = null;
        private SQLiteConnection targetDBConnection = null;
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
        private SQLiteCommand targetDBCommand = null;
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
        /// 目标数据库连接
        /// </summary>
        public SQLiteConnection TargetDBConnection
        {
            get
            {
                return targetDBConnection;
            }

            set
            {
                targetDBConnection = value;
            }
        }


        #endregion

        #endregion

        /// <summary> 
        /// 构造函数 
        /// </summary> 
        public SQLiteDBHelper()
        {
            connectionString = string.Empty;
            connectionString = "Data Source=" + dbPath;
        }

        public SQLiteDBHelper(String path)
        {
            connectionString = string.Empty;
            connectionString = "Data Source=" + path;
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

        #region 建立本地数据库

        /// <summary> 
        /// 创建SQLite数据库文件 
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
        public void CreateDB(String DBName)
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
                SQLiteConnection.CreateFile(DBName+".db");
            }
        }
        /// <summary>
        /// 拷贝数据库文件
        /// </summary>
        /// <param name="sourcepath">源数据库路径</param>
        /// <param name="destpath">目标数据库路径</param>
        public void DBCopy(String sourcepath,String destpath)
        {
            try
            {
                if (!File.Exists(sourcepath))
                {
                    DBPath = sourcepath;
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
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(">>>SQLiteDBHelper.cs ->DBCopy()<<<\r\t"+ex.Message);
            }
        }
        /// <summary>
        /// 写入witsdata
        /// </summary>
        /// <param name="tabID">表号</param>
        /// <param name="wt">表</param>
        /// <returns>写入记录数量</returns>
        public int InsertWitsData(String tabID,WitsTable wt)
        {
            int sum = 0;
            SQLiteConnection conn = this.DbConnection;
            SQLiteTransaction tran= conn.BeginTransaction();
            SQLiteCommand cmd = new SQLiteCommand(conn);
            cmd.Transaction = tran;
            String index;
            String value;
            try
            {
                this.Open();
                //校正后数据
                while (wt.getNextRow(out index, out value))
                {
                    //设置带参数的Transact-SQL语句
                    cmd.CommandText = "insert into [00_WitsData] values(@TabID,@ItemID, @Data)";
                    cmd.Parameters.AddRange(new[]
                    {
                        new SQLiteParameter("@TabID",tabID),
                        new SQLiteParameter("@ItemID",index),
                        new SQLiteParameter("@Data",value)
                    });
                    cmd.ExecuteNonQuery();
                    sum++;
                }
                tran.Commit();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(">>>SQLiteHelper.cs-->InsertWitsData(String,WitsTable)-->tran事务异常!<<<---- \r\t"+ ex.Message);
                tran.Rollback();
            }
            return sum;
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