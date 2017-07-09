using AutoSendMessageOnWeb.Lib.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace AutoSendMessageOnWeb
{
    public partial class frmTest : Form
    {
        public frmTest()
        {
            InitializeComponent();
        }

        private async void btnDangNhap_Click(object sender, EventArgs e)
        {
            this.GetCookie(txtTaiKhoan.Text, txtMatKhau.Text);

            //System.Net.Http.HttpClientHandler handle = new HttpClientHandler() { AllowAutoRedirect = false };

            //HttpClient httpClient = new HttpClient(handle, true);

            //KeyValuePair<string, string> taiKhoan = new KeyValuePair<string, string>("Email", txtTaiKhoan.Text);
            //KeyValuePair<string, string> matKhau = new KeyValuePair<string, string>("Password", txtMatKhau.Text);
            //KeyValuePair<string, string> rem = new KeyValuePair<string, string>("RememberMe", "true");
            //KeyValuePair<string, string> returnUrl = new KeyValuePair<string, string>("returnUrl", "/");

            //FormUrlEncodedContent content = new FormUrlEncodedContent(new[] { taiKhoan, matKhau, rem, returnUrl });
            
            //var clientRes = await httpClient.PostAsync("http://henho2.com/Account/Login", content);
            //var clientResJson = await clientRes.Content.ReadAsStringAsync();
            //var setCoolkie = clientRes.Headers.Where(p => p.Key == "Set-Cookie").FirstOrDefault();
            //CookieContainer container = new CookieContainer();
        }
        CookieContainer t;
        private string GetCookie(string taikhoan, string matkhau)
        {
            HttpWebRequest request = WebRequest.CreateHttp("http://henho2.com/Account/Login");
            request.ContentType = "application/x-www-form-urlencoded";
            request.AllowAutoRedirect = false;
            request.Method = "POST";
            StreamWriter sw = new StreamWriter(request.GetRequestStream());
            sw.Write(string.Format("Email={0}&Password={1}&RememberMe=true&returnUrl=%2F", taikhoan, matkhau));
            sw.Close();

            var response = request.GetResponse();
            var httpRes = response as HttpWebResponse;

            string setCookie = httpRes.Headers[HttpResponseHeader.SetCookie];
            t = new CookieContainer();
            t.SetCookies(new Uri("http://henho2.com/"), setCookie);
            return setCookie;
        }

        private void btnGuiTinNhan_Click(object sender, EventArgs e)
        {
            var uri = new UriBuilder("http://henho2.com/signalr/send");
            var query = HttpUtility.ParseQueryString(uri.Query);
            query["transport"] = "serverSentEvents";
            query["clientProtocol"] = "1.5";
            query["connectionToken"] = txtToken.Text;
            query["connectionData"] = "[{\"name\":\"chathub\"}]";
            uri.Query = query.ToString();

            HttpWebRequest request = WebRequest.CreateHttp(uri.Uri);

            request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
            //request.AllowAutoRedirect = false;
            request.Method = "POST";
            request.Headers.Add("Cookie", "openid_provider=google; ASP.NET_SessionId=oclvqdwznrkvlxyxy3ayrndt; .ASPXAUTH=2C3A488EDE85516BE48CA2E124B07D4212F12390C7AFAF5A81A4C571258F6547DF18BDFE2C4A65B16193E291CDE7A857E16FEF898976D1ED01A0DACAC1AC29DB5826F107DDA8030C6B30A4AC961782ED6CA9054A6A151BB8FDBDACBB55707C5CCBB9F84694FEC41CC6AF36EFF51E2021555E3403AC670DF1B08E1F24120ABFDD; _ga=GA1.2.436732481.1499097973; _gid=GA1.2.378764503.1499097973; _gat=1");

            StreamWriter sw = new StreamWriter(request.GetRequestStream());
            string data = "data={\"H\":\"chathub\",\"M\":\"SendPrivateMessage\",\"A\":[\"496008\",\"496010\",\"" + txtNoiDung.Text+ "\"],\"I\":1}";
            sw.Write(data);
            sw.Close();

            var response = request.GetResponse();
            var httpRes = response as HttpWebResponse;

            string setCookie = httpRes.Headers[HttpResponseHeader.SetCookie];
        }

        private void btnGuiThu_Click(object sender, EventArgs e)
        {
            HttpWebRequest request = WebRequest.CreateHttp("http://henho2.com/Message/Create");
            request.Method = "POST";
            //request.Headers.Add(HttpRequestHeader.Cookie, "ASP.NET_SessionId=g5ko5udrtlkbero2ev2iqrqr; path=%2F; HttpOnly,.ASPXAUTH=6649FE077994F0EC10384C3B192C022A903858710D67B881179295C3BA003F70F785EE3E40F2603DA92C428E2EF221546AC114BAD96D952133C45E40A93CA099A27D387BD6396C59F2E04CD7636F1572BB87D796FAD94DFF355374E594345F19CCB0A063476E863384B68C0240E669CC098A16CBA44B546B9BA14D6793FD4CCD; expires=Thu, 13-Jul-2017 01:09:17 GMT; path=%2F; HttpOnly");
            request.ContentType = "application/x-www-form-urlencoded";
            var cole = t.GetCookies(new Uri("http://henho2.com/"));
            request.CookieContainer = new CookieContainer();
            foreach (Cookie co in cole)
                request.CookieContainer.Add(co);
            string data = "IdTo=496010&NameTo=Kakashi Hatake&Title=Xin chà12o&MessageContent=Nội dung";
            StreamWriter sw = new StreamWriter(request.GetRequestStream());
            sw.Write(data);
            sw.Close();

            var response = request.GetResponse();

            StreamReader sr = new StreamReader(response.GetResponseStream());
            string ss = sr.ReadToEnd();

            var httpRes = response as HttpWebResponse;
            StreamReader sr2 = new StreamReader(httpRes.GetResponseStream());
            string ss2 = sr2.ReadToEnd();

            
            
        }

        private void btnMaHoa_Click(object sender, EventArgs e)
        {
            txtBanMa.Text = Crypto.Encrypt(txtBanRo.Text);
        }

        private void btnGiaiMa_Click(object sender, EventArgs e)
        {
            txtBanRo.Text += Crypto.Decrypt(txtBanMa.Text);
        }

        private void btnTaoKhoa_Click(object sender, EventArgs e)
        {
            Crypto.CreateKey(Convert.ToInt32(txtBanRo.Text));
        }

        private void btnCauTrucKey_Click(object sender, EventArgs e)
        {
            txtBanMa.Text = DataUseForSecurity.GenKeySendToClient(txtBanRo.Text, new DateTime(2017, 8, 9));
        }

        private void btnGuiAdmin_Click(object sender, EventArgs e)
        {
            txtBanMa.Text = DataUseForSecurity.GenKeySendToAdmin();
        }

        private void btnBam_Click(object sender, EventArgs e)
        {
            txtBanMa.Text = Crypto.HashString(txtBanRo.Text);
        }

        private void btnXacThuc_Click(object sender, EventArgs e)
        {
            string[] spl = txtBanMa.Text.Split('[', ']');
            DateTime? exp = Crypto.VerifySignature(spl[3], spl[1]);
            if (exp != null)
                MessageBox.Show(string.Format("Đã xác thực {0:dd/MM/yyyy}", exp.Value.ToShortDateString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information));
           else
                MessageBox.Show("Sai mã", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
