using System;
using System.IO;
using System.Net;
using System.Text;

namespace Lottery.Utils
{
    public class ResponseHelper
    {
        public static string GetResponseString(string postString, string uri)
        {
            try
            {
                byte[] bytes = Encoding.ASCII.GetBytes(postString);
                HttpWebRequest request = WebRequest.Create(uri) as HttpWebRequest;
                request.Method = "POST";
                request.KeepAlive = false;
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = bytes.Length;
                Stream requestStream = request.GetRequestStream();
                requestStream.Write(bytes, 0, bytes.Length);
                requestStream.Close();
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                string str = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("utf-8")).ReadToEnd();
                response.Close();
                if (string.IsNullOrEmpty(str))
                {
                    str = "";
                }
                return str;
            }
            catch
            {
                return "";
            }
        }
    }
}

