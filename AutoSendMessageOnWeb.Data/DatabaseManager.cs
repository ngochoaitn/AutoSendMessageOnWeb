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
        public BindingList<ThongTinTaiKhoan> DanhSachNguoiGui { set; get; }
        public BindingList<ThongTinTaiKhoan> DanhSachNguoiNhan { set; get; }

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
            }
            catch
            {
                this.CreateDatabbase();
                fs.Close();
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
                default:
                    return "Data\\thuvienwinform.tvwp";
            }
        }
    }
}
