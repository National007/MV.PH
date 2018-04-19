using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Lib.Data;
using Lib.Extend.Converter;
using MV.PH.Entity;


namespace MV.PH.WebAdmin.Model.Article
{
    public class P_ArticleEntity : ArticleInfoEntity
    {
        public P_ArticleEntity() : base()
        {
            this.AddField(new EntityField("ColumnName", false));
        }
        public string ColumnName
        {
            get { return base["ColumnName"].Value.ConvertToString(); }
            set { base["ColumnName"].Value = value; }
        }

    }
}