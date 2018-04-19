
using Lib.Web.Action;
using System.Web;
using System;
using System.IO;
using System.Collections;
using LitJson;
using System.Globalization;
using System.Drawing.Imaging;
using System.Drawing;
using System.Linq;
using MV.PH.Entity;
using Lib.Data;

using MV.PH.WebAdmin.Model.Common;

namespace MV.PH.WebAdmin.action
{
    /// <summary>
    /// common 的摘要说明
    /// </summary>
    public class common : ActionBase
    {
        SqlDataAccess sda = new SqlDataAccess("default");
        SystemSetting_dal dal = new SystemSetting_dal();
        public void uploadFile()
        {
            SystemSettingEntity entity = this.sda.FindEntity(new SystemSettingEntity() {SystemSettingKey= "watermarktext" });
            string type = Request["IsType"];  //上传类型,  1、富文本上传的文件，2、附件按钮上传的文件
            //string IsWater = Request["IsWater"];      //是否水印 1、水印文字；2、水印图片；否则无水印
            string IsThumbnail = Request["IsThumbnail"];    //是否缩略图  1、缩略图

            #region  //富文本上传的文件
            if (type == "1")
            {
                HttpPostedFile imgFile = Request.Files["imgFile"];   //文件上传
                //文件保存物理路径
                String savePath = "/resource/editor/";

                //文件保存虚拟路径
                String saveUrl = "/resource/editor/";

                Hashtable extTable = new Hashtable();
                extTable.Add("image", "gif,jpg,jpeg,png,bmp");
                extTable.Add("flash", "swf,flv");
                extTable.Add("media", "mp3,wav,wma,wmv,midi,avi,mp4,aac,ra,rmvb");
                extTable.Add("file", "doc,docx,xls,xlsx,ppt,htm,html,txt,zip,rar,gz,bz2");

                //最大文件大小为1GB
                int maxSize = 1024 * 1024 * 1024;

                if (imgFile == null)
                {
                    showError("请选择文件。");
                }

                String dirPath = Server.MapPath(savePath);
                if (!Directory.Exists(dirPath))
                {
                    //showError("上传目录不存在。");
                    Directory.CreateDirectory(dirPath);
                }

                String dirName = Request.QueryString["dir"];
                if (String.IsNullOrEmpty(dirName))
                {
                    dirName = "image";
                }
                if (!extTable.ContainsKey(dirName))
                {
                    showError("目录名不正确。");
                }

                String fileName = imgFile.FileName;  //文件名
                string fileExt = Path.GetExtension(fileName).ToLower();  //文件后缀

                if (imgFile.InputStream == null || imgFile.InputStream.Length > maxSize)
                {
                    showError("上传文件大小超过限制。");
                }

                if (String.IsNullOrEmpty(fileExt) || Array.IndexOf(((String)extTable[dirName]).Split(','), fileExt.Substring(1).ToLower()) == -1)
                {
                    showError("上传文件扩展名是不允许的扩展名。\n只允许" + ((String)extTable[dirName]) + "格式。");
                }
                if (dirName == "image")   //上传文件为图片文件
                {
                    //创建文件夹
                    dirPath += dirName + "/img/";
                    saveUrl += dirName + "/img/";
                }
                else
                {
                    dirPath += dirName + "/";
                    saveUrl += dirName + "/";
                }
                if (!Directory.Exists(dirPath))
                {
                    Directory.CreateDirectory(dirPath);
                }
                String ymd = DateTime.Now.ToString("yyyyMMdd", DateTimeFormatInfo.InvariantInfo);
                dirPath += ymd + "/";
                saveUrl += ymd + "/";
                if (!Directory.Exists(dirPath))
                {
                    Directory.CreateDirectory(dirPath);
                }

                String newFileName = DateTime.Now.ToString("yyyyMMddHHmmss_ffff", DateTimeFormatInfo.InvariantInfo) + fileExt;
                String filePath = dirPath + newFileName;   //服务端完整路径

                imgFile.SaveAs(filePath);
                string fileUrl = saveUrl + newFileName;  //文件的虚拟路径

                string webFilePath_syp1 = "";  // 服务器端带水印图路径(图片)

                #region  //水印文字
                //if (IsWater == "1")  //水印文字
                //{
                if (dal.GetWatermarkType() == "1") { 
                    if (fileExt == ".jpg" || fileExt == ".jpeg" || fileExt == ".bmp" || fileExt == ".gif" || fileExt == ".png")  //如果该文件为图片文件就加水印图片
                    {
                        string fileName_sy = "text_" + DateTime.Now.ToString("yyyyMMddHHmmss_ffff", DateTimeFormatInfo.InvariantInfo) + fileExt;                         // 水印图文件名称（文字）

                        webFilePath_syp1 = saveFile(fileName_sy, imgFile, "img_syw", true); // 服务器端带水印图路径(文字)
                        AddWater(Server.MapPath(fileUrl), Server.MapPath(webFilePath_syp1), ReturnImagepostion(), 100, entity.SystemSettingValue, "#fff");

                    }
                }
                //}
                #endregion

                #region  //水印图片
                //if (IsWater == "2")
                //{
                if (dal.GetWatermarkType() == "2")
                {
                    if (fileExt == ".jpg" || fileExt == ".jpeg" || fileExt == ".bmp" || fileExt == ".gif" || fileExt == ".png")  //如果该文件为图片文件就加水印图片
                    {
                        string fileName_syp1 = "water_" + DateTime.Now.ToString("yyyyMMddHHmmss_ffff", DateTimeFormatInfo.InvariantInfo) + fileExt;
                        webFilePath_syp1 = saveFile(fileName_syp1, imgFile, "img_syp", true); // 服务器端带水印图路径(图片)
                        string webFilePath_sypf1 = Server.MapPath("/images/icon/watermark.png"); // 服务器端水印图路径(图片)

                        AddWaterPic(Server.MapPath(fileUrl), Server.MapPath(webFilePath_syp1), ReturnImagepostion(), webFilePath_sypf1);  //生成水印图片
                    }
                }
                    
                //}
                #endregion
                
                
                Hashtable hash1 = new Hashtable();
                hash1["error"] = 0;
                hash1["url"] = string.IsNullOrEmpty(webFilePath_syp1)? fileUrl : webFilePath_syp1;   //如果webFilePath_syp1为空则为文件上传，否则为水印图片路径
                hash1["filename"] = imgFile.FileName;
                hash1["fileType"] = fileExt.Substring(fileExt.LastIndexOf(".") + 1);
                hash1["size"] = Hs(imgFile.ContentLength);
                Response.AddHeader("Content-Type", "text/html; charset=UTF-8");
                Response.Write(JsonMapper.ToJson(hash1));
                Response.End();
            }
            #endregion

            #region  //附件按钮上传的文件
            else
            {
                HttpPostedFile imgFile = Request.Files["file"];   //文件上传
                //文件保存物理路径
                String savePath = "/resource/attach/";

                //文件保存虚拟路径
                String saveUrl = "/resource/attach/";
                
                String dirPath = Server.MapPath(savePath);
                if (!Directory.Exists(dirPath))
                {
                    //showError("上传目录不存在。");
                    Directory.CreateDirectory(dirPath);
                }

                if (imgFile == null)
                {
                    showError("请选择文件。");
                }
                String fileName = imgFile.FileName;  //文件名
                string fileExt = Path.GetExtension(fileName).ToLower();  //文件后缀

                string fileType = fileExt.Substring(fileExt.IndexOf(".")+1); //文件格式 jpeg/jpg/png/bmp/docx等

                String dirName = "";
                #region  //根据文件类型创建文件夹
                string[] img_Type = { "gif", "jpg", "jpeg", "png", "bmp" };
                string[] file_Type = { "doc","docx","xls","xlsx","ppt","htm","html","txt","zip","rar" };
                string[] media_Type = { "mp3", "wav","wma","wmv","midi","avi","mp4","aac","ra","rmvb" };
                if (img_Type.Contains(fileType))
                {
                    dirName = "image";
                }
                else if (fileType.Contains(fileType))
                {
                    dirName = "file";
                }
                else if (media_Type.Contains(fileType))
                {
                    dirName = "media";
                }
                else
                {
                    dirName = "temp";
                }
                #endregion
                dirPath += dirName + "/";
                saveUrl += dirName + "/";
                if (!Directory.Exists(dirPath))
                {
                    Directory.CreateDirectory(dirPath);
                }
                String ymd = DateTime.Now.ToString("yyyyMMdd", DateTimeFormatInfo.InvariantInfo);
                dirPath += ymd + "/";
                saveUrl += ymd + "/";
                if (!Directory.Exists(dirPath))
                {
                    Directory.CreateDirectory(dirPath);
                }

                String newFileName = DateTime.Now.ToString("yyyyMMddHHmmss_ffff", DateTimeFormatInfo.InvariantInfo) + fileExt;
                String filePath = dirPath + newFileName;   //服务端完整路径

                imgFile.SaveAs(filePath);

                string fileUrl = saveUrl + newFileName;  //文件的虚拟路径
                string webFilePath_sy = "";   //水印（文字）图片的虚拟路径
                string Thumbnail = "";      //缩略图的虚拟路径

                #region  //水印文字
                //if (IsWater == "1")  //水印文字
                //{

                //}
                if (dal.GetWatermarkType() == "1")
                {
                    if (fileExt == ".jpg" || fileExt == ".jpeg" || fileExt == ".bmp" || fileExt == ".gif" || fileExt == ".png")  //如果该文件为图片文件就加水印图片
                    {
                        string fileName_sy = "text_" + DateTime.Now.ToString("yyyyMMddHHmmss_ffff", DateTimeFormatInfo.InvariantInfo) + fileExt;                         // 水印图文件名称（文字）

                        webFilePath_sy = saveFile(fileName_sy, imgFile, "img_syw", false); // 服务器端带水印图路径(文字)
                        AddWater(Server.MapPath(fileUrl), Server.MapPath(webFilePath_sy), ReturnImagepostion(), 100, entity.SystemSettingValue, "#fff");

                    }
                }
                #endregion

                #region  //水印图片
                //if (IsWater == "1")
                //{

                //}
                if (dal.GetWatermarkType() == "2")
                {
                    if (fileExt == ".jpg" || fileExt == ".jpeg" || fileExt == ".bmp" || fileExt == ".gif" || fileExt == ".png")  //如果该文件为图片文件就加水印图片
                    {
                        string fileName_syp1 = "water_" + DateTime.Now.ToString("yyyyMMddHHmmss_ffff", DateTimeFormatInfo.InvariantInfo) + fileExt;
                        webFilePath_sy = saveFile(fileName_syp1, imgFile, "img_syp", false);      // 服务器端带水印图路径(图片)
                        string webFilePath_sypf1 = Server.MapPath("/images/icon/watermark.png"); // 服务器端水印图路径(图片)

                        AddWaterPic(Server.MapPath(fileUrl), Server.MapPath(webFilePath_sy), ReturnImagepostion(), webFilePath_sypf1);  //生成水印图片
                    }
                }
                #endregion

                #region  //缩略图
                if (IsThumbnail == "1")  //缩略图
                {
                    if (fileExt == ".jpg" || fileExt == ".jpeg" || fileExt == ".bmp" || fileExt == ".gif" || fileExt == ".png")  //如果该文件为图片文件就生成缩略图
                    {
                        string fileName_x = "x_" + DateTime.Now.ToString("yyyyMMddHHmmss_ffff", DateTimeFormatInfo.InvariantInfo) + fileExt;                         // 缩略图文件名称（文字）
                        Thumbnail = saveFile(fileName_x, imgFile, "thumb", false); // 服务器端缩略图路径
                         MakeThumbnail(Server.MapPath(fileUrl), Server.MapPath(Thumbnail), 1000, 300, "Cut");     // 生成缩略图(根据原图比例剪切，不变形)方法
                        
                    }
                }
                #endregion


                Hashtable hash = new Hashtable();
                hash["error"] = 0;
                hash["url"] = string.IsNullOrEmpty(webFilePath_sy) ? fileUrl : webFilePath_sy;   //如果webFilePath_syp1为空则为文件上传，否则为水印图片路径;
                hash["filename"] = imgFile.FileName;
                hash["fileType"] = fileType;
                hash["size"] = Hs(imgFile.ContentLength);
                hash["thumbnail"] = string.IsNullOrWhiteSpace(Thumbnail)?fileUrl:Thumbnail;
                Response.AddHeader("Content-Type", "text/html; charset=UTF-8");
                Response.Write(JsonMapper.ToJson(hash));
                Response.End();
            }
            #endregion
        }

        #region //定义返回错误信息HS
        private void showError(string message)
        {
            Hashtable hash = new Hashtable();
            hash["error"] = 1;
            hash["message"] = message;
            Response.AddHeader("Content-Type", "text/html; charset=UTF-8");
            Response.Write(JsonMapper.ToJson(hash));
            Response.End();
        }
        #endregion

        #region 图片位置枚举
        /// <summary>  
        /// 图片位置  
        /// </summary>  
        public enum ImagePosition
        {
            LeftTop,        //左上 
            CenterTop,    //中上
            RightTop,       //右上  
            LeftCenter,     //左中
            CenterCenter,   //居中
            RightCenter,     //右中
            LeftBottom,    //左下  
            CenterBottom,    //中下
            RigthBottom,  //右下  
        }
        #endregion

        #region  ///将文件上传到服务器上
        /// <summary>
        /// 将文件上传到服务器上
        /// </summary>
        /// <param name="saveName"></param>
        /// <param name="http"></param>
        /// <returns></returns>
        public string saveFile(string saveName, HttpPostedFile http, string type,bool Iseditor)
        {
            string phy = string.Empty;
            if (Iseditor)  //是否编辑框
            {
                switch (type)
                {
                    case "thumb":       //缩略图保存路径
                        phy = "/resource/editor/image/img_x/" + DateTime.Now.ToString("yyyyMMdd") + "/";
                        break;
                    case "img_syw":   //带水印图（文字）保存路径
                        phy = "/resource/editor/image/img_syw/" + DateTime.Now.ToString("yyyyMMdd") + "/";
                        break;
                    case "img_syp":   //带水印图（图片）保存路径
                        phy = "/resource/editor/image/img_syp/" + DateTime.Now.ToString("yyyyMMdd") + "/";
                        break;
                    default:
                        phy = "/resource/editor/image/Temp/" + DateTime.Now.ToString("yyyyMMdd") + "/";
                        break;
                }
            }
            else  //附件上传
            {
                switch (type)
                {
                    case "attach":  //批量上传文件保存路径
                        phy = "/resource/attach/image/" + DateTime.Now.ToString("yyyyMMdd") + "/";
                        break;
                    case "thumb":       //缩略图保存路径
                        phy = "/resource/attach/img_thumb/" + DateTime.Now.ToString("yyyyMMdd") + "/";
                        break;
                    case "img_syw":   //带水印图（文字）保存路径
                        phy = "/resource/attach/img_syw/" + DateTime.Now.ToString("yyyyMMdd") + "/";
                        break;
                    case "img_syp":   //带水印图（图片）保存路径
                        phy = "/resource/attach/img_syp/" + DateTime.Now.ToString("yyyyMMdd") + "/";
                        break;
                    default:
                        phy = "/resource/attach/Temp/" + DateTime.Now.ToString("yyyyMMdd") + "/";
                        break;
                }
            }
           

            string serverFile = Server.MapPath(phy);
            if (!Directory.Exists(serverFile))
            {
                Directory.CreateDirectory(serverFile);
            }

            try
            {
                http.SaveAs(serverFile + saveName);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return phy + saveName;
        }
        #endregion

        #region 容量单位换算
        /// <summary>
        /// 容量单位换算
        /// </summary>
        /// <param name="length">容量长度</param>
        /// <returns></returns>
        public string Hs(long length)
        {
            string strSize = "";
            if (length >= 0 && length < 1024)
            {
                strSize = length.ToString("F2") + "B";
            }
            else if (length >= 1024 && length < Math.Pow(1024, 2))
            {
                strSize = (length / 1024).ToString("F2") + "KB";
            }
            else if (length > Math.Pow(1024, 2) && length < Math.Pow(1024, 3))
            {
                strSize = (length / Math.Pow(1024, 2)).ToString("F2") + "MB";
            }
            else if (length > Math.Pow(1024, 3) && length < Math.Pow(1024, 4))
            {
                strSize = (length / Math.Pow(1024, 3)).ToString("F2") + "GB";
            }
            else
            {
                strSize = (length / Math.Pow(1024, 4)).ToString("F2") + "TB";
            }
            return strSize;
        }
        #endregion

        #region 生成缩略图
        /// <summary>
        /// 生成缩略图
        /// </summary>
        /// <param name="originalImagePath">源图路径（物理路径）</param>
        /// <param name="thumbnailPath">缩略图路径（物理路径）</param>
        /// <param name="width">缩略图宽度</param>
        /// <param name="height">缩略图高度</param>
        /// <param name="mode">生成缩略图的方式</param>    
        public static void MakeThumbnail(string originalImagePath, string thumbnailPath, int width, int height, string mode)
        {
            System.Drawing.Image originalImage = System.Drawing.Image.FromFile(originalImagePath);

            int towidth = width;
            int toheight = height;

            int x = 0;
            int y = 0;
            int ow = originalImage.Width;
            int oh = originalImage.Height;

            switch (mode)
            {
                case "HW"://指定高宽缩放（可能变形）   
                    toheight = height;
                    towidth = width;
                    break;
                case "W"://指定宽，高按比例                    
                    toheight = originalImage.Height * width / originalImage.Width;
                    break;
                case "H"://指定高，宽按比例
                    towidth = originalImage.Width * height / originalImage.Height;
                    break;
                case "Cut"://指定高宽裁减（不变形）                
                    if ((double)originalImage.Width / (double)originalImage.Height > (double)towidth / (double)toheight)
                    {
                        oh = originalImage.Height;
                        ow = originalImage.Height * towidth / toheight;
                        y = 0;
                        x = (originalImage.Width - ow) / 2;
                    }
                    else
                    {
                        ow = originalImage.Width;
                        oh = originalImage.Width * height / towidth;
                        x = 0;
                        y = (originalImage.Height - oh) / 2;
                    }
                    break;
                default:
                    break;
            }

            //新建一个bmp图片
            System.Drawing.Image bitmap = new System.Drawing.Bitmap(towidth, toheight);

            //新建一个画板
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap);

            //设置高质量插值法
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;

            //设置高质量,低速度呈现平滑程度
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            //清空画布并以透明背景色填充
            g.Clear(System.Drawing.Color.Transparent);

            //在指定位置并且按指定大小绘制原图片的指定部分
            g.DrawImage(originalImage, new System.Drawing.Rectangle(0, 0, towidth, toheight),
                new System.Drawing.Rectangle(x, y, ow, oh),
                System.Drawing.GraphicsUnit.Pixel);

            try
            {
                //以jpg格式保存缩略图
                bitmap.Save(thumbnailPath, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            catch (System.Exception e)
            {
                throw e;
            }
            finally
            {
                originalImage.Dispose();
                bitmap.Dispose();
                g.Dispose();
            }
        }
        #endregion  
        public void MakeThumbnail(string originalImagePath, string thumbnailPath, int width, int height, out string outthumbnailPath)
        {
            System.Drawing.Image originalImage = System.Drawing.Image.FromFile(originalImagePath);

            int towidth = width;
            int toheight = height;

            int x = 0; //缩略图在画布上的X放向起始点  
            int y = 0; //缩略图在画布上的Y放向起始点  
            int ow = originalImage.Width;
            int oh = originalImage.Height;
            int dw = 0;
            int dh = 0;

            if ((double)originalImage.Width / (double)originalImage.Height > (double)towidth / (double)toheight)
            {
                //宽比高大，以宽为准  
                dw = originalImage.Width * towidth / originalImage.Width;
                dh = originalImage.Height * toheight / originalImage.Width;
                x = 0;
                y = (toheight - dh) / 2;
            }
            else
            {
                //高比宽大，以高为准  
                dw = originalImage.Width * towidth / originalImage.Height;
                dh = originalImage.Height * toheight / originalImage.Height;
                x = (towidth - dw) / 2;
                y = 0;
            }

            //新建一个bmp图片  
            System.Drawing.Image bitmap = new System.Drawing.Bitmap(towidth, toheight);

            //新建一个画板  
            Graphics g = System.Drawing.Graphics.FromImage(bitmap);

            //设置高质量插值法  
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;

            //设置高质量,低速度呈现平滑程度  
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            //清空画布并以白色背景色填充  
            g.Clear(Color.White);

            //在指定位置并且按指定大小绘制原图片的指定部分  
            g.DrawImage(originalImage, new Rectangle(x, y, dw, dh),
             new Rectangle(0, 0, ow, oh),
             GraphicsUnit.Pixel);

            try
            {
                //以Jpeg格式保存缩略图(KB最小)  
                bitmap.Save(thumbnailPath, System.Drawing.Imaging.ImageFormat.Jpeg);
                outthumbnailPath = thumbnailPath;
            }
            catch (System.Exception e)
            {
                throw e;
            }
            finally
            {
                originalImage.Dispose();
                bitmap.Dispose();
                g.Dispose();
            }
        }

        #region       在图片上增加文字水印
        /// <summary>
        /// 在图片上增加文字水印
        /// </summary>
        /// <param name="oldpath">原服务器图片路径</param>
        /// <param name="savepath">生成的带文字水印的图片路径</param>
        protected void AddWater(string oldpath, string savepath, ImagePosition position, int alpha,string watertext, string color)
        {
            Image image = Image.FromFile(oldpath);
            Bitmap bitmap = new Bitmap(image.Width, image.Height);
            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.Clear(Color.White);
            graphics.DrawImage(image, new Rectangle(0, 0, image.Width, image.Height), 0, 0, image.Width, image.Height, GraphicsUnit.Pixel);
            Font font = new Font("arial", 18);
            SizeF ziSizeF = new SizeF();
            ziSizeF = graphics.MeasureString(watertext, font);
            float x = 0f;
            float y = 0f;
            switch (position)
            {
                case ImagePosition.LeftTop:
                    x = ziSizeF.Width / 2f+20;
                    y = 8f+20;
                    break;
                case ImagePosition.CenterTop:
                    x = image.Width / 2;
                    y = 8f + 20;
                    break;
                case ImagePosition.RightTop:
                    x = image.Width - ziSizeF.Width + 20;
                    y = 8f + 20;
                    break;
                case ImagePosition.LeftCenter:
                    x = ziSizeF.Width / 2f + 20;
                    y = image.Height / 2 - ziSizeF.Height / 2;
                    break;
                case ImagePosition.CenterCenter:
                    x = image.Width / 2;
                    y = image.Height / 2 - ziSizeF.Height / 2;
                    break;
                case ImagePosition.RightCenter:
                    x = image.Width - ziSizeF.Width + 20;
                    y = image.Height / 2 - ziSizeF.Height / 2;
                    break;
                case ImagePosition.LeftBottom:
                    x = ziSizeF.Width / 2f+20;
                    y = image.Height - ziSizeF.Height-20;
                    break;
                case ImagePosition.CenterBottom:
                    x = image.Width / 2;
                    y = image.Height - ziSizeF.Height - 20;
                    break;
                case ImagePosition.RigthBottom:
                    x = image.Width - ziSizeF.Width+20;
                    y = image.Height - ziSizeF.Height-20;
                    break;
                default:      //默认右下
                    x = image.Width - ziSizeF.Width + 20;
                    y = image.Height - ziSizeF.Height - 20;
                    break;
            }
            try
            {
                StringFormat stringFormat = new StringFormat { Alignment = StringAlignment.Center };
                SolidBrush solidBrush = new SolidBrush(Color.FromArgb(alpha, 0, 0, 0));
                graphics.DrawString(watertext, font, solidBrush, x + 1f, y + 1f, stringFormat);
                SolidBrush brush = new SolidBrush(Color.FromArgb(alpha, ColorTranslator.FromHtml(color)));
                graphics.DrawString(watertext, font, brush, x, y, stringFormat);
                solidBrush.Dispose();
                brush.Dispose();
                bitmap.Save(savepath, ImageFormat.Jpeg);
            }
            catch (Exception e)
            {

                Response.Write(e.Message);
                Response.End();
            }
            finally
            {
                bitmap.Dispose();
                image.Dispose();
            }
            
        }
        #endregion

        #region  在图片上生成图片水印
        /// <summary>
        /// 在图片上生成图片水印
        /// </summary>
        /// <param name="oldpath">原服务器图片路径</param>
        /// <param name="savepath">生成的带图片水印的图片路径</param>
        /// <param name="waterImage ">水印图片路径</param>
        protected void AddWaterPic(string oldpath, string savepath, ImagePosition position, string waterImage)
        {
            Image image = Image.FromFile(oldpath);

            int phWidth = image.Width;
            int phHeight = image.Height;
            //  
            //ImageAttributes 对象包含有关在呈现时如何操作位图和图元文件颜色的信息。  
            //         
            ImageAttributes imageAttributes = new ImageAttributes();

            Bitmap bitmap = new Bitmap(image.Width, image.Height);
            //  
            //同样，由于水印是图片，我们也需要定义一个Image来装载它  
            //  
            Image imgWatermark = new Bitmap(waterImage);

            //  
            // 获取水印图片的高度和宽度  
            //  
            int wmWidth = imgWatermark.Width;
            int wmHeight = imgWatermark.Height;

            int xPosOfWm;
            int yPosOfWm;
            switch (position)
            {
                case ImagePosition.LeftTop:
                    xPosOfWm = 10;
                    yPosOfWm = 10;
                    break;
                case ImagePosition.CenterTop:
                    xPosOfWm = (phWidth - wmWidth) / 2;
                    yPosOfWm = 10;
                    break;
                case ImagePosition.RightTop:
                    xPosOfWm = phWidth - wmWidth - 10;
                    yPosOfWm = 10;
                    break;
                case ImagePosition.LeftCenter:
                    xPosOfWm = 10;
                    yPosOfWm = (phHeight - wmHeight) / 2;
                    break;
                case ImagePosition.CenterCenter:
                    xPosOfWm = (phWidth - wmWidth) / 2;
                    yPosOfWm = (phHeight - wmHeight) / 2;
                    break;
                case ImagePosition.RightCenter:
                    xPosOfWm = phWidth - wmWidth - 10;
                    yPosOfWm = (phHeight - wmHeight) / 2;
                    break;
                case ImagePosition.LeftBottom:
                    xPosOfWm = 10;
                    yPosOfWm = phHeight - wmHeight - 10;
                    break;
                case ImagePosition.CenterBottom:
                    xPosOfWm = (phWidth - wmWidth) / 2;
                    yPosOfWm = phHeight - wmHeight - 10;
                    break;
                case ImagePosition.RigthBottom:
                    xPosOfWm = phWidth - wmWidth - 10;
                    yPosOfWm = phHeight - wmHeight - 10;
                    break;
                default:  //默认右下
                    xPosOfWm = phWidth - wmWidth - 10;
                    yPosOfWm = phHeight - wmHeight - 10;
                    break;
            }
            try
            {
                //System.Drawing.Image image1 = System.Drawing.Image.FromFile(oldpath);
                //System.Drawing.Image copyImage = System.Drawing.Image.FromFile(waterImage);
                //System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(image1);
                //g.DrawImage(copyImage, new System.Drawing.Rectangle(
                //     xPosOfWm,
                //    yPosOfWm,
                //    wmWidth,
                //    wmHeight),
                //    0,
                //    0,
                //    wmWidth,
                //    wmHeight,
                //    GraphicsUnit.Pixel,
                //    imageAttributes
                //    );
                //g.Dispose();

                //image.Save(savepath,ImageFormat.Jpeg);
                //image.Dispose();
                System.Drawing.Image copyImage = System.Drawing.Image.FromFile(waterImage);
                System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(image);
                g.DrawImage(copyImage, new System.Drawing.Rectangle(
                    xPosOfWm,
                    yPosOfWm,
                    wmWidth,
                    wmHeight),
                    0,
                    0,
                    wmWidth,
                    wmHeight,
                    GraphicsUnit.Pixel,
                    imageAttributes);
                g.Dispose();

                image.Save(savepath, ImageFormat.Jpeg);
                image.Dispose();

            }
            catch (Exception e)
            {

                Response.Write(e.Message);
                Response.End();
            }
            finally
            {
                bitmap.Dispose();
                image.Dispose();
            }
        }
        #endregion

        #region  //读取系统设置表，返回文件上传位置
        public ImagePosition ReturnImagepostion()
        {
            SystemSettingEntity entity = sda.FindEntity(new SystemSettingEntity() {SystemSettingKey= "watermarkposition" });

            ImagePosition postion;
            switch (entity.SystemSettingValue)
            {
                case "1":
                    postion = ImagePosition.LeftTop;
                    break;
                case "2":
                    postion = ImagePosition.CenterTop;
                    break;
                case "3":
                    postion = ImagePosition.RightTop;
                    break;
                case "4":
                    postion = ImagePosition.LeftCenter;
                    break;
                case "5":
                    postion = ImagePosition.CenterCenter;
                    break;
                case "6":
                    postion = ImagePosition.RightCenter;
                    break;
                case "7":
                    postion = ImagePosition.LeftBottom;
                    break;
                case "8":
                    postion = ImagePosition.CenterBottom;
                    break;
                case "9":
                    postion = ImagePosition.RigthBottom;
                    break;
                default:
                    postion = ImagePosition.RigthBottom;
                    break;
            }

            return postion;
        }
        #endregion

    }
}