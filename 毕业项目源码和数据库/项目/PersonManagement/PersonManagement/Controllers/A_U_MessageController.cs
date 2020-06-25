using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PersonManagement.Models;

namespace PersonManagement.Controllers
{
    public class A_U_MessageController : Controller
    {
        PersonManagementEntities db = new PersonManagementEntities();
        // GET: A_U_Message--管理发送录取信息
        public ActionResult AUMInfo()
        {
            string UserName = Session["FrontLoginName"].ToString();
            var user = db.UserT.Where(p => p.UserName == UserName).SingleOrDefault();
            var aum = db.A_U_Message.Where(p => p.UserID == user.ID).SingleOrDefault();
            if (aum == null)
            {
                aum = null;
            }

            var epm = db.Employment.Where(p => p.UserID == user.ID).SingleOrDefault();
            if (epm == null)
            {
                epm = null;
            }
            else
            {
                ViewBag.DptUser = db.Department.Where(p => p.ID == epm.DptID).SingleOrDefault();
            }

            ViewBag.EpmUser = epm;
            ViewBag.User = user;
            ViewBag.Aum = aum;
            return View();
        }

        //确定录用后，同步用户表与员工表，记录信息
        [HttpPost]
        public ActionResult P_U_Add(string NameTag)
        {
            string UserName = Session["FrontLoginName"].ToString();
            var person = db.Person.Where(p => p.Name == NameTag).SingleOrDefault();//获取员工
            var user = db.UserT.Where(p => p.UserName == UserName).SingleOrDefault();//获取用户
            if (user.PersonID == 0)
            {
                user.PersonID = person.ID;
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return Content("true");
            }
            else
            {
                return Content("false");
            }
        }
    }
}