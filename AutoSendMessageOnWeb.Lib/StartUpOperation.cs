using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSendMessageOnWeb.Lib
{
    public class StartUpOperation
    {
        public const string InfoPath = "Data\\Info.tvwp";
        public const string ChangeLog = "Data\\ChangeLog.tvwp";
        public static void CheckFile()
        {
            if (!Directory.Exists("Data"))
                Directory.CreateDirectory("Data");
            if (!File.Exists(InfoPath))
            {
                File.Create(InfoPath).Close();
                WriteInfo(new[] { "" });
            }
        }

        public static void CheckVersion(Action callbac_knewversion)
        {
            var info = File.ReadAllLines(InfoPath);
            string localVer = info[0];
            string currentVer = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            if(localVer != currentVer)
            {
                callbac_knewversion();

                WriteInfo(new[] { currentVer });
            }
        }

        private static void WriteInfo(string[] param)
        {
            File.WriteAllLines(InfoPath, param);
        }
    }
}
