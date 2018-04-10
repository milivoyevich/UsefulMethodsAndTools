using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMemoryGame.Models;

namespace WebMemoryGame.Controllers
{
    public class PlayGameController : Controller
    {
        // GET: PlayGame
        public ActionResult Index()
        {
            ViewBag.Naslov = "Memory Game";
            ViewBag.Nivo = 4;

            if (Session["Start"] == null) Session["Start"] = false;
            ViewBag.Start = Session["Start"];

            if (Session["Login"]!=null && Convert.ToBoolean(Session["Login"]))
            {
                ViewBag.Login = true;
            }
            else
            {
                ViewBag.Login = false;
            }
            return View();
        }

        public ActionResult Register(mem_korisnici MK)
        {
           
            if (MK.email!=null)
            {
                var errorNum = ModelState.Count;
                return RedirectToAction("Login");
            }
            return View();
        }
        public ActionResult Login(mem_korisnici MK)
        {
            if (MK.username != null)
            {
                Session["Login"] = true;
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Logout()
        {
            Session["Login"] = null;
            Session["Start"] = false;
            Session["StartTime"] = null;
            return RedirectToAction("Index");
        }

        public ActionResult StartGame()
        {
            Session["Start"] = true;
            Session["StartTime"] = DateTime.Now;
            return RedirectToAction("Index");
        }
        public ActionResult StopGame()
        {
            Session["Start"] = false;
            Session["StartTime"] = null;
            return RedirectToAction("Index");
        }
         public ActionResult GameTimer()
        {
            var vreme = (DateTime.Now - Convert.ToDateTime(Session["StartTime"]));
            var minuti = Math.Floor(vreme.TotalMinutes);
            var sekundi = (vreme).TotalSeconds - minuti * 60;
            return Content (minuti.ToString("00") + ":" + sekundi.ToString("00"));
        }
    }
}