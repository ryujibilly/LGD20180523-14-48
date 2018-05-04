using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LGD.DAL.SQLite;
using System.Collections.Concurrent;
using System.Data.SQLite;
using System.Diagnostics;

namespace RealTimeDB
{
    public partial class RemoteWell : Form
    {

        #region 字段、属性
        private DataTable JsonTable = new DataTable();
        private String JsonString = string.Empty;
        private List<String> instName = new List<String>();
        private List<String> instDesc = new List<String>();
        private String curInst = String.Empty;
        private String instru = "";
        private List<String> nodeMap = new List<string>();
        //树形结构图涉及数据结构
        private String regionName = String.Empty;
        private String regionId = String.Empty;
        private String wellName = String.Empty;
        private String wellId = String.Empty;
        private String logName = String.Empty;
        private String logId = String.Empty;
        private List<String> wellidList = new List<string>();
        private List<String> wellnameList = new List<string>();
        private List<String> logidList = new List<string>();
        private List<String> lognameList = new List<string>();
        private List<List<String>> wellinfo = new List<List<string>>();
        private List<List<String>> loginfo = new List<List<string>>();
        private String selectedLogName;
        private String selectedLogId;
        private int selectedNodeLevel;

        /// <summary>
        /// 所有顶层工区的集合
        /// </summary>
        private List<Object> allRegions = new List<Object>();
        /// <summary>
        /// 顶层工区的节点集合
        /// </summary>
        private List<TreeNode> parentNodes = new List<TreeNode>();
        /// <summary>
        /// 工区名
        /// </summary>
        public string RegionName
        {
            get
            {
                return regionName;
            }

            set
            {
                regionName = value;
            }
        }
        /// <summary>
        /// 工区ID
        /// </summary>
        public string RegionId
        {
            get
            {
                return regionId;
            }

            set
            {
                regionId = value;
            }
        }
        /// <summary>
        /// 井ID
        /// </summary>
        public string WellId
        {
            get
            {
                return wellId;
            }

            set
            {
                wellId = value;
            }
        }

        /// <summary>
        /// 节点路径
        /// </summary>
        public List<string> NodeMap
        {
            get
            {
                return nodeMap;
            }

            set
            {
                nodeMap = value;
            }
        }
        /// <summary>
        /// 指定工区的井id集合
        /// </summary>
        public List<string> WellidList
        {
            get
            {
                return wellidList;
            }

            set
            {
                wellidList = value;
            }
        }
        /// <summary>
        /// 指定工区的井名称集合
        /// </summary>
        public List<string> WellnameList
        {
            get
            {
                return wellnameList;
            }

            set
            {
                wellnameList = value;
            }
        }
        /// <summary>
        /// 指定井的id集合
        /// </summary>
        public List<string> LogidList
        {
            get
            {
                return logidList;
            }

            set
            {
                logidList = value;
            }
        }
        /// <summary>
        /// 指定井的名称集合
        /// </summary>
        public List<string> LognameList
        {
            get
            {
                return lognameList;
            }

            set
            {
                lognameList = value;
            }
        }
        /// <summary>
        /// 井名
        /// </summary>
        public string WellName
        {
            get
            {
                return wellName;
            }

            set
            {
                wellName = value;
            }
        }
        /// <summary>
        /// 井次名
        /// </summary>
        public string LogName
        {
            get
            {
                return logName;
            }

            set
            {
                logName = value;
            }
        }
        /// <summary>
        /// 井次id
        /// </summary>
        public string LogId
        {
            get
            {
                return logId;
            }

            set
            {
                logId = value;
            }
        }
        /// <summary>
        /// 井信息
        /// </summary>
        public List<List<string>> Wellinfo
        {
            get
            {
                return wellinfo;
            }

            set
            {
                wellinfo = value;
            }
        }
        /// <summary>
        /// 井次信息
        /// </summary>
        public List<List<string>> Loginfo
        {
            get
            {
                return loginfo;
            }

            set
            {
                loginfo = value;
            }
        }
        /// <summary>
        /// 所选井次名
        /// </summary>
        public string SelectedLogName
        {
            get
            {
                return selectedLogName;
            }

            set
            {
                selectedLogName = value;
            }
        }
        /// <summary>
        /// 所选井次ID
        /// </summary>
        public string SelectedLogId
        {
            get
            {
                return selectedLogId;
            }

            set
            {
                selectedLogId = value;
            }
        }
        /// <summary>
        /// 所选节点深度
        /// </summary>
        public int SelectedNodeLevel
        {
            get
            {
                return selectedNodeLevel;
            }

            set
            {
                selectedNodeLevel = value;
            }
        }


        #endregion

        public RemoteWell()
        {
            InitializeComponent();
        }

        private void RemoteWell_Load(object sender, EventArgs e)
        {
            treeView_remoteWell.Nodes.Clear();
            initialTree();
        }
        /// <summary>
        /// 初始化顶层工区树
        /// </summary>
        private void initialTree()
        {
            try
            {
                DataTable dt = Pusher._pusher.GetAllRegions(out JsonString);
                foreach (DataRow dr in dt.Rows)
                {
                    allRegions.Add(dr.ItemArray[1]);
                    TreeNode tn = new TreeNode(dr.ItemArray[0].ToString());
                    tn.ToolTipText = dr.ItemArray[1].ToString();
                    parentNodes.Add(tn);
                }
                treeView_remoteWell.Nodes.AddRange(parentNodes.ToArray());
                treeView_remoteWell.Update();
                treeView_remoteWell.SelectedNode = null;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message+"\r\t <====== RemoteWell.cs-->initialTree() Error！======>");
            }
        }

        private void treeView_remoteWell_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                if (treeView_remoteWell.SelectedNode != null)
                {
                    String strSelectedid = e.Node.ToolTipText;
                    String strSelectedname = e.Node.Text;
                    switch (e.Node.Level)//TreeView层数
                    {
                        //通过工区节点 获取工区包含的井节点信息
                        case 0:
                            Wellinfo.Clear();
                            WellidList.Clear();
                            WellnameList.Clear();
                            RegionId = strSelectedid;
                            RegionName = strSelectedname;
                            Wellinfo = GetWellListByRegionId(RegionId);
                            for (int i = 0; i < WellnameList.Count; i++)
                            {
                                if (!getChildNodeList(e.Node).Contains(WellnameList[i]))
                                {
                                    TreeNode wellnode = new TreeNode(WellnameList[i]);
                                    wellnode.ToolTipText = WellidList[i];
                                    e.Node.Nodes.Add(wellnode);
                                }
                            }
                            SelectedNodeLevel = 0;
                            break;
                        //通过井节点 获取井包含的井次信息
                        case 1:
                            Loginfo.Clear();
                            LogidList.Clear();
                            LognameList.Clear();
                            WellId = strSelectedid;
                            WellName = strSelectedname;
                            Loginfo = GetLogListByWellId(WellId);
                            for (int i = 0; i < LognameList.Count; i++)
                            {
                                if (!getChildNodeList(e.Node).Contains(LognameList[i]))
                                {
                                    TreeNode lognode = new TreeNode(LognameList[i]);
                                    lognode.ToolTipText = LogidList[i];
                                    e.Node.Nodes.Add(lognode);
                                }
                            }
                            SelectedNodeLevel = 1;
                            break;
                        //选择井次
                        case 2:
                            LogName = e.Node.Text;
                            LogId = e.Node.ToolTipText;
                            SelectedNodeLevel = 2;
                            break;
                    }
                    initialNodeMap();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message + "\r\t <====== RemoteWell.cs-->treeView_remoteWell_AfterSelect() ,Error！======>");

            }
        }
        /// <summary>
        /// 获取子节点的名称集合
        /// </summary>
        /// <param name="node">所选节点</param>
        /// <returns>NameList</returns>
        private List<String> getChildNodeList(TreeNode node)
        {
            List<String> nodeNameList = new List<string>();
            foreach (TreeNode tn in node.Nodes)
              nodeNameList.Add(tn.Text);
            return nodeNameList;
        }


        /// <summary>
        /// 生成远程井次路径List
        /// </summary>
        private void initialNodeMap()
        {
        }
        /// <summary>
        /// 返回指定工区井信息
        /// </summary>
        /// <param name="rid">工区id</param>
        /// <returns>二维List,List[0]:wellnamelist;List[1]:wellidlist</returns>
        private List<List<String>> GetWellListByRegionId(String rid)
        {
            List<String> wellnameList = new List<string>();
            List<String> wellidList = new List<string>();
            try
            {
                DataTable dt = new DataTable();
                dt= Pusher._pusher.GetAllWellsByRegionId(rid, out JsonString);
                foreach (DataRow dr in dt.Rows)
                {
                    WellnameList.Add(dr[0].ToString());
                    WellidList.Add(dr[1].ToString());
                }
                List<List<String>> wellinfo = new List<List<string>>();
                Wellinfo.Add(WellnameList);
                Wellinfo.Add(WellidList);
                return Wellinfo;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message + "\r\t <====== RemoteWell.cs-->GetWellListByRegionId() ,Error！======>");
                return null;
            }
        }
        /// <summary>
        /// 返回指定井的井次信息
        /// </summary>
        /// <param name="wid">井id</param>
        /// <returns>二维List,List[0]:lognamelist;List[1]:logidlist</returns>
        private List<List<string>> GetLogListByWellId(string wid)
        {
            List<String> lognameList = new List<string>();
            List<String> logidList = new List<string>();
            try
            {
                DataTable dt = new DataTable();
                dt = Pusher._pusher.GetAllLogsByWellId(wid, out JsonString);
                foreach (DataRow dr in dt.Rows)
                {
                    LognameList.Add(dr[0].ToString());
                    LogidList.Add(dr[1].ToString());
                }
                List<List<String>> Loginfo = new List<List<string>>();
                Loginfo.Add(LognameList);
                Loginfo.Add(LogidList);
                return Loginfo;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message + "\r\t <====== RemoteWell.cs-->GetLogListByWellId() ,Error！======>");
                return null;
            }
        }

        private void treeView_remoteWell_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
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
            //int nodeLevel = e.Node.Level - 1;
            //if (e.Node.Nodes.Count == 0 && (e.Node.Level == 0 || e.Node.Level == 1))//没有子节点
            //{
            //    nodeLevel = nodeLevel + 1;
            //}
            if (e.Node.Level >= 0)
            {
                treeView_remoteWell.SelectedNode = e.Node;
                initContextMenuStrip(e.Node.Level).Show(treeView_remoteWell, e.X, e.Y);
            }
        }
        /// <summary>
        /// 根据节点深度初始化右键菜单：Region，Well，Log
        /// </summary>
        /// <param name="nodeLevel">节点深度</param>
        /// <returns>右键菜单</returns>
        private ContextMenuStrip initContextMenuStrip(int nodeLevel)
        {
            ContextMenuStrip cms = new ContextMenuStrip();
            switch(nodeLevel)
            {
                case 0:cms = contextMenuStrip_Region;
                    break;
                case 1:cms = contextMenuStrip_Well;
                    break;
                case 2:cms = contextMenuStrip_Log;
                    break;
                default:break;
            }
            return cms;
        }

        private void button_Ok_Click(object sender, EventArgs e)
        {
            if (SelectedNodeLevel == 2)
            {
                SelectedLogName = LogName;
                SelectedLogId = LogId;
                DialogResult = DialogResult.OK;
            }
            else if(SelectedNodeLevel<2)
            {
                MessageBox.Show("所选节点非井次！请选择井次节点！");
            }
        }
        /// <summary>
        /// 添加工区
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddRegion_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String newRegionName = String.Empty;
            AddItem ai = new AddItem("工区名","添加工区");
            ai.ShowDialog();
            if(ai.DialogResult==DialogResult.OK)
            {
                newRegionName = ai.ItemName;
                DataTable dt= Pusher._pusher.AddRegion("name",newRegionName, out JsonString);
            }
        }
        /// <summary>
        /// 添加井
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddWell_ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 添加井次
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddLog_ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            SelectedLogId = String.Empty;
            SelectedLogName = String.Empty;
            SelectedNodeLevel = 0;
            DialogResult = DialogResult.Cancel;
            this.Close();
            this.Dispose();
        }
    }
}
