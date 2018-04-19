using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MV.PH.Entity;
using MV.PH.WebAdmin.Model.Menu;
using MV.PH.WebAdmin.Inc;

namespace MV.PH.WebAdmin.Controllers
{
    public class BreadCrumbsController : ControllerBase
    {
        // GET: BreadCrumbs
        [Login]
        public PartialViewResult Index(string id)
        {
            
            var model = new BreadCrumbsModel();
            MenuEntity ChildrenModel = this.GlobalDataAccess.FindEntity(new MenuEntity() {MenuID=id,IsEnable=1 });
            if (ChildrenModel == null)
            {
                Redirect("/Menu/List");
            }
            if (!string.IsNullOrWhiteSpace(ChildrenModel.MenuParentID))
            {
                MenuEntity ParentModel = this.GlobalDataAccess.FindEntity(new MenuEntity() { MenuID = ChildrenModel.MenuParentID, IsEnable = 1 });
                var parentBread = new BreadCrumbModel
                {
                    IsParent = true,
                    Name = ParentModel.MenuName,
                };
                model.BreadCrumbList.Add(parentBread);

                var currentBread = new BreadCrumbModel
                {
                    IsParent = false,
                    Name = ChildrenModel.MenuName,
                    Url = ChildrenModel.LinkAddress,
                    Id = ParentModel.MenuID
                };
                model.BreadCrumbList.Add(currentBread);
            }
            return PartialView(model);
        }
        [Login]
        public PartialViewResult ColumnBread(string Id)
        {
            var model = new BreadCrumbsModel();
            ColumnEntity ChildrenModel = this.GlobalDataAccess.FindEntity(new ColumnEntity() { ColumnID = Id, IsEnable = 1 });

            if (ChildrenModel != null)
            {
                if (!string.IsNullOrWhiteSpace(ChildrenModel.ColumnParentID))  //有parentID就显示
                {
                    ColumnEntity ParentModel = this.GlobalDataAccess.FindEntity(new ColumnEntity() { ColumnID = ChildrenModel.ColumnParentID, IsEnable = 1 });
                    var parentBread = new BreadCrumbModel
                    {
                        IsParent = true,
                        Name = ParentModel.ColumnName,
                    };
                    model.BreadCrumbList.Add(parentBread);

                    var currentBread = new BreadCrumbModel
                    {
                        IsParent = false,
                        Name = ChildrenModel.ColumnName,
                        Id = ParentModel.ColumnID
                    };
                    model.BreadCrumbList.Add(currentBread);
                }
                else
                {
                    var parentBread = new BreadCrumbModel
                    {
                        IsParent = true,
                        Name = ChildrenModel.ColumnName,
                    };
                    model.BreadCrumbList.Add(parentBread);
                }
            }

            return PartialView(model);
        }

    }
}