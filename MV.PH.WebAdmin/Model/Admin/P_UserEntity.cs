using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Lib.Data;
using Lib.Extend.Converter;
using MV.PH.Entity;

namespace MV.PH.WebAdmin.Model.Admin
{
    public class P_UserEntity:UserEntity
    {
        public P_UserEntity() : base()
        {
            this.AddField(new EntityField("RoleName", false));
        }
        public string RoleName
        {
            get { return base["RoleName"].Value.ConvertToString(); }
            set { base["RoleName"].Value = value; }
        }

    }
}