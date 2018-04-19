using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MV.PH.WebAdmin.Inc;
namespace MV.PH.WebAdmin.Inc
{
    public class AjaxMsg
    {
        public static ActionResult AjaxMsgs(AjaxStatusEnum status, string message, object data = null, JsonRequestBehavior Behavior = JsonRequestBehavior.DenyGet)
        {
            var amm = new
            {
                Status = status,
                Message = message,
                Data = data ?? string.Empty
            };
            JsonResult jsonRes = new JsonResult();
            jsonRes.Data = amm;
            jsonRes.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return jsonRes;
        }

        public static ActionResult AjaxInfo(string message, string status)
        {
            var amm = new
            {
                status = status,
                info = message
            };
            JsonResult jsonRes = new JsonResult();
            jsonRes.Data = amm;
            return jsonRes;
        }

        

}
}