using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace AutoSendMessageOnWeb.Lib.Security
{
    public class DataUseForSecurity
    {
        public static DateTime GetReadDate()
        {
            return DateTime.Now.Date;
        }

        public static string GetFirstMAC()
        {
            string diaChiMAC = "";
            NetworkInterface cardMang1 = NetworkInterface.GetAllNetworkInterfaces().FirstOrDefault();

            PhysicalAddress diaChiMACs = cardMang1.GetPhysicalAddress();

            byte[] ByteDiaChi = diaChiMACs.GetAddressBytes();
            for (int j = 0; j < ByteDiaChi.Length; j++)
            {
                diaChiMAC += ByteDiaChi[j].ToString("X2");
                if (j != ByteDiaChi.Length - 1)
                {
                    diaChiMAC += "-";
                }
            }

            return diaChiMAC;
        }

        public static List<string> GetListMACs()
        {
            string diaChiMAC = "";
            List<string> macs = new List<string>();
            NetworkInterface[] danhSachCardMang = NetworkInterface.GetAllNetworkInterfaces();
            for (int i = 0; i < danhSachCardMang.Length; i++)
            {
                PhysicalAddress diaChiMACs = danhSachCardMang[i].GetPhysicalAddress();
                //diaChiMAC += danhSachCardMang[i].Name + " : ";
                byte[] ByteDiaChi = diaChiMACs.GetAddressBytes();
                for (int j = 0; j < ByteDiaChi.Length; j++)
                {
                    diaChiMAC += ByteDiaChi[j].ToString("X2");
                    if (j != ByteDiaChi.Length - 1)
                    {
                        diaChiMAC += "-";
                    }
                }
                macs.Add(diaChiMAC);
                diaChiMAC = "";
            }
            return macs;
        }

        public static string GenKeySendToClient(string userid, DateTime expdate)
        {
            //Sinh dữ liệu dựa trên MAC và hạn sử dụng
            string plainData = string.Format("[{0}][{1:dd/MM/yyyy}][{2:dd/MM/yyyy}]", Crypto.HashString(userid), GetReadDate(), expdate);

            //Mã hóa dữ liệu vừa sinh
            string cypherData = Crypto.Encrypt(plainData, "thuVIENwiForm!@#!");

            //Ký dữ liệu mã hóa nhận được
            string signatureOfCypher = Crypto.SignatureOfString(cypherData);
            
            return string.Format("[{0}][{1}]", signatureOfCypher, cypherData);
        }

        public static string GenKeySendToAdmin()
        {
            string data = string.Format("[{0}][{1}]", Dns.GetHostName(), GetFirstMAC());
            return Crypto.Encrypt(data);
        }
    }
}
