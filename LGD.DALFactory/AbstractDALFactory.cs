using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LGD.IDAL;
using System.Configuration;

namespace LGD.DALFactory
{
    public abstract class AbstractDALFactory
    {
        public abstract IProjectService CreateProjectService();
        public abstract IRecordService CreateRecordService();
        public abstract IConfigService CreateConfigService();
        //public static AbstractDALFactory ChooseFactory()
        //{
        //    //AbstractDALFactory factory = null;
        //    //string DbType = ConfigurationSettings.AppSettings["DbType"].ToString();
        //    //switch (DbType)
        //    //{
        //    //}
        //    //return factory;
        //}

    }
}
