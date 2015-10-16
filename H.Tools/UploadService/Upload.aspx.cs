using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UploadService
{
    public partial class Upload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpPostedFile file = Request.Files["Filedata"];
            if (file != null)
            {
                string uploadPath = ConfigurationManager.AppSettings["ImageUploadPath"];
                string p = Path.GetPathRoot(uploadPath);
                if (p == null || p.Trim().Length <= 0) // 说明是相对路径
                {
                    uploadPath = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, uploadPath);
                }


                string savePath = DateTime.Now.ToString("yyyyMMdd") + "/";
                //文件夹名称 加上年月日
                uploadPath += savePath;

                if (!Directory.Exists(uploadPath))
                    Directory.CreateDirectory(uploadPath);

                //文件后缀名
                string extension = Path.GetExtension(file.FileName);
                //不包含后缀的文件名
                string fileName = Path.GetFileNameWithoutExtension(file.FileName);

                string saveFileName = fileName + DateTime.Now.ToString("yyyyMMddHHmmss") + extension;

                file.SaveAs(uploadPath + saveFileName);

                Response.Write(savePath + saveFileName);
            }
            else
                Response.Write("上传失败..文件异常!");
        }
    }
}