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
            var htmlBody = DownloadNet.GetHtmlString("http://www.tuicool.com/articles/RBFRze");
            MatchHtml.GetUrlTitle(htmlBody);
        }
    }
}
