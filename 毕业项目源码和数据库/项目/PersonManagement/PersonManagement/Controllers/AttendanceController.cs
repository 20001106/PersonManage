using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using Microsoft.OData.Edm;
using PersonManagement.Models;

namespace PersonManagement.Controllers
{
    public class AttendanceController : Controller
    {
        PersonManagementEntities db = new PersonManagementEntities();
        // GET: Attendance
        public ActionResult AttInfo(string TadayTime = "")
        {
            List<Attendance> att = db.Attendance.Where(p => p.TadayTime.ToString() == TadayTime).ToList();

            //记录人数
            var person = db.Person.Count();//所有员工
            var attperson = att.Count();//参与人数
            var atted = person - attperson;

            var tadaytime = "";
            if (TadayTime == "")
            {
                tadaytime = DateTime.Now.ToShortDateString();
            }
            else
            {
                tadaytime = TadayTime;
            }

            ViewBag.AttTime = att;
            ViewBag.AttTaday = tadaytime;
            ViewBag.AttTadayCount = attperson;
            ViewBag.AttTadayNoCount = atted;
            ViewBag.Person = person;
            return View();
        }
    }
}