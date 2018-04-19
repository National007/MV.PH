using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MV.PH.WebAdmin.Model.Common
{
    public class Timer_dal:ControllerBase
    {
        #region  //获取某表的数据量（根据日期查找）
        public int Get_Data(string table_Name, string startTime, string endTime)
        {
            string strWhere = string.Format(" where 1=1");
            if (!string.IsNullOrWhiteSpace(startTime) && !string.IsNullOrWhiteSpace(endTime))
            {
                strWhere += string.Format(@" and CreateDate>='{0} 00:00:00' and CreateDate<='{1} 23:59:59'",startTime,endTime);
            }
            string sql = string.Format(@"select count(0) from {0} {1}", table_Name, strWhere);
            int i = Convert.ToInt32(this.GlobalDataAccess.ExecuteScalar(sql));
            return i;
        }
        #endregion

    }
}