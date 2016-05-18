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

namespace TEDU.Web.Api
{
    [RoutePrefix("api/ebook")]
    public class EbookController : ApiControllerBase
    {
        private readonly IEbookService ebookService;

        public EbookController(IEbookService categoryService, IErrorService errorService) :
           base(errorService)
        {
            this.ebookService = categoryService;
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
                    var pageDb = ebookService.GetEbook(id);
                    if (pageDb == null)
                        response = request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid Id.");
                    else
                    {
                        ebookService.Delete(pageDb);

                        ebookService.Save();

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
                IEnumerable<Ebook> model = ebookService.GetEbookPaging(currentPage, currentPageSize, out totalRow, filter);

                IEnumerable<EbookViewModel> modelVM = Mapper.Map<IEnumerable<Ebook>, IEnumerable<EbookViewModel>>(model);

                PaginationSet<EbookViewModel> pagedSet = new PaginationSet<EbookViewModel>()
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
                var entity = ebookService.GetEbook(id);

                var entityVM = Mapper.Map<Ebook, EbookViewModel>(entity);

                response = request.CreateResponse<EbookViewModel>(HttpStatusCode.OK, entityVM);

                return response;
            });
        }

        [Route("update")]
        [HttpPut]
        public HttpResponseMessage Update(HttpRequestMessage request, EbookViewModel entity)
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
                    var pageDb = ebookService.GetEbook(entity.ID);
                    if (pageDb == null)
                        response = request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid.");
                    else
                    {
                        pageDb.UpdateEbook(entity);
                        ebookService.Save();
                        response = request.CreateResponse<EbookViewModel>(HttpStatusCode.OK, entity);
                    }
                }

                return response;
            });
        }

        [HttpPost]
        [Route("add")]
        public HttpResponseMessage Add(HttpRequestMessage request, EbookViewModel entityVM)
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
                    Ebook newEntity = new Ebook();

                    newEntity.UpdateEbook(entityVM);

                    ebookService.Create(newEntity);

                    ebookService.Save();

                    // Update view model
                    entityVM = Mapper.Map<Ebook, EbookViewModel>(newEntity);
                    response = request.CreateResponse<EbookViewModel>(HttpStatusCode.Created, entityVM);
                }

                return response;
            });
        }
    }
}