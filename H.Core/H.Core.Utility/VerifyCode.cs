using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace H.Core.Utility.UI
{
    [ToolboxData("<{0}:VerifyCode runat=server></{0}:VerifyCode>")]
    public class VerifyCode : WebControl
    {
        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>The value.</value>
        public string Value
        {
            get
            {
                if (HttpContext.Current.Request.Cookies["VerifyCode"] == null)
                {
                    return string.Empty;
                }
                else
                {
                    //return "1111";
                    return new EncryHelper().DoDecrypt(HttpContext.Current.Request.Cookies["VerifyCode"].Value, "VCode", Encoding.UTF8);
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VerifyCode"/> class.
        /// </summary>
        public VerifyCode()
            : base(HtmlTextWriterTag.Img)
        { }

        /// <summary>
        /// Adds HTML attributes and styles that need to be rendered to the specified <see cref="T:System.Web.UI.HtmlTextWriterTag"/>. This method is used primarily by control developers.
        /// </summary>
        /// <param name="writer">A <see cref="T:System.Web.UI.HtmlTextWriter"/> that represents the output stream to render HTML content on the client.</param>
        protected override void AddAttributesToRender(HtmlTextWriter writer)
        {
            base.AddAttributesToRender(writer);
            writer.AddStyleAttribute(HtmlTextWriterStyle.Cursor, "pointer");
            writer.AddAttribute("onclick", "this.src='VerifyCode.aspx?id='+Math.random()", true);
            writer.AddAttribute(HtmlTextWriterAttribute.Src, "");
            writer.AddAttribute(HtmlTextWriterAttribute.Height, "18px");
        }

        protected override void OnPreRender(EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(typeof(string), this.ID, "<script type=\"text/javascript\">$(\"#" + this.ID + "\").attr(\"src\",\"VerifyCode.aspx\");</script>");
            base.OnPreRender(e);
        }
    }

    public class VerifyImageHttpHandle : IHttpHandler
    {
        public VerifyImageHttpHandle()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #region 验证码长度(默认6个验证码的长度)
        int length = 4;
        public int Length
        {
            get { return length; }
            set { length = value; }
        }
        #endregion

        #region 验证码字体大小(为了显示扭曲效果，默认40像素，可以自行修改)
        Random random = new Random(DateTime.Now.Millisecond);
        public int FontSize
        {
            get { return random.Next(25, 26); }
        }
        #endregion

        #region 边框补(默认1像素)
        int padding = 1;
        public int Padding
        {
            get { return padding; }
            set { padding = value; }
        }
        #endregion

        #region 是否输出燥点(默认不输出)
        bool chaos = true;
        public bool Chaos
        {
            get { return chaos; }
            set { chaos = value; }
        }
        #endregion

        #region 输出燥点的颜色(默认灰色)
        public Color ChaosColor
        {
            get
            {
                int index = random.Next(0, colors.Length);
                return colors[index];
            }
        }
        #endregion

        #region 自定义背景色(默认白色)
        Color backgroundColor = Color.White;
        public Color BackgroundColor
        {
            get { return backgroundColor; }
            set { backgroundColor = value; }
        }
        #endregion

        #region 自定义随机颜色数组
        Color[] colors = { Color.Black, Color.Red, Color.DarkBlue, Color.Green, Color.Brown, Color.DarkCyan };
        public Color[] Colors
        {
            get { return colors; }
            set { colors = value; }
        }
        #endregion

        #region 自定义字体数组
        string[] fonts = { "Arial", "TAHOMA", "Verdana" };
        public string[] Fonts
        {
            get { return fonts; }
            set { fonts = value; }
        }
        #endregion

        #region 自定义随机码字符串序列(使用逗号分隔)
        string codeSerial = "2,3,4,5,6,7,8,9,A,B,C,E,F,G,H,J,K,L,M,N,P,R,S,T,U,V,W,X,Y,Z";
        public string CodeSerial
        {
            get { return codeSerial; }
            set { codeSerial = value; }
        }
        #endregion

        #region 产生波形滤镜效果

        /// <summary>
        /// 正弦曲线Wave扭曲图片
        /// </summary>
        /// <param name="srcBmp">图片路径</param>
        /// <param name="bXDir">如果扭曲则选择为True</param>
        /// <param name="nMultValue">波形的幅度倍数，越大扭曲的程度越高，一般为3</param>
        /// <param name="dPhase">波形的起始相位，取值区间[0-2*PI)</param>
        /// <returns></returns>
        public System.Drawing.Bitmap TwistImage(Bitmap srcBmp, bool bXDir, double dMultValue, double dPhase)
        {
            System.Drawing.Bitmap destBmp = new Bitmap(srcBmp.Width, srcBmp.Height);

            // 将位图背景填充为白色
            System.Drawing.Graphics graph = System.Drawing.Graphics.FromImage(destBmp);
            graph.FillRectangle(new SolidBrush(System.Drawing.Color.White), 0, 0, destBmp.Width, destBmp.Height);
            graph.Dispose();

            double dBaseAxisLen = bXDir ? (double)destBmp.Height : (double)destBmp.Width;

            for (int i = 0; i < destBmp.Width; i++)
            {
                for (int j = 0; j < destBmp.Height; j++)
                {
                    double dx = 0;
                    dx = bXDir ? (Math.PI * 2 * (double)j) / dBaseAxisLen : (Math.PI * 2 * (double)i) / dBaseAxisLen;
                    dx += dPhase;
                    double dy = Math.Sin(dx);

                    // 取得当前点的颜色
                    int nOldX = 0, nOldY = 0;
                    nOldX = bXDir ? i + (int)(dy * dMultValue) : i;
                    nOldY = bXDir ? j : j + (int)(dy * dMultValue);

                    System.Drawing.Color color = srcBmp.GetPixel(i, j);
                    if (nOldX >= 0 && nOldX < destBmp.Width
                     && nOldY >= 0 && nOldY < destBmp.Height)
                    {
                        destBmp.SetPixel(nOldX, nOldY, color);
                    }
                }
            }

            return destBmp;
        }



        #endregion

        #region 生成校验码图片
        public Bitmap CreateImageCode(string code)
        {
            int fSize = 26;
            int fWidth = fSize + Padding;

            int imageWidth = (int)(code.Length * fWidth) + 14 + Padding * 2;
            int imageHeight = fSize + Padding + 10;

            System.Drawing.Bitmap image = new System.Drawing.Bitmap(imageWidth, imageHeight);

            Graphics g = Graphics.FromImage(image);

            g.Clear(BackgroundColor);

            Random rand = new Random();
            //给背景添加随机生成的燥点
            if (this.Chaos)
            {
                //int c = Length * 5;

                //for (int i = 0; i < c; i++)
                //{
                //    Pen pen = new Pen(ChaosColor, 1);

                //    int x = rand.Next(image.Width);
                //    int y = rand.Next(image.Height);
                //    g.DrawRectangle(pen, x, y, 1, 1);
                //}

                //生成燥线
                Point oPoint1 = new Point();
                Point oPoint2 = new Point();
                Random oRnd = new Random();
                for (int i = 0; i < 3; i++)
                {
                    oPoint1.X = oRnd.Next(image.Width);
                    oPoint1.Y = oRnd.Next(image.Height);
                    oPoint2.X = oRnd.Next(image.Width);
                    oPoint2.Y = oRnd.Next(image.Height);
                    Color oColor = colors[oRnd.Next(colors.Length)];
                    Pen pen = new Pen(oColor, 1);
                    g.DrawLine(pen, oPoint1, oPoint2);
                }
            }

            int left = 0, top = 0, top1 = 1, top2 = 1;

            int n1 = (imageHeight - FontSize - Padding * 2);
            int n2 = n1 / 4;
            top1 = n2 - 3;
            top2 = n1 / 2;

            Font f;
            Brush b;

            int cindex, findex;
            //随机字体和颜色的验证码字符
            for (int i = 0; i < code.Length; i++)
            {
                cindex = rand.Next(Colors.Length - 1);
                findex = rand.Next(Fonts.Length - 1);

                f = new System.Drawing.Font(Fonts[findex], FontSize);
                b = new System.Drawing.SolidBrush(Colors[cindex]);

                top = rand.Next(top1, top2);

                left = i * fWidth;

                g.DrawString(code.Substring(i, 1), f, b, left, top);
            }

            //画一个边框 边框颜色为Color.Gainsboro
            g.DrawRectangle(new Pen(Color.Gainsboro, 0), 0, 0, image.Width - 1, image.Height - 1);
            g.Dispose();

            //产生波形（Add By 51aspx.com）
            //image = TwistImage(image, true, 6, 3);

            return image;
        }
        #endregion

        #region 将创建好的图片输出到页面
        public void CreateImageOnPage(string code, HttpContext context)
        {
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
            {
                Bitmap image = this.CreateImageCode(code);

                image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

                context.Response.ClearContent();
                context.Response.ContentType = "image/Jpeg";
                context.Response.BinaryWrite(ms.GetBuffer());

                ms.Close();
                image.Dispose();
                image = null;
            }
        }
        #endregion

        #region 生成随机字符码
        public string CreateVerifyCode(int codeLen)
        {
            if (codeLen == 0)
            {
                codeLen = Length;
            }

            string[] arr = CodeSerial.Split(',');

            string code = "";

            int randValue = -1;

            Random rand = new Random(unchecked((int)DateTime.Now.Ticks));

            for (int i = 0; i < codeLen; i++)
            {
                randValue = rand.Next(0, arr.Length - 1);

                code += arr[randValue];
            }

            return code;
        }
        public string CreateVerifyCode()
        {
            return CreateVerifyCode(0);
        }
        #endregion

        #region IHttpHandler Members

        public bool IsReusable
        {
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            VerifyImageHttpHandle v = new VerifyImageHttpHandle();

            v.Length = this.length;
            v.Chaos = this.chaos;
            v.BackgroundColor = this.backgroundColor;
            v.CodeSerial = this.codeSerial;
            v.Colors = this.colors;
            v.Fonts = this.fonts;
            v.Padding = this.padding;
            string code = v.CreateVerifyCode();
            HttpResponse Response = context.Response;
            Response.Cache.SetExpires(DateTime.Now.AddHours(-1));
            Response.CacheControl = "no-cache";
            //  将生成的图片发回客户端
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
            {
                Bitmap image = this.CreateImageCode(code);
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                code = new EncryHelper().DoEncrypt(code.ToUpper(), "VCode", Encoding.UTF8);
                Response.Cookies.Add(new HttpCookie("VerifyCode", code));
                Response.ClearContent(); //需要输出图象信息 要修改HTTP头 
                Response.ContentType = "image/jpeg";
                Response.BinaryWrite(ms.GetBuffer());
                image.Dispose();
                ms.Close();
                ms.Dispose();
                Response.End();
            }
        }

        #endregion
    }
}
