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
        public ActionResult PayInfo(string StartTime = "", string EndTime = "", string Name = "")
        {
            if (!string.IsNullOrEmpty(StartTime) && !string.IsNullOrEmpty(EndTime))
            {
                DateTime startTime = Convert.ToDateTime(StartTime);
                DateTime endTime = Convert.ToDateTime(EndTime);
                if (startTime > endTime)
                {
                    return Content("<script>alert('筛选时间段错误！');history.go(-1)</script>");
                }
                else
                {
                    ViewBag.Pay = db.Pay.Where(p => p.OverTime >= startTime && p.OverTime < endTime).ToList();
                }
            }
            else if (!string.IsNullOrEmpty(Name))
            {
                if (Name == "全部")
                {
                    ViewBag.Pay = db.Pay.ToList();
                }
                else
                {
                    ViewBag.Pay = db.Pay.Where(p => Name == "" || p.Person.Name.Contains(Name)).ToList();
                }
            }
            else
            {
                ViewBag.Pay = db.Pay.ToList();
            }
            ViewBag.Person = db.Person.ToList();
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