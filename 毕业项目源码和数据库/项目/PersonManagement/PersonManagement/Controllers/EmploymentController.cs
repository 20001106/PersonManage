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
            ViewBag.EpmSingleDetail = db.Employment.Find(id);
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
                person.DptID = epm.Department.ID;
                person.Diploma = epm.Diploma;
                person.Major = epm.Major;
                person.Remark = epm.Remark;

                //修改该应聘者录用状态
                epm.State = 1;
                db.Entry(epm).State = EntityState.Modified;

                db.Person.Add(person);
                db.SaveChanges();
                return RedirectToAction("PersonInfo", "Person");
            }
        }

        //招聘
        public ActionResult EpmAdd()
        {
            ViewBag.Dpt = db.Department.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult EpmAdd(Employment epm)
        {
            db.Employment.Add(epm);
            db.SaveChanges();
            TempData["epmgo"] = "应聘成功，请等待后续通知，留意通知栏！";
            return RedirectToAction("EpmAdd", "Employment");
        }
    }
}