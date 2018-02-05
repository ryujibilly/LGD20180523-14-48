using System;
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

namespace RealTimeDB
{
    /// <summary>
    /// 仪器类型枚举
    /// </summary>
    public enum InstType { Log, MudLog, Drill };//测井，录井，钻井
    /// <summary>
    /// 数据推送--业务逻辑类
    /// </summary>
    public class Pusher
    {
        #region 字段属性
        public realdbservices _realdbws = new realdbservices();
        public realdbservices.UserNameHeader name = new realdbservices.UserNameHeader();
        public realdbservices.UserPassWordHeader password = new realdbservices.UserPassWordHeader();
        public NetworkCredential nc = new NetworkCredential();
        public Hashtable ht = new Hashtable();  //Hashtable 为webservice所需要的参数集
        public String strJsonSend = String.Empty;
        public String strJsonReceive = String.Empty;
        public List<String> colName = new List<string>();
        public List<List<String>> colData = new List<List<string>>();
        private ConcurrentQueue<DataTable> pushingDataTabQueue = new ConcurrentQueue<DataTable>();
        private DataTable indexTable = new DataTable();
        private List<int> startlabs = new List<int>();
        private String logid = "";
        private String instname = "";
        private List<List<String>> titleList = new List<List<String>>();
        private Dictionary<String, List<String>> titleDict = new Dictionary<string, List<string>>();
        private List<List<String>> dataList = new List<List<string>>();
        private Boolean isPushing = false;
        public Thread PushingThread;

        private String username;
        private String userpassword;

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
            initIndexTable();
            //strJson = JsonHepler.HashtableToJson(ht, 0);
            
        }
        /// <summary>
        /// 使用用户名密码构造方法
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
            InitHashTable(username, password);
            initIndexTable();
            //strJson = JsonHepler.HashtableToJson(ht, 0);
        }

        /// <summary>
        /// 初始化推送进程索引表
        /// </summary>
        private void initIndexTable()
        {
            DataColumn dc1 = new DataColumn("TabId", Type.GetType("System.String"));
            DataColumn dc2 = new DataColumn("Date", Type.GetType("System.String"));
            DataColumn dc3 = new DataColumn("Time", Type.GetType("System.String"));
            DataColumn dc4 = new DataColumn("StartIndex", Type.GetType("System.String"));
            DataColumn dc5 = new DataColumn("EndIndex", Type.GetType("System.String"));
            IndexTable.Columns.Add(dc1);
            IndexTable.Columns.Add(dc2);
            IndexTable.Columns.Add(dc3);
            IndexTable.Columns.Add(dc4);
            IndexTable.Columns.Add(dc5);
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
        /// 填充曲线HashTable
        /// </summary>
        /// <param name="_curvename"></param>
        /// <param name="curvedata"></param>
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
            catch (System.Exception)
            {
                throw;
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
                jstring = _realdbws. WriteCurveData(strJsonSend);
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
        /// 推送数据
        /// </summary>
        void StartPushing()
        {
            try
            {
                while (IsPushing)
                {
                    if (PushingDataTabQueue.Count > 0 && IndexTable.Rows.Count > 0)
                    {
                        DataTable dt = new DataTable();
                        if (PushingDataTabQueue.TryDequeue(out dt))
                        {
                            String RecordName = dt.TableName;
                            String RecordNo = RecordName.Split('-')[0];
                            List<String> curvenames = new List<string>();
                            if (TitleDict.TryGetValue(RecordName, out curvenames))
                            {
                                int Size = dt.Rows.Count;
                                dt.Columns.RemoveAt(0);
                                String SendJsonStr = InitCurveTable(Logid, RecordNo, Size, Instname.ToLower(), curvenames, dt);
                                String recvJsonStr = _realdbws.WriteCurveData(SendJsonStr);
                            }
                            else continue;
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// 创建推送数据的Json包
        /// </summary>
        /// <returns></returns>
        private String CreatePushingDataBag()
        {
            String jsonStr="";
            Hashtable ht = new Hashtable();
            return jsonStr;
        }

        /// <summary>
        /// 获取即将推送的数据
        /// </summary>
        public void getData(SQLiteDBHelper helper,List<String> selecttablist,String instru,String beginDate,String beginTime,String endDate,String endTime)
        {
            try
            {
                foreach (String tabname in selecttablist)
                {
                   PushingDataTabQueue.Enqueue(helper.getPushingData(instru, tabname, beginDate, beginTime, endDate, endTime));
                }
            }
            catch (System.Exception ex)
            {
                Debug.WriteLine(ex.Message + "\r\t==========" + "pusher.getData()");
            }
        }
        /// <summary>
        /// 获取即将推送的数据
        /// </summary>
        /// <returns>缓存是否读取完</returns>
        public bool getData(SQLiteDBHelper helper, List<String> selecttablist, String instru, String beginDate, String beginTime,int _fps)
        {
            bool isOver = false;
            try
            {
                foreach (String tabname in selecttablist)
                {
                    int rowidstart = 0;
                    int rowidend = 0;
                    DataTable dt = new DataTable();
                    int _startindex = getLastIndex(tabname,IndexTable);
                    if (_startindex >=0)
                    {
                        dt = helper.getPushingData(instru, tabname, _startindex, _fps, out rowidstart, out rowidend).Copy();
                        String strDate = dt.Rows[dt.Rows.Count - 1].ItemArray[5].ToString();
                        String strTime = dt.Rows[dt.Rows.Count - 1].ItemArray[6].ToString();
                        PushingDataTabQueue.Enqueue(dt);
                        DataRow dr = IndexTable.NewRow();
                        dr[0] = tabname;
                        dr[1] = strDate;
                        dr[2] = strTime;
                        //起始rowid
                        dr[3] = rowidstart;
                        //截至rowid
                        dr[4] = rowidend;
                        IndexTable.Rows.Add(dr);
                    }
                    if ((rowidend - rowidstart + 1) < _fps)
                    {
                        isOver = true;
                        continue;
                    }
                }
                return isOver;
            }
            catch (System.Exception ex)
            {
                Debug.WriteLine(ex.Message + "\r\t==========" + "pusher.getData()");
                return false;
            }
        }
        /// <summary>
        /// 从索引表里查找对应表的最后一次索引
        /// </summary>
        /// <param name="tabname"></param>
        /// <param name="_indextab"></param>
        /// <returns>最后一个索引值</returns>
        private int getLastIndex(string tabname,DataTable _indextab)
        {
            int lastindex = 0;
            int i = _indextab.Rows.Count - 1;
            while (i>=0)
            {
                if (_indextab.Rows[i].ItemArray[0].ToString() == tabname)
                {
                    lastindex = int.Parse(_indextab.Rows[i].ItemArray[4].ToString());
                    break;
                }
                else i--;
            }
            return lastindex;
        }
    }
}
