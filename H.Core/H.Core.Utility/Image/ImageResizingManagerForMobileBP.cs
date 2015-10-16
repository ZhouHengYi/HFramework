using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;

namespace H.Core.Utility.Image
{
    public class ImageResizingManagerForMobileBP
    {
        public static Bitmap ScaleByPercent(System.Drawing.Image imgPhoto, int Percent)
        {
            float nPercent = ((float)Percent / 100);

            int sourceWidth = imgPhoto.Width;
            int sourceHeight = imgPhoto.Height;
            int sourceX = 0;
            int sourceY = 0;

            int destX = 0;
            int destY = 0;
            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);

            Bitmap bmPhoto = new Bitmap(destWidth, destHeight, PixelFormat.Format24bppRgb);
            bmPhoto.SetResolution(imgPhoto.HorizontalResolution, imgPhoto.VerticalResolution);

            Graphics grPhoto = Graphics.FromImage(bmPhoto);
            grPhoto.CompositingQuality = CompositingQuality.HighQuality;
            grPhoto.SmoothingMode = SmoothingMode.HighQuality;
            grPhoto.InterpolationMode = InterpolationMode.HighQualityBicubic;
            grPhoto.Clear(Color.White);


            grPhoto.DrawImage(imgPhoto,
                new Rectangle(destX, destY, destWidth, destHeight),
                new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight),
                GraphicsUnit.Pixel);

            grPhoto.Dispose();
            return bmPhoto;
        }

        public static System.Drawing.Image ConstrainProportions(System.Drawing.Image imgPhoto, int Size, Dimensions Dimension)
        {
            int sourceWidth = imgPhoto.Width;
            int sourceHeight = imgPhoto.Height;
            int sourceX = 0;
            int sourceY = 0;
            int destX = 0;
            int destY = 0;
            float nPercent = 0;

            switch (Dimension)
            {
                case Dimensions.Width:
                    nPercent = ((float)Size / (float)sourceWidth);
                    break;
                default:
                    nPercent = ((float)Size / (float)sourceHeight);
                    break;
            }

            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);

            Bitmap bmPhoto = new Bitmap(destWidth, destHeight, PixelFormat.Format24bppRgb);
            bmPhoto.SetResolution(imgPhoto.HorizontalResolution, imgPhoto.VerticalResolution);

            Graphics grPhoto = Graphics.FromImage(bmPhoto);
            grPhoto.CompositingQuality = CompositingQuality.HighQuality;
            grPhoto.SmoothingMode = SmoothingMode.HighQuality;
            grPhoto.InterpolationMode = InterpolationMode.HighQualityBicubic;

            grPhoto.DrawImage(imgPhoto,
            new Rectangle(destX, destY, destWidth, destHeight),
            new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight),
            GraphicsUnit.Pixel);

            grPhoto.Dispose();
            return bmPhoto;
        }

        public static Bitmap FixedSize(System.Drawing.Image imgPhoto, int Width, int Height)
        {
            int sourceWidth = imgPhoto.Width;
            int sourceHeight = imgPhoto.Height;
            int sourceX = 0;
            int sourceY = 0;
            int destX = 0;
            int destY = 0;

            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;

            nPercentW = Math.Min((float)Width / (float)sourceWidth, 1.0F);
            nPercentH = Math.Min(((float)Height / (float)sourceHeight), 1.0F);

            //if we have to pad the height pad both the top and the bottom
            //with the difference between the scaled height and the desired height
            nPercent = Math.Min(nPercentH, nPercentW);

            destX = (int)((Width - (sourceWidth * nPercent * 0.8)) / 2);
            destY = (int)((Height - (sourceHeight * nPercent * 0.95)) / 2);

            int destWidth = (int)(sourceWidth * nPercent * 0.85);
            int destHeight = (int)(sourceHeight * nPercent * 0.85);

            Bitmap bmPhoto = new Bitmap(Width, Height, PixelFormat.Format48bppRgb);
            bmPhoto.SetResolution(imgPhoto.HorizontalResolution, imgPhoto.VerticalResolution);

            Graphics grPhoto = Graphics.FromImage(bmPhoto);
            grPhoto.Clear(Color.White);
            grPhoto.CompositingQuality = CompositingQuality.HighQuality;
            grPhoto.SmoothingMode = SmoothingMode.HighQuality;
            grPhoto.InterpolationMode = InterpolationMode.HighQualityBicubic;


            grPhoto.DrawImage(imgPhoto,
                new Rectangle(destX, destY, destWidth, destHeight),
                new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight),
                GraphicsUnit.Pixel);

            grPhoto.Dispose();
            return bmPhoto;
        }

        //private static readonly Bitmap s_imagWatermark = new Bitmap(HostingEnvironment.ApplicationPhysicalPath + ConfigurationManager.AppSettings["watermarkPath"]);
        private static readonly Dictionary<int, System.Drawing.Image> s_dictWaterMarks = new Dictionary<int, System.Drawing.Image>();
        /// <summary>
        /// 根据所给的宽、高得到相应比例的水印
        /// </summary>
        /// <param name="imageWidth"></param>
        /// <param name="imageHeight"></param>
        /// <returns></returns>
        private static Bitmap GetWatermark(int imageWidth, int imageHeight)
        {
            //if (!s_dictWaterMarks.ContainsKey(imageWidth))
            //{
            //    var precent = GetWatermarkPercent(imageWidth, imageHeight);
            //    int resizedWidth = (int)(s_imagWatermark.Width * precent);
            //    int resizedHeight = (int)(s_imagWatermark.Height * precent);

            //    var result = s_imagWatermark.GetThumbnailImage(resizedWidth, resizedHeight, () => false, IntPtr.Zero);

            //    s_dictWaterMarks[imageWidth] = result;
            //}

            return (Bitmap)s_dictWaterMarks[imageWidth];
        }

        private const int DEFAULT_WIDTH = 1024;
        private const int DEFAULT_HEIGHT = 1024;
        private static float GetWatermarkPercent(int imageWidth, int imageHeight)
        {
            return Math.Min((float)imageWidth / (float)DEFAULT_WIDTH, (float)imageHeight / (float)DEFAULT_HEIGHT);
        }

        public static Bitmap InsertWatermark(System.Drawing.Image imgPhoto)
        {
            int phWidth = imgPhoto.Width;
            int phHeight = imgPhoto.Height;
            Graphics grPhoto = null;
            Bitmap bmWatermark = null;
            Graphics grWatermark = null;

            try
            {
                //load the Bitmap into a Graphics object 
                grPhoto = Graphics.FromImage(imgPhoto);

                //create a image object containing the watermark
                System.Drawing.Image imgWatermark = GetWatermark(imgPhoto.Width, imgPhoto.Height);
                int wmWidth = imgWatermark.Width;
                int wmHeight = imgWatermark.Height;

                //Create a Bitmap based on the previously modified photograph Bitmap
                bmWatermark = new Bitmap(imgPhoto);
                bmWatermark.SetResolution(imgPhoto.HorizontalResolution, imgPhoto.VerticalResolution);
                //Load this Bitmap into a new Graphic Object
                grWatermark = Graphics.FromImage(bmWatermark);

                //To achieve a transulcent watermark we will apply (2) color 
                //manipulations by defineing a ImageAttributes object and 
                //seting (2) of its properties.
                ImageAttributes imageAttributes = new ImageAttributes();
                /*
                //The first step in manipulating the watermark image is to replace 
                //the background color with one that is trasparent (Alpha=0, R=0, G=0, B=0)
                //to do this we will use a Colormap and use this to define a RemapTable
                ColorMap colorMap = new ColorMap();

                //My watermark was defined with a background of 100% Green this will
                //be the color we search for and replace with transparency
                colorMap.OldColor = Color.FromArgb(255, 0, 255, 0);
                colorMap.NewColor = Color.FromArgb(0, 0, 0, 0);

                ColorMap[] remapTable = { colorMap };

                imageAttributes.SetRemapTable(remapTable, ColorAdjustType.Bitmap);
                */
                //The second color manipulation is used to change the opacity of the 
                //watermark.  This is done by applying a 5x5 matrix that contains the 
                //coordinates for the RGBA space.  By setting the 3rd row and 3rd column 
                //to 0.3f we achive a level of opacity
                float[][] colorMatrixElements = { 
												new float[] {1.0f,  0.0f,  0.0f,  0.0f, 0.0f},       
												new float[] {0.0f,  1.0f,  0.0f,  0.0f, 0.0f},        
												new float[] {0.0f,  0.0f,  1.0f,  0.0f, 0.0f},        
												new float[] {0.0f,  0.0f,  0.0f,  0.1f, 0.0f},        
												new float[] {0.0f,  0.0f,  0.0f,  0.0f, 1.0f}};
                ColorMatrix wmColorMatrix = new ColorMatrix(colorMatrixElements);

                imageAttributes.SetColorMatrix(wmColorMatrix, ColorMatrixFlag.Default,
                    ColorAdjustType.Bitmap);

                //For this example we will place the watermark in the upper right
                //hand corner of the photograph. offset down 10 pixels and to the 
                //left 10 pixles

                //int xPosOfWm = 10;
                int xPosOfWm = ((phWidth - wmWidth) - 10);
                int yPosOfWm = ((phHeight - wmHeight) - 10);

                grWatermark.DrawImage(imgWatermark,
                    new Rectangle(xPosOfWm, yPosOfWm, wmWidth, wmHeight),  //Set the detination Position
                    0,                  // x-coordinate of the portion of the source image to draw. 
                    0,                  // y-coordinate of the portion of the source image to draw. 
                    wmWidth,            // Watermark Width
                    wmHeight,		    // Watermark Height
                    GraphicsUnit.Pixel, // Unit of measurment
                    imageAttributes);   //ImageAttributes Object

                return bmWatermark;
            }
            finally
            {
                if (grPhoto != null)
                {
                    grPhoto.Dispose();
                }
                if (grWatermark != null)
                {
                    grWatermark.Dispose();
                }
                if (imgPhoto != null)
                {
                    imgPhoto.Dispose();
                }
            }
        }
    }
    public enum Dimensions
    {
        Width,
        Height
    }
}
