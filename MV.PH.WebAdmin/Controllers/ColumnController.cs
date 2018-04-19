using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MV.PH.Entity;
using MV.PH.WebAdmin.Inc;
using Lib.Tool;
using MV.PH.WebAdmin.Model.PageHelp;
using MV.PH.WebAdmin.Model.Common;
using MV.PH.WebAdmin.Model.Article;

namespace MV.PH.WebAdmin.Controllers
{
    public class ColumnController : ControllerBase
    {
        Uploadfile upfile = new Uploadfile();

        // GET: Column
        [Login]
        #region  //父栏目列表
        public ActionResult List(int page=1,string property="")
        {
            string strWhere = " where ColumnParentID is null ";

            if (!string.IsNullOrWhiteSpace(property))
            {
                property = property.Replace("'", "''");
                switch (property)
                {
                    case "IsNeedAuditing":   //待审核
                        strWhere += string.Format(@" and IsNeedAuditing=1");
                        break;
                    case "UnIsNeedAuditing":    //已审核
                        strWhere += string.Format(@" and IsNeedAuditing=0");
                        break;
                    default:
                        strWhere += string.Format(@" and 1=1");
                        break;
                }
                ViewBag.property = property;
            }

            string sqlcount = string.Format(@"select count(0) from T_Column {0}",strWhere);
            int RecordCount = Convert.ToInt32(this.GlobalDataAccess.ExecuteScalar(sqlcount).ToString());

            Lib.UI.PageBase pagebase = new Lib.UI.PageBase();
            int PageSize = 8;
            pagebase.CurrentPageIndex = page;

            string pageSql = string.Format(@"select * from 
	                                                (
		                                                select row_number()over(order by SortNumber) rowNo,* from T_Column
		                                                {2}
	                                                )tb where rowNo>{0} and rowNo<={1}", ((page - 1) * PageSize), (page * PageSize), strWhere);
            List<ColumnEntity> columnList = this.GlobalDataAccess.FindEntities<ColumnEntity>(pageSql);
            PageListModel<ColumnEntity> List = new PageListModel<ColumnEntity>(columnList, page, PageSize, RecordCount);
            this.GlobalDataAccess.Dispose();
            return View(List);
        }
        #endregion

        [Login]
        #region  //子栏目列表
        public ActionResult ChildrenList(int page = 1, string property = "",string ColumnID="")
        {

            #region //上级栏目
            if (string.IsNullOrWhiteSpace(ColumnID))
            {
                return AjaxMsg.AjaxMsgs(AjaxStatusEnum.Error, "参数错误");
            }
            //string sql = string.Format(@"select * from T_Column where ColumnID='{0}'", ColumnID);
            //ColumnEntity entity = this.GlobalDataAccess.FindEntity<ColumnEntity>(sql);
            //ViewData["ParentColumn"] = entity;
            ViewBag.ColumnID = ColumnID;
            #endregion

            string strWhere = string.Format(@" where ColumnParentID='{0}'", ColumnID);

            if (!string.IsNullOrWhiteSpace(property))
            {
                property = property.Replace("'", "''");
                switch (property)
                {
                    case "IsNeedAuditing":   //待审核
                        strWhere += string.Format(@" and IsNeedAuditing=1");
                        break;
                    case "UnIsNeedAuditing":    //已审核
                        strWhere += string.Format(@" and IsNeedAuditing=0");
                        break;
                    default:
                        strWhere += string.Format(@" and 1=1");
                        break;
                }
                ViewBag.property = property;
            }

            string sqlcount = string.Format(@"select count(0) from T_Column {0}", strWhere);
            int RecordCount = Convert.ToInt32(this.GlobalDataAccess.ExecuteScalar(sqlcount).ToString());

            Lib.UI.PageBase pagebase = new Lib.UI.PageBase();
            int PageSize = 8;
            pagebase.CurrentPageIndex = page;

            string pageSql = string.Format(@"select * from 
	                                                (
		                                                select row_number()over(order by SortNumber) rowNo,* from T_Column
		                                                {2}
	                                                )tb where rowNo>{0} and rowNo<={1}", ((page - 1) * PageSize), (page * PageSize), strWhere);
            List<ColumnEntity> columnList = this.GlobalDataAccess.FindEntities<ColumnEntity>(pageSql);
            PageListModel<ColumnEntity> List = new PageListModel<ColumnEntity>(columnList, page, PageSize, RecordCount);

            this.GlobalDataAccess.Dispose();
            return View(List);
        }
        #endregion
        
        [Login]
        #region //栏目添加
        public ActionResult ColumnAdd()
        {
            #region // 父栏目
            string sql = string.Format(@"select * from T_Column where ColumnParentID is null and IsEnable=1");
            List<ColumnEntity> column = this.GlobalDataAccess.FindEntities<ColumnEntity>(sql);
            ViewData["columnList"] = column;
            #endregion
            return View();
        }
        [HttpPost]
        public ActionResult ColumnAdd(ColumnEntity entity,HttpPostedFileBase file1,HttpPostedFileBase file2)
        {
            file1 = Request.Files["BigIcon"];
            file2 = Request.Files["SmallIcon"];
            string result1 = string.Empty;
            string result2 = string.Empty;
            if (file1 != null)          //有上传文件
            {
                string extra1 = System.IO.Path.GetExtension(file1.FileName).ToLower();  //后缀名

                if (extra1 == ".jpg" || extra1 == ".png" || extra1 == ".bmp" || extra1 == ".gif" || extra1 == ".jpeg")
                {
                    string filename1 = Guid.NewGuid() + extra1;  //重命名
                    result1 = filename1;
                    result1 = upfile.saveFile(filename1, file1, "column_big");
                    Server.MapPath(result1);
                    entity.ColumnBigIcon = result1;
                }
            }

            if (file2 != null)          //有上传文件
            {
                string extra2 = System.IO.Path.GetExtension(file2.FileName).ToLower();  //后缀名

                if (extra2 == ".jpg" || extra2 == ".png" || extra2 == ".bmp" || extra2== ".gif" || extra2 == ".jpeg")
                {
                    string filename2 = Guid.NewGuid() + extra2;  //重命名
                    result2 = filename2;
                    result2 = upfile.saveFile(filename2, file2, "column_small");
                    Server.MapPath(result2);
                    entity.ColumnSmallIcon = result2;
                }
            }
            int num = 0;

            #region   //顶级栏目的TreeID
            if (string.IsNullOrWhiteSpace(entity.ColumnParentID))  //顶级栏目
            {
                string maxTreeID = string.Format(@"select max(ColumnTreeID) from T_Column where ColumnParentID is null");  //最大顶级栏目的TreeID
                if (string.IsNullOrWhiteSpace(this.GlobalDataAccess.ExecuteScalar(maxTreeID).ToString()))
                {
                    //父栏目没有子节点
                    num = 1;
                }
                else
                {
                    num = Convert.ToInt32(this.GlobalDataAccess.ExecuteScalar(maxTreeID))+1;
                }
                entity.ColumnTreeID = string.Format("{0:D5}", num);
            }
            #endregion

            else
            {
                #region  //非顶级栏目TreeID
                ColumnEntity column = this.GlobalDataAccess.FindEntity(new ColumnEntity() { ColumnID = entity.ColumnParentID });  //获取上一级的栏目信息

                string TreeID_len = string.Format(@"select len(ColumnTreeID) from T_Column where ColumnTreeID='{0}'",column.ColumnTreeID);  //获取上一级的TreeID的长度
                int TreeId_Length = Convert.ToInt32(this.GlobalDataAccess.ExecuteScalar(TreeID_len));

                string sqltreeID = string.Format(@"select max(substring(ColumnTreeID,{1},5)) from T_Column where ColumnTreeID like '%{0}'", entity.ColumnTreeID,TreeId_Length+1);//获取上一级栏目下子级中最大的TreeID
                if (string.IsNullOrWhiteSpace(this.GlobalDataAccess.ExecuteScalar(sqltreeID).ToString()))
                {
                    num = 1;
                }
                else
                {
                    num = Convert.ToInt32(this.GlobalDataAccess.ExecuteScalar(sqltreeID))+1;
                }
                entity.ColumnTreeID = column.ColumnTreeID + string.Format("{0:D5}", num);
                #endregion
            }

            entity.ColumnID = Tools.NewID;
            entity.ColumnType = entity.ColumnType.Trim();

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
        #endregion

        [Login]
        #region  //栏目修改
        public ActionResult ColumnEdit(string ColumnID)
        {
            #region // 父栏目
            string sql = string.Format(@"select * from T_Column where ColumnParentID is null and IsEnable=1");
            List<ColumnEntity> column = this.GlobalDataAccess.FindEntities<ColumnEntity>(sql);
            ViewData["columnList"] = column;
            #endregion

            if (string.IsNullOrWhiteSpace(ColumnID))
            {
                return AjaxMsg.AjaxMsgs(AjaxStatusEnum.Error, "参数错误");
            }

            ColumnEntity entity = this.GlobalDataAccess.FindEntity(new ColumnEntity() { ColumnID = ColumnID });
            if (entity == null)
            {
                return AjaxMsg.AjaxMsgs(AjaxStatusEnum.Error, "未找到该项内容");
            }
            return View(entity);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ColumnEdit(ColumnEntity entity,HttpPostedFileBase file1,HttpPostedFileBase file2)
        {
            if (string.IsNullOrWhiteSpace(entity.ColumnID))
            {
                return AjaxMsg.AjaxInfo("参数错误!", "n");
            }

            file1 = Request.Files["BigIcon"];
            file2 = Request.Files["SmallIcon"];
            string result1 = string.Empty;
            string result2 = string.Empty;
            if (file1 != null)          //有上传文件
            {
                string extra1 = System.IO.Path.GetExtension(file1.FileName).ToLower();  //后缀名

                if (extra1 == ".jpg" || extra1 == ".png" || extra1 == ".bmp" || extra1 == ".gif" || extra1 == ".jpeg")
                {
                    string filename1 = Guid.NewGuid() + extra1;  //重命名
                    result1 = filename1;
                    result1 = upfile.saveFile(filename1, file1, "column_big");
                    Server.MapPath(result1);
                    entity.ColumnBigIcon = result1;
                }
            }

            if (file2 != null)          //有上传文件
            {
                string extra2 = System.IO.Path.GetExtension(file2.FileName).ToLower();  //后缀名

                if (extra2 == ".jpg" || extra2 == ".png" || extra2 == ".bmp" || extra2 == ".gif" || extra2 == ".jpeg")
                {
                    string filename2 = Guid.NewGuid() + extra2;  //重命名
                    result2 = filename2;
                    result2 = upfile.saveFile(filename2, file2, "column_small");
                    Server.MapPath(result2);
                    entity.ColumnSmallIcon = result2;
                }
            }

            int num = 0;

            ColumnEntity columnEntity = this.GlobalDataAccess.FindEntity(new ColumnEntity() {ColumnID=entity.ColumnID });

            if (columnEntity.ColumnParentID != entity.ColumnParentID)  //栏目已改动
            {
                if (string.IsNullOrWhiteSpace(entity.ColumnParentID))  //顶级栏目
                {
                    #region   //顶级栏目的TreeID
                    string maxTreeID = string.Format(@"select max(ColumnTreeID) from T_Column where ColumnParentID is null");  //最大顶级栏目的TreeID
                    if (string.IsNullOrWhiteSpace(this.GlobalDataAccess.ExecuteScalar(maxTreeID).ToString()))
                    {
                        //父栏目没有子节点
                        num = 1;
                    }
                    else
                    {
                        num = Convert.ToInt32(this.GlobalDataAccess.ExecuteScalar(maxTreeID)) + 1;
                    }
                    entity.ColumnTreeID = string.Format("{0:D5}", num);

                    #region   //更改栏目TreeID就更改文章TreeID
                    string sql = string.Format(@"update T_ArticleInfo set ColumnTreeID='{0}' WHERE ColumnTreeID='{1}'",entity.ColumnTreeID,columnEntity.ColumnTreeID);
                    this.GlobalDataAccess.ExecuteNonQuery(sql);
                    #endregion

                    #endregion
                }

                else
                {
                    #region  //非顶级栏目TreeID
                    ColumnEntity column = this.GlobalDataAccess.FindEntity(new ColumnEntity() { ColumnID = entity.ColumnParentID });  //获取上一级的栏目信息

                    string TreeID_len = string.Format(@"select len(ColumnTreeID) from T_Column where ColumnTreeID='{0}'", column.ColumnTreeID);  //获取上一级的TreeID的长度
                    int TreeId_Length = Convert.ToInt32(this.GlobalDataAccess.ExecuteScalar(TreeID_len));

                    string sqltreeID = string.Format(@"select max(substring(ColumnTreeID,{1},5)) from T_Column where ColumnTreeID like '%{0}'", entity.ColumnTreeID, TreeId_Length + 1);//获取上一级栏目下子级中最大的TreeID
                    if (string.IsNullOrWhiteSpace(this.GlobalDataAccess.ExecuteScalar(sqltreeID).ToString()))
                    {
                        num = 1;
                    }
                    else
                    {
                        num = Convert.ToInt32(this.GlobalDataAccess.ExecuteScalar(sqltreeID)) + 1;
                    }
                    entity.ColumnTreeID = column.ColumnTreeID + string.Format("{0:D5}", num);

                    #region   //更改栏目TreeID就更改文章TreeID
                    string sql = string.Format(@"update T_ArticleInfo set ColumnTreeID='{0}' WHERE ColumnTreeID='{1}'",entity.ColumnTreeID,columnEntity.ColumnTreeID);
                    this.GlobalDataAccess.ExecuteNonQuery(sql);
                    #endregion

                    #endregion
                }
            }
            
            if (string.IsNullOrWhiteSpace(entity.ColumnParentID))
            {
                entity.ColumnParentIDAttribute.SetDBNullValue();
            }

            entity.ColumnType = entity.ColumnType.Trim();

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

        #region  //栏目删除
        public ActionResult DelColumn(string ColumnTreeIDstring)
        {
            try
            {
                string ColumnTreeID = ColumnTreeIDstring.TrimEnd(',').Trim();
                foreach (string item in ColumnTreeID.Split(','))
                {
                    string Column_sql = string.Format(@"select * from T_Column where ColumnTreeID like '{0}%'",item);  //根据TreeID获取栏目信息
                    List<ColumnEntity> ColumnList = this.GlobalDataAccess.FindEntities<ColumnEntity>(Column_sql);
                    foreach (var Column_Entity in ColumnList)
                    {
                        this.GlobalDataAccess.Delete(new RoleColumnPermissionEntity() {ColumnID= Column_Entity.ColumnID });   //删除角色栏目权限
                        this.GlobalDataAccess.Delete(new ArticleInColumnEntity() {ColumnID=Column_Entity.ColumnID });    //删除文章隶属栏目表
                    }

                    string Art_sql = string.Format(@"select * from T_ArticleInfo where ColumnTreeID like '{0}%'", item);  //根据TreeID获取文章信息
                    List<ArticleInfoEntity> ArtList = this.GlobalDataAccess.FindEntities<ArticleInfoEntity>(Art_sql);
                    foreach (var Art_Entity in ArtList)
                    {
                        this.GlobalDataAccess.Delete(new ArticleRrelatedEntity() { ArticleInfoID = Art_Entity.ArticleInfoID });   //删除文章相关表
                        this.GlobalDataAccess.Delete(new ArticleAttachmentEntity() { ArticleInfoID = Art_Entity.ArticleInfoID });    //删除文章附件表
                    }

                    string del_Art = string.Format(@"delete from T_ArticleInfo where ColumnTreeID like '{0}%'",item);  //删除栏目下的文章表
                    this.GlobalDataAccess.ExecuteNonQuery(del_Art);

                    string del_Column = string.Format(@"delete from T_Column where ColumnTreeID like '{0}%'", item);  //删除栏目
                    this.GlobalDataAccess.ExecuteNonQuery(del_Column);
                }
                return AjaxMsg.AjaxMsgs(AjaxStatusEnum.Success, "删除成功!");
            }
            catch (Exception ex)
            {
                return AjaxMsg.AjaxMsgs(AjaxStatusEnum.Error, ex.Message);
            }
            finally
            {
                this.GlobalDataAccess.Dispose();
            }
        }
        #endregion

        [Login]
        #region   //栏目停用、启用
        public ActionResult ColumnState(string ColumnID,int IsEnable)
        {
            if (string.IsNullOrWhiteSpace(ColumnID))
            {
                return AjaxMsg.AjaxMsgs(AjaxStatusEnum.Error,"参数错误");
            }

            this.GlobalDataAccess.Update(new ColumnEntity
            {
                IsEnable = IsEnable,
                ColumnID = ColumnID
            });
            return AjaxMsg.AjaxInfo("操作成功","y");
        }
        #endregion

        #region  //删除大图、小图
        public ActionResult DelIcon(string ColumnID,string type)
        {
            if(type=="big")  //删除大图
            {
                #region  //删除服务器的文件
                ColumnEntity entity = this.GlobalDataAccess.FindEntity(new ColumnEntity() {ColumnID=ColumnID });
                if (System.IO.File.Exists(Server.MapPath(entity.ColumnBigIcon)))
                {
                    System.IO.File.Delete(Server.MapPath(entity.ColumnBigIcon));
                }
                #endregion

                string sql = string.Format(@"update T_Column set ColumnBigIcon=null where ColumnID='{0}'",ColumnID);
                int i = this.GlobalDataAccess.ExecuteNonQuery(sql);
                if (i > 0)
                {
                    return AjaxMsg.AjaxMsgs(AjaxStatusEnum.Success, "删除成功!");
                }
                else
                {
                    return AjaxMsg.AjaxMsgs(AjaxStatusEnum.Fail, "删除失败!");
                }
            }
            //删除小图
            else
            {
                #region  //删除服务器的文件
                ColumnEntity entity = this.GlobalDataAccess.FindEntity(new ColumnEntity() { ColumnID = ColumnID });
                if (System.IO.File.Exists(Server.MapPath(entity.ColumnSmallIcon)))
                {
                    System.IO.File.Delete(Server.MapPath(entity.ColumnSmallIcon));
                }
                #endregion

                string sql = string.Format(@"update T_Column set ColumnSmallIcon=null where ColumnID='{0}'", ColumnID);
                int i = this.GlobalDataAccess.ExecuteNonQuery(sql);
                if (i > 0)
                {
                    return AjaxMsg.AjaxMsgs(AjaxStatusEnum.Success, "删除成功!");
                }
                else
                {
                    return AjaxMsg.AjaxMsgs(AjaxStatusEnum.Fail, "删除失败!");
                }
            }

        }
        #endregion
    }
}