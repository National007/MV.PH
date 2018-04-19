using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MV.PH.WebAdmin.Model.Menu
{
    public class BreadCrumbsModel
    {
        public BreadCrumbsModel()
        {
            BreadCrumbList = new List<BreadCrumbModel>();
        }
        public bool IsOnlyIndex { get; set; }
        public string CurrentName { get; set; }

        public List<BreadCrumbModel> BreadCrumbList { get; set; }
    }
    public class BreadCrumbModel
    {
        public bool IsIndex { get; set; }
        public bool IsParent { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Id { get; set; }
    }

}