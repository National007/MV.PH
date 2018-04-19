using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MV.PH.Entity;
using MV.PH.WebAdmin.Model.PageHelp;
using MV.PH.WebAdmin.Model.Admin;
using Lib.Tool;
using MV.PH.WebAdmin.Model.AccountDal;
using MV.PH.WebAdmin.Model.Common;
using MV.PH.WebAdmin.Inc;

namespace MV.PH.WebAdmin.Controllers
{
    public class AdminController : ControllerBase
    {
        Accountdal dal = new Accountdal();
        // GET: Admin
        #region   //判断用户名是否存在
        [HttpPost]
        public ActionResult RegistName()
        {

            string LoginName = Request["param"];
            string UserID = Request.QueryString["UserID"];

            if (string.IsNullOrWhiteSpace(LoginName))
            {
                return AjaxMsg.AjaxInfo("用户名不为空","n");
                //var s = new { info = "用户名不为空", status = "n" };
                //return Json(s);
            }
            if (dal.Validate_UserName(LoginName, UserID))
            {
                return AjaxMsg.AjaxInfo("用户名已存在!", "n");
                //var s = new { info = "用户名已存在!", status = "n" };
                //return Json(s);
            }
            return AjaxMsg.AjaxInfo("","y");
            //var v = new { info = "", status = "y" };
            //return Json(v);
        }
        #endregion

        #region  //判断旧密码输入是否正确
        [Login]
        public ActionResult GetPassword()
        {
            var Users = Session["user"] as UserEntity;
            string Pwd = Request["param"];
            if (string.IsNullOrWhiteSpace(Pwd))
            {
                return  AjaxMsg.AjaxInfo("旧密码不为空", "n");
            }
            if (dal.Validate_Password(Pwd,Users.UserID))  //旧密码输入正确
            {
                return AjaxMsg.AjaxInfo("", "y");
            }
            else
            {
                return AjaxMsg.AjaxInfo("旧密码输入错误!", "n");
            }

        }
        #endregion
        
        #region  //密码修改
        [Login]
        public ActionResult ChangePwd()
        {
            return View();
        }
        [Login]
        public ActionResult UpdatePwd()
        {
            UserEntity entity = Session["user"] as UserEntity;
            string sql = string.Format(@"update T_User set LoginPassword='{0}' where UserID='{1}'",Unti.GetMd5(Tools.R("enterPwd")),entity.UserID);
            int i = this.GlobalDataAccess.ExecuteNonQuery(sql);
            if (i > 0)
            {
                return AjaxMsg.AjaxInfo("密码修改成功,请重新登录","y");
            }
            else
            {
                return AjaxMsg.AjaxInfo("密码修改失败!","n");
            }
        }
        #endregion
        [Login]
        #region  //加入新角色页
        public ActionResult Role(string UserID="",int page=1)
        {
            if (string.IsNullOrWhiteSpace(UserID))
            {
                return AjaxMsg.AjaxMsgs(AjaxStatusEnum.Error,"参数错误!");
            }
            List<UserInRoleEntity> entity = this.GlobalDataAccess.FindEntities(new UserInRoleEntity() {UserID=UserID });

           
            string strWhere = string.Format(@" where 1=1");
            if (entity.Count>0)
            {
                string str = string.Empty;
                foreach (var item in entity)
                {
                    str += "'" + item.RoleID + "',";
                }
                strWhere = string.Format(@" where RoleID NOT IN ({0})", str.TrimEnd(','));
            }
            
            ViewBag.UserID = UserID;

            string sqlcount = string.Format(@"select count(0) from T_Role
                                                    {0}
                                                     ",strWhere);
            int RecordCount = Convert.ToInt32(this.GlobalDataAccess.ExecuteScalar(sqlcount));

            Lib.UI.PageBase pagebase = new Lib.UI.PageBase();
            int PageSize = 10;
            pagebase.CurrentPageIndex = page;

            string pageSql = string.Format(@"select * from 
		                                            (
			                                            select *,Row_Number()over(order by RoleID) RowNo from T_Role
				                                             {2}
		                                            )tb where RowNo>{0} and RowNo<{1}", ((page - 1) * PageSize), (page * PageSize),strWhere);
            List<RoleEntity> list = this.GlobalDataAccess.FindEntities<RoleEntity>(pageSql);
            PageListModel<RoleEntity> RoleList = new PageListModel<RoleEntity>(list, page, PageSize, RecordCount);
            
            return View(RoleList);
        }
        #endregion
        
        [Login]
        #region  //为指定用户加入新角色
        [HttpPost]
        public ActionResult Role()
        {
            var Users = Session["user"] as UserEntity;
            this.GlobalDataAccess.BeginTransaction();
            try
            {
                

                #region  //添加用户角色
                UserInRoleEntity roleEntity = new UserInRoleEntity();
                roleEntity.UserID = Request["UserID"];
                string RoleID = Request["RoleIDString"].TrimEnd(',').Trim();
                if (!string.IsNullOrEmpty(RoleID))
                {
                    foreach (string item in RoleID.Split(','))
                    {
                        roleEntity.RoleID = item;
                        this.GlobalDataAccess.AddNew(roleEntity);
                    }
                }
                
                #endregion

                this.GlobalDataAccess.CommitTransaction();
                Log.WriteLog(Users.UserName, "添加", "用户角色列表》用户角色添加》", "成功！");
                return AjaxMsg.AjaxInfo("添加成功!", "y");

            }
            catch (Exception ex)
            {
                this.GlobalDataAccess.RollbackTransaction();
                Log.WriteLog(Users.UserName, "添加", "管理员列表》用户添加》程序错误：" + ex.Message, "程序错误！");
                return AjaxMsg.AjaxInfo(ex.Message, "n");
            }
        }
        #endregion

        [Login]
        #region // 指定角色的用户列表
        public ActionResult Role_AdminList(int page=1,string RoleID="")
        {
            #region //根据角色ID获取角色信息表
            RoleEntity entity = this.GlobalDataAccess.FindEntity(new RoleEntity() { RoleID = RoleID });
            ViewData["RoleEntity"] = entity;
            #endregion

            string strWhere = string.Format(@" where B.RoleID='{0}'", RoleID);
            string sqlcount = string.Format(@"select COUNT(0) from T_User A
													inner join T_UserInRole B ON A.UserID=B.UserID
	                                                {0}", strWhere);
            int RecordCount = Convert.ToInt32(this.GlobalDataAccess.ExecuteScalar(sqlcount));

            Lib.UI.PageBase pagebase = new Lib.UI.PageBase();
            int PageSize = 10;
            pagebase.CurrentPageIndex = page;

            string pageSql = string.Format(@"select * from 
		                                            (
			                                            select A.*,Row_Number()over(order by A.UserID) RowNo from 
			                                            (
				                                            T_User A
				                                            inner join T_UserInRole B ON A.UserID=B.UserID
			                                            )
				                                         {2}
		                                            )tb where RowNo>{0} and RowNo<={1}", ((page - 1) * PageSize), (page * PageSize), strWhere);
            List<UserEntity> list = this.GlobalDataAccess.FindEntities<UserEntity>(pageSql);
            PageListModel<UserEntity> UserList = new PageListModel<UserEntity>(list, page, PageSize, RecordCount);
            return View(UserList);
        }
        #endregion

        [Login]
        #region  //删除指定角色权限的用户
        public ActionResult Delete_Role_User(string RoleID, string UserIDString)
        {
            var Users = Session["user"] as UserEntity;
            int i = 0;
            this.GlobalDataAccess.BeginTransaction();
            try
            {

                string UserID = UserIDString.ToString().TrimEnd(',').Trim();
                foreach (string item in UserID.Split(','))
                {
                    i++;
                    this.GlobalDataAccess.Delete(new UserInRoleEntity() { UserID = item, RoleID = RoleID });  //删除角色权限的用户
                }
                this.GlobalDataAccess.CommitTransaction();
                Log.WriteLog(Users.UserName, "删除", "角色用户》角色用户数量删除》已删除" + i + "条数据", "成功！");
                return AjaxMsg.AjaxMsgs(AjaxStatusEnum.Success, "删除成功！");
            }
            catch (Exception ex)
            {
                this.GlobalDataAccess.EndTransaction();
                Log.WriteLog(Users.UserName, "删除", "角色用户》角色用户数量删除》删除出现程序错误:"+ex.Message, "程序错误！");
                return AjaxMsg.AjaxMsgs(AjaxStatusEnum.Error, ex.Message);
            }
        }
        #endregion
        
        [Login]
        #region  //指定用户的角色列表
        public ActionResult Admin_RoleList(int page=1,string UserID="")
        {
            #region //根据用户ID获取用户信息表
            UserEntity entity = this.GlobalDataAccess.FindEntity(new UserEntity() { UserID = UserID });
            ViewData["UserEntity"] = entity;
            #endregion


            string strWhere =string.Format(@" WHERE B.UserID='{0}'",UserID);
            string sqlcount = string.Format(@"select count(0) from T_Role A
	                                                inner join T_UserInRole B ON A.RoleID=B.RoleID
	                                                {0}", strWhere);
            int RecordCount = Convert.ToInt32(this.GlobalDataAccess.ExecuteScalar(sqlcount));

            Lib.UI.PageBase pagebase = new Lib.UI.PageBase();
            int PageSize = 10;
            pagebase.CurrentPageIndex = page;

            string pageSql = string.Format(@"select * from 
		                                            (
			                                            select A.*,Row_Number()over(order by A.RoleID) RowNo from 
			                                            (
				                                            T_Role A
				                                            inner join T_UserInRole B ON A.RoleID=B.RoleID
			                                            )
				                                            {2}
		                                            )tb where RowNo>{0} and RowNo<{1}", ((page - 1) * PageSize), (page * PageSize), strWhere);
            List<RoleEntity> list = this.GlobalDataAccess.FindEntities<RoleEntity>(pageSql);
            PageListModel<RoleEntity> RoleList = new PageListModel<RoleEntity>(list, page, PageSize, RecordCount);
            return View(RoleList);
        }
        #endregion

        [Login]
        #region  //删除指定用户的角色权限
        public ActionResult Delete_UserRole(string UserID,string RoleIDString)
        {
            var Users = Session["user"] as UserEntity;
            int i = 0;
            this.GlobalDataAccess.BeginTransaction();
            try
            {

                string RoleID = RoleIDString.ToString().TrimEnd(',').Trim();
                foreach (string item in RoleID.Split(','))
                {
                    i++;
                    this.GlobalDataAccess.Delete(new UserInRoleEntity() {UserID=UserID,RoleID=item });  //删除用户角色
                }
                this.GlobalDataAccess.CommitTransaction();
                Log.WriteLog(Users.UserName, "删除", "用户角色》用户角色数量删除》已删除" + i + "条数据", "成功！");
                return AjaxMsg.AjaxMsgs(AjaxStatusEnum.Success, "删除成功！");
            }
            catch (Exception ex)
            {
                this.GlobalDataAccess.EndTransaction();
                Log.WriteLog(Users.UserName, "删除", "用户角色》用户角色数量删除》删除出现程序错误:" + ex.Message, "程序错误！");
                return AjaxMsg.AjaxMsgs(AjaxStatusEnum.Error, ex.Message);
            }
        }
        #endregion

        [Login]
        #region   //管理员列表
        /// <summary>
        /// 管理员列表
        /// </summary>
        /// <returns></returns>

        public ActionResult AdminManager(int page = 1, string UserName = "", string LoginName = "")
        {
            var user = Session["user"] as UserEntity;
            string strWhere = " WHERE UserID<>'" + user.UserID + "'";

            if (user.IsAdmin == Convert.ToInt32(Post.GenerAdmin))  //普通管理员
            {
                strWhere += string.Format(@" AND IsAdmin <> 1");
            }

            if (!string.IsNullOrWhiteSpace(UserName))
            {
                UserName = UserName.Replace("'", "");
                strWhere += string.Format(@" AND UserName like '%{0}%'", UserName);
                ViewBag.UserName = UserName;
            }
            if (!string.IsNullOrWhiteSpace(LoginName))
            {
                LoginName = LoginName.Replace("'", "");
                strWhere += string.Format(@" AND LoginName like '%{0}%'", LoginName);
                ViewBag.LoginName = LoginName;
            }

            string sqlcount = string.Format(@"select count(0) from T_User {0}", strWhere);
            int RecordCount = Convert.ToInt32(this.GlobalDataAccess.ExecuteScalar(sqlcount).ToString());

            Lib.UI.PageBase pagebase = new Lib.UI.PageBase();
            int PageSize = 10;
            pagebase.CurrentPageIndex = page;

            string pageSql = string.Format(@"select * from 
	                                                (
		                                                select *, ROW_NUMBER()over(order by UserName)as RowNo 
                                                            from
			                                                    T_User
                                                        {2}
	                                                )tb where RowNo>{0} and RowNo<={1}", ((page - 1) * PageSize), (page * PageSize), strWhere);
            List<UserEntity> list = this.GlobalDataAccess.FindEntities<UserEntity>(pageSql);
            PageListModel<UserEntity> userList = new PageListModel<UserEntity>(list, page, PageSize, RecordCount);
            return View(userList);
        }
        #endregion

        [Login]
        #region  //管理员添加、修改
        /// <summary>
        /// 管理员添加
        /// </summary>
        /// <returns></returns>
        public ActionResult Add()
        {
            //string str = string.Format(@"select * from T_role order by RoleID");
            //List<RoleEntity> role = this.GlobalDataAccess.FindEntities<RoleEntity>(str);
            //ViewData["Role"] = role;
            return View();  
        }

        [Login]
        [HttpPost]
        public ActionResult Add(UserEntity User)
        {
            var Users = Session["user"] as UserEntity;
            this.GlobalDataAccess.BeginTransaction();
            try
            {
                #region  //添加用户
                User.UserID = Tools.NewID;
                User.LoginPassword = Unti.GetMd5(User.LoginPassword);
                User.IsAdmin = 0;
                this.GlobalDataAccess.AddNew(User);
                #endregion

                //#region  //添加用户角色
                //UserInRoleEntity roleEntity = new UserInRoleEntity();
                //roleEntity.UserID = User.UserID;

                //string RoleID = Request["RoleIDString"].TrimEnd(',').Trim();
                //foreach (string item in RoleID.Split(','))
                //{
                //    roleEntity.RoleID = item;
                //    this.GlobalDataAccess.AddNew(roleEntity);
                //}
                //#endregion

                this.GlobalDataAccess.CommitTransaction();
                Log.WriteLog(Users.UserName, "添加", "管理员列表》用户添加》添加用户：" + User.LoginName, "成功！");
                return AjaxMsg.AjaxInfo("添加成功!", "y");
                
            }
            catch (Exception ex)
            {
                this.GlobalDataAccess.RollbackTransaction();
                Log.WriteLog(Users.UserName, "添加", "管理员列表》用户添加》程序错误：" + ex.Message, "程序错误！");
                return AjaxMsg.AjaxInfo(ex.Message,"n");
            }
        }

        [Login]
        public ActionResult Edit(string UserID)
        {

            //string str = string.Format(@"select * from T_role order by RoleID");
            //List<RoleEntity> role = this.GlobalDataAccess.FindEntities<RoleEntity>(str);
            //ViewData["Role"] = role;

            if (string.IsNullOrWhiteSpace(UserID))
            {
                return AjaxMsg.AjaxMsgs(AjaxStatusEnum.Error,"参数错误!");
            }
            string sql = string.Format(@"select * from T_User
                                                    where UserID='{0}'", UserID);
            UserEntity entity = this.GlobalDataAccess.FindEntity<UserEntity>(sql);

            if (entity == null)
            {
                return AjaxMsg.AjaxMsgs(AjaxStatusEnum.Error, "未找到该用户");
            }
            return View(entity);
        }

        [Login]
        [HttpPost]
        public ActionResult Edit(UserEntity User)
        {
            if (string.IsNullOrWhiteSpace(User.UserID))
            {
                return AjaxMsg.AjaxMsgs(AjaxStatusEnum.Error,"参数错误");
            }
            var Users = Session["user"] as UserEntity;
            this.GlobalDataAccess.BeginTransaction();
            try
            {
                #region //修改用户信息
                if (!string.IsNullOrWhiteSpace(User.LoginPassword))
                {
                    User.LoginPassword = Unti.GetMd5(User.LoginPassword);
                }
                
                this.GlobalDataAccess.Update(User);
                #endregion

                //#region  //删除用户角色
                //this.GlobalDataAccess.Delete(new UserInRoleEntity() { UserID=User.UserID});
                //#endregion

                //#region  //添加用户角色
                //UserInRoleEntity roleEntity = new UserInRoleEntity();
                //roleEntity.UserID = User.UserID;

                //string RoleID = Request["RoleIDString"].TrimEnd(',').Trim();
                //foreach (string item in RoleID.Split(','))
                //{
                //    roleEntity.RoleID = item;
                //    this.GlobalDataAccess.AddNew(roleEntity);
                //}
                //#endregion

                this.GlobalDataAccess.CommitTransaction();
                Log.WriteLog(Users.UserName, "修改", "管理员列表》用户编辑》修改用户：" + User.LoginName, "成功！");
                return AjaxMsg.AjaxInfo("修改成功", "y");

            }
            catch (Exception ex)
            {
                this.GlobalDataAccess.RollbackTransaction();
                Log.WriteLog(Users.UserName, "修改", "管理员列表》用户编辑》程序错误：" + ex.Message, "程序错误！");
                return AjaxMsg.AjaxInfo(ex.Message, "n");
            }

        }

        #endregion

        [Login]
        #region  //管理员删除、批量删除
        public ActionResult DeleteUser(string UserIDstring)
        {
            var Users = Session["user"] as UserEntity;
            int i = 0;
            this.GlobalDataAccess.BeginTransaction();
            try
            {
                
                string UserID = UserIDstring.ToString().TrimEnd(',').Trim();
                foreach (string item in UserID.Split(','))
                {
                    i++;
                    this.GlobalDataAccess.Delete(new UserInRoleEntity() { UserID = item });
                    this.GlobalDataAccess.Delete(new UserEntity() { UserID = item });
                }
                this.GlobalDataAccess.CommitTransaction();
                Log.WriteLog(Users.UserName, "删除", "管理员列表》管理员删除》已删除"+i+"条数据", "成功！");
                return AjaxMsg.AjaxMsgs(AjaxStatusEnum.Success, "删除成功！");
            }
            catch (Exception ex)
            {
                this.GlobalDataAccess.EndTransaction();
                Log.WriteLog(Users.UserName, "删除", "管理员列表》管理员删除》已删除" + i + "条数据", "程序错误！");
                return AjaxMsg.AjaxMsgs(AjaxStatusEnum.Error, ex.Message);
            }
        }
        #endregion

        [Login]
        #region  //角色管理列表
        /// <summary>
        /// 角色管理列表
        /// </summary>
        /// <returns></returns>
        public ActionResult RoleManager(int page=1,string RoleName="")
        {
            string strWhere = string.Format(@" where 1=1");

            if (!string.IsNullOrWhiteSpace(RoleName))
            {
                RoleName = RoleName.Replace("'", "''");
                strWhere += string.Format(@" AND RoleName like '%{0}%'", RoleName);
                ViewBag.RoleName = RoleName;
            }

            string sqlcount = string.Format(@"select count(0) from T_Role {0}",strWhere);
            int RecordCount = Convert.ToInt32(this.GlobalDataAccess.ExecuteScalar(sqlcount));

            Lib.UI.PageBase pagebase = new Lib.UI.PageBase();
            int PageSize = 10;
            pagebase.CurrentPageIndex = page;

            string pageSql = string.Format(@"select * from 
		                                            (
			                                            select *,Row_Number()over(order by RoleID) RowNo 
			                                            from 
				                                            T_Role
                                                           {2}
		                                            )tb where RowNo>{0} and RowNo<={1}", ((page - 1) * PageSize), (page * PageSize), strWhere);
            List<RoleEntity> list = this.GlobalDataAccess.FindEntities<RoleEntity>(pageSql);
            PageListModel<RoleEntity> RoleList = new PageListModel<RoleEntity>(list, page, PageSize, RecordCount);
            return View(RoleList);
        }
        #endregion

        [Login]
        #region  //角色添加
        /// <summary>
        /// 角色添加页面
        /// </summary>
        /// <returns></returns>
        public ActionResult RoleAdd()
        {
            return View();
        }

        [HttpPost]
        [Login]
        public ActionResult RoleAdd(RoleEntity Role)
        {
            var Users = Session["user"] as UserEntity;
            if (string.IsNullOrWhiteSpace(Role.RoleName))
            {
                return AjaxMsg.AjaxMsgs(AjaxStatusEnum.Error, "角色名称不为空!");
            }

            this.GlobalDataAccess.BeginTransaction();
            try
            {

                #region  //添加功能
                Role.RoleID = Tools.NewID;
                this.GlobalDataAccess.AddNew(Role);
                #endregion
                
                this.GlobalDataAccess.CommitTransaction();
                Log.WriteLog(Users.UserName, "添加", "管理员角色列表》角色添加》添加角色：" + Role.RoleName, "成功！");
                return AjaxMsg.AjaxInfo("添加成功","y");

            }
            catch (Exception ex)
            {
                this.GlobalDataAccess.EndTransaction();
                Log.WriteLog(Users.UserName, "添加", "管理员角色列表》角色添加》添加角色出现程序错误：" + ex.Message, "程序错误！");
                return AjaxMsg.AjaxInfo(ex.Message,"n");
            }
           
        }
        #endregion

        [Login]
        #region  //角色修改
        public ActionResult RoleEdit(string RoleID)
        {
            
            if (string.IsNullOrWhiteSpace(RoleID))
            {
                return AjaxMsg.AjaxMsgs(AjaxStatusEnum.Error, "参数错误");
            }
            RoleEntity entity = this.GlobalDataAccess.FindEntity(new RoleEntity { RoleID = RoleID });

            if (entity == null)
            {
                return AjaxMsg.AjaxMsgs(AjaxStatusEnum.Error, "未找到该角色");
            }

            return View(entity);
        }
        [Login]
        [HttpPost]
        public ActionResult RoleEdit(RoleEntity Role)
        {
            var Users = Session["user"] as UserEntity;
            if (string.IsNullOrWhiteSpace(Role.RoleName))
            {
                return AjaxMsg.AjaxMsgs(AjaxStatusEnum.Error, "角色名称不为空!");
            }

            if (string.IsNullOrWhiteSpace(Role.RoleID))  //修改角色
            {
                return AjaxMsg.AjaxMsgs(AjaxStatusEnum.Error, "参数错误!");
            }

            this.GlobalDataAccess.BeginTransaction();
            try
            {
                #region //修改功能
                this.GlobalDataAccess.Update(Role);
                #endregion
                

                this.GlobalDataAccess.CommitTransaction();
                Log.WriteLog(Users.UserName, "修改", "管理员角色列表》角色修改》修改角色：" + Role.RoleName, "成功！");
                return AjaxMsg.AjaxInfo("修改成功", "y");

            }
            catch (Exception ex)
            {
                this.GlobalDataAccess.EndTransaction();
                Log.WriteLog(Users.UserName, "修改", "管理员角色列表》角色修改》修改角色出现程序错误：" + ex.Message, "程序错误！");
                return AjaxMsg.AjaxInfo(ex.Message, "n");
            }

        }
        #endregion

        [Login]
        #region  //角色删除、批量删除

        public ActionResult DeleteRole(string RoleIDString)
        {
            var Users = Session["user"] as UserEntity;
            this.GlobalDataAccess.BeginTransaction();
            try
            {
                int i = 0;
                string RoleID = RoleIDString.ToString().TrimEnd(',').Trim();
                foreach (string item in RoleID.Split(','))
                {
                    i++;
                    this.GlobalDataAccess.Delete(new UserInRoleEntity() { RoleID = item });   //用户角色表
                    this.GlobalDataAccess.Delete(new RoleMenuPermissionEntity() {RoleID=item });  //角色菜单权限表
                    this.GlobalDataAccess.Delete(new RoleColumnPermissionEntity() {RoleID=item });  //角色栏目权限表
                    this.GlobalDataAccess.Delete(new RoleEntity() { RoleID = item });
                }
                this.GlobalDataAccess.CommitTransaction();
                Log.WriteLog(Users.UserName, "删除", "管理员角色列表》角色删除》已删除"+i+"条数据", "成功！");
                return AjaxMsg.AjaxMsgs(AjaxStatusEnum.Success, "删除成功！");
            }
            catch (Exception ex)
            {
                this.GlobalDataAccess.EndTransaction();
                Log.WriteLog(Users.UserName, "删除", "管理员角色列表》角色删除》删除出现程序错误:"+ex.Message, "程序错误！");
                return AjaxMsg.AjaxMsgs(AjaxStatusEnum.Error, ex.Message);
            }
        }
        #endregion

        [Login]
        #region   //日志列表
        public ActionResult LogList(int page=1,string EndTime="",string StartTime="",string UserName="")
        {
            var Users = Session["user"] as UserEntity;
            string strWhere = " WHERE 1=1";

            #region  查询用户表
            string User_sql = string.Format(@"select UserName from T_User");
            List<UserEntity> list_User = this.GlobalDataAccess.FindEntities<UserEntity>(User_sql);
            ViewData["list_User"] = list_User;
            #endregion

            if (!string.IsNullOrWhiteSpace(StartTime))
            {
                StartTime = StartTime.Replace("'","''");
                strWhere += string.Format(@" and CreateDate>='{0} 00:00:00'",StartTime);
                ViewBag.StartTime = StartTime;
            }
            if (!string.IsNullOrWhiteSpace(EndTime))
            {
                EndTime = EndTime.Replace("'", "''");
                strWhere += string.Format(@" and CreateDate<='{0} 23:59:59'", EndTime);
                ViewBag.EndTime = EndTime;
            }
            if (!string.IsNullOrWhiteSpace(UserName))
            {
                UserName = UserName.Replace("'", "''");
                strWhere += string.Format(@" and UserName like '%{0}%'", UserName);
                ViewBag.UserName = UserName;
            }

            string sqlcount = string.Format(@"select COUNT(0) from T_SystemLog {0}", strWhere);
            int RecordCount = Convert.ToInt32(this.GlobalDataAccess.ExecuteScalar(sqlcount).ToString());

            Lib.UI.PageBase pagebase = new Lib.UI.PageBase();
            int PageSize = 10;
            pagebase.CurrentPageIndex = page;

            string pageSql = string.Format(@"select * from 
	                                                (
		                                                select *, ROW_NUMBER()over(order by CreateDate desc)as RowNo from T_SystemLog
			                                             {2}  
	                                                )tb where RowNo>{0}and RowNo<={1}", ((page - 1) * PageSize), (page * PageSize), strWhere);
            List<SystemLogEntity> list = this.GlobalDataAccess.FindEntities<SystemLogEntity>(pageSql);
            PageListModel<SystemLogEntity> LogList = new PageListModel<SystemLogEntity>(list, page, PageSize, RecordCount);
            return View(LogList);
        }
        #endregion

        #region  //日志删除、批量删除
        public ActionResult LogDel(string LogIDstring)
        {
            try
            {
                string LogID = LogIDstring.TrimEnd(',').Trim();
                foreach (string item in LogID.Split(','))
                {
                    this.GlobalDataAccess.Delete(new SystemLogEntity() {SystemLogID=item });
                }
                return AjaxMsg.AjaxMsgs(AjaxStatusEnum.Success,"删除成功!");
            }
            catch (Exception ex)
            {
                return AjaxMsg.AjaxMsgs(AjaxStatusEnum.Error,ex.Message);
            }
        }
        #endregion

        [Login]
        #region  //菜单权限
        public ActionResult Menu(string RoleID)
        {
            if (string.IsNullOrWhiteSpace(RoleID))
            {
                return AjaxMsg.AjaxMsgs(AjaxStatusEnum.Error, "参数错误");
            }

            #region   //父菜单
            string sql = "select MenuID,MenuName from T_Menu where MenuParentID is null and IsEnable=1 order by SortNumber";
            List<MenuEntity> list = this.GlobalDataAccess.FindEntities<MenuEntity>(sql);
            ViewData["MenuList"] = list;
            #endregion
            
            RoleEntity entity = this.GlobalDataAccess.FindEntity(new RoleEntity { RoleID = RoleID });

            if (entity == null)
            {
                return AjaxMsg.AjaxMsgs(AjaxStatusEnum.Error, "未找到该角色的菜单权限");
            }

            return View(entity);
        }
        [HttpPost]
        public ActionResult Menu(RoleMenuPermissionEntity entity)
        {
            if (string.IsNullOrWhiteSpace(entity.RoleID))
            {
                return AjaxMsg.AjaxMsgs(AjaxStatusEnum.Error, "参数错误");
            }

            #region  //添加角色菜单权限

            this.GlobalDataAccess.Delete(new RoleMenuPermissionEntity
            {
                RoleID = entity.RoleID
            });

            RoleMenuPermissionEntity roleMenu = new RoleMenuPermissionEntity();
            string MenuIDStirng = Tools.R("MenuIDString").TrimEnd(',').Trim();
            if (!string.IsNullOrWhiteSpace(MenuIDStirng))
            {
                foreach (string MenuID in MenuIDStirng.Split(','))
                {
                    roleMenu.MenuID = MenuID;
                    roleMenu.RoleID = entity.RoleID;
                    this.GlobalDataAccess.AddNew(roleMenu);
                }
            }

            #endregion
            return AjaxMsg.AjaxInfo("设置成功", "y");
        }
        #endregion
        
        [Login]
        #region  //栏目权限
        public ActionResult Column(string RoleID)
        {
            if (string.IsNullOrWhiteSpace(RoleID))
            {
                return AjaxMsg.AjaxMsgs(AjaxStatusEnum.Error, "参数错误");
            }
            #region   //父栏目
            string sql = string.Format(@"select 
                                            ColumnID, ColumnName 
                                                from 
                                            T_Column 
                                                where 
                                        ColumnParentID is null and IsEnable = 1 
                                                order by SortNumber");
            List<ColumnEntity> list = this.GlobalDataAccess.FindEntities<ColumnEntity>(sql);
            ViewData["ColumnList"] = list;
            #endregion
            
            RoleEntity entity = this.GlobalDataAccess.FindEntity(new RoleEntity { RoleID = RoleID });

            if (entity == null)
            {
                return AjaxMsg.AjaxMsgs(AjaxStatusEnum.Error, "未找到该角色的栏目权限");
            }

            return View(entity);
        }
        [HttpPost]
        public ActionResult Column(RoleColumnPermissionEntity entity)
        {
            if (string.IsNullOrWhiteSpace(entity.RoleID))
            {
                return AjaxMsg.AjaxMsgs(AjaxStatusEnum.Error,"参数错误");
            }
            #region  //添加角色栏目权限

            this.GlobalDataAccess.Delete(new RoleColumnPermissionEntity
            {
                RoleID = entity.RoleID
            });

            string ColumnIDString = Tools.R("ColumnIDString").TrimEnd(',').Trim();
            RoleColumnPermissionEntity roleMenu = new RoleColumnPermissionEntity();
            if (!string.IsNullOrWhiteSpace(ColumnIDString))
            {
                foreach (string ColumnID in ColumnIDString.Split(','))
                {
                    roleMenu.ColumnID = ColumnID;
                    roleMenu.RoleID = entity.RoleID;
                    this.GlobalDataAccess.AddNew(roleMenu);
                }
            }

            #endregion
            return AjaxMsg.AjaxInfo("设置成功", "y");
        }
        #endregion
        
    }
}