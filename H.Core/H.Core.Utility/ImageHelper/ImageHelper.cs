using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace H.Core.Utility
{
    public class ImageHelper
    {
        /// <summary>
        /// 保存图片缩略图
        /// </summary>
        /// <param name="uploadImage">图片</param>
        /// <param name="width">宽度</param>
        /// <param name="height">高度</param>
        /// <param name="fileKey">分组文件夹</param>
        /// <param name="midFilepath">中间文件夹</param>
        /// <param name="fileName">文件名</param>
        /// <param name="isOriginal">是否生成原图</param>
        public void SaveFixedImage(System.Drawing.Image uploadImage, int width, int height, string filePath, string midFilepath, string fileName, bool isOriginal)
        {
            System.Drawing.Image resizedImage = null;

            string savePath = filePath.Replace("Original", midFilepath);

            if (!Directory.Exists(savePath))
            {
                Directory.CreateDirectory(savePath);
            }

            //判断源图片大小小于等于被压缩的图片格式并且非原图压缩
            //则无需压缩直接保存到目标地址
            if (!isOriginal && (uploadImage.Height <= height || uploadImage.Width <= width))
            {
                uploadImage.Save(savePath + fileName, ImageFormat.Jpeg);
            }
            else
            {
                resizedImage = ImageResizingManagerBP.FixedSize(uploadImage, width, height);
                EncoderParameters ep = new EncoderParameters();
                long[] qy = new long[1];
                qy[0] = 100;
                EncoderParameter eParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, qy);
                ep.Param[0] = eParam;
                resizedImage.Save(savePath + fileName, ImageFormat.Jpeg);
                resizedImage.Dispose();
            }
        }


        public void SaveFixedImageForMobile(System.Drawing.Image uploadImage, int width, int height, string filePath, string midFilepath, string fileName, bool isOriginal)
        {
            System.Drawing.Image resizedImage = null;

            string savePath = filePath.Replace("Original", midFilepath);

            if (!Directory.Exists(savePath))
            {
                Directory.CreateDirectory(savePath);
            }

            //判断源图片大小小于等于被压缩的图片格式并且非原图压缩
            //则无需压缩直接保存到目标地址
            //if (!isOriginal && (uploadImage.Height <= height || uploadImage.Width <= width))
            //{
            //    uploadImage.Save(savePath + fileName, ImageFormat.Jpeg);
            //}
            //else
            //{
            resizedImage = ImageResizingManagerForMobileBP.FixedSize(uploadImage, width, height);
            EncoderParameters ep = new EncoderParameters();
            long[] qy = new long[1];
            qy[0] = 100;
            EncoderParameter eParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, qy);
            ep.Param[0] = eParam;
            resizedImage.Save(savePath + fileName, ImageFormat.Jpeg);
            resizedImage.Dispose();
            //}
        }
    }
}
