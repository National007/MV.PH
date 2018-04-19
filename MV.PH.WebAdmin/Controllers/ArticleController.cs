using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;

using MV.PH.Entity;
using MV.PH.WebAdmin.Model.PageHelp;
using MV.PH.WebAdmin.Model.Admin;
using Lib.Tool;
using MV.PH.WebAdmin.Model.Article;
using MV.PH.WebAdmin.Model.Common;
using MV.PH.WebAdmin.Inc;

namespace MV.PH.WebAdmin.Controllers
{
    public class ArticleController : ControllerBase
    {
        Uploadfile upfile = new Uploadfile();
        Article_dal dal = new Article_dal();
        public static bool IsDate(string strDate)
        {
            try
            {
                DateTime.Parse(strDate);
                return true;
            }
            catch
            {
                return false;
            }
        }

        #region  //根据栏目ID检索栏目类型
        public ActionResult ArticleType(string ColumnID)
        {
            string sql = string.Format(@"select 
                                            ColumnType 
                                         from 
                                            T_Column 
                                         where 
                                            ColumnID='{0}'", ColumnID);
            string type = Convert.ToString(this.GlobalDataAccess.ExecuteScalar(sql));     //栏目类型
            var v = new
            {
                Type = type.Trim()
            };
            JsonResult jr = new JsonResult();
            jr.Data = v;
            return jr;
        }
        #endregion

        // GET: Article
        [Login]
        #region  //资讯列表
        public ActionResult ArticleList(int page = 1, string ArticleTitle = "", string ColumnTreeID = "", string property = "",string divMain= "",string StartTime = "",string EndTime="")
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
            ViewBag.divMain = divMain;

            string strWhere = " where 1=1";
            string inner_tab = string.Empty;

            if (user.IsAdmin == Convert.ToInt32(Post.SuperAdmin))  //超管
            {
                #region  //父栏目
                string sql = string.Format(@"select ColumnID,ColumnTreeID,ColumnName from T_Column where ColumnParentID is null");
                List<ColumnEntity> list = this.GlobalDataAccess.FindEntities<ColumnEntity>(sql);
                ViewData["list"] = list;
                #endregion
            }
            else       //普管
            {
                #region  //父栏目
                string RoleIDstring = string.Empty;
                if (entity.Count > 0)
                {
                    foreach (var item in entity)
                    {
                        RoleIDstring += "'" + item.RoleID + "',";
                    }
                    string sql = string.Format(@"select 
                                            A.ColumnID,A.ColumnTreeID,A.ColumnName 
                                         from 
                                            T_Column A
	                                        inner join T_RoleColumnPermission B ON A.ColumnID=B.ColumnID
	                                      WHERE B.RoleID in ({0}) AND ColumnParentID IS NULL
                                            group by A.ColumnName,A.ColumnTreeID,A.ColumnID", RoleIDstring.TrimEnd(','));
                    List<ColumnEntity> list = this.GlobalDataAccess.FindEntities<ColumnEntity>(sql);
                    ViewData["list"] = list;

                    string sql1 = string.Format(@"select 
                                                    A.ColumnID,A.ColumnTreeID,A.ColumnName 
                                                 from 
                                                    T_Column A
	                                                inner join T_RoleColumnPermission B ON A.ColumnID=B.ColumnID
	                                              WHERE B.RoleID in ({0})
                                                    group by A.ColumnName,A.ColumnTreeID,A.ColumnID",RoleIDstring.TrimEnd(','));
                    List<ColumnEntity> list_column = this.GlobalDataAccess.FindEntities<ColumnEntity>(sql1);
                    string ColumnIDstring = string.Empty;
                    if (list_column.Count > 0)
                    {
                        foreach (var item in list_column)
                        {
                            ColumnIDstring+="'"+item.ColumnID+"',";
                        }
                    }
                    if (!string.IsNullOrWhiteSpace(ColumnIDstring))
                    {
                        strWhere = string.Format(@" WHERE tb.columnid in ({0})", ColumnIDstring.TrimEnd(','));
                    }
                    else
                    {
                        strWhere = string.Format("where 1=2");
                    }
                }
                #endregion
                
            }
            //string sql1 = string.Format(@"select A.*,B.ColumnName,ROW_NUMBER()over(order by A.CreateDate desc) as rowNo from 
            //                                          (
            //                                           T_ArticleInfo A
            //                                           inner join T_Column B ON A.ColumnID=B.ColumnID
            //                                                    {0}
            //                                          )", inner_tab);
            //string sql1_count = string.Format(@"select COUNT(0) from T_ArticleInfo A
            //                                         inner join T_Column B ON B.ColumnID=A.ColumnID
            //                                            {0}", inner_tab);

            if (!string.IsNullOrWhiteSpace(ColumnTreeID))
            {
                ColumnTreeID = ColumnTreeID.Replace("'", "''");
                strWhere += string.Format(@" and B.ColumnTreeID LIKE '{0}%'", ColumnTreeID);
                ViewBag.ColumnTreeID = ColumnTreeID;

                //sql1 = string.Format(@" SELECT TB.ColumnID,TB.ArticleInfoID,A.ArticleTitle,B.ColumnName,A.ReadCount,A.IsToppest,A.IsRecommend,A.AuditingStatus,A.IsEnable,ROW_NUMBER()over(order by A.CreateDate desc) as rowNo FROM 
                //                                     (
            				//                            (
            				//	                            SELECT A.ColumnID,A.ArticleInfoID FROM T_ArticleInfo A
            				//		                            UNION
            				//	                            SELECT * FROM T_ArticleInColumn
            				//                            )TB 
            				//                            INNER JOIN T_ArticleInfo A ON TB.ArticleInfoID=A.ArticleInfoID
            				//                            inner join T_Column B ON TB.ColumnID=B.ColumnID
                //                                                                            {0}
            		  //                              )", inner_tab);
                //sql1_count = string.Format(@"SELECT COUNT(0) FROM
            				//                        (
            				//	                        SELECT A.ColumnID,A.ArticleInfoID FROM T_ArticleInfo A
            				//		                        UNION
            				//	                        SELECT * FROM T_ArticleInColumn
            				//                        )TB 
            				//                        INNER JOIN T_ArticleInfo A ON TB.ArticleInfoID=A.ArticleInfoID
            				//                        inner join T_Column B ON TB.ColumnID=B.ColumnID
                //                                                                                {0}", inner_tab);
            }
            if (!string.IsNullOrWhiteSpace(ArticleTitle))
            {
                ArticleTitle = ArticleTitle.Replace("'", "''");
                strWhere += string.Format(@" and A.ArticleTitle like '%{0}%'", ArticleTitle);
                ViewBag.ArticleTitle = ArticleTitle;
            }
            if (!string.IsNullOrWhiteSpace(property))
            {
                property = property.Replace("'", "''");
                switch (property)
                {
                    case "S_AuditingStatus":  //审核通过
                        strWhere += string.Format(@" and A.AuditingStatus=2");
                        break;
                    case "U_AuditingStatus":  //审核不通过
                        strWhere += string.Format(@" and A.AuditingStatus=1");
                        break;
                    case "W_AuditingStatus":  //未审核
                        strWhere += string.Format(@" and A.AuditingStatus=0");
                        break;
                    case "IsRecommend":
                        strWhere += string.Format(@" and A.IsRecommend=1");
                        break;
                    case "IsToppest":
                        strWhere += string.Format(@" and A.IsToppest=1");
                        break;
                    default:
                        strWhere += string.Format(@" and 1=1");
                        break;
                }
                ViewBag.property = property;
            }
            if (!string.IsNullOrWhiteSpace(StartTime)&& IsDate(StartTime))  //字符串为时间格式
            {
                StartTime = StartTime.Replace("'", "''");
                strWhere += string.Format(@" and CreateDate>='{0} 00:00:00'", StartTime);
                ViewBag.StartTime = StartTime;
            }
            if (!string.IsNullOrWhiteSpace(EndTime)&& IsDate(EndTime)) //字符串为时间格式
            {
                EndTime = EndTime.Replace("'", "''");
                strWhere += string.Format(@" and CreateDate<='{0} 23:59:59'", EndTime);
                ViewBag.EndTime = EndTime;
            }

            //string sqlcount = string.Format(@"select COUNT(0) from T_ArticleInfo A
            //                                         inner join T_Column B ON B.ColumnID=A.ColumnID
            //                                            {1}
            //                                      {0}", strWhere, inner_tab);

            string sqlcount = string.Format(@"SELECT COUNT(0) FROM
            				(
            					SELECT A.ColumnID,A.ArticleInfoID FROM T_ArticleInfo A
            						UNION
            					SELECT * FROM T_ArticleInColumn
            				)TB 
            				INNER JOIN T_ArticleInfo A ON TB.ArticleInfoID=A.ArticleInfoID
            				inner join T_Column B ON TB.ColumnID=B.ColumnID
                                                                        {1}
                                                                 {0}", strWhere, inner_tab);
            //string sqlcount = string.Format(@"{0}{1}", sql1_count, strWhere);
            int RecordCount = Convert.ToInt32(this.GlobalDataAccess.ExecuteScalar(sqlcount).ToString());

            Lib.UI.PageBase pagebase = new Lib.UI.PageBase();
            int PageSize = 8;
            pagebase.CurrentPageIndex = page;

            //string pageSql = string.Format(@"select * from 
            //                                         (
            //                                          select A.*,B.ColumnName,ROW_NUMBER()over(order by A.CreateDate desc) as rowNo from 
            //                                          (
            //                                           T_ArticleInfo A
            //                                           inner join T_Column B ON A.ColumnID=B.ColumnID
            //                                                    {3}
            //                                          )
            //                                          {2}
            //                                         )tb where rowNo>{0} and rowNo<={1}", ((page - 1) * PageSize), (page * PageSize), strWhere, inner_tab);

            string pageSql = string.Format(@"select * from 
                                                     (

                                                     select 
                                                        tb.columnid,
                                                        tb.articleinfoid,
                                                        a.articletitle,
                                                        b.columnname,
                                                        a.readcount,
                                                        a.istoppest,
                                                        a.isrecommend,
                                                        a.auditingstatus,
                                                        a.isenable,
                                                        a.CreateDate,
                                                        row_number()over(order by a.createdate desc) as rowno from 
                                                     (
            				                            (
            					                            select a.columnid,a.articleinfoid from t_articleinfo a
            						                            union
            					                            select * from t_articleincolumn
            				                            )tb 
            				                            inner join t_articleinfo a on tb.articleinfoid=a.articleinfoid
            				                            inner join t_column b on tb.columnid=b.columnid
                                                                                            {3}
            		                                    )
                                                      {2}
                                                     )tb where rowno>{0} and rowno<={1}", ((page - 1) * PageSize), (page * PageSize), strWhere, inner_tab);

            //string pageSql = string.Format(@"select * from 
            //                                         (
            //                                         {3}
            //                                          {2}
            //                                         )tb where rowNo>{0} and rowNo<={1}", ((page - 1) * PageSize), (page * PageSize), strWhere, sql1);
            List<P_ArticleEntity> Articlelist = this.GlobalDataAccess.FindEntities<P_ArticleEntity>(pageSql);
            PageListModel<P_ArticleEntity> userList = new PageListModel<P_ArticleEntity>(Articlelist, page, PageSize, RecordCount);

            
            return View(userList);
        }
        #endregion

        [Login]
        #region  //资讯添加
        public ActionResult Add()
        {
            #region  //父栏目
            //string sql = string.Format(@"select ColumnID,ColumnName from T_Column where ColumnParentID is null");
            //List<ColumnEntity> list = this.GlobalDataAccess.FindEntities<ColumnEntity>(sql);
            //ViewData["list"] = list;
            #endregion

            #region  //用户角色
            var user = Session["user"] as UserEntity;
            string str = string.Format(@"SELECT A.* FROM T_Role A
																INNER JOIN T_UserInRole B ON A.RoleID=B.RoleID
																INNER JOIN T_User C ON B.UserID=C.UserID
																WHERE C.UserID='{0}'", user.UserID);
            List<RoleEntity> entity = this.GlobalDataAccess.FindEntities<RoleEntity>(str);
            ViewData["Role"] = entity;
            #endregion

            if (user.IsAdmin == Convert.ToInt32(Post.SuperAdmin))  //超管
            {
                #region  //父栏目
                string sql = string.Format(@"select ColumnID,ColumnName from T_Column where ColumnParentID is null");
                List<ColumnEntity> list = this.GlobalDataAccess.FindEntities<ColumnEntity>(sql);
                ViewData["list"] = list;
                #endregion
            }
            else       //普管
            {
                #region  //父栏目
                string RoleIDstring = string.Empty;
                if (entity.Count > 0)
                {
                    foreach (var item in entity)
                    {
                        RoleIDstring += "'" + item.RoleID + "',";
                    }
                    string sql = string.Format(@"select 
                                            A.ColumnID,A.ColumnName 
                                         from 
                                            T_Column A
	                                        inner join T_RoleColumnPermission B ON A.ColumnID=B.ColumnID
	                                      WHERE B.RoleID in ({0}) AND ColumnParentID IS NULL
                                            group by A.ColumnName,A.ColumnID", RoleIDstring.TrimEnd(','));
                    List<ColumnEntity> list = this.GlobalDataAccess.FindEntities<ColumnEntity>(sql);
                    ViewData["list"] = list;
                }
                #endregion
                
            }
            return View();
        }
        [Login]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Add(ArticleInfoEntity entity,HttpPostedFileBase file1)
        {
            var user = Session["user"] as UserEntity;

            ColumnEntity column = this.GlobalDataAccess.FindEntity(new ColumnEntity() { ColumnID = entity.ColumnID });  //通过栏目ID获取栏目TreeID
            this.GlobalDataAccess.BeginTransaction();
            try
            {
                #region  //添加文章
                entity.ArticleInfoID = Tools.NewID;
                entity.ColumnTreeID = column.ColumnTreeID;
                entity.ArticleNumber = Convert.ToInt32(DateTime.Now.ToString("yyyyMMdd"));
                entity.CreateDate = DateTime.Now;  //创建日期
                entity.Creator = user.UserName;
                //判断本分类是否需要审核
                if (column.IsNeedAuditing == 1)  //栏目需要审核
                {
                    //需要审核时，默认审核状态为“未审核”
                    entity.AuditingStatus = 0;  //未审核
                }
                else
                {
                    entity.AuditingStatus = 2;  //审核通过
                    entity.AuditingPerson = "system auto";
                    entity.AuditingDate = DateTime.Now;
                }


                int i = this.GlobalDataAccess.AddNew(entity);
                #endregion

                #region  //封面图片（栏目类型为文本图片及视频）
                if (entity.ArticleType.Trim() == "text_image"||entity.ArticleType.Trim()== "video")
                {
                    file1 = Request.Files["BigIcon"];
                    string result1 = string.Empty;
                    if (file1 != null)          //有上传文件
                    {
                        string extra1 = System.IO.Path.GetExtension(file1.FileName).ToLower();  //后缀名

                        if (extra1 == ".jpg" || extra1 == ".png" || extra1 == ".bmp" || extra1 == ".gif" || extra1 == ".jpeg")
                        {
                            string filename1 = Guid.NewGuid() + extra1;  //重命名
                            result1 = filename1;
                            result1 = upfile.saveFile(filename1, file1, "face");
                            Server.MapPath(result1);
                            ArticleAttachmentEntity attach = new ArticleAttachmentEntity();
                            attach.ArticleAttachmentID = Tools.NewID;
                            attach.ArticleInfoID = entity.ArticleInfoID;
                            attach.FileName = file1.FileName;
                            attach.PhysicsName = "Face";
                            attach.ThumbnailthumbnailThumbnail = result1;
                            attach.FileSize = upfile.Hs(file1.ContentLength);
                            attach.FileType = extra1.Substring(extra1.IndexOf('.') + 1);
                            attach.CreateDate = DateTime.Now;
                            this.GlobalDataAccess.AddNew(attach);
                        }
                    }
                }
                #endregion

                #region  //添加文章下的附件   (文本类型)
                if (entity.ArticleType.Trim() == "text_list"|| entity.ArticleType.Trim()=="text_image")
                {
                    if (!string.IsNullOrWhiteSpace(Request["hid_attach_filepath"]))
                    {
                        string[] hid_attach_filename = Request.Params.GetValues("hid_attach_filename");
                        string[] hid_attach_filepath = Request.Params.GetValues("hid_attach_filepath");
                        string[] hid_attach_filesize = Request.Params.GetValues("hid_attach_filesize");
                        string[] hid_attach_filetype = Request.Params.GetValues("hid_attach_filetype");
                        for (int j = 0; j < hid_attach_filename.Length; j++)
                        {
                            ArticleAttachmentEntity attach = new ArticleAttachmentEntity();
                            attach.ArticleAttachmentID = Tools.NewID;
                            attach.ArticleInfoID = entity.ArticleInfoID;
                            attach.FileName = hid_attach_filename[j];
                            attach.PhysicsName = hid_attach_filepath[j];
                            attach.FileSize = hid_attach_filesize[j];
                            attach.FileType = hid_attach_filetype[j];
                            attach.CreateDate = DateTime.Now;
                            this.GlobalDataAccess.AddNew(attach);
                        }
                    }
                }
                #endregion

                #region  //添加文章下的附件  （图片类型）
                if (entity.ArticleType.Trim() == "image")
                {
                    if (!string.IsNullOrWhiteSpace(Request["ElintAttachment"]))
                    {
                        string[] strAttach = Request.Params.GetValues("ElintAttachment");
                        string[] remark = Request.Params.GetValues("hid_photo_remark");
                        for (int j = 0; j < strAttach.Length; j++)
                        {
                            string[] atta = strAttach[j].Split('|');
                            ArticleAttachmentEntity attachEntity = new ArticleAttachmentEntity();
                            attachEntity.ArticleAttachmentID = Tools.NewID;
                            attachEntity.ArticleInfoID = entity.ArticleInfoID;
                            attachEntity.FileName = atta[0];
                            attachEntity.PhysicsName = atta[2];
                            attachEntity.ThumbnailthumbnailThumbnail = atta[4];
                            attachEntity.FileSize = atta[3];
                            attachEntity.FileType = atta[1];
                            attachEntity.FileRemark = remark[j];
                            attachEntity.CreateDate = DateTime.Now;
                            this.GlobalDataAccess.AddNew(attachEntity);
                        }
                    }
                }
                #endregion

                #region  //添加文章下的附件   (视频类型)
                if (entity.ArticleType.Trim() == "video")
                {
                    if (!string.IsNullOrWhiteSpace(Request["hidFilePath"]))
                    {
                        ArticleAttachmentEntity attach = new ArticleAttachmentEntity();
                        attach.ArticleAttachmentID = Tools.NewID;
                        attach.ArticleInfoID = entity.ArticleInfoID;
                        attach.FileName = Request["hidFileName"];
                        attach.PhysicsName = Request["hidFilePath"];
                        attach.FileSize = Request["hidFileSize"];
                        attach.FileType = Request["hidFileType"];
                        attach.CreateDate = DateTime.Now;
                        this.GlobalDataAccess.AddNew(attach);
                    }
                }
                #endregion

                this.GlobalDataAccess.CommitTransaction();
                if (i > 0)
                {
                    return AjaxMsg.AjaxInfo("添加成功!", "y");
                }
                else
                {
                    return AjaxMsg.AjaxInfo("添加失败!", "n");
                }
            }
            catch (Exception ex)
            {
                this.GlobalDataAccess.EndTransaction();
                return AjaxMsg.AjaxInfo(ex.Message, "n");
            }
        }
        #endregion

        [Login]
        #region  //资讯修改
        public ActionResult Edit(string ArticleInfoID)
        {
            if (string.IsNullOrWhiteSpace(ArticleInfoID))
            {
                return AjaxMsg.AjaxMsgs(AjaxStatusEnum.Error, "参数错误");
            }

            #region  //用户角色
            var user = Session["user"] as UserEntity;
            string str = string.Format(@"SELECT A.* FROM T_Role A
																INNER JOIN T_UserInRole B ON A.RoleID=B.RoleID
																INNER JOIN T_User C ON B.UserID=C.UserID
																WHERE C.UserID='{0}'", user.UserID);
            List<RoleEntity> Role_entity = this.GlobalDataAccess.FindEntities<RoleEntity>(str);
            ViewData["Role"] = Role_entity;
            #endregion

            if (user.IsAdmin == Convert.ToInt32(Post.SuperAdmin))  //超管
            {
                #region  //父栏目
                string sql = string.Format(@"select ColumnID,ColumnName from T_Column where ColumnParentID is null");
                List<ColumnEntity> list = this.GlobalDataAccess.FindEntities<ColumnEntity>(sql);
                ViewData["list"] = list;
                #endregion
            }
            else       //普管
            {
                #region  //父栏目
                string RoleIDstring = string.Empty;
                if (Role_entity.Count > 0)
                {
                    foreach (var item in Role_entity)
                    {
                        RoleIDstring += "'" + item.RoleID + "',";
                    }
                    string sql = string.Format(@"select 
                                            A.ColumnID,A.ColumnName 
                                         from 
                                            T_Column A
	                                        inner join T_RoleColumnPermission B ON A.ColumnID=B.ColumnID
	                                      WHERE B.RoleID in ({0}) AND ColumnParentID IS NULL
                                            group by A.ColumnName,A.ColumnID", RoleIDstring.TrimEnd(','));
                    List<ColumnEntity> list = this.GlobalDataAccess.FindEntities<ColumnEntity>(sql);
                    ViewData["list"] = list;
                }
                #endregion

            }
            
            ArticleInfoEntity entity = this.GlobalDataAccess.FindEntity(new ArticleInfoEntity() { ArticleInfoID = ArticleInfoID });

            if (entity == null)
            {
                return AjaxMsg.AjaxMsgs(AjaxStatusEnum.Error, "未找到该项内容");
            }

            #region  //遍历该文章下的附件
            string sql1 = string.Format(@"select 
                                            * 
                                        from 
                                            T_ArticleAttachment 
                                        where ArticleInfoID='{0}' and PhysicsName <> 'Face' order by CreateDate", ArticleInfoID);
            List<ArticleAttachmentEntity> attachList = this.GlobalDataAccess.FindEntities<ArticleAttachmentEntity>(sql1);
            ViewData["attachList"] = attachList;
            #endregion

            #region //查询该文章下的封面图片
            string sql2 = string.Format(@"select 
                                            * 
                                        from 
                                            T_ArticleAttachment 
                                        where ArticleInfoID='{0}' and PhysicsName='Face'", ArticleInfoID);
            ArticleAttachmentEntity attachentity = this.GlobalDataAccess.FindEntity<ArticleAttachmentEntity>(sql2);
            ViewData["attachentity"] = attachentity;
            #endregion

            return View(entity);
        }
        [Login]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(ArticleInfoEntity entity,HttpPostedFileBase file1)
        {
            var user = Session["user"] as UserEntity;
            if (string.IsNullOrWhiteSpace(entity.ArticleInfoID))
            {
                return AjaxMsg.AjaxInfo("参数错误!", "n");
            }
            this.GlobalDataAccess.BeginTransaction();
            try
            {
                entity.ModifyDate = DateTime.Now;
                entity.Modifier = user.UserName;

                #region  //文章修改
                int i = this.GlobalDataAccess.Update(entity);
                #endregion
                

                #region //文章下的附件删除（除封面图片外）
                string del_Attach = string.Format(@"delete from T_ArticleAttachment where ArticleInfoID='{0}' and PhysicsName <> 'face'",entity.ArticleInfoID);
                this.GlobalDataAccess.ExecuteNonQuery(del_Attach);
                #endregion

                #region  //封面图片（栏目类型为文本图片及视频）
                if (entity.ArticleType.Trim() == "text_image" || entity.ArticleType.Trim() == "video")
                {
                    file1 = Request.Files["BigIcon"];
                    string result1 = string.Empty;
                    if (file1 != null)          //有上传文件
                    {
                        #region  //删除封面图片
                        string del_Attach_Face = string.Format(@"delete from T_ArticleAttachment where ArticleInfoID='{0}' and PhysicsName='face'", entity.ArticleInfoID);
                        this.GlobalDataAccess.ExecuteNonQuery(del_Attach_Face);
                        #endregion

                        string extra1 = System.IO.Path.GetExtension(file1.FileName).ToLower();  //后缀名

                        if (extra1 == ".jpg" || extra1 == ".png" || extra1 == ".bmp" || extra1 == ".gif" || extra1 == ".jpeg")
                        {
                            string filename1 = Guid.NewGuid() + extra1;  //重命名
                            result1 = filename1;
                            result1 = upfile.saveFile(filename1, file1, "face");
                            Server.MapPath(result1);
                            ArticleAttachmentEntity attach = new ArticleAttachmentEntity();
                            attach.ArticleAttachmentID = Tools.NewID;
                            attach.ArticleInfoID = entity.ArticleInfoID;
                            attach.FileName = file1.FileName;
                            attach.PhysicsName = "Face";
                            attach.ThumbnailthumbnailThumbnail = result1;
                            attach.FileSize = upfile.Hs(file1.ContentLength);
                            attach.FileType = extra1.Substring(extra1.IndexOf('.') + 1);
                            attach.CreateDate = DateTime.Now;
                            this.GlobalDataAccess.AddNew(attach);
                        }
                    }

                }
                #endregion

                #region  //添加文章下的附件   (文本类型)
                if (entity.ArticleType.Trim() == "text_list" || entity.ArticleType.Trim() == "text_image")
                {
                    if (!string.IsNullOrWhiteSpace(Request["hid_attach_filepath"]))
                    {
                        string[] hid_attach_filename = Request.Params.GetValues("hid_attach_filename");
                        string[] hid_attach_filepath = Request.Params.GetValues("hid_attach_filepath");
                        string[] hid_attach_filesize = Request.Params.GetValues("hid_attach_filesize");
                        string[] hid_attach_filetype = Request.Params.GetValues("hid_attach_filetype");
                        for (int j = 0; j < hid_attach_filename.Length; j++)
                        {
                            ArticleAttachmentEntity attach = new ArticleAttachmentEntity();
                            attach.ArticleAttachmentID = Tools.NewID;
                            attach.ArticleInfoID = entity.ArticleInfoID;
                            attach.FileName = hid_attach_filename[j];
                            attach.PhysicsName = hid_attach_filepath[j];
                            attach.FileSize = hid_attach_filesize[j];
                            attach.FileType = hid_attach_filetype[j];
                            attach.CreateDate = DateTime.Now;
                            this.GlobalDataAccess.AddNew(attach);
                        }
                    }
                }
                #endregion

                #region  //添加文章下的附件  （图片类型）
                if (entity.ArticleType.Trim() == "image")
                {
                    if (!string.IsNullOrWhiteSpace(Request["ElintAttachment"]))
                    {
                        string[] strAttach = Request.Params.GetValues("ElintAttachment");
                        string[] remark = Request.Params.GetValues("hid_photo_remark");
                        for (int j = 0; j < strAttach.Length; j++)
                        {
                            string[] atta = strAttach[j].Split('|');
                            ArticleAttachmentEntity attachEntity = new ArticleAttachmentEntity();
                            attachEntity.ArticleAttachmentID = Tools.NewID;
                            attachEntity.ArticleInfoID = entity.ArticleInfoID;
                            attachEntity.FileName = atta[0];
                            attachEntity.PhysicsName = atta[2];
                            attachEntity.ThumbnailthumbnailThumbnail = atta[4];
                            attachEntity.FileSize = atta[3];
                            attachEntity.FileType = atta[1];
                            attachEntity.FileRemark = remark[j];
                            attachEntity.CreateDate = DateTime.Now;
                            this.GlobalDataAccess.AddNew(attachEntity);
                        }
                    }
                }
                #endregion

                #region  //添加文章下的附件   (视频类型)
                if (entity.ArticleType.Trim() == "video")
                {
                    if (!string.IsNullOrWhiteSpace(Request["hidFilePath"]))
                    {
                        ArticleAttachmentEntity attach = new ArticleAttachmentEntity();
                        attach.ArticleAttachmentID = Tools.NewID;
                        attach.ArticleInfoID = entity.ArticleInfoID;
                        attach.FileName = Request["hidFileName"];
                        attach.PhysicsName = Request["hidFilePath"];
                        attach.FileSize = Request["hidFileSize"];
                        attach.FileType = Request["hidFileType"];
                        attach.CreateDate = DateTime.Now;
                        this.GlobalDataAccess.AddNew(attach);
                    }
                }
                #endregion

                this.GlobalDataAccess.CommitTransaction();
                if (i > 0)
                {
                    return AjaxMsg.AjaxInfo("修改成功!", "y");
                }
                else
                {
                    return AjaxMsg.AjaxInfo("修改失败!", "n");
                }

            }
            catch (Exception ex)
            {
                this.GlobalDataAccess.EndTransaction();
                return AjaxMsg.AjaxInfo(ex.Message, "n");
            }

        }
        #endregion

        #region   //删除封面图片
        public ActionResult DelFaceImg(string ArticleAttachmentID)
        {
            if (string.IsNullOrWhiteSpace(ArticleAttachmentID))
            {
                return AjaxMsg.AjaxMsgs(AjaxStatusEnum.Success, "参数错误!");
            }

            #region  //删除服务器的文件
            ArticleAttachmentEntity entity = this.GlobalDataAccess.FindEntity(new ArticleAttachmentEntity() { ArticleAttachmentID = ArticleAttachmentID });
            if (System.IO.File.Exists(Server.MapPath(entity.ThumbnailthumbnailThumbnail)))
            {
                System.IO.File.Delete(Server.MapPath(entity.ThumbnailthumbnailThumbnail));
            }
            #endregion

            int i = this.GlobalDataAccess.Delete(new ArticleAttachmentEntity() {ArticleAttachmentID=ArticleAttachmentID });
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

        [Login]
        #region  //批量删除文章
        public ActionResult DelArticle(string ArticleIDstring, string ColumnID)
        {
            this.GlobalDataAccess.BeginTransaction();
            try
            {
                ArticleRrelatedEntity Rrelate = new ArticleRrelatedEntity();
                string ArticleID = ArticleIDstring.TrimEnd(',').Trim();
                foreach (string item in ArticleID.Split(','))
                {
                    #region  //批量删除
                    if (string.IsNullOrWhiteSpace(ColumnID))
                    {
                        string[] strArticleID = item.Split('|');  //获取文章ID

                        if (dal.GetSub_Title(strArticleID[1], strArticleID[0]) > 0)   //该文章为副文章
                        {
                            this.GlobalDataAccess.Delete(new ArticleInColumnEntity() { ArticleInfoID = strArticleID[0], ColumnID = strArticleID[1] });
                        }
                        else      //原文章
                        {
                            Rrelate = this.GlobalDataAccess.FindEntity(new ArticleRrelatedEntity() { ArticleInfoID = strArticleID[0] });  //文章相关
                            if (Rrelate != null)  //如果删除文章是文章相关的父文章
                            {
                                this.GlobalDataAccess.Delete(new ArticleRrelatedEntity() { ArticleInfoID = strArticleID[0] });    //文章 相关表
                            }
                            else   //删除文章是文章相关的子文章
                            {
                                this.GlobalDataAccess.Delete(new ArticleRrelatedEntity() { RrelatedArticleInfoID = strArticleID[0] });    //文章 相关表
                            }
                            this.GlobalDataAccess.Delete(new ArticleInColumnEntity() { ArticleInfoID = strArticleID[0] });   //	文章复制表
                            this.GlobalDataAccess.Delete(new ArticleAttachmentEntity() { ArticleInfoID = strArticleID[0] });  //文章附件表
                            this.GlobalDataAccess.Delete(new ArticleInfoEntity() { ArticleInfoID = strArticleID[0] });   //文章表
                        }
                    }
                    #endregion

                    #region  //单行删除
                    else
                    {
                        if (dal.GetSub_Title(ColumnID, item) > 0)   //该文章为副文章
                        {
                            this.GlobalDataAccess.Delete(new ArticleInColumnEntity() { ArticleInfoID = item, ColumnID = ColumnID });
                        }
                        else      //原文章
                        {
                            Rrelate = this.GlobalDataAccess.FindEntity(new ArticleRrelatedEntity() { ArticleInfoID = item });  //文章相关
                            if (Rrelate != null)  //如果删除文章是文章相关的父文章
                            {
                                this.GlobalDataAccess.Delete(new ArticleRrelatedEntity() { ArticleInfoID = item });    //文章 相关表
                            }
                            else   //删除文章是文章相关的子文章
                            {
                                this.GlobalDataAccess.Delete(new ArticleRrelatedEntity() { RrelatedArticleInfoID = item });    //文章 相关表
                            }
                            this.GlobalDataAccess.Delete(new ArticleInColumnEntity() { ArticleInfoID = item });   //	文章复制表
                            this.GlobalDataAccess.Delete(new ArticleAttachmentEntity() { ArticleInfoID = item });  //文章附件表
                            this.GlobalDataAccess.Delete(new ArticleInfoEntity() { ArticleInfoID = item });   //文章表
                        }
                    }
                    #endregion


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

        [Login]
        #region //文章审核列表
        public ActionResult AuditingList(int page = 1, string ArticleTitle = "", string ColumnTreeID = "", string property = "")
        {
            #region  //用户角色
            var user = Session["user"] as UserEntity;
            string str = string.Format(@"SELECT A.* FROM T_Role A
																INNER JOIN T_UserInRole B ON A.RoleID=B.RoleID
																INNER JOIN T_User C ON B.UserID=C.UserID
																WHERE C.UserID='{0}'", user.UserID);
            List<RoleEntity> Role_entity = this.GlobalDataAccess.FindEntities<RoleEntity>(str);
            ViewData["Role"] = Role_entity;
            #endregion

            string strWhere = " where A.AuditingStatus<2";
            string inner_tab = string.Empty;
            if (user.IsAdmin == Convert.ToInt32(Post.SuperAdmin))  //超管
            {
                #region  //父栏目
                string sql1 = string.Format(@"select ColumnID,ColumnName from T_Column where ColumnParentID is null");
                List<ColumnEntity> list1 = this.GlobalDataAccess.FindEntities<ColumnEntity>(sql1);
                ViewData["list"] = list1;
                #endregion
            }
            else       //普管
            {
                #region  //父栏目
                string RoleIDstring = string.Empty;
                if (Role_entity.Count > 0)
                {
                    foreach (var item in Role_entity)
                    {
                        RoleIDstring += "'" + item.RoleID + "',";
                    }
                    string sql1 = string.Format(@"select 
                                            A.ColumnID,A.ColumnName 
                                         from 
                                            T_Column A
	                                        inner join T_RoleColumnPermission B ON A.ColumnID=B.ColumnID
	                                      WHERE B.RoleID in ({0}) AND ColumnParentID IS NULL
                                            group by A.ColumnName,A.ColumnID", RoleIDstring.TrimEnd(','));
                    List<ColumnEntity> list1 = this.GlobalDataAccess.FindEntities<ColumnEntity>(sql1);
                    ViewData["list"] = list1;
                }
                #endregion

                strWhere += string.Format(@" and C.RoleID in ({0})", RoleIDstring.TrimEnd(','));
                inner_tab = "inner join T_RoleColumnPermission C ON B.ColumnID=C.ColumnID";

            }

            
            if (!string.IsNullOrWhiteSpace(ColumnTreeID))
            {
                ColumnTreeID = ColumnTreeID.Replace("'", "''");
                strWhere += string.Format(@" and A.ColumnTreeID like '{0}%'", ColumnTreeID);
                ViewBag.ColumnTreeID = ColumnTreeID;
            }
            if (!string.IsNullOrWhiteSpace(ArticleTitle))
            {
                ArticleTitle = ArticleTitle.Replace("'", "''");
                strWhere += string.Format(@" and A.ArticleTitle like '%{0}%'", ArticleTitle);
                ViewBag.ArticleTitle = ArticleTitle;
            }
            if (!string.IsNullOrWhiteSpace(property))
            {
                property = property.Replace("'", "''");
                switch (property)
                {
                    case "S_AuditingStatus":  //审核通过
                        strWhere += string.Format(@" and A.AuditingStatus=2");
                        break;
                    case "U_AuditingStatus":  //审核不通过
                        strWhere += string.Format(@" and A.AuditingStatus=1");
                        break;
                    case "W_AuditingStatus":  //未审核
                        strWhere += string.Format(@" and A.AuditingStatus=0");
                        break;
                    case "IsRecommend":
                        strWhere += string.Format(@" and A.IsRecommend=1");
                        break;
                    case "IsToppest":
                        strWhere += string.Format(@" and A.IsToppest=1");
                        break;
                    default:
                        strWhere += string.Format(@" and 1=1");
                        break;
                }
                ViewBag.property = property;
            }

            string sqlcount = string.Format(@"select COUNT(0) from T_ArticleInfo A
	                                                    inner join T_Column B ON B.ColumnID=A.ColumnID
                                                        {1}
		                                                {0}", strWhere,inner_tab);
            int RecordCount = Convert.ToInt32(this.GlobalDataAccess.ExecuteScalar(sqlcount).ToString());

            Lib.UI.PageBase pagebase = new Lib.UI.PageBase();
            int PageSize = 8;
            pagebase.CurrentPageIndex = page;

            string pageSql = string.Format(@"select * from 
	                                                    (
		                                                    select A.*,B.ColumnName,ROW_NUMBER()over(order by A.createdate asc) as rowNo from 
		                                                    (
			                                                    T_ArticleInfo A
			                                                    inner join T_Column B ON A.ColumnID=B.ColumnID
                                                                {3}
		                                                    )
		                                                    {2}
	                                                    )tb where rowNo>{0} and rowNo<={1}", ((page - 1) * PageSize), (page * PageSize), strWhere,inner_tab);
            List<P_ArticleEntity> Articlelist = this.GlobalDataAccess.FindEntities<P_ArticleEntity>(pageSql);
            PageListModel<P_ArticleEntity> userList = new PageListModel<P_ArticleEntity>(Articlelist, page, PageSize, RecordCount);
            
            return View(userList);
        }
        #endregion

        [Login]
        #region  //文章批量审核（通过、不通过）
        public ActionResult Auditing(string ArticleIDstring, string state,string ColumnID)
        {
            var user = Session["user"] as UserEntity;
            this.GlobalDataAccess.BeginTransaction();
            try
            {
                ArticleInfoEntity entity = new ArticleInfoEntity();
                string ArticleID = ArticleIDstring.TrimEnd(',').Trim();
                var i = 0;  //记录审核通过（审核不通过）失败的条数
                var count = 0;      //选中审核通过（审核不通过）的条数

                string msg = string.Empty;
                #region //审核通过
                if (state == "pass")
                {
                    #region  //批量审核
                    if (string.IsNullOrWhiteSpace(ColumnID))
                    {
                        foreach (string item in ArticleID.Split(','))
                        {
                            count++;
                            string[] strArticleID = item.Split('|');  //获取文章ID
                            if (dal.GetSub_Title(strArticleID[1], strArticleID[0]) > 0)   //该文章为副文章
                            {
                                i++;
                            }
                            else
                            {
                                entity.AuditingStatus = 2;  //审核通过
                                entity.AuditingDate = DateTime.Now;  //审核日期
                                entity.AuditingPerson = user.UserName;  //审核人
                                entity.ArticleInfoID = strArticleID[0];
                                this.GlobalDataAccess.Update(entity);
                            }

                        }
                        this.GlobalDataAccess.CommitTransaction();
                        
                        if (i > 0)
                        {
                            msg += "批量审核通过" + (count - i) + "条成功," + i + "条失败";
                        }
                        else
                        {
                            msg += "批量审核通过" + count + "条成功";
                        }
                        return AjaxMsg.AjaxMsgs(AjaxStatusEnum.Success, "" + msg + "");
                    }
                    #endregion

                    #region  //单文章审核
                    else
                    {
                        int IsSuccess = 1;
                        if (dal.GetSub_Title(ColumnID, ArticleID)>0)  //该文章为副文章
                        {
                            IsSuccess = 0;
                            msg += "审核通过失败";
                        }
                        else
                        {
                            entity.AuditingStatus = 2;  //审核通过
                            entity.AuditingDate = DateTime.Now;  //审核日期
                            entity.AuditingPerson = user.UserName;  //审核人
                            entity.ArticleInfoID = ArticleID;
                            this.GlobalDataAccess.Update(entity);
                            msg += "审核通过成功";
                        }
                        this.GlobalDataAccess.CommitTransaction();
                        if (IsSuccess > 0)
                        {
                            return AjaxMsg.AjaxMsgs(AjaxStatusEnum.Success, "" + msg + "");
                        }
                        else
                        {
                            return AjaxMsg.AjaxMsgs(AjaxStatusEnum.Fail, "" + msg + "");
                        }
                    }
                    #endregion
                    
                    
                }
                #endregion

                #region  //审核不通过
                else
                {
                    #region  //批量审核
                    if (string.IsNullOrWhiteSpace(ColumnID))
                    {
                        foreach (string item in ArticleID.Split(','))
                        {
                            count++;
                            string[] strArticleID = item.Split('|');  //获取文章ID
                            if (dal.GetSub_Title(strArticleID[1], strArticleID[0]) > 0)   //该文章为副文章
                            {
                                i++;
                            }
                            else
                            {
                                entity.AuditingStatus = 1;  //审核不通过
                                entity.AuditingDate = DateTime.Now;  //审核日期
                                entity.AuditingPerson = user.UserName;  //审核人
                                entity.ArticleInfoID = strArticleID[0];
                                this.GlobalDataAccess.Update(entity);
                            }
                        }

                        this.GlobalDataAccess.CommitTransaction();

                        if (i > 0)
                        {
                            msg += "批量审核不通过" + (count - i) + "条成功," + i + "条失败";
                        }
                        else
                        {
                            msg += "批量审核不通过" + count + "条成功";
                        }
                        return AjaxMsg.AjaxMsgs(AjaxStatusEnum.Success, "" + msg + "");
                    }
                    #endregion

                    #region  //单文章审核
                    else
                    {
                        int IsSuccess = 1;
                        if (dal.GetSub_Title(ColumnID, ArticleID) > 0)  //该文章为副文章
                        {
                            IsSuccess = 0;
                            msg += "审核不通过失败";
                        }
                        else
                        {
                            entity.AuditingStatus = 1;  //审核通过
                            entity.AuditingDate = DateTime.Now;  //审核日期
                            entity.AuditingPerson = user.UserName;  //审核人
                            entity.ArticleInfoID = ArticleID;
                            this.GlobalDataAccess.Update(entity);
                            msg += "审核不通过成功";
                        }
                        this.GlobalDataAccess.CommitTransaction();
                        if (IsSuccess > 0)
                        {
                            return AjaxMsg.AjaxMsgs(AjaxStatusEnum.Success, "" + msg + "");
                        }
                        else
                        {
                            return AjaxMsg.AjaxMsgs(AjaxStatusEnum.Fail, "" + msg + "");
                        }
                    }
                    #endregion
                }
                #endregion

            }
            catch (Exception ex)
            {
                this.GlobalDataAccess.EndTransaction();
                return AjaxMsg.AjaxMsgs(AjaxStatusEnum.Error, ex.Message);
            }
        }
        #endregion

        [Login]
        #region // 文章批量移动
        public ActionResult ArticleMove(string ArticleIDstring, string ColumnID)
        {
            this.GlobalDataAccess.BeginTransaction();
            try
            {
                ArticleInfoEntity entity = new ArticleInfoEntity();  //原文章
                ArticleInColumnEntity ArtColumn = new ArticleInColumnEntity();  //副文章
                string ArticleID = ArticleIDstring.TrimEnd(',').Trim();
                foreach (var item in ArticleID.Split(','))
                {
                    string[] strArticleID = item.Split('|');  //获取文章ID
                    if (dal.GetSub_Title(strArticleID[1], strArticleID[0]) > 0)   //该文章为副文章
                    {
                        string sql = string.Format(@"
                                                    update 
                                                        T_ArticleInColumn 
                                                            set ColumnID='{2}' 
                                                    where 
                                                        ColumnID='{0}' 
                                                            and 
                                                        ArticleInfoID='{1}'",strArticleID[1],strArticleID[0],ColumnID);
                        this.GlobalDataAccess.ExecuteNonQuery(sql);
                    }
                    else      //原文章
                    {
                        entity.ColumnID = ColumnID;
                        entity.ArticleInfoID = strArticleID[0];
                        this.GlobalDataAccess.Update(entity);
                    }

                }
                this.GlobalDataAccess.CommitTransaction();
                return AjaxMsg.AjaxMsgs(AjaxStatusEnum.Success, "设置成功");
            }
            catch (Exception ex)
            {
                this.GlobalDataAccess.RollbackTransaction();
                return AjaxMsg.AjaxMsgs(AjaxStatusEnum.Error, ex.Message);
            }
        }
        #endregion

        [Login]
        #region  //多文章批量复制到单个栏目
        public ActionResult SingleArticleInColumn(string ArticleIDstring, string ColumnID)
        {
            this.GlobalDataAccess.BeginTransaction();
            try
            {

                ArticleInColumnEntity entity = new ArticleInColumnEntity();
                var i = 0;  //记录复制失败的条数
                var count = 0;      //选中复制的条数
                string ArticleID = ArticleIDstring.TrimEnd(',').Trim();
                foreach (var item in ArticleID.Split(','))
                {
                    count++;
                    string[] strArticleID = item.Split('|');  //获取文章ID
                    ArticleInColumnEntity artColumn = this.GlobalDataAccess.FindEntity(new ArticleInColumnEntity() { ColumnID = ColumnID, ArticleInfoID = strArticleID[0] });
                    if (artColumn != null)  //过滤掉文章隶属栏目表中出现重复数据
                    {
                        this.GlobalDataAccess.Delete(new ArticleInColumnEntity() { ArticleInfoID = strArticleID[0], ColumnID = ColumnID });
                    }
                    ArticleInfoEntity artEntity = this.GlobalDataAccess.FindEntity(new ArticleInfoEntity() { ArticleInfoID = strArticleID[0] });
                    if (artEntity.ColumnID == ColumnID)
                    {
                        i++;  //记录复制失败的条数

                    }
                    else
                    {
                        entity.ColumnID = ColumnID;
                        entity.ArticleInfoID = strArticleID[0];
                        this.GlobalDataAccess.AddNew(entity);
                    }

                }
                this.GlobalDataAccess.CommitTransaction();
                string msg = "";
                if (i > 0)
                {
                    msg += "批量复制" + (count - i) + "条成功," + i + "条失败";
                }
                else
                {
                    msg += "批量复制" + count + "条成功";
                }
                return AjaxMsg.AjaxMsgs(AjaxStatusEnum.Success, "" + msg + "");
            }
            catch (Exception ex)
            {
                this.GlobalDataAccess.RollbackTransaction();
                return AjaxMsg.AjaxMsgs(AjaxStatusEnum.Error, ex.Message);
            }
        }
        #endregion

        //#region  //单文章批量复制到多个栏目
        //public ActionResult MultiArticleInColumn(string ColumnIDstring, string ArticleID)
        //{
        //    this.GlobalDataAccess.BeginTransaction();
        //    try
        //    {
        //        this.GlobalDataAccess.Delete(new ArticleInColumnEntity() {ArticleInfoID=ArticleID });

        //        ArticleInColumnEntity entity = new ArticleInColumnEntity();
        //        string ColumnID = ColumnIDstring.TrimEnd(',').Trim();
        //        if (!string.IsNullOrWhiteSpace(ColumnID))
        //        {
        //            foreach (var item in ColumnID.Split(','))
        //            {
        //                entity.ColumnID = item;
        //                entity.ArticleInfoID = ArticleID;
        //                this.GlobalDataAccess.AddNew(entity);
        //            }
        //        }
        //        this.GlobalDataAccess.CommitTransaction();
        //        return AjaxMsg.AjaxMsgs(AjaxStatusEnum.Success, "设置成功");
        //    }
        //    catch (Exception ex)
        //    {
        //        this.GlobalDataAccess.RollbackTransaction();
        //        return AjaxMsg.AjaxMsgs(AjaxStatusEnum.Error, ex.Message);
        //    }
        //}
        //#endregion

            [Login]
        #region //文章隶属栏目列表
        public ActionResult ArticleColumnList(string ArticleInfoID)
        {
            if (string.IsNullOrWhiteSpace(ArticleInfoID))
            {
                return AjaxMsg.AjaxMsgs(AjaxStatusEnum.Error, "参数错误");
            }

            ArticleInfoEntity entity = this.GlobalDataAccess.FindEntity(new ArticleInfoEntity() { ArticleInfoID = ArticleInfoID });

            #region   //父栏目
            string sql = string.Format(@"select 
                                            ColumnID, ColumnName 
                                                from 
                                            T_Column 
                                                where 
                                        ColumnParentID is null and IsEnable = 1 and ColumnID <> '{0}'
                                                order by SortNumber", entity.ColumnID);
            List<ColumnEntity> list = this.GlobalDataAccess.FindEntities<ColumnEntity>(sql);
            ViewData["ColumnList"] = list;
            #endregion
            
            return View(entity);
        }
        #endregion

        #region  //附件添加
        public ActionResult dialog_attach()
        {
            return View();
        }
        #endregion

        [Login]
        #region //相关文章列表
        public ActionResult ArticleRrelated(int page = 1, string ArticleTitle = "", string ColumnTreeID = "", string ArticleInfoID = "")
        {

            #region  //父栏目
            string sql = string.Format(@"select ColumnID,ColumnTreeID,ColumnName from T_Column where ColumnParentID is null");
            List<ColumnEntity> list = this.GlobalDataAccess.FindEntities<ColumnEntity>(sql);
            ViewData["list"] = list;
            #endregion


            #region //文章相关
            List<ArticleRrelatedEntity> Rrelate = this.GlobalDataAccess.FindEntities(new ArticleRrelatedEntity() { ArticleInfoID = ArticleInfoID });
            ViewData["RrelateList"] = Rrelate;
            ViewBag.ArticleInfoID = ArticleInfoID;
            #endregion

            string strWhere = string.Format(@" where A.ArticleInfoID <> '{0}'", ArticleInfoID);

            if (!string.IsNullOrWhiteSpace(ColumnTreeID))
            {
                ColumnTreeID = ColumnTreeID.Replace("'", "''");
                strWhere += string.Format(@" and A.ColumnTreeID like '{0}%'", ColumnTreeID);
                ViewBag.ColumnTreeID = ColumnTreeID;
            }
            if (!string.IsNullOrWhiteSpace(ArticleTitle))
            {
                ArticleTitle = ArticleTitle.Replace("'", "''");
                strWhere += string.Format(@" and A.ArticleTitle like '%{0}%'", ArticleTitle);
                ViewBag.ArticleTitle = ArticleTitle;
            }


            string sqlcount = string.Format(@"select COUNT(0) from T_ArticleInfo A
	                                                    inner join T_Column B ON B.ColumnID=A.ColumnID
		                                                {0}", strWhere);
            int RecordCount = Convert.ToInt32(this.GlobalDataAccess.ExecuteScalar(sqlcount).ToString());

            Lib.UI.PageBase pagebase = new Lib.UI.PageBase();
            int PageSize = 8;
            pagebase.CurrentPageIndex = page;

            string pageSql = string.Format(@"select * from 
	                                                    (
		                                                    select A.*,B.ColumnName,ROW_NUMBER()over(order by A.createdate asc) as rowNo from 
		                                                    (
			                                                    T_ArticleInfo A
			                                                    inner join T_Column B ON A.ColumnID=B.ColumnID
		                                                    )
		                                                    {2}
	                                                    )tb where rowNo>{0} and rowNo<={1}", ((page - 1) * PageSize), (page * PageSize), strWhere);
            List<P_ArticleEntity> Articlelist = this.GlobalDataAccess.FindEntities<P_ArticleEntity>(pageSql);
            PageListModel<P_ArticleEntity> userList = new PageListModel<P_ArticleEntity>(Articlelist, page, PageSize, RecordCount);
            
            return View(userList);
        }
        #endregion

        [Login]
        #region  //相关文章设置
        public ActionResult ArticleRrelatedSet(string RrelatedArticleInfoIDstring, string ArticleInfoID)
        {
            ArticleRrelatedEntity entity = new ArticleRrelatedEntity();
            ArticleInfoEntity artInfo = this.GlobalDataAccess.FindEntity(new ArticleInfoEntity() {ArticleInfoID=ArticleInfoID });
            if (string.IsNullOrWhiteSpace(ArticleInfoID))
            {
                return AjaxMsg.AjaxMsgs(AjaxStatusEnum.Error, "参数错误");
            }
            if (artInfo == null)
            {
                return AjaxMsg.AjaxMsgs(AjaxStatusEnum.Error, "未找到该篇文章");
            }

            this.GlobalDataAccess.BeginTransaction();
            try
            {

                this.GlobalDataAccess.Delete(new ArticleRrelatedEntity() { ArticleInfoID = ArticleInfoID });  //删除文章相关

                string RrelatedArticleInfoID = RrelatedArticleInfoIDstring.TrimEnd(',').Trim();
                if (!string.IsNullOrWhiteSpace(RrelatedArticleInfoID))
                {
                    foreach (var item in RrelatedArticleInfoID.Split(','))
                    {
                        entity.RrelatedArticleInfoID = item;
                        entity.ArticleInfoID = ArticleInfoID;
                        this.GlobalDataAccess.AddNew(entity);
                    }
                }
                
                this.GlobalDataAccess.CommitTransaction();
                return AjaxMsg.AjaxMsgs(AjaxStatusEnum.Success, "设置成功");
            }
            catch (Exception ex)
            {
                this.GlobalDataAccess.RollbackTransaction();
                return AjaxMsg.AjaxMsgs(AjaxStatusEnum.Error, ex.Message);
            }
        }
        #endregion

        [Login]
        #region  //文章预览页面
        public ActionResult ArticlePreviews(string ArticleID,string ColumnID)
        {
            if (string.IsNullOrWhiteSpace(ArticleID))
            {
                return AjaxMsg.AjaxMsgs(AjaxStatusEnum.Error, "参数错误");
            }
            if (string.IsNullOrWhiteSpace(ColumnID))
            {
                return AjaxMsg.AjaxMsgs(AjaxStatusEnum.Error, "参数错误");
            }

            #region 文章详细信息
            string sql = string.Format(@"select * from  T_ArticleInfo where ArticleInfoID='{0}'", ArticleID);
            ArticleInfoEntity entity = this.GlobalDataAccess.FindEntity<ArticleInfoEntity>(sql);
            #endregion

            if (entity == null)
            {
                return AjaxMsg.AjaxMsgs(AjaxStatusEnum.Error, "未找到该文章");
            }

            #region  //栏目详细
            ColumnEntity column_Entity = this.GlobalDataAccess.FindEntity(new ColumnEntity() {ColumnID=ColumnID });
            ViewData["column_Entity"] = column_Entity;
            #endregion

            if (column_Entity == null)
            {
                return AjaxMsg.AjaxMsgs(AjaxStatusEnum.Error, "未找到该文章的隶属栏目");
            }

            #region  //遍历该文章下的附件
            string sql1 = string.Format(@"select 
                                            * 
                                        from 
                                            T_ArticleAttachment 
                                        where ArticleInfoID='{0}' and PhysicsName <> 'Face' order by CreateDate", ArticleID);
            List<ArticleAttachmentEntity> attachList = this.GlobalDataAccess.FindEntities<ArticleAttachmentEntity>(sql1);
            ViewData["attachList"] = attachList;
            #endregion

            
            return View(entity);
        }
        #endregion

    }
}