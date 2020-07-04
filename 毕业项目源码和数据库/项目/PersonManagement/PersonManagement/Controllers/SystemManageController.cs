using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using PersonManagement.Models;

namespace PersonManagement.Controllers
{
    public class SystemManageController : Controller
    {
        PersonManagementEntities db = new PersonManagementEntities();
        // GET: SystemManage--后台首页
        
        //注销
        public ActionResult LogOut()
        {
            Session["LoginName"] = "";
            Session.Clear();//清除Session
            return RedirectToAction("Index", "AdminT");
        }

        //首页
        public ActionResult BgHome()
        {
            return View();
        }

        //查看该系统管理员
        public ActionResult Administrator()
        {
            ViewBag.Admin = db.AdminT.ToList();
            return View();
        }

        //更改管理
        public ActionResult AdminUpdate(string LoginName, string LoginPwd)
        {
            if (string.IsNullOrEmpty(LoginName))
            {
                return Content("false");
            }
            else if (string.IsNullOrEmpty(LoginPwd))
            {
                return Content("false1");
            }
            else
            {
                AdminT admin = db.AdminT.SingleOrDefault(p => p.LoginName == LoginName);
                admin.LoginPwd = LoginPwd;
                db.Entry(admin).State = EntityState.Modified;
                db.SaveChanges();
                return Content("true");
            }
        }

        //公告栏
        public ActionResult BulletinBoard(string Topic = "")
        {
            var board = db.Board.OrderByDescending(p => p.PublishTime).Where(n => Topic == "" || n.Topic.Contains(Topic)).ToList();
            ViewBag.Board = board;
            ViewBag.Topic = Topic;
            return View();
        }

        //发布公告
        public ActionResult PublishBoard()
        {
            return View();
        }
        [HttpPost]
        public ActionResult PublishBoard(string Topic, string ContentBoard)
        {
            if (Topic == "" && ContentBoard == "")
            {
                return Content("false");
            }
            else if (Topic == "" || ContentBoard == "")
            {
                if (Topic == "")
                {
                    return Content("Topic");
                }
                if (ContentBoard == "")
                {
                    return Content("ContentBoard");
                }
            }
            else
            {
                string LoginName = Session["LoginName"].ToString();
                var admin = db.AdminT.Where(p => p.LoginName == LoginName).SingleOrDefault();
                int id = admin.ID;
                Board board = new Board();
                board.AdminID = id;
                board.PublishTime = DateTime.Now;
                board.Topic = Topic;
                board.Content = ContentBoard;
                db.Board.Add(board);
                db.SaveChanges();
                return Content("true");
            }
            return View();
        }

        //查看公告详情
        public ActionResult BoardDetail(int? id)
        {
            var board = db.Board.Find(id);
            ViewBag.Board = board;
            return View();
        }
    }
}