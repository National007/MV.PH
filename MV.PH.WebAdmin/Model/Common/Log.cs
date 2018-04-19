using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using Lib.Tool;
using MV.PH.WebAdmin.Model.Common;
using System.IO;
using System.Data.Common;

namespace MV.PH.WebAdmin.Model.Common
{
    public static class Log
    {

        private static PublicLog db = null;
        static Log()
        {
            string lconnstr = ConfigurationManager.ConnectionStrings["default"].ConnectionString; //Key值
            if (lconnstr != null)
            {
                db = new PublicLog(lconnstr, PublicLog.DbProviderType.SqlServer);
            }
        }
        /// <summary>
        /// 向文件中写日志
        /// </summary>
        /// <param name="LogStatus">内容</param>
        /// <param name="filename">文件名</param>
        public static void WriteLog(string UserName = "", string LogCategory = "", string LogDescription = "", string LogTitle = "")
        {
            HttpContext context = System.Web.HttpContext.Current;

            string ip = string.Empty;

            if (context != null)
            {
                if (context.Request.ServerVariables["HTTP_VIA"] != null) // using proxy
                {
                    ip = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString(); // Return real client IP.
                }
                else// not using proxy or can't get the Client IP
                {
                    ip = context.Request.ServerVariables["REMOTE_ADDR"].ToString(); //While it can't get the Client IP, it will return proxy IP.
                }

                if (string.IsNullOrEmpty(ip))
                {
                    ip = context.Request.UserHostAddress;
                }
            }

            string LogId = Tools.NewID;

            if (LogCategory.Length > 60) { LogCategory = LogCategory.Substring(0, 60); }
            if (LogTitle.Length > 255) { LogTitle = LogTitle.Substring(0, 255); }
            if (LogDescription.Length > 3000) { LogDescription = LogDescription.Substring(0, 3000); }
            string sql = string.Format(@"insert into T_SystemLog values(@SystemLogID,@LogCategory,@LogTitle,@LogContent,@UserName,@LogIP,@CreateDate)");
            IList<DbParameter> idp = new List<DbParameter>();
            idp.Add(db.CreateDbParameter("@SystemLogID", LogId));
            idp.Add(db.CreateDbParameter("@LogCategory", LogCategory));
            idp.Add(db.CreateDbParameter("@LogTitle", LogTitle));
            idp.Add(db.CreateDbParameter("@LogContent", LogDescription));
            idp.Add(db.CreateDbParameter("@UserName", UserName));
            idp.Add(db.CreateDbParameter("@LogIP", ip));
            idp.Add(db.CreateDbParameter("@CreateDate", DateTime.Now));
            try
            {
                db.ExecuteNonQuery(sql, idp);
            }
            catch (Exception ex)
            {
            }
        }


    }
}