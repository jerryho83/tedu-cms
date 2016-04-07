using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TEDU.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult Footer()
        {
            return PartialView();
        }

        public PartialViewResult MainMenu()
        {
            return PartialView();
        }

        public PartialViewResult NewsTab()
        {
            return PartialView();
        }

        public PartialViewResult BreakingNews()
        {
            return PartialView();
        }
    }
}