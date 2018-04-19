<%@ WebHandler Language="C#" Class="Upload" %>

/**
 * KindEditor ASP.NET
 * 上传管理
 */

using System;
using System.Collections;
using System.Web;
using System.IO;
using System.Globalization;
using LitJson;

public class Upload : IHttpHandler
{
    private HttpContext context;

    public void ProcessRequest(HttpContext context)
    {
        //String aspxUrl = context.Request.Path.Substring(0, context.Request.Path.LastIndexOf("/") + 1);

        //文件保存目录路径
        String savePath = "/resource/editor/";

        //文件保存目录URL
        String saveUrl = "/resource/editor/";

        //定义允许上传的文件扩展名
        Hashtable extTable = new Hashtable();
        extTable.Add("image", "gif,jpg,jpeg,png,bmp");
        extTable.Add("flash", "swf,flv");
        extTable.Add("media", "swf,flv,mp3,wav,wma,wmv,mid,avi,mpg,asf,rm,rmvb");
        extTable.Add("file", "doc,docx,xls,xlsx,ppt,htm,html,txt,zip,rar,gz,bz2");

        //最大文件大小为1GB
        int maxSize = 1024*1024*1024;
        this.context = context;

        HttpPostedFile imgFile = context.Request.Files["imgFile"];
        if (imgFile == null)
        {
            showError("请选择文件。");
        }

        String dirPath = context.Server.MapPath(savePath);
        if (!Directory.Exists(dirPath))
        {
            //showError("上传目录不存在。");
            Directory.CreateDirectory(dirPath);
        }

        String dirName = context.Request.QueryString["dir"];
        if (String.IsNullOrEmpty(dirName))
        {
            dirName = "image";
        }
        if (!extTable.ContainsKey(dirName))
        {
            showError("目录名不正确。");
        }

        String fileName = imgFile.FileName;
        String fileExt = Path.GetExtension(fileName).ToLower();

        if (imgFile.InputStream == null || imgFile.InputStream.Length > maxSize)
        {
            showError("上传文件大小超过限制。");
        }

        if (String.IsNullOrEmpty(fileExt) || Array.IndexOf(((String)extTable[dirName]).Split(','), fileExt.Substring(1).ToLower()) == -1)
        {
            showError("上传文件扩展名是不允许的扩展名。\n只允许" + ((String)extTable[dirName]) + "格式。");
        }

        //创建文件夹
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
        String filePath = dirPath + newFileName;

        imgFile.SaveAs(filePath);

        String fileUrl = saveUrl + newFileName;

        Hashtable hash = new Hashtable();
        hash["error"] = 0;
        hash["url"] = fileUrl;
        hash["filename"] = imgFile.FileName;
        hash["fileType"] = Path.GetExtension(imgFile.FileName).Substring(Path.GetExtension(imgFile.FileName).LastIndexOf(".") + 1);
        hash["size"] = Hs(imgFile.ContentLength);
        context.Response.AddHeader("Content-Type", "text/html; charset=UTF-8");
        context.Response.Write(JsonMapper.ToJson(hash));
        context.Response.End();
    }

    private void showError(string message)
    {
        Hashtable hash = new Hashtable();
        hash["error"] = 1;
        hash["message"] = message;
        context.Response.AddHeader("Content-Type", "text/html; charset=UTF-8");
        context.Response.Write(JsonMapper.ToJson(hash));
        context.Response.End();
    }
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

    public bool IsReusable
    {
        get
        {
            return true;
        }
    }
}