using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoSendMessageOnWeb.Lib.ExtentionMethod
{
    public class RandomEmail
    {
        public static List<string> _lstDomain = new List<string>() {"@gmail.com", "@yahoo.com", "@yahoo.com.vn", "@outlook.com", "@zing.vn", "@facebook.com"};
        public static string GetRandomEmail()
        {
            string SALTCHARS = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            StringBuilder salt = new StringBuilder();
            Random rnd = new Random();
            while (salt.Length < rnd.Next(10, 15))
            {
                int index = (int)(rnd.NextDouble() * SALTCHARS.Length);
                salt.Append(SALTCHARS.ElementAt(index));
            }
            string saltStr = salt.ToString() + _lstDomain.GetRandomElement();
            return saltStr;
        }
    }
}
