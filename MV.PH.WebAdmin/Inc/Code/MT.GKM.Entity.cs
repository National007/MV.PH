using System;
using System.Data;
using Lib.Data;
using Lib.Extend.Converter;

namespace MV.PH.Entity
{
    /// <summary>
    /// 【T_ArticleAttachment】 实体
    /// </summary>
    public class ArticleAttachmentEntity : EntityBase
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public ArticleAttachmentEntity() : base("T_ArticleAttachment")
        {
            this.AddField(new EntityField("ArticleAttachmentID", true));
            this.AddField(new EntityField("ArticleInfoID", false));
            this.AddField(new EntityField("FileName", false));
            this.AddField(new EntityField("PhysicsName", false));
            this.AddField(new EntityField("FilePriview", false));
            this.AddField(new EntityField("ThumbnailthumbnailThumbnail", false));
            this.AddField(new EntityField("FileSize", false));
            this.AddField(new EntityField("FileType", false));
            this.AddField(new EntityField("FileRemark", false));
            this.AddField(new EntityField("CreateDate", false));
        }


        /// <summary>
        /// 【ArticleAttachmentID】：【】 字段
        /// 数据类型：varchar；最大长度：32；是否可空：yes
        /// </summary>
        public string ArticleAttachmentID
        {
            get { return base["ArticleAttachmentID"].Value.ConvertToString(); }
            set { base["ArticleAttachmentID"].Value = value; }
        }

        /// <summary>
        /// 【ArticleAttachmentID】：【】 字段属性
        /// 数据类型：varchar；最大长度：32；是否可空：yes
        /// </summary>
        public EntityField ArticleAttachmentIDAttribute
        {
            get { return base["ArticleAttachmentID"]; }
            set { base["ArticleAttachmentID"] = value; }
        }

        /// <summary>
        /// 【ArticleInfoID】：【】 字段
        /// 数据类型：varchar；最大长度：32；是否可空：yes
        /// </summary>
        public string ArticleInfoID
        {
            get { return base["ArticleInfoID"].Value.ConvertToString(); }
            set { base["ArticleInfoID"].Value = value; }
        }

        /// <summary>
        /// 【ArticleInfoID】：【】 字段属性
        /// 数据类型：varchar；最大长度：32；是否可空：yes
        /// </summary>
        public EntityField ArticleInfoIDAttribute
        {
            get { return base["ArticleInfoID"]; }
            set { base["ArticleInfoID"] = value; }
        }

        /// <summary>
        /// 【FileName】：【】 字段
        /// 数据类型：varchar；最大长度：256；是否可空：no
        /// </summary>
        public string FileName
        {
            get { return base["FileName"].Value.ConvertToString(); }
            set { base["FileName"].Value = value; }
        }

        /// <summary>
        /// 【FileName】：【】 字段属性
        /// 数据类型：varchar；最大长度：256；是否可空：no
        /// </summary>
        public EntityField FileNameAttribute
        {
            get { return base["FileName"]; }
            set { base["FileName"] = value; }
        }

        /// <summary>
        /// 【PhysicsName】：【】 字段
        /// 数据类型：varchar；最大长度：256；是否可空：no
        /// </summary>
        public string PhysicsName
        {
            get { return base["PhysicsName"].Value.ConvertToString(); }
            set { base["PhysicsName"].Value = value; }
        }

        /// <summary>
        /// 【PhysicsName】：【】 字段属性
        /// 数据类型：varchar；最大长度：256；是否可空：no
        /// </summary>
        public EntityField PhysicsNameAttribute
        {
            get { return base["PhysicsName"]; }
            set { base["PhysicsName"] = value; }
        }

        /// <summary>
        /// 【FilePriview】：【】 字段
        /// 数据类型：varchar；最大长度：256；是否可空：no
        /// </summary>
        public string FilePriview
        {
            get { return base["FilePriview"].Value.ConvertToString(); }
            set { base["FilePriview"].Value = value; }
        }

        /// <summary>
        /// 【FilePriview】：【】 字段属性
        /// 数据类型：varchar；最大长度：256；是否可空：no
        /// </summary>
        public EntityField FilePriviewAttribute
        {
            get { return base["FilePriview"]; }
            set { base["FilePriview"] = value; }
        }

        /// <summary>
        /// 【ThumbnailthumbnailThumbnail】：【】 字段
        /// 数据类型：varchar；最大长度：256；是否可空：no
        /// </summary>
        public string ThumbnailthumbnailThumbnail
        {
            get { return base["ThumbnailthumbnailThumbnail"].Value.ConvertToString(); }
            set { base["ThumbnailthumbnailThumbnail"].Value = value; }
        }

        /// <summary>
        /// 【ThumbnailthumbnailThumbnail】：【】 字段属性
        /// 数据类型：varchar；最大长度：256；是否可空：no
        /// </summary>
        public EntityField ThumbnailthumbnailThumbnailAttribute
        {
            get { return base["ThumbnailthumbnailThumbnail"]; }
            set { base["ThumbnailthumbnailThumbnail"] = value; }
        }

        /// <summary>
        /// 【FileSize】：【】 字段
        /// 数据类型：float；最大长度：8；是否可空：no
        /// </summary>
        public string FileSize
        {
            get { return base["FileSize"].Value.ConvertToString(); }
            set { base["FileSize"].Value = value; }
        }

        /// <summary>
        /// 【FileSize】：【】 字段属性
        /// 数据类型：float；最大长度：8；是否可空：no
        /// </summary>
        public EntityField FileSizeAttribute
        {
            get { return base["FileSize"]; }
            set { base["FileSize"] = value; }
        }

        /// <summary>
        /// 【FileType】：【】 字段
        /// 数据类型：varchar；最大长度：10；是否可空：no
        /// </summary>
        public string FileType
        {
            get { return base["FileType"].Value.ConvertToString(); }
            set { base["FileType"].Value = value; }
        }

        /// <summary>
        /// 【FileType】：【】 字段属性
        /// 数据类型：varchar；最大长度：10；是否可空：no
        /// </summary>
        public EntityField FileTypeAttribute
        {
            get { return base["FileType"]; }
            set { base["FileType"] = value; }
        }

        /// <summary>
        /// 【FileRemark】：【】 字段
        /// 数据类型：varchar；最大长度：500；是否可空：no
        /// </summary>
        public string FileRemark
        {
            get { return base["FileRemark"].Value.ConvertToString(); }
            set { base["FileRemark"].Value = value; }
        }

        /// <summary>
        /// 【FileRemark】：【】 字段属性
        /// 数据类型：varchar；最大长度：500；是否可空：no
        /// </summary>
        public EntityField FileRemarkAttribute
        {
            get { return base["FileRemark"]; }
            set { base["FileRemark"] = value; }
        }

        /// <summary>
        /// 【CreateDate】：【】 字段
        /// 数据类型：datetime；最大长度：8；是否可空：no
        /// </summary>
        public DateTime CreateDate
        {
            get { return base["CreateDate"].Value.ConvertToDateTime(); }
            set { base["CreateDate"].Value = value; }
        }

        /// <summary>
        /// 【CreateDate】：【】 字段属性
        /// 数据类型：datetime；最大长度：8；是否可空：no
        /// </summary>
        public EntityField CreateDateAttribute
        {
            get { return base["CreateDate"]; }
            set { base["CreateDate"] = value; }
        }
    }

    /// <summary>
    /// 【T_ArticleInColumn】 实体
    /// </summary>
    public class ArticleInColumnEntity : EntityBase
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public ArticleInColumnEntity() : base("T_ArticleInColumn")
        {
            this.AddField(new EntityField("ColumnID", true));
            this.AddField(new EntityField("ArticleInfoID", true));
        }


        /// <summary>
        /// 【ColumnID】：【】 字段
        /// 数据类型：varchar；最大长度：32；是否可空：yes
        /// </summary>
        public string ColumnID
        {
            get { return base["ColumnID"].Value.ConvertToString(); }
            set { base["ColumnID"].Value = value; }
        }

        /// <summary>
        /// 【ColumnID】：【】 字段属性
        /// 数据类型：varchar；最大长度：32；是否可空：yes
        /// </summary>
        public EntityField ColumnIDAttribute
        {
            get { return base["ColumnID"]; }
            set { base["ColumnID"] = value; }
        }

        /// <summary>
        /// 【ArticleInfoID】：【】 字段
        /// 数据类型：varchar；最大长度：32；是否可空：yes
        /// </summary>
        public string ArticleInfoID
        {
            get { return base["ArticleInfoID"].Value.ConvertToString(); }
            set { base["ArticleInfoID"].Value = value; }
        }

        /// <summary>
        /// 【ArticleInfoID】：【】 字段属性
        /// 数据类型：varchar；最大长度：32；是否可空：yes
        /// </summary>
        public EntityField ArticleInfoIDAttribute
        {
            get { return base["ArticleInfoID"]; }
            set { base["ArticleInfoID"] = value; }
        }
    }

    /// <summary>
    /// 【T_ArticleInfo】 实体
    /// </summary>
    public class ArticleInfoEntity : EntityBase
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public ArticleInfoEntity() : base("T_ArticleInfo")
        {
            this.AddField(new EntityField("ArticleInfoID", true));
            this.AddField(new EntityField("ColumnID", false));
            this.AddField(new EntityField("ColumnTreeID", false));
            this.AddField(new EntityField("PhysicsName", false));
            this.AddField(new EntityField("ArticleNumber", false));
            this.AddField(new EntityField("ArticleTitle", false));
            this.AddField(new EntityField("ArticleContent", false));
            this.AddField(new EntityField("ArticleType", false));
            this.AddField(new EntityField("ArticleSource", false));
            this.AddField(new EntityField("IsToppest", false));
            this.AddField(new EntityField("IsRecommend", false));
            this.AddField(new EntityField("ReadCount", false));
            this.AddField(new EntityField("SortNumber", false));
            this.AddField(new EntityField("IsEnable", false));
            this.AddField(new EntityField("CreateDate", false));
            this.AddField(new EntityField("ModifyDate", false));
            this.AddField(new EntityField("Creator", false));
            this.AddField(new EntityField("Modifier", false));
            this.AddField(new EntityField("AuditingStatus", false));
            this.AddField(new EntityField("AuditingDate", false));
            this.AddField(new EntityField("AuditingPerson", false));
        }


        /// <summary>
        /// 【ArticleInfoID】：【】 字段
        /// 数据类型：varchar；最大长度：32；是否可空：yes
        /// </summary>
        public string ArticleInfoID
        {
            get { return base["ArticleInfoID"].Value.ConvertToString(); }
            set { base["ArticleInfoID"].Value = value; }
        }

        /// <summary>
        /// 【ArticleInfoID】：【】 字段属性
        /// 数据类型：varchar；最大长度：32；是否可空：yes
        /// </summary>
        public EntityField ArticleInfoIDAttribute
        {
            get { return base["ArticleInfoID"]; }
            set { base["ArticleInfoID"] = value; }
        }

        /// <summary>
        /// 【ColumnID】：【】 字段
        /// 数据类型：varchar；最大长度：32；是否可空：yes
        /// </summary>
        public string ColumnID
        {
            get { return base["ColumnID"].Value.ConvertToString(); }
            set { base["ColumnID"].Value = value; }
        }

        /// <summary>
        /// 【ColumnID】：【】 字段属性
        /// 数据类型：varchar；最大长度：32；是否可空：yes
        /// </summary>
        public EntityField ColumnIDAttribute
        {
            get { return base["ColumnID"]; }
            set { base["ColumnID"] = value; }
        }

        /// <summary>
        /// 【ColumnTreeID】：【】 字段
        /// 数据类型：varchar；最大长度：100；是否可空：no
        /// </summary>
        public string ColumnTreeID
        {
            get { return base["ColumnTreeID"].Value.ConvertToString(); }
            set { base["ColumnTreeID"].Value = value; }
        }

        /// <summary>
        /// 【ColumnTreeID】：【】 字段属性
        /// 数据类型：varchar；最大长度：100；是否可空：no
        /// </summary>
        public EntityField ColumnTreeIDAttribute
        {
            get { return base["ColumnTreeID"]; }
            set { base["ColumnTreeID"] = value; }
        }

        /// <summary>
        /// 【PhysicsName】：【】 字段
        /// 数据类型：varchar；最大长度：30；是否可空：no
        /// </summary>
        public string PhysicsName
        {
            get { return base["PhysicsName"].Value.ConvertToString(); }
            set { base["PhysicsName"].Value = value; }
        }

        /// <summary>
        /// 【PhysicsName】：【】 字段属性
        /// 数据类型：varchar；最大长度：30；是否可空：no
        /// </summary>
        public EntityField PhysicsNameAttribute
        {
            get { return base["PhysicsName"]; }
            set { base["PhysicsName"] = value; }
        }

        /// <summary>
        /// 【ArticleNumber】：【】 字段
        /// 数据类型：int；最大长度：4；是否可空：yes
        /// </summary>
        public int ArticleNumber
        {
            get { return base["ArticleNumber"].Value.ConvertToInt32(); }
            set { base["ArticleNumber"].Value = value; }
        }

        /// <summary>
        /// 【ArticleNumber】：【】 字段属性
        /// 数据类型：int；最大长度：4；是否可空：yes
        /// </summary>
        public EntityField ArticleNumberAttribute
        {
            get { return base["ArticleNumber"]; }
            set { base["ArticleNumber"] = value; }
        }

        /// <summary>
        /// 【ArticleTitle】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：yes
        /// </summary>
        public string ArticleTitle
        {
            get { return base["ArticleTitle"].Value.ConvertToString(); }
            set { base["ArticleTitle"].Value = value; }
        }

        /// <summary>
        /// 【ArticleTitle】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：yes
        /// </summary>
        public EntityField ArticleTitleAttribute
        {
            get { return base["ArticleTitle"]; }
            set { base["ArticleTitle"] = value; }
        }

        /// <summary>
        /// 【ArticleContent】：【】 字段
        /// 数据类型：text；最大长度：16；是否可空：no
        /// </summary>
        public string ArticleContent
        {
            get { return base["ArticleContent"].Value.ConvertToString(); }
            set { base["ArticleContent"].Value = value; }
        }

        /// <summary>
        /// 【ArticleContent】：【】 字段属性
        /// 数据类型：text；最大长度：16；是否可空：no
        /// </summary>
        public EntityField ArticleContentAttribute
        {
            get { return base["ArticleContent"]; }
            set { base["ArticleContent"] = value; }
        }

        /// <summary>
        /// 【ArticleType】：【】 字段
        /// 数据类型：varchar；最大长度：20；是否可空：no
        /// </summary>
        public string ArticleType
        {
            get { return base["ArticleType"].Value.ConvertToString(); }
            set { base["ArticleType"].Value = value; }
        }

        /// <summary>
        /// 【ArticleType】：【】 字段属性
        /// 数据类型：varchar；最大长度：20；是否可空：no
        /// </summary>
        public EntityField ArticleTypeAttribute
        {
            get { return base["ArticleType"]; }
            set { base["ArticleType"] = value; }
        }

        /// <summary>
        /// 【ArticleSource】：【】 字段
        /// 数据类型：varchar；最大长度：50；是否可空：no
        /// </summary>
        public string ArticleSource
        {
            get { return base["ArticleSource"].Value.ConvertToString(); }
            set { base["ArticleSource"].Value = value; }
        }

        /// <summary>
        /// 【ArticleSource】：【】 字段属性
        /// 数据类型：varchar；最大长度：50；是否可空：no
        /// </summary>
        public EntityField ArticleSourceAttribute
        {
            get { return base["ArticleSource"]; }
            set { base["ArticleSource"] = value; }
        }

        /// <summary>
        /// 【IsToppest】：【】 字段
        /// 数据类型：int；最大长度：4；是否可空：yes
        /// </summary>
        public int IsToppest
        {
            get { return base["IsToppest"].Value.ConvertToInt32(); }
            set { base["IsToppest"].Value = value; }
        }

        /// <summary>
        /// 【IsToppest】：【】 字段属性
        /// 数据类型：int；最大长度：4；是否可空：yes
        /// </summary>
        public EntityField IsToppestAttribute
        {
            get { return base["IsToppest"]; }
            set { base["IsToppest"] = value; }
        }

        /// <summary>
        /// 【IsRecommend】：【】 字段
        /// 数据类型：int；最大长度：4；是否可空：no
        /// </summary>
        public int IsRecommend
        {
            get { return base["IsRecommend"].Value.ConvertToInt32(); }
            set { base["IsRecommend"].Value = value; }
        }

        /// <summary>
        /// 【IsRecommend】：【】 字段属性
        /// 数据类型：int；最大长度：4；是否可空：no
        /// </summary>
        public EntityField IsRecommendAttribute
        {
            get { return base["IsRecommend"]; }
            set { base["IsRecommend"] = value; }
        }

        /// <summary>
        /// 【ReadCount】：【】 字段
        /// 数据类型：int；最大长度：4；是否可空：yes
        /// </summary>
        public int ReadCount
        {
            get { return base["ReadCount"].Value.ConvertToInt32(); }
            set { base["ReadCount"].Value = value; }
        }

        /// <summary>
        /// 【ReadCount】：【】 字段属性
        /// 数据类型：int；最大长度：4；是否可空：yes
        /// </summary>
        public EntityField ReadCountAttribute
        {
            get { return base["ReadCount"]; }
            set { base["ReadCount"] = value; }
        }

        /// <summary>
        /// 【SortNumber】：【】 字段
        /// 数据类型：int；最大长度：4；是否可空：no
        /// </summary>
        public int SortNumber
        {
            get { return base["SortNumber"].Value.ConvertToInt32(); }
            set { base["SortNumber"].Value = value; }
        }

        /// <summary>
        /// 【SortNumber】：【】 字段属性
        /// 数据类型：int；最大长度：4；是否可空：no
        /// </summary>
        public EntityField SortNumberAttribute
        {
            get { return base["SortNumber"]; }
            set { base["SortNumber"] = value; }
        }

        /// <summary>
        /// 【IsEnable】：【】 字段
        /// 数据类型：int；最大长度：4；是否可空：no
        /// </summary>
        public int IsEnable
        {
            get { return base["IsEnable"].Value.ConvertToInt32(); }
            set { base["IsEnable"].Value = value; }
        }

        /// <summary>
        /// 【IsEnable】：【】 字段属性
        /// 数据类型：int；最大长度：4；是否可空：no
        /// </summary>
        public EntityField IsEnableAttribute
        {
            get { return base["IsEnable"]; }
            set { base["IsEnable"] = value; }
        }

        /// <summary>
        /// 【CreateDate】：【】 字段
        /// 数据类型：datetime；最大长度：8；是否可空：yes
        /// </summary>
        public DateTime CreateDate
        {
            get { return base["CreateDate"].Value.ConvertToDateTime(); }
            set { base["CreateDate"].Value = value; }
        }

        /// <summary>
        /// 【CreateDate】：【】 字段属性
        /// 数据类型：datetime；最大长度：8；是否可空：yes
        /// </summary>
        public EntityField CreateDateAttribute
        {
            get { return base["CreateDate"]; }
            set { base["CreateDate"] = value; }
        }

        /// <summary>
        /// 【ModifyDate】：【】 字段
        /// 数据类型：datetime；最大长度：8；是否可空：no
        /// </summary>
        public DateTime ModifyDate
        {
            get { return base["ModifyDate"].Value.ConvertToDateTime(); }
            set { base["ModifyDate"].Value = value; }
        }

        /// <summary>
        /// 【ModifyDate】：【】 字段属性
        /// 数据类型：datetime；最大长度：8；是否可空：no
        /// </summary>
        public EntityField ModifyDateAttribute
        {
            get { return base["ModifyDate"]; }
            set { base["ModifyDate"] = value; }
        }

        /// <summary>
        /// 【Creator】：【】 字段
        /// 数据类型：varchar；最大长度：60；是否可空：no
        /// </summary>
        public string Creator
        {
            get { return base["Creator"].Value.ConvertToString(); }
            set { base["Creator"].Value = value; }
        }

        /// <summary>
        /// 【Creator】：【】 字段属性
        /// 数据类型：varchar；最大长度：60；是否可空：no
        /// </summary>
        public EntityField CreatorAttribute
        {
            get { return base["Creator"]; }
            set { base["Creator"] = value; }
        }

        /// <summary>
        /// 【Modifier】：【】 字段
        /// 数据类型：varchar；最大长度：60；是否可空：no
        /// </summary>
        public string Modifier
        {
            get { return base["Modifier"].Value.ConvertToString(); }
            set { base["Modifier"].Value = value; }
        }

        /// <summary>
        /// 【Modifier】：【】 字段属性
        /// 数据类型：varchar；最大长度：60；是否可空：no
        /// </summary>
        public EntityField ModifierAttribute
        {
            get { return base["Modifier"]; }
            set { base["Modifier"] = value; }
        }

        /// <summary>
        /// 【AuditingStatus】：【】 字段
        /// 数据类型：int；最大长度：4；是否可空：no
        /// </summary>
        public int AuditingStatus
        {
            get { return base["AuditingStatus"].Value.ConvertToInt32(); }
            set { base["AuditingStatus"].Value = value; }
        }

        /// <summary>
        /// 【AuditingStatus】：【】 字段属性
        /// 数据类型：int；最大长度：4；是否可空：no
        /// </summary>
        public EntityField AuditingStatusAttribute
        {
            get { return base["AuditingStatus"]; }
            set { base["AuditingStatus"] = value; }
        }

        /// <summary>
        /// 【AuditingDate】：【】 字段
        /// 数据类型：datetime；最大长度：8；是否可空：no
        /// </summary>
        public DateTime AuditingDate
        {
            get { return base["AuditingDate"].Value.ConvertToDateTime(); }
            set { base["AuditingDate"].Value = value; }
        }

        /// <summary>
        /// 【AuditingDate】：【】 字段属性
        /// 数据类型：datetime；最大长度：8；是否可空：no
        /// </summary>
        public EntityField AuditingDateAttribute
        {
            get { return base["AuditingDate"]; }
            set { base["AuditingDate"] = value; }
        }

        /// <summary>
        /// 【AuditingPerson】：【】 字段
        /// 数据类型：varchar；最大长度：80；是否可空：no
        /// </summary>
        public string AuditingPerson
        {
            get { return base["AuditingPerson"].Value.ConvertToString(); }
            set { base["AuditingPerson"].Value = value; }
        }

        /// <summary>
        /// 【AuditingPerson】：【】 字段属性
        /// 数据类型：varchar；最大长度：80；是否可空：no
        /// </summary>
        public EntityField AuditingPersonAttribute
        {
            get { return base["AuditingPerson"]; }
            set { base["AuditingPerson"] = value; }
        }
    }

    /// <summary>
    /// 【T_ArticleRrelated】 实体
    /// </summary>
    public class ArticleRrelatedEntity : EntityBase
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public ArticleRrelatedEntity() : base("T_ArticleRrelated")
        {
            this.AddField(new EntityField("ArticleInfoID", false));
            this.AddField(new EntityField("RrelatedArticleInfoID", false));
        }


        /// <summary>
        /// 【ArticleInfoID】：【】 字段
        /// 数据类型：varchar；最大长度：32；是否可空：yes
        /// </summary>
        public string ArticleInfoID
        {
            get { return base["ArticleInfoID"].Value.ConvertToString(); }
            set { base["ArticleInfoID"].Value = value; }
        }

        /// <summary>
        /// 【ArticleInfoID】：【】 字段属性
        /// 数据类型：varchar；最大长度：32；是否可空：yes
        /// </summary>
        public EntityField ArticleInfoIDAttribute
        {
            get { return base["ArticleInfoID"]; }
            set { base["ArticleInfoID"] = value; }
        }

        /// <summary>
        /// 【RrelatedArticleInfoID】：【】 字段
        /// 数据类型：varchar；最大长度：32；是否可空：yes
        /// </summary>
        public string RrelatedArticleInfoID
        {
            get { return base["RrelatedArticleInfoID"].Value.ConvertToString(); }
            set { base["RrelatedArticleInfoID"].Value = value; }
        }

        /// <summary>
        /// 【RrelatedArticleInfoID】：【】 字段属性
        /// 数据类型：varchar；最大长度：32；是否可空：yes
        /// </summary>
        public EntityField RrelatedArticleInfoIDAttribute
        {
            get { return base["RrelatedArticleInfoID"]; }
            set { base["RrelatedArticleInfoID"] = value; }
        }
    }

    /// <summary>
    /// 【T_CJ_DATA】 实体
    /// </summary>
    public class CJ_DATAEntity : EntityBase
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public CJ_DATAEntity() : base("T_CJ_DATA")
        {
            this.AddField(new EntityField("DataID", true));
            this.AddField(new EntityField("ImportDate", false));
            this.AddField(new EntityField("ImportBatch", false));
            this.AddField(new EntityField("ImportRemark", false));
            this.AddField(new EntityField("ID", false));
            this.AddField(new EntityField("年份", false));
            this.AddField(new EntityField("省份", false));
            this.AddField(new EntityField("承考院系", false));
            this.AddField(new EntityField("考生号", false));
            this.AddField(new EntityField("准考证号", false));
            this.AddField(new EntityField("身份证号", false));
            this.AddField(new EntityField("姓名", false));
            this.AddField(new EntityField("性别", false));
            this.AddField(new EntityField("毕业中学", false));
            this.AddField(new EntityField("邮政编码", false));
            this.AddField(new EntityField("通信地址", false));
            this.AddField(new EntityField("联系电话", false));
            this.AddField(new EntityField("收件人", false));
            this.AddField(new EntityField("报考专业", false));
            this.AddField(new EntityField("科目1", false));
            this.AddField(new EntityField("科目2", false));
            this.AddField(new EntityField("素描试卷编号", false));
            this.AddField(new EntityField("色彩试卷编号", false));
            this.AddField(new EntityField("音乐舞蹈进场号", false));
            this.AddField(new EntityField("素描备注", false));
            this.AddField(new EntityField("色彩备注", false));
            this.AddField(new EntityField("备注", false));
            this.AddField(new EntityField("总成绩", false));
            this.AddField(new EntityField("排名", false));
            this.AddField(new EntityField("是否合格", false));
        }


        /// <summary>
        /// 【DataID】：【】 字段
        /// 数据类型：varchar；最大长度：32；是否可空：yes
        /// </summary>
        public string DataID
        {
            get { return base["DataID"].Value.ConvertToString(); }
            set { base["DataID"].Value = value; }
        }

        /// <summary>
        /// 【DataID】：【】 字段属性
        /// 数据类型：varchar；最大长度：32；是否可空：yes
        /// </summary>
        public EntityField DataIDAttribute
        {
            get { return base["DataID"]; }
            set { base["DataID"] = value; }
        }

        /// <summary>
        /// 【ImportDate】：【】 字段
        /// 数据类型：datetime；最大长度：8；是否可空：yes
        /// </summary>
        public DateTime ImportDate
        {
            get { return base["ImportDate"].Value.ConvertToDateTime(); }
            set { base["ImportDate"].Value = value; }
        }

        /// <summary>
        /// 【ImportDate】：【】 字段属性
        /// 数据类型：datetime；最大长度：8；是否可空：yes
        /// </summary>
        public EntityField ImportDateAttribute
        {
            get { return base["ImportDate"]; }
            set { base["ImportDate"] = value; }
        }

        /// <summary>
        /// 【ImportBatch】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string ImportBatch
        {
            get { return base["ImportBatch"].Value.ConvertToString(); }
            set { base["ImportBatch"].Value = value; }
        }

        /// <summary>
        /// 【ImportBatch】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField ImportBatchAttribute
        {
            get { return base["ImportBatch"]; }
            set { base["ImportBatch"] = value; }
        }

        /// <summary>
        /// 【ImportRemark】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string ImportRemark
        {
            get { return base["ImportRemark"].Value.ConvertToString(); }
            set { base["ImportRemark"].Value = value; }
        }

        /// <summary>
        /// 【ImportRemark】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField ImportRemarkAttribute
        {
            get { return base["ImportRemark"]; }
            set { base["ImportRemark"] = value; }
        }

        /// <summary>
        /// 【ID】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string ID
        {
            get { return base["ID"].Value.ConvertToString(); }
            set { base["ID"].Value = value; }
        }

        /// <summary>
        /// 【ID】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField IDAttribute
        {
            get { return base["ID"]; }
            set { base["ID"] = value; }
        }

        /// <summary>
        /// 【年份】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string 年份
        {
            get { return base["年份"].Value.ConvertToString(); }
            set { base["年份"].Value = value; }
        }

        /// <summary>
        /// 【年份】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField 年份Attribute
        {
            get { return base["年份"]; }
            set { base["年份"] = value; }
        }

        /// <summary>
        /// 【省份】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string 省份
        {
            get { return base["省份"].Value.ConvertToString(); }
            set { base["省份"].Value = value; }
        }

        /// <summary>
        /// 【省份】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField 省份Attribute
        {
            get { return base["省份"]; }
            set { base["省份"] = value; }
        }

        /// <summary>
        /// 【承考院系】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string 承考院系
        {
            get { return base["承考院系"].Value.ConvertToString(); }
            set { base["承考院系"].Value = value; }
        }

        /// <summary>
        /// 【承考院系】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField 承考院系Attribute
        {
            get { return base["承考院系"]; }
            set { base["承考院系"] = value; }
        }

        /// <summary>
        /// 【考生号】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string 考生号
        {
            get { return base["考生号"].Value.ConvertToString(); }
            set { base["考生号"].Value = value; }
        }

        /// <summary>
        /// 【考生号】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField 考生号Attribute
        {
            get { return base["考生号"]; }
            set { base["考生号"] = value; }
        }

        /// <summary>
        /// 【准考证号】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string 准考证号
        {
            get { return base["准考证号"].Value.ConvertToString(); }
            set { base["准考证号"].Value = value; }
        }

        /// <summary>
        /// 【准考证号】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField 准考证号Attribute
        {
            get { return base["准考证号"]; }
            set { base["准考证号"] = value; }
        }

        /// <summary>
        /// 【身份证号】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string 身份证号
        {
            get { return base["身份证号"].Value.ConvertToString(); }
            set { base["身份证号"].Value = value; }
        }

        /// <summary>
        /// 【身份证号】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField 身份证号Attribute
        {
            get { return base["身份证号"]; }
            set { base["身份证号"] = value; }
        }

        /// <summary>
        /// 【姓名】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string 姓名
        {
            get { return base["姓名"].Value.ConvertToString(); }
            set { base["姓名"].Value = value; }
        }

        /// <summary>
        /// 【姓名】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField 姓名Attribute
        {
            get { return base["姓名"]; }
            set { base["姓名"] = value; }
        }

        /// <summary>
        /// 【性别】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string 性别
        {
            get { return base["性别"].Value.ConvertToString(); }
            set { base["性别"].Value = value; }
        }

        /// <summary>
        /// 【性别】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField 性别Attribute
        {
            get { return base["性别"]; }
            set { base["性别"] = value; }
        }

        /// <summary>
        /// 【毕业中学】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string 毕业中学
        {
            get { return base["毕业中学"].Value.ConvertToString(); }
            set { base["毕业中学"].Value = value; }
        }

        /// <summary>
        /// 【毕业中学】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField 毕业中学Attribute
        {
            get { return base["毕业中学"]; }
            set { base["毕业中学"] = value; }
        }

        /// <summary>
        /// 【邮政编码】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string 邮政编码
        {
            get { return base["邮政编码"].Value.ConvertToString(); }
            set { base["邮政编码"].Value = value; }
        }

        /// <summary>
        /// 【邮政编码】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField 邮政编码Attribute
        {
            get { return base["邮政编码"]; }
            set { base["邮政编码"] = value; }
        }

        /// <summary>
        /// 【通信地址】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string 通信地址
        {
            get { return base["通信地址"].Value.ConvertToString(); }
            set { base["通信地址"].Value = value; }
        }

        /// <summary>
        /// 【通信地址】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField 通信地址Attribute
        {
            get { return base["通信地址"]; }
            set { base["通信地址"] = value; }
        }

        /// <summary>
        /// 【联系电话】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string 联系电话
        {
            get { return base["联系电话"].Value.ConvertToString(); }
            set { base["联系电话"].Value = value; }
        }

        /// <summary>
        /// 【联系电话】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField 联系电话Attribute
        {
            get { return base["联系电话"]; }
            set { base["联系电话"] = value; }
        }

        /// <summary>
        /// 【收件人】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string 收件人
        {
            get { return base["收件人"].Value.ConvertToString(); }
            set { base["收件人"].Value = value; }
        }

        /// <summary>
        /// 【收件人】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField 收件人Attribute
        {
            get { return base["收件人"]; }
            set { base["收件人"] = value; }
        }

        /// <summary>
        /// 【报考专业】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string 报考专业
        {
            get { return base["报考专业"].Value.ConvertToString(); }
            set { base["报考专业"].Value = value; }
        }

        /// <summary>
        /// 【报考专业】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField 报考专业Attribute
        {
            get { return base["报考专业"]; }
            set { base["报考专业"] = value; }
        }

        /// <summary>
        /// 【科目1】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string 科目1
        {
            get { return base["科目1"].Value.ConvertToString(); }
            set { base["科目1"].Value = value; }
        }

        /// <summary>
        /// 【科目1】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField 科目1Attribute
        {
            get { return base["科目1"]; }
            set { base["科目1"] = value; }
        }

        /// <summary>
        /// 【科目2】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string 科目2
        {
            get { return base["科目2"].Value.ConvertToString(); }
            set { base["科目2"].Value = value; }
        }

        /// <summary>
        /// 【科目2】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField 科目2Attribute
        {
            get { return base["科目2"]; }
            set { base["科目2"] = value; }
        }

        /// <summary>
        /// 【素描试卷编号】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string 素描试卷编号
        {
            get { return base["素描试卷编号"].Value.ConvertToString(); }
            set { base["素描试卷编号"].Value = value; }
        }

        /// <summary>
        /// 【素描试卷编号】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField 素描试卷编号Attribute
        {
            get { return base["素描试卷编号"]; }
            set { base["素描试卷编号"] = value; }
        }

        /// <summary>
        /// 【色彩试卷编号】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string 色彩试卷编号
        {
            get { return base["色彩试卷编号"].Value.ConvertToString(); }
            set { base["色彩试卷编号"].Value = value; }
        }

        /// <summary>
        /// 【色彩试卷编号】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField 色彩试卷编号Attribute
        {
            get { return base["色彩试卷编号"]; }
            set { base["色彩试卷编号"] = value; }
        }

        /// <summary>
        /// 【音乐舞蹈进场号】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string 音乐舞蹈进场号
        {
            get { return base["音乐舞蹈进场号"].Value.ConvertToString(); }
            set { base["音乐舞蹈进场号"].Value = value; }
        }

        /// <summary>
        /// 【音乐舞蹈进场号】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField 音乐舞蹈进场号Attribute
        {
            get { return base["音乐舞蹈进场号"]; }
            set { base["音乐舞蹈进场号"] = value; }
        }

        /// <summary>
        /// 【素描备注】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string 素描备注
        {
            get { return base["素描备注"].Value.ConvertToString(); }
            set { base["素描备注"].Value = value; }
        }

        /// <summary>
        /// 【素描备注】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField 素描备注Attribute
        {
            get { return base["素描备注"]; }
            set { base["素描备注"] = value; }
        }

        /// <summary>
        /// 【色彩备注】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string 色彩备注
        {
            get { return base["色彩备注"].Value.ConvertToString(); }
            set { base["色彩备注"].Value = value; }
        }

        /// <summary>
        /// 【色彩备注】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField 色彩备注Attribute
        {
            get { return base["色彩备注"]; }
            set { base["色彩备注"] = value; }
        }

        /// <summary>
        /// 【备注】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string 备注
        {
            get { return base["备注"].Value.ConvertToString(); }
            set { base["备注"].Value = value; }
        }

        /// <summary>
        /// 【备注】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField 备注Attribute
        {
            get { return base["备注"]; }
            set { base["备注"] = value; }
        }

        /// <summary>
        /// 【总成绩】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string 总成绩
        {
            get { return base["总成绩"].Value.ConvertToString(); }
            set { base["总成绩"].Value = value; }
        }

        /// <summary>
        /// 【总成绩】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField 总成绩Attribute
        {
            get { return base["总成绩"]; }
            set { base["总成绩"] = value; }
        }

        /// <summary>
        /// 【排名】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string 排名
        {
            get { return base["排名"].Value.ConvertToString(); }
            set { base["排名"].Value = value; }
        }

        /// <summary>
        /// 【排名】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField 排名Attribute
        {
            get { return base["排名"]; }
            set { base["排名"] = value; }
        }

        /// <summary>
        /// 【是否合格】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string 是否合格
        {
            get { return base["是否合格"].Value.ConvertToString(); }
            set { base["是否合格"].Value = value; }
        }

        /// <summary>
        /// 【是否合格】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField 是否合格Attribute
        {
            get { return base["是否合格"]; }
            set { base["是否合格"] = value; }
        }
    }

    /// <summary>
    /// 【T_Column】 实体
    /// </summary>
    public class ColumnEntity : EntityBase
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public ColumnEntity() : base("T_Column")
        {
            this.AddField(new EntityField("ColumnID", true));
            this.AddField(new EntityField("ColumnName", false));
            this.AddField(new EntityField("ColumnParentID", false));
            this.AddField(new EntityField("ColumnTreeID", false));
            this.AddField(new EntityField("PhysicsName", false));
            this.AddField(new EntityField("ColumnGrouping", false));
            this.AddField(new EntityField("ColumnType", false));
            this.AddField(new EntityField("ColumnBigIcon", false));
            this.AddField(new EntityField("ColumnSmallIcon", false));
            this.AddField(new EntityField("ManualLink", false));
            this.AddField(new EntityField("OpenTarget", false));
            this.AddField(new EntityField("SortNumber", false));
            this.AddField(new EntityField("IsEnable", false));
            this.AddField(new EntityField("IsNeedAuditing", false));
            this.AddField(new EntityField("IsNavigation", false));
        }


        /// <summary>
        /// 【ColumnID】：【】 字段
        /// 数据类型：varchar；最大长度：32；是否可空：yes
        /// </summary>
        public string ColumnID
        {
            get { return base["ColumnID"].Value.ConvertToString(); }
            set { base["ColumnID"].Value = value; }
        }

        /// <summary>
        /// 【ColumnID】：【】 字段属性
        /// 数据类型：varchar；最大长度：32；是否可空：yes
        /// </summary>
        public EntityField ColumnIDAttribute
        {
            get { return base["ColumnID"]; }
            set { base["ColumnID"] = value; }
        }

        /// <summary>
        /// 【ColumnName】：【】 字段
        /// 数据类型：varchar；最大长度：50；是否可空：yes
        /// </summary>
        public string ColumnName
        {
            get { return base["ColumnName"].Value.ConvertToString(); }
            set { base["ColumnName"].Value = value; }
        }

        /// <summary>
        /// 【ColumnName】：【】 字段属性
        /// 数据类型：varchar；最大长度：50；是否可空：yes
        /// </summary>
        public EntityField ColumnNameAttribute
        {
            get { return base["ColumnName"]; }
            set { base["ColumnName"] = value; }
        }

        /// <summary>
        /// 【ColumnParentID】：【】 字段
        /// 数据类型：varchar；最大长度：32；是否可空：no
        /// </summary>
        public string ColumnParentID
        {
            get { return base["ColumnParentID"].Value.ConvertToString(); }
            set { base["ColumnParentID"].Value = value; }
        }

        /// <summary>
        /// 【ColumnParentID】：【】 字段属性
        /// 数据类型：varchar；最大长度：32；是否可空：no
        /// </summary>
        public EntityField ColumnParentIDAttribute
        {
            get { return base["ColumnParentID"]; }
            set { base["ColumnParentID"] = value; }
        }

        /// <summary>
        /// 【ColumnTreeID】：【】 字段
        /// 数据类型：varchar；最大长度：20；是否可空：no
        /// </summary>
        public string ColumnTreeID
        {
            get { return base["ColumnTreeID"].Value.ConvertToString(); }
            set { base["ColumnTreeID"].Value = value; }
        }

        /// <summary>
        /// 【ColumnTreeID】：【】 字段属性
        /// 数据类型：varchar；最大长度：20；是否可空：no
        /// </summary>
        public EntityField ColumnTreeIDAttribute
        {
            get { return base["ColumnTreeID"]; }
            set { base["ColumnTreeID"] = value; }
        }

        /// <summary>
        /// 【PhysicsName】：【】 字段
        /// 数据类型：varchar；最大长度：30；是否可空：no
        /// </summary>
        public string PhysicsName
        {
            get { return base["PhysicsName"].Value.ConvertToString(); }
            set { base["PhysicsName"].Value = value; }
        }

        /// <summary>
        /// 【PhysicsName】：【】 字段属性
        /// 数据类型：varchar；最大长度：30；是否可空：no
        /// </summary>
        public EntityField PhysicsNameAttribute
        {
            get { return base["PhysicsName"]; }
            set { base["PhysicsName"] = value; }
        }

        /// <summary>
        /// 【ColumnGrouping】：【】 字段
        /// 数据类型：varchar；最大长度：30；是否可空：no
        /// </summary>
        public string ColumnGrouping
        {
            get { return base["ColumnGrouping"].Value.ConvertToString(); }
            set { base["ColumnGrouping"].Value = value; }
        }

        /// <summary>
        /// 【ColumnGrouping】：【】 字段属性
        /// 数据类型：varchar；最大长度：30；是否可空：no
        /// </summary>
        public EntityField ColumnGroupingAttribute
        {
            get { return base["ColumnGrouping"]; }
            set { base["ColumnGrouping"] = value; }
        }

        /// <summary>
        /// 【ColumnType】：【】 字段
        /// 数据类型：varchar；最大长度：20；是否可空：yes
        /// </summary>
        public string ColumnType
        {
            get { return base["ColumnType"].Value.ConvertToString(); }
            set { base["ColumnType"].Value = value; }
        }

        /// <summary>
        /// 【ColumnType】：【】 字段属性
        /// 数据类型：varchar；最大长度：20；是否可空：yes
        /// </summary>
        public EntityField ColumnTypeAttribute
        {
            get { return base["ColumnType"]; }
            set { base["ColumnType"] = value; }
        }

        /// <summary>
        /// 【ColumnBigIcon】：【】 字段
        /// 数据类型：varchar；最大长度：256；是否可空：no
        /// </summary>
        public string ColumnBigIcon
        {
            get { return base["ColumnBigIcon"].Value.ConvertToString(); }
            set { base["ColumnBigIcon"].Value = value; }
        }

        /// <summary>
        /// 【ColumnBigIcon】：【】 字段属性
        /// 数据类型：varchar；最大长度：256；是否可空：no
        /// </summary>
        public EntityField ColumnBigIconAttribute
        {
            get { return base["ColumnBigIcon"]; }
            set { base["ColumnBigIcon"] = value; }
        }

        /// <summary>
        /// 【ColumnSmallIcon】：【】 字段
        /// 数据类型：varchar；最大长度：256；是否可空：no
        /// </summary>
        public string ColumnSmallIcon
        {
            get { return base["ColumnSmallIcon"].Value.ConvertToString(); }
            set { base["ColumnSmallIcon"].Value = value; }
        }

        /// <summary>
        /// 【ColumnSmallIcon】：【】 字段属性
        /// 数据类型：varchar；最大长度：256；是否可空：no
        /// </summary>
        public EntityField ColumnSmallIconAttribute
        {
            get { return base["ColumnSmallIcon"]; }
            set { base["ColumnSmallIcon"] = value; }
        }

        /// <summary>
        /// 【ManualLink】：【】 字段
        /// 数据类型：varchar；最大长度：256；是否可空：no
        /// </summary>
        public string ManualLink
        {
            get { return base["ManualLink"].Value.ConvertToString(); }
            set { base["ManualLink"].Value = value; }
        }

        /// <summary>
        /// 【ManualLink】：【】 字段属性
        /// 数据类型：varchar；最大长度：256；是否可空：no
        /// </summary>
        public EntityField ManualLinkAttribute
        {
            get { return base["ManualLink"]; }
            set { base["ManualLink"] = value; }
        }

        /// <summary>
        /// 【OpenTarget】：【】 字段
        /// 数据类型：varchar；最大长度：20；是否可空：no
        /// </summary>
        public string OpenTarget
        {
            get { return base["OpenTarget"].Value.ConvertToString(); }
            set { base["OpenTarget"].Value = value; }
        }

        /// <summary>
        /// 【OpenTarget】：【】 字段属性
        /// 数据类型：varchar；最大长度：20；是否可空：no
        /// </summary>
        public EntityField OpenTargetAttribute
        {
            get { return base["OpenTarget"]; }
            set { base["OpenTarget"] = value; }
        }

        /// <summary>
        /// 【SortNumber】：【】 字段
        /// 数据类型：int；最大长度：4；是否可空：yes
        /// </summary>
        public int SortNumber
        {
            get { return base["SortNumber"].Value.ConvertToInt32(); }
            set { base["SortNumber"].Value = value; }
        }

        /// <summary>
        /// 【SortNumber】：【】 字段属性
        /// 数据类型：int；最大长度：4；是否可空：yes
        /// </summary>
        public EntityField SortNumberAttribute
        {
            get { return base["SortNumber"]; }
            set { base["SortNumber"] = value; }
        }

        /// <summary>
        /// 【IsEnable】：【】 字段
        /// 数据类型：int；最大长度：4；是否可空：yes
        /// </summary>
        public int IsEnable
        {
            get { return base["IsEnable"].Value.ConvertToInt32(); }
            set { base["IsEnable"].Value = value; }
        }

        /// <summary>
        /// 【IsEnable】：【】 字段属性
        /// 数据类型：int；最大长度：4；是否可空：yes
        /// </summary>
        public EntityField IsEnableAttribute
        {
            get { return base["IsEnable"]; }
            set { base["IsEnable"] = value; }
        }

        /// <summary>
        /// 【IsNeedAuditing】：【】 字段
        /// 数据类型：int；最大长度：4；是否可空：no
        /// </summary>
        public int IsNeedAuditing
        {
            get { return base["IsNeedAuditing"].Value.ConvertToInt32(); }
            set { base["IsNeedAuditing"].Value = value; }
        }

        /// <summary>
        /// 【IsNeedAuditing】：【】 字段属性
        /// 数据类型：int；最大长度：4；是否可空：no
        /// </summary>
        public EntityField IsNeedAuditingAttribute
        {
            get { return base["IsNeedAuditing"]; }
            set { base["IsNeedAuditing"] = value; }
        }

        /// <summary>
        /// 【IsNavigation】：【】 字段
        /// 数据类型：int；最大长度：4；是否可空：no
        /// </summary>
        public int IsNavigation
        {
            get { return base["IsNavigation"].Value.ConvertToInt32(); }
            set { base["IsNavigation"].Value = value; }
        }

        /// <summary>
        /// 【IsNavigation】：【】 字段属性
        /// 数据类型：int；最大长度：4；是否可空：no
        /// </summary>
        public EntityField IsNavigationAttribute
        {
            get { return base["IsNavigation"]; }
            set { base["IsNavigation"] = value; }
        }
    }

    /// <summary>
    /// 【T_Dictionary】 实体
    /// </summary>
    public class DictionaryEntity : EntityBase
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public DictionaryEntity() : base("T_Dictionary")
        {
            this.AddField(new EntityField("DictionaryID", true));
            this.AddField(new EntityField("DictionaryCategoryID", false));
            this.AddField(new EntityField("DictionaryName", false));
            this.AddField(new EntityField("DictionaryValue", false));
            this.AddField(new EntityField("DictionaryDescription", false));
            this.AddField(new EntityField("SortNumber", false));
        }


        /// <summary>
        /// 【DictionaryID】：【】 字段
        /// 数据类型：varchar；最大长度：32；是否可空：yes
        /// </summary>
        public string DictionaryID
        {
            get { return base["DictionaryID"].Value.ConvertToString(); }
            set { base["DictionaryID"].Value = value; }
        }

        /// <summary>
        /// 【DictionaryID】：【】 字段属性
        /// 数据类型：varchar；最大长度：32；是否可空：yes
        /// </summary>
        public EntityField DictionaryIDAttribute
        {
            get { return base["DictionaryID"]; }
            set { base["DictionaryID"] = value; }
        }

        /// <summary>
        /// 【DictionaryCategoryID】：【】 字段
        /// 数据类型：varchar；最大长度：32；是否可空：yes
        /// </summary>
        public string DictionaryCategoryID
        {
            get { return base["DictionaryCategoryID"].Value.ConvertToString(); }
            set { base["DictionaryCategoryID"].Value = value; }
        }

        /// <summary>
        /// 【DictionaryCategoryID】：【】 字段属性
        /// 数据类型：varchar；最大长度：32；是否可空：yes
        /// </summary>
        public EntityField DictionaryCategoryIDAttribute
        {
            get { return base["DictionaryCategoryID"]; }
            set { base["DictionaryCategoryID"] = value; }
        }

        /// <summary>
        /// 【DictionaryName】：【】 字段
        /// 数据类型：varchar；最大长度：100；是否可空：no
        /// </summary>
        public string DictionaryName
        {
            get { return base["DictionaryName"].Value.ConvertToString(); }
            set { base["DictionaryName"].Value = value; }
        }

        /// <summary>
        /// 【DictionaryName】：【】 字段属性
        /// 数据类型：varchar；最大长度：100；是否可空：no
        /// </summary>
        public EntityField DictionaryNameAttribute
        {
            get { return base["DictionaryName"]; }
            set { base["DictionaryName"] = value; }
        }

        /// <summary>
        /// 【DictionaryValue】：【】 字段
        /// 数据类型：varchar；最大长度：256；是否可空：no
        /// </summary>
        public string DictionaryValue
        {
            get { return base["DictionaryValue"].Value.ConvertToString(); }
            set { base["DictionaryValue"].Value = value; }
        }

        /// <summary>
        /// 【DictionaryValue】：【】 字段属性
        /// 数据类型：varchar；最大长度：256；是否可空：no
        /// </summary>
        public EntityField DictionaryValueAttribute
        {
            get { return base["DictionaryValue"]; }
            set { base["DictionaryValue"] = value; }
        }

        /// <summary>
        /// 【DictionaryDescription】：【】 字段
        /// 数据类型：varchar；最大长度：256；是否可空：no
        /// </summary>
        public string DictionaryDescription
        {
            get { return base["DictionaryDescription"].Value.ConvertToString(); }
            set { base["DictionaryDescription"].Value = value; }
        }

        /// <summary>
        /// 【DictionaryDescription】：【】 字段属性
        /// 数据类型：varchar；最大长度：256；是否可空：no
        /// </summary>
        public EntityField DictionaryDescriptionAttribute
        {
            get { return base["DictionaryDescription"]; }
            set { base["DictionaryDescription"] = value; }
        }

        /// <summary>
        /// 【SortNumber】：【】 字段
        /// 数据类型：int；最大长度：4；是否可空：no
        /// </summary>
        public int SortNumber
        {
            get { return base["SortNumber"].Value.ConvertToInt32(); }
            set { base["SortNumber"].Value = value; }
        }

        /// <summary>
        /// 【SortNumber】：【】 字段属性
        /// 数据类型：int；最大长度：4；是否可空：no
        /// </summary>
        public EntityField SortNumberAttribute
        {
            get { return base["SortNumber"]; }
            set { base["SortNumber"] = value; }
        }
    }

    /// <summary>
    /// 【T_DictionaryCategory】 实体
    /// </summary>
    public class DictionaryCategoryEntity : EntityBase
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public DictionaryCategoryEntity() : base("T_DictionaryCategory")
        {
            this.AddField(new EntityField("DictionaryCategoryID", true));
            this.AddField(new EntityField("CategoryName", false));
            this.AddField(new EntityField("PhysicsName", false));
            this.AddField(new EntityField("Remark", false));
        }


        /// <summary>
        /// 【DictionaryCategoryID】：【】 字段
        /// 数据类型：varchar；最大长度：32；是否可空：yes
        /// </summary>
        public string DictionaryCategoryID
        {
            get { return base["DictionaryCategoryID"].Value.ConvertToString(); }
            set { base["DictionaryCategoryID"].Value = value; }
        }

        /// <summary>
        /// 【DictionaryCategoryID】：【】 字段属性
        /// 数据类型：varchar；最大长度：32；是否可空：yes
        /// </summary>
        public EntityField DictionaryCategoryIDAttribute
        {
            get { return base["DictionaryCategoryID"]; }
            set { base["DictionaryCategoryID"] = value; }
        }

        /// <summary>
        /// 【CategoryName】：【】 字段
        /// 数据类型：varchar；最大长度：50；是否可空：no
        /// </summary>
        public string CategoryName
        {
            get { return base["CategoryName"].Value.ConvertToString(); }
            set { base["CategoryName"].Value = value; }
        }

        /// <summary>
        /// 【CategoryName】：【】 字段属性
        /// 数据类型：varchar；最大长度：50；是否可空：no
        /// </summary>
        public EntityField CategoryNameAttribute
        {
            get { return base["CategoryName"]; }
            set { base["CategoryName"] = value; }
        }

        /// <summary>
        /// 【PhysicsName】：【】 字段
        /// 数据类型：varchar；最大长度：256；是否可空：no
        /// </summary>
        public string PhysicsName
        {
            get { return base["PhysicsName"].Value.ConvertToString(); }
            set { base["PhysicsName"].Value = value; }
        }

        /// <summary>
        /// 【PhysicsName】：【】 字段属性
        /// 数据类型：varchar；最大长度：256；是否可空：no
        /// </summary>
        public EntityField PhysicsNameAttribute
        {
            get { return base["PhysicsName"]; }
            set { base["PhysicsName"] = value; }
        }

        /// <summary>
        /// 【Remark】：【】 字段
        /// 数据类型：varchar；最大长度：500；是否可空：no
        /// </summary>
        public string Remark
        {
            get { return base["Remark"].Value.ConvertToString(); }
            set { base["Remark"].Value = value; }
        }

        /// <summary>
        /// 【Remark】：【】 字段属性
        /// 数据类型：varchar；最大长度：500；是否可空：no
        /// </summary>
        public EntityField RemarkAttribute
        {
            get { return base["Remark"]; }
            set { base["Remark"] = value; }
        }
    }

    /// <summary>
    /// 【T_ForbiddenWord】 实体
    /// </summary>
    public class ForbiddenWordEntity : EntityBase
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public ForbiddenWordEntity() : base("T_ForbiddenWord")
        {
            this.AddField(new EntityField("ForbiddenWordID", true));
            this.AddField(new EntityField("ForbiddenWord", false));
        }


        /// <summary>
        /// 【ForbiddenWordID】：【】 字段
        /// 数据类型：varchar；最大长度：32；是否可空：yes
        /// </summary>
        public string ForbiddenWordID
        {
            get { return base["ForbiddenWordID"].Value.ConvertToString(); }
            set { base["ForbiddenWordID"].Value = value; }
        }

        /// <summary>
        /// 【ForbiddenWordID】：【】 字段属性
        /// 数据类型：varchar；最大长度：32；是否可空：yes
        /// </summary>
        public EntityField ForbiddenWordIDAttribute
        {
            get { return base["ForbiddenWordID"]; }
            set { base["ForbiddenWordID"] = value; }
        }

        /// <summary>
        /// 【ForbiddenWord】：【】 字段
        /// 数据类型：varchar；最大长度：20；是否可空：no
        /// </summary>
        public string ForbiddenWord
        {
            get { return base["ForbiddenWord"].Value.ConvertToString(); }
            set { base["ForbiddenWord"].Value = value; }
        }

        /// <summary>
        /// 【ForbiddenWord】：【】 字段属性
        /// 数据类型：varchar；最大长度：20；是否可空：no
        /// </summary>
        public EntityField ForbiddenWordAttribute
        {
            get { return base["ForbiddenWord"]; }
            set { base["ForbiddenWord"] = value; }
        }
    }

    /// <summary>
    /// 【T_FSX_DATA】 实体
    /// </summary>
    public class FSX_DATAEntity : EntityBase
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public FSX_DATAEntity() : base("T_FSX_DATA")
        {
            this.AddField(new EntityField("DataID", true));
            this.AddField(new EntityField("ImportDate", false));
            this.AddField(new EntityField("ImportBatch", false));
            this.AddField(new EntityField("ImportRemark", false));
            this.AddField(new EntityField("编号", false));
            this.AddField(new EntityField("年份", false));
            this.AddField(new EntityField("省份", false));
            this.AddField(new EntityField("层次", false));
            this.AddField(new EntityField("类别", false));
            this.AddField(new EntityField("控制线文化专业", false));
            this.AddField(new EntityField("投档最高分文化专业", false));
            this.AddField(new EntityField("投档最低分文化专业", false));
            this.AddField(new EntityField("备注说明", false));
        }


        /// <summary>
        /// 【DataID】：【】 字段
        /// 数据类型：varchar；最大长度：32；是否可空：yes
        /// </summary>
        public string DataID
        {
            get { return base["DataID"].Value.ConvertToString(); }
            set { base["DataID"].Value = value; }
        }

        /// <summary>
        /// 【DataID】：【】 字段属性
        /// 数据类型：varchar；最大长度：32；是否可空：yes
        /// </summary>
        public EntityField DataIDAttribute
        {
            get { return base["DataID"]; }
            set { base["DataID"] = value; }
        }

        /// <summary>
        /// 【ImportDate】：【】 字段
        /// 数据类型：datetime；最大长度：8；是否可空：yes
        /// </summary>
        public DateTime ImportDate
        {
            get { return base["ImportDate"].Value.ConvertToDateTime(); }
            set { base["ImportDate"].Value = value; }
        }

        /// <summary>
        /// 【ImportDate】：【】 字段属性
        /// 数据类型：datetime；最大长度：8；是否可空：yes
        /// </summary>
        public EntityField ImportDateAttribute
        {
            get { return base["ImportDate"]; }
            set { base["ImportDate"] = value; }
        }

        /// <summary>
        /// 【ImportBatch】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string ImportBatch
        {
            get { return base["ImportBatch"].Value.ConvertToString(); }
            set { base["ImportBatch"].Value = value; }
        }

        /// <summary>
        /// 【ImportBatch】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField ImportBatchAttribute
        {
            get { return base["ImportBatch"]; }
            set { base["ImportBatch"] = value; }
        }

        /// <summary>
        /// 【ImportRemark】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string ImportRemark
        {
            get { return base["ImportRemark"].Value.ConvertToString(); }
            set { base["ImportRemark"].Value = value; }
        }

        /// <summary>
        /// 【ImportRemark】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField ImportRemarkAttribute
        {
            get { return base["ImportRemark"]; }
            set { base["ImportRemark"] = value; }
        }

        /// <summary>
        /// 【编号】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string 编号
        {
            get { return base["编号"].Value.ConvertToString(); }
            set { base["编号"].Value = value; }
        }

        /// <summary>
        /// 【编号】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField 编号Attribute
        {
            get { return base["编号"]; }
            set { base["编号"] = value; }
        }

        /// <summary>
        /// 【年份】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string 年份
        {
            get { return base["年份"].Value.ConvertToString(); }
            set { base["年份"].Value = value; }
        }

        /// <summary>
        /// 【年份】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField 年份Attribute
        {
            get { return base["年份"]; }
            set { base["年份"] = value; }
        }

        /// <summary>
        /// 【省份】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string 省份
        {
            get { return base["省份"].Value.ConvertToString(); }
            set { base["省份"].Value = value; }
        }

        /// <summary>
        /// 【省份】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField 省份Attribute
        {
            get { return base["省份"]; }
            set { base["省份"] = value; }
        }

        /// <summary>
        /// 【层次】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string 层次
        {
            get { return base["层次"].Value.ConvertToString(); }
            set { base["层次"].Value = value; }
        }

        /// <summary>
        /// 【层次】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField 层次Attribute
        {
            get { return base["层次"]; }
            set { base["层次"] = value; }
        }

        /// <summary>
        /// 【类别】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string 类别
        {
            get { return base["类别"].Value.ConvertToString(); }
            set { base["类别"].Value = value; }
        }

        /// <summary>
        /// 【类别】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField 类别Attribute
        {
            get { return base["类别"]; }
            set { base["类别"] = value; }
        }

        /// <summary>
        /// 【控制线文化专业】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string 控制线文化专业
        {
            get { return base["控制线文化专业"].Value.ConvertToString(); }
            set { base["控制线文化专业"].Value = value; }
        }

        /// <summary>
        /// 【控制线文化专业】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField 控制线文化专业Attribute
        {
            get { return base["控制线文化专业"]; }
            set { base["控制线文化专业"] = value; }
        }

        /// <summary>
        /// 【投档最高分文化专业】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string 投档最高分文化专业
        {
            get { return base["投档最高分文化专业"].Value.ConvertToString(); }
            set { base["投档最高分文化专业"].Value = value; }
        }

        /// <summary>
        /// 【投档最高分文化专业】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField 投档最高分文化专业Attribute
        {
            get { return base["投档最高分文化专业"]; }
            set { base["投档最高分文化专业"] = value; }
        }

        /// <summary>
        /// 【投档最低分文化专业】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string 投档最低分文化专业
        {
            get { return base["投档最低分文化专业"].Value.ConvertToString(); }
            set { base["投档最低分文化专业"].Value = value; }
        }

        /// <summary>
        /// 【投档最低分文化专业】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField 投档最低分文化专业Attribute
        {
            get { return base["投档最低分文化专业"]; }
            set { base["投档最低分文化专业"] = value; }
        }

        /// <summary>
        /// 【备注说明】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string 备注说明
        {
            get { return base["备注说明"].Value.ConvertToString(); }
            set { base["备注说明"].Value = value; }
        }

        /// <summary>
        /// 【备注说明】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField 备注说明Attribute
        {
            get { return base["备注说明"]; }
            set { base["备注说明"] = value; }
        }
    }

    /// <summary>
    /// 【T_LQ_DATA】 实体
    /// </summary>
    public class LQ_DATAEntity : EntityBase
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public LQ_DATAEntity() : base("T_LQ_DATA")
        {
            this.AddField(new EntityField("DataID", true));
            this.AddField(new EntityField("ImportDate", false));
            this.AddField(new EntityField("ImportBatch", false));
            this.AddField(new EntityField("ImportRemark", false));
            this.AddField(new EntityField("流水号", false));
            this.AddField(new EntityField("年份", false));
            this.AddField(new EntityField("通知书编号", false));
            this.AddField(new EntityField("省份", false));
            this.AddField(new EntityField("考生号", false));
            this.AddField(new EntityField("准考证号", false));
            this.AddField(new EntityField("身份证号", false));
            this.AddField(new EntityField("考生姓名", false));
            this.AddField(new EntityField("性别", false));
            this.AddField(new EntityField("民族", false));
            this.AddField(new EntityField("学历层次", false));
            this.AddField(new EntityField("学制年限", false));
            this.AddField(new EntityField("类别", false));
            this.AddField(new EntityField("科类", false));
            this.AddField(new EntityField("院系", false));
            this.AddField(new EntityField("报到校区", false));
            this.AddField(new EntityField("报到地址", false));
            this.AddField(new EntityField("照片文件", false));
            this.AddField(new EntityField("照片角度", false));
            this.AddField(new EntityField("批次代码", false));
            this.AddField(new EntityField("批次名称", false));
            this.AddField(new EntityField("科类代码", false));
            this.AddField(new EntityField("科类名称", false));
            this.AddField(new EntityField("批次", false));
            this.AddField(new EntityField("计划性质代码", false));
            this.AddField(new EntityField("投档单位代码", false));
            this.AddField(new EntityField("投档志愿", false));
            this.AddField(new EntityField("专业1", false));
            this.AddField(new EntityField("专业1名称", false));
            this.AddField(new EntityField("专业2", false));
            this.AddField(new EntityField("专业2名称", false));
            this.AddField(new EntityField("专业3", false));
            this.AddField(new EntityField("专业3名称", false));
            this.AddField(new EntityField("专业4", false));
            this.AddField(new EntityField("专业4名称", false));
            this.AddField(new EntityField("专业5", false));
            this.AddField(new EntityField("专业5名称", false));
            this.AddField(new EntityField("专业6", false));
            this.AddField(new EntityField("专业6名称", false));
            this.AddField(new EntityField("录取代码", false));
            this.AddField(new EntityField("录取专业", false));
            this.AddField(new EntityField("录取专业规范名", false));
            this.AddField(new EntityField("是否师范", false));
            this.AddField(new EntityField("成绩", false));
            this.AddField(new EntityField("投档成绩", false));
            this.AddField(new EntityField("考生状态", false));
            this.AddField(new EntityField("家庭地址", false));
            this.AddField(new EntityField("邮政编码", false));
            this.AddField(new EntityField("收件人", false));
            this.AddField(new EntityField("联系电话", false));
            this.AddField(new EntityField("毕业中学", false));
            this.AddField(new EntityField("录取志愿", false));
            this.AddField(new EntityField("备注", false));
            this.AddField(new EntityField("是否打印", false));
            this.AddField(new EntityField("打印状态", false));
            this.AddField(new EntityField("获奖内容", false));
            this.AddField(new EntityField("采集员", false));
            this.AddField(new EntityField("采集IP", false));
            this.AddField(new EntityField("Action_Time", false));
            this.AddField(new EntityField("录取结束日期", false));
            this.AddField(new EntityField("报到状态", false));
            this.AddField(new EntityField("操作员", false));
            this.AddField(new EntityField("报到日期", false));
            this.AddField(new EntityField("未报到原因", false));
            this.AddField(new EntityField("选择否", false));
            this.AddField(new EntityField("EMS单号", false));
            this.AddField(new EntityField("学号", false));
            this.AddField(new EntityField("班级", false));
        }


        /// <summary>
        /// 【DataID】：【】 字段
        /// 数据类型：varchar；最大长度：32；是否可空：yes
        /// </summary>
        public string DataID
        {
            get { return base["DataID"].Value.ConvertToString(); }
            set { base["DataID"].Value = value; }
        }

        /// <summary>
        /// 【DataID】：【】 字段属性
        /// 数据类型：varchar；最大长度：32；是否可空：yes
        /// </summary>
        public EntityField DataIDAttribute
        {
            get { return base["DataID"]; }
            set { base["DataID"] = value; }
        }

        /// <summary>
        /// 【ImportDate】：【】 字段
        /// 数据类型：datetime；最大长度：8；是否可空：yes
        /// </summary>
        public DateTime ImportDate
        {
            get { return base["ImportDate"].Value.ConvertToDateTime(); }
            set { base["ImportDate"].Value = value; }
        }

        /// <summary>
        /// 【ImportDate】：【】 字段属性
        /// 数据类型：datetime；最大长度：8；是否可空：yes
        /// </summary>
        public EntityField ImportDateAttribute
        {
            get { return base["ImportDate"]; }
            set { base["ImportDate"] = value; }
        }

        /// <summary>
        /// 【ImportBatch】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string ImportBatch
        {
            get { return base["ImportBatch"].Value.ConvertToString(); }
            set { base["ImportBatch"].Value = value; }
        }

        /// <summary>
        /// 【ImportBatch】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField ImportBatchAttribute
        {
            get { return base["ImportBatch"]; }
            set { base["ImportBatch"] = value; }
        }

        /// <summary>
        /// 【ImportRemark】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string ImportRemark
        {
            get { return base["ImportRemark"].Value.ConvertToString(); }
            set { base["ImportRemark"].Value = value; }
        }

        /// <summary>
        /// 【ImportRemark】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField ImportRemarkAttribute
        {
            get { return base["ImportRemark"]; }
            set { base["ImportRemark"] = value; }
        }

        /// <summary>
        /// 【流水号】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string 流水号
        {
            get { return base["流水号"].Value.ConvertToString(); }
            set { base["流水号"].Value = value; }
        }

        /// <summary>
        /// 【流水号】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField 流水号Attribute
        {
            get { return base["流水号"]; }
            set { base["流水号"] = value; }
        }

        /// <summary>
        /// 【年份】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string 年份
        {
            get { return base["年份"].Value.ConvertToString(); }
            set { base["年份"].Value = value; }
        }

        /// <summary>
        /// 【年份】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField 年份Attribute
        {
            get { return base["年份"]; }
            set { base["年份"] = value; }
        }

        /// <summary>
        /// 【通知书编号】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string 通知书编号
        {
            get { return base["通知书编号"].Value.ConvertToString(); }
            set { base["通知书编号"].Value = value; }
        }

        /// <summary>
        /// 【通知书编号】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField 通知书编号Attribute
        {
            get { return base["通知书编号"]; }
            set { base["通知书编号"] = value; }
        }

        /// <summary>
        /// 【省份】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string 省份
        {
            get { return base["省份"].Value.ConvertToString(); }
            set { base["省份"].Value = value; }
        }

        /// <summary>
        /// 【省份】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField 省份Attribute
        {
            get { return base["省份"]; }
            set { base["省份"] = value; }
        }

        /// <summary>
        /// 【考生号】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string 考生号
        {
            get { return base["考生号"].Value.ConvertToString(); }
            set { base["考生号"].Value = value; }
        }

        /// <summary>
        /// 【考生号】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField 考生号Attribute
        {
            get { return base["考生号"]; }
            set { base["考生号"] = value; }
        }

        /// <summary>
        /// 【准考证号】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string 准考证号
        {
            get { return base["准考证号"].Value.ConvertToString(); }
            set { base["准考证号"].Value = value; }
        }

        /// <summary>
        /// 【准考证号】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField 准考证号Attribute
        {
            get { return base["准考证号"]; }
            set { base["准考证号"] = value; }
        }

        /// <summary>
        /// 【身份证号】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string 身份证号
        {
            get { return base["身份证号"].Value.ConvertToString(); }
            set { base["身份证号"].Value = value; }
        }

        /// <summary>
        /// 【身份证号】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField 身份证号Attribute
        {
            get { return base["身份证号"]; }
            set { base["身份证号"] = value; }
        }

        /// <summary>
        /// 【考生姓名】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string 考生姓名
        {
            get { return base["考生姓名"].Value.ConvertToString(); }
            set { base["考生姓名"].Value = value; }
        }

        /// <summary>
        /// 【考生姓名】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField 考生姓名Attribute
        {
            get { return base["考生姓名"]; }
            set { base["考生姓名"] = value; }
        }

        /// <summary>
        /// 【性别】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string 性别
        {
            get { return base["性别"].Value.ConvertToString(); }
            set { base["性别"].Value = value; }
        }

        /// <summary>
        /// 【性别】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField 性别Attribute
        {
            get { return base["性别"]; }
            set { base["性别"] = value; }
        }

        /// <summary>
        /// 【民族】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string 民族
        {
            get { return base["民族"].Value.ConvertToString(); }
            set { base["民族"].Value = value; }
        }

        /// <summary>
        /// 【民族】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField 民族Attribute
        {
            get { return base["民族"]; }
            set { base["民族"] = value; }
        }

        /// <summary>
        /// 【学历层次】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string 学历层次
        {
            get { return base["学历层次"].Value.ConvertToString(); }
            set { base["学历层次"].Value = value; }
        }

        /// <summary>
        /// 【学历层次】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField 学历层次Attribute
        {
            get { return base["学历层次"]; }
            set { base["学历层次"] = value; }
        }

        /// <summary>
        /// 【学制年限】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string 学制年限
        {
            get { return base["学制年限"].Value.ConvertToString(); }
            set { base["学制年限"].Value = value; }
        }

        /// <summary>
        /// 【学制年限】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField 学制年限Attribute
        {
            get { return base["学制年限"]; }
            set { base["学制年限"] = value; }
        }

        /// <summary>
        /// 【类别】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string 类别
        {
            get { return base["类别"].Value.ConvertToString(); }
            set { base["类别"].Value = value; }
        }

        /// <summary>
        /// 【类别】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField 类别Attribute
        {
            get { return base["类别"]; }
            set { base["类别"] = value; }
        }

        /// <summary>
        /// 【科类】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string 科类
        {
            get { return base["科类"].Value.ConvertToString(); }
            set { base["科类"].Value = value; }
        }

        /// <summary>
        /// 【科类】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField 科类Attribute
        {
            get { return base["科类"]; }
            set { base["科类"] = value; }
        }

        /// <summary>
        /// 【院系】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string 院系
        {
            get { return base["院系"].Value.ConvertToString(); }
            set { base["院系"].Value = value; }
        }

        /// <summary>
        /// 【院系】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField 院系Attribute
        {
            get { return base["院系"]; }
            set { base["院系"] = value; }
        }

        /// <summary>
        /// 【报到校区】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string 报到校区
        {
            get { return base["报到校区"].Value.ConvertToString(); }
            set { base["报到校区"].Value = value; }
        }

        /// <summary>
        /// 【报到校区】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField 报到校区Attribute
        {
            get { return base["报到校区"]; }
            set { base["报到校区"] = value; }
        }

        /// <summary>
        /// 【报到地址】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string 报到地址
        {
            get { return base["报到地址"].Value.ConvertToString(); }
            set { base["报到地址"].Value = value; }
        }

        /// <summary>
        /// 【报到地址】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField 报到地址Attribute
        {
            get { return base["报到地址"]; }
            set { base["报到地址"] = value; }
        }

        /// <summary>
        /// 【照片文件】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string 照片文件
        {
            get { return base["照片文件"].Value.ConvertToString(); }
            set { base["照片文件"].Value = value; }
        }

        /// <summary>
        /// 【照片文件】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField 照片文件Attribute
        {
            get { return base["照片文件"]; }
            set { base["照片文件"] = value; }
        }

        /// <summary>
        /// 【照片角度】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string 照片角度
        {
            get { return base["照片角度"].Value.ConvertToString(); }
            set { base["照片角度"].Value = value; }
        }

        /// <summary>
        /// 【照片角度】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField 照片角度Attribute
        {
            get { return base["照片角度"]; }
            set { base["照片角度"] = value; }
        }

        /// <summary>
        /// 【批次代码】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string 批次代码
        {
            get { return base["批次代码"].Value.ConvertToString(); }
            set { base["批次代码"].Value = value; }
        }

        /// <summary>
        /// 【批次代码】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField 批次代码Attribute
        {
            get { return base["批次代码"]; }
            set { base["批次代码"] = value; }
        }

        /// <summary>
        /// 【批次名称】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string 批次名称
        {
            get { return base["批次名称"].Value.ConvertToString(); }
            set { base["批次名称"].Value = value; }
        }

        /// <summary>
        /// 【批次名称】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField 批次名称Attribute
        {
            get { return base["批次名称"]; }
            set { base["批次名称"] = value; }
        }

        /// <summary>
        /// 【科类代码】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string 科类代码
        {
            get { return base["科类代码"].Value.ConvertToString(); }
            set { base["科类代码"].Value = value; }
        }

        /// <summary>
        /// 【科类代码】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField 科类代码Attribute
        {
            get { return base["科类代码"]; }
            set { base["科类代码"] = value; }
        }

        /// <summary>
        /// 【科类名称】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string 科类名称
        {
            get { return base["科类名称"].Value.ConvertToString(); }
            set { base["科类名称"].Value = value; }
        }

        /// <summary>
        /// 【科类名称】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField 科类名称Attribute
        {
            get { return base["科类名称"]; }
            set { base["科类名称"] = value; }
        }

        /// <summary>
        /// 【批次】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string 批次
        {
            get { return base["批次"].Value.ConvertToString(); }
            set { base["批次"].Value = value; }
        }

        /// <summary>
        /// 【批次】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField 批次Attribute
        {
            get { return base["批次"]; }
            set { base["批次"] = value; }
        }

        /// <summary>
        /// 【计划性质代码】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string 计划性质代码
        {
            get { return base["计划性质代码"].Value.ConvertToString(); }
            set { base["计划性质代码"].Value = value; }
        }

        /// <summary>
        /// 【计划性质代码】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField 计划性质代码Attribute
        {
            get { return base["计划性质代码"]; }
            set { base["计划性质代码"] = value; }
        }

        /// <summary>
        /// 【投档单位代码】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string 投档单位代码
        {
            get { return base["投档单位代码"].Value.ConvertToString(); }
            set { base["投档单位代码"].Value = value; }
        }

        /// <summary>
        /// 【投档单位代码】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField 投档单位代码Attribute
        {
            get { return base["投档单位代码"]; }
            set { base["投档单位代码"] = value; }
        }

        /// <summary>
        /// 【投档志愿】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string 投档志愿
        {
            get { return base["投档志愿"].Value.ConvertToString(); }
            set { base["投档志愿"].Value = value; }
        }

        /// <summary>
        /// 【投档志愿】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField 投档志愿Attribute
        {
            get { return base["投档志愿"]; }
            set { base["投档志愿"] = value; }
        }

        /// <summary>
        /// 【专业1】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string 专业1
        {
            get { return base["专业1"].Value.ConvertToString(); }
            set { base["专业1"].Value = value; }
        }

        /// <summary>
        /// 【专业1】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField 专业1Attribute
        {
            get { return base["专业1"]; }
            set { base["专业1"] = value; }
        }

        /// <summary>
        /// 【专业1名称】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string 专业1名称
        {
            get { return base["专业1名称"].Value.ConvertToString(); }
            set { base["专业1名称"].Value = value; }
        }

        /// <summary>
        /// 【专业1名称】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField 专业1名称Attribute
        {
            get { return base["专业1名称"]; }
            set { base["专业1名称"] = value; }
        }

        /// <summary>
        /// 【专业2】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string 专业2
        {
            get { return base["专业2"].Value.ConvertToString(); }
            set { base["专业2"].Value = value; }
        }

        /// <summary>
        /// 【专业2】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField 专业2Attribute
        {
            get { return base["专业2"]; }
            set { base["专业2"] = value; }
        }

        /// <summary>
        /// 【专业2名称】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string 专业2名称
        {
            get { return base["专业2名称"].Value.ConvertToString(); }
            set { base["专业2名称"].Value = value; }
        }

        /// <summary>
        /// 【专业2名称】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField 专业2名称Attribute
        {
            get { return base["专业2名称"]; }
            set { base["专业2名称"] = value; }
        }

        /// <summary>
        /// 【专业3】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string 专业3
        {
            get { return base["专业3"].Value.ConvertToString(); }
            set { base["专业3"].Value = value; }
        }

        /// <summary>
        /// 【专业3】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField 专业3Attribute
        {
            get { return base["专业3"]; }
            set { base["专业3"] = value; }
        }

        /// <summary>
        /// 【专业3名称】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string 专业3名称
        {
            get { return base["专业3名称"].Value.ConvertToString(); }
            set { base["专业3名称"].Value = value; }
        }

        /// <summary>
        /// 【专业3名称】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField 专业3名称Attribute
        {
            get { return base["专业3名称"]; }
            set { base["专业3名称"] = value; }
        }

        /// <summary>
        /// 【专业4】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string 专业4
        {
            get { return base["专业4"].Value.ConvertToString(); }
            set { base["专业4"].Value = value; }
        }

        /// <summary>
        /// 【专业4】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField 专业4Attribute
        {
            get { return base["专业4"]; }
            set { base["专业4"] = value; }
        }

        /// <summary>
        /// 【专业4名称】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string 专业4名称
        {
            get { return base["专业4名称"].Value.ConvertToString(); }
            set { base["专业4名称"].Value = value; }
        }

        /// <summary>
        /// 【专业4名称】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField 专业4名称Attribute
        {
            get { return base["专业4名称"]; }
            set { base["专业4名称"] = value; }
        }

        /// <summary>
        /// 【专业5】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string 专业5
        {
            get { return base["专业5"].Value.ConvertToString(); }
            set { base["专业5"].Value = value; }
        }

        /// <summary>
        /// 【专业5】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField 专业5Attribute
        {
            get { return base["专业5"]; }
            set { base["专业5"] = value; }
        }

        /// <summary>
        /// 【专业5名称】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string 专业5名称
        {
            get { return base["专业5名称"].Value.ConvertToString(); }
            set { base["专业5名称"].Value = value; }
        }

        /// <summary>
        /// 【专业5名称】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField 专业5名称Attribute
        {
            get { return base["专业5名称"]; }
            set { base["专业5名称"] = value; }
        }

        /// <summary>
        /// 【专业6】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string 专业6
        {
            get { return base["专业6"].Value.ConvertToString(); }
            set { base["专业6"].Value = value; }
        }

        /// <summary>
        /// 【专业6】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField 专业6Attribute
        {
            get { return base["专业6"]; }
            set { base["专业6"] = value; }
        }

        /// <summary>
        /// 【专业6名称】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string 专业6名称
        {
            get { return base["专业6名称"].Value.ConvertToString(); }
            set { base["专业6名称"].Value = value; }
        }

        /// <summary>
        /// 【专业6名称】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField 专业6名称Attribute
        {
            get { return base["专业6名称"]; }
            set { base["专业6名称"] = value; }
        }

        /// <summary>
        /// 【录取代码】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string 录取代码
        {
            get { return base["录取代码"].Value.ConvertToString(); }
            set { base["录取代码"].Value = value; }
        }

        /// <summary>
        /// 【录取代码】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField 录取代码Attribute
        {
            get { return base["录取代码"]; }
            set { base["录取代码"] = value; }
        }

        /// <summary>
        /// 【录取专业】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string 录取专业
        {
            get { return base["录取专业"].Value.ConvertToString(); }
            set { base["录取专业"].Value = value; }
        }

        /// <summary>
        /// 【录取专业】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField 录取专业Attribute
        {
            get { return base["录取专业"]; }
            set { base["录取专业"] = value; }
        }

        /// <summary>
        /// 【录取专业规范名】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string 录取专业规范名
        {
            get { return base["录取专业规范名"].Value.ConvertToString(); }
            set { base["录取专业规范名"].Value = value; }
        }

        /// <summary>
        /// 【录取专业规范名】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField 录取专业规范名Attribute
        {
            get { return base["录取专业规范名"]; }
            set { base["录取专业规范名"] = value; }
        }

        /// <summary>
        /// 【是否师范】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string 是否师范
        {
            get { return base["是否师范"].Value.ConvertToString(); }
            set { base["是否师范"].Value = value; }
        }

        /// <summary>
        /// 【是否师范】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField 是否师范Attribute
        {
            get { return base["是否师范"]; }
            set { base["是否师范"] = value; }
        }

        /// <summary>
        /// 【成绩】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string 成绩
        {
            get { return base["成绩"].Value.ConvertToString(); }
            set { base["成绩"].Value = value; }
        }

        /// <summary>
        /// 【成绩】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField 成绩Attribute
        {
            get { return base["成绩"]; }
            set { base["成绩"] = value; }
        }

        /// <summary>
        /// 【投档成绩】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string 投档成绩
        {
            get { return base["投档成绩"].Value.ConvertToString(); }
            set { base["投档成绩"].Value = value; }
        }

        /// <summary>
        /// 【投档成绩】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField 投档成绩Attribute
        {
            get { return base["投档成绩"]; }
            set { base["投档成绩"] = value; }
        }

        /// <summary>
        /// 【考生状态】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string 考生状态
        {
            get { return base["考生状态"].Value.ConvertToString(); }
            set { base["考生状态"].Value = value; }
        }

        /// <summary>
        /// 【考生状态】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField 考生状态Attribute
        {
            get { return base["考生状态"]; }
            set { base["考生状态"] = value; }
        }

        /// <summary>
        /// 【家庭地址】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string 家庭地址
        {
            get { return base["家庭地址"].Value.ConvertToString(); }
            set { base["家庭地址"].Value = value; }
        }

        /// <summary>
        /// 【家庭地址】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField 家庭地址Attribute
        {
            get { return base["家庭地址"]; }
            set { base["家庭地址"] = value; }
        }

        /// <summary>
        /// 【邮政编码】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string 邮政编码
        {
            get { return base["邮政编码"].Value.ConvertToString(); }
            set { base["邮政编码"].Value = value; }
        }

        /// <summary>
        /// 【邮政编码】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField 邮政编码Attribute
        {
            get { return base["邮政编码"]; }
            set { base["邮政编码"] = value; }
        }

        /// <summary>
        /// 【收件人】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string 收件人
        {
            get { return base["收件人"].Value.ConvertToString(); }
            set { base["收件人"].Value = value; }
        }

        /// <summary>
        /// 【收件人】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField 收件人Attribute
        {
            get { return base["收件人"]; }
            set { base["收件人"] = value; }
        }

        /// <summary>
        /// 【联系电话】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string 联系电话
        {
            get { return base["联系电话"].Value.ConvertToString(); }
            set { base["联系电话"].Value = value; }
        }

        /// <summary>
        /// 【联系电话】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField 联系电话Attribute
        {
            get { return base["联系电话"]; }
            set { base["联系电话"] = value; }
        }

        /// <summary>
        /// 【毕业中学】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string 毕业中学
        {
            get { return base["毕业中学"].Value.ConvertToString(); }
            set { base["毕业中学"].Value = value; }
        }

        /// <summary>
        /// 【毕业中学】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField 毕业中学Attribute
        {
            get { return base["毕业中学"]; }
            set { base["毕业中学"] = value; }
        }

        /// <summary>
        /// 【录取志愿】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string 录取志愿
        {
            get { return base["录取志愿"].Value.ConvertToString(); }
            set { base["录取志愿"].Value = value; }
        }

        /// <summary>
        /// 【录取志愿】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField 录取志愿Attribute
        {
            get { return base["录取志愿"]; }
            set { base["录取志愿"] = value; }
        }

        /// <summary>
        /// 【备注】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string 备注
        {
            get { return base["备注"].Value.ConvertToString(); }
            set { base["备注"].Value = value; }
        }

        /// <summary>
        /// 【备注】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField 备注Attribute
        {
            get { return base["备注"]; }
            set { base["备注"] = value; }
        }

        /// <summary>
        /// 【是否打印】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string 是否打印
        {
            get { return base["是否打印"].Value.ConvertToString(); }
            set { base["是否打印"].Value = value; }
        }

        /// <summary>
        /// 【是否打印】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField 是否打印Attribute
        {
            get { return base["是否打印"]; }
            set { base["是否打印"] = value; }
        }

        /// <summary>
        /// 【打印状态】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string 打印状态
        {
            get { return base["打印状态"].Value.ConvertToString(); }
            set { base["打印状态"].Value = value; }
        }

        /// <summary>
        /// 【打印状态】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField 打印状态Attribute
        {
            get { return base["打印状态"]; }
            set { base["打印状态"] = value; }
        }

        /// <summary>
        /// 【获奖内容】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string 获奖内容
        {
            get { return base["获奖内容"].Value.ConvertToString(); }
            set { base["获奖内容"].Value = value; }
        }

        /// <summary>
        /// 【获奖内容】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField 获奖内容Attribute
        {
            get { return base["获奖内容"]; }
            set { base["获奖内容"] = value; }
        }

        /// <summary>
        /// 【采集员】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string 采集员
        {
            get { return base["采集员"].Value.ConvertToString(); }
            set { base["采集员"].Value = value; }
        }

        /// <summary>
        /// 【采集员】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField 采集员Attribute
        {
            get { return base["采集员"]; }
            set { base["采集员"] = value; }
        }

        /// <summary>
        /// 【采集IP】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string 采集IP
        {
            get { return base["采集IP"].Value.ConvertToString(); }
            set { base["采集IP"].Value = value; }
        }

        /// <summary>
        /// 【采集IP】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField 采集IPAttribute
        {
            get { return base["采集IP"]; }
            set { base["采集IP"] = value; }
        }

        /// <summary>
        /// 【Action_Time】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string Action_Time
        {
            get { return base["Action_Time"].Value.ConvertToString(); }
            set { base["Action_Time"].Value = value; }
        }

        /// <summary>
        /// 【Action_Time】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField Action_TimeAttribute
        {
            get { return base["Action_Time"]; }
            set { base["Action_Time"] = value; }
        }

        /// <summary>
        /// 【录取结束日期】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string 录取结束日期
        {
            get { return base["录取结束日期"].Value.ConvertToString(); }
            set { base["录取结束日期"].Value = value; }
        }

        /// <summary>
        /// 【录取结束日期】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField 录取结束日期Attribute
        {
            get { return base["录取结束日期"]; }
            set { base["录取结束日期"] = value; }
        }

        /// <summary>
        /// 【报到状态】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string 报到状态
        {
            get { return base["报到状态"].Value.ConvertToString(); }
            set { base["报到状态"].Value = value; }
        }

        /// <summary>
        /// 【报到状态】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField 报到状态Attribute
        {
            get { return base["报到状态"]; }
            set { base["报到状态"] = value; }
        }

        /// <summary>
        /// 【操作员】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string 操作员
        {
            get { return base["操作员"].Value.ConvertToString(); }
            set { base["操作员"].Value = value; }
        }

        /// <summary>
        /// 【操作员】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField 操作员Attribute
        {
            get { return base["操作员"]; }
            set { base["操作员"] = value; }
        }

        /// <summary>
        /// 【报到日期】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string 报到日期
        {
            get { return base["报到日期"].Value.ConvertToString(); }
            set { base["报到日期"].Value = value; }
        }

        /// <summary>
        /// 【报到日期】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField 报到日期Attribute
        {
            get { return base["报到日期"]; }
            set { base["报到日期"] = value; }
        }

        /// <summary>
        /// 【未报到原因】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string 未报到原因
        {
            get { return base["未报到原因"].Value.ConvertToString(); }
            set { base["未报到原因"].Value = value; }
        }

        /// <summary>
        /// 【未报到原因】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField 未报到原因Attribute
        {
            get { return base["未报到原因"]; }
            set { base["未报到原因"] = value; }
        }

        /// <summary>
        /// 【选择否】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string 选择否
        {
            get { return base["选择否"].Value.ConvertToString(); }
            set { base["选择否"].Value = value; }
        }

        /// <summary>
        /// 【选择否】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField 选择否Attribute
        {
            get { return base["选择否"]; }
            set { base["选择否"] = value; }
        }

        /// <summary>
        /// 【EMS单号】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string EMS单号
        {
            get { return base["EMS单号"].Value.ConvertToString(); }
            set { base["EMS单号"].Value = value; }
        }

        /// <summary>
        /// 【EMS单号】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField EMS单号Attribute
        {
            get { return base["EMS单号"]; }
            set { base["EMS单号"] = value; }
        }

        /// <summary>
        /// 【学号】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string 学号
        {
            get { return base["学号"].Value.ConvertToString(); }
            set { base["学号"].Value = value; }
        }

        /// <summary>
        /// 【学号】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField 学号Attribute
        {
            get { return base["学号"]; }
            set { base["学号"] = value; }
        }

        /// <summary>
        /// 【班级】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string 班级
        {
            get { return base["班级"].Value.ConvertToString(); }
            set { base["班级"].Value = value; }
        }

        /// <summary>
        /// 【班级】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField 班级Attribute
        {
            get { return base["班级"]; }
            set { base["班级"] = value; }
        }
    }

    /// <summary>
    /// 【T_Menu】 实体
    /// </summary>
    public class MenuEntity : EntityBase
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public MenuEntity() : base("T_Menu")
        {
            this.AddField(new EntityField("MenuID", true));
            this.AddField(new EntityField("MenuParentID", false));
            this.AddField(new EntityField("MenuTreeID", false));
            this.AddField(new EntityField("MenuName", false));
            this.AddField(new EntityField("LinkAddress", false));
            this.AddField(new EntityField("MenuBigIcon", false));
            this.AddField(new EntityField("MenuSmallIcon", false));
            this.AddField(new EntityField("SortNumber", false));
            this.AddField(new EntityField("IsEnable", false));
            this.AddField(new EntityField("PhysicsName", false));
        }


        /// <summary>
        /// 【MenuID】：【】 字段
        /// 数据类型：varchar；最大长度：32；是否可空：yes
        /// </summary>
        public string MenuID
        {
            get { return base["MenuID"].Value.ConvertToString(); }
            set { base["MenuID"].Value = value; }
        }

        /// <summary>
        /// 【MenuID】：【】 字段属性
        /// 数据类型：varchar；最大长度：32；是否可空：yes
        /// </summary>
        public EntityField MenuIDAttribute
        {
            get { return base["MenuID"]; }
            set { base["MenuID"] = value; }
        }

        /// <summary>
        /// 【MenuParentID】：【】 字段
        /// 数据类型：varchar；最大长度：32；是否可空：no
        /// </summary>
        public string MenuParentID
        {
            get { return base["MenuParentID"].Value.ConvertToString(); }
            set { base["MenuParentID"].Value = value; }
        }

        /// <summary>
        /// 【MenuParentID】：【】 字段属性
        /// 数据类型：varchar；最大长度：32；是否可空：no
        /// </summary>
        public EntityField MenuParentIDAttribute
        {
            get { return base["MenuParentID"]; }
            set { base["MenuParentID"] = value; }
        }

        /// <summary>
        /// 【MenuTreeID】：【】 字段
        /// 数据类型：varchar；最大长度：50；是否可空：no
        /// </summary>
        public string MenuTreeID
        {
            get { return base["MenuTreeID"].Value.ConvertToString(); }
            set { base["MenuTreeID"].Value = value; }
        }

        /// <summary>
        /// 【MenuTreeID】：【】 字段属性
        /// 数据类型：varchar；最大长度：50；是否可空：no
        /// </summary>
        public EntityField MenuTreeIDAttribute
        {
            get { return base["MenuTreeID"]; }
            set { base["MenuTreeID"] = value; }
        }

        /// <summary>
        /// 【MenuName】：【】 字段
        /// 数据类型：varchar；最大长度：60；是否可空：yes
        /// </summary>
        public string MenuName
        {
            get { return base["MenuName"].Value.ConvertToString(); }
            set { base["MenuName"].Value = value; }
        }

        /// <summary>
        /// 【MenuName】：【】 字段属性
        /// 数据类型：varchar；最大长度：60；是否可空：yes
        /// </summary>
        public EntityField MenuNameAttribute
        {
            get { return base["MenuName"]; }
            set { base["MenuName"] = value; }
        }

        /// <summary>
        /// 【LinkAddress】：【】 字段
        /// 数据类型：varchar；最大长度：100；是否可空：no
        /// </summary>
        public string LinkAddress
        {
            get { return base["LinkAddress"].Value.ConvertToString(); }
            set { base["LinkAddress"].Value = value; }
        }

        /// <summary>
        /// 【LinkAddress】：【】 字段属性
        /// 数据类型：varchar；最大长度：100；是否可空：no
        /// </summary>
        public EntityField LinkAddressAttribute
        {
            get { return base["LinkAddress"]; }
            set { base["LinkAddress"] = value; }
        }

        /// <summary>
        /// 【MenuBigIcon】：【】 字段
        /// 数据类型：varchar；最大长度：256；是否可空：no
        /// </summary>
        public string MenuBigIcon
        {
            get { return base["MenuBigIcon"].Value.ConvertToString(); }
            set { base["MenuBigIcon"].Value = value; }
        }

        /// <summary>
        /// 【MenuBigIcon】：【】 字段属性
        /// 数据类型：varchar；最大长度：256；是否可空：no
        /// </summary>
        public EntityField MenuBigIconAttribute
        {
            get { return base["MenuBigIcon"]; }
            set { base["MenuBigIcon"] = value; }
        }

        /// <summary>
        /// 【MenuSmallIcon】：【】 字段
        /// 数据类型：varchar；最大长度：256；是否可空：no
        /// </summary>
        public string MenuSmallIcon
        {
            get { return base["MenuSmallIcon"].Value.ConvertToString(); }
            set { base["MenuSmallIcon"].Value = value; }
        }

        /// <summary>
        /// 【MenuSmallIcon】：【】 字段属性
        /// 数据类型：varchar；最大长度：256；是否可空：no
        /// </summary>
        public EntityField MenuSmallIconAttribute
        {
            get { return base["MenuSmallIcon"]; }
            set { base["MenuSmallIcon"] = value; }
        }

        /// <summary>
        /// 【SortNumber】：【】 字段
        /// 数据类型：int；最大长度：4；是否可空：no
        /// </summary>
        public int SortNumber
        {
            get { return base["SortNumber"].Value.ConvertToInt32(); }
            set { base["SortNumber"].Value = value; }
        }

        /// <summary>
        /// 【SortNumber】：【】 字段属性
        /// 数据类型：int；最大长度：4；是否可空：no
        /// </summary>
        public EntityField SortNumberAttribute
        {
            get { return base["SortNumber"]; }
            set { base["SortNumber"] = value; }
        }

        /// <summary>
        /// 【IsEnable】：【】 字段
        /// 数据类型：int；最大长度：4；是否可空：no
        /// </summary>
        public int IsEnable
        {
            get { return base["IsEnable"].Value.ConvertToInt32(); }
            set { base["IsEnable"].Value = value; }
        }

        /// <summary>
        /// 【IsEnable】：【】 字段属性
        /// 数据类型：int；最大长度：4；是否可空：no
        /// </summary>
        public EntityField IsEnableAttribute
        {
            get { return base["IsEnable"]; }
            set { base["IsEnable"] = value; }
        }

        /// <summary>
        /// 【PhysicsName】：【】 字段
        /// 数据类型：int；最大长度：4；是否可空：no
        /// </summary>
        public String PhysicsName
        {
            get { return base["PhysicsName"].Value.ConvertToString(); }
            set { base["PhysicsName"].Value = value; }
        }

        /// <summary>
        /// 【PhysicsName】：【】 字段属性
        /// 数据类型：int；最大长度：4；是否可空：no
        /// </summary>
        public EntityField PhysicsNameAttribute
        {
            get { return base["PhysicsName"]; }
            set { base["PhysicsName"] = value; }
        }
    }

    /// <summary>
    /// 【T_QueryDisplayField】 实体
    /// </summary>
    public class QueryDisplayFieldEntity : EntityBase
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public QueryDisplayFieldEntity() : base("T_QueryDisplayField")
        {
            this.AddField(new EntityField("QueryDisplayFieldID", true));
            this.AddField(new EntityField("TableName", false));
            this.AddField(new EntityField("TableNameTitle", false));
            this.AddField(new EntityField("DisplayField", false));
        }


        /// <summary>
        /// 【QueryDisplayFieldID】：【】 字段
        /// 数据类型：varchar；最大长度：32；是否可空：yes
        /// </summary>
        public string QueryDisplayFieldID
        {
            get { return base["QueryDisplayFieldID"].Value.ConvertToString(); }
            set { base["QueryDisplayFieldID"].Value = value; }
        }

        /// <summary>
        /// 【QueryDisplayFieldID】：【】 字段属性
        /// 数据类型：varchar；最大长度：32；是否可空：yes
        /// </summary>
        public EntityField QueryDisplayFieldIDAttribute
        {
            get { return base["QueryDisplayFieldID"]; }
            set { base["QueryDisplayFieldID"] = value; }
        }

        /// <summary>
        /// 【TableName】：【】 字段
        /// 数据类型：varchar；最大长度：20；是否可空：no
        /// </summary>
        public string TableName
        {
            get { return base["TableName"].Value.ConvertToString(); }
            set { base["TableName"].Value = value; }
        }

        /// <summary>
        /// 【TableName】：【】 字段属性
        /// 数据类型：varchar；最大长度：20；是否可空：no
        /// </summary>
        public EntityField TableNameAttribute
        {
            get { return base["TableName"]; }
            set { base["TableName"] = value; }
        }

        /// <summary>
        /// 【TableNameTitle】：【】 字段
        /// 数据类型：varchar；最大长度：20；是否可空：no
        /// </summary>
        public string TableNameTitle
        {
            get { return base["TableNameTitle"].Value.ConvertToString(); }
            set { base["TableNameTitle"].Value = value; }
        }

        /// <summary>
        /// 【TableNameTitle】：【】 字段属性
        /// 数据类型：varchar；最大长度：20；是否可空：no
        /// </summary>
        public EntityField TableNameTitleAttribute
        {
            get { return base["TableNameTitle"]; }
            set { base["TableNameTitle"] = value; }
        }

        /// <summary>
        /// 【DisplayField】：【】 字段
        /// 数据类型：varchar；最大长度：500；是否可空：no
        /// </summary>
        public string DisplayField
        {
            get { return base["DisplayField"].Value.ConvertToString(); }
            set { base["DisplayField"].Value = value; }
        }

        /// <summary>
        /// 【DisplayField】：【】 字段属性
        /// 数据类型：varchar；最大长度：500；是否可空：no
        /// </summary>
        public EntityField DisplayFieldAttribute
        {
            get { return base["DisplayField"]; }
            set { base["DisplayField"] = value; }
        }
    }

    /// <summary>
    /// 【T_Role】 实体
    /// </summary>
    public class RoleEntity : EntityBase
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public RoleEntity() : base("T_Role")
        {
            this.AddField(new EntityField("RoleID", true));
            this.AddField(new EntityField("RoleName", false));
            this.AddField(new EntityField("RoleDescription", false));
        }


        /// <summary>
        /// 【RoleID】：【】 字段
        /// 数据类型：varchar；最大长度：32；是否可空：yes
        /// </summary>
        public string RoleID
        {
            get { return base["RoleID"].Value.ConvertToString(); }
            set { base["RoleID"].Value = value; }
        }

        /// <summary>
        /// 【RoleID】：【】 字段属性
        /// 数据类型：varchar；最大长度：32；是否可空：yes
        /// </summary>
        public EntityField RoleIDAttribute
        {
            get { return base["RoleID"]; }
            set { base["RoleID"] = value; }
        }

        /// <summary>
        /// 【RoleName】：【】 字段
        /// 数据类型：varchar；最大长度：20；是否可空：no
        /// </summary>
        public string RoleName
        {
            get { return base["RoleName"].Value.ConvertToString(); }
            set { base["RoleName"].Value = value; }
        }

        /// <summary>
        /// 【RoleName】：【】 字段属性
        /// 数据类型：varchar；最大长度：20；是否可空：no
        /// </summary>
        public EntityField RoleNameAttribute
        {
            get { return base["RoleName"]; }
            set { base["RoleName"] = value; }
        }

        /// <summary>
        /// 【RoleDescription】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string RoleDescription
        {
            get { return base["RoleDescription"].Value.ConvertToString(); }
            set { base["RoleDescription"].Value = value; }
        }

        /// <summary>
        /// 【RoleDescription】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField RoleDescriptionAttribute
        {
            get { return base["RoleDescription"]; }
            set { base["RoleDescription"] = value; }
        }
    }

    /// <summary>
    /// 【T_RoleColumnPermission】 实体
    /// </summary>
    public class RoleColumnPermissionEntity : EntityBase
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public RoleColumnPermissionEntity() : base("T_RoleColumnPermission")
        {
            this.AddField(new EntityField("ColumnID", true));
            this.AddField(new EntityField("RoleID", true));
        }


        /// <summary>
        /// 【ColumnID】：【】 字段
        /// 数据类型：varchar；最大长度：32；是否可空：yes
        /// </summary>
        public string ColumnID
        {
            get { return base["ColumnID"].Value.ConvertToString(); }
            set { base["ColumnID"].Value = value; }
        }

        /// <summary>
        /// 【ColumnID】：【】 字段属性
        /// 数据类型：varchar；最大长度：32；是否可空：yes
        /// </summary>
        public EntityField ColumnIDAttribute
        {
            get { return base["ColumnID"]; }
            set { base["ColumnID"] = value; }
        }

        /// <summary>
        /// 【RoleID】：【】 字段
        /// 数据类型：varchar；最大长度：32；是否可空：yes
        /// </summary>
        public string RoleID
        {
            get { return base["RoleID"].Value.ConvertToString(); }
            set { base["RoleID"].Value = value; }
        }

        /// <summary>
        /// 【RoleID】：【】 字段属性
        /// 数据类型：varchar；最大长度：32；是否可空：yes
        /// </summary>
        public EntityField RoleIDAttribute
        {
            get { return base["RoleID"]; }
            set { base["RoleID"] = value; }
        }
    }

    /// <summary>
    /// 【T_RoleMenuPermission】 实体
    /// </summary>
    public class RoleMenuPermissionEntity : EntityBase
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public RoleMenuPermissionEntity() : base("T_RoleMenuPermission")
        {
            this.AddField(new EntityField("MenuID", true));
            this.AddField(new EntityField("RoleID", true));
        }


        /// <summary>
        /// 【MenuID】：【】 字段
        /// 数据类型：varchar；最大长度：32；是否可空：yes
        /// </summary>
        public string MenuID
        {
            get { return base["MenuID"].Value.ConvertToString(); }
            set { base["MenuID"].Value = value; }
        }

        /// <summary>
        /// 【MenuID】：【】 字段属性
        /// 数据类型：varchar；最大长度：32；是否可空：yes
        /// </summary>
        public EntityField MenuIDAttribute
        {
            get { return base["MenuID"]; }
            set { base["MenuID"] = value; }
        }

        /// <summary>
        /// 【RoleID】：【】 字段
        /// 数据类型：varchar；最大长度：32；是否可空：yes
        /// </summary>
        public string RoleID
        {
            get { return base["RoleID"].Value.ConvertToString(); }
            set { base["RoleID"].Value = value; }
        }

        /// <summary>
        /// 【RoleID】：【】 字段属性
        /// 数据类型：varchar；最大长度：32；是否可空：yes
        /// </summary>
        public EntityField RoleIDAttribute
        {
            get { return base["RoleID"]; }
            set { base["RoleID"] = value; }
        }
    }

    /// <summary>
    /// 【T_SystemLog】 实体
    /// </summary>
    public class SystemLogEntity : EntityBase
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public SystemLogEntity() : base("T_SystemLog")
        {
            this.AddField(new EntityField("SystemLogID", true));
            this.AddField(new EntityField("LogCategory", false));
            this.AddField(new EntityField("LogTitle", false));
            this.AddField(new EntityField("LogContent", false));
            this.AddField(new EntityField("UserName", false));
            this.AddField(new EntityField("LogIP", false));
            this.AddField(new EntityField("CreateDate", false));
        }


        /// <summary>
        /// 【SystemLogID】：【】 字段
        /// 数据类型：varchar；最大长度：32；是否可空：yes
        /// </summary>
        public string SystemLogID
        {
            get { return base["SystemLogID"].Value.ConvertToString(); }
            set { base["SystemLogID"].Value = value; }
        }

        /// <summary>
        /// 【SystemLogID】：【】 字段属性
        /// 数据类型：varchar；最大长度：32；是否可空：yes
        /// </summary>
        public EntityField SystemLogIDAttribute
        {
            get { return base["SystemLogID"]; }
            set { base["SystemLogID"] = value; }
        }

        /// <summary>
        /// 【LogCategory】：【】 字段
        /// 数据类型：varchar；最大长度：60；是否可空：yes
        /// </summary>
        public string LogCategory
        {
            get { return base["LogCategory"].Value.ConvertToString(); }
            set { base["LogCategory"].Value = value; }
        }

        /// <summary>
        /// 【LogCategory】：【】 字段属性
        /// 数据类型：varchar；最大长度：60；是否可空：yes
        /// </summary>
        public EntityField LogCategoryAttribute
        {
            get { return base["LogCategory"]; }
            set { base["LogCategory"] = value; }
        }

        /// <summary>
        /// 【LogTitle】：【】 字段
        /// 数据类型：varchar；最大长度：250；是否可空：no
        /// </summary>
        public string LogTitle
        {
            get { return base["LogTitle"].Value.ConvertToString(); }
            set { base["LogTitle"].Value = value; }
        }

        /// <summary>
        /// 【LogTitle】：【】 字段属性
        /// 数据类型：varchar；最大长度：250；是否可空：no
        /// </summary>
        public EntityField LogTitleAttribute
        {
            get { return base["LogTitle"]; }
            set { base["LogTitle"] = value; }
        }

        /// <summary>
        /// 【LogContent】：【】 字段
        /// 数据类型：varchar；最大长度：3000；是否可空：no
        /// </summary>
        public string LogContent
        {
            get { return base["LogContent"].Value.ConvertToString(); }
            set { base["LogContent"].Value = value; }
        }

        /// <summary>
        /// 【LogContent】：【】 字段属性
        /// 数据类型：varchar；最大长度：3000；是否可空：no
        /// </summary>
        public EntityField LogContentAttribute
        {
            get { return base["LogContent"]; }
            set { base["LogContent"] = value; }
        }

        /// <summary>
        /// 【UserName】：【】 字段
        /// 数据类型：varchar；最大长度：60；是否可空：no
        /// </summary>
        public string UserName
        {
            get { return base["UserName"].Value.ConvertToString(); }
            set { base["UserName"].Value = value; }
        }

        /// <summary>
        /// 【UserName】：【】 字段属性
        /// 数据类型：varchar；最大长度：60；是否可空：no
        /// </summary>
        public EntityField UserNameAttribute
        {
            get { return base["UserName"]; }
            set { base["UserName"] = value; }
        }

        /// <summary>
        /// 【LogIP】：【】 字段
        /// 数据类型：varchar；最大长度：15；是否可空：yes
        /// </summary>
        public string LogIP
        {
            get { return base["LogIP"].Value.ConvertToString(); }
            set { base["LogIP"].Value = value; }
        }

        /// <summary>
        /// 【LogIP】：【】 字段属性
        /// 数据类型：varchar；最大长度：15；是否可空：yes
        /// </summary>
        public EntityField LogIPAttribute
        {
            get { return base["LogIP"]; }
            set { base["LogIP"] = value; }
        }

        /// <summary>
        /// 【CreateDate】：【】 字段
        /// 数据类型：datetime；最大长度：8；是否可空：yes
        /// </summary>
        public DateTime CreateDate
        {
            get { return base["CreateDate"].Value.ConvertToDateTime(); }
            set { base["CreateDate"].Value = value; }
        }

        /// <summary>
        /// 【CreateDate】：【】 字段属性
        /// 数据类型：datetime；最大长度：8；是否可空：yes
        /// </summary>
        public EntityField CreateDateAttribute
        {
            get { return base["CreateDate"]; }
            set { base["CreateDate"] = value; }
        }
    }

    /// <summary>
    /// 【T_SystemSetting】 实体
    /// </summary>
    public class SystemSettingEntity : EntityBase
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public SystemSettingEntity() : base("T_SystemSetting")
        {
            this.AddField(new EntityField("SystemSettingKey", true));
            this.AddField(new EntityField("SystemSettingValue", false));
            this.AddField(new EntityField("SystemSettingGrouping", false));
            this.AddField(new EntityField("SystemSettingDescription", false));
        }


        /// <summary>
        /// 【SystemSettingKey】：【】 字段
        /// 数据类型：varchar；最大长度：100；是否可空：yes
        /// </summary>
        public string SystemSettingKey
        {
            get { return base["SystemSettingKey"].Value.ConvertToString(); }
            set { base["SystemSettingKey"].Value = value; }
        }

        /// <summary>
        /// 【SystemSettingKey】：【】 字段属性
        /// 数据类型：varchar；最大长度：100；是否可空：yes
        /// </summary>
        public EntityField SystemSettingKeyAttribute
        {
            get { return base["SystemSettingKey"]; }
            set { base["SystemSettingKey"] = value; }
        }

        /// <summary>
        /// 【SystemSettingValue】：【】 字段
        /// 数据类型：varchar；最大长度：250；是否可空：no
        /// </summary>
        public string SystemSettingValue
        {
            get { return base["SystemSettingValue"].Value.ConvertToString(); }
            set { base["SystemSettingValue"].Value = value; }
        }

        /// <summary>
        /// 【SystemSettingValue】：【】 字段属性
        /// 数据类型：varchar；最大长度：250；是否可空：no
        /// </summary>
        public EntityField SystemSettingValueAttribute
        {
            get { return base["SystemSettingValue"]; }
            set { base["SystemSettingValue"] = value; }
        }

        /// <summary>
        /// 【SystemSettingGrouping】：【】 字段
        /// 数据类型：varchar；最大长度：20；是否可空：no
        /// </summary>
        public string SystemSettingGrouping
        {
            get { return base["SystemSettingGrouping"].Value.ConvertToString(); }
            set { base["SystemSettingGrouping"].Value = value; }
        }

        /// <summary>
        /// 【SystemSettingGrouping】：【】 字段属性
        /// 数据类型：varchar；最大长度：20；是否可空：no
        /// </summary>
        public EntityField SystemSettingGroupingAttribute
        {
            get { return base["SystemSettingGrouping"]; }
            set { base["SystemSettingGrouping"] = value; }
        }

        /// <summary>
        /// 【SystemSettingDescription】：【】 字段
        /// 数据类型：text；最大长度：16；是否可空：no
        /// </summary>
        public string SystemSettingDescription
        {
            get { return base["SystemSettingDescription"].Value.ConvertToString(); }
            set { base["SystemSettingDescription"].Value = value; }
        }

        /// <summary>
        /// 【SystemSettingDescription】：【】 字段属性
        /// 数据类型：text；最大长度：16；是否可空：no
        /// </summary>
        public EntityField SystemSettingDescriptionAttribute
        {
            get { return base["SystemSettingDescription"]; }
            set { base["SystemSettingDescription"] = value; }
        }
    }

    /// <summary>
    /// 【T_User】 实体
    /// </summary>
    public class UserEntity : EntityBase
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public UserEntity() : base("T_User")
        {
            this.AddField(new EntityField("UserID", true));
            this.AddField(new EntityField("UserName", false));
            this.AddField(new EntityField("LoginName", false));
            this.AddField(new EntityField("LoginPassword", false));
            this.AddField(new EntityField("IsAdmin", false));
        }


        /// <summary>
        /// 【UserID】：【】 字段
        /// 数据类型：varchar；最大长度：32；是否可空：yes
        /// </summary>
        public string UserID
        {
            get { return base["UserID"].Value.ConvertToString(); }
            set { base["UserID"].Value = value; }
        }

        /// <summary>
        /// 【UserID】：【】 字段属性
        /// 数据类型：varchar；最大长度：32；是否可空：yes
        /// </summary>
        public EntityField UserIDAttribute
        {
            get { return base["UserID"]; }
            set { base["UserID"] = value; }
        }

        /// <summary>
        /// 【UserName】：【】 字段
        /// 数据类型：varchar；最大长度：30；是否可空：yes
        /// </summary>
        public string UserName
        {
            get { return base["UserName"].Value.ConvertToString(); }
            set { base["UserName"].Value = value; }
        }

        /// <summary>
        /// 【UserName】：【】 字段属性
        /// 数据类型：varchar；最大长度：30；是否可空：yes
        /// </summary>
        public EntityField UserNameAttribute
        {
            get { return base["UserName"]; }
            set { base["UserName"] = value; }
        }

        /// <summary>
        /// 【LoginName】：【】 字段
        /// 数据类型：varchar；最大长度：30；是否可空：yes
        /// </summary>
        public string LoginName
        {
            get { return base["LoginName"].Value.ConvertToString(); }
            set { base["LoginName"].Value = value; }
        }

        /// <summary>
        /// 【LoginName】：【】 字段属性
        /// 数据类型：varchar；最大长度：30；是否可空：yes
        /// </summary>
        public EntityField LoginNameAttribute
        {
            get { return base["LoginName"]; }
            set { base["LoginName"] = value; }
        }

        /// <summary>
        /// 【LoginPassword】：【】 字段
        /// 数据类型：varchar；最大长度：100；是否可空：yes
        /// </summary>
        public string LoginPassword
        {
            get { return base["LoginPassword"].Value.ConvertToString(); }
            set { base["LoginPassword"].Value = value; }
        }

        /// <summary>
        /// 【LoginPassword】：【】 字段属性
        /// 数据类型：varchar；最大长度：100；是否可空：yes
        /// </summary>
        public EntityField LoginPasswordAttribute
        {
            get { return base["LoginPassword"]; }
            set { base["LoginPassword"] = value; }
        }

        /// <summary>
        /// 【IsAdmin】：【】 字段
        /// 数据类型：int；最大长度：4；是否可空：no
        /// </summary>
        public int IsAdmin
        {
            get { return base["IsAdmin"].Value.ConvertToInt32(); }
            set { base["IsAdmin"].Value = value; }
        }

        /// <summary>
        /// 【IsAdmin】：【】 字段属性
        /// 数据类型：int；最大长度：4；是否可空：no
        /// </summary>
        public EntityField IsAdminAttribute
        {
            get { return base["IsAdmin"]; }
            set { base["IsAdmin"] = value; }
        }
    }

    /// <summary>
    /// 【T_UserFeedback】 实体
    /// </summary>
    public class UserFeedbackEntity : EntityBase
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public UserFeedbackEntity() : base("T_UserFeedback")
        {
            this.AddField(new EntityField("UserFeedbackID", true));
            this.AddField(new EntityField("FeedbackTitle", false));
            this.AddField(new EntityField("FeedbackContent", false));
            this.AddField(new EntityField("FeedbackDate", false));
            this.AddField(new EntityField("ReadStatus", false));
            this.AddField(new EntityField("ReadDate", false));
        }


        /// <summary>
        /// 【UserFeedbackID】：【】 字段
        /// 数据类型：varchar；最大长度：32；是否可空：yes
        /// </summary>
        public string UserFeedbackID
        {
            get { return base["UserFeedbackID"].Value.ConvertToString(); }
            set { base["UserFeedbackID"].Value = value; }
        }

        /// <summary>
        /// 【UserFeedbackID】：【】 字段属性
        /// 数据类型：varchar；最大长度：32；是否可空：yes
        /// </summary>
        public EntityField UserFeedbackIDAttribute
        {
            get { return base["UserFeedbackID"]; }
            set { base["UserFeedbackID"] = value; }
        }

        /// <summary>
        /// 【FeedbackTitle】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string FeedbackTitle
        {
            get { return base["FeedbackTitle"].Value.ConvertToString(); }
            set { base["FeedbackTitle"].Value = value; }
        }

        /// <summary>
        /// 【FeedbackTitle】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField FeedbackTitleAttribute
        {
            get { return base["FeedbackTitle"]; }
            set { base["FeedbackTitle"] = value; }
        }

        /// <summary>
        /// 【FeedbackContent】：【】 字段
        /// 数据类型：varchar；最大长度：2000；是否可空：no
        /// </summary>
        public string FeedbackContent
        {
            get { return base["FeedbackContent"].Value.ConvertToString(); }
            set { base["FeedbackContent"].Value = value; }
        }

        /// <summary>
        /// 【FeedbackContent】：【】 字段属性
        /// 数据类型：varchar；最大长度：2000；是否可空：no
        /// </summary>
        public EntityField FeedbackContentAttribute
        {
            get { return base["FeedbackContent"]; }
            set { base["FeedbackContent"] = value; }
        }

        /// <summary>
        /// 【FeedbackDate】：【】 字段
        /// 数据类型：datetime；最大长度：8；是否可空：yes
        /// </summary>
        public DateTime FeedbackDate
        {
            get { return base["FeedbackDate"].Value.ConvertToDateTime(); }
            set { base["FeedbackDate"].Value = value; }
        }

        /// <summary>
        /// 【FeedbackDate】：【】 字段属性
        /// 数据类型：datetime；最大长度：8；是否可空：yes
        /// </summary>
        public EntityField FeedbackDateAttribute
        {
            get { return base["FeedbackDate"]; }
            set { base["FeedbackDate"] = value; }
        }

        /// <summary>
        /// 【ReadStatus】：【】 字段
        /// 数据类型：varchar；最大长度：10；是否可空：no
        /// </summary>
        public string ReadStatus
        {
            get { return base["ReadStatus"].Value.ConvertToString(); }
            set { base["ReadStatus"].Value = value; }
        }

        /// <summary>
        /// 【ReadStatus】：【】 字段属性
        /// 数据类型：varchar；最大长度：10；是否可空：no
        /// </summary>
        public EntityField ReadStatusAttribute
        {
            get { return base["ReadStatus"]; }
            set { base["ReadStatus"] = value; }
        }

        /// <summary>
        /// 【ReadDate】：【】 字段
        /// 数据类型：datetime；最大长度：8；是否可空：no
        /// </summary>
        public DateTime ReadDate
        {
            get { return base["ReadDate"].Value.ConvertToDateTime(); }
            set { base["ReadDate"].Value = value; }
        }

        /// <summary>
        /// 【ReadDate】：【】 字段属性
        /// 数据类型：datetime；最大长度：8；是否可空：no
        /// </summary>
        public EntityField ReadDateAttribute
        {
            get { return base["ReadDate"]; }
            set { base["ReadDate"] = value; }
        }
    }

    /// <summary>
    /// 【T_UserInRole】 实体
    /// </summary>
    public class UserInRoleEntity : EntityBase
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public UserInRoleEntity() : base("T_UserInRole")
        {
            this.AddField(new EntityField("UserID", true));
            this.AddField(new EntityField("RoleID", true));
        }


        /// <summary>
        /// 【UserID】：【】 字段
        /// 数据类型：varchar；最大长度：32；是否可空：yes
        /// </summary>
        public string UserID
        {
            get { return base["UserID"].Value.ConvertToString(); }
            set { base["UserID"].Value = value; }
        }

        /// <summary>
        /// 【UserID】：【】 字段属性
        /// 数据类型：varchar；最大长度：32；是否可空：yes
        /// </summary>
        public EntityField UserIDAttribute
        {
            get { return base["UserID"]; }
            set { base["UserID"] = value; }
        }

        /// <summary>
        /// 【RoleID】：【】 字段
        /// 数据类型：varchar；最大长度：32；是否可空：yes
        /// </summary>
        public string RoleID
        {
            get { return base["RoleID"].Value.ConvertToString(); }
            set { base["RoleID"].Value = value; }
        }

        /// <summary>
        /// 【RoleID】：【】 字段属性
        /// 数据类型：varchar；最大长度：32；是否可空：yes
        /// </summary>
        public EntityField RoleIDAttribute
        {
            get { return base["RoleID"]; }
            set { base["RoleID"] = value; }
        }
    }

    /// <summary>
    /// 【T_ZSJH_DATA】 实体
    /// </summary>
    public class ZSJH_DATAEntity : EntityBase
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public ZSJH_DATAEntity() : base("T_ZSJH_DATA")
        {
            this.AddField(new EntityField("DataID", true));
            this.AddField(new EntityField("ImportDate", false));
            this.AddField(new EntityField("ImportBatch", false));
            this.AddField(new EntityField("ImportRemark", false));
            this.AddField(new EntityField("编号", false));
            this.AddField(new EntityField("年份", false));
            this.AddField(new EntityField("省份", false));
            this.AddField(new EntityField("学历层次", false));
            this.AddField(new EntityField("学院", false));
            this.AddField(new EntityField("专业", false));
            this.AddField(new EntityField("类别", false));
            this.AddField(new EntityField("科目", false));
            this.AddField(new EntityField("计划数", false));
            this.AddField(new EntityField("收费标准", false));
            this.AddField(new EntityField("所在校区", false));
            this.AddField(new EntityField("其他说明", false));
        }


        /// <summary>
        /// 【DataID】：【】 字段
        /// 数据类型：varchar；最大长度：32；是否可空：yes
        /// </summary>
        public string DataID
        {
            get { return base["DataID"].Value.ConvertToString(); }
            set { base["DataID"].Value = value; }
        }

        /// <summary>
        /// 【DataID】：【】 字段属性
        /// 数据类型：varchar；最大长度：32；是否可空：yes
        /// </summary>
        public EntityField DataIDAttribute
        {
            get { return base["DataID"]; }
            set { base["DataID"] = value; }
        }

        /// <summary>
        /// 【ImportDate】：【】 字段
        /// 数据类型：datetime；最大长度：8；是否可空：yes
        /// </summary>
        public DateTime ImportDate
        {
            get { return base["ImportDate"].Value.ConvertToDateTime(); }
            set { base["ImportDate"].Value = value; }
        }

        /// <summary>
        /// 【ImportDate】：【】 字段属性
        /// 数据类型：datetime；最大长度：8；是否可空：yes
        /// </summary>
        public EntityField ImportDateAttribute
        {
            get { return base["ImportDate"]; }
            set { base["ImportDate"] = value; }
        }

        /// <summary>
        /// 【ImportBatch】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string ImportBatch
        {
            get { return base["ImportBatch"].Value.ConvertToString(); }
            set { base["ImportBatch"].Value = value; }
        }

        /// <summary>
        /// 【ImportBatch】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField ImportBatchAttribute
        {
            get { return base["ImportBatch"]; }
            set { base["ImportBatch"] = value; }
        }

        /// <summary>
        /// 【ImportRemark】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string ImportRemark
        {
            get { return base["ImportRemark"].Value.ConvertToString(); }
            set { base["ImportRemark"].Value = value; }
        }

        /// <summary>
        /// 【ImportRemark】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField ImportRemarkAttribute
        {
            get { return base["ImportRemark"]; }
            set { base["ImportRemark"] = value; }
        }

        /// <summary>
        /// 【编号】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string 编号
        {
            get { return base["编号"].Value.ConvertToString(); }
            set { base["编号"].Value = value; }
        }

        /// <summary>
        /// 【编号】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField 编号Attribute
        {
            get { return base["编号"]; }
            set { base["编号"] = value; }
        }

        /// <summary>
        /// 【年份】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string 年份
        {
            get { return base["年份"].Value.ConvertToString(); }
            set { base["年份"].Value = value; }
        }

        /// <summary>
        /// 【年份】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField 年份Attribute
        {
            get { return base["年份"]; }
            set { base["年份"] = value; }
        }

        /// <summary>
        /// 【省份】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string 省份
        {
            get { return base["省份"].Value.ConvertToString(); }
            set { base["省份"].Value = value; }
        }

        /// <summary>
        /// 【省份】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField 省份Attribute
        {
            get { return base["省份"]; }
            set { base["省份"] = value; }
        }

        /// <summary>
        /// 【学历层次】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string 学历层次
        {
            get { return base["学历层次"].Value.ConvertToString(); }
            set { base["学历层次"].Value = value; }
        }

        /// <summary>
        /// 【学历层次】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField 学历层次Attribute
        {
            get { return base["学历层次"]; }
            set { base["学历层次"] = value; }
        }

        /// <summary>
        /// 【学院】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string 学院
        {
            get { return base["学院"].Value.ConvertToString(); }
            set { base["学院"].Value = value; }
        }

        /// <summary>
        /// 【学院】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField 学院Attribute
        {
            get { return base["学院"]; }
            set { base["学院"] = value; }
        }

        /// <summary>
        /// 【专业】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string 专业
        {
            get { return base["专业"].Value.ConvertToString(); }
            set { base["专业"].Value = value; }
        }

        /// <summary>
        /// 【专业】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField 专业Attribute
        {
            get { return base["专业"]; }
            set { base["专业"] = value; }
        }

        /// <summary>
        /// 【类别】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string 类别
        {
            get { return base["类别"].Value.ConvertToString(); }
            set { base["类别"].Value = value; }
        }

        /// <summary>
        /// 【类别】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField 类别Attribute
        {
            get { return base["类别"]; }
            set { base["类别"] = value; }
        }

        /// <summary>
        /// 【科目】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string 科目
        {
            get { return base["科目"].Value.ConvertToString(); }
            set { base["科目"].Value = value; }
        }

        /// <summary>
        /// 【科目】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField 科目Attribute
        {
            get { return base["科目"]; }
            set { base["科目"] = value; }
        }

        /// <summary>
        /// 【计划数】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string 计划数
        {
            get { return base["计划数"].Value.ConvertToString(); }
            set { base["计划数"].Value = value; }
        }

        /// <summary>
        /// 【计划数】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField 计划数Attribute
        {
            get { return base["计划数"]; }
            set { base["计划数"] = value; }
        }

        /// <summary>
        /// 【收费标准】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string 收费标准
        {
            get { return base["收费标准"].Value.ConvertToString(); }
            set { base["收费标准"].Value = value; }
        }

        /// <summary>
        /// 【收费标准】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField 收费标准Attribute
        {
            get { return base["收费标准"]; }
            set { base["收费标准"] = value; }
        }

        /// <summary>
        /// 【所在校区】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string 所在校区
        {
            get { return base["所在校区"].Value.ConvertToString(); }
            set { base["所在校区"].Value = value; }
        }

        /// <summary>
        /// 【所在校区】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField 所在校区Attribute
        {
            get { return base["所在校区"]; }
            set { base["所在校区"] = value; }
        }

        /// <summary>
        /// 【其他说明】：【】 字段
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public string 其他说明
        {
            get { return base["其他说明"].Value.ConvertToString(); }
            set { base["其他说明"].Value = value; }
        }

        /// <summary>
        /// 【其他说明】：【】 字段属性
        /// 数据类型：varchar；最大长度：200；是否可空：no
        /// </summary>
        public EntityField 其他说明Attribute
        {
            get { return base["其他说明"]; }
            set { base["其他说明"] = value; }
        }
    }

}

