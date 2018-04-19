using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MV.PH.WebAdmin.Model.Common
{
    public class SystemSetting_dal:ControllerBase
    {
        #region  //获取水印类型
        public string GetWatermarkType()
        {
            string sql = string.Format(@"select SystemSettingValue from T_SystemSetting where SystemSettingKey='watermarktype'");
            string str = Convert.ToString(this.GlobalDataAccess.ExecuteScalar(sql));
            return str;
        }
        #endregion


    }
}