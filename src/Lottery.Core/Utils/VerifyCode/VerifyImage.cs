﻿using System.Drawing;

namespace Lottery.Utils
{
    public class VerifyImage
    {
        private string contentType = "image/pjpeg";
        private Bitmap image;
        private System.Drawing.Imaging.ImageFormat imageFormat = System.Drawing.Imaging.ImageFormat.Jpeg;

        public string ContentType
        {
            get
            {
                return this.contentType;
            }
            set
            {
                this.contentType = value;
            }
        }

        public Bitmap Image
        {
            get
            {
                return this.image;
            }
            set
            {
                this.image = value;
            }
        }

        public System.Drawing.Imaging.ImageFormat ImageFormat
        {
            get
            {
                return this.imageFormat;
            }
            set
            {
                this.imageFormat = value;
            }
        }
    }
}

