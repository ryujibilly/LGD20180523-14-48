using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Xml;

namespace LGD.DAL.SQLite
{
    /// <summary>
    /// WitsConfig 信息类
    /// </summary>
    public class WitsConfigInfo
    {
        private String instrument;
        private List<String> tabid;
        private List<String> itemid;
        private List<String> shotname;
        private String xmlpath = AppDomain.CurrentDomain.BaseDirectory + "WITS.xml";
        /// <summary>
        /// XML文件地址
        /// </summary>
        public String XMLpath
        {
            get { return xmlpath; }
        }
        /// <summary>
        /// 仪器名
        /// </summary>
        public string Instrument
        {
            get
            {
                return instrument;
            }

            set
            {
                instrument = value;
            }
        }
        /// <summary>
        /// 表号
        /// </summary>
        public List<string> Tabid
        {
            get
            {
                return tabid;
            }

            set
            {
                tabid = value;
            }
        }
        /// <summary>
        /// 短助记符
        /// </summary>
        public List<string> Shotname
        {
            get
            {
                return shotname;
            }

            set
            {
                shotname = value;
            }
        }
        /// <summary>
        /// 列号
        /// </summary>
        public List<string> Itemid
        {
            get
            {
                return itemid;
            }

            set
            {
                itemid = value;
            }
        }
    }
    /// <summary>
    /// XML属性类
    /// </summary>
    public class XmlAttr
    {
        private string instrument;
        private string tabid;
        private string itemid;
        private string shotname;
        /// <summary>
        /// 表号
        /// </summary>
        public string Tabid
        {
            get
            {
                return tabid;
            }

            set
            {
                tabid = value;
            }
        }
        /// <summary>
        /// Item号
        /// </summary>
        public string Itemid
        {
            get
            {
                return itemid;
            }

            set
            {
                itemid = value;
            }
        }
        /// <summary>
        /// 短助记符名
        /// </summary>
        public string Shotname
        {
            get
            {
                return shotname;
            }

            set
            {
                shotname = value;
            }
        }
        /// <summary>
        /// 仪器名
        /// </summary>
        public string Instrument
        {
            get
            {
                return instrument;
            }

            set
            {
                instrument = value;
            }
        }
    }
    public class WitsConfig
    {
        public static WitsConfigInfo WCfgInfo = new WitsConfigInfo();
        public static XmlAttr attr = new XmlAttr();

        /// <summary>
        /// 获取仪器配置信息 
        /// </summary>
        /// <param name="instrument">仪器名</param>
        /// <returns>是否成功读取</returns>
        public static bool GetConfig(String instrument)
        {
            bool bIsGet = false;
            try
            {
                if (File.Exists(WCfgInfo.XMLpath))
                {

                    XmlDocument doc = new XmlDocument();
                    doc.Load(WCfgInfo.XMLpath);
                    XmlElement root = doc.DocumentElement;

                    XmlNodeList dbConfigNodes = root.GetElementsByTagName("DBConfig");

                    foreach (XmlNode node in dbConfigNodes)
                    {
                        XmlAttr xa = new XmlAttr();
                        XmlElement xe = (XmlElement)node;
                        //xa.Id = xe.GetAttribute("ID");
                        //switch (xa.Id)
                        //{
                        //    case "01":
                        //        //WCfgInfo.FoldBrowserPath = xe.ChildNodes[1].InnerText;
                        //        break;
                        //    case "02":
                        //        //WCfgInfo.StaticDB_PATH = xe.ChildNodes[1].InnerText;
                        //        break;
                        //    case "03":
                        //        //WCfgInfo.DBPath_Well = xe.ChildNodes[1].InnerText;
                        //        break;
                        //    default: break;
                        //}
                    }
                }
                else Debug.WriteLine("WITS.xml 文件地址不存在！");
                bIsGet = true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                bIsGet = false;
            }
            return bIsGet;
        }
    }
}
