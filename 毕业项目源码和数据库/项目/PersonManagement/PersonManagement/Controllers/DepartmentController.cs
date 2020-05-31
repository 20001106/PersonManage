using System;
using System.Collections.Generic;
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
        public ActionResult DptInfo()
        {
            ViewBag.Dpt = db.Department.ToList();
            return View();
        }

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
    }
}