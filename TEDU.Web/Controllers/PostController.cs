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
    public class PostController : Controller
    {
        IPostService _postService;
        public PostController(IPostService postService)
        {
            _postService = postService;
        }
        // GET: Post
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Category(string alias, int page = 0, int pageSize = 10)
        {
            int totalRow = 0;
            var posts = _postService.GetListByCategoryAlias(alias, page, pageSize, out totalRow);
            var model = Mapper.Map<List<Post>, List<PostViewModel>>(posts);

            return View(model);
        }
        public ActionResult Detail(int id)
        {
            return View();
        }
    }
}