using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MV.PH.Entity;
using MV.PH.WebAdmin.Inc;

namespace MV.PH.WebAdmin.Model.AccountDal
{
    public class Accountdal:ControllerBase
    {
        #region   修改用户信息操作验证
        /// <summary>
        /// 登陆名是否存在
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public bool Validate_UserName(string LoginName, string UserID)
        {

            string sql = "select count(1) from T_User where LoginName ='" + LoginName + "'";
            if (UserID!=null&&UserID!="")
            {
                UserEntity user = this.GlobalDataAccess.FindEntity<UserEntity>(new UserEntity() { UserID = UserID });
                if (LoginName == user.LoginName)
                {
                    return false;
                }
            }
            int subcount = Convert.ToInt32(this.GlobalDataAccess.ExecuteScalar(sql));
            if (subcount > 0)  //用户名已存在
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        /// <summary>
        /// 判断旧密码输入是否正确
        /// </summary>
        /// <param name="LoginPassword">旧密码</param>
        /// <param name="UserID">登录用户ID</param>
        /// <returns></returns>
        #region  //修改密码 判断旧密码输入是否正确
        [Login]
        public bool Validate_Password(string LoginPassword,string UserID)
        {
            
            string sql = string.Format(@"select LoginPassword from T_User WHERE UserID='{0}'", UserID);
            string pwd = Convert.ToString(this.GlobalDataAccess.ExecuteScalar(sql)); //旧密码
            if (pwd!=Unti.GetMd5(LoginPassword))   //旧密码输入错误
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

    }
}