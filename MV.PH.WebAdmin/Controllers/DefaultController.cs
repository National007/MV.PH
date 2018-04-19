using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;
using MV.PH.Entity;
using MV.PH.WebAdmin.Inc;

namespace MV.PH.WebAdmin.Controllers
{
    public class DefaultController : ControllerBase
    {
        // GET: Default
        //[Login]
        public ActionResult Index()
        {
            #region  //用户角色
            var user = Session["user"] as UserEntity;
            string str = string.Format(@"SELECT A.* FROM T_Role A
																INNER JOIN T_UserInRole B ON A.RoleID=B.RoleID
																INNER JOIN T_User C ON B.UserID=C.UserID
																WHERE C.UserID='{0}'", user.UserID);
            List<RoleEntity> entity = this.GlobalDataAccess.FindEntities<RoleEntity>(str);
            ViewData["Role"] = entity;
            #endregion

            List<MenuEntity> list = new List<MenuEntity>();
            if (user.IsAdmin == Convert.ToInt32(Post.SuperAdmin))   //超管
            {
                #region //父菜单列
                string sql = "select MenuID,MenuName,MenuBigIcon from T_Menu where MenuParentID is null and IsEnable=1 order by SortNumber";
                list = this.GlobalDataAccess.FindEntities<MenuEntity>(sql);
                #endregion
            }
            else
            {
                #region //父菜单列及角色权限
                string RoleIDstring = string.Empty;
                if (entity.Count > 0)
                {
                    foreach (var item in entity)
                    {
                        RoleIDstring += "'" + item.RoleID + "',";
                    }
                    string sql = string.Format(@"select 
                                                A.MenuID,A.MenuName,A.MenuBigIcon,A.SortNumber
                                             from 
                                                T_Menu A
	                                            inner join T_RoleMenuPermission B ON A.MenuID=B.MenuID
	                                          WHERE B.RoleID in ({0}) and MenuParentID IS NULL
                                                group by A.MenuName,A.MenuID,A.MenuBigIcon,A.SortNumber
                                                order by A.SortNumber", RoleIDstring.TrimEnd(','));
                    list = this.GlobalDataAccess.FindEntities<MenuEntity>(sql);
                    
                }
                #endregion
                
            }
            return View(list);
        }
        //[Login]
        public ActionResult welcome()
        {
            return View();
        }

        public ActionResult welcome1()
        {
            return View();
        }

        public ActionResult Exit()
        {
            Session.Abandon();
            return RedirectToAction("Index","Login");
        }

    }
}