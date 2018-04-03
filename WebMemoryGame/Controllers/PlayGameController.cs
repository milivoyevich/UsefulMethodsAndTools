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
            return View();
        }

        public ActionResult Register(mem_korisnici MK)
        {

            return View();
        }
    }
}