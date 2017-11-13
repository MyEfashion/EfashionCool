using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EfashionCool.Infrastructure;
using DevStack.OrmLite;
using StanSoft;
using EfashionCool.Model;
using EfashionCool.Manager;

namespace EfashionCool.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            DownloadNet.DownLoadGoingData("https://baijia.baidu.com/s?id=1583912181382922403&wfr=pc&fr=idx_lst");
            
        }
    }
}
