using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MV.PH.WebAdmin.Model.Article
{
    public class Article_dal:ControllerBase
    {
        #region  //通过文章ID获取文章相关数
        public int GetArticleRrelateByArticleID(string ArticleID)
        {
            string sql = string.Format(@"select count(0) from T_ArticleRrelated where ArticleInfoID='{0}'",ArticleID);
            int i = Convert.ToInt32(this.GlobalDataAccess.ExecuteScalar(sql));
            return i;
        }
        #endregion

        #region  //通过文章ID获取文章被复制的次数
        public int GetColumnCountByArticleID(string ArticleID)
        {
            string sql = string.Format(@"select count(0) from T_ArticleInColumn where ArticleInfoID='{0}'",ArticleID);
            int i = Convert.ToInt32(this.GlobalDataAccess.ExecuteScalar(sql));
            return i;
        }
        #endregion

        #region  //通过文章ID获取文章附件数
        public int GetAttachCountByArticleInfoID(string ArticleInfoID)
        {
            string sql = string.Format(@"select 
                                            count(0) 
                                         from 
                                            T_ArticleAttachment 
                                         where ArticleInfoID='{0}' and PhysicsName <> 'Face'", ArticleInfoID);
            int i = Convert.ToInt32(this.GlobalDataAccess.ExecuteScalar(sql));
            return i;
        }
        #endregion

        #region  //屏蔽词
        public string GetForbiddenWord()
        {
            string sql = string.Format(@"select ForbiddenWord from T_ForbiddenWord");
            string str = Convert.ToString(this.GlobalDataAccess.ExecuteScalar(sql));
            return str;
        }
        #endregion

        #region  //通过栏目ID及文章ID区分原文章
        public int GetOrginal_Title(string ColumnID,string ArticleInfoID)
        {
            string sql = string.Format(@"select 
                                            COUNT(0) 
                                         from 
                                            T_ArticleInfo 
                                         where 
                                            ColumnID='{0}' 
                                                and 
                                            ArticleInfoID='{1}'",ColumnID,ArticleInfoID);
            int i = Convert.ToInt32(this.GlobalDataAccess.ExecuteScalar(sql));
            return i;
        }
        #endregion

        #region  //通过栏目ID及文章ID区分副文章
        public int GetSub_Title(string ColumnID, string ArticleInfoID)
        {
            string sql = string.Format(@"select 
	                                        COUNT(0) 
                                        from 
	                                        T_ArticleInColumn 
                                        where 
	                                        ColumnID='{0}' 
		                                        and 
	                                        ArticleInfoID='{1}'", ColumnID, ArticleInfoID);
            int i = Convert.ToInt32(this.GlobalDataAccess.ExecuteScalar(sql));
            return i;
        }
        #endregion

    }
}