using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
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
    [RoutePrefix("api/courseVideo")]
    public class CourseVideoController : ApiControllerBase
    {
        private readonly ICourseVideoService _courseVideoService;

        public CourseVideoController(ICourseVideoService courseVideoService, IErrorService errorService) :
           base(errorService)
        {
            this._courseVideoService = courseVideoService;
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
                    var courseVideoDb = _courseVideoService.GetCourseVideo(id);
                    if (courseVideoDb == null)
                        response = request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid Id.");
                    else
                    {
                        _courseVideoService.Delete(courseVideoDb);

                        _courseVideoService.SaveCourseVideo();

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
                IEnumerable<CourseVideo> model = _courseVideoService.GetCourseVideos(page, pageSize, out totalRow, filter);

                IEnumerable<CourseVideoViewModel> modelVm = Mapper.Map<IEnumerable<CourseVideo>, IEnumerable<CourseVideoViewModel>>(model);

                PaginationSet<CourseVideoViewModel> pagedSet = new PaginationSet<CourseVideoViewModel>()
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
                var courseVideo = _courseVideoService.GetCourseVideo(id);

                var postVM = Mapper.Map<CourseVideo, CourseVideoViewModel>(courseVideo);

                response = request.CreateResponse<CourseVideoViewModel>(HttpStatusCode.OK, postVM);

                return response;
            });
        }

        [Route("update")]
        [HttpPut]
        public HttpResponseMessage Update(HttpRequestMessage request, CourseVideoViewModel post)
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
                    var courseVideoDb = _courseVideoService.GetCourseVideo(post.ID);

                    if (courseVideoDb == null)
                        response = request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid.");
                    else
                    {
                        courseVideoDb.UpdateCourseVideo(post);
                        courseVideoDb.LastModifiedDate = DateTime.Now;
                        courseVideoDb.LastModifiedBy = User.Identity.Name;
                        _courseVideoService.UpdateCourseVideo(courseVideoDb);
                        _courseVideoService.SaveCourseVideo();
                        response = request.CreateResponse<CourseVideoViewModel>(HttpStatusCode.OK, post);
                    }
                }

                return response;
            });
        }

        [HttpPost]
        [Route("add")]
        public HttpResponseMessage Add(HttpRequestMessage request, CourseVideoViewModel post)
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
                    CourseVideo newPost = new CourseVideo();

                    newPost.UpdateCourseVideo(post);
                    newPost.CreatedDate = DateTime.Now;
                    newPost.CreatedBy = User.Identity.Name;
                    _courseVideoService.CreateCourseVideo(newPost);

                    _courseVideoService.SaveCourseVideo();

                    // Update view model
                    post = Mapper.Map<CourseVideo, CourseVideoViewModel>(newPost);
                    response = request.CreateResponse<CourseVideoViewModel>(HttpStatusCode.Created, post);
                }

                return response;
            });
        }
    }
}
