using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Collections.Concurrent;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;

namespace WitsTransmission.WitsReceive
{
    public partial class RecConfig_Form : Form
    {
        public XMLUtil.XMLUtil m_xmlUtil = new XMLUtil.XMLUtil();
        public List<CheckBox> m_checkBoxList = new List<CheckBox>();
        public List<RadioButton> m_radioButtonList = new List<RadioButton>();
        public List<String> m_recordAttributesList = new List<String>();
        public List<String> m_itemAttributesList = new List<String>();
        //保存Server选的的仪器及对应选择的表
        Dictionary<String, List<String>> m_selectServerToolDictionary = new Dictionary<string, List<string>>();
        //保存Client选的的仪器及对应选择的表
        Dictionary<String, List<String>> m_selectClientToolDictionary = new Dictionary<string, List<string>>();
        //保存WitsTable_treeView选择的表
        public List<String> m_selectedTableList = new List<string>();
        public TCPUtil.AsynchronousTCPServer m_tcpServer = new TCPUtil.AsynchronousTCPServer();
        public ConcurrentQueue<TCPUtil.AsynchronousTCPClient> m_tcpClientQueue = new ConcurrentQueue<TCPUtil.AsynchronousTCPClient>();
        public Thread StartServerThread;
        public Thread StartClientThread;
        //供Main_Form的写库线程获取Server所选仪器和表信息
        public Dictionary<String, List<String>> getSelectServerToolDictionary()
        {
            return m_selectServerToolDictionary;
        }
        //供Main_Form的写库线程获取Client所选仪器和表信息
        public Dictionary<String, List<String>> getSelectClientToolDictionary()
        {
            return m_selectClientToolDictionary;
        }

        public RecConfig_Form()
        {
            InitializeComponent();
        }

        public void RecConfig_Form_Load(object sender, EventArgs e)
        {
            m_checkBoxList.Add(logging_checkBox);//测井
            m_checkBoxList.Add(wellLog_checkBox);//录井
            m_checkBoxList.Add(drilling_checkBox);//钻井
            m_radioButtonList.Add(logging_radioButton);//测井
            m_radioButtonList.Add(wellLog_radioButton);//录井
            m_radioButtonList.Add(drilling_radioButton);//钻井
            m_recordAttributesList.Add("index");
            m_recordAttributesList.Add("describe");
            m_itemAttributesList.Add("index");
            m_itemAttributesList.Add("describe");
            m_itemAttributesList.Add("short-mnemonic");
        }


        private void tCPSetting_tabControl_Selected(object sender, TabControlEventArgs e)
        {
            
        }
               
        //将三个checkBox响应事件都设为一致
        private void logging_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            //checkBox多选,获取所选控件的Text，存入m_toolTypeList
            foreach (CheckBox cb in m_checkBoxList)
            {
                if (cb.Checked == true)
                {
                    //根据选择，从ToolInfo.xml中读取相应仪器信息加入tool_comboBox控件
                    List<String> strList = new List<String>();
                    strList = m_xmlUtil.getSubChildNodes(m_xmlUtil.getChildNodes(m_xmlUtil.getRoot(m_xmlUtil.getDocument("ToolInfo.xml"))), "name",cb.Text);
                    m_xmlUtil.m_xmlReader.Close();
                    foreach (String str in strList)
                    {
                        //tool_comboBox中该项不存在，则添加
                        if (!tool_comboBox.Items.Contains(str))
                        {
                            tool_comboBox.Items.Add(str);
                        }
                    }
                }
                else
                {
                    //根据选择，从ToolInfo.xml中读取相应仪器信息，从tool_comboBox控件移除
                    List<String> strList = new List<String>();
                    strList = m_xmlUtil.getSubChildNodes(m_xmlUtil.getChildNodes(m_xmlUtil.getRoot(m_xmlUtil.getDocument("ToolInfo.xml"))), "name",cb.Text);
                    m_xmlUtil.m_xmlReader.Close();
                    foreach (String str in strList)
                    {
                        ////tool_comboBox中该项存在，则移除
                        if (tool_comboBox.Items.Contains(str)&&str!="Common")
                        {
                            tool_comboBox.Items.Remove(str);
                        }
                        if (tool_comboBox.Items.Count == 1 && str == "Common")
                        {
                            tool_comboBox.Items.Remove(str);
                        }
                    }
                    if (tool_comboBox.Items.Count == 0)
                    {
                        tool_comboBox.ResetText();
                        WitsTable_treeView.Nodes.Clear();
                    }
                }
            }
        }

        private void tcpServerIP_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //48代表0，57代表9，8代表空格，46代表小数点
            if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 8) && (e.KeyChar != 46))
            {
                e.Handled = true;
            }
        }

        private void tcpServerIP_textBox_Leave(object sender, EventArgs e)
        {
            try
            {
                string[] strSplit = { "." };
                string str = tcpServerIP_textBox.Text;
                string[] strArray = str.Split(strSplit, StringSplitOptions.RemoveEmptyEntries);
                if(strArray.Count()<4)
                {
                    MessageBox.Show("输入的IP地址非法！");
                    tcpServerIP_textBox.Focus();
                    return;
                }
                foreach (string element in strArray)
                {
                    int nElement = int.Parse(element);
                    if ((nElement < 0) || (nElement > 255))
                    {
                        MessageBox.Show("输入的IP地址非法！");
                        tcpServerIP_textBox.Focus();
                        return;
                    }
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tcpServerPort_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //48代表0，57代表9，8代表空格
            if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 8))
            {
                e.Handled = true;
            }
        }

        
        private void tcpServerPort_textBox_Leave(object sender, EventArgs e)
        {
            /*string regexString = @"^\d+$";
            if (!Regex.IsMatch(tcpServerPort_textBox.Text, regexString))
            {
                MessageBox.Show("请输入一个正整数！");
            }*/
            if (string.IsNullOrWhiteSpace(tcpServerPort_textBox.Text))
            {
                MessageBox.Show("未输入端口号！");
                tcpServerPort_textBox.Focus();
            }
        }
       

        private void tool_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            WitsTable_treeView.Nodes.Clear();//清空树显示
            m_selectedTableList.Clear();//清空上次选择仪器所对应的所选的表
            int index = tool_comboBox.SelectedIndex;
            String strSelected = tool_comboBox.Items[index].ToString();
            //根据ComboBox选择，从WITS.xml中读取相应仪器的record信息，加载到WitsTable_treeView第一级节点
            List<List<String>> recordList = new List<List<String>>();
            recordList = m_xmlUtil.getSubChildNodes(m_xmlUtil.getChildNodes(m_xmlUtil.getRoot(m_xmlUtil.getDocument("WITS.xml"))), m_recordAttributesList, strSelected);
            m_xmlUtil.m_xmlReader.Close();
            foreach (List<String> recordAttributeList in recordList)
            {
                //添加TreeGridView的第一级节点
                TreeNode rootNode = new TreeNode();
                foreach (String strRecordAttribute in recordAttributeList)
                {
                    rootNode.Text += strRecordAttribute;
                }
                //根据ComboBox选择和record，从WITS.xml中读取相应仪器的某个record下的所有item信息，加载到WitsTable_treeView第二级节点
                List<List<String>> itemList = new List<List<String>>();
                itemList = m_xmlUtil.getSubSubChildNodes(m_xmlUtil.getSubChildNodes(m_xmlUtil.getChildNodes(m_xmlUtil.getRoot(m_xmlUtil.getDocument("WITS.xml"))), strSelected), m_itemAttributesList, "index", rootNode.Text.Substring(0,2));
                m_xmlUtil.m_xmlReader.Close();
                foreach (List<String> itemAttributeList in itemList)
                {
                    TreeNode childNode = new TreeNode();
                    foreach (String strItemAttribute in itemAttributeList)
                    {
                        childNode.Text += strItemAttribute;
                    }
                    rootNode.Nodes.Add(childNode);
                }
                WitsTable_treeView.Nodes.Add(rootNode);
            }
        }
        
        //取消节点选中状态之后，取消所有父节点的选中状态
        private void setParentNodeCheckedState(TreeNode currNode, bool state)
        {
            TreeNode parentNode = currNode.Parent;
            parentNode.Checked = state;
            if (currNode.Parent.Parent != null)
            {
                setParentNodeCheckedState(currNode.Parent, state);
            }
        }
        //选中节点之后，选中节点的所有子节点
        private void setChildNodeCheckedState(TreeNode currNode, bool state)
        {
            TreeNodeCollection nodes = currNode.Nodes;
            if (nodes.Count > 0)
            {
                foreach (TreeNode tn in nodes)
                {
                    tn.Checked = state;
                    setChildNodeCheckedState(tn, state);
                }
            }
        }

        private void WitsTable_treeView_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Action == TreeViewAction.ByMouse)
            {
                int k = 0;
                //如果是父节点并且是被选中的，被选中子节点被选中
                if (e.Node.Parent == null && e.Node.GetNodeCount(true) != 0 && e.Node.Checked)
                {
                    setChildNodeCheckedState(e.Node, true);
                }
                //如果是父节点并且不是被选中的，被选中子节点不被选中
                else if (e.Node.Parent == null && e.Node.GetNodeCount(true) != 0 && e.Node.Checked == false)
                {
                    setChildNodeCheckedState(e.Node, false);
                }
                //如果是子节点，并且是被选中的
                else if (e.Node.Parent != null && e.Node.Checked == true)
                {
                    setParentNodeCheckedState(e.Node, true);
                }
                //如果是子节点，并且不是被选中
                else if (e.Node.Parent != null && e.Node.Checked == false)
                {
                    //遍历所有的节点
                    for (int i = 0; i < e.Node.Parent.Nodes.Count; i++)
                    {
                        //如果有其中有一个被选中的,父节点也被选中
                        if (e.Node.Parent.Nodes[i].Checked)
                        {
                            k++;
                        }
                    }
                    if (k > 0)
                    {
                        setParentNodeCheckedState(e.Node, true);
                    }
                    else
                    {
                        setParentNodeCheckedState(e.Node, false);
                    }
                }
            }
            //父节点被选中，将其内容添加到m_selectedTableList
            if (e.Node.Parent == null && e.Node.GetNodeCount(true) != 0)
            {
                String toolName = tool_comboBox.SelectedItem.ToString();
                if (!m_selectServerToolDictionary.Keys.Contains(toolName))//不存在该仪器名
                {
                    m_selectedTableList.Clear();//清空上次选择仪器所对应的所选的表
                    if (e.Node.Checked)
                    {
                        m_selectedTableList.Add(e.Node.Text.ToString().Substring(0, 2));//如表号"01"
                    }
                    else
                    {
                        m_selectedTableList.Remove(e.Node.Text.ToString().Substring(0, 2));
                    }
                    List<String> selectedTableList = new List<string>();
                    foreach(String str in m_selectedTableList)
                    {
                        selectedTableList.Add(str);
                    }
                    m_selectServerToolDictionary.Add(toolName, selectedTableList);
                }
                else
                {
                    for (int i = 0; i < m_selectServerToolDictionary.Count; i++)
                    {
                        if (m_selectServerToolDictionary.ElementAt(i).Key == toolName)//与所选仪器名一致
                        {
                            if (e.Node.Checked)
                            {
                                m_selectedTableList.Add(e.Node.Text.ToString().Substring(0, 2));//如表号"01"
                            }
                            else
                            {
                                m_selectedTableList.Remove(e.Node.Text.ToString().Substring(0, 2));
                            }
                            List<String> selectedTableList = new List<string>();
                            foreach (String str in m_selectedTableList)
                            {
                                selectedTableList.Add(str);
                            }
                            //每次添加前移除，确保最后一次添加的是所选仪器对应所选的表全集
                            m_selectServerToolDictionary.Remove(toolName);
                            m_selectServerToolDictionary.Add(toolName,selectedTableList);
                        }
                    }
                }
            }
        }

        #region  
        //全选或全不选子节点
        public void CheckAllChildNodes(TreeNode treeNode, bool nodeChecked)
        {
            foreach (TreeNode node in treeNode.Nodes)
            {
                node.Checked = nodeChecked;
                if (node.Nodes.Count > 0)
                {
                    this.CheckAllChildNodes(node, nodeChecked);
                }
            }
        }
        //全选或全不选父节点
        public void CheckAllParentNodes(TreeView treeView, bool parentNodeChecked,bool nodeChecked)
        {
            foreach (TreeNode node in treeView.Nodes)
            {
                CheckAllChildNodes(node, node.Checked = nodeChecked);
                bool bol = parentNodeChecked;
                if (node.Parent != null)
                {
                    for (int i = 0; i < node.Parent.Nodes.Count; i++)
                    {
                        if (!node.Parent.Nodes[i].Checked)
                            bol = !parentNodeChecked;
                    }
                    node.Parent.Checked = bol;
                }
            }
        }
        #endregion

        private void selectAll_button_Click(object sender, EventArgs e)
        {
            CheckAllParentNodes(WitsTable_treeView,true,true);
        }

        private void noSelect_button_Click(object sender, EventArgs e)
        {
            CheckAllParentNodes(WitsTable_treeView, false, false);
        }

        private void serverStartup_button_Click(object sender, EventArgs e)
        {
            if (m_selectServerToolDictionary.Count > 0)
            {
                StartServerThread = new Thread(new ThreadStart(_startServer));
                StartServerThread.IsBackground = true; 
                StartServerThread.Start();
                serverStartup_button.Enabled = false;
                stopServer_button.Enabled = true;
            }
            else
            {
                stopServer_button.Enabled = false;
                MessageBox.Show("信息不完整，服务无法启动！");
            }
        }

        private void _startServer()
        {
            try
            {
                int port = int.Parse(tcpServerPort_textBox.Text);
                //此方法每接收到WITS数据，就传递给Main_Form作处理
                m_tcpServer.StartListening(tcpServerIP_textBox.Text, port);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(">>StartServer线程"+ex.Message);
            }
        }

        private void stopServer_button_Click(object sender, EventArgs e)
        {
            serverStartup_button.Enabled = true;
            stopServer_button.Enabled = false;
        }

        private void tCPClientIP_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //48代表0，57代表9，8代表空格，46代表小数点
            if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 8) && (e.KeyChar != 46))
            {
                e.Handled = true;
            }
        }

        private void tCPClientIP_textBox_Leave(object sender, EventArgs e)
        {
            try
            {
                string[] strSplit = { "." };
                string str = tcpServerIP_textBox.Text;
                string[] strArray = str.Split(strSplit, StringSplitOptions.RemoveEmptyEntries);
                if (strArray.Count() < 4)
                {
                    MessageBox.Show("输入的IP地址非法！");
                    return;
                }
                foreach (string element in strArray)
                {
                    int nElement = int.Parse(element);
                    if ((nElement < 0) || (nElement > 255))
                    {
                        MessageBox.Show("输入的IP地址非法！");
                        return;
                    }
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tCPClientPort_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //48代表0，57代表9，8代表空格
            if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 8))
            {
                e.Handled = true;
            }
        }

        private void tCPClientPort_textBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tCPClientPort_textBox.Text))
            {
                MessageBox.Show("未输入端口号！");
                tCPClientPort_textBox.Focus();
            }
        }

        private void logging_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            foreach (RadioButton rb in m_radioButtonList)
            {
                if (rb.Checked == true)
                {
                    //根据选择，从ToolInfo.xml中读取相应仪器信息加入tool_comboBox控件
                    List<String> strList = new List<String>();
                    strList = m_xmlUtil.getSubChildNodes(m_xmlUtil.getChildNodes(m_xmlUtil.getRoot(m_xmlUtil.getDocument("ToolInfo.xml"))), "name", rb.Text);
                    m_xmlUtil.m_xmlReader.Close();
                    foreach (String str in strList)
                    {
                        //clientTool_comboBox中该项不存在，则添加
                        if (!clientTool_comboBox.Items.Contains(str))
                        {
                            clientTool_comboBox.Items.Add(str);
                        }
                    }
                }
                else
                {
                    //根据选择，从ToolInfo.xml中读取相应仪器信息，从tool_comboBox控件移除
                    List<String> strList = new List<String>();
                    strList = m_xmlUtil.getSubChildNodes(m_xmlUtil.getChildNodes(m_xmlUtil.getRoot(m_xmlUtil.getDocument("ToolInfo.xml"))), "name", rb.Text);
                    m_xmlUtil.m_xmlReader.Close();
                    foreach (String str in strList)
                    {
                        ////clientTool_comboBox中该项存在，则移除
                        if (clientTool_comboBox.Items.Contains(str) && str != "Common")
                        {
                            clientTool_comboBox.Items.Remove(str);
                        }
                        if (clientTool_comboBox.Items.Count == 1 && str == "Common")
                        {
                            clientTool_comboBox.Items.Remove(str);
                        }
                    }
                    if (clientTool_comboBox.Items.Count == 0)
                    {
                        clientTool_comboBox.ResetText();
                        clientWitsTable_treeView.Nodes.Clear();
                    }
                }
            }
        }

        private void clientTool_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            clientWitsTable_treeView.Nodes.Clear();
            m_selectedTableList.Clear();//清空上次选择仪器所对应的所选的表
            int index = clientTool_comboBox.SelectedIndex;
            String strSelected = clientTool_comboBox.Items[index].ToString();
            //根据ComboBox选择，从WITS.xml中读取相应仪器的record信息，加载到WitsTable_treeView第一级节点
            List<List<String>> recordList = new List<List<String>>();
            recordList = m_xmlUtil.getSubChildNodes(m_xmlUtil.getChildNodes(m_xmlUtil.getRoot(m_xmlUtil.getDocument("WITS.xml"))), m_recordAttributesList, strSelected);
            m_xmlUtil.m_xmlReader.Close();
            foreach (List<String> recordAttributeList in recordList)
            {
                //添加TreeGridView的第一级节点
                TreeNode rootNode = new TreeNode();
                foreach (String strRecordAttribute in recordAttributeList)
                {
                    rootNode.Text += strRecordAttribute;
                }
                //根据ComboBox选择和record，从WITS.xml中读取相应仪器的某个record下的所有item信息，加载到WitsTable_treeView第二级节点
                List<List<String>> itemList = new List<List<String>>();
                itemList = m_xmlUtil.getSubSubChildNodes(m_xmlUtil.getSubChildNodes(m_xmlUtil.getChildNodes(m_xmlUtil.getRoot(m_xmlUtil.getDocument("WITS.xml"))), strSelected), m_itemAttributesList, "index", rootNode.Text.Substring(0, 2));
                m_xmlUtil.m_xmlReader.Close();
                foreach (List<String> itemAttributeList in itemList)
                {
                    TreeNode childNode = new TreeNode();
                    foreach (String strItemAttribute in itemAttributeList)
                    {
                        childNode.Text += strItemAttribute;
                    }
                    rootNode.Nodes.Add(childNode);
                }
                clientWitsTable_treeView.Nodes.Add(rootNode);
            }
        }

        private void clientWitsTable_treeView_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Action == TreeViewAction.ByMouse)
            {
                int k = 0;
                //如果是父节点并且是被选中的，被选中子节点被选中
                if (e.Node.Parent == null && e.Node.GetNodeCount(true) != 0 && e.Node.Checked)
                {
                    setChildNodeCheckedState(e.Node, true);
                }
                //如果是父节点并且不是被选中的，被选中子节点不被选中
                else if (e.Node.Parent == null && e.Node.GetNodeCount(true) != 0 && e.Node.Checked == false)
                {
                    setChildNodeCheckedState(e.Node, false);
                }
                //如果是子节点，并且是被选中的
                else if (e.Node.Parent != null && e.Node.Checked == true)
                {
                    setParentNodeCheckedState(e.Node, true);
                }
                //如果是子节点，并且不是被选中
                else if (e.Node.Parent != null && e.Node.Checked == false)
                {
                    //遍历所有的节点
                    for (int i = 0; i < e.Node.Parent.Nodes.Count; i++)
                    {
                        //如果有其中有一个被选中的,父节点也被选中
                        if (e.Node.Parent.Nodes[i].Checked)
                        {
                            k++;
                        }
                    }
                    if (k > 0)
                    {
                        setParentNodeCheckedState(e.Node, true);
                    }
                    else
                    {
                        setParentNodeCheckedState(e.Node, false);
                    }
                }
            }
            //父节点被选中，将其内容添加到m_selectedTableList
            if (e.Node.Parent == null && e.Node.GetNodeCount(true) != 0)
            {
                String toolName = clientTool_comboBox.SelectedItem.ToString();
                if (!m_selectClientToolDictionary.Keys.Contains(toolName))//不存在该仪器名
                {
                    m_selectedTableList.Clear();//清空上次选择仪器所对应的所选的表
                    if (e.Node.Checked)
                    {
                        m_selectedTableList.Add(e.Node.Text.ToString().Substring(0, 2));//如表号"01"
                    }
                    else
                    {
                        m_selectedTableList.Remove(e.Node.Text.ToString().Substring(0, 2));
                    }
                    List<String> selectedTableList = new List<string>();
                    foreach (String str in m_selectedTableList)
                    {
                        selectedTableList.Add(str);
                    }
                    m_selectClientToolDictionary.Add(toolName, selectedTableList);
                }
                else
                {
                    for (int i = 0; i < m_selectClientToolDictionary.Count; i++)
                    {
                        if (m_selectClientToolDictionary.ElementAt(i).Key == toolName)//与所选仪器名一致
                        {
                            if (e.Node.Checked)
                            {
                                m_selectedTableList.Add(e.Node.Text.ToString().Substring(0, 2));//如表号"01"
                            }
                            else
                            {
                                m_selectedTableList.Remove(e.Node.Text.ToString().Substring(0, 2));
                            }
                            List<String> selectedTableList = new List<string>();
                            foreach (String str in m_selectedTableList)
                            {
                                selectedTableList.Add(str);
                            }
                            //每次添加前移除，确保最后一次添加的是所选仪器对应所选的表全集
                            m_selectClientToolDictionary.Remove(toolName);
                            m_selectClientToolDictionary.Add(toolName, selectedTableList);
                        }
                    }
                }
            }
        }

        private void clientSelectAll_button_Click(object sender, EventArgs e)
        {
            CheckAllParentNodes(clientWitsTable_treeView, true, true);
        }

        private void clientNoSelect_button_Click(object sender, EventArgs e)
        {
            CheckAllParentNodes(clientWitsTable_treeView, false, false);
        }
        
        private void clientConnect_button_Click(object sender, EventArgs e)
        {
             if (m_selectClientToolDictionary.Count > 0)
             {
                StartClientThread = new Thread(new ThreadStart(_startClient));
                StartClientThread.IsBackground = true; 
                StartClientThread.Start();
                clientConnect_button.Enabled = false;
                clientConnectStop_button.Enabled = true;
             }
             else
             {
                clientConnectStop_button.Enabled = false;
                MessageBox.Show("信息不完整，服务无法启动！");
             }
        }

        private void _startClient()
        {
            try
            {
                int port = int.Parse(tCPClientPort_textBox.Text);
                TCPUtil.AsynchronousTCPClient tcpClient = new TCPUtil.AsynchronousTCPClient();
                //此方法每接收到WITS数据，就传递给Main_Form处理
                tcpClient.StartClient(tCPClientIP_textBox.Text, port);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(">>StartClient线程" + ex.Message);
            }
        }
        
        private void clientConnectStop_button_Click(object sender, EventArgs e)
        {
            clientConnect_button.Enabled = true;
            clientConnectStop_button.Enabled = false;
        }
    }
}
