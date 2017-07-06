using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSendMessageOnWeb.Data
{
    public enum TrangWeb
    {
        HenHo2
    }
    public class UriTrangWeb
    {
        public static Uri HenHo2
        {
            get
            {
                return new Uri("http://henho2.com");
            }
        }
    }
}
