using AutoMapper;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TEDU.Model;
using TEDU.Service;
using TEDU.Web.Infrastructure.Core;
using TEDU.Web.Infrastructure.Extensions;
using TEDU.Web.ViewModels;

namespace TEDU.Web.Api
{
    [Authorize]
    [RoutePrefix("api/Category")]
    public class CategoryController : ApiControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService, IErrorService errorService) :
           base(errorService)
        {
            this._categoryService = categoryService;
        }

        [HttpDelete]
        [Route("delete/{id:int}")]
        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                if (!ModelState.IsValid)
                {
                    response = request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var categoryDb = _categoryService.GetCategory(id);
                    if (categoryDb == null)
                        response = request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid Id.");
                    else
                    {
                        _categoryService.Delete(categoryDb);

                        _categoryService.SaveCategory();

                        response = request.CreateResponse<bool>(HttpStatusCode.OK, true);
                    }
                }

                return response;
            });
        }

        [HttpGet]
        [Route("getlistparent")]
        public HttpResponseMessage GetListParent(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                IEnumerable<Category> model = _categoryService.GetCategories();
                IEnumerable<CategoryViewModel> modelVM = Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryViewModel>>(model);

                response = request.CreateResponse(HttpStatusCode.OK, modelVM);

                return response;
            });
        }

        [HttpGet]
        [Route("GetDetails/{id:int}")]
        public HttpResponseMessage GetDetails(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                var category = _categoryService.GetCategory(id);

                var categoryVM = Mapper.Map<Category, CategoryViewModel>(category);

                response = request.CreateResponse<CategoryViewModel>(HttpStatusCode.OK, categoryVM);

                return response;
            });
        }

        [Route("update")]
        [HttpPut]
        public HttpResponseMessage Update(HttpRequestMessage request, CategoryViewModel category)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                if (!ModelState.IsValid)
                {
                    response = request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var movieDb = _categoryService.GetCategory(category.ID);
                    if (movieDb == null)
                        response = request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid.");
                    else
                    {
                        movieDb.UpdateCategory(category);
                        _categoryService.SaveCategory();
                        response = request.CreateResponse<CategoryViewModel>(HttpStatusCode.OK, category);
                    }
                }

                return response;
            });
        }

        [HttpPost]
        [Route("add")]
        public HttpResponseMessage Add(HttpRequestMessage request, CategoryViewModel category)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                if (!ModelState.IsValid)
                {
                    response = request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    Category newCategory = new Category();

                    newCategory.UpdateCategory(category);

                    _categoryService.CreateCategory(newCategory);

                    _categoryService.SaveCategory();

                    // Update view model
                    category = Mapper.Map<Category, CategoryViewModel>(newCategory);
                    response = request.CreateResponse<CategoryViewModel>(HttpStatusCode.Created, category);
                }

                return response;
            });
        }
    }
}