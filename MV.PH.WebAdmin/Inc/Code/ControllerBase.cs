using System;
using System.Web.Mvc;
using System.Web.Routing;
using Lib.Data;
using Lib.Tool;

/// <summary>
/// 控制器基类
/// </summary>
public class ControllerBase : Controller
{
    private int __pageSize = 15;

    protected int PageSize
    {
        get { return this.__pageSize; }
        set { this.__pageSize = value; }
    }

    private SqlDataAccess __dataAccess;

    protected SqlDataAccess GlobalDataAccess
    {
        get
        {
            if (this.__dataAccess == null)
            {
                this.__dataAccess = new SqlDataAccess("default");
            }

            return this.__dataAccess;
        }
        set
        {
            this.__dataAccess = value;
        }
    }

    protected string UserID { get; set; }

    private string UserIDKey { get { return "__userID"; } }

    /// <summary>
    /// view方法调用之前调用的方法
    /// </summary>
    protected virtual void BeforeMethodExecute()
    {
    }

    /// <summary>
    /// view方法调用之后调用的方法
    /// </summary>
    protected virtual void AfterMethodExecute()
    {

    }

    protected string ActionName
    {
        get
        {
            return Tools.ToString(RouteData.Route.GetRouteData(this.HttpContext).Values["action"]).ToLower();
        }
    }

    protected virtual void CheckAttribute()
    {
        //ControllerInfoAttribute attr = Attr.GetAttribute<ControllerInfoAttribute>(this, this.ActionName);
        //if (attr == null)
        //{
        //    return;
        //}
        //if (attr.IsCheckLogin)
        //{
        //    if (string.IsNullOrEmpty(this.UserID))
        //    {
        //        Response.Redirect("/default/login/");
        //    }
        //}
    }

    //protected override IAsyncResult BeginExecute(RequestContext requestContext, AsyncCallback callback, object state)
    //{
    //    return base.BeginExecute(requestContext, callback, state);
    //}

    //protected override void EndExecute(IAsyncResult asyncResult)
    //{
    //    this.UserID = Tools.S(this.UserIDKey);
    //    this.CheckAttribute();
    //    this.BeforeMethodExecute();
    //    base.EndExecute(asyncResult);
    //    this.AfterMethodExecute();
    //}

    protected override void Dispose(bool disposing)
    {
        this.GlobalDataAccess.Dispose();
        this.GlobalDataAccess = null;
        base.Dispose(disposing);
    }
   
}
