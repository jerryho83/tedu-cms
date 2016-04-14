using AutoMapper;
using System.Collections.Generic;
using System.Web.Mvc;
using TEDU.Model;
using TEDU.Service;
using TEDU.Web.ViewModels;

namespace TEDU.Web.Controllers
{
    public class PostController : Controller
    {
        private IPostService _postService;

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
            var model = Mapper.Map<List<PostViewModel>>(posts);

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