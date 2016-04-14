using AutoMapper;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using TEDU.Model;
using TEDU.Service;
using TEDU.Web.Mappings;
using TEDU.Web.ViewModels;

namespace TEDU.Web.Controllers
{
    public class PostController : Controller
    {
        private IPostService _postService;
        private ICategoryService _categoryService;

        public PostController(IPostService postService, ICategoryService categoryService)
        {
            _postService = postService;
            _categoryService = categoryService;
        }

        // GET: Post
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Category(string alias, int page = 1, int pageSize = 10)
        {
            int totalRow = 0;
            var posts = _postService.GetListByCategoryAlias(alias, page, pageSize, out totalRow);
            var model = Mapper.Map<List<Post>, List<PostViewModel>>(posts);

            var category = _categoryService.GetCategoryByAlias(alias);
            ViewBag.Category = Mapper.Map<Category, CategoryViewModel>(category);

            ViewBag.Total = totalRow;
            ViewBag.Page = page;
            var totalPage = 0;
            const int maxpage = 5;
            try
            {
                totalPage = (int)Math.Ceiling((double)totalRow / pageSize);
            }
            catch (Exception)
            {
            }
            ViewBag.TotalPage = totalPage;
            ViewBag.MaxPage = maxpage;
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1;
            if (page == 1) ViewBag.Prev = totalPage;
            ViewBag.First = 1;
            ViewBag.Last = totalPage;

            return View(model);
        }

        public ActionResult Detail(int id)
        {
            var postDb = _postService.GetPost(id);
            var model = Mapper.Map<Post, PostViewModel>(postDb);
            return View(model);
        }
    }
}