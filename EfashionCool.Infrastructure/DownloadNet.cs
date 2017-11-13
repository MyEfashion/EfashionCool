using EfashionCool.Manager;
using EfashionCool.Model;
using StanSoft;
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

        public static void DownLoadGoingData(string url, int flag = 1)
        {
            var htmlBody = GetHtmlString(url);
            var article = Html2Article.GetArticle(htmlBody);
            if (article.Content.Length > 100 && article.ContentWithTags.Length > 100)
            {
                var articleSource = new a_articlesource()
                {
                    Title = article.Title,
                    CreateTime = article.PublishDate,
                    FromUrl = url,
                    Content = article.Content,
                    ContentWithTags = article.ContentWithTags
                };
                ArticleSourceManager.Instance.Submit(articleSource);
                ++flag;
            }
            var urlDic = MatchHtml.GetUrlTitle(htmlBody);
            if (urlDic.Count() > 0)
            {
                foreach (var item in urlDic)
                {
                    //if (flag > 10)
                    //{
                    //    return;
                    //}
                    try
                    {
                        DownLoadGoingData(item.Key, flag);
                    }
                    catch (Exception)
                    {

                    }
                }
            }
        }
    }
}
