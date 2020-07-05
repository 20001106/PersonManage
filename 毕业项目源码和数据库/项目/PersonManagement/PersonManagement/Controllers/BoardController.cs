using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PersonManagement.Models;

namespace PersonManagement.Controllers
{
    public class BoardController : Controller
    {
        PersonManagementEntities db = new PersonManagementEntities();
        // GET: Board
        public ActionResult BoardInfo()
        {
            var board = db.Board.OrderByDescending(p => p.PublishTime).ToList();
            ViewBag.Board = board;
            return View();
        }

        public ActionResult BoardDetail(int? id)
        {
            var board = db.Board.Find(id);
            ViewBag.Board = board;
            return View();
        }
    }
}