using SyntacticSugar;
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
            var html = Regex.Replace(htmlBody, @"<p[^>]+>", "<p>");
            var html1 = Regex.Replace(htmlBody, @"<div[^>]+>", "<div>");
            var html2 = Regex.Match(htmlBody, @"\<([a-zA-Z]{1,}) +id=\'nei\'\> *\<([a-zA-Z]{1,}) +.*\>(.*)\</\2\>\</\1\>");
            var html3 = GetHtmlAttr(htmlBody, "div", "");
            //  todo   dic避免重复
            var dic = new Dictionary<string, string>();


            XHtmlElement xh = new XHtmlElement(htmlBody);

            //获取body的子集a标签并且class="icon"
            var link = xh.Descendants("div").Where(c => c.Attributes.Any(a => a.Key == "class" && a.Value == "article_body")).ToList();

            ////获取带href的a元素
            //var links = xh.Descendants("div").Where(c => c.Attributes.Any(a => a.Key == "id")).ToList();
           
            ////获取第一个img
            //var img = xh.Descendants("img");

            ////获取最近的第一个p元素以及与他同一级的其它p元素
            //var ps = xh.Descendants("p");

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
                LogHelper.Log("记录", "Sucess", href + "----------"+text);
            }
            return dic;
        }

        private static List<string> GetHtmlAttr(string html, string tag, string attr)

        {

            Regex re = new Regex(@"(<" + tag + @"[\w\W].+?>)");

            MatchCollection imgreg = re.Matches(html);

            List<string> m_Attributes = new List<string>();
            
            Regex attrReg = new Regex(@"([a-zA-Z1-9_-]+)\s*=\s*(\x27|\x22)([^\x27\x22]*)(\x27|\x22)", RegexOptions.IgnoreCase);


            for (int i = 0; i < imgreg.Count; i++)

            {

                MatchCollection matchs = attrReg.Matches(imgreg[i].ToString());

                for (int j = 0; j < matchs.Count; j++)

                {

                    GroupCollection groups = matchs[j].Groups;

                    if (attr.ToUpper() == groups[1].Value.ToUpper())

                    {

                        m_Attributes.Add(groups[3].Value);

                        break;

                    }

                }

            }

            return m_Attributes;

        }
    }
}
