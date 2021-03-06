﻿using AutoMapper;
using System;
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
    [RoutePrefix("api/Post")]
    public class PostController : ApiControllerBase
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService, IErrorService errorService) :
           base(errorService)
        {
            this._postService = postService;
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
                    var categoryDb = _postService.GetPost(id);
                    if (categoryDb == null)
                        response = request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid Id.");
                    else
                    {
                        _postService.Delete(categoryDb);

                        _postService.SavePost();

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
                IEnumerable<Post> model = _postService.GetPosts(page, pageSize, out totalRow, filter);

                IEnumerable<PostViewModel> modelVm = Mapper.Map<IEnumerable<Post>, IEnumerable<PostViewModel>>(model);

                PaginationSet<PostViewModel> pagedSet = new PaginationSet<PostViewModel>()
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
                var post = _postService.GetPost(id);

                var postVM = Mapper.Map<Post, PostViewModel>(post);

                response = request.CreateResponse<PostViewModel>(HttpStatusCode.OK, postVM);

                return response;
            });
        }

        [Route("update")]
        [HttpPut]
        public HttpResponseMessage Update(HttpRequestMessage request, PostViewModel post)
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
                    var postDb = _postService.GetPost(post.ID);

                    if (postDb == null)
                        response = request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid.");
                    else
                    {
                        postDb.UpdatePost(post);
                        postDb.LastModifiedDate = DateTime.Now;
                        postDb.LastModifiedBy = User.Identity.Name;
                        _postService.UpdatePost(postDb);
                        _postService.SavePost();
                        response = request.CreateResponse<PostViewModel>(HttpStatusCode.OK, post);
                    }
                }

                return response;
            });
        }

        [HttpPost]
        [Route("add")]
        public HttpResponseMessage Add(HttpRequestMessage request, PostViewModel post)
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
                    Post newPost = new Post();

                    newPost.UpdatePost(post);
                    newPost.CreatedDate = DateTime.Now;
                    newPost.CreateBy = User.Identity.Name;
                    _postService.CreatePost(newPost);

                    _postService.SavePost();

                    // Update view model
                    post = Mapper.Map<Post, PostViewModel>(newPost);
                    response = request.CreateResponse<PostViewModel>(HttpStatusCode.Created, post);
                }

                return response;
            });
        }
    }
}