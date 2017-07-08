using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSendMessageOnWeb.Lib.ExtentionMethod
{
    public static class DataTypeEx
    {
        public static int? ConvertToInt32(this string s)
        {
            try
            {
                return int.Parse(s);
            }
            catch
            {
                return null;
            }
        }
    }
}
