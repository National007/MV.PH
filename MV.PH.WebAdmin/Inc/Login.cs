using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MV.PH.Entity;
using Lib.Data;

namespace MV.PH.WebAdmin.Inc
{
    public class Login : ActionFilterAttribute, IActionFilter
    {
        SqlDataAccess sda = new SqlDataAccess("default");
        private bool _isajax = false;
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Session["user"] == null)
            {
                ContentResult result = new ContentResult();
                if (!_isajax)
                {
                    result.Content = string.Format(@"<script type='text/javascript'>alert('访问超时，请重新登录！');parent.location.href='/Login';</script>");
                }
                filterContext.Result = result;
            }
            else
            {
                var user = HttpContext.Current.Session["user"] as UserEntity;
                string action_Name = filterContext.ActionDescriptor.ActionName;   //动作方法名
                string Controll_Name = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;  //控制器名称
                string str = "/" + Controll_Name + "/" + action_Name;

                #region  //获取用户角色
                string str_MenuPermion = string.Format(@"SELECT A.* FROM T_Role A
            				INNER JOIN T_UserInRole B ON A.RoleID=B.RoleID
            				INNER JOIN T_User C ON B.UserID=C.UserID
            				WHERE C.UserID='{0}'", user.UserID);
                List<RoleEntity> listRole = this.sda.FindEntities<RoleEntity>(str_MenuPermion);
                #endregion

                List<MenuEntity> Menu_Permision = new List<MenuEntity>();
                string RoleIDstring = string.Empty;
                if (listRole.Count > 0)
                {
                    foreach (var role_Children in listRole)
                    {
                        RoleIDstring += "'" + role_Children.RoleID + "',";
                    }
                    string sql = string.Format(@"select
                                                A.LinkAddress
                                             from
                                                T_Menu A
                                             inner join T_RoleMenuPermission B ON A.MenuID=B.MenuID
                                           WHERE 
                                                    B.RoleID in ({0})
                                                    and A.LinkAddress <> ''
                                                group by A.LinkAddress", RoleIDstring.TrimEnd(','));
                    Menu_Permision = sda.FindEntities<MenuEntity>(sql);

                }

                #region  //获取角色权限的连接地址
                string Menu_Role_Permision = string.Empty;
                if (Menu_Permision.Count > 0)
                {
                    foreach (var item in Menu_Permision)
                    {
                        Menu_Role_Permision += item.LinkAddress + ",";
                    }
                }
                #endregion

                #region  //获取菜单表的所有连接地址
                List<MenuEntity> list_Menu = this.sda.FindEntities<MenuEntity>(@"select LinkAddress from T_Menu where LinkAddress<>''");
                string str_Link = string.Empty;
                if (list_Menu.Count > 0)
                {
                    foreach (var item in list_Menu)
                    {
                        str_Link += item.LinkAddress + ",";
                    }
                }
                #endregion


                if (user.IsAdmin == Convert.ToInt32(Post.GenerAdmin))   //普通管理员
                {
                    if (str_Link.Contains(str))  //判断进入的连接地址是菜单表中的地址
                    {
                        if (!Menu_Role_Permision.Contains(str))   //角色菜单权限中没有这个连接地址权限
                        {
                            ContentResult result = new ContentResult();
                            if (!_isajax)
                            {
                                result.Content = string.Format(@"<script type='text/javascript'>alert('页面不存在或权限不够！');parent.location.href='/Login';</script>");
                            }
                            filterContext.Result = result;
                        }
                    }
                }
            }

        }


    }
}