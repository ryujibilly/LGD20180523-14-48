using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Net;
using System.Diagnostics;
using System.IO;

namespace LGD.UI
{
    public class FormConfig
    {
        public static readonly FormConfig fc = new FormConfig();
        /// <summary>
        /// 主机IP地质
        /// </summary>
        public String HostIP { get; set; }

        public static bool SaveConfig()
        {
            bool isSaved = false;
            try
            {
                XmlDocument doc = new XmlDocument();
                XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", "utf-8",null);

                //添加节点
                //默认主机IP地址
                XmlElement eleHostIP = doc.CreateElement("HostIP");
                XmlText txtHostIP = doc.CreateTextNode(fc.HostIP);

                XmlNode newElem = doc.CreateNode("element", "config", "");

                newElem.AppendChild(eleHostIP);
                newElem.LastChild.AppendChild(txtHostIP);

                XmlElement root = doc.CreateElement("config");
                root.AppendChild(newElem);
                doc.AppendChild(root);
                doc.Save("FormConfig.xml");

                isSaved = true;

                return isSaved;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return isSaved;
            }
        }

        /// <summary>
        /// 获取配置信息 
        /// </summary>
        /// <returns></returns>
        public static bool LoadConfig()
        {
            bool isLoaded = false;
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load("FormConfig.xml");

                fc.HostIP =doc.SelectSingleNode("//HostIP").InnerText;

                XmlDocument xmldoc = new XmlDocument();
                if(File.Exists("FormConfig.xml"))
                {
                    xmldoc.Load("FormConfig.xml");
                    XmlNodeList xmlnode = xmldoc.SelectSingleNode("Settings").ChildNodes;
                    foreach (XmlElement element in xmlnode)
                    {
                        fc.HostIP = element.Attributes["HostIP"].Value;
                        //CfgInfo.DeviceSN = element.Attributes["deviceSN"].Value;
                        //CfgInfo.NetKey = element.Attributes["netKey"].Value;
                        ////CfgInfo.DB_PATH = element.Attributes["dbPath"].Value;
                        //CfgInfo.DBPath_Well = element.Attributes["dbPath_Well"].Value;
                        //CfgInfo.DBPath_CorrectionChart = element.Attributes["dbPath_CorrectionChart"].Value;
                        //Properties.Settings.Default.DBPath_ChartInfo = CfgInfo.DBPath_CorrectionChart;
                        //Properties.Settings.Default.DBPath_WellInfo = CfgInfo.DBPath_Well;
                        break;
                    }
                }
                isLoaded = true;
                return isLoaded;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return isLoaded;
            }
        }
    }
}
