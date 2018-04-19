using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MV.PH.WebAdmin.Model.Common
{
    public class UserFeedback_dal:ControllerBase
    {
        #region //获取用户反馈信息（未读状态）
        public int GetUserFeedbackCount()
        {
            string sql = string.Format(@"select count(0) from T_UserFeedback where ReadStatus='未读'");
            int i = Convert.ToInt32(this.GlobalDataAccess.ExecuteScalar(sql));
            return i;
        }
        #endregion
    }
}