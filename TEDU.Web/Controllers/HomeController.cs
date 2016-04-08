using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TEDU.Model;
using TEDU.Service;
using TEDU.Web.ViewModels;

namespace TEDU.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostService postService;

        public HomeController(IPostService postService)
        {
            this.postService = postService;
        }

        // GET: Home
        public ActionResult Index()
        {
            var focusNews = postService.GetBreakingNews(6);
            ViewBag.FocusNews = Mapper.Map<IEnumerable<Post>, IEnumerable<PostViewModel>>(focusNews);
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
            var data = Mapper.Map<IEnumerable<Post>,IEnumerable<PostViewModel>>(model);


            return PartialView(data);
        }

        public PartialViewResult SpecialBox()
        {
            return PartialView();
        }
    }
}