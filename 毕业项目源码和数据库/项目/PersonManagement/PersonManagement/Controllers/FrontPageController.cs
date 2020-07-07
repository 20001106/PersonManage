using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PersonManagement.Models;

namespace PersonManagement.Controllers
{
    public class FrontPageController : Controller
    {
        PersonManagementEntities db = new PersonManagementEntities();
        // GET: FrontPage--前端首页，在这里运行
        public ActionResult FrontHome()
        {
            return View();
        }

        //注销用户信息
        public ActionResult LogOut()
        {
            Session["FrontLoginName"] = "";
            Session["ruserID"] = "";
            Session.Clear();//清除Session
            return RedirectToAction("LoginRegister","UserT");
        }

        //关于
        public ActionResult FrontAbout()
        {
            return View();
        }
    }
}