using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EfashionCool.Infrastructure
{
    public static class MatchHtml
    {
        public static Dictionary<string, string> GetUrlTitle(string htmlBody)
        {
            var regexStr = @"<a[^>]+href=""(?<href>[\S]+?)""[^>]*>(?<text>[\S]+?)</a>";
            MatchCollection matchs = Regex.Matches(htmlBody, regexStr);
            var dic = new Dictionary<string, string>();
            var hashSet = new HashSet<string>();
            var href = "";
            var text = "";
            foreach (Match item in matchs)
            {
                href = item.Groups["href"].ToString();
                text = item.Groups["text"].ToString();
                if (!dic.ContainsKey(href))
                {
                    dic.Add(item.Groups["href"].ToString(), item.Groups["text"].ToString());
                }
                hashSet.Add(item.Groups["href"].ToString());
                hashSet.Add(item.Groups["href"].ToString());
                LogHelper.Log("记录", "Sucess", href + "----------"+text);
            }
            return dic;
        }
    }
}
