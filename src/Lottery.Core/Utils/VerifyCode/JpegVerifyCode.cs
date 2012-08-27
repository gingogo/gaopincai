using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Lottery.Utils
{
    public class JpegVerifyCode
    {
        private static Bitmap charbmp = new Bitmap(40, 40);
        private static Font[] fonts = new Font[] { new Font(new FontFamily("Times New Roman"), (float) (0x10 + Next(3)), FontStyle.Regular), new Font(new FontFamily("Georgia"), (float) (0x10 + Next(3)), FontStyle.Regular), new Font(new FontFamily("Arial"), (float) (0x10 + Next(3)), FontStyle.Regular), new Font(new FontFamily("Comic Sans MS"), (float) (0x10 + Next(3)), FontStyle.Regular) };
        private static Matrix m = new Matrix();
        private static RNGCryptoServiceProvider rand = new RNGCryptoServiceProvider();
        private static byte[] randb = new byte[4];

        public static string GenValidateCode()
        {
            return GenValidateCode(5);
        }

        public static string GenValidateCode(int len)
        {
            if ((len < 1) || (len > 10))
            {
                len = 5;
            }
            Random random = new Random();
            string str = "1234567890";
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < len; i++)
            {
                builder.Append(str.Substring(random.Next(0, str.Length - 1), 1));
            }
            return builder.ToString();
        }

        private static int Next(int max)
        {
            rand.GetBytes(randb);
            int num = BitConverter.ToInt32(randb, 0) % (max + 1);
            if (num < 0)
            {
                num = -num;
            }
            return num;
        }

        private static int Next(int min, int max)
        {
            return (Next(max - min) + min);
        }

        public static void OutputValidateCodeImage(HttpResponse response, string validateCode)
        {
            OutputValidateCodeImage(response, validateCode, 18f, 80, 30);
        }

        public static void OutputValidateCodeImage(HttpResponse response, string validateCode, float fontSize)
        {
            OutputValidateCodeImage(response, validateCode, fontSize, 80, 30);
        }

        public static void OutputValidateCodeImage(HttpResponse response, string validateCode, float fontSize, int height)
        {
            int num2;
            int width = Convert.ToInt32((double) (validateCode.Length * 21.5));
            Bitmap image = new Bitmap(width, height);
            Graphics graphics = Graphics.FromImage(image);
            Color[] colorArray3 = new Color[] { Color.Black, Color.Red, Color.DarkBlue, Color.Green, Color.Brown, Color.DarkCyan, Color.Purple };
            Color[] colorArray = colorArray3;
            colorArray3 = new Color[] { Color.LightBlue, Color.LightCoral, Color.LightCyan, Color.LightGoldenrodYellow, Color.LightGray, Color.LightGreen, Color.LightPink, Color.LightSalmon, Color.LightSeaGreen, Color.LightSkyBlue, Color.LightYellow };
            Color[] colorArray2 = colorArray3;
            Random random = new Random();
            for (num2 = 0; num2 < 40; num2++)
            {
                Pen pen = new Pen(colorArray2[random.Next(11)], 0f);
                Point point = new Point(random.Next(width), random.Next(height));
                Point point2 = new Point(random.Next(width), random.Next(height));
                Point point3 = new Point(random.Next(width), random.Next(height));
                Point point4 = new Point(random.Next(width), random.Next(height));
                graphics.DrawBezier(pen, point, point2, point3, point4);
            }
            string s = string.Empty;
            int num3 = 2;
            for (num2 = 0; num2 < validateCode.Length; num2++)
            {
                s = validateCode.Substring(num2, 1);
                graphics.DrawString(s, new Font("宋体", fontSize, FontStyle.Bold), new SolidBrush(colorArray[random.Next(6)]), (float) num3, 2f);
                num3 += 20;
            }
            image.Save(response.OutputStream, ImageFormat.Jpeg);
            graphics.Dispose();
            image.Dispose();
            response.ContentType = "image/jpeg";
        }

        public static void OutputValidateCodeImage(HttpResponse response, string validateCode, float fontSize, int width, int height)
        {
            Bitmap image = new Bitmap(width, height);
            Graphics graphics = Graphics.FromImage(image);
            graphics.FillRectangle(new SolidBrush(Color.FromArgb(0x92, 0xa4, 0xde)), 0, 0, width, height);
            Font font = new Font(FontFamily.GenericSerif, fontSize, FontStyle.Bold, GraphicsUnit.Pixel);
            graphics.DrawString(validateCode, font, new SolidBrush(Color.White), (float) 3f, (float) 3f);
            Random random = new Random();
            Pen pen = new Pen(new SolidBrush(Color.Transparent), 2f);
            for (int i = 0; i < 10; i++)
            {
                graphics.DrawLine(pen, new Point(random.Next(0, 0xc7), random.Next(0, 0x3b)), new Point(random.Next(0, 0xc7), random.Next(0, 0x3b)));
            }
            image.Save(response.OutputStream, ImageFormat.Jpeg);
            graphics.Dispose();
            image.Dispose();
            response.ContentType = "image/jpeg";
        }

        public static void OutputValidateCodeImage(HttpResponse response, string code, int width, int height, Color bgcolor, int textcolor)
        {
            int num2;
            Bitmap image = new Bitmap(width, height, PixelFormat.Format32bppArgb);
            Graphics graphics = Graphics.FromImage(image);
            graphics.SmoothingMode = SmoothingMode.HighSpeed;
            graphics.Clear(bgcolor);
            int num = (textcolor == 2) ? 60 : 0;
            Pen pen = new Pen(Color.FromArgb(Next(50) + num, Next(50) + num, Next(50) + num), 1f);
            SolidBrush brush = new SolidBrush(Color.FromArgb(Next(100), Next(100), Next(100)));
            for (num2 = 0; num2 < 3; num2++)
            {
                graphics.DrawArc(pen, Next(20) - 10, Next(20) - 10, Next(width) + 10, Next(height) + 10, Next(-100, 100), Next(-200, 200));
            }
            Graphics graphics2 = Graphics.FromImage(charbmp);
            float x = -18f;
            for (num2 = 0; num2 < code.Length; num2++)
            {
                m.Reset();
                m.RotateAt((float) (Next(50) - 0x19), new PointF((float) (Next(3) + 7), (float) (Next(3) + 7)));
                graphics2.Clear(Color.Transparent);
                graphics2.Transform = m;
                brush.Color = Color.Black;
                x = (x + 18f) + Next(5);
                PointF point = new PointF(x, 2f);
                graphics2.DrawString(code[num2].ToString(), fonts[Next(fonts.Length - 1)], brush, new PointF(0f, 0f));
                graphics2.ResetTransform();
                graphics.DrawImage(charbmp, point);
            }
            brush.Dispose();
            graphics.Dispose();
            graphics2.Dispose();
            image.Save(response.OutputStream, ImageFormat.Jpeg);
            response.ContentType = "image/jpeg";
            response.Flush();
        }

        public static void OutputValidateCodeImage(HttpResponse response, string validateCode, float fontSize, int width, int height, Color bgcolor, Color txcolor, FontStyle fontStyle, string contentType)
        {
            Bitmap image = new Bitmap(width, height);
            Graphics graphics = Graphics.FromImage(image);
            graphics.FillRectangle(new SolidBrush(bgcolor), 0, 0, width, height);
            Font font = new Font(FontFamily.GenericSerif, fontSize, fontStyle, GraphicsUnit.Pixel);
            graphics.DrawString(validateCode, font, new SolidBrush(txcolor), (float) 3f, (float) 3f);
            image.Save(response.OutputStream, ImageFormat.Jpeg);
            graphics.Dispose();
            image.Dispose();
            if (contentType.Equals("png"))
            {
                response.ContentType = "image/png";
            }
            else
            {
                response.ContentType = "image/jpeg";
            }
        }
    }
}

