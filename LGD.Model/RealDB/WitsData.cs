using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LGD.Model.RealDB
{
    public class WitsData
    {
        public WitsData() { }
        private int _RecID;
        private string _TabID;
        private string _ItemID;
        private string _Data;
        /// <summary>
        ///  记录ID
        /// </summary>
        public int RecID
        {
            get { return _RecID; }
            set { _RecID = value; }
        }

        /// <summary>
        /// 表ID
        /// </summary>
        public string TabID
        {
            get { return _TabID; }
            set { _TabID = value; }
        }

        /// <summary>
        /// 项目ID
        /// </summary>
        public string ItemID
        {
            get { return _ItemID; }
            set { _ItemID = value; }
        }

        /// <summary>
        /// 数据
        /// </summary>
        public string Data
        {
            get { return _Data; }
            set { _Data = value; }
        }

    }
}
