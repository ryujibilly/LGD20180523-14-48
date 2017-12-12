using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace WitsTransmission.WitsSend
{
    public partial class SendConfig_Form : Form
    {
       
        public const int USER = 0x500;
        public const int SENDDATAMESSAGE = USER + 3;
        private ContextMenuStrip m_contextMenuStrip = new ContextMenuStrip();
        public String m_tcpClientIP;
        public String m_tcpClientPort;
        public String m_tcpServerIP;
        public String m_tcpServerPort;
        public Thread StartServerThread;
        public volatile bool m_isStartServer;//加volatile关键字，确保变量调用线程和修改线程值一致
        public Thread StartClientThread;
        public Thread SendDataDispalyThread;
        public String m_strReceiveData;//保存TCPServer通过消息发送来的WITS数据
        public String m_strSendData="";//保存出队数据，供发送使用
        public Dictionary<string, Socket> m_clientSocketDic = new Dictionary<string, Socket> { };
        public ConcurrentQueue<String> m_tempSendDataQueue = new ConcurrentQueue<String>();
        TCPUtil.AsynchronousTCPServer m_tcpServer = new TCPUtil.AsynchronousTCPServer();
        //定义为private对象，避免锁不可控
        private Object thisLock;
        
        protected override void DefWndProc(ref Message m)
        {
            thisLock = new Object();//实现临界区同步锁
            lock (thisLock)
            {
                switch (m.Msg)
                {
                    //接收自定义消息SENDDATAMESSAGE，一次接收的WITS数据并显示其参数
                    case SENDDATAMESSAGE:
                        WitsTransmission.TCPUtil.SendDataStruct contentStruct = new WitsTransmission.TCPUtil.SendDataStruct();//这是创建自定义信息的结构
                        Type mytype2 = contentStruct.GetType();
                        contentStruct = (WitsTransmission.TCPUtil.SendDataStruct)m.GetLParam(mytype2);//这里获取的就是作为LParam参数发送来的信息的结构
                        m_strReceiveData = contentStruct.lpData; //显示收到的自定义信息
                        m_tempSendDataQueue.Enqueue(m_strReceiveData);
                        break;
                    default:
                        base.DefWndProc(ref m);
                        break;
                }
            }
        }

        public SendConfig_Form()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void SendConfig_Form_Load(object sender, EventArgs e)
        {

        }

        private void tcpMode_treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //选择的节点内容
            string strSelect = e.Node.Text;
            switch (e.Node.Level)//TreeView层数
            { 
                case 1:
                    if (e.Node.Parent.Text == "TcpClient")
                    {
                    
                    }
                    if (e.Node.Parent.Text == "TcpServer")
                    {
                    
                    }
                    break;
                default:
                    break;
            }
        }

        private void tcpMode_treeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button != MouseButtons.Right)//不是右键
            {
                return;
            }
            if (e.Node == null)//无节点 
            {
                return;
            }
            if (e.Node.Level < 0)
            {
                return;
            }
            int nodeLevel = e.Node.Level;
            tcpMode_treeView.SelectedNode = e.Node;
            initContextMenuStrip(nodeLevel);
            m_contextMenuStrip.Show(tcpMode_treeView, e.X, e.Y);
        }

        private void initContextMenuStrip(int nodeLevel)
        {
            m_contextMenuStrip.Items.Clear();
            ToolStripMenuItem createClient = new ToolStripMenuItem("创建Client");
            createClient.Click += new EventHandler(NewClientToolStripMenuItem_Click);
            m_contextMenuStrip.Items.Add(createClient);
            ToolStripMenuItem createServer = new ToolStripMenuItem("创建Server");
            createServer.Click += new EventHandler(NewServerToolStripMenuItem_Click);
            m_contextMenuStrip.Items.Add(createServer);
            ToolStripMenuItem clientConnect = new ToolStripMenuItem("Client连接");
            clientConnect.Click += new EventHandler(ClientConnectToolStripMenuItem_Click);
            m_contextMenuStrip.Items.Add(clientConnect);
            ToolStripMenuItem clientDisconnect = new ToolStripMenuItem("断开Client连接");
            clientDisconnect.Click += new EventHandler(ClientDisconnectToolStripMenuItem_Click);
            m_contextMenuStrip.Items.Add(clientDisconnect);
            ToolStripMenuItem startServer = new ToolStripMenuItem("启动Server");
            startServer.Click += new EventHandler(StartServerToolStripMenuItem_Click);
            m_contextMenuStrip.Items.Add(startServer);
            ToolStripMenuItem stopServer = new ToolStripMenuItem("停止Server");
            stopServer.Click += new EventHandler(StopServerToolStripMenuItem_Click);
            m_contextMenuStrip.Items.Add(stopServer);
            ToolStripMenuItem deleteConnect = new ToolStripMenuItem("删除连接");
            deleteConnect.Click += new EventHandler(DeleteConnectToolStripMenuItem_Click);
            m_contextMenuStrip.Items.Add(deleteConnect);
            ToolStripMenuItem disconnectAll = new ToolStripMenuItem("全部断开");
            disconnectAll.Click += new EventHandler(DisconnectAllToolStripMenuItem_Click);
            m_contextMenuStrip.Items.Add(disconnectAll);
            ToolStripMenuItem deleteAll = new ToolStripMenuItem("删除所有连接");
            deleteAll.Click += new EventHandler(DeleteAllToolStripMenuItem_Click);
            m_contextMenuStrip.Items.Add(deleteAll);
            ToolStripMenuItem exit = new ToolStripMenuItem("退出");
            exit.Click += new EventHandler(ExitToolStripMenuItem_Click);
            m_contextMenuStrip.Items.Add(exit);
            switch (nodeLevel)
            {
                case 0:
                    if (tcpMode_treeView.SelectedNode.Text == "TcpClient")
                    {
                        createClient.Enabled = true;
                        createServer.Enabled = false;
                        clientConnect.Enabled = false;
                        clientDisconnect.Enabled = false;
                        startServer.Enabled = false;
                        stopServer.Enabled = false;
                        deleteConnect.Enabled = false;
                        disconnectAll.Enabled = true;
                        deleteAll.Enabled = true;
                    }
                    if (tcpMode_treeView.SelectedNode.Text == "TcpServer")
                    {
                        createClient.Enabled = false;
                        createServer.Enabled = true;
                        clientConnect.Enabled = false;
                        clientDisconnect.Enabled = false;
                        startServer.Enabled = false;
                        stopServer.Enabled = false;
                        deleteConnect.Enabled = false;
                        disconnectAll.Enabled = true;
                        deleteAll.Enabled = true;
                    }
                    break;
                case 1:
                    if (tcpMode_treeView.SelectedNode.Parent.Text == "TcpClient")
                    {
                        createClient.Enabled = true;
                        createServer.Enabled = false;
                        clientConnect.Enabled = true;
                        clientDisconnect.Enabled = true;
                        startServer.Enabled = false;
                        stopServer.Enabled = false;
                        deleteConnect.Enabled = true;
                        disconnectAll.Enabled = false;
                        deleteAll.Enabled = false;
                    }
                    if (tcpMode_treeView.SelectedNode.Parent.Text == "TcpServer")
                    {
                        createClient.Enabled = false;
                        createServer.Enabled = true;
                        clientConnect.Enabled = false;
                        clientDisconnect.Enabled = false;
                        startServer.Enabled = true;
                        stopServer.Enabled = true;
                        deleteConnect.Enabled = true;
                        disconnectAll.Enabled = false;
                        deleteAll.Enabled = false;
                    }
                    break;
                default:
                    break;
            }
        }

        private void NewClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TcpClientConfig_Form tcpClientConfig_Form = new TcpClientConfig_Form();
            tcpClientConfig_Form.ShowDialog();
            m_tcpClientIP = tcpClientConfig_Form.getIP();
            m_tcpClientPort = tcpClientConfig_Form.getPort();
            String str = m_tcpClientIP + ":" + m_tcpClientPort;
            if (str == ":")//tcpClientConfig_Form点击取消按钮
            {
                return;
            }
            addTreeNode(tcpMode_treeView,str);
        }

        private void _startClient()
        {
            try
            {       
                int port = int.Parse(m_tcpClientPort);
                TCPUtil.AsynchronousTCPClient tcpClient = new TCPUtil.AsynchronousTCPClient();
                //此方法每接收到WITS数据，就发送给远程Server
                tcpClient.StartClient(m_tcpClientIP, port);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(">>StartClient线程" + ex.Message);
            }
        }

        private void NewServerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TcpServerConfig_Form tcpServerConfig_Form = new TcpServerConfig_Form();
            tcpServerConfig_Form.ShowDialog();
            m_tcpServerIP = tcpServerConfig_Form.getIP();
            m_tcpServerPort = tcpServerConfig_Form.getPort();
            String str = m_tcpServerIP + ":" + m_tcpServerPort;
            if (str == ":")//tcpServerConfig_Form点击取消按钮
            {
                return;
            }
            addTreeNode(tcpMode_treeView,str);
        }

        private void ClientConnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartClientThread = new Thread(new ThreadStart(_startClient));
            StartClientThread.Start();
        }

        private void ClientDisconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void StartServerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartServerThread = new Thread(new ThreadStart(_startServer));
            StartServerThread.IsBackground = true; //随主线程结束而结束
            m_isStartServer = true;
            StartServerThread.Start();
            SendDataDispalyThread = new Thread(new ThreadStart(_sendDataDisplay));
            SendDataDispalyThread.IsBackground = true; 
            SendDataDispalyThread.Start();
        }

        private void _startServer()
        {
            try
            {
                int port = int.Parse(m_tcpServerPort);
                m_tcpServer.StartListeningSend(m_tcpServerIP, port);
                String str;
                while(m_isStartServer)
                {
                    if (m_tempSendDataQueue.TryDequeue(out str))
                    {
                        m_strSendData = str;
                        m_clientSocketDic = m_tcpServer.getClientSocketDic();
                        //发送接收到数据给，所有连接m_tcpServer的Client
                        foreach (String strKey in m_clientSocketDic.Keys)
                        {
                            Socket clientSocket;
                            if (m_clientSocketDic.TryGetValue(strKey, out clientSocket))
                            {
                                m_tcpServer.Send(clientSocket, str);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(">>StartServer线程" + ex.Message);
            }
        }

        private void _sendDataDisplay()
        {
            while (true)
            {
                DataDisplay_tabControl.SelectedIndex = 0;
                TabPage tp = DataDisplay_tabControl.TabPages[0];
                foreach (RichTextBox rt in tp.Controls)
                {
                    //设置光标的位置到文本尾   
                    rt.Select(rt.TextLength, 0);
                    //滚动到控件光标处   
                    rt.ScrollToCaret();
                    //rt.AppendText(m_strSendData);
                    rt.Text += m_strSendData;
                    rt.Update();
                    if (rt.TextLength>=1000)
                    {
                        rt.Clear();
                    }
                }
            }
        }

        private void StopServerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_isStartServer = false;
        }

        private void DeleteConnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (TabPage page in DataDisplay_tabControl.TabPages)
            {
                //TreeView选择的节点与TabPage一致
                if (page.Text == tcpMode_treeView.SelectedNode.Text)
                {
                    DataDisplay_tabControl.TabPages.Remove(page);
                    page.Dispose();
                    tcpMode_treeView.SelectedNode.Remove();
                    return;
                }
            }
        }

        private void DisconnectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void DeleteAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //一级节点无子节点
            if (tcpMode_treeView.SelectedNode.Nodes == null)
            {
                return;
            }
            foreach (TabPage page in DataDisplay_tabControl.TabPages)
            {
                DataDisplay_tabControl.TabPages.Remove(page);
                page.Dispose();
            }
            tcpMode_treeView.SelectedNode.Nodes.Clear();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_contextMenuStrip.Hide();
        }
        //添加TreeView节点并添加对应的TabPage
        public void addTreeNode(TreeView treeView, String nodeText)
        {
            TreeNode selectedTreeNode = treeView.SelectedNode;
            TreeNode treeNodeAdd = new TreeNode();
            treeNodeAdd.Text = nodeText;
            switch (selectedTreeNode.Level)
            {
                case 0://一级节点的二级节点为空，加载二级节点
                    if (selectedTreeNode.Nodes.Count <= 0)
                    {
                        selectedTreeNode.Nodes.Add(treeNodeAdd);
                    }
                    else
                    {
                        List<string> tnList0 = new List<string>();
                        foreach (TreeNode tn in selectedTreeNode.Nodes)
                        {
                            tnList0.Add(tn.Text);
                        }
                        if (!tnList0.Contains(treeNodeAdd.Text))
                        {
                            selectedTreeNode.Nodes.Add(treeNodeAdd);
                        }
                    }
                    addTabPage(DataDisplay_tabControl, nodeText);
                    break;
                case 1://直接加到二级节点
                    List<string> tnList1 = new List<string>();
                    foreach (TreeNode tn in selectedTreeNode.Parent.Nodes)
                    {
                        tnList1.Add(tn.Text);
                    }
                    if (!tnList1.Contains(treeNodeAdd.Text))
                    {
                        selectedTreeNode.Parent.Nodes.Add(treeNodeAdd);
                    }
                    addTabPage(DataDisplay_tabControl, nodeText);
                    break;
                default:
                    break;
            }
        }
        //添加tabPage
        public void addTabPage(TabControl tabControl,String pagename)
        { 
            //判断是否已创建过
            foreach (TabPage page in tabControl.TabPages)
            {
                if (page.Text == pagename)
                {
                    tabControl.SelectedTab = page;//显示该页
                    return;
                }
            }
            //需要添加的控件
            RichTextBox richTextBox = new RichTextBox();
            richTextBox.ReadOnly = true;
            richTextBox.ScrollBars = RichTextBoxScrollBars.Vertical;
            richTextBox.Height = 310;
            richTextBox.Width = 295;
            //增加tabpage
            TabPage tabpage = new TabPage();
            tabpage.Name = pagename;
            tabpage.Text = pagename;
            tabpage.Controls.Add(richTextBox);//添加要增加的控件
            tabControl.TabPages.Add(tabpage);
            tabControl.SelectedTab = tabpage;//显示该页
        }
    }
}
