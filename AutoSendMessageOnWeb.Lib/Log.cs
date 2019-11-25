using System;
using System.IO;
using System.Text;

namespace AutoSendMessageOnWeb.Lib
{
    public class Log
    {
        private const string FILE_LOG = "Data\\log.txt";
        public static void WriteLog(string content)
        {
            try
            {
                if (!File.Exists(FILE_LOG))
                    File.Create(FILE_LOG).Close();
                File.AppendAllText(FILE_LOG, $"{DateTime.Now}: {content}{Environment.NewLine}", Encoding.UTF8);
            }
            catch { }
        }
        public static void WriteLog(string path, string content)
        {
            try
            {
                if (!File.Exists(path))
                    File.Create(path).Close();
                File.AppendAllText(path, $"{DateTime.Now}: {content}{Environment.NewLine}", Encoding.UTF8);
            }
            catch { }
        }
    }
}
