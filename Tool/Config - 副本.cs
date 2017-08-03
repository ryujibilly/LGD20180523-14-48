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

                //1 默认文件夹
                XmlElement dbconfig = doc.CreateElement("DBConfig");
                dbconfig.SetAttribute("id", "1");
                dbconfig.AppendChild(getChildNode(doc, "Name", "FoldBrowserPath"));
                dbconfig.AppendChild(getChildNode(doc, "Path", Config.CfgInfo.FoldBrowserPath));
                root.AppendChild(dbconfig);

                //静态模板库地址
                dbconfig = doc.CreateElement("DBConfig");
                dbconfig.SetAttribute("id", "2");
                dbconfig.AppendChild(getChildNode(doc, "Name", "StaticDB_PATH"));
                dbconfig.AppendChild(getChildNode(doc, "Path", Config.CfgInfo.StaticDB_PATH));
                root.AppendChild(dbconfig);

                //单井数据库地址
                dbconfig = doc.CreateElement("DBConfig");
                dbconfig.SetAttribute("id", "3");
                dbconfig.AppendChild(getChildNode(doc, "Name", "DBPath_Well"));
                dbconfig.AppendChild(getChildNode(doc, "Path", Config.CfgInfo.DBPath_Well));
                root.AppendChild(dbconfig);

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
                        string id=((XmlElement)node).GetAttribute("id");
                        switch(id){
                            case "1": CfgInfo.FoldBrowserPath = node.Attributes["Path"].InnerText;
                                break;
                            case "2": CfgInfo.StaticDB_PATH = node.Attributes["Path"].InnerText;
                                break;
                            case "3": CfgInfo.DBPath_Well = node.Attributes["Path"].InnerText;
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

