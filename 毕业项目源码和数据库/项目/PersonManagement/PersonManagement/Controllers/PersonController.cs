using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PersonManagement.Models;

namespace PersonManagement.Controllers
{
    public class PersonController : Controller
    {
        PersonManagementEntities db = new PersonManagementEntities();
        // GET: Person
        public ActionResult PersonInfo(string Name = "")
        {
            ViewBag.Person = db.Person.OrderByDescending(p => p.ID).Where(n => Name == "" || n.Name.Contains(Name)).ToList();
            return View();
        }

        //查看员工个人信息
        public ActionResult PersonDetail(int? id)
        {
            ViewBag.PersonSingleDetail = db.Person.Find(id);
            return View();
        }

        //删除员工
        public ActionResult PersonDelete(int? id)
        {
            List<Attendance> Alist = db.Attendance.Where(p => p.PersonID == id).ToList();
            List<Pay> Plist = db.Pay.Where(p => p.PersonID == id).ToList();
            List<Reward> Rlist = db.Reward.Where(p => p.PersonID == id).ToList();
            List<A_P_Message> APMlist = db.A_P_Message.Where(p => p.PersonID == id).ToList();
            Person person = db.Person.Find(id);
            if (Alist.Count > 0)
            {
                TempData["Tips"] = person.Name + "员工有考勤信息记录，不能删除！";
                return RedirectToAction("PersonInfo","Person");
            }
            else if (Plist.Count > 0)
            {
                TempData["Tips"] = person.Name + "员工有薪资信息记录，不能删除！";
                return RedirectToAction("PersonInfo", "Person");
            }
            else if (Rlist.Count > 0)
            {
                TempData["Tips"] = person.Name + "员工有奖惩信息记录，不能删除！";
                return RedirectToAction("PersonInfo", "Person");
            }
            else if (APMlist.Count > 0)
            {
                TempData["Tips"] = person.Name + "员工有互动消息记录，不能删除！";
                return RedirectToAction("PersonInfo", "Person");
            }
            else
            {
                db.Person.Remove(person);
                db.SaveChanges();
                return RedirectToAction("PersonInfo", "Person");
            }
        }

        //前端界面，员工个人信息整合
        public ActionResult PUCenter() 
        {
            return View();
        }
    }
}