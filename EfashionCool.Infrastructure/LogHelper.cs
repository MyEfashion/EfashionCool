using DevLib.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfashionCool.Infrastructure
{
    public static class LogHelper
    {
        public static void Log(string pathName, string status, object msg)
        {
            string path;
            try
            {
                path = ConfigHelper.GetAppSetting("logPath");
            }
            catch (Exception)
            {
                path = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "\\" + pathName;
            }
            try
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                string logFile = path + "\\" + DateTime.Now.ToString("yyyy-MM-dd") + ".log";
                StreamWriter sw = File.AppendText(path);
                sw.WriteLine("{0}\t{1}\t{2}", DateTime.Now.ToLongDateString(), status, msg);
            }
            catch (Exception ex)
            { }
        }
    }
}
