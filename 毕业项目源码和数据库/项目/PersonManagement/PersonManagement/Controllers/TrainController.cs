using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PersonManagement.Models;

namespace PersonManagement.Controllers
{
    public class TrainController : Controller
    {
        PersonManagementEntities db = new PersonManagementEntities();
        // GET: Train--培训管理
        public ActionResult TrainInfo(string Topic = "")
        {
            ViewBag.Train = db.Train.Where(p => Topic == "" || p.Topic.Contains(Topic)).ToList();
            return View();
        }

        //删除信息
        public ActionResult TrainDelete(int? id)
        {
            Train train = db.Train.Find(id);
            db.Train.Remove(train);
            db.SaveChanges();
            return RedirectToAction("TrainInfo", "Train");
        }

        //添加培训信息
        public ActionResult TrainAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult TrainAdd(Train train)
        {
            db.Train.Add(train);
            db.SaveChanges();
            return RedirectToAction("TrainInfo", "Train");
        }
    }
}