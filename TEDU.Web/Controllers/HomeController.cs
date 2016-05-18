using AutoMapper;
using System.Collections.Generic;
using System.Web.Mvc;
using TEDU.Common.Helper;
using TEDU.Model;
using TEDU.Model.Models;
using TEDU.Service;
using TEDU.Web.ViewModels;

namespace TEDU.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostService postService;
        private readonly ICategoryService categoryService;

        public HomeController(IPostService postService, ICategoryService categoryService)
        {
            this.postService = postService;
            this.categoryService = categoryService;
        }

        // GET: Home
        public ActionResult Index()
        {
            var focusNews = postService.GetBreakingNews(5);
            ViewBag.FocusNews = Mapper.Map<IEnumerable<Post>, IEnumerable<PostViewModel>>(focusNews);

            var slideNews = postService.GetPostSlide(4);
            ViewBag.SlideNews = Mapper.Map<IEnumerable<Post>, IEnumerable<PostViewModel>>(slideNews);

            var homeCates = categoryService.GetHomeCategories(3);
            var homeCatesVM = Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryViewModel>>(homeCates);
            foreach (var item in homeCatesVM)
            {
                var post = postService.GetRecentPostsByCategory(item.ID, 4);
                item.Posts = Mapper.Map<List<Post>, List<PostViewModel>>(post);
            }
            ViewBag.HomeCates = homeCatesVM;
            ViewBag.SystemTitle = ConfigHelper.GetConfigByKey("SystemTitle");
            ViewBag.SystemKeyword = ConfigHelper.GetConfigByKey("SystemKeyword");
            ViewBag.SystemDescription = ConfigHelper.GetConfigByKey("SystemDescription");
            return View();
        }

        public PartialViewResult Footer()
        {
            var recentNews = postService.GetRecentPosts(3);
            ViewBag.RecentPosts = Mapper.Map<IEnumerable<Post>, IEnumerable<PostViewModel>>(recentNews);

            var cloudTags = postService.GetPopularListTags(10);
            ViewBag.TagCloud = Mapper.Map<IEnumerable<Tag>, IEnumerable<TagViewModel>>(cloudTags);
            return PartialView();
        }

        public PartialViewResult MainMenu()
        {
            var data = categoryService.GetCategories();
            var model = Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryViewModel>>(data);
            return PartialView(model);
        }

        public PartialViewResult NewsTab()
        {
            var popularNews = postService.GetPopularPosts(6);
            var recentNews = postService.GetRecentPosts(6);
            ViewBag.Popular = Mapper.Map<IEnumerable<Post>, IEnumerable<PostViewModel>>(popularNews);
            ViewBag.RecentPosts = Mapper.Map<IEnumerable<Post>, IEnumerable<PostViewModel>>(recentNews);
            return PartialView();
        }

        public PartialViewResult BreakingNews()
        {
            var model = postService.GetBreakingNews(3);
            var data = Mapper.Map<IEnumerable<Post>, IEnumerable<PostViewModel>>(model);
            return PartialView(data);
        }

        //public PartialViewResult Gallery()
        //{
        //    return PartialView();
        //}

        public PartialViewResult VideoGallery()
        {
            return PartialView();
        }

        public PartialViewResult RecentPost()
        {
            var model = postService.GetRecentPosts(3);
            var data = Mapper.Map<IEnumerable<Post>, IEnumerable<PostViewModel>>(model);

            return PartialView(data);
        }

        public PartialViewResult SpecialBox()
        {
            return PartialView();
        }
    }
}