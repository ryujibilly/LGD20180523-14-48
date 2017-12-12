using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using System.Diagnostics;

namespace WitsTransmission.XMLUtil
{
    /// <summary>
    /// XML工具类
    /// 实现XML文件的读取、写入新节点、修改节点和删除节点功能
    /// @author futao
    /// </summary>
    public class XMLUtil
    {
        private XmlReaderSettings settings;
        public  XmlReader m_xmlReader;//每次调用后，需关闭
        public XmlDocument m_xmlDoc = new XmlDocument();
        //根据xml文件路径，生成XmlDocument对象
        public XmlDocument getDocument(String filename)  
        {  
            try
            {
                m_xmlReader = XmlReader.Create(@"..\..\ConfigFile\" + filename, settings);
                m_xmlDoc.Load(m_xmlReader);
                Trace.WriteLine("----->getDocument()");
                return m_xmlDoc;
            }
            catch (System.Exception ex)
            {
                throw new Exception("读取XML失败！", ex);
            }
        }
        //获取xml文档根节点
        public XmlElement getRoot(XmlDocument xmlDoc)
        {
            try
            {
                Trace.WriteLine("----->getRoot()");
                return xmlDoc.DocumentElement;
            }
            catch (System.Exception ex)
            {
                throw new Exception("读取XML文档根节点失败！", ex);
            }
        } 
        //根据根节点得到其所有子节点（一级节点）
        public XmlNodeList getChildNodes(XmlElement root)
        {
            try
            {
                Trace.WriteLine("----->getChildNodes()");
                return root.ChildNodes;
            }
            catch (System.Exception ex)
            {
                throw new Exception("读取XML文档一级子节点失败！", ex);
            }
        }
        //根据根节点的子节点(一级节点)的某属性和控件所选择的类型，获取所需节点下的所有子节点（二级节点）
        public XmlNodeList getSubChildNodeList(XmlNodeList nodeList,String strAttribute,String strSelect)
        {
            try
            {
                XmlNodeList subNodeList = null;
                foreach (XmlNode node in nodeList)
                {
                    if (strSelect == node.Attributes[strAttribute].Value)//是所选的一级节点
                    {
                        subNodeList = node.ChildNodes;//返回所选一级节点下的二级节点
                    }
                }
                Trace.WriteLine("----->getSubChildNodeList()");
                return subNodeList;
            }
            catch (System.Exception ex)
            {
                throw new Exception("读取XML文档二级子节点失败！", ex);
            }
        }
        //根据根节点的子节点(一级节点无Attributes情况)和控件所选择的类型，获取所需节点下的所有子节点（二级节点）
        public XmlNodeList getSubChildNodes(XmlNodeList nodeList, String strSelect)
        {
            try
            {
                XmlNodeList subNodeList = null;
                foreach (XmlNode node in nodeList)
                {
                    if (strSelect == node.Name)//是所选的一级节点
                    {
                        subNodeList = node.ChildNodes;//返回所选一级节点下的二级节点
                    }
                }
                Trace.WriteLine("----->getSubChildNodes()");
                return subNodeList;
            }
            catch (System.Exception ex)
            {
                throw new Exception("读取XML文档二级子节点失败！", ex);
            }
        }
        //根据根节点的子节点和控件所选择的类型，获取所需节点下的所有子节点的某个属性（二级节点）
        public List<String> getSubChildNodes(XmlNodeList nodeList, String strAttribute, String strSelect)
        {
            try
            {
                List<String> nameList = new List<String>();
                foreach (XmlNode node in nodeList)
                {
                    if (strSelect == node.Attributes[strAttribute].Value)//是所选的一级节点
                    {
                        //获取所需节点下的所有子节点（二级节点）
                        XmlNodeList subNodeList = node.ChildNodes;
                        //将所需节点下的所有子节点的name放入nameList
                        foreach (XmlNode subNode in subNodeList)
                        {
                            nameList.Add(subNode.Attributes[strAttribute].Value);
                        }
                    }
                }
                Trace.WriteLine("----->getSubChildNodes()");
                return nameList;
            }
            catch (System.Exception ex)
            {
                throw new Exception("读取XML文档二级子节点属性失败！", ex);
            }
        }
        //根据根节点的子节点和控件所选择的类型，获取所需节点下的所有子节点的多个属性（二级节点）
        public List<List<String>> getSubChildNodes(XmlNodeList nodeList, List<String> attributeList, String strSelect)
        {
            try
            {
                List<List<String>> recordList = new List<List<String>>();
                foreach (XmlNode node in nodeList)
                {
                    if (strSelect == node.Name)//是所选的一级节点
                    {
                        //获取所需节点下的所有子节点(二级节点)
                        XmlNodeList subNodeList = node.ChildNodes;
                        //将二级节点的所需属性放入recordList
                        foreach (XmlNode subNode in subNodeList)
                        {
                            List<String> attributeValueList = new List<String>();
                            foreach (String strSubNodeAttribute in attributeList)
                            {
                                attributeValueList.Add(subNode.Attributes[strSubNodeAttribute].Value);
                            }
                            recordList.Add(attributeValueList);
                        }
                    }
                }
                Trace.WriteLine("----->getSubChildNodes()");
                return recordList;
            }
            catch (System.Exception ex)
            {
                throw new Exception("读取XML文档二级子节点多个属性失败！", ex);
            }
        }
        //根据二级节点属性，获取该二级节点下的所有子节点的某个属性（三级节点）
        public List<String> getSubSubChildNodes(XmlNodeList subNodeList, String strSubAttribute, String strSelect)
        {
            try
            {
                List<String> itemList = new List<String>();
                foreach (XmlNode subNode in subNodeList)//二级节点
                {
                    //获取所需节点下的所有子节点(三级节点)
                    if (strSelect == subNode.Attributes[strSubAttribute].Value)
                    {
                        XmlNodeList subSubNodeList = subNode.ChildNodes;
                        foreach (XmlNode subSubNode in subSubNodeList)
                        {
                            //根据strSubAttribute参数，将其值添加到itemList
                            itemList.Add(subSubNode.Attributes[strSubAttribute].Value);
                        }
                    }
                }
                Trace.WriteLine("----->getSubSubChildNodes()");
                return itemList;
            }
            catch (System.Exception ex)
            {
                throw new Exception("读取XML文档三级子节点某个属性失败！", ex);
            }
        }
        //根据二级节点属性，获取该二级节点下的所有子节点的多个属性（三级节点）
        public List<List<String>> getSubSubChildNodes(XmlNodeList subNodeList, List<String> attributeList, String strSubAttribute, String strSelect)
        {
            try
            {
                List<List<String>> itemList = new List<List<String>>();
                foreach (XmlNode subNode in subNodeList)//二级节点
                {
                    //获取所需节点下的所有子节点(三级节点)
                    if (strSelect == subNode.Attributes[strSubAttribute].Value)
                    {
                        XmlNodeList subSubNodeList = subNode.ChildNodes;
                        foreach (XmlNode subSubNode in subSubNodeList)
                        {
                            List<String> attributeValueList = new List<String>();
                            //根据attributeList中参数，将其值添加到itemList
                            foreach (String strSubSubAttribute in attributeList)
                            {
                                attributeValueList.Add(subSubNode.Attributes[strSubSubAttribute].Value);
                            }
                            itemList.Add(attributeValueList);
                        }
                    }
                }
                Trace.WriteLine("----->getSubSubChildNodes()");
                return itemList;
            }
            catch (System.Exception ex)
            {
                throw new Exception("读取XML文档三级子节点多个属性失败！", ex);
            }
        }
        //创建节点
        public XmlNode createXmlNode(XmlDocument xmlDoc, String nodeName, String atrributeName, String atrributeValue)
        {
            //添加unit子节点
            XmlNode childNode = xmlDoc.CreateNode(XmlNodeType.Element, nodeName, null);
            XmlAttribute childNodeAttribute = xmlDoc.CreateAttribute(atrributeName);
            childNodeAttribute.InnerText = atrributeValue;
            childNode.Attributes.Append(childNodeAttribute);
            return childNode;
        }
        //创建新节点，最多可创建三级节点
        public void addNewXmlNode(String filename, int addTreeLevel, TreeNode selectedTreeNode, String nodeName, String atrributeName, String atrributeValue)
        {
            m_xmlDoc = getDocument(filename);
            //创建一个节点Element;
            XmlElement element = m_xmlDoc.CreateElement(nodeName);
            //设置该节点name属性
            element.SetAttribute(atrributeName, atrributeValue);
            XmlNodeList nodeList = getChildNodes(getRoot(m_xmlDoc));
            foreach (XmlNode node in nodeList)
            {
                switch (addTreeLevel)
                {
                    case 0:
                        //将TreeView第0级节点，在Xml文件一级节点创建
                        if (node.Attributes[atrributeName].Value == selectedTreeNode.Text)
                        {
                            node.ParentNode.AppendChild(element);
                        }
                        break;
                    case 1:
                        //将TreeView第1级节点，在Xml文件二级节点创建
                        switch (selectedTreeNode.Level)
                        {
                            case 0://XML文件一级节点无子节点
                                if (node.Attributes[atrributeName].Value == selectedTreeNode.Text)
                                {
                                    node.AppendChild(element);
                                }
                                break;
                            case 1://XML文件一级节点有子节点
                                if (node.Attributes[atrributeName].Value == selectedTreeNode.Parent.Text)
                                {
                                    XmlNodeList subNodeList = node.ChildNodes;
                                    foreach (XmlNode subNode in subNodeList)
                                    {
                                        if (subNode.Attributes[atrributeName].Value == selectedTreeNode.Text)
                                        {
                                            subNode.ParentNode.AppendChild(element);
                                        }
                                    }
                                }
                                break;
                            default:
                                break;
                        }
                        break;
                    case 2:
                        //将TreeView第2级节点，在Xml文件三级节点创建
                        switch (selectedTreeNode.Level)
                        {
                            case 1://XML文件二级节点无子节点
                                if (node.Attributes[atrributeName].Value == selectedTreeNode.Parent.Text)
                                {
                                    XmlNodeList subNodeList = node.ChildNodes;
                                    foreach (XmlNode subNode in subNodeList)
                                    {
                                        if (subNode.Attributes[atrributeName].Value == selectedTreeNode.Text)
                                        {
                                            subNode.AppendChild(element);
                                        }
                                    }
                                }
                                break;
                            case 2://XML文件二级节点有子节点
                                if (node.Attributes[atrributeName].Value == selectedTreeNode.Parent.Parent.Text)
                                {
                                    XmlNodeList subNodeList = node.ChildNodes;
                                    foreach (XmlNode subNode in subNodeList)
                                    {
                                        if (subNode.Attributes[atrributeName].Value == selectedTreeNode.Parent.Text)
                                        {
                                            subNode.AppendChild(element);
                                        }
                                    }
                                }
                                break;
                            default:
                                break;
                        }
                        break;
                    default:
                        break;
                }
            }
            m_xmlReader.Close();
            m_xmlDoc.Save(@"..\..\ConfigFile\" + filename);
        }
        //修改节点，最多可修改三级节点
        public void alterXmlNode(String filename,TreeNode selectedTreeNode, String atrributeName, String atrributeValue)
        {
            m_xmlDoc = getDocument(filename);
            switch (selectedTreeNode.Level)
            {
                case 0://修改XML文件第一级
                    XmlNodeList nodeList1 = getChildNodes(getRoot(m_xmlDoc));
                    foreach (XmlNode node in nodeList1)
                    {
                        //修改TreeView第0级节点，在Xml文件一级节点修改
                        if (node.Attributes[atrributeName].Value == selectedTreeNode.Text)
                        {
                            node.Attributes[atrributeName].Value = atrributeValue;
                            m_xmlReader.Close();
                            m_xmlDoc.Save(@"..\..\ConfigFile\" + filename);
                        }
                    }
                    break;
                case 1://修改XML文件第二级节点
                    XmlNodeList nodeList2 = getSubChildNodeList(getChildNodes(getRoot(m_xmlDoc)), atrributeName, selectedTreeNode.Parent.Text);
                    foreach (XmlNode node in nodeList2)
                    {
                        //修改TreeView第1级节点，在Xml文件二级节点修改
                        if (node.Attributes[atrributeName].Value == selectedTreeNode.Text)
                        {
                            node.Attributes[atrributeName].Value = atrributeValue;
                            m_xmlReader.Close();
                            m_xmlDoc.Save(@"..\..\ConfigFile\" + filename);
                        }
                    }
                    break;
                case 2://修改XML文件第三级节点
                    XmlNodeList nodeList2temp = getSubChildNodeList(getChildNodes(getRoot(m_xmlDoc)), atrributeName, selectedTreeNode.Parent.Parent.Text);
                    foreach (XmlNode node in nodeList2temp)
                    {
                        //修改TreeView第1级节点，在Xml文件二级节点修改
                        if (node.Attributes[atrributeName].Value == selectedTreeNode.Parent.Text)
                        {
                            XmlNodeList nodeList3 = node.ChildNodes;
                            foreach (XmlNode subNode in nodeList3)
                            {
                                if (subNode.Attributes[atrributeName].Value == selectedTreeNode.Text)
                                {
                                    subNode.Attributes[atrributeName].Value = atrributeValue;
                                    m_xmlReader.Close();
                                    m_xmlDoc.Save(@"..\..\ConfigFile\" + filename);
                                }
                            }
                        }
                    }
                    break;
                default:
                    break;
            }
        }
        //删除节点，最多可删除三级节点
        public void deleteXmlNode(String filename, TreeNode selectedTreeNode, String atrributeName)
        {
            m_xmlDoc = getDocument(filename);
            switch (selectedTreeNode.Level)
            {
                case 0://删除XML文件第一级
                    XmlNodeList nodeList1 = getChildNodes(getRoot(m_xmlDoc));
                    foreach (XmlNode node in nodeList1)
                    {
                        //删除TreeView第0级节点，在Xml文件一级节点删除
                        if (node.Attributes[atrributeName].Value == selectedTreeNode.Text)
                        {
                            //用父节点删子节点，可完全删除
                            getRoot(m_xmlDoc).RemoveChild(node);
                            //当前节点删，仅能删除其属性
                            //node.RemoveAll();
                        }
                    }
                    break;
                case 1://删除XML文件第二级节点
                    XmlNodeList nodeList2 = getSubChildNodeList(getChildNodes(getRoot(m_xmlDoc)), atrributeName, selectedTreeNode.Parent.Text);
                    foreach (XmlNode node in nodeList2)
                    {
                        //删除TreeView第1级节点，在Xml文件二级节点删除
                        if (node.Attributes[atrributeName].Value == selectedTreeNode.Text)
                        {
                            node.ParentNode.RemoveChild(node);
                        }
                    }
                    break;
                case 2://删除XML文件第三级节点
                    XmlNodeList nodeList2temp = getSubChildNodeList(getChildNodes(getRoot(m_xmlDoc)), atrributeName, selectedTreeNode.Parent.Parent.Text);
                    foreach (XmlNode node in nodeList2temp)
                    {
                        if (node.Attributes[atrributeName].Value == selectedTreeNode.Parent.Text)
                        {
                            XmlNodeList nodeList3 = node.ChildNodes;
                            foreach (XmlNode subNode in nodeList3)
                            {
                                //删除TreeView第2级节点，在Xml文件三级节点删除
                                if (subNode.Attributes[atrributeName].Value == selectedTreeNode.Text)
                                {
                                    subNode.ParentNode.RemoveChild(subNode);
                                }
                            }
                        }
                    }
                    break;
                default:
                    break;
            }
            m_xmlReader.Close();
            m_xmlDoc.Save(@"..\..\ConfigFile\" + filename);
        }
    }
}
