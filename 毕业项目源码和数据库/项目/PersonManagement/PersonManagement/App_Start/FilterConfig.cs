using PersonManagement.Models;
using System.Web;
using System.Web.Mvc;

namespace PersonManagement
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());

            //注册全局
            //filters.Add(new MyFilterAttribute());
        }
    }
}
