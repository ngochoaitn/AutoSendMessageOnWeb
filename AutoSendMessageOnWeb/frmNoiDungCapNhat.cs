using System.Windows.Forms;

namespace AutoSendMessageOnWeb
{
    public partial class frmNoiDungCapNhat : Form
    {
        public frmNoiDungCapNhat()
        {
            InitializeComponent();
            this.Text += this.Text += System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            textBoxFlat1.AppendText(System.IO.File.ReadAllText(Lib.StartUpOperation.ChangeLog));
        }
    }
}
