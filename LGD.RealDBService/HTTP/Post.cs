using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Net;
using System.Text;
using System.IO;

namespace LGD.RealDBService.HTTP
{
    public class Post
    {
        public static Post _post = new Post();
        public static string PostWebServiceByJson(String URL,String MethodName,Hashtable Pars)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(URL + "/" + MethodName);
            request.Method = "POST";
            request.ContentType = "application/json;charset=utf-8";
            request.Credentials = CredentialCache.DefaultCredentials;
            request.Timeout = 10000;
            byte[] data = Encoding.UTF8.GetBytes(HashtableToJson(Pars));
            request.ContentLength = data.Length;
            Stream writer = request.GetRequestStream();
            writer.Write(data, 0, data.Length);
            writer.Close();

            StreamReader sr = new StreamReader(request.GetResponse().GetResponseStream(), Encoding.UTF8);
            String retXml = sr.ReadToEnd();
            sr.Close();
            return retXml;
        }

        private static char[] HashtableToJson(object pars)
        {
            throw new NotImplementedException();
        }

        //public void HashtableToJson(Hashtable pars)
        //{
        //    Hashtable ht = new Hashtable();
        //    ht.Add("user", "yuwenmao");
        //    ht.Add("password", "123");
        //    _post.PostWebServiceByJson("http://localhost/OpenApi/MobileService.asmx", "Login", ht);
        //}
    }
}