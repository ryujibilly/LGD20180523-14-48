using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace LGD.DAL.SQLite
{
    public class WitsTable:DataTable
    {
        /// <summary>
        /// 空构造方法
        /// </summary>
        public WitsTable()
        {

        }
        /// <summary>
        /// 动态构造WitsTable
        /// </summary>
        /// <param name="instru">仪器名</param>
        /// <param name="tabid">表号</param>
        /// <param name="shotname">短助记符列表</param>
        public WitsTable(String instru, String tabid, List<String> shotname)
        {
            this.TableName = tabid + "-" + instru;
            foreach (string item in shotname)
            {
                this.Columns.Add(new DataColumn(item, Type.GetType("System.String")));
            }
        }
        /// <summary>
        /// 获取表的下一行数据
        /// </summary>
        /// <param name="value">当前行的数据字符串列表</param>
        /// <returns></returns>
        public bool getNextRow(out List< String> value)
        {
            value = new List<string>() ;
            if (this.Rows.Count > 0)
            {
                foreach(object o in Rows[0].ItemArray)
                {
                    value.Add(o.ToString());
                }
                Rows.Remove(Rows[0]);
                return true;
            }
            else
            {
                value = null;
                return false;
            }
        }
    }
}
