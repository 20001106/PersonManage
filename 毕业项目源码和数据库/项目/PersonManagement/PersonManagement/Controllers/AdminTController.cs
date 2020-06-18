using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        // GET: AdminT--登录
        public ActionResult Index()
        {
            //登录
            return View();
        }
        [HttpPost]
        [MyFilter]
        public ActionResult Index(string LoginName, string LoginPwd)
        {
            if (string.IsNullOrEmpty(LoginName) && string.IsNullOrEmpty(LoginPwd))
            {
                return Content("false");
            }
            else if (string.IsNullOrEmpty(LoginName) || string.IsNullOrEmpty(LoginPwd))
            {
                if (string.IsNullOrEmpty(LoginName))
                {
                    return Content("LoginNamefalse");
                }
                if (string.IsNullOrEmpty(LoginPwd))
                {
                    return Content("LoginPwdfalse");
                }
            }
            else
            {
                if (LoginName.Length >= 10 && LoginPwd.Length >= 10)
                {
                    return Content("TwoLength");
                }
                else if (LoginName.Length >= 10 || LoginPwd.Length >= 10)
                {
                    if (LoginName.Length >= 10)
                    {
                        return Content("LoginNameLengthfalse");
                    }
                    if (LoginPwd.Length >= 10)
                    {
                        return Content("LoginPwdLengthfalse");
                    }
                }
                else
                {
                    var adminT = db.AdminT.Where(u => u.LoginName == LoginName && u.LoginPwd == LoginPwd).SingleOrDefault();
                    if (adminT == null)
                    {
                        return Content("false1");
                    }
                    else
                    {
                        Session["LoginName"] = LoginName;
                        return Content("true");
                    }
                }
            }
            return RedirectToAction("BgHome", "SystemManage");
        }
    }
}