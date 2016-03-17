using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChatR.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Action = "Index";

            return View();
        }

        public ActionResult Chat()
        {
            ViewBag.Action = "Chat";

            return View();
        }
    }
}