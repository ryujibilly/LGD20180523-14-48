using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace LGD.RealDBService
{
    /// <summary>
    /// Summary description for testWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class testWebService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        //添加工区
        public bool AddRegion(String strJson, String strRetMsg)
        {
            return true;
        }

	    //添加井
	    public bool AddWell(String strJson, String strRetMsg)
        {
            return true;
        }
    }
}
