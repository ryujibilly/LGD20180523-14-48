using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace LGD.DAL.SQLite
{
    public class WitsTable:DataTable
    {
        private String index;
        private String value;
        /// <summary>
        /// 字段索引列
        /// </summary>
        private DataColumn columnIndex=new DataColumn("ItemIndex",Type.GetType("System.String"));
        /// <summary>
        /// 数据列
        /// </summary>
        private DataColumn columnValue= new DataColumn("Value", Type.GetType("System.String"));
        /// <summary>
        /// 字段索引
        /// </summary>
        public string Index
        {
            get
            {
                return index;
            }

            set
            {
                index = value;
            }
        }
        /// <summary>
        /// 数据
        /// </summary>
        public string Value
        {
            get
            {
                return value;
            }

            set
            {
                this.value = value;
            }
        }

        public WitsTable()
        {
            this.Columns.Add(columnIndex);
            this.Columns.Add(columnValue);
        }
        /// <summary>
        /// 获取表的下一行数据 （i=index;v=value）
        /// </summary>
        /// <param name="i">index</param>
        /// <param name="v">value</param>
        /// <returns>该表是否为空</returns>
        public bool getNextRow(out String i,out String v)
        {
            if (this.Rows.Count > 0)
            {
                i = this.Rows[0].ItemArray[0].ToString();
                v = this.Rows[0].ItemArray[1].ToString();
                this.Rows.Remove(this.Rows[0]);
                return true;
            }
            else
            {
                i = null;
                v = null;
                return false;
            }
        }
    }
}
