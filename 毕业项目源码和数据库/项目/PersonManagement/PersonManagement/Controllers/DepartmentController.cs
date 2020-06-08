using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PersonManagement.Models;

namespace PersonManagement.Controllers
{
    public class DepartmentController : Controller
    {
        PersonManagementEntities db = new PersonManagementEntities();
        // GET: Department--部门管理
        public ActionResult DptInfo(string Name = "")
        {
            ViewBag.Dpt = db.Department.Where(p => Name == "" || p.Name.Contains(Name)).ToList();
            ViewBag.Name = Name;
            return View();
        }

        //添加部门
        public ActionResult DptAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DptAdd(Department Dpt)
        {
            Dpt.CreateTime = DateTime.Now;
            db.Department.Add(Dpt);
            db.SaveChanges();
            return RedirectToAction("DptInfo","Department");
        }

        //删除部门
        public ActionResult DptDelete(int? id)
        {
            List<Person> Plist = db.Person.Where(p => p.DptID == id).ToList();
            if (Plist.Count > 0)
            {
                return Content("<script>alert('该部门有员工存在，不可删除！');history.go(-1)</script>");
            }
            else
            {
                Department Dpt = db.Department.Find(id);
                db.Department.Remove(Dpt);
                db.SaveChanges();
            }
            return RedirectToAction("DptInfo","Department");
        }

        //查看部门详细信息
        public ActionResult DptDetail(int? id)
        {
            ViewBag.DptSingleDetail = db.Department.Find(id);
            return View();
        }

        //编辑部门信息
        public ActionResult DptSave()
        {
            return View();
        }
    }
}