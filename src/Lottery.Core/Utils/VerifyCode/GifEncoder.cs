namespace Lottery.Utils
{
    using System;
    using System.Drawing;
    using System.IO;

    public class GifEncoder
    {
        protected int colorDepth;
        protected byte[] colorTab;
        protected int delay;
        protected int dispose = -1;
        protected bool firstFrame = true;
        protected int height;
        protected Image image;
        protected byte[] indexedPixels;
        protected MemoryStream Memory;
        protected int palSize = 7;
        protected byte[] pixels;
        protected int repeat = -1;
        protected int sample = 10;
        protected bool sizeSet;
        protected bool started;
        protected int transIndex;
        protected Color transparent = Color.Empty;
        protected bool[] usedEntry = new bool[0x100];
        protected int width;

        public bool AddFrame(Image im)
        {
            if (!((im != null) && this.started))
            {
                return false;
            }
            bool flag = true;
            try
            {
                if (!this.sizeSet)
                {
                    this.SetSize(im.Width, im.Height);
                }
                this.image = im;
                this.GetImagePixels();
                this.AnalyzePixels();
                if (this.firstFrame)
                {
                    this.WriteLSD();
                    this.WritePalette();
                    if (this.repeat >= 0)
                    {
                        this.WriteNetscapeExt();
                    }
                }
                this.WriteGraphicCtrlExt();
                this.WriteImageDesc();
                if (!this.firstFrame)
                {
                    this.WritePalette();
                }
                this.WritePixels();
                this.firstFrame = false;
            }
            catch (IOException)
            {
                flag = false;
            }
            return flag;
        }

        protected void AnalyzePixels()
        {
            int length = this.pixels.Length;
            int num2 = length / 3;
            this.indexedPixels = new byte[num2];
            NeuQuant quant = new NeuQuant(this.pixels, length, this.sample);
            this.colorTab = quant.Process();
            int num3 = 0;
            for (int i = 0; i < num2; i++)
            {
                int index = quant.Map(this.pixels[num3++] & 0xff, this.pixels[num3++] & 0xff, this.pixels[num3++] & 0xff);
                this.usedEntry[index] = true;
                this.indexedPixels[i] = (byte) index;
            }
            this.pixels = null;
            this.colorDepth = 8;
            this.palSize = 7;
            if (this.transparent != Color.Empty)
            {
                this.transIndex = this.FindClosest(this.transparent);
            }
        }

        protected int FindClosest(Color c)
        {
            if (this.colorTab == null)
            {
                return -1;
            }
            int r = c.R;
            int g = c.G;
            int b = c.B;
            int num4 = 0;
            int num5 = 0x1000000;
            int length = this.colorTab.Length;
            for (int i = 0; i < length; i++)
            {
                int num8 = r - (this.colorTab[i++] & 0xff);
                int num9 = g - (this.colorTab[i++] & 0xff);
                int num10 = b - (this.colorTab[i] & 0xff);
                int num11 = ((num8 * num8) + (num9 * num9)) + (num10 * num10);
                int index = i / 3;
                if (this.usedEntry[index] && (num11 < num5))
                {
                    num5 = num11;
                    num4 = index;
                }
            }
            return num4;
        }

        protected void GetImagePixels()
        {
            int width = this.image.Width;
            int height = this.image.Height;
            if ((width != this.width) || (height != this.height))
            {
                Image image = new Bitmap(this.width, this.height);
                Graphics graphics = Graphics.FromImage(image);
                graphics.DrawImage(this.image, 0, 0);
                this.image = image;
                graphics.Dispose();
            }
            this.pixels = new byte[(3 * this.image.Width) * this.image.Height];
            int index = 0;
            Bitmap bitmap = new Bitmap(this.image);
            for (int i = 0; i < this.image.Height; i++)
            {
                for (int j = 0; j < this.image.Width; j++)
                {
                    Color pixel = bitmap.GetPixel(j, i);
                    this.pixels[index] = pixel.R;
                    index++;
                    this.pixels[index] = pixel.G;
                    index++;
                    this.pixels[index] = pixel.B;
                    index++;
                }
            }
        }

        public void OutPut(ref MemoryStream MemoryResult)
        {
            this.started = false;
            this.Memory.WriteByte(0x3b);
            this.Memory.Flush();
            MemoryResult = this.Memory;
            this.Memory.Close();
            this.Memory.Dispose();
            this.transIndex = 0;
            this.Memory = null;
            this.image = null;
            this.pixels = null;
            this.indexedPixels = null;
            this.colorTab = null;
            this.firstFrame = true;
        }

        public void SetDelay(int ms)
        {
            this.delay = (int) Math.Round((double) (((float) ms) / 10f));
        }

        public void SetDispose(int code)
        {
            if (code >= 0)
            {
                this.dispose = code;
            }
        }

        public void SetFrameRate(float fps)
        {
            if (!(fps == 0f))
            {
                this.delay = (int) Math.Round((double) (100f / fps));
            }
        }

        public void SetQuality(int quality)
        {
            if (quality < 1)
            {
                quality = 1;
            }
            this.sample = quality;
        }

        public void SetRepeat(int iter)
        {
            if (iter >= 0)
            {
                this.repeat = iter;
            }
        }

        public void SetSize(int w, int h)
        {
            if (!this.started || this.firstFrame)
            {
                this.width = w;
                this.height = h;
                if (this.width < 1)
                {
                    this.width = 320;
                }
                if (this.height < 1)
                {
                    this.height = 240;
                }
                this.sizeSet = true;
            }
        }

        public void SetTransparent(Color c)
        {
            this.transparent = c;
        }

        public void Start()
        {
            this.Memory = new MemoryStream();
            this.WriteString("GIF89a");
            this.started = true;
        }

        protected void WriteGraphicCtrlExt()
        {
            int num;
            int num2;
            this.Memory.WriteByte(0x21);
            this.Memory.WriteByte(0xf9);
            this.Memory.WriteByte(4);
            if (this.transparent == Color.Empty)
            {
                num = 0;
                num2 = 0;
            }
            else
            {
                num = 1;
                num2 = 2;
            }
            if (this.dispose >= 0)
            {
                num2 = this.dispose & 7;
            }
            num2 = num2 << 2;
            this.Memory.WriteByte(Convert.ToByte((int) (num2 | num)));
            this.WriteShort(this.delay);
            this.Memory.WriteByte(Convert.ToByte(this.transIndex));
            this.Memory.WriteByte(0);
        }

        protected void WriteImageDesc()
        {
            this.Memory.WriteByte(0x2c);
            this.WriteShort(0);
            this.WriteShort(0);
            this.WriteShort(this.width);
            this.WriteShort(this.height);
            if (this.firstFrame)
            {
                this.Memory.WriteByte(0);
            }
            else
            {
                this.Memory.WriteByte(Convert.ToByte((int) (0x80 | this.palSize)));
            }
        }

        protected void WriteLSD()
        {
            this.WriteShort(this.width);
            this.WriteShort(this.height);
            this.Memory.WriteByte(Convert.ToByte((int) (240 | this.palSize)));
            this.Memory.WriteByte(0);
            this.Memory.WriteByte(0);
        }

        protected void WriteNetscapeExt()
        {
            this.Memory.WriteByte(0x21);
            this.Memory.WriteByte(0xff);
            this.Memory.WriteByte(11);
            this.WriteString("NETSCAPE2.0");
            this.Memory.WriteByte(3);
            this.Memory.WriteByte(1);
            this.WriteShort(this.repeat);
            this.Memory.WriteByte(0);
        }

        protected void WritePalette()
        {
            this.Memory.Write(this.colorTab, 0, this.colorTab.Length);
            int num = 0x300 - this.colorTab.Length;
            for (int i = 0; i < num; i++)
            {
                this.Memory.WriteByte(0);
            }
        }

        protected void WritePixels()
        {
            new LZWEncoder(this.width, this.height, this.indexedPixels, this.colorDepth).Encode(this.Memory);
        }

        protected void WriteShort(int value)
        {
            this.Memory.WriteByte(Convert.ToByte((int) (value & 0xff)));
            this.Memory.WriteByte(Convert.ToByte((int) ((value >> 8) & 0xff)));
        }

        protected void WriteString(string s)
        {
            char[] chArray = s.ToCharArray();
            for (int i = 0; i < chArray.Length; i++)
            {
                this.Memory.WriteByte((byte) chArray[i]);
            }
        }
    }

    public class LZWEncoder
    {
        private int a_count;
        private byte[] accum = new byte[0x100];
        private static readonly int BITS = 12;
        private bool clear_flg;
        private int ClearCode;
        private int[] codetab = new int[HSIZE];
        private int cur_accum;
        private int cur_bits;
        private int curPixel;
        private static readonly int EOF = -1;
        private int EOFCode;
        private int free_ent;
        private int g_init_bits;
        private int hsize = HSIZE;
        private static readonly int HSIZE = 0x138b;
        private int[] htab = new int[HSIZE];
        private int imgH;
        private int imgW;
        private int initCodeSize;
        private int[] masks = new int[] { 
            0, 1, 3, 7, 15, 0x1f, 0x3f, 0x7f, 0xff, 0x1ff, 0x3ff, 0x7ff, 0xfff, 0x1fff, 0x3fff, 0x7fff, 
            0xffff
         };
        private int maxbits = BITS;
        private int maxcode;
        private int maxmaxcode = (((int)1) << BITS);
        private int n_bits;
        private byte[] pixAry;
        private int remaining;

        public LZWEncoder(int width, int height, byte[] pixels, int color_depth)
        {
            this.imgW = width;
            this.imgH = height;
            this.pixAry = pixels;
            this.initCodeSize = Math.Max(2, color_depth);
        }

        private void Add(byte c, Stream outs)
        {
            this.accum[this.a_count++] = c;
            if (this.a_count >= 0xfe)
            {
                this.Flush(outs);
            }
        }

        private void ClearTable(Stream outs)
        {
            this.ResetCodeTable(this.hsize);
            this.free_ent = this.ClearCode + 2;
            this.clear_flg = true;
            this.Output(this.ClearCode, outs);
        }

        private void Compress(int init_bits, Stream outs)
        {
            int num;
            this.g_init_bits = init_bits;
            this.clear_flg = false;
            this.n_bits = this.g_init_bits;
            this.maxcode = this.MaxCode(this.n_bits);
            this.ClearCode = ((int)1) << (init_bits - 1);
            this.EOFCode = this.ClearCode + 1;
            this.free_ent = this.ClearCode + 2;
            this.a_count = 0;
            int code = this.NextPixel();
            int num3 = 0;
            int hsize = this.hsize;
            while (hsize < 0x10000)
            {
                num3++;
                hsize *= 2;
            }
            num3 = 8 - num3;
            int num5 = this.hsize;
            this.ResetCodeTable(num5);
            this.Output(this.ClearCode, outs);
        Label_01D0:
            while ((num = this.NextPixel()) != EOF)
            {
                hsize = (num << this.maxbits) + code;
                int index = (num << num3) ^ code;
                if (this.htab[index] == hsize)
                {
                    code = this.codetab[index];
                }
                else
                {
                    if (this.htab[index] >= 0)
                    {
                        int num7 = num5 - index;
                        if (index == 0)
                        {
                            num7 = 1;
                        }
                        do
                        {
                            index -= num7;
                            if (index < 0)
                            {
                                index += num5;
                            }
                            if (this.htab[index] == hsize)
                            {
                                code = this.codetab[index];
                                goto Label_01D0;
                            }
                        }
                        while (this.htab[index] >= 0);
                    }
                    this.Output(code, outs);
                    code = num;
                    if (this.free_ent < this.maxmaxcode)
                    {
                        this.codetab[index] = this.free_ent++;
                        this.htab[index] = hsize;
                    }
                    else
                    {
                        this.ClearTable(outs);
                    }
                }
            }
            this.Output(code, outs);
            this.Output(this.EOFCode, outs);
        }

        public void Encode(Stream os)
        {
            os.WriteByte(Convert.ToByte(this.initCodeSize));
            this.remaining = this.imgW * this.imgH;
            this.curPixel = 0;
            this.Compress(this.initCodeSize + 1, os);
            os.WriteByte(0);
        }

        private void Flush(Stream outs)
        {
            if (this.a_count > 0)
            {
                outs.WriteByte(Convert.ToByte(this.a_count));
                outs.Write(this.accum, 0, this.a_count);
                this.a_count = 0;
            }
        }

        private int MaxCode(int n_bits)
        {
            return ((((int)1) << n_bits) - 1);
        }

        private int NextPixel()
        {
            if (this.remaining == 0)
            {
                return EOF;
            }
            this.remaining--;
            int num = this.curPixel + 1;
            if (num < this.pixAry.GetUpperBound(0))
            {
                byte num2 = this.pixAry[this.curPixel++];
                return (num2 & 0xff);
            }
            return 0xff;
        }

        private void Output(int code, Stream outs)
        {
            this.cur_accum &= this.masks[this.cur_bits];
            if (this.cur_bits > 0)
            {
                this.cur_accum |= code << this.cur_bits;
            }
            else
            {
                this.cur_accum = code;
            }
            this.cur_bits += this.n_bits;
            while (this.cur_bits >= 8)
            {
                this.Add((byte)(this.cur_accum & 0xff), outs);
                this.cur_accum = this.cur_accum >> 8;
                this.cur_bits -= 8;
            }
            if ((this.free_ent > this.maxcode) || this.clear_flg)
            {
                if (this.clear_flg)
                {
                    this.maxcode = this.MaxCode(this.n_bits = this.g_init_bits);
                    this.clear_flg = false;
                }
                else
                {
                    this.n_bits++;
                    if (this.n_bits == this.maxbits)
                    {
                        this.maxcode = this.maxmaxcode;
                    }
                    else
                    {
                        this.maxcode = this.MaxCode(this.n_bits);
                    }
                }
            }
            if (code == this.EOFCode)
            {
                while (this.cur_bits > 0)
                {
                    this.Add((byte)(this.cur_accum & 0xff), outs);
                    this.cur_accum = this.cur_accum >> 8;
                    this.cur_bits -= 8;
                }
                this.Flush(outs);
            }
        }

        private void ResetCodeTable(int hsize)
        {
            for (int i = 0; i < hsize; i++)
            {
                this.htab[i] = -1;
            }
        }
    }

    public class NeuQuant
    {
        protected static readonly int alphabiasshift = 10;
        protected int alphadec;
        protected static readonly int alpharadbias = (((int)1) << alpharadbshift);
        protected static readonly int alpharadbshift = (alphabiasshift + radbiasshift);
        protected static readonly int beta = (intbias >> betashift);
        protected static readonly int betagamma = (intbias << (gammashift - betashift));
        protected static readonly int betashift = 10;
        protected int[] bias = new int[netsize];
        protected int[] freq = new int[netsize];
        protected static readonly int gamma = (((int)1) << gammashift);
        protected static readonly int gammashift = 10;
        protected static readonly int initalpha = (((int)1) << alphabiasshift);
        protected static readonly int initrad = (netsize >> 3);
        protected static readonly int initradius = (initrad * radiusbias);
        protected static readonly int intbias = (((int)1) << intbiasshift);
        protected static readonly int intbiasshift = 0x10;
        protected int lengthcount;
        protected static readonly int maxnetpos = (netsize - 1);
        protected static readonly int minpicturebytes = (3 * prime4);
        protected static readonly int ncycles = 100;
        protected static readonly int netbiasshift = 4;
        protected int[] netindex = new int[0x100];
        protected static readonly int netsize = 0x100;
        protected int[][] network;
        protected static readonly int prime1 = 0x1f3;
        protected static readonly int prime2 = 0x1eb;
        protected static readonly int prime3 = 0x1e7;
        protected static readonly int prime4 = 0x1f7;
        protected static readonly int radbias = (((int)1) << radbiasshift);
        protected static readonly int radbiasshift = 8;
        protected static readonly int radiusbias = (((int)1) << radiusbiasshift);
        protected static readonly int radiusbiasshift = 6;
        protected static readonly int radiusdec = 30;
        protected int[] radpower = new int[initrad];
        protected int samplefac;
        protected byte[] thepicture;

        public NeuQuant(byte[] thepic, int len, int sample)
        {
            this.thepicture = thepic;
            this.lengthcount = len;
            this.samplefac = sample;
            this.network = new int[netsize][];
            for (int i = 0; i < netsize; i++)
            {
                int num2;
                this.network[i] = new int[4];
                int[] numArray = this.network[i];
                numArray[2] = num2 = (i << (netbiasshift + 8)) / netsize;
                numArray[0] = numArray[1] = num2;
                this.freq[i] = intbias / netsize;
                this.bias[i] = 0;
            }
        }

        protected void Alterneigh(int rad, int i, int b, int g, int r)
        {
            int num = i - rad;
            if (num < -1)
            {
                num = -1;
            }
            int netsize = i + rad;
            if (netsize > NeuQuant.netsize)
            {
                netsize = NeuQuant.netsize;
            }
            int num3 = i + 1;
            int num4 = i - 1;
            int num5 = 1;
            while ((num3 < netsize) || (num4 > num))
            {
                int[] numArray;
                int num6 = this.radpower[num5++];
                if (num3 < netsize)
                {
                    numArray = this.network[num3++];
                    try
                    {
                        numArray[0] -= (num6 * (numArray[0] - b)) / alpharadbias;
                        numArray[1] -= (num6 * (numArray[1] - g)) / alpharadbias;
                        numArray[2] -= (num6 * (numArray[2] - r)) / alpharadbias;
                    }
                    catch (Exception)
                    {
                    }
                }
                if (num4 > num)
                {
                    numArray = this.network[num4--];
                    try
                    {
                        numArray[0] -= (num6 * (numArray[0] - b)) / alpharadbias;
                        numArray[1] -= (num6 * (numArray[1] - g)) / alpharadbias;
                        numArray[2] -= (num6 * (numArray[2] - r)) / alpharadbias;
                        continue;
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                }
            }
        }

        protected void Altersingle(int alpha, int i, int b, int g, int r)
        {
            int[] numArray = this.network[i];
            numArray[0] -= (alpha * (numArray[0] - b)) / initalpha;
            numArray[1] -= (alpha * (numArray[1] - g)) / initalpha;
            numArray[2] -= (alpha * (numArray[2] - r)) / initalpha;
        }

        public byte[] ColorMap()
        {
            byte[] buffer = new byte[3 * netsize];
            int[] numArray = new int[netsize];
            for (int i = 0; i < netsize; i++)
            {
                numArray[this.network[i][3]] = i;
            }
            int num2 = 0;
            for (int j = 0; j < netsize; j++)
            {
                int index = numArray[j];
                buffer[num2++] = (byte)this.network[index][0];
                buffer[num2++] = (byte)this.network[index][1];
                buffer[num2++] = (byte)this.network[index][2];
            }
            return buffer;
        }

        protected int Contest(int b, int g, int r)
        {
            int num = 0x7fffffff;
            int num2 = num;
            int index = -1;
            int num4 = index;
            for (int i = 0; i < netsize; i++)
            {
                int[] numArray = this.network[i];
                int num6 = numArray[0] - b;
                if (num6 < 0)
                {
                    num6 = -num6;
                }
                int num7 = numArray[1] - g;
                if (num7 < 0)
                {
                    num7 = -num7;
                }
                num6 += num7;
                num7 = numArray[2] - r;
                if (num7 < 0)
                {
                    num7 = -num7;
                }
                num6 += num7;
                if (num6 < num)
                {
                    num = num6;
                    index = i;
                }
                int num8 = num6 - (this.bias[i] >> (intbiasshift - netbiasshift));
                if (num8 < num2)
                {
                    num2 = num8;
                    num4 = i;
                }
                int num9 = this.freq[i] >> betashift;
                this.freq[i] -= num9;
                this.bias[i] += num9 << gammashift;
            }
            this.freq[index] += beta;
            this.bias[index] -= betagamma;
            return num4;
        }

        public void Inxbuild()
        {
            int num;
            int index = 0;
            int num3 = 0;
            for (int i = 0; i < netsize; i++)
            {
                int[] numArray;
                int[] numArray2 = this.network[i];
                int num5 = i;
                int num6 = numArray2[1];
                num = i + 1;
                while (num < netsize)
                {
                    numArray = this.network[num];
                    if (numArray[1] < num6)
                    {
                        num5 = num;
                        num6 = numArray[1];
                    }
                    num++;
                }
                numArray = this.network[num5];
                if (i != num5)
                {
                    num = numArray[0];
                    numArray[0] = numArray2[0];
                    numArray2[0] = num;
                    num = numArray[1];
                    numArray[1] = numArray2[1];
                    numArray2[1] = num;
                    num = numArray[2];
                    numArray[2] = numArray2[2];
                    numArray2[2] = num;
                    num = numArray[3];
                    numArray[3] = numArray2[3];
                    numArray2[3] = num;
                }
                if (num6 != index)
                {
                    this.netindex[index] = (num3 + i) >> 1;
                    num = index + 1;
                    while (num < num6)
                    {
                        this.netindex[num] = i;
                        num++;
                    }
                    index = num6;
                    num3 = i;
                }
            }
            this.netindex[index] = (num3 + maxnetpos) >> 1;
            for (num = index + 1; num < 0x100; num++)
            {
                this.netindex[num] = maxnetpos;
            }
        }

        public void Learn()
        {
            int num;
            int num2;
            if (this.lengthcount < minpicturebytes)
            {
                this.samplefac = 1;
            }
            this.alphadec = 30 + ((this.samplefac - 1) / 3);
            byte[] thepicture = this.thepicture;
            int index = 0;
            int lengthcount = this.lengthcount;
            int num5 = this.lengthcount / (3 * this.samplefac);
            int num6 = num5 / ncycles;
            int initalpha = NeuQuant.initalpha;
            int initradius = NeuQuant.initradius;
            int rad = initradius >> radiusbiasshift;
            if (rad <= 1)
            {
                rad = 0;
            }
            for (num = 0; num < rad; num++)
            {
                this.radpower[num] = initalpha * ((((rad * rad) - (num * num)) * radbias) / (rad * rad));
            }
            if (this.lengthcount < minpicturebytes)
            {
                num2 = 3;
            }
            else if ((this.lengthcount % prime1) != 0)
            {
                num2 = 3 * prime1;
            }
            else if ((this.lengthcount % prime2) != 0)
            {
                num2 = 3 * prime2;
            }
            else if ((this.lengthcount % prime3) != 0)
            {
                num2 = 3 * prime3;
            }
            else
            {
                num2 = 3 * prime4;
            }
            num = 0;
            while (num < num5)
            {
                int b = (thepicture[index] & 0xff) << netbiasshift;
                int g = (thepicture[index + 1] & 0xff) << netbiasshift;
                int r = (thepicture[index + 2] & 0xff) << netbiasshift;
                int i = this.Contest(b, g, r);
                this.Altersingle(initalpha, i, b, g, r);
                if (rad != 0)
                {
                    this.Alterneigh(rad, i, b, g, r);
                }
                index += num2;
                if (index >= lengthcount)
                {
                    index -= this.lengthcount;
                }
                num++;
                if (num6 == 0)
                {
                    num6 = 1;
                }
                if ((num % num6) == 0)
                {
                    initalpha -= initalpha / this.alphadec;
                    initradius -= initradius / radiusdec;
                    rad = initradius >> radiusbiasshift;
                    if (rad <= 1)
                    {
                        rad = 0;
                    }
                    for (i = 0; i < rad; i++)
                    {
                        this.radpower[i] = initalpha * ((((rad * rad) - (i * i)) * radbias) / (rad * rad));
                    }
                }
            }
        }

        public int Map(int b, int g, int r)
        {
            int num = 0x3e8;
            int num2 = -1;
            int index = this.netindex[g];
            int num4 = index - 1;
            while ((index < netsize) || (num4 >= 0))
            {
                int num5;
                int num6;
                int[] numArray;
                if (index < netsize)
                {
                    numArray = this.network[index];
                    num5 = numArray[1] - g;
                    if (num5 >= num)
                    {
                        index = netsize;
                    }
                    else
                    {
                        index++;
                        if (num5 < 0)
                        {
                            num5 = -num5;
                        }
                        num6 = numArray[0] - b;
                        if (num6 < 0)
                        {
                            num6 = -num6;
                        }
                        num5 += num6;
                        if (num5 < num)
                        {
                            num6 = numArray[2] - r;
                            if (num6 < 0)
                            {
                                num6 = -num6;
                            }
                            num5 += num6;
                            if (num5 < num)
                            {
                                num = num5;
                                num2 = numArray[3];
                            }
                        }
                    }
                }
                if (num4 >= 0)
                {
                    numArray = this.network[num4];
                    num5 = g - numArray[1];
                    if (num5 >= num)
                    {
                        num4 = -1;
                    }
                    else
                    {
                        num4--;
                        if (num5 < 0)
                        {
                            num5 = -num5;
                        }
                        num6 = numArray[0] - b;
                        if (num6 < 0)
                        {
                            num6 = -num6;
                        }
                        num5 += num6;
                        if (num5 < num)
                        {
                            num6 = numArray[2] - r;
                            if (num6 < 0)
                            {
                                num6 = -num6;
                            }
                            num5 += num6;
                            if (num5 < num)
                            {
                                num = num5;
                                num2 = numArray[3];
                            }
                        }
                    }
                }
            }
            return num2;
        }

        public byte[] Process()
        {
            this.Learn();
            this.Unbiasnet();
            this.Inxbuild();
            return this.ColorMap();
        }

        public void Unbiasnet()
        {
            for (int i = 0; i < netsize; i++)
            {
                this.network[i][0] = this.network[i][0] >> netbiasshift;
                this.network[i][1] = this.network[i][1] >> netbiasshift;
                this.network[i][2] = this.network[i][2] >> netbiasshift;
                this.network[i][3] = i;
            }
        }
    }
}

