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
    public class PayController : Controller
    {
        PersonManagementEntities db = new PersonManagementEntities();
        // GET: Pay--薪资管理
        public ActionResult PayInfo(string OverTime = "", string Name = "")
        {
            if (!string.IsNullOrEmpty(OverTime))
            {
                DateTime ot = DateTime.Parse(OverTime);
                string year = ot.Year.ToString();
                string month = ot.Month.ToString();
                string day = ot.Day.ToString();
                ViewBag.Pay = db.Pay.Where(p => p.OverTime.Year.ToString() == year && p.OverTime.Month.ToString() == month && p.OverTime.Day.ToString() == day).ToList();
            }
            else if (!string.IsNullOrEmpty(Name))
            {
                ViewBag.Pay = db.Pay.OrderByDescending(n => n.OverTime).Where(p => Name == "" || p.Person.Name.Contains(Name)).ToList();
            }
            else
            {
                string year = DateTime.Now.Year.ToString();
                string month = DateTime.Now.Month.ToString();
                string day = DateTime.Now.Day.ToString();
                ViewBag.Pay = db.Pay.Where(p => p.OverTime.Year.ToString() == year && p.OverTime.Month.ToString() == month && p.OverTime.Day.ToString() == day).ToList();
            }
            ViewBag.Person = db.Person.ToList();
            return View();
        }

        //薪资发放
        public ActionResult PayGrant()
        {
            return View();
        }

        //统计
        public ActionResult Statistics()
        {
            return View();
        }

        [HttpGet]
        //数据
        public JsonResult PayData()
        {
            
            return Json(new {  }, JsonRequestBehavior.AllowGet);
        }
    }
}