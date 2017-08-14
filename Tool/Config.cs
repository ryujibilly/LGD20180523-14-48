using System;
using System.Diagnostics;
using System.IO;
using System.Xml;
using System.Configuration;

namespace Tool
{
    /// <summary>
    /// 配置的信息类
    /// </summary>
    public class ConfigInfo
    {
        /// <summary>
        /// 默认文件夹路径
        /// </summary>
        public string FoldBrowserPath { get; set; }
        /// <summary>
        /// 配置信息是否有效
        /// </summary>
        public bool IsValue = false;
        /// <summary>
        /// 静态模板库路径
        /// </summary>
        public String StaticDB_PATH { get; set; }
        /// <summary>
        /// 单井数据库路径
        /// </summary>
        public String DBPath_Well { get; set; }


        private String xmlpath = AppDomain.CurrentDomain.BaseDirectory + "LGDConfig.xml";
        /// <summary>
        /// XML文件地址
        /// </summary>
        public String XMLpath
        {
            get { return xmlpath; }
        }

    }
    /// <summary>
    /// XML属性
    /// </summary>
    public class XmlAttr
    {
        private string xmlName;
        private string xmlPath;
        private string id;
        /// <summary>
        /// XML 属性名
        /// </summary>
        public string Name
        {
            get
            {
                return xmlName;
            }

            set
            {
                xmlName = value;
            }
        }
        /// <summary>
        /// XML 属性路径
        /// </summary>
        public string Path
        {
            get
            {
                return xmlPath;
            }

            set
            {
                xmlPath = value;
            }
        }
        /// <summary>
        /// 属性ID
        /// </summary>
        public string Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }
    }
    /// <summary>
    /// 配置类
    /// </summary>
    public class Config
    {
        /// <summary>
        /// 全局配置信息-单例模式
        /// </summary>
        public static ConfigInfo CfgInfo = new ConfigInfo();

        /// <summary>
        /// 保存配置信息
        /// </summary>
        /// <returns></returns>
        public static bool SaveConfig()
        {
            bool bIsSave = false;
            try
            {
                XmlDocument doc = new XmlDocument();
                XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", "utf-8", null);
                doc.AppendChild(dec);
                //根节点
                XmlElement root = doc.CreateElement("Config");
                doc.AppendChild(root);

                //根节点添加独立子节点

                //1 默认文件夹  id=1
                XmlElement dbconfig1 = doc.CreateElement("DBConfig");
                XmlAttribute attrID1 = doc.CreateAttribute("ID");
                attrID1.Value = "01";
                dbconfig1.Attributes.Append(attrID1);
                root.AppendChild(dbconfig1);

                //id=1 ,name
                XmlElement eleName1 = doc.CreateElement("Name");
                eleName1.InnerText = "FoldBrowserPath";
                dbconfig1.AppendChild(eleName1);
                //id=1 ,path
                XmlElement elePath1 = doc.CreateElement("Path");
                elePath1.InnerText = Config.CfgInfo.FoldBrowserPath;
                dbconfig1.AppendChild(elePath1);

                //2 静态模板库地址  id=2
                XmlElement dbconfig2 = doc.CreateElement("DBConfig");
                XmlAttribute attrID2 = doc.CreateAttribute("ID");
                attrID2.Value = "02";
                dbconfig2.Attributes.Append(attrID2);
                root.AppendChild(dbconfig2);

                //id=2 ,name
                XmlElement eleName2 = doc.CreateElement("Name");
                eleName2.InnerText = "StaticDB_PATH";
                dbconfig2.AppendChild(eleName2);
                //id=2 ,path
                XmlElement elePath2 = doc.CreateElement("Path");
                elePath2.InnerText = Config.CfgInfo.StaticDB_PATH;
                dbconfig2.AppendChild(elePath2);

                //3 单井数据库地址  id=3
                XmlElement dbconfig3 = doc.CreateElement("DBConfig");
                XmlAttribute attrID3 = doc.CreateAttribute("ID");
                attrID3.Value = "03";
                dbconfig3.Attributes.Append(attrID3);
                root.AppendChild(dbconfig3);

                //id=3 ,name
                XmlElement eleName3 = doc.CreateElement("Name");
                eleName3.InnerText = "DBPath_Well";
                dbconfig3.AppendChild(eleName3);
                //id=3 ,path
                XmlElement elePath3 = doc.CreateElement("Path");
                elePath3.InnerText = Config.CfgInfo.DBPath_Well;
                dbconfig3.AppendChild(elePath3);

                doc.Save(Config.CfgInfo.XMLpath);
                Debug.WriteLine("LGDConfig.xml 创建成功！");
                bIsSave = true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                bIsSave = false;
            }
            return bIsSave;
        }

        /// <summary>
        /// 获取配置信息 
        /// </summary>
        /// <returns></returns>
        public static bool GetConfig()
        {
            bool bIsGet = false;
            try
            {
                if (File.Exists(Config.CfgInfo.XMLpath))
                {

                    XmlDocument doc = new XmlDocument();
                    doc.Load(Config.CfgInfo.XMLpath);
                    XmlElement root = doc.DocumentElement;

                    XmlNodeList dbConfigNodes = root.GetElementsByTagName("DBConfig");
                    foreach (XmlNode node in dbConfigNodes)
                    {
                        XmlAttr xa = new XmlAttr();
                        XmlElement xe=(XmlElement)node;
                        xa.Id = xe.GetAttribute("ID");
                        switch(xa.Id){
                            case "01": CfgInfo.FoldBrowserPath = xe.ChildNodes[1].InnerText;
                                break;
                            case "02": CfgInfo.StaticDB_PATH = xe.ChildNodes[1].InnerText;
                                break;
                            case "03": CfgInfo.DBPath_Well = xe.ChildNodes[1].InnerText;
                                break;
                            default: break;
                        }
                    }
                }
                bIsGet = true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                bIsGet = false;
            }
            return bIsGet;
        }

        public static XmlNode getChildNode(XmlDocument xmldoc, String tag, String value)
        {
            XmlNode node = xmldoc.CreateNode(XmlNodeType.Element, tag, value);
            return node;
        }
    }
}

