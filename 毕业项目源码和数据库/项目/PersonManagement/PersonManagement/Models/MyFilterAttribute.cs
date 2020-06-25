using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonManagement.Models
{
    public class MyFilterAttribute : ActionFilterAttribute
    {
        //实现接口方法
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //控制器名称
            string controller = filterContext.RouteData.Values["controller"].ToString();
            if (controller == "AdminT")
            {
                base.OnActionExecuting(filterContext);
                return;
            }
            //调用Get方法判断Session为空
            string LoginName = SessionHelper.Get("LoginName");
            if (string.IsNullOrEmpty(LoginName))
            {
                //这里构造了一个新的ActionResult
                filterContext.Result = new RedirectResult("/AdminT/Index");
                return;
            }
            else
            {
                base.OnActionExecuting(filterContext);
                return;
            }
        }
    }
}