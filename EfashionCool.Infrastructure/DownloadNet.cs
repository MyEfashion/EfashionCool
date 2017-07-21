using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EfashionCool.Infrastructure
{
    public static class DownloadNet
    {
        /// <summary>
        /// 获取Url内Html
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string GetHtmlString(string url)
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            WebResponse webResponse = webRequest.GetResponse();
            Stream stream = webResponse.GetResponseStream();
            StreamReader reader = new StreamReader(stream, Encoding.UTF8);
            var htmlString = reader.ReadToEnd();
            return htmlString;
        }
    }
}
