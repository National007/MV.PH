using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MV.PH.WebAdmin.Model.Column
{
    public class Column_dal:ControllerBase
    {
        #region  //通过父栏目ID获取子栏目数量
        public int GetChildrenColumn(string ColumnID)
        {
            string sql = string.Format(@"select 
                                                count(0) 
                                            from 
                                                T_Column 
                                            where ColumnParentID='{0}'",ColumnID);
            int i = Convert.ToInt32(this.GlobalDataAccess.ExecuteScalar(sql));
            return i;
        }
        #endregion

        #region //通过栏目ID获取栏目名称
        public string GetColumnNameByColumnID(string ColumnID)
        {
            string sql = string.Format(@"select 
                                                ColumnName 
                                            from 
                                                T_Column 
                                            where ColumnID='{0}'", ColumnID);
            string i = Convert.ToString(this.GlobalDataAccess.ExecuteScalar(sql));
            return i;
        }
        #endregion

    }
}