using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Reflection;
using System.Collections;
using System.IO;
using System.Text.RegularExpressions;
using System.Runtime.Serialization.Json;
using System.Runtime;
using System.Diagnostics;
using Newtonsoft.Json;

namespace Tool.Json
{
    public class JsonHepler
    {
        //全分隔符 
        public static char[] seperator=new char[]{',' , '[' , ']','{','}','\r','\n','\\','"',' '};
        //外分隔符 [] 分割出所有记录
        public static char[] outsideseperator = new char[] { '[', ']' };
        //
        public static char[] trimoutside = new char[] {'\r', '\n', '\\', '"', ' ' };
        //内分隔符 其他分隔符某条记录
        public static char[] insideseperator = new char[] { ','};
        /// <summary>
        /// List转成json 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonName"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        public static string ListToJson<T>(IList<T> list, string jsonName)
        {
            StringBuilder Json = new StringBuilder();
            if (string.IsNullOrEmpty(jsonName))
                jsonName = list[0].GetType().Name;
            Json.Append("{\"" + jsonName + "\":[");
            if (list.Count > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    T obj = Activator.CreateInstance<T>();
                    PropertyInfo[] pi = obj.GetType().GetProperties();
                    Json.Append("{");
                    for (int j = 0; j < pi.Length; j++)
                    {
                        Type type;
                        object o = pi[j].GetValue(list[i], null);
                        string v = string.Empty;
                        if (o != null)
                        {
                            type = o.GetType();
                            v = o.ToString();
                        }
                        else
                        {
                            type = typeof(string);
                        }

                        Json.Append("\"" + pi[j].Name.ToString() + "\":" + StringFormat(v, type));

                        if (j < pi.Length - 1)
                        {
                            Json.Append(",");
                        }
                    }
                    Json.Append("}");
                    if (i < list.Count - 1)
                    {
                        Json.Append(",");
                    }
                }
            }
            Json.Append("]}");
            return Json.ToString();
        }

        /// <summary>
        /// 序列化集合对象
        /// </summary>
        public static string JsonSerializerByArrayData<T>(T[] tArray)
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T[]));
            MemoryStream ms = new MemoryStream();
            ser.WriteObject(ms, tArray);
            string jsonString = Encoding.UTF8.GetString(ms.ToArray());
            ms.Close();
            string p = @"\\/Date\((\d+)\+\d+\)\\/";
            MatchEvaluator matchEvaluator = new MatchEvaluator(ConvertJsonDateToDateString);
            Regex reg = new Regex(p);
            jsonString = reg.Replace(jsonString, matchEvaluator);
            return jsonString;
        }

        /// <summary>
        /// 序列化单个对象
        /// </summary>
        public static string JsonSerializerBySingleData<T>(T t)
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
            MemoryStream ms = new MemoryStream();
            ser.WriteObject(ms, t);
            string jsonString = Encoding.UTF8.GetString(ms.ToArray());
            ms.Close();
            string p = @"\\/Date\((\d+)\+\d+\)\\/";
            MatchEvaluator matchEvaluator = new MatchEvaluator(ConvertJsonDateToDateString);
            Regex reg = new Regex(p);
            jsonString = reg.Replace(jsonString, matchEvaluator);
            return jsonString;
        }

        /// <summary> 
        /// 反序列化单个对象
        /// </summary> 
        public static T JsonDeserializeBySingleData<T>(string jsonString)
        {
            //将"yyyy-MM-dd HH:mm:ss"格式的字符串转为"\/Date(1294499956278+0800)\/"格式  
            string p = @"\d{4}-\d{2}-\d{2}\s\d{2}:\d{2}:\d{2}";
            MatchEvaluator matchEvaluator = new MatchEvaluator(ConvertDateStringToJsonDate);
            Regex reg = new Regex(p);
            jsonString = reg.Replace(jsonString, matchEvaluator);
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonString));
            T obj = (T)ser.ReadObject(ms);
            return obj;
        }

        /// <summary> 
        /// 反序列化集合对象
        /// </summary> 
        public static T[] JsonDeserializeByArrayData<T>(string jsonString)
        {
            //将"yyyy-MM-dd HH:mm:ss"格式的字符串转为"\/Date(1294499956278+0800)\/"格式  
            string p = @"\d{4}-\d{2}-\d{2}\s\d{2}:\d{2}:\d{2}";
            MatchEvaluator matchEvaluator = new MatchEvaluator(ConvertDateStringToJsonDate);
            Regex reg = new Regex(p);
            jsonString = reg.Replace(jsonString, matchEvaluator);
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T[]));
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonString));
            T[] arrayObj = (T[])ser.ReadObject(ms);
            return arrayObj;
        }

        /// <summary> 
        /// 将Json序列化的时间由/Date(1294499956278+0800)转为字符串 
        /// </summary> 
        private static string ConvertJsonDateToDateString(Match m)
        {
            string result = string.Empty;
            DateTime dt = new DateTime(1970, 1, 1);
            dt = dt.AddMilliseconds(long.Parse(m.Groups[1].Value));
            dt = dt.ToLocalTime();
            result = dt.ToString("yyyy-MM-dd HH:mm:ss");
            return result;
        }

        /// <summary>  
        /// 将时间字符串转为Json时间 
        /// </summary> 
        private static string ConvertDateStringToJsonDate(Match m)
        {
            string result = string.Empty;
            DateTime dt = DateTime.Parse(m.Groups[0].Value);
            dt = dt.ToUniversalTime();
            TimeSpan ts = dt - DateTime.Parse("1970-01-01");
            result = string.Format("\\/Date({0}+0800)\\/", ts.TotalMilliseconds);
            return result;
        }

        /// <summary>
        /// List转成json 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static string ListToJson<T>(IList<T> list)
        {
            object obj = list[0];
            return ListToJson<T>(list, obj.GetType().Name);
        }

        /// <summary> 
        /// 对象转换为Json字符串 
        /// </summary> 
        /// <param name="jsonObject">对象</param> 
        /// <returns>Json字符串</returns> 
        public static string ToJson(object jsonObject)
        {
            try
            {
                StringBuilder jsonString = new StringBuilder();
                jsonString.Append("{");
                PropertyInfo[] propertyInfo = jsonObject.GetType().GetProperties();
                for (int i = 0; i < propertyInfo.Length; i++)
                {
                    object objectValue = propertyInfo[i].GetGetMethod().Invoke(jsonObject, null);
                    if (objectValue == null)
                    {
                        continue;
                    }
                    StringBuilder value = new StringBuilder();
                    if (objectValue is DateTime || objectValue is Guid || objectValue is TimeSpan)
                    {
                        value.Append("\"" + objectValue.ToString() + "\"");
                    }
                    else if (objectValue is string)
                    {
                        value.Append("\"" + objectValue.ToString() + "\"");
                    }
                    else if (objectValue is IEnumerable)
                    {
                        value.Append(ToJson((IEnumerable)objectValue));
                    }
                    else
                    {
                        value.Append("\"" + objectValue.ToString() + "\"");
                    }
                    jsonString.Append("\"" + propertyInfo[i].Name + "\":" + value + ","); ;
                }
                return jsonString.ToString().TrimEnd(',') + "}";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary> 
        /// 对象集合转换Json 
        /// </summary> 
        /// <param name="array">集合对象</param> 
        /// <returns>Json字符串</returns> 
        public static string ToJson(IEnumerable array)
        {
            string jsonString = "[";
            foreach (object item in array)
            {
                jsonString += ToJson(item) + ",";
            }
            if (jsonString.Length > 1)
            {
                jsonString.Remove(jsonString.Length - 1, jsonString.Length);
            }
            else
            {
                jsonString = "[]";
            }
            return jsonString + "]";
        }

        /// <summary> 
        /// 普通集合转换Json 
        /// </summary> 
        /// <param name="array">集合对象</param> 
        /// <returns>Json字符串</returns> 
        public static string ToArrayString(IEnumerable array)
        {
            string jsonString = "[";
            foreach (object item in array)
            {
                jsonString = ToJson(item.ToString()) + ",";
            }
            jsonString.Remove(jsonString.Length - 1, jsonString.Length);
            return jsonString + "]";
        }

        /// <summary> 
        /// Datatable转换为Json 
        /// </summary> 
        /// <param name="table">Datatable对象</param> 
        /// <returns>Json字符串</returns> 
        public static string ToJson(DataTable dt)
        {
            StringBuilder jsonString = new StringBuilder();
            jsonString.Append("[");
            DataRowCollection drc = dt.Rows;
            for (int i = 0; i < drc.Count; i++)
            {
                jsonString.Append("{");
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    string strKey = dt.Columns[j].ColumnName;
                    string strValue = drc[i][j].ToString();
                    Type type = dt.Columns[j].DataType;
                    jsonString.Append("\"" + strKey + "\":");
                    strValue = StringFormat(strValue, type);
                    if (j < dt.Columns.Count - 1)
                    {
                        jsonString.Append(strValue + ",");
                    }
                    else
                    {
                        jsonString.Append(strValue);
                    }
                }
                jsonString.Append("},");
            }
            jsonString.Remove(jsonString.Length - 1, 1);
            jsonString.Append("]");
            if (jsonString.Length == 1)
            {
                return "[]";
            }
            return jsonString.ToString();
        }

        /// <summary>
        /// DataTable转成Json 
        /// </summary>
        /// <param name="jsonName"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string ToJson(DataTable dt, string jsonName)
        {
            StringBuilder Json = new StringBuilder();
            if (string.IsNullOrEmpty(jsonName))
                jsonName = dt.TableName;
            Json.Append("{\"" + jsonName + "\":[");
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Json.Append("{");
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        Type type = dt.Rows[i][j].GetType();
                        Json.Append("\"" + dt.Columns[j].ColumnName.ToString() + "\":" + StringFormat(dt.Rows[i][j] is DBNull ? string.Empty : dt.Rows[i][j].ToString(), type));
                        if (j < dt.Columns.Count - 1)
                        {
                            Json.Append(",");
                        }
                    }
                    Json.Append("}");
                    if (i < dt.Rows.Count - 1)
                    {
                        Json.Append(",");
                    }
                }
            }
            Json.Append("]}");
            return Json.ToString();
        }

        /// <summary> 
        /// DataReader转换为Json 
        /// </summary> 
        /// <param name="dataReader">DataReader对象</param> 
        /// <returns>Json字符串</returns> 
        public static string ToJson(IDataReader dataReader)
        {
            try
            {
                StringBuilder jsonString = new StringBuilder();
                jsonString.Append("[");

                while (dataReader.Read())
                {
                    jsonString.Append("{");
                    for (int i = 0; i < dataReader.FieldCount; i++)
                    {
                        Type type = dataReader.GetFieldType(i);
                        string strKey = dataReader.GetName(i);
                        string strValue = dataReader[i].ToString();
                        jsonString.Append("\"" + strKey + "\":");
                        strValue = StringFormat(strValue, type);
                        if (i < dataReader.FieldCount - 1)
                        {
                            jsonString.Append(strValue + ",");
                        }
                        else
                        {
                            jsonString.Append(strValue);
                        }
                    }
                    jsonString.Append("},");
                }
                if (!dataReader.IsClosed)
                {
                    dataReader.Close();
                }
                jsonString.Remove(jsonString.Length - 1, 1);
                jsonString.Append("]");
                if (jsonString.Length == 1)
                {
                    return "[]";
                }
                return jsonString.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary> 
        /// DataSet转换为Json 
        /// </summary> 
        /// <param name="dataSet">DataSet对象</param> 
        /// <returns>Json字符串</returns> 
        public static string ToJson(DataSet dataSet)
        {
            string jsonString = "{";
            foreach (DataTable table in dataSet.Tables)
            {
                jsonString += "\"" + table.TableName + "\":" + ToJson(table) + ",";
            }
            jsonString = jsonString.TrimEnd(',');
            return jsonString + "}";
        }

        /// <summary>
        /// 过滤特殊字符
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string String2Json(String s)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                char c = s.ToCharArray()[i];
                switch (c)
                {
                    case '\"':
                        sb.Append("\\\""); break;
                    case '\\':
                        sb.Append("\\\\"); break;
                    case '/':
                        sb.Append("\\/"); break;
                    case '\b':
                        sb.Append("\\b"); break;
                    case '\f':
                        sb.Append("\\f"); break;
                    case '\n':
                        sb.Append("\\n"); break;
                    case '\r':
                        sb.Append("\\r"); break;
                    case '\t':
                        sb.Append("\\t"); break;
                    case '\v':
                        sb.Append("\\v"); break;
                    case '\0':
                        sb.Append("\\0"); break;
                    default:
                        sb.Append(c); break;
                }
            }
            return sb.ToString();
        }
        /// <summary>
        /// 格式化字符型、日期型、布尔型
        /// </summary>
        /// <param name="str"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        private static string StringFormat(string str, Type type)
        {
            if (type != typeof(string) && string.IsNullOrEmpty(str))
            {
                str = "\"" + str + "\"";
            }
            else if (type == typeof(string))
            {
                str = String2Json(str);
                str = "\"" + str + "\"";
            }
            else if (type == typeof(DateTime))
            {
                str = "\"" + str + "\"";
            }
            else if (type == typeof(bool))
            {
                str = str.ToLower();
            }
            else if (type == typeof(byte[]))
            {
                str = "\"" + str + "\"";
            }
            else if (type == typeof(Guid))
            {
                str = "\"" + str + "\"";
            }
            return str;
        }

        /// <summary>
        /// 哈希表转json
        /// </summary>
        /// <param name="ht"></param>
        /// <param name="readcount"></param>
        /// <returns></returns>
        public static string HashtableToJson(Hashtable hr, int readcount = 0)
        {
            string json = "{";
            foreach (DictionaryEntry row in hr)
            {
                try
                {
                    string key = "\"" + row.Key + "\":";
                    if (row.Value is Hashtable)
                    {
                        Hashtable t = (Hashtable)row.Value;
                        if (t.Count > 0)
                        {
                            json += key + HashtableToJson(t, readcount++) + ",";
                        }
                        else { json += key + "{},"; }
                    }
                    else
                    {
                        string value = "\"" + row.Value.ToString() + "\",";
                        json += key + value;
                    }
                }
                catch { }
            }
            //  json = MyString.ClearEndChar(json);  
            json = json + "}";
            return json;
        }

        /// <summary>
        /// Json数据转数组
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonText"></param>
        /// <returns></returns>
        public static List<T> JsonToList<T>(string jsonText)
        {
            List<T> list = new List<T>();

            DataContractJsonSerializer _Json = new DataContractJsonSerializer(list.GetType());
            byte[] _Using = Encoding.UTF8.GetBytes(jsonText);
            MemoryStream _MemoryStream = new MemoryStream(_Using);
            _MemoryStream.Position = 0;

            return (List<T>)_Json.ReadObject(_MemoryStream);
        }
        /// <summary>
        /// 设置用户名密码，并返回一个新的hashtable
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <returns>返回的hashtable</returns>
        public static Hashtable SetUserNameAndPassWord(string username,string password)
        {
            Hashtable ht = new Hashtable();
            ht.Add("user", username);
            ht.Add("password", password);
            ht.Add("size", "0");
            ht.Add("msg", "");
            ht.Add("return", "");
            ht.Add("title", "");
            ht.Add("data", "");
            return ht;
        }
        /// <summary>
        /// 添加header
        /// </summary>
        /// <param name="ht"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Hashtable addHeader(ref Hashtable ht,string key,string value)
        {
            if (key == string.Empty&&!ht.Contains(key))
                ht.Add(key,value);
            return ht;
        }
        /// <summary>
        /// 返回Header值
        /// </summary>
        /// <param name="ht">hashtable</param>
        /// <param name="key">键</param>
        /// <returns></returns>
        public static string getHeaderValue(Hashtable ht, string key)
        {
            string str = string.Empty;
            if (ht.ContainsKey(key))
            {
                foreach (DictionaryEntry de in ht)
                {
                    if (de.Key.ToString() == key)
                    {
                        str= de.Value.ToString();
                    }
                    else return string.Empty;
                }
                return str;
            }
            else
                return string.Empty;  
        }
        /// <summary>
        /// header是否含有某键
        /// </summary>
        /// <param name="ht">hashtable</param>
        /// <param name="key">键</param>
        /// <returns></returns>
        public static bool getHeader(Hashtable ht,string key)
        {
            if (ht.ContainsKey(key))
                return true;
            else return false;
        }
        /// <summary>
        /// 获取title，即列名的List
        /// </summary>
        /// <param name="ht">哈希表</param>
        /// <returns>列名List</returns>
        public static List<String> getJsonCol(Hashtable ht,String key)
        {
            List<String> _list = new List<string>();
            string str = "";
            if (ht.ContainsKey(key))
            {
                foreach (DictionaryEntry de in ht)
                {
                    if (de.Key.ToString() == key)
                    {
                        str = de.Value.ToString();
                        _list = new List<string>(str.Split(seperator,StringSplitOptions.RemoveEmptyEntries));
                    }
                    else return _list;
                }
                return _list;
            }
            else
                return _list;
        }
        /// <summary>
        /// 获取data，即列名为colName的二维List<List<String>>
        /// </summary>
        /// <param name="ht">哈希表</param>
        /// <returns>"数据二维List"</returns>
        public static List<List<String>> getJsonData(Hashtable ht, String key,int colNumber)
        {
            List<List<String>> _list = new List<List<string>>();
            List<String> tempRecord = new List<string>();

            string str = "";
            if (ht.ContainsKey(key))
            {
                foreach (DictionaryEntry de in ht)
                {
                    if (de.Key.ToString() == key)
                    {
                        str = de.Value.ToString();
                        //str = str.Replace('\r', ' ');
                        //str = str.Replace('\n', ' ');
                        //str = str.Replace('\\', ' ');
                        //str = str.Replace('"', ' ');
                        tempRecord = new List<string>(str.Split(seperator, StringSplitOptions.RemoveEmptyEntries));
                        int rowNumber = tempRecord.Count/colNumber;
                        for (int i = 0; i < colNumber; i++)//2
                        {
                            List<String> tempRow = new List<string>();
                            for (int j = 0; j < rowNumber; j++)//4
                            {
                                tempRow.Add(tempRecord[colNumber * j + i]);
                            }
                            _list.Add(tempRow);
                        }
                        return _list;
                    }
                    else continue;
                }
                return _list;
            }
            else
                return _list;
        }

        /// <summary>
        /// 二维列表转DataTable
        /// </summary>
        /// <param name="list"></param>
        /// <param name="colName"></param>
        /// <returns></returns>
        public static DataTable List2DataTable(List<List<String>> list,List<String> colName)
        {
            DataTable dt = new DataTable();
            for(int i=0;i<colName.Count;i++)
            {
                DataColumn dc = new DataColumn(colName[i]);
                dt.Columns.Add(dc);
            }
            for (int j = 0; j < list[0].Count; j++)
            {
                DataRow dr = dt.NewRow();
                object[] temp = new object[list.Count];
                for (int i = 0; i < list.Count; i++)
                {
                    temp[i] = (object)list[i][j];
                }
                dt.Rows.Add(temp);
            }
            return dt;
        }
        /// <summary>
        /// Json字符串转DataTable
        /// </summary>
        /// <param name="strJson"></param>
        /// <returns></returns>
        public static DataTable JsonToDataTable(string strJson)
        {
            //取出表名  
            Regex rg = new Regex(@"(?<={)[^:]+(?=:/[)", RegexOptions.IgnoreCase);
            string strName = rg.Match(strJson).Value;
            DataTable tb = null;
            //去除表名  
            strJson = strJson.Substring(strJson.IndexOf("[") + 1);
            strJson = strJson.Substring(0, strJson.IndexOf("]"));

            //获取数据  
            rg = new Regex(@"(?<={)[^}]+(?=})");
            MatchCollection mc = rg.Matches(strJson);
            for (int i = 0; i < mc.Count; i++)
            {
                string strRow = mc[i].Value;
                string[] strRows = strRow.Split(',');

                //创建表  
                if (tb == null)
                {
                    tb = new DataTable();
                    tb.TableName = strName;
                    foreach (string str in strRows)
                    {
                        DataColumn dc = new DataColumn();
                        string[] strCell = str.Split(':');
                        dc.ColumnName = strCell[0].ToString();
                        tb.Columns.Add(dc);
                    }
                    tb.AcceptChanges();
                }

                //增加内容  
                DataRow dr = tb.NewRow();
                for (int r = 0; r < strRows.Length; r++)
                {
                    dr[r] = strRows[r].Split(':')[1].Trim().Replace("，", ",").Replace("：", ":").Replace("\"","");
                }
                tb.Rows.Add(dr);
                tb.AcceptChanges();
            }
            return tb;
        }
        public static String List2JsonAarry(List<String> list)
        {
            String jstring = "";
            jstring += "["+"\"";
            for (int i = 0; i < list.Count - 1;i++)
                jstring += list[i]+",";
            jstring += list[list.Count - 1];
            jstring += "\""+"]";
            return jstring;
        }

        public static String AddData(List<String> data)
        {
            String jstring="";
            return jstring;
        }
        public static String AddTitle(List<String> title)
        {
            String jstring = "";
            return jstring;
        }
        public static String SetSize(List<String> data)
        {
            String jsting = "";
            return jsting;
        }
    }
}
