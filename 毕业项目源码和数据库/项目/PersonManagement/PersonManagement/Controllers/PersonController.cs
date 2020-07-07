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
            ViewBag.Person = db.Person.Where(n => Name == "" || n.Name.Contains(Name)).ToList();
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
                return RedirectToAction("PersonInfo", "Person");
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
        public ActionResult EditSingleInfo(string UserName, string UserPwd, string ID, string Age, string Phone, string Address) {
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
            return RedirectToAction("PMyInfo", "Person");
        }

        //考勤
        public ActionResult PMyAttendance()
        {
            string PersonName = Session["FrontLoginName"].ToString();
            var person = db.Person.Where(p => p.Name == PersonName).SingleOrDefault();
            int id = person.ID;
            string year = DateTime.Now.Year.ToString();
            string month = DateTime.Now.Month.ToString();
            string day = DateTime.Now.Day.ToString();
            var att = db.Attendance.Where(p => p.PersonID == id && p.TadayTime.Year.ToString() == year && p.TadayTime.Month.ToString() == month && p.TadayTime.Day.ToString() == day).SingleOrDefault();
            if (att == null)
            {
                att = null;
            }
            ViewBag.Attendance = att;
            return View();
        }
        //打卡
        public ActionResult PMyOK()
        {
            string PersonName = Session["FrontLoginName"].ToString();
            var person = db.Person.Where(p => p.Name == PersonName).SingleOrDefault();
            int id = person.ID;
            Attendance att = new Attendance();
            att.PersonID = id;
            att.TadayTime = DateTime.Now;
            att.StartTime = DateTime.Now;
            string endtime = DateTime.Now.Year.ToString() + "-"
                + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString() + " 22:00:00.000";
            DateTime EndTime = DateTime.Parse(endtime);
            att.EndTime = EndTime;
            db.Attendance.Add(att);
            db.SaveChanges();
            return RedirectToAction("PMyAttendance", "Person");
        }
        //所有记录
        public ActionResult PMyAttRecord()
        {
            string PersonName = Session["FrontLoginName"].ToString();
            var person = db.Person.Where(p => p.Name == PersonName).SingleOrDefault();
            int id = person.ID;
            List<Attendance> att = db.Attendance.OrderByDescending(n => n.TadayTime).Where(p => p.PersonID == id).ToList();
            if (att.Count() == 0)
            {
                att = null;
            }
            ViewBag.AttRecord = att;
            return View();
        }

        //薪资
        public ActionResult PMyPay(string OverTime = "")
        {
            string PersonName = Session["FrontLoginName"].ToString();
            var person = db.Person.Where(p => p.Name == PersonName).SingleOrDefault();
            int id = person.ID;
            if (OverTime == "")
            {
                var pay = db.Pay.Where(p => OverTime == "" && p.PersonID == id).ToList();
                if (pay.Count() == 0)
                {
                    pay = null;
                }
                ViewBag.MyPay = pay;
            }
            else
            {
                DateTime overtime = DateTime.Parse(OverTime);
                var pay = db.Pay.Where(p => (OverTime == "" || p.OverTime == overtime) && p.PersonID == id).ToList();
                if (pay.Count() == 0)
                {
                    pay = null;
                }
                ViewBag.MyPay = pay;
            }
            return View();
        }

        //培训
        public ActionResult PMyTrain(string Topic = "")
        {
            string PersonName = Session["FrontLoginName"].ToString();
            var person = db.Person.Where(p => p.Name == PersonName).SingleOrDefault();
            string name = person.Name;
            var train = db.Train.Where(p => (Topic == "" || p.Topic.Contains(Topic)) && p.Number.Contains(name)).ToList();
            if (train.Count() == 0)
            {
                train = null;
            }
            ViewBag.MyTrain = train;
            ViewBag.Person = person;
            return View();
        }

        //奖惩
        public ActionResult PMyReward(string RewardType = "")
        {
            string PersonName = Session["FrontLoginName"].ToString();
            var person = db.Person.Where(p => p.Name == PersonName).SingleOrDefault();
            int id = person.ID;
            if (RewardType == "全部")
            {
                var reward = db.Reward.Where(p => p.PersonID == id).ToList();
                if (reward.Count() == 0)
                {
                    reward = null;
                }
                ViewBag.MyReward = reward;
            }
            else if (RewardType == "奖励" || RewardType == "惩罚")
            {
                var reward = db.Reward.Where(p => p.RewardType.Contains(RewardType) && p.PersonID == id).ToList();
                if (reward.Count() == 0)
                {
                    reward = null;
                }
                ViewBag.MyReward = reward;
            }
            else
            {
                var reward = db.Reward.Where(p => RewardType == "" && p.PersonID == id).ToList();
                if (reward.Count() == 0)
                {
                    reward = null;
                }
                ViewBag.MyReward = reward;
            }
            return View();
        }

        //消息
        public ActionResult PMyMessage(string State = "")
        {
            string PersonName = Session["FrontLoginName"].ToString();
            var person = db.Person.Where(p => p.Name == PersonName).SingleOrDefault();
            int id = person.ID;
            if (State == "全部")
            {
                var apm = db.A_P_Message.Where(p => p.PersonID == id).ToList();
                if (apm.Count() == 0)
                {
                    apm = null;
                }
                ViewBag.APMessage = apm;
            }
            else if (State == "0" || State == "1")
            {
                int state = int.Parse(State);
                var apm = db.A_P_Message.Where(p => p.State == state && p.PersonID == id).ToList();
                if (apm.Count() == 0)
                {
                    apm = null;
                }
                ViewBag.APMessage = apm;
            }
            else
            {
                var apm = db.A_P_Message.Where(p => State == "" && p.PersonID == id).ToList();
                if (apm.Count() == 0)
                {
                    apm = null;
                }
                ViewBag.APMessage = apm;
            }
            return View();
        }
        //发送消息
        public ActionResult PMySendMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult PMySendMessage(string Message, string Reason)
        {
            if (Message == "" && Reason == "")
            {
                return Content("false");
            }
            else if (Message == "" || Reason == "")
            {
                if (Message == "")
                {
                    return Content("Message");
                }
                if (Reason == "")
                {
                    return Content("Reason");
                }
            }
            else
            {
                A_P_Message apm = new A_P_Message();
                string PersonName = Session["FrontLoginName"].ToString();
                var person = db.Person.Where(p => p.Name == PersonName).SingleOrDefault();
                int id = person.ID;
                apm.PersonID = id;
                apm.Message = Message;
                apm.Reason = Reason;
                apm.SendTime = DateTime.Now;
                apm.State = 0;
                db.A_P_Message.Add(apm);
                db.SaveChanges();
                return Content("true");
            }
            return View();
        }
        //查看消息
        public ActionResult PMyLookMessage(int? id)
        {
            var apm = db.A_P_Message.Find(id);
            ViewBag.APMessage = apm;
            return View();
        }
    }
}