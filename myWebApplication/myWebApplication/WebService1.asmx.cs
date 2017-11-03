//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Services;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Collections.ObjectModel;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;


namespace myWebApplication
{
    /// <summary>
    /// WebService1 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public int Add(int a, int b)
        {
            return (a + b);
        }
        //[WebMethod]
        //public string Sub(int a, int b)
        //{
        //    return (a - b).ToString();
        //}
        //[WebMethod]
        //public string class_one(string str)
        //{
        //    fuzaModel mm2 = serverFun.Deserialize(typeof(fuzaModel), str) as fuzaModel;
        //    mm2.a = mm2.a * 3;
        //    mm2.b = mm2.b + "web";
        //    return serverFun.Serialize(mm2);
        //}

        //[WebMethod]
        //public string class_set(string str)
        //{
        //    List newList = serverFun.Deserialize(typeof(List), str) as List;
        //    foreach (var info in newList)
        //    {
        //        info.a = info.a * 3;
        //        info.b = info.b + " web";
        //    }
        //    return serverFun.Serialize > (newList);
        //}
    }

 //   [XmlInclude(typeof(fuzaModel))]
 //   [Serializable]
 //   public class fuzaModel
 //   {
 //       private int m_UserId;
 //       [XmlElement("userId")]
 //       public int UserId
 //       {
 //           get { return m_UserId; }
 //           set { m_UserId = value; }
 //       }
 //       public int a;
 //       public string b;

 //       //  [WebMethod]
 //       public fuzaModel aModel(fuzaModel m)
 //       {

 //           m.a = 2;
 //           m.b = "b";
 //           return m;
 //       }
 //   }

 //   [Serializable]
 //   public class serverFun : System.Web.Services.WebService
 //   {
 //       [WebMethod]
 //       public static string Serialize(T t)
 //       {
 //           using (StringWriter sw = new StringWriter())
 //           {
 //               XmlSerializer xz = new XmlSerializer(t.GetType());
 //               xz.Serialize(sw, t);
 //               return sw.ToString();
 //           }
 //       }
 
 //       [WebMethod]
 //       public static object Deserialize(Type type, string s)
 //       {
 //           using (StringReader sr = new StringReader(s))
 //           {
 //               XmlSerializer xz = new XmlSerializer(type);
 //               return xz.Deserialize(sr);
 //           }
 //       }

 ////       在调用端序列化实体对象(实体对象须是可序列化的类): 
 //       [WebMethod]
 //       public static byte[] SerializeObject(object pObj)
 //       {
 //           if (pObj == null)            return null;
 //           System.IO.MemoryStream memoryStream = new System.IO.MemoryStream();
 //           BinaryFormatter formatter = new BinaryFormatter();
 //           formatter.Serialize(memoryStream, pObj);
 //           memoryStream.Position = 0;
 //           byte[] read = new byte[memoryStream.Length];
 //           memoryStream.Read(read, 0, read.Length);
 //           memoryStream.Close();
 //           return read;
 //       }
 //       //在service的调用方法中，接受一个byte[] 参数即可，然后反序列化：
 //       //然后将object强制转换成相应的实体类型，就可以直接使用此对象了。
 //       [WebMethod]
 //       public static object DeserializeObject(byte[] pBytes)
 //       {
 //           object newOjb = null;
 //           if (pBytes == null)return newOjb;
 //           System.IO.MemoryStream memoryStream = new
 //           System.IO.MemoryStream(pBytes);
 //           memoryStream.Position = 0;
 //           BinaryFormatter formatter = new BinaryFormatter();
 //           newOjb = formatter.Deserialize(memoryStream);
 //           memoryStream.Close();
 //           return newOjb;
 //       }
 //       [WebMethod]
 //       public static string newObject(byte[] pBytes)
 //       {
 //           fuzaModel nn = new fuzaModel();
 //           fuzaModel m_temp = DeserializeObject(pBytes) as fuzaModel;
 //           return Serialize(m_temp);
 //       }

 //   }
 










}
