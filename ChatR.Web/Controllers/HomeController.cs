using System;
using System.Net;
using System.Web.Mvc;
using ChatR.Web.Services;

namespace ChatR.Web.Controllers
{
    public class HomeController : Controller
    {
        private IChatStorage _chatStorage;

        public HomeController(IChatStorage chatStorage)
        {
            _chatStorage = chatStorage;
        }

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

        [HttpGet]
        public JsonResult GetMessages()
        {
            try
            {
                var result = Json(_chatStorage.GetAllMessages(), JsonRequestBehavior.AllowGet);

                return result;
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int) HttpStatusCode.InternalServerError;
                return Json($"{ex.Source}: {ex.Message}", JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Shape()
        {
            ViewBag.Action = "Shape";

            return View();
        }
    }
}