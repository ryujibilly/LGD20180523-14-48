using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace WitsTransmission.Model
{
    public class WitsTableDictionary : Dictionary<String, DataTable>
    {
        //private String m_toolName;
        public List<String> m_itemAttributesList = new List<String>();
        private XMLUtil.XMLUtil m_xmlUtil = new XMLUtil.XMLUtil();
        public WitsTableDictionary()
        {
            m_itemAttributesList.Add("index");
            m_itemAttributesList.Add("short-mnemonic");
        }
        public DataTable createTable(String tableNo,List<String> itemIndexList,List<String> curveNameList)
        {
            DataTable witsTable = new DataTable();
            //为m_witsTable添加列 
            DataColumn dctemp1 = new DataColumn("ItemIndex", Type.GetType("System.String"));
            DataColumn dctemp2 = new DataColumn("CurveName", Type.GetType("System.String"));
            DataColumn dctemp3 = new DataColumn("Value", Type.GetType("System.String"));
            witsTable.Columns.Add(dctemp1);
            witsTable.Columns.Add(dctemp2);
            witsTable.Columns.Add(dctemp3);
            int i = 0;
            foreach (String strItemIndex in itemIndexList)
            {
                DataRow drTemp = witsTable.NewRow();
                drTemp["ItemIndex"] = strItemIndex;
                drTemp["CurveName"] = curveNameList[i];
                witsTable.Rows.Add(drTemp);
                i++;
            }
            return witsTable;
        }

        public Dictionary<String, DataTable> createDictionary(String toolName, List<String> tableNoList)
        {
            Dictionary<String, DataTable> dic = new Dictionary<string, DataTable>();
            foreach (String tableNo in tableNoList)
            {
                //根据toolName选择和tableNo，从WITS.xml中读取相应仪器的某个record下的所有item信息，加载到WitsTable_treeView第二级节点
                List<List<String>> itemList = new List<List<String>>();
                itemList = m_xmlUtil.getSubSubChildNodes(m_xmlUtil.getSubChildNodes(m_xmlUtil.getChildNodes(m_xmlUtil.getRoot(m_xmlUtil.getDocument("WITS.xml"))), toolName), m_itemAttributesList, "index", tableNo);
                m_xmlUtil.m_xmlReader.Close();
                List<String> itemIndexList = new List<String>();
                List<String> curveNameList = new List<String>();
                foreach (List<String> itemAttributeList in itemList)
                {
                    itemIndexList.Add(itemAttributeList[0]);
                    curveNameList.Add(itemAttributeList[1]);
                }
                dic.Add(tableNo, createTable(tableNo, itemIndexList, curveNameList));
            }
            return dic;
        }

    }
}
