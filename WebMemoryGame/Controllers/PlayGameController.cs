using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebMemoryGame.Controllers
{
    public class PlayGameController : Controller
    {
        // GET: PlayGame
        public ActionResult Index()
        {
            return View();
        }
    }
}