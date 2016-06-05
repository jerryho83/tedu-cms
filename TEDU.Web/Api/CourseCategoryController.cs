
using AutoMapper;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TEDU.Model.Models;
using TEDU.Service;
using TEDU.Web.Infrastructure.Core;
using TEDU.Web.Infrastructure.Extensions;
using TEDU.Web.ViewModels;

namespace TEDU.Web.Api
{
    [Authorize]
    [RoutePrefix("api/courseCategory")]
    public class CourseCategoryController : ApiControllerBase
    {
        private readonly ICourseCategoryService _courseCategoryService;

        public CourseCategoryController(ICourseCategoryService courseCategoryService, IErrorService errorService) :
           base(errorService)
        {
            this._courseCategoryService = courseCategoryService;
        }

        [HttpDelete]
        [Route("delete")]
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
                    var categoryDb = _courseCategoryService.GetCategory(id);
                    if (categoryDb == null)
                        response = request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid Id.");
                    else
                    {
                        _courseCategoryService.Delete(categoryDb);

                        _courseCategoryService.SaveCategory();

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
                IEnumerable<CourseCategory> model = _courseCategoryService.GetCategories();
                IEnumerable<CourseCategoryViewModel> modelVM = Mapper.Map<IEnumerable<CourseCategory>, IEnumerable<CourseCategoryViewModel>>(model);

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
                var category = _courseCategoryService.GetCategory(id);

                var categoryVM = Mapper.Map<CourseCategory, CourseCategoryViewModel>(category);

                response = request.CreateResponse<CourseCategoryViewModel>(HttpStatusCode.OK, categoryVM);

                return response;
            });
        }

        [Route("update")]
        [HttpPut]
        public HttpResponseMessage Update(HttpRequestMessage request, CourseCategoryViewModel category)
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
                    var categoryDb = _courseCategoryService.GetCategory(category.ID);
                    if (categoryDb == null)
                        response = request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid.");
                    else
                    {
                        categoryDb.UpdateCourseCategory(category);
                        _courseCategoryService.SaveCategory();
                        response = request.CreateResponse<CourseCategoryViewModel>(HttpStatusCode.OK, category);
                    }
                }

                return response;
            });
        }

        [HttpPost]
        [Route("add")]
        public HttpResponseMessage Add(HttpRequestMessage request, CourseCategoryViewModel category)
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
                    CourseCategory newCategory = new CourseCategory();

                    newCategory.UpdateCourseCategory(category);

                    _courseCategoryService.CreateCategory(newCategory);

                    _courseCategoryService.SaveCategory();

                    // Update view model
                    category = Mapper.Map<CourseCategory, CourseCategoryViewModel>(newCategory);
                    response = request.CreateResponse<CourseCategoryViewModel>(HttpStatusCode.Created, category);
                }

                return response;
            });
        }
    }
}
