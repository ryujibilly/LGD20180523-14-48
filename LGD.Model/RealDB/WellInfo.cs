using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LGD.Model.RealDB
{
    public class WellInfo
    {
        public WellInfo() { }
        private int _ID;
        private int _WellID;
        private string _WellName;
        private string _Wells;
        /// <summary>
        /// 井次
        /// </summary>
        public string Wells
        {
            get { return _Wells; }
            set { _Wells = value; }
        }
        /// <summary>
        /// 井名
        /// </summary>
        public string WellName
        {
            get { return _WellName; }
            set { _WellName = value; }
        }
        /// <summary>
        /// 井号
        /// </summary>
        public int WellID
        {
            get { return _WellID; }
            set { _WellID = value; }
        }
        /// <summary>
        /// 自增主键ID
        /// </summary>
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
    }
}
