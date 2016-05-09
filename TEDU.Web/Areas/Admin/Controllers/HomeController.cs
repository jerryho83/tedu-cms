using System.Web.Mvc;
using TEDU.Service;

namespace TEDU.Web.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
        }

        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}