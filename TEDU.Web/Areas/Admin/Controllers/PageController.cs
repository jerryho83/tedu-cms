using AutoMapper;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Mvc;
using TEDU.Model.Models;
using TEDU.Service;
using TEDU.Web.Infrastructure.Core;
using TEDU.Web.Infrastructure.Extensions;
using TEDU.Web.ViewModels;

namespace TEDU.Web.Areas.Admin.Controllers
{
    [Authorize]
    [RoutePrefix("api/admin/page")]
    public class PageController : ApiControllerBase
    {
        private readonly IPageService pageService;

        public PageController(IPageService pageService, IErrorService errorService) :
           base(errorService)
        {
            this.pageService = pageService;
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
                    var pageDb = pageService.GetPage(id);
                    if (pageDb == null)
                        response = request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid Id.");
                    else
                    {
                        pageService.Delete(pageDb);

                        pageService.Save();

                        response = request.CreateResponse<bool>(HttpStatusCode.OK, true);
                    }
                }

                return response;
            });
        }

        [HttpGet]
        [Route("getlistpaging")]
        public HttpResponseMessage GetListPaging(HttpRequestMessage request, int? page, int? pageSize, string filter = null)
        {
            int currentPage = page.Value;

            int currentPageSize = pageSize.Value;

            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                int totalRow;
                IEnumerable<Page> model = pageService.GetPagesPaging(currentPage, currentPageSize, out totalRow, filter);

                IEnumerable<PageViewModel> modelVM = Mapper.Map<IEnumerable<Page>, IEnumerable<PageViewModel>>(model);

                PaginationSet<PageViewModel> pagedSet = new PaginationSet<PageViewModel>()
                {
                    Page = currentPage,
                    TotalCount = totalRow,
                    TotalPages = (int)Math.Ceiling((decimal)totalRow / currentPageSize),
                    Items = modelVM
                };

                response = request.CreateResponse(HttpStatusCode.OK, pagedSet);

                return response;
            });
        }

        [HttpGet]
        [Route("detail/{id:int}")]
        public HttpResponseMessage GetDetails(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                var entity = pageService.GetPage(id);

                var entityVM = Mapper.Map<Page, PageViewModel>(entity);

                response = request.CreateResponse<PageViewModel>(HttpStatusCode.OK, entityVM);

                return response;
            });
        }

        [HttpPut]
        [Route("update")]
        public HttpResponseMessage Update(HttpRequestMessage request, PageViewModel entity)
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
                    var pageDb = pageService.GetPage(entity.ID);
                    if (pageDb == null)
                        response = request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid.");
                    else
                    {
                        pageDb.UpdatePage(entity);
                        pageService.Save();
                        response = request.CreateResponse<PageViewModel>(HttpStatusCode.OK, entity);
                    }
                }

                return response;
            });
        }

        [HttpPost]
        [Route("add")]
        public HttpResponseMessage Add(HttpRequestMessage request, PageViewModel page)
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
                    Page newEntity = new Page();

                    newEntity.UpdatePage(page);

                    pageService.Create(newEntity);

                    pageService.Save();

                    // Update view model
                    page = Mapper.Map<Page, PageViewModel>(newEntity);
                    response = request.CreateResponse<PageViewModel>(HttpStatusCode.Created, page);
                }

                return response;
            });
        }
    }
}