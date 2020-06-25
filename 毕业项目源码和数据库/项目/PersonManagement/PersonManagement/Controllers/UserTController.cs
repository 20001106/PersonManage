using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PersonManagement.Models;

namespace PersonManagement.Controllers
{
    public class UserTController : Controller
    {
        PersonManagementEntities db = new PersonManagementEntities();
        // GET: UserT--用户登录注册界面
        public ActionResult LoginRegister()
        {
            return View();
        }

        //登录验证
        [HttpPost]
        public ActionResult Login(string UserName, string UserPwd)
        {
            if (string.IsNullOrEmpty(UserName) && string.IsNullOrEmpty(UserPwd))//判断是否为空
            {
                return Content("false");
            }
            else if (string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(UserPwd))//判断哪个为空
            {
                if (string.IsNullOrEmpty(UserName))
                {
                    return Content("UserNamefalse");
                }
                if (string.IsNullOrEmpty(UserPwd))
                {
                    return Content("UserPwdfalse");
                }
            }
            else
            {
                var userT = db.UserT.Where(u => u.UserName == UserName && u.UserPwd == UserPwd).SingleOrDefault();
                if (userT == null)//判断是否有值
                {
                    return Content("false1");
                }
                else
                {
                    if (userT.PersonID == 0)
                    {
                        //针对未录用的用户进行判断
                        Session["FrontLoginName"] = userT.UserName;
                        Session["ruserID"] = 0;//进行比较的用户设为0
                    }
                    else 
                    {
                        //针对员工进行判断
                        var person = db.Person.Where(p => p.ID == userT.PersonID).SingleOrDefault();
                        Session["FrontLoginName"] = person.Name;
                        Session["ruserID"] = 1;//进行比较的员工设为0
                    }
                    return Content("true");
                }
            }
            return RedirectToAction("FrontHome","FrontPage");
        }

        //注册验证
        [HttpPost]
        public ActionResult Register(string UserNameR, string UserPwdR, string UserPwdRO)
        {
            if (string.IsNullOrEmpty(UserNameR) && string.IsNullOrEmpty(UserPwdR) && string.IsNullOrEmpty(UserPwdRO))//判断是否为空
            {
                return Content("false");
            }
            else if (string.IsNullOrEmpty(UserNameR) || string.IsNullOrEmpty(UserPwdR) || string.IsNullOrEmpty(UserPwdRO))//判断哪个为空
            {
                if (string.IsNullOrEmpty(UserNameR))
                {
                    return Content("UserNameRfalse");
                }
                if (string.IsNullOrEmpty(UserPwdR))
                {
                    return Content("UserPwdRfalse");
                }
                if (string.IsNullOrEmpty(UserPwdRO))
                {
                    return Content("UserPwdROfalse");
                }
            }
            else if (UserPwdR != UserPwdRO)
            {
                return Content("RO");
            }
            else
            {
                var userT = db.UserT.Where(p => p.UserName == UserNameR).SingleOrDefault();
                if (userT != null)
                {
                    return Content("UN");
                }
                else
                {
                    UserT ut = new UserT();
                    ut.PersonID = 0;
                    ut.UserName = UserNameR;
                    ut.UserPwd = UserPwdR;
                    db.UserT.Add(ut);
                    db.SaveChanges();
                    return Content("true");
                }
            }
            return RedirectToAction("LoginRegister", "UserT");
        }
    }
}