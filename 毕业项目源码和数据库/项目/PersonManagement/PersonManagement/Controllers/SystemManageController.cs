using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PersonManagement.Models;

namespace PersonManagement.Controllers
{
    public class SystemManageController : Controller
    {
        PersonManagementEntities db = new PersonManagementEntities();
        // GET: SystemManage--后台首页
        
        //注销
        public ActionResult LogOut()
        {
            Session["LoginName"] = "";
            Session.Clear();//清除Session
            return RedirectToAction("Index", "AdminT");
        }

        //首页
        public ActionResult BgHome()
        {
            return View();
        }

        //查看该系统管理员
        public ActionResult Administrator()
        {
            ViewBag.Admin = db.AdminT.ToList();
            return View();
        }

        //更改管理
        public ActionResult AdminUpdate(string LoginName, string LoginPwd)
        {
            if (string.IsNullOrEmpty(LoginName))
            {
                return Content("false");
            }
            else if (string.IsNullOrEmpty(LoginPwd))
            {
                return Content("false1");
            }
            else
            {
                AdminT admin = db.AdminT.SingleOrDefault(p => p.LoginName == LoginName);
                admin.LoginPwd = LoginPwd;
                db.Entry(admin).State = EntityState.Modified;
                db.SaveChanges();
                return Content("true");
            }
        }

        //公告栏
        public ActionResult BulletinBoard()
        {
            return View();
        }
    }
}