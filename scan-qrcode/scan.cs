using CSharpWin_JD.CaptureImage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace scan_qrcode
{
    public partial class scan : Form
    {
        public scan()
        {
            InitializeComponent();
            capture();
            this.Close();
        }

        //void Form1_Load(object sender, EventArgs e)
        //{
        //    capture();
        //}

        void capture()
        {
            CaptureImageTool capture = new CaptureImageTool();

            if (capture.ShowDialog() == DialogResult.OK)
            {
                QRCode.QRCoder qrcoder = new QRCode.QRCoder();

                string stri = qrcoder.ReadQrCode(capture.Image);
                if (!string.IsNullOrEmpty(stri))
                {
                    Clipboard.SetText(stri);
                    textBox1.Text = stri;
                }
                else
                {
                    textBox1.Text = "未能解析该二维码！";
                    textBox1.Enabled = false;
                }
                    
            }
        }



    }
}
