using System.Web.Mvc;
using TEDU.Service;

namespace TEDU.Web.Areas.Admin.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IPostService _postService;

        public HomeController(ICategoryService categoryService, IPostService postService)
        {
            this._categoryService = categoryService;
            this._postService = postService;
        }

        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}