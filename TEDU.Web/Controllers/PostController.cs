using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TEDU.Web.Controllers
{
    public class PostController : Controller
    {
        // GET: Post
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Category(string alias)
        {
            return View();
        }
        public ActionResult Detail(int id)
        {
            return View();
        }
    }
}