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

        /// <summary>
        /// 添加部门
        /// </summary>
        /// <returns></returns>
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

        public ActionResult Detail(int? ID)
        {
            var Dpt = db.Department.Find(ID);
            return Json(Dpt);
        }
    }
}