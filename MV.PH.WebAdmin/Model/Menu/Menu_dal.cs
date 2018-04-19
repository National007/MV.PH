using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MV.PH.WebAdmin.Model.Menu
{
    public class Menu_dal: ControllerBase
    {
        #region  //通过父菜单ID获取子菜单数量
        //通过父菜单ID获取子菜单数量
        public int GetChildrenMenuCount(string MenuID)
        {
            string sql = string.Format(@"select 
                                            count(0) 
                                         from 
                                            T_Menu 
                                         where MenuParentID='{0}'", MenuID);
            int i = Convert.ToInt32(this.GlobalDataAccess.ExecuteScalar(sql));
            return i;
        }
        #endregion
    }
}