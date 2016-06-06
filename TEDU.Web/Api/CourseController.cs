using AutoMapper;
using System;
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
    [RoutePrefix("api/course")]
    public class CourseController : ApiControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService postService, IErrorService errorService) :
           base(errorService)
        {
            this._courseService = postService;
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
                    var course = _courseService.GetCourse(id);
                    if (course == null)
                        response = request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid Id.");
                    else
                    {
                        _courseService.Delete(course);

                        _courseService.SaveCourse();

                        response = request.CreateResponse<bool>(HttpStatusCode.OK, true);
                    }
                }

                return response;
            });
        }

        [Route("getlistpaging")]
        public HttpResponseMessage GetListPaging(HttpRequestMessage request, int? page, int? pageSize, string filter = null)
        {
            int currentPage = page.Value;

            int currentPageSize = pageSize.Value;

            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                int totalRow;
                IEnumerable<Course> model = _courseService.GetCourses(currentPage, currentPageSize, out totalRow, filter);

                IEnumerable<CourseViewModel> modelVm = Mapper.Map<IEnumerable<Course>, IEnumerable<CourseViewModel>>(model);

                PaginationSet<CourseViewModel> pagedSet = new PaginationSet<CourseViewModel>()
                {
                    Page = currentPage,
                    TotalCount = totalRow,
                    TotalPages = (int)Math.Ceiling((decimal)totalRow / currentPageSize),
                    Items = modelVm
                };

                response = request.CreateResponse(HttpStatusCode.OK, pagedSet);

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
                var course = _courseService.GetCourse(id);

                var courseVM = Mapper.Map<Course, PostViewModel>(course);

                response = request.CreateResponse<PostViewModel>(HttpStatusCode.OK, courseVM);

                return response;
            });
        }

        [Route("update")]
        [HttpPut]
        public HttpResponseMessage Update(HttpRequestMessage request, CourseViewModel course)
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
                    var courseDb = _courseService.GetCourse(course.ID);

                    if (courseDb == null)
                        response = request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid.");
                    else
                    {
                        courseDb.UpdateCourse(course);
                        courseDb.LastModifiedDate = DateTime.Now;
                        courseDb.LastModifiedBy = User.Identity.Name;
                        _courseService.UpdateCourse(courseDb);
                        _courseService.SaveCourse();
                        response = request.CreateResponse<CourseViewModel>(HttpStatusCode.OK, course);
                    }
                }

                return response;
            });
        }

        [HttpPost]
        [Route("add")]
        public HttpResponseMessage Add(HttpRequestMessage request, CourseViewModel course)
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
                    Course newCourse = new Course();

                    newCourse.UpdateCourse(course);
                    newCourse.CreatedDate = DateTime.Now;
                    newCourse.CreateBy = User.Identity.Name;
                    _courseService.CreateCourse(newCourse);

                    _courseService.SaveCourse();

                        // Update view model
                        course = Mapper.Map<Course, CourseViewModel>(newCourse);
                    response = request.CreateResponse<CourseViewModel>(HttpStatusCode.Created, course);
                }

                return response;
            });
        }
    }
}