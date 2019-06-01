using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSendMessageOnWeb.Lib
{
    public class Log
    {
        private const string FILE_LOG = "Data\\log.txt";
        public static async Task WriteLog(string content)
        {
            if (!File.Exists(FILE_LOG))
                File.Create(FILE_LOG).Close();
            File.AppendAllText(FILE_LOG, $"{DateTime.Now}: {content}{Environment.NewLine}", Encoding.UTF8);
            await Task.Delay(1);
        }
    }
}
