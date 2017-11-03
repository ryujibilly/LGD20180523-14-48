using System;
using System.Collections.Generic;
using WebService;
using WebService.realdbws;
using Tool;
using Tool.Json;
using System.Web.Services.Protocols;
using System.Net;
using Newtonsoft;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Collections;
using System.Data;

namespace RealTimeDB
{
    /// <summary>
    /// 数据推送，业务逻辑类
    /// </summary>
    public class Pusher
    {
        public realdbservices _realdbws = new realdbservices();
        public realdbservices.UserNameHeader name = new realdbservices.UserNameHeader();
        public realdbservices.UserPassWordHeader password = new realdbservices.UserPassWordHeader();
        public NetworkCredential nc = new NetworkCredential();
        public Hashtable ht = new Hashtable();  //Hashtable 为webservice所需要的参数集
        public String strJson = String.Empty;
        public List<String> colName = new List<string>();
        public List<List<String>> colData = new List<List<string>>();

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

        public Pusher()
        {
            this.Username = "yuwenmao";
            this.Userpassword = "123";
            nc.UserName = "yuwenmao";
            nc.Password = "123";
            _realdbws.Credentials = nc;
            InitHashTable();

            strJson = JsonHepler.HashtableToJson(ht, 0);
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
            InitHashTable(username, password);

            strJson = JsonHepler.HashtableToJson(ht, 0);
        }

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
                jstring = _realdbws.GetAllRegions(strJson);
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
                Debug.WriteLine(ex.Message);
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

                jstring = _realdbws.GetAllRegions(strJson);

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

                jstring = _realdbws.GetAllInstName(strJson);

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
    }
}
