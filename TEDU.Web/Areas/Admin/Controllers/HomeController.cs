using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TEDU.Service;

namespace TEDU.Web.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly IPostService postService;
        public HomeController(ICategoryService categoryService, IPostService postService)
        {
            this.categoryService = categoryService;
            this.postService = postService;
        }
        // GET: Admin/Home
        public ActionResult Index()
        {
            var model = categoryService.GetCategories();
            return View(model);
        }
    }
}