using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using TEDU.Model;
using TEDU.Service;
using TEDU.Web.ViewModels;

namespace TEDU.Web.Areas.Admin.Controllers
{
    public class CategoryController : ApiController
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [Route("admin/api/category/GetListCategories")]
        // GET: Admin/Home
        public IEnumerable<Category> GetListCategories()
        {
            var model = categoryService.GetCategories();
            var data = Mapper.Map<List<Category>, List<CategoryViewModel>>(model.ToList());
            return model;
        }
    }
}