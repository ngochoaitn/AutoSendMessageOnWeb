﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoSendMessageOnWeb
{
    public partial class frmNoiDungCapNhat : Form
    {
        public frmNoiDungCapNhat()
        {
            InitializeComponent();
            textBoxFlat1.Text = System.IO.File.ReadAllText(Lib.StartUpOperation.ChangeLog);
        }
    }
}
