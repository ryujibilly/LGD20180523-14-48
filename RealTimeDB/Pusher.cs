﻿using System;
using System.Net;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Data;
using System.Web.Services.Protocols;
using WebService;
using WebService.realdbws;
using Tool;
using Tool.Json;
using Newtonsoft;
using Newtonsoft.Json;
using System.Threading;
using System.Collections.Concurrent;
using LGD.DAL.SQLite;
using System.Data.SQLite;
using Tool.Timer;
using System.Text;
using System.Net.NetworkInformation;

namespace RealTimeDB
{
    /// <summary>
    /// 仪器类型枚举
    /// </summary>
    public enum InstType { Log, MudLog, Drill };//测井，录井，钻井
    /// <summary>
    /// 数据推送--业务逻辑类
    /// </summary>
    public sealed class Pusher
    {
        //单例对象
        public  static readonly Pusher _pusher = new Pusher("yuwenmao","123");
        #region 字段属性
        public String url = "";
        public realdbservices _realdbws = new realdbservices();
        /// <summary>
        /// Webservice连接状态
        /// </summary>
        public bool realdbservices_Status = false;
        /// <summary>
        /// RealDB访问令牌
        /// </summary>
        public static bool canReadDB;
        /// <summary>
        /// RealDB访问的线程互斥锁
        /// </summary>
        private Mutex mtx;
        public realdbservices.UserNameHeader name = new realdbservices.UserNameHeader();
        public realdbservices.UserPassWordHeader password = new realdbservices.UserPassWordHeader();
        public NetworkCredential nc = new NetworkCredential();
        public Hashtable ht = new Hashtable();  //Hashtable 为webservice所需要的参数集
        public String strJsonSend = String.Empty;
        public String strJsonReceive = String.Empty;
        public List<String> colName = new List<string>();
        public List<List<String>> colData = new List<List<string>>();
        public List<String> selectedTabList = new List<string>();
        private ConcurrentQueue<DataTable> pushingDataTabQueue = new ConcurrentQueue<DataTable>();
        private DataTable indexTable = new DataTable();
        private List<int> startlabs = new List<int>();
        private String logid = "";
        private String instname = "";
        private List<List<String>> titleList = new List<List<String>>();
        private Dictionary<String, List<String>> titleDict = new Dictionary<string, List<string>>();
        private List<List<String>> dataList = new List<List<string>>();
        private Boolean isPushing = false;
        private Boolean isSynPush = false;
        public Boolean PushingQueueFull = false;
        public Thread PushingThread;
        public object sqliteLockObj = new object();
        //public MMTimer PushingTimer;
        /// <summary>
        /// 监视webservices网络状态的计时器
        /// </summary>
        public MMTimer GetHttpStatusTimer;
        private Dictionary<String,int> sendSumDic = new Dictionary<string, int>();
        private ConcurrentQueue<String> sendStatusQ = new ConcurrentQueue<string>();
        /// <summary>
        /// 各表最新的rowid
        /// </summary>
        private  Dictionary<String, int> lastInsertRowIDDic = new Dictionary<string, int>();
        /// <summary>
        /// 各表发送截止的rowid
        /// </summary>
        private  Dictionary<String, int> lastSentRowIDDic = new Dictionary<string, int>();
        private String username;
        private String userpassword;
        private SQLiteDBHelper dbhelper = new SQLiteDBHelper();

        public string Username
        {
            get
            {
                return username;
            }

            set
            {
                username = value;
            }
        }

        public string Userpassword
        {
            get
            {
                return userpassword;
            }

            set
            {
                userpassword = value;
            }
        }

        /// <summary>
        /// 存放用于推送的查询返回的DataTable
        /// </summary>
        public ConcurrentQueue<DataTable> PushingDataTabQueue
        {
            get
            {
                return pushingDataTabQueue;
            }

            set
            {
                pushingDataTabQueue = value;
            }
        }
        /// <summary>
        /// DateTime的索引表
        /// </summary>
        public DataTable IndexTable
        {
            get
            {
                return indexTable;
            }

            set
            {
                indexTable = value;
            }
        }
        /// <summary>
        /// 索引起始位
        /// </summary>
        public List<int> Startlabs
        {
            get
            {
                return startlabs;
            }

            set
            {
                startlabs = value;
            }
        }
        /// <summary>
        /// 井ID
        /// </summary>
        public string Logid
        {
            get
            {
                return logid;
            }

            set
            {
                logid = value;
            }
        }
        /// <summary>
        /// 仪器名
        /// </summary>
        public string Instname
        {
            get
            {
                return instname;
            }

            set
            {
                instname = value;
            }
        }
        /// <summary>
        /// 哈希表的Title列表
        /// </summary>
        public List<List<String>> TitleList
        {
            get
            {
                return titleList;
            }

            set
            {
                titleList = value;
            }
        }
        /// <summary>
        /// Title链表字典
        /// </summary>
        public Dictionary<string, List<string>> TitleDict
        {
            get
            {
                return titleDict;
            }

            set
            {
                titleDict = value;
            }
        }
        /// <summary>
        /// 哈希表的Data链表
        /// </summary>
        public List<List<string>> DataList
        {
            get
            {
                return dataList;
            }

            set
            {
                dataList = value;
            }
        }
        /// <summary>
        /// 是否在推送
        /// </summary>
        public bool IsPushing
        {
            get
            {
                return isPushing;
            }

            set
            {
                isPushing = value;
            }
        }
        /// <summary>
        /// 累计发送记录数目字典
        /// </summary>
        public Dictionary<string,int> SendSumDic
        {
            get
            {
                return sendSumDic;
            }

            set
            {
                sendSumDic = value;
            }
        }
        /// <summary>
        /// WITSML的推送状态
        /// </summary>
        public ConcurrentQueue<string> SendStatusQ
        {
            get
            {
                return sendStatusQ;
            }

            set
            {
                sendStatusQ = value;
            }
        }

        /// <summary>
        /// SQLiteDBHelper
        /// </summary>
        public SQLiteDBHelper Dbhelper
        {
            get
            {
                return dbhelper;
            }

            set
            {
                dbhelper = value;
            }
        }
        /// <summary>
        /// 最新写入数据库记录的rowid字典 <表名,rowid>
        /// </summary>
        public Dictionary<string, int> LastInsertRowIDDic
        {
            get
            {
                return lastInsertRowIDDic;
            }

            set
            {
                lastInsertRowIDDic = value;
            }
        }
        /// <summary>
        /// 最后推送数据记录的rowid字典 <表名,rowid>
        /// </summary>
        public Dictionary<string, int> LastSentRowIDDic
        {
            get
            {
                return lastSentRowIDDic;
            }

            set
            {
                lastSentRowIDDic = value;
            }
        }
        /// <summary>
        /// 所有表是否积压数据
        /// </summary>
        public Boolean IsSynPush
        {
            get
            {
                return isSynPush;
            }

            set
            {
                isSynPush = value;
            }
        }
        /// <summary>
        /// RealDB访问的线程互斥锁
        /// </summary>
        public Mutex MTX
        {
            get
            {
                return mtx;
            }

            set
            {
                mtx = value;
            }
        }
        #endregion

        /// <summary>
        /// 构造方法
        /// </summary>
        public Pusher()
        {
            this.Username = "yuwenmao";
            this.Userpassword = "123";
            nc.UserName = "yuwenmao";
            nc.Password = "123";
            _realdbws.Credentials = nc;
            PushingThread = new Thread(new ThreadStart(StartPushing));
            InitHashTable();
        }



        /// <summary>
        /// 使用用户名+密码构造方法
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public Pusher(String username,String password)
        {
            this.Username = username;
            this.Userpassword = password;
            nc.UserName = username;
            nc.Password = password;
            _realdbws.Credentials = nc;
            PushingThread = new Thread(new ThreadStart(StartPushing));
            //PushingTimer = new MMTimer(StartPushing);
            //GetHttpStatusTimer = new MMTimer(GetHttpStatus);
            //this.GetHttpStatusTimer.Interval = 30000;
            InitHashTable(username, password);
        }
        /// <summary>
        /// 使用SQLiteDBHelper+用户名+密码构造方法
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public Pusher(String username, String password,SQLiteDBHelper helper)
        {
            this.Username = username;
            this.Userpassword = password;
            nc.UserName = username;
            nc.Password = password;
            _realdbws.Credentials = nc;
            PushingThread = new Thread(new ThreadStart(StartPushing));
            this.Dbhelper = helper;
        }
        //public void InitPusherThreadPool()
        //{
        //    ThreadPool.SetMaxThreads(5, 5);
        //    ThreadPool.QueueUserWorkItem(new WaitCallback(StartPushing), PushingDataTabQueue);
        //}
        /// <summary>
        /// 强制回收对象
        /// </summary>
        public void Dispose()
        {
            int ge = GC.GetGeneration(this);
            GC.Collect(ge);
        }
        /// <summary>
        /// 空哈希表初始化方法
        /// </summary>
        /// <returns>哈希表</returns>
        public Hashtable InitHashTable()
        {
            ht.Clear();
            ht.Add("user", "yuwenmao");
            ht.Add("password", "123");
            ht.Add("size", "0");
            ht.Add("msg", "");
            ht.Add("return", "");
            ht.Add("title", "");
            ht.Add("data", "");
            return ht;
        }
        /// <summary>
        /// 用户名密码的哈希表构造方法
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <returns>哈希表</returns>
        public Hashtable InitHashTable(String username,String password)
        {
            ht.Clear();
            ht.Add("user", username);
            ht.Add("password", password);
            ht.Add("size", "0");
            ht.Add("msg", "");
            ht.Add("return", "");
            ht.Add("title", "");
            ht.Add("data", "");
            return ht;
        }
        /// <summary>
        /// 初始化没有header的哈希表
        /// </summary>
        /// <param name="hasHeader">是否包含Header</param>
        /// <param name="_title">单个title</param>
        /// <param name="_data">单个data</param>
        /// <returns></returns>
        public Hashtable InitHashTable(bool hasHeader,String _title,String _data)
        {
            if (!hasHeader)
            {
                ht.Clear();
                ht.Add("user", "yuwenmao");
                ht.Add("password", "123");
                ht.Add("size", "1");
                ht.Add("msg", "");
                ht.Add("return", "");
                ht.Add("title", "[" + "\"" + _title + "\"" + "]");
                ht.Add("data", "[" + "\"" + _data + "\"" + "]");
            }
            return ht;
        }
        /// <summary>
        /// 初始化没有header的哈希表
        /// </summary>
        /// <param name="hasHeader">是否包含Header</param>
        /// <param name="_titles">title 列表</param>
        /// <param name="_datas">data 列表</param>
        /// <returns></returns>
        public Hashtable InitHashTable(bool hasHeader, List<String> _titles, List<String> _datas)
        {
            if (!hasHeader)
            {
                ht.Clear();
                ht.Add("user", "yuwenmao");
                ht.Add("password", "123");
                ht.Add("size", "1");
                ht.Add("msg", "");
                ht.Add("return", "");
                ht.Add("title", JsonHepler.List2JsonAarry(_titles));
                ht.Add("data", JsonHepler.List2JsonAarry(_datas));
            }
            return ht;
        }

        /// <summary>
        /// 生成推送Json字符串
        /// </summary>
        /// <param name="logid">井id</param>
        /// <param name="recordno">表号</param>
        /// <param name="size">记录size</param>
        /// <param name="instname">仪器名</param>
        /// <param name="_curvename">曲线名</param>
        /// <param name="_curvedata">曲线数据</param>
        /// <returns></returns>
        public String InitCurveTable(String logid,String recordno,int size,String instname, List<String> _curvename,DataTable _curvedata)
        {
            String temp0 = "";
            String temp1 = "";
            String temp2 = "";
            DataTable dt = _curvedata.Copy();
            ht.Clear();
            ht.Add("logid", logid);
            ht.Add("recordno", recordno);
            ht.Add("instname", instname);
            ht.Add("indexname", "DATE,TIME");
            ht.Add("user", "yuwenmao");
            ht.Add("password", "123");
            ht.Add("size", size);
            ht.Add("msg", "");
            ht.Add("return", size);
            temp0 = JsonHepler.HashtableToJson(ht, 0);

            //title

            string strCurveNames= "\"title\" :[";
            DataRow rowCurveData = dt.Rows[0];
            foreach (String cv in _curvename)
            {
                String elem = "\"";
                if (cv.Length < 1)
                {
                    elem += "-999.25\"";
                }
                else
                {
                    elem += cv+"\"";
                }
                strCurveNames += elem + ",";
            }
            strCurveNames=strCurveNames.Remove(strCurveNames.Length - 1);
            strCurveNames += "]";
            temp1= temp0.Insert(1,strCurveNames+",");
            //data

            string strCurveData = "";
            strCurveData += createDataString(dt);
            temp2=temp1.Insert(1,strCurveData+"],");
            return temp2;
        }
        /// <summary>
        /// 生成曲线数据的Json字符串
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private String createDataString(DataTable dt)
        {
            string strCurveData = "\"data\" :[";
            for(int j=0;j<dt.Rows.Count;j++)
            {
                DataRow rowCurveData = dt.Rows[j];
                strCurveData += "[";
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    string elem = "\"";
                    if (rowCurveData[i].ToString().Length < 1)
                    {
                        elem += "-999.25\"";
                    }
                    else
                    {
                        elem += rowCurveData[i].ToString() + "\"";
                    }
                    strCurveData += elem + ",";
                }
                strCurveData = strCurveData.Remove(strCurveData.Length - 1);
                strCurveData += "],";
            }
            strCurveData = strCurveData.Remove(strCurveData.Length - 1);
            return strCurveData;
        }

        /// <summary>
        /// 写曲线
        /// </summary>
        /// <returns>写的记录条数</returns>
        public int WriteCurveData(String title, String regionName, out String jstring)
        {
            int sum = 0;
            try
            {
                InitHashTable(false, title, regionName);
                colName.Clear();
                colData.Clear();
                strJsonSend = JsonHepler.HashtableToJson(ht, 0);
                jstring = _realdbws.WriteCurveData(strJsonSend);
                Hashtable tempHT = (Hashtable)JsonConvert.DeserializeObject(jstring, typeof(Hashtable));
                //获取列名
                colName = JsonHepler.getJsonCol(tempHT, "title");
                //获取数据
                colData = JsonHepler.getJsonData(tempHT, "data", colName.Count);
                //return JsonHepler.List2DataTable(colData, colName);
            }
            catch (System.Exception ex)
            {
                Debug.WriteLine(ex.Message + "\r\t==========" + "pusher.GetAllLogsByWellId()");
                jstring = String.Empty;
                //return null;
            }
            return sum;
        }

        /// <summary>
        /// 连接测试
        /// </summary>
        /// <returns>是否连接异常</returns>
        public bool ConnectTest()
        {
            try
            {
                String jstring;
                colName.Clear();
                colData.Clear();
                InitHashTable();
                strJsonSend = JsonHepler.HashtableToJson(ht, 0);
                jstring = _realdbws.GetAllRegions(strJsonSend);
                Hashtable tempHT = (Hashtable)JsonConvert.DeserializeObject(jstring, typeof(Hashtable));
                //获取列名
                colName = JsonHepler.getJsonCol(tempHT, "title");
                //获取数据
                colData = JsonHepler.getJsonData(tempHT, "data", colName.Count);
                JsonHepler.List2DataTable(colData, colName);
                return true;
            }
            catch (System.Exception ex)
            {
                Debug.WriteLine(ex.Message+"\r\t=========="+ "pusher.ConnectTest()");
                return false;
            }
        }

        /// <summary>
        /// 获取工区信息
        /// </summary>
        /// <param name="jstring">输出JsonString</param>
        /// <returns>Jstring转换成DataTable</returns>
        public DataTable GetAllRegions(out String jstring)
        {
            try
            {
                colName.Clear();

                colData.Clear();

                strJsonSend = JsonHepler.HashtableToJson(ht, 0);

                jstring = _realdbws.GetAllRegions(strJsonSend);

                Hashtable tempHT = (Hashtable)JsonConvert.DeserializeObject(jstring, typeof(Hashtable));

                //获取列名
                colName = JsonHepler.getJsonCol(tempHT, "title");
                //获取数据
                colData = JsonHepler.getJsonData(tempHT, "data", colName.Count);

                return JsonHepler.List2DataTable(colData, colName);
            }
            catch (System.Exception ex)
            {
                Debug.WriteLine(ex.Message + "\r\t==========" + "pusher.GetAllRegions()");
                jstring = String.Empty;
                return null;
            }

        }
        /// <summary>
        /// 获取仪器信息
        /// </summary>
        /// <param name="jstring">输出JsonString</param>
        /// <returns>Jstring转换成DataTable</returns>
        public DataTable GetAllInstName(out String jstring)
        {
            try
            {
                colName.Clear();

                colData.Clear();

                strJsonSend = JsonHepler.HashtableToJson(ht, 0);

                jstring = _realdbws.GetAllInstName(strJsonSend);

                Hashtable tempHT = (Hashtable)JsonConvert.DeserializeObject(jstring, typeof(Hashtable));

                //获取列名
                colName = JsonHepler.getJsonCol(tempHT, "title");
                //获取数据
                colData = JsonHepler.getJsonData(tempHT, "data", colName.Count);

                return JsonHepler.List2DataTable(colData, colName);
            }
            catch (System.Exception ex)
            {
                Debug.WriteLine(ex.Message + "\r\t==========" + "pusher.GetAllInstName()");
                jstring = "";
                DataTable dt = new DataTable();
                return dt;
            }
        }

        /// <summary>
        /// 通过仪器名获得仪器信息
        /// </summary>
        /// <param name="instName">仪器名称</param>
        /// <param name="jstring">输出JsonString</param>
        /// <returns>Jstring转换成DataTable</returns>
        public DataTable GetInstInfoByName(String instName,out String jstring)
        {
            try
            {
                colName.Clear();

                colData.Clear();

                ht.Add("instname", instName);

                strJsonSend = JsonHepler.HashtableToJson(ht, 0);

                jstring = _realdbws.GetInstInfoByName(strJsonSend);

                Hashtable tempHT = (Hashtable)JsonConvert.DeserializeObject(jstring, typeof(Hashtable));

                //获取列名
                colName = JsonHepler.getJsonCol(tempHT, "title");
                //获取数据
                colData = JsonHepler.getJsonData(tempHT, "data", colName.Count);

                return JsonHepler.List2DataTable(colData, colName);
            }
            catch (System.Exception ex)
            {
                Debug.WriteLine(ex.Message + "\r\t==========" + "pusher.GetInstInfoByName()");
                jstring = String.Empty;
                return null;
            }
        }
        /// <summary>
        /// 通过工区ID获取井信息
        /// </summary>
        /// <param name="regionid"></param>
        /// <param name="jstring"></param>
        /// <returns></returns>
        public DataTable GetAllWellsByRegionId(String regionid,out String jstring)
        {
            try
            {
                InitHashTable();
                colName.Clear();

                colData.Clear();

                ht.Add("regionid", regionid);

                strJsonSend = JsonHepler.HashtableToJson(ht, 0);

                jstring = _realdbws.GetAllWellsByRegionId(strJsonSend);

                Hashtable tempHT = (Hashtable)JsonConvert.DeserializeObject(jstring, typeof(Hashtable));

                //获取列名
                colName = JsonHepler.getJsonCol(tempHT, "title");
                //获取数据
                colData = JsonHepler.getJsonData(tempHT, "data", colName.Count);

                return JsonHepler.List2DataTable(colData, colName);
            }
            catch (System.Exception ex)
            {
                Debug.WriteLine(ex.Message + "\r\t==========" + "pusher.GetAllWellsByRegionId()");
                jstring = String.Empty;
                return null;
            }
        }

        /// <summary>
        /// 通过井ID获取井次信息
        /// </summary>
        /// <param name="regionid"></param>
        /// <param name="jstring"></param>
        /// <returns></returns>
        public DataTable GetAllLogsByWellId(String wellid, out String jstring)
        {
            try
            {
                InitHashTable();
                colName.Clear();

                colData.Clear();

                ht.Add("wellid", wellid);

                strJsonSend = JsonHepler.HashtableToJson(ht, 0);

                jstring = _realdbws.GetAllLogsByWellId(strJsonSend);

                Hashtable tempHT = (Hashtable)JsonConvert.DeserializeObject(jstring, typeof(Hashtable));

                //获取列名
                colName = JsonHepler.getJsonCol(tempHT, "title");
                //获取数据
                colData = JsonHepler.getJsonData(tempHT, "data", colName.Count);

                return JsonHepler.List2DataTable(colData, colName);
            }
            catch (System.Exception ex)
            {
                Debug.WriteLine(ex.Message + "\r\t==========" + "pusher.GetAllLogsByWellId()");
                jstring = String.Empty;
                return null;
            }
        }

        /// <summary>
        /// 添加工区
        /// </summary>
        /// <param name="regionName">工区名称</param>
        /// <returns>是否成功</returns>
        public DataTable AddRegion(String title,String regionName,out String jstring)
        {
            try
            {
                InitHashTable(false,title,regionName);
                colName.Clear();
                colData.Clear();
                strJsonSend = JsonHepler.HashtableToJson(ht, 0);
                jstring = _realdbws.AddRegion(strJsonSend);
                Hashtable tempHT = (Hashtable)JsonConvert.DeserializeObject(jstring, typeof(Hashtable));
                //获取列名
                colName = JsonHepler.getJsonCol(tempHT, "title");
                //获取数据
                colData = JsonHepler.getJsonData(tempHT, "data", colName.Count);
                return JsonHepler.List2DataTable(colData, colName);
            }
            catch (System.Exception ex)
            {
                Debug.WriteLine(ex.Message + "\r\t==========" + "pusher.GetAllLogsByWellId()");
                jstring = String.Empty;
                return null;
            }
        }
        /// <summary>
        /// 推送数据
        /// </summary>
        void StartPushing()
        {
            String SendJsonStr = "";
            String recvJsonStr = "";
            try
            {
                int i = 0;
                while (true)
                {
                    if (PushingDataTabQueue.Count > 0 )
                    {
                        DataTable dt = new DataTable();
                        DataTable dt_orgin = new DataTable();
                        if (PushingDataTabQueue.TryDequeue(out dt))
                        {
                            //表号+仪器，断句
                            String RecordName = dt.TableName;
                            String RecordNo = RecordName.Split('-')[0];
                            List<String> curvenames = new List<string>();
                            if (TitleDict.TryGetValue(RecordName, out curvenames))
                            {
                                dt_orgin = dt.Copy();
                                int Size = dt.Rows.Count;
                                int rowid = int.Parse(dt.Rows[dt.Rows.Count - 1].ItemArray[0].ToString());
                                //移除rowid 列
                                dt.Columns.RemoveAt(0);
                                SendJsonStr = InitCurveTable(Logid, RecordNo, Size, Instname.ToLower(), curvenames, dt);
                                if (this.Ping("10.242.0.186"))
                                {
                                    recvJsonStr = _realdbws.WriteCurveData(SendJsonStr);
                                    //计数
                                    if (recvJsonStr.Contains("ok"))                                    //各表累计发送记录数
                                                                                                       //SendSumDic[RecordNo] += Size;
                                    {
                                        //各表推送数据的最后一条记录rowid
                                        lastSentRowIDDic[RecordNo] = rowid;
                                        string status = ">>>" + i++.ToString("D4") + "Date：" +
                                            DateTime.Now.ToShortDateString() + "..Time:" + DateTime.Now.ToLongTimeString() +
                                            "..TabNo:" + RecordNo + "..Records:" + rowid + "<<<";
                                        SendStatusQ.Enqueue(status);
                                    }
                                }
                            }
                            else continue;
                        }
                    }
                    Thread.Sleep(50);
                }
            }
            catch (System.Exception ex)
            {
                Trace.WriteLine(ex.Message+ "<======StartPushing()异常=====> \r\n");
                PushingDataTabQueue = new ConcurrentQueue<DataTable>();
                PushingThread.Abort();
                PushingThread.Start();
            }
        }
        /// <summary>
        /// 监视最新rowid
        /// </summary>
        public void RowidMonitoring()
        {
            try
            {
                lock (sqliteLockObj)
                {
                    //最新rowid
                    getLastRowID(out lastInsertRowIDDic);
                }
            }
            catch (System.Exception ex)
            {
                Debug.WriteLine(ex.Message+ ">>>Pusher.cs==>RowidMonitoring(）计时器托管线程异常~!<<<");
            }
        }

        /// <summary>
        /// 获取即将推送的数据(指定时间)
        /// </summary>
        public void getData(SQLiteDBHelper helper,List<String> selecttablist,String instru,String beginDate,String beginTime,String endDate,String endTime)
        {
            try
            {
                lock (sqliteLockObj)
                {
                    foreach (String tabname in selecttablist)
                    {
                        DataTable dt = new DataTable();
                        dt = helper.getPushingData(instru, tabname, beginDate, beginTime, endDate, endTime);
                        //if (PushingDataTabQueue.Count >= 100)
                        //    PushingQueueFull = true;
                        //else
                            PushingDataTabQueue.Enqueue(dt);
                    }
                }
            }
            catch (System.Exception ex)
            {
                Debug.WriteLine(ex.Message + "\r\t==========" + "pusher.getDataSQLiteDBHelper helper,List<String> selecttablist,String instru,String beginDate,String beginTime,String endDate,String endTime)");
            } 
        }

        /// <summary>
        /// 静态推送数据进入队列
        /// </summary>
        /// <param name="helper">SQLitehelper</param>
        /// <param name="selecttablist">推送的表名列</param>
        /// <param name="instru">仪器</param>
        /// <param name="_fps">单词推送表数量</param>
        /// <returns>是否推送完毕</returns>
        public void getData(SQLiteDBHelper helper, List<String> selecttablist, String instru,int _fps)
        {
            IsSynPush = false;
            try
            {
                //锁定入队操作，加互斥锁
                //MTX = new Mutex(true, "ReaddingDB",out canReadDB);

                foreach (String tabname in selecttablist)
                {
                    int rowidstart = 0;
                    int rowidend = 0;
                    DataTable dt = new DataTable();
                    //起始rowid
                    int _startindex = LastSentRowIDDic[tabname];
                    //截至rowid
                    int _endindex = LastInsertRowIDDic[tabname];
                    //入队条件 
                    while (_startindex >= 0 && _endindex >= 0 && _startindex + _fps <= _endindex)
                    {
                        lock (sqliteLockObj)
                        {
                            dt = helper.getPushingData(instru, tabname, _startindex, _fps, out rowidstart, out rowidend).Copy();
                        }
                        _startindex += _fps;
                        //if (PushingDataTabQueue.Count >= 100)
                        //    PushingQueueFull = true;
                        //else
                            PushingDataTabQueue.Enqueue(dt);
                        IsSynPush = true;
                        if (_endindex - _startindex < _fps)
                        {
                            SynchroData(helper, selectedTabList, Instname);
                            break;
                        }

                    }
                }
                //完成入队操作，释放互斥锁
                //MTX.ReleaseMutex();

            }
            catch (System.Exception ex)
            {
                Debug.WriteLine(ex.Message + "\r\t==========" + "pusher.getData(SQLiteDBHelper helper, List<String> selecttablist, String instru,int _fps)");
            }
        }
        /// <summary>
        /// 将实时数据放入待推送队列中
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="selecttablist"></param>
        /// <param name="instru"></param>
        public void SynchroData(SQLiteDBHelper helper, List<String> selecttablist, String instru)
        {
            try
            {
                ////锁定入队操作，加互斥锁
                //MTX = new Mutex(true, "ReaddingDB", out canReadDB);
                int rowid = 0;
                foreach (String tabname in selecttablist)
                {
                    DataTable dt = new DataTable();
                    //起始rowid
                    int _startindex = LastSentRowIDDic[tabname];
                    //截至rowid
                    int _endindex = LastInsertRowIDDic[tabname];
                    if (_endindex > _startindex)
                        lock (sqliteLockObj)
                        {
                            dt = helper.getPushingData(instru, tabname, LastSentRowIDDic[tabname], out rowid);
                        }
                    if (rowid > 0)
                    {
                        LastInsertRowIDDic[tabname] = rowid;
                        if (dt.Rows.Count > 0)
                        {
                            //if (PushingDataTabQueue.Count >= 100)
                            //    PushingQueueFull = true;
                            //else
                                PushingDataTabQueue.Enqueue(dt);
                        }
                        //完成入队后  startindex赋值为最新rowid
                        LastSentRowIDDic[tabname] = rowid;
                    }
                }
                IsSynPush = false;
                ////完成入队操作，释放互斥锁
                //MTX.ReleaseMutex();
            }
            catch (System.Exception ex)
            {
                Debug.WriteLine(ex.Message + "\r\t==========" + "pusher.getDataSQLiteDBHelper helper,List<String> selecttablist,String instru,String beginDate,String beginTime,String endDate,String endTime)");
            }
        }
        /// <summary>
        /// 获取所有表当前记录数rowid
        /// </summary>
        /// <param name="lastrowid"></param>
        private void getLastRowID(out Dictionary<String,int> lastrowiddic)
        {
            try
            {
                Properties.Settings.Default.Last_Insert_RowID = "";

                lastrowiddic = new Dictionary<string, int>();
                int lastrowid = -1;
                foreach (String tabname in selectedTabList)
                {
                    lock (sqliteLockObj)
                    {
                        lastrowid = Dbhelper.getLastRowID(tabname, Instname);
                    }
                    lastrowiddic.Add(tabname,lastrowid);
                    Properties.Settings.Default.Last_Insert_RowID += tabname + "-" + lastrowid + "\r\n";
                }
            }
            catch (System.Exception ex)
            {
                Debug.WriteLine(ex.Message + "\r\t==========" + "pusher.getLastIndexgetLastRowID(out Dictionary<String,int> lastrowiddic)");
                lastrowiddic = new Dictionary<string, int>();
            }

        }
        /// <summary>
        /// 获取WebService网络连接状态,异常则挂起推送线程，恢复正常则继续推送线程。
        /// </summary>
        private void GetHttpStatus(uint uTimerID, uint uMsg, UIntPtr dwUser, UIntPtr dw1, UIntPtr dw2)
        {
            try
            {
                if(Ping(this.url))
                {
                    realdbservices_Status = true;
                    IsPushing = true;
                    PushingThread.Suspend();
                    //PushingTimer.Stop();
                }
                else
                {
                    realdbservices_Status = false;
                    IsPushing = false;
                    PushingThread.Resume();
                    //PushingTimer.Start(true);
                }
            }
            catch (System.Exception ex)
            {
                Debug.WriteLine(ex.Message + "\r\t==========" + "pusher.GetHttpStatus()");
            }
        }


        /// <summary>
        /// 是否能 Ping 通指定的主机
        /// </summary>
        /// <param name="ip">ip 地址或主机名或域名</param>
        /// <returns>true 通，false 不通</returns>
        public bool Ping(string ip)
        {
            Ping p = new Ping();
            PingOptions options = new System.Net.NetworkInformation.PingOptions();
            options.DontFragment = true;
            string data = "Test Data!";
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            int timeout = 5000; // Timeout 时间，单位：毫秒
            PingReply reply = p.Send(ip, timeout, buffer, options);
            if (reply.Status == IPStatus.Success)
                return true;
            else
                return false;
        }
        /// <summary>
        /// 初始化 推送rowid字典
        /// </summary>
        public void initSentRowIDDic()
        {
            foreach (string recno in selectedTabList)
                Pusher._pusher.LastSentRowIDDic.Add(recno, 0);
        }
        /// <summary>
        /// 初始化 实时库rowid字典
        /// </summary>
        public void initInsertRowIDDic()
        {
            foreach (string recno in selectedTabList)
                Pusher._pusher.LastInsertRowIDDic.Add(recno, 0);
        }
    }
}
