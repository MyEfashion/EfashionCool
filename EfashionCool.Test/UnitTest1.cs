using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EfashionCool.Infrastructure;
using DevStack.OrmLite;

namespace EfashionCool.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var htmlBody = DownloadNet.GetHtmlString("http://mp.weixin.qq.com/s?__biz=MzAxOTc0NzExNg==&mid=2665513504&idx=1&sn=25dd6420e3056101dd3f6fdaedacaa2a&chksm=80d67a63b7a1f37572a5159ff6f53810467c15c8beec94770e8360c45f45036360d77755ee78&scene=21#wechat_redirect");
            MatchHtml.GetUrlTitle(htmlBody);
        }
    }
}
