using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using ZXing;
using ZXing.QrCode;

namespace QRCode
{
    public class QRCoder
    {


        /// <summary>
        /// 读取二维码
        /// </summary>
        /// <param name="img">图片文件</param>
        /// <returns></returns>
        public string ReadQrCode(Image img)
        {
            BarcodeReader reader = new BarcodeReader();
            reader.Options.CharacterSet = "UTF-8";
            Bitmap map = new Bitmap(img);
            Result result = reader.Decode(map);
            return result == null ? "" : result.Text;
        }


        /// <summary>
        /// 读取二维码
        /// </summary>
        /// <param name="filename">文件路径</param>
        /// <returns></returns>
        public string ReadQrCode(string filename)
        {
            BarcodeReader reader = new BarcodeReader();
            reader.Options.CharacterSet = "UTF-8";
            Bitmap map = new Bitmap(filename);
            Result result = reader.Decode(map);
            return result == null ? "" : result.Text;
        }


        /// <summary>
        /// 生成二维码保存为图片
        /// </summary>
        /// <param name="text">二维码内容</param>
        public void GenerateQRCode(string text)
        {
            BarcodeWriter writer = new BarcodeWriter();

            writer.Format = BarcodeFormat.QR_CODE;

            QrCodeEncodingOptions options = new QrCodeEncodingOptions();

            options.DisableECI = true;

            //设置内容编码
            options.CharacterSet = "UTF-8";

            //设置二维码的宽度高度
            options.Width = 200;
            options.Height = 200;

            //设置二维码的边距，单位不是固定像素
            options.Margin = 1;
            writer.Options = options;

            Bitmap map = writer.Write(text);

            string filename = @"F:\qrcode.png";
            map.Save(filename, ImageFormat.Png);
            map.Dispose();

        }
    }
}
