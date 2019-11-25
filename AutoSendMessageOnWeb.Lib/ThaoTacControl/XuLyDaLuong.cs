using System;
using System.Drawing;
using System.Windows.Forms;

namespace AutoSendMessageOnWeb.Lib.ThaoTacControl
{
    public class XuLyDaLuong
    {
        public static void ChangeText(Label lbl, string text, Color forcecolor)
        {
            if(lbl.InvokeRequired)
            {
                lbl.BeginInvoke((Action)(()=>
                {
                    lbl.ForeColor = forcecolor;
                    lbl.Text = text;
                }));
            }
            else
            {
                lbl.ForeColor = forcecolor;
                lbl.Text = text;
            }
        }

        public static void AppendText(TextBox txt, string text)
        {
            if (txt.InvokeRequired)
            {
                txt.BeginInvoke((Action)(() =>
                {
                    txt.AppendText(text);
                }));
            }
            else
            {
                txt.AppendText(text);
            }
        }
    }
}
