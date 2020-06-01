using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Windows;
using Microsoft.Ajax.Utilities;
using PersonManagement.Models;

namespace PersonManagement.Controllers
{
    public class AdminTController : Controller
    {
        PersonManagementEntities db = new PersonManagementEntities();
        // GET: AdminT--后台登录首页
        public ActionResult Index()
        {
            //登录
            return View();
        }
        [HttpPost]
        public ActionResult Index(string LoginName, string LoginPwd)
        {
            if (string.IsNullOrEmpty(LoginName) || string.IsNullOrEmpty(LoginName))
            {
                return Content("<script>alert('账号或密码不能为空!');history.go(-1)</script>");
            }
            else
            {
                var adminT = db.AdminT.Where(u => u.LoginName == LoginName && u.LoginPwd == LoginName).SingleOrDefault();
                if (adminT == null)
                {
                    return Content("<script>alert('账户或密码错误！');history.go(-1)</script>");

                }
                else
                {
                    Session["LoginName"] = LoginName;
                    return RedirectToAction("DptInfo", "Department");
                }
            }
        }

        public ActionResult Quit()
        {
            
            return View();
        }
    }
}