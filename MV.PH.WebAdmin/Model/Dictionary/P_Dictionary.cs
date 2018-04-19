using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Lib.Data;
using Lib.Extend.Converter;
using MV.PH.Entity;


namespace MV.PH.WebAdmin.Model.Dictionary
{
    public class P_DictionaryEntity : DictionaryEntity
    {
        public P_DictionaryEntity() : base()
        {
            this.AddField(new EntityField("CategoryName", false));
        }
        public string CategoryName
        {
            get { return base["CategoryName"].Value.ConvertToString(); }
            set { base["CategoryName"].Value = value; }
        }

    }
}