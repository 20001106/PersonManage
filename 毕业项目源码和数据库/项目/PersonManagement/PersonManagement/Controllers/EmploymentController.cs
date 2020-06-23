using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PersonManagement.Models;

namespace PersonManagement.Controllers
{
    public class EmploymentController : Controller
    {
        PersonManagementEntities db = new PersonManagementEntities();
        // GET: Employment--招聘
        public ActionResult EpmInfo(string Name = "")
        {
            ViewBag.Epm = db.Employment.OrderByDescending(p => p.ID).Where(n => (Name == "" || n.Name.Contains(Name)) && n.DeleteRecord == 0).ToList();
            return View();
        }

        //查看应聘者详细信息
        public ActionResult EpmDetail(int? id)
        {
            var epm = db.Employment.Find(id);
            ViewBag.EpmSingleDetail = epm;
            ViewBag.DptUser = db.Department.Where(p => p.ID == epm.DptID).SingleOrDefault();
            return View();
        }

        //删除应聘者
        public ActionResult EpmDelete(int? id)
        {
            Employment epm = db.Employment.Find(id);
            if (epm.State == 1)
            {
                TempData["Tips"] = epm.Name + "已录用，不可删除！";
                return RedirectToAction("EpmInfo", "Employment");
            }
            else
            {
                epm.DeleteRecord = 1;
                db.Entry(epm).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("EpmInfo", "Employment");
            }
        }

        //恢复删除
        public ActionResult EpmDeleteRecord(string Name = "")
        {
            ViewBag.Epm = db.Employment.OrderByDescending(p => p.ID).Where(n => (Name == "" || n.Name.Contains(Name)) && n.DeleteRecord == 1).ToList();
            return View();
        }

        //恢复
        public ActionResult Record(int? id)
        {
            Employment epm = db.Employment.Find(id);
            epm.DeleteRecord = 0;
            db.Entry(epm).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("EpmInfo", "Employment");
        }

        //录用应聘者
        public ActionResult EpmEnroll(int? id)
        {
            Employment epm = db.Employment.Find(id);
            if (epm.State == 1)
            {
                TempData["Tips"] = "该应聘者已录用！";
                return RedirectToAction("EpmDetail", "Employment", new { id=id });
            }
            else
            {
                Person person = new Person();
                person.Name = epm.Name;
                person.Sex = epm.Sex;
                person.Age = epm.Age;
                person.IDCard = epm.IDCard;
                person.Address = epm.Address;
                person.Native_place = epm.Native_place;
                person.Phone = epm.Phone;
                person.Email = epm.Email;
                person.DptID = epm.DptID;
                person.Diploma = epm.Diploma;
                person.Major = epm.Major;
                person.Remark = epm.Remark;

                //修改该应聘者录用状态
                epm.State = 1;
                db.Entry(epm).State = EntityState.Modified;

                db.Person.Add(person);//添加进员工表

                //处理用户管理表--提示已录取
                A_U_Message aum = new A_U_Message();
                aum.EpmID = epm.ID;
                aum.UserID = epm.UserID;
                aum.Topic = "恭喜你，已通过录用";
                db.A_U_Message.Add(aum);

                db.SaveChanges();
                return RedirectToAction("PersonInfo", "Person");
            }
        }

        //招聘
        public ActionResult EpmAdd()
        {
            string UserName = Session["FrontLoginName"].ToString();
            var user = db.UserT.Where(p => p.UserName == UserName).SingleOrDefault();//获取用户
            var epm = db.Employment.Where(p => p.UserID == user.ID).ToList();
            if (epm == null)
            {
                ViewBag.EpmUser = epm;
            }
            else
            {
                ViewBag.EpmUser = epm;
            }

            ViewBag.Dpt = db.Department.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult EpmAdd(Employment epm)
        {
            string UserName = Session["FrontLoginName"].ToString();
            var user = db.UserT.Where(p => p.UserName == UserName).SingleOrDefault();//获取用户

            epm.UserID = user.ID;
            db.Employment.Add(epm);
            db.SaveChanges();
            TempData["epmgo"] = "应聘成功，请等待后续通知，留意通知栏！";
            return RedirectToAction("EpmAdd", "Employment");
        }
    }
}