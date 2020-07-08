using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
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
            ViewBag.Person =  db.Person.ToList();
            var pay = db.Pay.Where(p => p.OverTime.Year.ToString() == Date.Now.Year.ToString() && p.OverTime.Month.ToString() == Date.Now.Month.ToString() && p.OverTime.Day.ToString() == Date.Now.Day.ToString()).ToList();
            if (pay.Count() == 0)
            {
                pay = null;
            }
            ViewBag.Pay = pay;
            return View();
        }
        //下发
        public ActionResult PaySubmit(int[] PersonID, int[] AttPay, int[] OtherPay)
        {
            for (int i = 0; i < PersonID.Length; i++)
            {
                Pay pay = new Pay();
                pay.PersonID = PersonID[i];
                pay.OverTime = Date.Now;
                pay.AttPay = AttPay[i];
                pay.OtherPay = OtherPay[i];
                db.Pay.Add(pay);
            }
            db.SaveChanges();
            return RedirectToAction("PayInfo","Pay");
        }

        //统计图
        public ActionResult Statistics()
        {
            ViewBag.Person1 = db.Person.Where(p => p.Name == "张三").SingleOrDefault();
            ViewBag.Person2 = db.Person.Where(p => p.Name == "李琼").SingleOrDefault();
            ViewBag.Person3 = db.Person.Where(p => p.Name == "王五").SingleOrDefault();
            ViewBag.Person4 = db.Person.Where(p => p.Name == "赵茜").SingleOrDefault();
            ViewBag.Person5 = db.Person.Where(p => p.Name == "陈七").SingleOrDefault();
            ViewBag.Person6 = db.Person.Where(p => p.Name == "王七").SingleOrDefault();
            return View();
        }
    }
}