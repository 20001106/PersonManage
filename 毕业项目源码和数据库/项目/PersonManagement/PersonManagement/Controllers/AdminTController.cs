using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PersonManagement.Models;

namespace PersonManagement.Controllers
{
    public class AdminTController : Controller
    {
        // GET: AdminT--后台登录首页
        public ActionResult Index()
        {
            return View();
        }
    }
}