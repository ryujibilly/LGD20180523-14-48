using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Xml;
using LGD.DAL.SQLite;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace WitsTransmission.WellConfig
{
    public partial class WellConfig_Form : Form
    {
        //RealDB路径
        private String m_strRealDBPath;
        //根目录
        private String m_strRootPath;
        //工区路径
        private String m_strWorkspacePath;
        //井路径
        private String m_strWellPath;
        //井次路径
        private String m_strWellcountPath;
        //井次名（数据库名为“井次名.db3"）
        private String m_strWellcount;
        //创建模板DB，仅用于第一次连接数据库
        private SQLiteDBHelper m_realDBHelper;
        public XMLUtil.XMLUtil m_xmlUtil= new XMLUtil.XMLUtil();
        private ContextMenuStrip m_contextMenuStrip = new ContextMenuStrip();
        public WellConfig_Form()
        {
            InitializeComponent();
        }

        private void WellConfig_Form_Load(object sender, EventArgs e)
        {
            //路径初始化
            XmlNodeList pathNodeList = m_xmlUtil.getChildNodes(m_xmlUtil.getRoot(m_xmlUtil.getDocument("Path.xml")));
            m_xmlUtil.m_xmlReader.Close();
            Trace.WriteLine("WellConfig_Form_Load----->getChildNodes()");
            setRealDBPath(pathNodeList.Item(0).Attributes["value"].Value);
            m_strRootPath = pathNodeList.Item(1).Attributes["value"].Value;
            m_strWorkspacePath = pathNodeList.Item(2).Attributes["value"].Value;
            m_strWellPath = pathNodeList.Item(3).Attributes["value"].Value;
            m_strWellcountPath = pathNodeList.Item(4).Attributes["value"].Value;
            currentPath_textBox.Text = m_strWellcountPath;
            String[] strWellcount = currentPath_textBox.Text.Split("\\".ToArray());
            setwellcount(strWellcount.Last());
        }

        public String getRealDBPath()
        {
            return m_strRealDBPath;
        }
        public void setRealDBPath(String str)
        {
            m_strRealDBPath = str;
        }
        public String getworkspacePath()
        {
            return m_strWorkspacePath;
        }
        public void setworkspacePath(String str)
        {
            m_strWorkspacePath = str;
        }
        public String getWellPath()
        {
            return m_strWellPath;
        }
        public void setWellPath(String str)
        {
            m_strWellPath = str;
        }
        public String getwellcountPath()
        {
            return m_strWellcountPath;
        }
        public void setwellcountPath(String str)
        {
            m_strWellcountPath = str;
        }

        public String getwellcount()
        {
            return m_strWellcount;
        }
        public void setwellcount(String str)
        {
            m_strWellcount = str;
        }
        public SQLiteDBHelper getRealDBHelper()
        {
            return  m_realDBHelper;
        }
        public void setRealDBHepler(SQLiteDBHelper helper)
        {
            m_realDBHelper = helper;
        }

        /// <summary>
        /// 创建目录及文件路径，在此目录下创建数据库及表
        /// </summary>
        /// <param name="dirPath"></param>
        /// <param name="filename"></param>
        /// <returns>filepath</returns>
        public String creatDirectory(String dirPath,String filename)
        {
            string filepath = System.IO.Path.Combine(dirPath, filename);
            if (!Directory.Exists(dirPath.ToString()))//Directory类的静态方法,用来判断目录是否存在
            {
                Directory.CreateDirectory(dirPath.ToString());//如果所要求的目录不存在,调用Directory的静态方法CreateDirectory创建目录.
            }
            return filepath;
        }

        private void getWellMessage_button_Click(object sender, EventArgs e)
        {
            //wellConfig_treeView添加初始化数据
            wellConfig_treeView.Nodes.Clear();
            //从WITS.xml中读取相应workspace信息，加载到wellConfig_treeView第一级节点
            TreeNode rootNode; 
            XmlNodeList workspaceNodeList = m_xmlUtil.getChildNodes(m_xmlUtil.getRoot(m_xmlUtil.getDocument("Well.xml")));
            m_xmlUtil.m_xmlReader.Close();
            Trace.WriteLine("getWellMessage_button_Click----->getChildNodes()");
            foreach (XmlNode node in workspaceNodeList)
            {
                rootNode = new TreeNode();
                rootNode.Text += node.Attributes["name"].Value;
                wellConfig_treeView.Nodes.Add(rootNode);
            }
        }
        //仅在完整路径时可点击
        private void finishConfig_button_Click(object sender, EventArgs e)
        {
            //currentPath_textBox.Text仅在路径完整时被赋值，所以其为完整路径，但在删除节点时路径不完整
            //将本次选择的完整路径写入Path.xml（仅存上次写库的完整路径）,记录上次写库路径以便在下次选择路径时若不需要改变路径则直接使用
            if (currentPath_textBox.Text == m_strWellcountPath)//路径为同一路径
            {
                
                String[] strWellcountPath = currentPath_textBox.Text.Split("\\".ToArray());
                int Length = strWellcountPath.Length;
                XmlNodeList pathNodeList = m_xmlUtil.getChildNodes(m_xmlUtil.getRoot(m_xmlUtil.getDocument("Path.xml")));
                m_xmlUtil.m_xmlReader.Close();
                Trace.WriteLine("finishConfig_button_Click----->getChildNodes()");
                pathNodeList.Item(2).Attributes["value"].Value = m_strRootPath + "\\" + strWellcountPath[Length - 3];
                pathNodeList.Item(3).Attributes["value"].Value = m_strRootPath + "\\" + strWellcountPath[Length - 3] + "\\" + strWellcountPath[Length - 2];
                pathNodeList.Item(4).Attributes["value"].Value = currentPath_textBox.Text;
                m_xmlUtil.m_xmlDoc.Save(@"..\..\..\ConfigFile\" + "Path.xml");
                m_xmlUtil.m_xmlReader.Close();
                setwellcount(strWellcountPath.Last());
                SQLiteDBHelper dbhelper = new SQLiteDBHelper(getRealDBPath());
                setRealDBHepler(dbhelper);
                this.DialogResult = DialogResult.OK;
                this.Close();//关闭窗口
            }
            else
            {
                MessageBox.Show("选择与写库路径不同，请重新选择！");
            }
         
        }

        private void wellConfig_treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //选择的节点内容
            string strSelect = e.Node.Text;
            switch(e.Node.Level)//TreeView层数
            {
                //根据wellConfig_treeView一级节点选择从WITS.xml中读取相应well信息，加载到wellConfig_treeView第二级节点
                case 0:
                //if (e.Node.Parent == null)//无父节点（wellConfig_treeView一级节点）
                    setworkspacePath(m_strRootPath + "\\" + strSelect);
                    List<String> wellList = new List<String>();
                    wellList = m_xmlUtil.getSubChildNodes(m_xmlUtil.getChildNodes(m_xmlUtil.getRoot(m_xmlUtil.getDocument("Well.xml"))), "name", strSelect);
                    m_xmlUtil.m_xmlReader.Close();
                    Trace.WriteLine("wellConfig_treeView_AfterSelect--case0:--->getSubChildNodes()");
                    foreach (String strWell in wellList)
                    {
                        TreeNode childNode = new TreeNode();
                        childNode.Text += strWell;
                        //wellConfig_treeView中该项不存在，则添加
                        if (e.Node.Nodes.Count <= 0)//一级节点的二级节点为空，加载二级节点
                        {
                            e.Node.Nodes.Add(childNode);
                        }
                        else
                        {
                            List<string> tnList = new List<string>();
                            foreach (TreeNode tn in e.Node.Nodes)
                            {
                                tnList.Add(tn.Text);
                            }
                            if (!tnList.Contains(childNode.Text))
                            {
                                e.Node.Nodes.Add(childNode);
                            }
                        }
                    }
                    //路径不完整，按钮不可点击
                    finishConfig_button.Enabled = false;
                    break;
                //根据wellConfig_treeView二级节点选择从WITS.xml中读取相应wellcount信息，加载到wellConfig_treeView第三级节点
                //if (e.Node.Parent != null && e.Node.Parent.Parent == null)//父节点不为空，父节点的父节点为空（第二级节点）
                case 1:
                    setWellPath(m_strRootPath + "\\" + e.Node.Parent.Text + "\\" + strSelect);
                    List<String> wellcountList = new List<String>();
                    XmlNodeList nodeList = m_xmlUtil.getSubChildNodeList(m_xmlUtil.getChildNodes(m_xmlUtil.getRoot(m_xmlUtil.getDocument("Well.xml"))), "name", e.Node.Parent.Text);
                    m_xmlUtil.m_xmlReader.Close();
                    Trace.WriteLine("wellConfig_treeView_AfterSelect--case1:--->getSubChildNodes()");
                    if (nodeList != null)
                    {
                        wellcountList = m_xmlUtil.getSubSubChildNodes(nodeList, "name", strSelect);
                        m_xmlUtil.m_xmlReader.Close();
                        Trace.WriteLine("wellConfig_treeView_AfterSelect--case1:--->getSubSubChildNodes()");
                    }
                    foreach (String strWellcount in wellcountList)
                    {
                        TreeNode childNode = new TreeNode();
                        childNode.Text += strWellcount;
                        //wellConfig_treeView中该项不存在，则添加
                        if (e.Node.Nodes.Count <= 0)//二级节点的三级节点为空
                        {
                            e.Node.Nodes.Add(childNode);
                        }
                        else
                        {
                            List<string> tnList = new List<string>();
                            foreach (TreeNode tn in e.Node.Nodes)
                            {
                                tnList.Add(tn.Text);
                            }
                            if (!tnList.Contains(childNode.Text))
                            {
                                e.Node.Nodes.Add(childNode);
                            }
                        }
                    }
                    //路径不完整，按钮不可点击
                    finishConfig_button.Enabled = false;
                    break;
                //if (e.Node.Parent != null && e.Node.Parent.Parent !=null && e.Node.Parent.Parent.Parent == null)//父节点不为空，父节点的父节点不为空（第三级节点）
                case 2:
                    setwellcountPath(m_strRootPath + "\\" + e.Node.Parent.Parent.Text + "\\" + e.Node.Parent.Text + "\\" + strSelect);
                    //只在路径完整时赋值
                    currentPath_textBox.Text = m_strWellcountPath;
                    setwellcount(e.Node.Text.ToString());
                    //路径完整，按钮可点击
                    finishConfig_button.Enabled = true;
                    break;
                default:
                    //路径不完整，按钮不可点击
                    finishConfig_button.Enabled = false;
                    break;
            }
        }

        private void wellConfig_treeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
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
            int nodeLevel = e.Node.Level-1;
            if (e.Node.Nodes.Count == 0 && (e.Node.Level==0||e.Node.Level==1))//没有子节点
            {
                nodeLevel = nodeLevel + 1;
            }
            wellConfig_treeView.SelectedNode = e.Node;
            initContextMenuStrip(nodeLevel);
            m_contextMenuStrip.Show(wellConfig_treeView, e.X, e.Y);
        }

        private void initContextMenuStrip(int nodeLevel)
        {
            m_contextMenuStrip.Items.Clear();
            switch (nodeLevel)
            { 
                case -1:
                    ToolStripMenuItem createWorkspace = new ToolStripMenuItem("新建工区");
                    createWorkspace.Click += new EventHandler(NewToolStripMenuItem_Click);
                    m_contextMenuStrip.Items.Add(createWorkspace);
                    ToolStripMenuItem alterWorkspace = new ToolStripMenuItem("修改工区");
                    alterWorkspace.Click += new EventHandler(AlterToolStripMenuItem_Click);
                    m_contextMenuStrip.Items.Add(alterWorkspace);
                    ToolStripMenuItem deleteWorkspace = new ToolStripMenuItem("删除工区");
                    deleteWorkspace.Click += new EventHandler(DeleteToolStripMenuItem_Click);
                    m_contextMenuStrip.Items.Add(deleteWorkspace);
                    break;
                case 0:
                    ToolStripMenuItem createWell = new ToolStripMenuItem("新建井");
                    createWell.Click += new EventHandler(NewToolStripMenuItem_Click);
                    m_contextMenuStrip.Items.Add(createWell);
                    ToolStripMenuItem alterWell = new ToolStripMenuItem("修改井");
                    alterWell.Click += new EventHandler(AlterToolStripMenuItem_Click);
                    m_contextMenuStrip.Items.Add(alterWell);
                    ToolStripMenuItem deleteWell = new ToolStripMenuItem("删除井");
                    deleteWell.Click += new EventHandler(DeleteToolStripMenuItem_Click);
                    m_contextMenuStrip.Items.Add(deleteWell);
                    break;
                case 1:
                    ToolStripMenuItem createWellcount = new ToolStripMenuItem("新建井次");
                    createWellcount.Click += new EventHandler(NewToolStripMenuItem_Click);
                    m_contextMenuStrip.Items.Add(createWellcount);
                    ToolStripMenuItem alterWellcount = new ToolStripMenuItem("修改井次");
                    alterWellcount.Click += new EventHandler(AlterToolStripMenuItem_Click);
                    m_contextMenuStrip.Items.Add(alterWellcount);
                    ToolStripMenuItem deleteWellcount = new ToolStripMenuItem("删除井次");
                    deleteWellcount.Click += new EventHandler(DeleteToolStripMenuItem_Click);
                    m_contextMenuStrip.Items.Add(deleteWellcount);
                    break;
                default:
                    break;
            }
        }

        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string strMenuItemSelected = sender.ToString();
            switch (strMenuItemSelected)
            { 
                case "新建工区":
                    if (!Directory.Exists(m_strRootPath))
                    {
                        Directory.CreateDirectory(m_strRootPath);
                    }
                    // 设置对话框的说明信息
                    folderBrowserDialog1.Description = "新建工区文件夹";
                    // 设置当前选择的路径
                    folderBrowserDialog1.SelectedPath = m_strRootPath;
                    if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                    {
                        setworkspacePath(folderBrowserDialog1.SelectedPath);
                        String[] strWorkspace = m_strWorkspacePath.Split("\\".ToArray());
                        TreeNode treeNodeAdd = new TreeNode();
                        treeNodeAdd.Text = strWorkspace.Last();
                        //wellConfig_treeView中该项不存在，则添加
                        if (wellConfig_treeView.Nodes.Count <= 0)//一级节点的二级节点为空，加载二级节点
                        {
                            wellConfig_treeView.Nodes.Add(treeNodeAdd);
                        }
                        else
                        {
                            List<string> tnList = new List<string>();
                            foreach (TreeNode tn in wellConfig_treeView.Nodes)
                            {
                                tnList.Add(tn.Text);
                            }
                            if (!tnList.Contains(treeNodeAdd.Text))
                            {
                                wellConfig_treeView.Nodes.Add(treeNodeAdd);
                            }
                        }
                        TreeNode selectedTreeNode = wellConfig_treeView.SelectedNode;
                        m_xmlUtil.addNewXmlNode("Well.xml",0, selectedTreeNode, "workspace", "name", treeNodeAdd.Text);
                        m_xmlUtil.m_xmlReader.Close();
                    }
                    break;
                case "新建井":
                    // 设置当前选择的路径
                    if (!Directory.Exists(m_strWorkspacePath))
                    {
                        Directory.CreateDirectory(m_strWorkspacePath);
                    }
                    folderBrowserDialog1.SelectedPath = m_strWorkspacePath;
                    folderBrowserDialog1.Description = "新建井文件夹";
                    if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                    {
                        setWellPath(folderBrowserDialog1.SelectedPath);
                        String[] strWell = m_strWellPath.Split("\\".ToArray());
                        TreeNode selectedTreeNode = wellConfig_treeView.SelectedNode;
                        TreeNode treeNodeAdd = new TreeNode();
                        treeNodeAdd.Text = strWell.Last();
                        if (selectedTreeNode.Nodes.Count <= 0)//一级节点的二级节点为空，加载二级节点
                        {
                            selectedTreeNode.Nodes.Add(treeNodeAdd);
                        }
                        else
                        {
                            List<string> tnList = new List<string>();
                            foreach (TreeNode tn in wellConfig_treeView.Nodes)
                            {
                                tnList.Add(tn.Text);
                            }
                            if (!tnList.Contains(treeNodeAdd.Text))
                            {
                                selectedTreeNode.Parent.Nodes.Add(treeNodeAdd);
                            }
                        }
                        m_xmlUtil.addNewXmlNode("Well.xml", 1,selectedTreeNode, "well", "name", treeNodeAdd.Text);
                        m_xmlUtil.m_xmlReader.Close();
                    }
                    break;
                case "新建井次":
                    if (!Directory.Exists(m_strWellPath))
                    {
                        Directory.CreateDirectory(m_strWellPath);
                    }
                    folderBrowserDialog1.SelectedPath = m_strWellPath;
                    folderBrowserDialog1.Description = "新建井次文件夹";
                    if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                    {
                        setwellcountPath(folderBrowserDialog1.SelectedPath);
                        String[] strWellcount = m_strWellcountPath.Split("\\".ToArray());
                        setwellcount(strWellcount.Last());
                        //只在路径完整时赋值
                        currentPath_textBox.Text = m_strWellcountPath;
                        TreeNode selectedTreeNode = wellConfig_treeView.SelectedNode;
                        TreeNode treeNodeAdd = new TreeNode();
                        treeNodeAdd.Text = m_strWellcount;
                        if (selectedTreeNode.Nodes.Count <= 0)//二级节点的三级节点为空，加载三级节点
                        {
                            switch (selectedTreeNode.Level)
                            {
                                case 1:
                                    selectedTreeNode.Nodes.Add(treeNodeAdd);
                                    break;
                                case 2:
                                    selectedTreeNode.Parent.Nodes.Add(treeNodeAdd);
                                    break;
                                default:
                                    break;
                            }
                            
                        }
                        else
                        {
                            List<string> tnList = new List<string>();
                            foreach (TreeNode tn in wellConfig_treeView.Nodes)
                            {
                                tnList.Add(tn.Text);
                            }
                            if (!tnList.Contains(treeNodeAdd.Text))
                            {
                                switch (selectedTreeNode.Level)
                                {
                                    case 1:
                                        selectedTreeNode.Nodes.Add(treeNodeAdd);
                                        break;
                                    case 2:
                                        selectedTreeNode.Parent.Nodes.Add(treeNodeAdd);
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }
                        m_xmlUtil.addNewXmlNode("Well.xml", 2, selectedTreeNode, "wellcount", "name", treeNodeAdd.Text);
                        m_xmlUtil.m_xmlReader.Close();
                    }
                    break;
                default:
                    break;
            }
        }

        private void AlterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string strSelected = sender.ToString();
            switch (strSelected)
            {
                case "修改工区":
                    folderBrowserDialog1.ShowNewFolderButton = false;
                    // 设置当前选择的路径
                    if (!Directory.Exists(m_strWorkspacePath))
                    {
                        Directory.CreateDirectory(m_strWorkspacePath);
                    }
                    folderBrowserDialog1.SelectedPath = m_strWorkspacePath;
                    folderBrowserDialog1.Description = "修改工区文件夹名";
                    if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                    {
                        setworkspacePath(folderBrowserDialog1.SelectedPath);
                        String[] strWorkspace = m_strWorkspacePath.Split("\\".ToArray());
                        TreeNode selectedTreeNode = wellConfig_treeView.SelectedNode;
                        m_xmlUtil.alterXmlNode("Well.xml", selectedTreeNode, "name", strWorkspace.Last());
                        m_xmlUtil.m_xmlReader.Close();
                        selectedTreeNode.Text= strWorkspace.Last();
                    }
                    break;
                case "修改井":
                    folderBrowserDialog1.ShowNewFolderButton = false;
                    if (!Directory.Exists(m_strWellPath))
                    {
                        Directory.CreateDirectory(m_strWellPath);
                    }
                    folderBrowserDialog1.SelectedPath = m_strWellPath;
                    folderBrowserDialog1.Description = "修改井文件夹名";
                    if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                    {
                        setWellPath(folderBrowserDialog1.SelectedPath);
                        String[] strWell = m_strWellPath.Split("\\".ToArray());
                        TreeNode selectedTreeNode = wellConfig_treeView.SelectedNode;
                        m_xmlUtil.alterXmlNode("Well.xml", selectedTreeNode, "name", strWell.Last());
                        m_xmlUtil.m_xmlReader.Close();
                        selectedTreeNode.Text = strWell.Last();
                    }
                    break;
                case "修改井次":
                    folderBrowserDialog1.ShowNewFolderButton = false;
                    if (!Directory.Exists(m_strWellcountPath))
                    {
                        Directory.CreateDirectory(m_strWellcountPath);
                    }
                    folderBrowserDialog1.SelectedPath = m_strWellcountPath;
                    folderBrowserDialog1.Description = "修改井次文件夹名";
                    if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                    {
                        setwellcountPath(folderBrowserDialog1.SelectedPath);
                        String[] strWellcount = m_strWellcountPath.Split("\\".ToArray());
                        setwellcount(strWellcount.Last());
                        TreeNode selectedTreeNode = wellConfig_treeView.SelectedNode;
                        m_xmlUtil.alterXmlNode("Well.xml", selectedTreeNode, "name", strWellcount.Last());
                        m_xmlUtil.m_xmlReader.Close();
                        selectedTreeNode.Text = strWellcount.Last();
                        //只在路径完整时赋值
                        currentPath_textBox.Text = m_strWellcountPath;
                    }
                    break;
                default:
                    break;
            }
        }
        //防止误操作删除数据库数据，只删除wellConfig_treeView、Well.xml和Path.xml显示和加载的路径，不实际删除文件
        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string strSelected = sender.ToString();
            TreeNode selectedTreeNode = wellConfig_treeView.SelectedNode;
            switch (strSelected)
            {
                case "删除工区":
                    m_xmlUtil.deleteXmlNode("Well.xml", selectedTreeNode, "name");
                    m_xmlUtil.m_xmlReader.Close();
                    wellConfig_treeView.SelectedNode.Remove();
                    currentPath_textBox.Text = m_strRootPath;
                    break;
                case "删除井":
                    m_xmlUtil.deleteXmlNode("Well.xml", selectedTreeNode, "name");
                    m_xmlUtil.m_xmlReader.Close();
                    wellConfig_treeView.SelectedNode.Remove();
                    if (selectedTreeNode.Level == -1)//井已被删除，仅剩工区时，用于删除路径中的工区
                    {
                        currentPath_textBox.Text = getworkspacePath();
                        break;
                    }
                    currentPath_textBox.Text = m_strRootPath;
                    break;
                case "删除井次":
                    m_xmlUtil.deleteXmlNode("Well.xml", selectedTreeNode, "name");
                    m_xmlUtil.m_xmlReader.Close();
                    wellConfig_treeView.SelectedNode.Remove();
                    if (selectedTreeNode.Level == 0)//井次已被删除，仅剩工区和井时，用于删除路径中的井
                    {
                        currentPath_textBox.Text = getworkspacePath();
                        break;
                    }
                    currentPath_textBox.Text = getWellPath();
                    break;
                default:
                    break;
            }
        }

     }
}
