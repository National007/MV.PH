using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MV.PH.Entity;
using MV.PH.WebAdmin.Inc;
using Lib.Tool;
using MV.PH.WebAdmin.Model.PageHelp;

namespace MV.PH.WebAdmin.Controllers
{
    public class MenuController : ControllerBase
    {
        // GET: Menu
        [Login]
        #region //父菜单列表
        public ActionResult List(int page=1)
        {

            string strWhere = " where MenuParentID is null ";
            string sqlcount = string.Format(@"select count(0) from T_Menu {0}", strWhere);
            int RecordCount = Convert.ToInt32(this.GlobalDataAccess.ExecuteScalar(sqlcount).ToString());

            Lib.UI.PageBase pagebase = new Lib.UI.PageBase();
            int PageSize = 8;
            pagebase.CurrentPageIndex = page;

            string pageSql = string.Format(@"select * from
	                                        (
		                                        select *,Row_Number()over(order by SortNumber) RowNo 
			                                        from 
			                                        T_Menu
				                                        {2}
	                                        )tb where RowNo>{0} and RowNo<={1}", ((page - 1) * PageSize), (page * PageSize), strWhere);
            List<MenuEntity> columnList = this.GlobalDataAccess.FindEntities<MenuEntity>(pageSql);
            PageListModel<MenuEntity> List = new PageListModel<MenuEntity>(columnList, page, PageSize, RecordCount);
            return View(List);
        }
        #endregion

        [Login]
        #region //子菜单列表
        public ActionResult ChildrenList(int page = 1,string MenuID="")
        {
            if (string.IsNullOrWhiteSpace(MenuID))
            {
                return AjaxMsg.AjaxMsgs(AjaxStatusEnum.Error, "参数错误");
            }
            #region //上级菜单
            string sql = string.Format(@"select * from T_Menu where MenuID='{0}'", MenuID);
            MenuEntity entity = this.GlobalDataAccess.FindEntity<MenuEntity>(sql);
            ViewData["ParentMenu"] = entity;
            #endregion

            if (entity == null)
            {
                return AjaxMsg.AjaxMsgs(AjaxStatusEnum.Error, "未找到父菜单内容");
            }

            string strWhere = string.Format(@" where MenuParentID='{0}'",MenuID);
            string sqlcount = string.Format(@"select count(0) from T_Menu {0}", strWhere);
            int RecordCount = Convert.ToInt32(this.GlobalDataAccess.ExecuteScalar(sqlcount).ToString());

            Lib.UI.PageBase pagebase = new Lib.UI.PageBase();
            int PageSize = 8;
            pagebase.CurrentPageIndex = page;

            string pageSql = string.Format(@"select * from
	                                        (
		                                        select *,Row_Number()over(order by SortNumber) RowNo 
			                                        from 
			                                        T_Menu
				                                   {2}     
	                                        )tb where RowNo>{0} and RowNo<={1}", ((page - 1) * PageSize), (page * PageSize), strWhere);
            List<MenuEntity> columnList = this.GlobalDataAccess.FindEntities<MenuEntity>(pageSql);
            PageListModel<MenuEntity> List = new PageListModel<MenuEntity>(columnList, page, PageSize, RecordCount);
            return View(List);
        }
        #endregion

        [Login]
        #region  //菜单添加、修改
        public ActionResult MenuAdd()
        {
            string sql = "select MenuID,MenuName from T_Menu where MenuParentID is null order by SortNumber";
            List<MenuEntity> list = this.GlobalDataAccess.FindEntities<MenuEntity>(sql);
            return View(list);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult MenuAdd(MenuEntity entity)
        {
            entity.MenuID = Tools.NewID;
            int i = this.GlobalDataAccess.AddNew(entity);
            if (i > 0)
            {
                return AjaxMsg.AjaxInfo("添加成功!", "y");
            }
            else
            {
                return AjaxMsg.AjaxInfo("添加失败!", "n");
            }
        }

        public ActionResult MenuEdit(string MenuID)
        {
            if (string.IsNullOrWhiteSpace(MenuID))
            {
                return AjaxMsg.AjaxMsgs(AjaxStatusEnum.Error,"参数错误");
            }
            string sql = "select MenuID,MenuName from T_Menu where MenuParentID is null order by SortNumber";
            List<MenuEntity> list = this.GlobalDataAccess.FindEntities<MenuEntity>(sql);
            ViewData["list"] = list;

            MenuEntity entity = this.GlobalDataAccess.FindEntity(new MenuEntity() {MenuID=MenuID });

            if (entity == null)
            {
                return AjaxMsg.AjaxMsgs(AjaxStatusEnum.Error, "未找到该菜单");
            }
            return View(entity);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult MenuEdit(MenuEntity entity)
        {
            if (string.IsNullOrWhiteSpace(entity.MenuID))
            {
                return AjaxMsg.AjaxInfo("参数错误","n");
            }
            if (string.IsNullOrWhiteSpace(entity.MenuParentID))
            {
                entity.MenuParentIDAttribute.SetDBNullValue();
            }

            int i = this.GlobalDataAccess.Update(entity);
            if (i > 0)
            {
                return AjaxMsg.AjaxInfo("修改成功!", "y");
            }
            else
            {
                return AjaxMsg.AjaxInfo("修改失败!", "n");
            }
        }
        #endregion

        #region //菜单批量删除
        public ActionResult DelMenu(string MenuIDstring)
        {
            this.GlobalDataAccess.BeginTransaction();
            try
            {
                string MenuID = MenuIDstring.TrimEnd(',').Trim();
                foreach (string item in MenuID.Split(','))
                {
                    this.GlobalDataAccess.Delete(new RoleMenuPermissionEntity() {MenuID=item });  //角色菜单权限表
                    this.GlobalDataAccess.Delete(new MenuEntity() { MenuID = item });
                }
                this.GlobalDataAccess.CommitTransaction();
                return AjaxMsg.AjaxMsgs(AjaxStatusEnum.Success, "删除成功!");
            }
            catch (Exception ex)
            {
                this.GlobalDataAccess.EndTransaction();
                return AjaxMsg.AjaxMsgs(AjaxStatusEnum.Error, ex.Message);
            }
        }
        #endregion

    }
}