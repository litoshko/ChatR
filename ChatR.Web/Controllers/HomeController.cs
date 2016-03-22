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

        public ActionResult Shape()
        {
            ViewBag.Action = "Shape";

            return View();
        }
    }
}