using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MV.PH.Entity;
using MV.PH.WebAdmin.Model.PageHelp;
using Lib.Tool;
using MV.PH.WebAdmin.Model.Dictionary;
using MV.PH.WebAdmin.Model.Common;
using MV.PH.WebAdmin.Inc;
namespace MV.PH.WebAdmin.Controllers
{
    public class SystemController : ControllerBase
    {
        // GET: System
        Uploadfile upfile = new Uploadfile();

        [Login]
        #region //敏感字修改
        public ActionResult Independent(string ForbiddenWordID="1")
        {

            if (string.IsNullOrWhiteSpace(ForbiddenWordID))
            {
                return AjaxMsg.AjaxMsgs(AjaxStatusEnum.Error,"系统错误!");
            }

            ForbiddenWordEntity entity = this.GlobalDataAccess.FindEntity(new ForbiddenWordEntity() {ForbiddenWordID=ForbiddenWordID });

            if (entity == null)
            {
                return AjaxMsg.AjaxMsgs(AjaxStatusEnum.Error, "未找到该项内容");
            }

            return View(entity);
        }

        [HttpPost]
        public ActionResult Independent(ForbiddenWordEntity entity)
        {
            if (string.IsNullOrWhiteSpace(entity.ForbiddenWordID))
            {
                return AjaxMsg.AjaxInfo("参数错误", "n");
            }

            if (string.IsNullOrEmpty(entity.ForbiddenWord))
            {
                entity.ForbiddenWordAttribute.SetDBNullValue();
            }

            int i = this.GlobalDataAccess.Update(entity);
            if (i > 0)
            {
                return AjaxMsg.AjaxInfo("屏蔽词设置成功","y");
            }
            else
            {
                return AjaxMsg.AjaxInfo("屏蔽词设置失败", "n");
            }
            
        }
        #endregion
        

        [Login]
        #region //字典分类列表
        public ActionResult DictionaryCategoryList(int page=1,string CategoryName="")
        {
            var Users = Session["user"] as UserEntity;
            string strWhere = " WHERE 1=1";
            
            
            if (!string.IsNullOrWhiteSpace(CategoryName))
            {
                CategoryName = CategoryName.Replace("'", "''");
                strWhere += string.Format(@" and CategoryName like '%{0}%'", CategoryName);
                ViewBag.CategoryName = CategoryName;
            }

            string sqlcount = string.Format(@"select COUNT(0) from T_DictionaryCategory {0}", strWhere);
            int RecordCount = Convert.ToInt32(this.GlobalDataAccess.ExecuteScalar(sqlcount).ToString());

            Lib.UI.PageBase pagebase = new Lib.UI.PageBase();
            int PageSize = 10;
            pagebase.CurrentPageIndex = page;

            string pageSql = string.Format(@"select * from 
	                                                (
		                                                select *, ROW_NUMBER()over(order by CategoryName)as RowNo from T_DictionaryCategory
			                                             {2}  
	                                                )tb where RowNo>{0}and RowNo<={1}", ((page - 1) * PageSize), (page * PageSize), strWhere);
            List<DictionaryCategoryEntity> list = this.GlobalDataAccess.FindEntities<DictionaryCategoryEntity>(pageSql);
            PageListModel<DictionaryCategoryEntity> CategoryList = new PageListModel<DictionaryCategoryEntity>(list, page, PageSize, RecordCount);
            return View(CategoryList);
        }
        #endregion

        [Login]
        #region //字典分类添加
        public ActionResult CategoryAdd()
        {
            return View();
        }

       [HttpPost]
       public ActionResult CategoryAdd(DictionaryCategoryEntity entity)
        {
            entity.DictionaryCategoryID = Tools.NewID;
            int i = this.GlobalDataAccess.AddNew(entity);
            if (i > 0)
            {
                return AjaxMsg.AjaxInfo("添加成功","y");
            }
            else
            {
                return AjaxMsg.AjaxInfo("添加失败", "y");
            }
        }
        #endregion

        [Login]
        #region  //字典分类修改
        public ActionResult CategoryEdit(string DictionaryCategoryID)
        {
            if (string.IsNullOrEmpty(DictionaryCategoryID))
            {
                return AjaxMsg.AjaxMsgs(AjaxStatusEnum.Error,"参数错误!");
            }

            DictionaryCategoryEntity entity = this.GlobalDataAccess.FindEntity(new DictionaryCategoryEntity() {DictionaryCategoryID=DictionaryCategoryID });

            if (entity == null)
            {
                return AjaxMsg.AjaxMsgs(AjaxStatusEnum.Error, "未找到该项内容");
            }
            return View(entity);
        }

        [HttpPost]
        public ActionResult CategoryEdit(DictionaryCategoryEntity entity)
        {
            if (string.IsNullOrEmpty(entity.DictionaryCategoryID))
            {
                return AjaxMsg.AjaxInfo("参数错误", "n");
            }

            int i = this.GlobalDataAccess.Update(entity);
            if (i > 0)
            {
                return AjaxMsg.AjaxInfo("修改成功","y");
            }
            else
            {
                return AjaxMsg.AjaxInfo("修改失败","n");
            }
        }
        #endregion

        #region //字典分类删除
        public ActionResult DelDictionaryCategory(string DictionaryCategoryIDstring)
        {
            this.GlobalDataAccess.BeginTransaction();
            try
            {
                string DictionaryCategoryID = DictionaryCategoryIDstring.TrimEnd(',').Trim();
                foreach (string item in DictionaryCategoryID.Split(','))
                {
                    this.GlobalDataAccess.Delete(new DictionaryEntity() { DictionaryCategoryID = item });   //删除字典表
                    this.GlobalDataAccess.Delete(new DictionaryCategoryEntity() {DictionaryCategoryID=item });  //删除字典分类表
                }
                this.GlobalDataAccess.CommitTransaction();
                return AjaxMsg.AjaxMsgs(AjaxStatusEnum.Success, "删除成功");
            }
            catch (Exception ex)
            {
                this.GlobalDataAccess.EndTransaction();
                return AjaxMsg.AjaxMsgs(AjaxStatusEnum.Error, ex.Message);
            }
        }
        #endregion

        [Login]
        #region //字典列表
        public ActionResult DictionaryList(int page = 1, string DictionaryCategoryID = "",string DictionaryName="")
        {
            var Users = Session["user"] as UserEntity;
            string strWhere = " WHERE 1=1";

            #region  //字典分类
            string sql = string.Format(@"select * from T_DictionaryCategory");
            List<DictionaryCategoryEntity> category = this.GlobalDataAccess.FindEntities<DictionaryCategoryEntity>(sql);
            ViewData["category"] = category;
            #endregion
            

            if (!string.IsNullOrWhiteSpace(DictionaryName))
            {
                DictionaryName = DictionaryName.Replace("'", "''");
                strWhere += string.Format(@" and A.DictionaryName like '%{0}%'", DictionaryName);
                ViewBag.DictionaryName = DictionaryName;
            }
            if (!string.IsNullOrWhiteSpace(DictionaryCategoryID))
            {
                DictionaryCategoryID = DictionaryCategoryID.Replace("'", "''");
                strWhere += string.Format(@" and A.DictionaryCategoryID='{0}'", DictionaryCategoryID);
                ViewBag.DictionaryCategoryID = DictionaryCategoryID;
            }

            string sqlcount = string.Format(@"select COUNT(0) from T_Dictionary A
                                                    INNER JOIN T_DictionaryCategory B ON A.DictionaryCategoryID=B.DictionaryCategoryID", strWhere);
            int RecordCount = Convert.ToInt32(this.GlobalDataAccess.ExecuteScalar(sqlcount).ToString());

            Lib.UI.PageBase pagebase = new Lib.UI.PageBase();
            int PageSize = 10;
            pagebase.CurrentPageIndex = page;

            string pageSql = string.Format(@"select * from 
	                                                (
		                                                select A.*,B.CategoryName, ROW_NUMBER()over(order by SortNumber)as RowNo from 
															(
																T_Dictionary A
																INNER JOIN T_DictionaryCategory B ON A.DictionaryCategoryID=B.DictionaryCategoryID
															)
			                                              {2}
	                                                )tb where RowNo>{0} and RowNo<={1}", ((page - 1) * PageSize), (page * PageSize), strWhere);
            List<P_DictionaryEntity> list = this.GlobalDataAccess.FindEntities<P_DictionaryEntity>(pageSql);
            PageListModel<P_DictionaryEntity> CategoryList = new PageListModel<P_DictionaryEntity>(list, page, PageSize, RecordCount);
            return View(CategoryList);
        }
        #endregion

        [Login]
        #region //字典添加
        public ActionResult DictionaryAdd()
        {
            #region  //字典分类
            string sql = string.Format(@"select * from T_DictionaryCategory");
            List<DictionaryCategoryEntity> category = this.GlobalDataAccess.FindEntities<DictionaryCategoryEntity>(sql);
            ViewData["category"] = category;
            #endregion

            return View();
        }

        [HttpPost]
        public ActionResult DictionaryAdd(DictionaryEntity entity)
        {
            entity.DictionaryID = Tools.NewID;
            int i = this.GlobalDataAccess.AddNew(entity);
            if (i > 0)
            {
                return AjaxMsg.AjaxInfo("添加成功","y");
            }
            else
            {
                return AjaxMsg.AjaxInfo("添加失败","n");
            }
        }
        #endregion

        [Login]
        #region  //字典修改
        public ActionResult DictionaryEdit(string DictionaryID)
        {
            #region  //字典分类
            string sql = string.Format(@"select * from T_DictionaryCategory");
            List<DictionaryCategoryEntity> category = this.GlobalDataAccess.FindEntities<DictionaryCategoryEntity>(sql);
            ViewData["category"] = category;
            #endregion

            if (string.IsNullOrWhiteSpace(DictionaryID))
            {
                return AjaxMsg.AjaxMsgs(AjaxStatusEnum.Error,"参数错误");
            }
            DictionaryEntity entity = this.GlobalDataAccess.FindEntity(new DictionaryEntity() {DictionaryID=DictionaryID });
            if (entity == null)
            {
                return AjaxMsg.AjaxMsgs(AjaxStatusEnum.Error, "未找到该项内容");
            }
            return View(entity);
        }

        [HttpPost]
        public ActionResult DictionaryEdit(DictionaryEntity entity)
        {
            if (string.IsNullOrWhiteSpace(entity.DictionaryID))
            {
                return AjaxMsg.AjaxInfo("参数错误", "n");
            }
            int i = this.GlobalDataAccess.Update(entity);
            if (i > 0)
            {
                return AjaxMsg.AjaxInfo("修改成功", "y");
            }
            else
            {
                return AjaxMsg.AjaxInfo("修改失败", "n");
            }
        }
        #endregion

        #region //字典删除
        public ActionResult DelDictionary(string DictionaryIDstring)
        {
            this.GlobalDataAccess.BeginTransaction();
            try
            {
                string DictionaryID = DictionaryIDstring.TrimEnd(',').Trim();
                foreach (string item in DictionaryID.Split(','))
                {
                    this.GlobalDataAccess.Delete(new DictionaryEntity() { DictionaryID = item });
                }
                this.GlobalDataAccess.CommitTransaction();
                return AjaxMsg.AjaxMsgs(AjaxStatusEnum.Success, "删除成功");
            }
            catch (Exception ex)
            {
                this.GlobalDataAccess.EndTransaction();
                return AjaxMsg.AjaxMsgs(AjaxStatusEnum.Error, ex.Message);
            }
        }
        #endregion
        
        [Login]
        #region   //用户反馈列表
        public ActionResult CommentList(int page = 1,string StartTime="",string EndTime="",string ReadStatus="")
        {
            string strWhere = " WHERE 1=1";

            if (!string.IsNullOrWhiteSpace(StartTime))
            {
                StartTime = StartTime.Replace("'", "''");
                strWhere += string.Format(@" and FeedbackDate>='{0} 00:00:00'", StartTime);
                ViewBag.StartTime = StartTime;
            }
            if (!string.IsNullOrWhiteSpace(EndTime))
            {
                EndTime = EndTime.Replace("'", "''");
                strWhere += string.Format(@" and FeedbackDate<='{0} 23:59:59'", EndTime);
                ViewBag.EndTime = EndTime;
            }
            if (!string.IsNullOrWhiteSpace(ReadStatus))
            {
                ReadStatus = ReadStatus.Replace("'", "''");
                strWhere += string.Format(@" and ReadStatus='{0}'", ReadStatus);
                ViewBag.ReadStatus = ReadStatus;
            }

            string sqlcount = string.Format(@"select COUNT(0) from T_UserFeedback {0}", strWhere);
            int RecordCount = Convert.ToInt32(this.GlobalDataAccess.ExecuteScalar(sqlcount).ToString());

            Lib.UI.PageBase pagebase = new Lib.UI.PageBase();
            int PageSize = 10;
            pagebase.CurrentPageIndex = page;

            string pageSql = string.Format(@"select * from 
	                                                (
		                                                select *, ROW_NUMBER()over(order by FeedbackDate desc)as RowNo from T_UserFeedback
			                                             {2}  
	                                                )tb where RowNo>{0}and RowNo<={1}", ((page - 1) * PageSize), (page * PageSize), strWhere);
            List<UserFeedbackEntity> list = this.GlobalDataAccess.FindEntities<UserFeedbackEntity>(pageSql);
            PageListModel<UserFeedbackEntity> commentList = new PageListModel<UserFeedbackEntity>(list, page, PageSize, RecordCount);
            return View(commentList);
        }
        #endregion

        [Login]
        #region  //用户反馈详情
        public ActionResult UserFeedDetail(string UserFeedbackID)
        {
            if (string.IsNullOrWhiteSpace(UserFeedbackID))
            {
                return AjaxMsg.AjaxMsgs(AjaxStatusEnum.Error, "参数错误");
            }

            UserFeedbackEntity entity = this.GlobalDataAccess.FindEntity(new UserFeedbackEntity() {UserFeedbackID=UserFeedbackID });

            if (entity == null)
            {
                return AjaxMsg.AjaxMsgs(AjaxStatusEnum.Error, "该内容不存在");
            }
            this.GlobalDataAccess.Update(new UserFeedbackEntity()
            {
                ReadStatus="已读",
                ReadDate=DateTime.Now,
                UserFeedbackID=UserFeedbackID
            });
            return View(entity);
        }
        #endregion

        #region  //评论列表删除、批量删除
        public ActionResult CommentDel(string UserFeedbackIDstring)
        {
            try
            {
                string UserFeedbackID = UserFeedbackIDstring.TrimEnd(',').Trim();
                foreach (string item in UserFeedbackID.Split(','))
                {
                    this.GlobalDataAccess.Delete(new UserFeedbackEntity() { UserFeedbackID = item });
                }
                return AjaxMsg.AjaxMsgs(AjaxStatusEnum.Success, "删除成功!");
            }
            catch (Exception ex)
            {
                return AjaxMsg.AjaxMsgs(AjaxStatusEnum.Error, ex.Message);
            }
        }
        #endregion

        [Login]
        #region  //文件上传设置
        public ActionResult sys_config()
        {
            #region  //水印类型
            SystemSettingEntity watermartType = this.GlobalDataAccess.FindEntity(new SystemSettingEntity() {SystemSettingKey= "watermarktype" });
            ViewData["watermartType"] = watermartType;
            #endregion

            #region  //水印位置
            SystemSettingEntity watermarkPosition = this.GlobalDataAccess.FindEntity(new SystemSettingEntity() { SystemSettingKey = "watermarkposition" });
            ViewData["watermarkPosition"] = watermarkPosition;
            #endregion

            //#region  //水印图片文件
            //SystemSettingEntity watermarkPic = this.GlobalDataAccess.FindEntity(new SystemSettingEntity() { SystemSettingKey = "watermarkpic" });
            //ViewData["watermarkPic"] = watermarkPic;
            //#endregion

            #region  //水印文字
            SystemSettingEntity watermarkText = this.GlobalDataAccess.FindEntity(new SystemSettingEntity() { SystemSettingKey = "watermarktext" });
            ViewData["watermarkText"] = watermarkText;
            #endregion

            return View();
        }
        [HttpPost]
        public ActionResult sys_config(HttpPostedFileBase file1)
        {
            this.GlobalDataAccess.BeginTransaction();
            try
            {
                #region  //设置水印类型
                this.GlobalDataAccess.Update(new SystemSettingEntity()
                {
                    SystemSettingValue = Request["watermarktype"],
                    SystemSettingKey = "watermarktype"
                });
                #endregion

                #region  //设置水印位置
                this.GlobalDataAccess.Update(new SystemSettingEntity()
                {
                    SystemSettingValue = Request["watermarkposition"],
                    SystemSettingKey = "watermarkposition"
                });
                #endregion

                #region  //  设置水印图片文件
                file1 = Request.Files["BigIcon"];
                string result1 = string.Empty;
                if (file1 != null)          //有上传文件
                {
                    string extra1 = System.IO.Path.GetExtension(file1.FileName).ToLower();  //后缀名

                    if (extra1 == ".jpg" || extra1 == ".png" || extra1 == ".bmp" || extra1 == ".gif" || extra1 == ".jpeg")
                    {
                        string filename1 = Guid.NewGuid() + extra1;  //重命名
                        result1 = filename1;
                        result1 = upfile.saveFile(filename1, file1, "waterPic");
                        Server.MapPath(result1);
                        this.GlobalDataAccess.Update(new SystemSettingEntity()
                        {
                            SystemSettingValue = result1,
                            SystemSettingKey = "watermarkpic"
                        });
                    }
                }
                #endregion

                #region  //设置水印文字
                this.GlobalDataAccess.Update(new SystemSettingEntity()
                {
                    SystemSettingValue = Request["watermarktext"],
                    SystemSettingKey = "watermarktext"
                });
                #endregion

                this.GlobalDataAccess.CommitTransaction();
                return AjaxMsg.AjaxInfo("文件上传设置成功!", "y");
            }
            catch (Exception ex)
            {
                this.GlobalDataAccess.RollbackTransaction();
                return AjaxMsg.AjaxInfo(ex.Message, "n");
            }
           

        }
        #endregion

        #region  //删除水印文件
        public ActionResult Delwater()
        {
            this.GlobalDataAccess.Delete(new SystemSettingEntity() {SystemSettingKey= "watermarkpic" });

            #region  //删除服务器的文件
            SystemSettingEntity entity = this.GlobalDataAccess.FindEntity(new SystemSettingEntity() { SystemSettingKey = "watermarkpic" });
            if (System.IO.File.Exists(Server.MapPath(entity.SystemSettingValue)))
            {
                System.IO.File.Delete(Server.MapPath(entity.SystemSettingValue));
            }
            #endregion

            string sql = string.Format(@"update T_SystemSetting set SystemSettingValue=null where SystemSettingKey='watermarkpic'");
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
        #endregion

    }
}