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
    [RoutePrefix("api/courseUser")]
    public class CourseUserController : ApiControllerBase
    {
        private ICourseUserService _courseUserService;

        public CourseUserController(IErrorService errorService,ICourseUserService courseUserService)
            : base(errorService)
        {
            _courseUserService = courseUserService;
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
                    var courseUserDb = _courseUserService.GetCourseUser(id);
                    if (courseUserDb == null)
                        response = request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid Id.");
                    else
                    {
                        _courseUserService.Delete(courseUserDb);

                        _courseUserService.SaveCourseUser();

                        response = request.CreateResponse<bool>(HttpStatusCode.OK, true);
                    }
                }

                return response;
            });
        }

        [Route("getlistpaging")]
        public HttpResponseMessage GetListPaging(HttpRequestMessage request, int page, int pageSize, string filter = null)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                int totalRow;
                IEnumerable<CourseUser> model = _courseUserService.GetCourseUsers(page, pageSize, out totalRow, filter);

                IEnumerable<CourseUserViewModel> modelVm = Mapper.Map<IEnumerable<CourseUser>, IEnumerable<CourseUserViewModel>>(model);

                PaginationSet<CourseUserViewModel> pagedSet = new PaginationSet<CourseUserViewModel>()
                {
                    Page = page,
                    TotalCount = totalRow,
                    TotalPages = (int)Math.Ceiling((decimal)totalRow / pageSize),
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
                var courseUser = _courseUserService.GetCourseUser(id);

                var postVM = Mapper.Map<CourseUser, CourseUserViewModel>(courseUser);

                response = request.CreateResponse<CourseUserViewModel>(HttpStatusCode.OK, postVM);

                return response;
            });
        }

        [Route("update")]
        [HttpPut]
        public HttpResponseMessage Update(HttpRequestMessage request, CourseUserViewModel post)
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
                    var courseUserDb = _courseUserService.GetCourseUser(post.ID);

                    if (courseUserDb == null)
                        response = request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid.");
                    else
                    {
                        courseUserDb.UpdateCourseUser(post);
                        _courseUserService.UpdateCourseUser(courseUserDb);
                        _courseUserService.SaveCourseUser();
                        response = request.CreateResponse<CourseUserViewModel>(HttpStatusCode.OK, post);
                    }
                }

                return response;
            });
        }

        [HttpPost]
        [Route("add")]
        public HttpResponseMessage Add(HttpRequestMessage request, CourseUserViewModel post)
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
                    CourseUser newPost = new CourseUser();

                    newPost.UpdateCourseUser(post);
                    newPost.CreatedDate = DateTime.Now;
                    newPost.CreatedBy = User.Identity.Name;
                    _courseUserService.CreateCourseUser(newPost);

                    _courseUserService.SaveCourseUser();

                    // Update view model
                    post = Mapper.Map<CourseUser, CourseUserViewModel>(newPost);
                    response = request.CreateResponse<CourseUserViewModel>(HttpStatusCode.Created, post);
                }

                return response;
            });
        }
    }
}