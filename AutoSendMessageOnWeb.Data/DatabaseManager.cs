using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace AutoSendMessageOnWeb.Data
{
    [Serializable]
    public class DatabaseManager
    {
        private string _fileDataPath;
        public string PhienTimKiem { set; get; }
        public BindingList<ThongTinTaiKhoan> DanhSachNguoiGui { set; get; }
        public BindingList<ThongTinTaiKhoan> DanhSachNguoiNhan { set; get; }
        public BindingList<ThongTinNguoiDung> DanhSachNguoiDung { set; get; }
        public List<string> DanhSachTieuDe { set; get; }
        public List<string> DanhSachNoiDung { set; get; }
        public DatabaseManager(string file)
        {
            _fileDataPath = file;
            this.CreateIfNotExist();
            this.Load();
        }
        public DatabaseManager(TrangWeb site)
        {
            _fileDataPath = GetDefaultFileDatabase(site);
            this.CreateIfNotExist();
            this.Load();
        }

        public bool Exits()
        {
            return File.Exists(_fileDataPath);
        }

        public void CreateDatabbase()
        {
            this.DanhSachNguoiGui = new BindingList<ThongTinTaiKhoan>();
            this.DanhSachNguoiNhan = new BindingList<ThongTinTaiKhoan>();
            this.DanhSachNguoiDung = new BindingList<ThongTinNguoiDung>();
            this.DanhSachNoiDung = new List<string>();
            this.DanhSachTieuDe = new List<string>();
            this.SaveChange();
        }

        public void CreateIfNotExist()
        {
            if (!this.Exits())
                this.CreateDatabbase();
        }

        private void Load()
        {
            FileStream fs = new FileStream(_fileDataPath, FileMode.Open);
            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                DatabaseManager tmp = (DatabaseManager)bf.Deserialize(fs);
                fs.Close();
                this.DanhSachNguoiGui = tmp.DanhSachNguoiGui;
                this.DanhSachNguoiNhan = tmp.DanhSachNguoiNhan;
                this.DanhSachNguoiDung = tmp.DanhSachNguoiDung;
                this.PhienTimKiem = tmp.PhienTimKiem;
                this.DanhSachTieuDe = tmp.DanhSachTieuDe ?? new List<string>();
                this.DanhSachNoiDung = tmp.DanhSachNoiDung ?? new List<string>();
            }
            catch
            {
                fs.Close();
                this.CreateDatabbase();
            }
        }

        public bool SaveChange()
        {
            FileInfo f = new FileInfo(_fileDataPath);

            if (!f.Directory.Exists)
                f.Directory.Create();

            FileStream fs = new FileStream(_fileDataPath, FileMode.Create);
            try
            {
                BinaryFormatter bf = new BinaryFormatter();

                bf.Serialize(fs, this);

                fs.Close();

                return true;
            }
            catch
            {
                fs.Close();
                return false;
            }

        }

        public static string GetDefaultFileDatabase(TrangWeb site)
        {
            switch(site)
            {
                case TrangWeb.HenHo2:
                    return "Data\\henho2.tvwp";
                case TrangWeb.DuyenSo:
                    return "Data\\duyenso.tvwp";
                case TrangWeb.VietNamCupid:
                    return "Data\\VietNamCupid.tvwp";
                case TrangWeb.LikeYou:
                    return "Data\\LikeYou.tvwp";
                case TrangWeb.HenHoKetBan:
                    return "Data\\HenHoKetBan.tvwp";
                case TrangWeb.TimBanGai:
                    return "Data\\TimBanGai.tvwp";

                case TrangWeb.ThongTinNguoiDung:
                    return "Data\\DanhSachNguoiDung.tvwp";

                default:
                    throw new Exception("Chưa cài đặt CSDL cho trang này");
            }
        }
    }
}
