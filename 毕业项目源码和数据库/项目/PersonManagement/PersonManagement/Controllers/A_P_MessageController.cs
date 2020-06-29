using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PersonManagement.Models;

namespace PersonManagement.Controllers
{
    public class A_P_MessageController : Controller
    {
        PersonManagementEntities db = new PersonManagementEntities();
        // GET: A_P_Message
        public ActionResult APMessage(string State = "", string ID = "")
        {
            if (!string.IsNullOrEmpty(State))
            {
                if (State == "全部")
                {
                    ViewBag.Apm = db.A_P_Message.OrderByDescending(p => p.SendTime).ToList();
                }
                if (State == "0")
                {
                    int sid = int.Parse(State);
                    ViewBag.Apm = db.A_P_Message.OrderByDescending(p => p.SendTime).Where(n => State == "" || n.State == sid).ToList();
                }
                if (State == "1")
                {
                    int sid = int.Parse(State);
                    ViewBag.Apm = db.A_P_Message.OrderByDescending(p => p.SendTime).Where(n => State == "" || n.State == sid).ToList();
                }
                if (State == "--请选择--")
                {
                    ViewBag.Apm = null;
                }
            }
            else if (!string.IsNullOrEmpty(ID))
            {
                if (ID == "--请选择--")
                {
                    ViewBag.Apm = null;
                }
                else if (ID == "全部")
                {
                    ViewBag.Apm = db.A_P_Message.OrderByDescending(p => p.SendTime).ToList();
                }
                else
                {
                    int id = int.Parse(ID);
                    ViewBag.Apm = db.A_P_Message.OrderByDescending(p => p.SendTime).Where(p => ID == "" || p.PersonID == id).ToList();
                }
            }
            else
            {
                ViewBag.Apm = db.A_P_Message.OrderByDescending(p => p.SendTime).ToList();
            }
            ViewBag.Person = db.Person.ToList();
            return View();
        }

        //回复员工
        public ActionResult APMReply(int? id)
        {
            ViewBag.APMPersonSingle = db.A_P_Message.Find(id);
            return View();
        }
        [HttpPost]
        public ActionResult APMReply(string ID, string ReplyMessage)
        {
            if (ReplyMessage == "")
            {
                return Content("false");
            }
            else
            {
                int id = int.Parse(ID);
                string adminName = Session["LoginName"].ToString();
                var apm = db.A_P_Message.Where(p => p.ID == id).SingleOrDefault();
                apm.State = 1;
                apm.ReplyMessage = ReplyMessage;
                apm.ReplyTime = DateTime.Now;
                apm.ReplyAdmin = adminName;
                db.Entry(apm).State = EntityState.Modified;
                db.SaveChanges();
                return Content("true");
            }
        }

        //查看管理回复员工的信息
        public ActionResult APMLook(int? id)
        {
            ViewBag.APMPersonSingle = db.A_P_Message.Find(id);
            return View();
        }
    }
}