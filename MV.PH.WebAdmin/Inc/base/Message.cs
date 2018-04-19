using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MV.PH.WebAdmin.Inc
{
        public enum AjaxStatusEnum
        {
            /// <summary>
            /// 成功
            /// </summary>
            Success = 1,
            /// <summary>
            /// 操作失败(数据)
            /// </summary>
            Fail = 0,
            /// <summary>
            /// 系统错误
            /// </summary>
            Error = -1,
            /// <summary>
            /// 逻辑条件不合
            /// </summary>
            Alert = -2
        }
    
    public enum Post
    {
        SuperAdmin=1,
        GenerAdmin=0
    }

}