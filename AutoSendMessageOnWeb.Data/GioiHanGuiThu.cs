using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSendMessageOnWeb.Data
{
    public class GioiHanGuiThu
    {
        public int this[TrangWeb site]
        {
            get
            {
                return LayGioiHan(site);
            }
        }
        public static int LayGioiHan(TrangWeb site)
        {
            switch (site)
            {
                case TrangWeb.HenHo2:
                    return 1000;
            }
            return -1;
        }
    }
}
