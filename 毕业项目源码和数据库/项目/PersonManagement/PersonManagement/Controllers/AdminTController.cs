﻿using System;
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
        // GET: AdminT--后台登录首页
        public ActionResult Index()
        {
            //登录
            return View();
        }
        [HttpPost]
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
            return RedirectToAction("BgHome","AdminT");
        }

        //注销
        public ActionResult LogOut()
        {
            Session["LoginName"] = "";
            Session.Clear();//清除Session
            return RedirectToAction("Index", "AdminT");
        }

        //版本
        public ActionResult Versions()
        {
            return View();
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
                return Content("false1") ;
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
    }
}