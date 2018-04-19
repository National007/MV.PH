using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;
using MV.PH.Entity;
using MV.PH.WebAdmin.Inc;
using MV.PH.WebAdmin.Model.AccountDal;
using MV.PH.WebAdmin.Model.Common;

namespace MV.PH.WebAdmin.Controllers
{
    public class LoginController : ControllerBase
    {
        // GET: Login
        Accountdal account = new Accountdal();
        public ActionResult Index()
        {
            
            Session.Abandon();
            return View();
        }
        [HttpPost]
        public ActionResult Index(UserEntity entity)
        {

            if (string.IsNullOrWhiteSpace(entity.LoginName))
            {
                return AjaxMsg.AjaxMsgs(AjaxStatusEnum.Error, "用户名不为空!");
            }
            if (string.IsNullOrWhiteSpace(entity.LoginPassword))
            {
                return AjaxMsg.AjaxMsgs(AjaxStatusEnum.Error, "密码不为空!");
            }
            if (!account.Validate_UserName(entity.LoginName,entity.UserID))
            {
                return AjaxMsg.AjaxMsgs(AjaxStatusEnum.Error, "用户名不存在!");
            }


            UserEntity user = this.GlobalDataAccess.FindEntity(new UserEntity
            {
                LoginName = entity.LoginName,
                LoginPassword = Unti.GetMd5(entity.LoginPassword)
                //LoginPassword=entity.LoginPassword
            });

            if (user != null)
            {
                Session["user"] = user;
                Log.WriteLog(user.UserName, "登录", "用户名为：" + entity.LoginName + "实施登录", "成功！");

                return AjaxMsg.AjaxMsgs(AjaxStatusEnum.Success,"登录成功");
            }
            else
            {
                Log.WriteLog("无", "登录", "用户名为：" + entity.LoginName + "实施登录", "失败！");

                return AjaxMsg.AjaxMsgs(AjaxStatusEnum.Error, "登录失败!");
            }
            
        }

    }
}