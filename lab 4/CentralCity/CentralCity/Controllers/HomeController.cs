using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CentralCity.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            DateTime thisDay = DateTime.Today;
            ViewBag.TodaysDate = thisDay.ToString("D");
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "information about the authors";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult History()
        {
            ViewBag.Message = "A brief history of Central City";

            return View();
        }
    }
}