using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MV.PH.Entity;
using MV.PH.WebAdmin.Inc;

namespace MV.PH.WebAdmin.Model.Admin
{
    public class Role_dal:ControllerBase
    {
        #region  //通过用户ID获取用户获得的角色数量
        public int GetRoleCount(string UserID)
        {
            string sql = string.Format(@"select count(0) from T_Role A
	                                            inner join T_UserInRole B ON A.RoleID=B.RoleID
	                                            WHERE B.UserID='{0}'",UserID);
            int i = Convert.ToInt32(this.GlobalDataAccess.ExecuteScalar(sql));
            return i;
        }
        #endregion
        

        #region  //通过角色ID获取用户数
        public int GetUserCont(string RoleID)
        {
            string sql = string.Format(@"select count(0) from T_Role A
	                                            inner join T_UserInRole B ON A.RoleID=B.RoleID
	                                            WHERE A.RoleID='{0}'", RoleID);
            int i = Convert.ToInt32(this.GlobalDataAccess.ExecuteScalar(sql));
            return i;
        }
        #endregion

        #region  //通过用户ID获取用户角色
        public int GetRolesByUserID(string UserID,string RoleID)
        {
            string sql = string.Format(@"select 
                                            count(0) 
                                          from 
                                            T_UserInRole 
                                          where UserID='{0}' and RoleID='{1}'",UserID,RoleID);
            int i = Convert.ToInt32(this.GlobalDataAccess.ExecuteScalar(sql));
            return i;
        }
        #endregion

    }
}