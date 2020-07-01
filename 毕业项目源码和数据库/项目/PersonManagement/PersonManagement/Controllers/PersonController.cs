using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        public ActionResult PCenter() 
        {
            return View();
        }

        //我的信息
        public ActionResult PMyInfo()
        {
            string PersonName = Session["FrontLoginName"].ToString();
            var person = db.Person.Where(p => p.Name == PersonName).SingleOrDefault();
            int id = person.ID;
            var user = db.UserT.Where(p => p.PersonID == id).SingleOrDefault();
            ViewBag.PersonSingle = person;
            ViewBag.UserSingle = user;
            return View();
        }
        //更改部分个人信息
        [HttpPost]
        public ActionResult EditSingleInfo(string UserName, string UserPwd,string ID, string Age, string Phone, string Address) {
            var user = db.UserT.Where(p => p.UserName == UserName).SingleOrDefault();
            user.UserPwd = UserPwd;
            int id = int.Parse(ID);
            int age = int.Parse(Age);
            var person = db.Person.Find(id);
            person.Age = age;
            person.Phone = Phone;
            person.Address = Address;
            db.Entry(user).State = EntityState.Modified;
            db.Entry(person).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("PMyInfo","Person");
        }

        //考勤
        public ActionResult PMyAttendance()
        {

            return View();
        }

        //薪资
        public ActionResult PMyPay()
        {

            return View();
        }

        //培训
        public ActionResult PMyTrain()
        {

            return View();
        }

        //奖惩
        public ActionResult PMyReward(string RewardType = "")
        {
            string PersonName = Session["FrontLoginName"].ToString();
            var person = db.Person.Where(p => p.Name == PersonName).SingleOrDefault();
            int id = person.ID;
            var reward = db.Reward.Where(p => (RewardType == "" || p.RewardType.Contains(RewardType)) && p.PersonID == id).ToList();
            if (reward.Count() == 0)
            {
                reward = null;
            }
            ViewBag.MyReward = reward;
            return View();
        }

        //消息
        public ActionResult PMyMessage()
        {

            return View();
        }
    }
}