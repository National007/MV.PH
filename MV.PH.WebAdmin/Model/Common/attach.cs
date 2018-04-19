using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MV.PH.Entity;
using MV.PH.WebAdmin.Inc;

namespace MV.PH.WebAdmin.Model.Common
{
    public class attach:ControllerBase
    {
        public string ReturnVideoFile(string ArticleInfoID)
        {
            string sql = string.Format(@"select 
                                            top 1 FileName
                                                from 
                                            T_ArticleAttachment 
                                                where 
                                            ArticleInfoID='{0}'", ArticleInfoID);
            string str = Convert.ToString(this.GlobalDataAccess.ExecuteScalar(sql));
            return str;
        }
    }
}