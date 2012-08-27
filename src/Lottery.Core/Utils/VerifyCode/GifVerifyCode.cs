using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace Lottery.Utils
{
    public class GifVerifyCode
    {
        public Color DrawColor = Color.Orange;
        public Color FontColor = Color.Green;
        public bool FontTextRenderingHint;
        public string ValidateCodeFont = "Arial";
        public float ValidateCodeSize = 14f;

        private void CreateImageBmp(out Bitmap ImageFrame, string codeLength, int ImageHeight)
        {
            char[] chArray = codeLength.ToCharArray(0, codeLength.Length);
            int width = (int) (((codeLength.Length * this.ValidateCodeSize) * 1.1) + 4.0);
            ImageFrame = new Bitmap(width, ImageHeight);
            Graphics graphics = Graphics.FromImage(ImageFrame);
            graphics.Clear(Color.White);
            Font font = new Font(this.ValidateCodeFont, this.ValidateCodeSize, FontStyle.Bold);
            Brush brush = new SolidBrush(this.FontColor);
            int num2 = (int) Math.Max((float) ((ImageHeight - this.ValidateCodeSize) - 3f), (float) 2f);
            Random random = new Random();
            for (int i = 0; i < codeLength.Length; i++)
            {
                int[] numArray = new int[] { (((int) (i * this.ValidateCodeSize)) + random.Next(1)) + 3, random.Next(num2 - random.Next(num2 - 1)) };
                Point point = new Point(numArray[0], numArray[1]);
                if (this.FontTextRenderingHint)
                {
                    graphics.TextRenderingHint = TextRenderingHint.SingleBitPerPixel;
                }
                else
                {
                    graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
                }
                graphics.DrawString(chArray[i].ToString(), font, brush, (PointF) point);
            }
            graphics.Dispose();
        }

        private void DisposeImageBmp(ref Bitmap ImageFrame)
        {
            Graphics graphics = Graphics.FromImage(ImageFrame);
            Pen pen = new Pen(this.DrawColor, 1f);
            Random random = new Random();
            Point[] pointArray = new Point[2];
            for (int i = 0; i < 5; i++)
            {
                pointArray[0] = new Point(random.Next(ImageFrame.Width), random.Next(ImageFrame.Height));
                pointArray[1] = new Point(random.Next(ImageFrame.Width), random.Next(ImageFrame.Height));
                graphics.DrawLine(pen, pointArray[0], pointArray[1]);
            }
            graphics.Dispose();
        }

        public VerifyImage GenerateImage(string code, int width, int height, Color bgcolor, int textcolor)
        {
            VerifyImage info = new VerifyImage
            {
                ImageFormat = ImageFormat.Gif,
                ContentType = "image/gif"
            };
            height = 0x16;
            Bitmap imageFrame = new Bitmap(width, height, PixelFormat.Format32bppArgb);
            GifEncoder encoder = new GifEncoder();
            MemoryStream stream = new MemoryStream();
            encoder.Start();
            encoder.SetDelay(5);
            encoder.SetRepeat(0);
            for (int i = 0; i < 20; i++)
            {
                this.CreateImageBmp(out imageFrame, code, height);
                this.DisposeImageBmp(ref imageFrame);
                imageFrame.Save(stream, ImageFormat.Png);
                encoder.AddFrame(Image.FromStream(stream));
                stream = new MemoryStream();
            }
            encoder.OutPut(ref stream);
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.ContentType = "image/Gif";
            HttpContext.Current.Response.BinaryWrite(stream.ToArray());
            stream.Close();
            stream.Dispose();
            info.Image = imageFrame;
            return info;
        }

        public static string RandCode(int len, bool OnlyNum)
        {
            string[] strArray = new string[] { 
                "1", "2", "3", "4", "5", "6", "7", "8", "9", "a", "b", "c", "d", "e", "f", "g", 
                "h", "j", "k", "m", "n", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y"
             };
            Random random = new Random();
            int index = 4;
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < len; i++)
            {
                if (!OnlyNum)
                {
                    index = random.Next(0, strArray.Length);
                }
                else
                {
                    index = random.Next(0, 10);
                }
                builder.Append(strArray[index]);
            }
            return builder.ToString();
        }

        public static Color ToColor(string color)
        {
            int num;
            int num2;
            char[] chArray;
            int blue = 0;
            color = color.TrimStart(new char[] { '#' });
            color = Regex.Replace(color.ToLower(), "[g-zG-Z]", "");
            switch (color.Length)
            {
                case 3:
                    chArray = color.ToCharArray();
                    num = Convert.ToInt32(chArray[0].ToString() + chArray[0].ToString(), 0x10);
                    num2 = Convert.ToInt32(chArray[1].ToString() + chArray[1].ToString(), 0x10);
                    blue = Convert.ToInt32(chArray[2].ToString() + chArray[2].ToString(), 0x10);
                    return Color.FromArgb(num, num2, blue);

                case 6:
                    chArray = color.ToCharArray();
                    num = Convert.ToInt32(chArray[0].ToString() + chArray[1].ToString(), 0x10);
                    num2 = Convert.ToInt32(chArray[2].ToString() + chArray[3].ToString(), 0x10);
                    blue = Convert.ToInt32(chArray[4].ToString() + chArray[5].ToString(), 0x10);
                    return Color.FromArgb(num, num2, blue);
            }
            return Color.FromName(color);
        }
    }
}

