using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PersonManagement.Models;

namespace PersonManagement.Controllers
{
    public class RewardController : Controller
    {
        PersonManagementEntities db = new PersonManagementEntities();
        // GET: Reward--奖惩管理
        public ActionResult RewardInfo(string RewardType = "")
        {
            if (RewardType == "全部")
            {
                ViewBag.Reward = db.Reward.ToList();
            }
            else
            {
                ViewBag.Reward = db.Reward.Where(p => RewardType == "" || p.RewardType.Contains(RewardType)).ToList();
            }
            return View();
        }

        //添加奖惩
        public ActionResult RewardAdd()
        {
            ViewBag.Person = db.Person.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult RewardAdd(Reward reward)
        {
            reward.RewardTime = DateTime.Now;
            db.Reward.Add(reward);
            db.SaveChanges();
            return RedirectToAction("RewardInfo", "Reward");
        }

        //删除奖惩
        public ActionResult RewardDelete(int? id)
        {
            Reward reward = db.Reward.Find(id);
            db.Reward.Remove(reward);
            db.SaveChanges();
            return RedirectToAction("RewardInfo", "Reward");
        }
    }
}