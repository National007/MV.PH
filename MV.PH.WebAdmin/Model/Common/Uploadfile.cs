using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace MV.PH.WebAdmin.Model.Common
{
    public class Uploadfile
    {
        #region  ///将文件上传到服务器上
        /// <summary>
        /// 将文件上传到服务器上
        /// </summary>
        /// <param name="saveName"></param>
        /// <param name="http"></param>
        /// <returns></returns>
        public string saveFile(string saveName, HttpPostedFileBase http, string type)
        {
            string phy = string.Empty;
            switch (type)
            {
                case "column_big":
                    phy = "/resource/Column/BigIcon/"+DateTime.Now.ToString("yyyyMMdd")+ "/";
                    break;
                case "column_small":
                    phy = "/resource/Column/SmallIcon/" + DateTime.Now.ToString("yyyyMMdd") + "/";
                    break;
                case "video":
                    phy = "/resource/attach/Video/" + DateTime.Now.ToString("yyyyMMdd") + "/";
                    break;
                case "face":
                    phy = "/resource/attach/Face/" + DateTime.Now.ToString("yyyyMMdd") + "/";
                    break;
                case "waterPic":
                    phy = "/images/icon/";
                    break;
                default:
                    phy = "/resource/Temp/" + DateTime.Now.Year + "/" + DateTime.Now.Month + "/" + DateTime.Now.Day + "/";
                    break;
            }

            string serverFile = HttpContext.Current.Server.MapPath(phy);
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

        #region  //容量单位换算
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

    }
}