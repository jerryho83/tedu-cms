using System.Web.Mvc;

namespace TEDU.Web.Controllers
{
    [Authorize]
    public class EbookController : Controller
    {
        // GET: Ebook
        public ActionResult Index()
        {
            return View();
        }
    }
}