using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using TEDU.Common.Exceptions;
using TEDU.Data.Infrastructure;
using TEDU.Model.Models;
using TEDU.Service;
using TEDU.Web.Infrastructure.Core;
using TEDU.Web.Infrastructure.Extensions;
using TEDU.Web.ViewModels;

namespace TEDU.Web.Api
{
    [Authorize]
    [RoutePrefix("api/techLine")]
    public class TechLineController : ApiControllerBase
    {
        private ITechLineService _techLineService;
        private IUnitOfWork _unitOfWork;

        public TechLineController(IErrorService errorService,
            ITechLineService techLineService,
            IUnitOfWork unitOfWork) : base(errorService)
        {
            _techLineService = techLineService;
            _unitOfWork = unitOfWork;
        }
        [Route("getlistpaging")]
        [HttpGet]
        public HttpResponseMessage GetListPaging(HttpRequestMessage request, int page, int pageSize, string filter = null)
        {

            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                int totalRow = 0;
                var model = _techLineService.GetAll(page, pageSize, out totalRow, filter);
                IEnumerable<TechLineViewModel> modelVm = Mapper.Map<IEnumerable<TechLine>, IEnumerable<TechLineViewModel>>(model);

                PaginationSet<TechLineViewModel> pagedSet = new PaginationSet<TechLineViewModel>()
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
        [Route("getlistall")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                var model = _techLineService.GetAll();
                IEnumerable<TechLineViewModel> modelVm = Mapper.Map<IEnumerable<TechLine>, IEnumerable<TechLineViewModel>>(model);

                response = request.CreateResponse(HttpStatusCode.OK, modelVm);

                return response;
            });
        }
        [Route("detail/{id:int}")]
        [HttpGet]
        public HttpResponseMessage Details(HttpRequestMessage request, int id)
        {
            if (id == 0)
            {
                return request.CreateErrorResponse(HttpStatusCode.BadRequest, nameof(id) + " is required.");
            }
            TechLine techLine = _techLineService.GetDetail(id);
            var techLineViewModel = Mapper.Map<TechLine, TechLineViewModel>(techLine);

            if (techLine == null)
            {
                return request.CreateErrorResponse(HttpStatusCode.NoContent, "No group");
            }
            return request.CreateResponse(HttpStatusCode.OK, techLineViewModel);
        }

        [HttpPost]
        [Route("add")]
        public HttpResponseMessage Create(HttpRequestMessage request, TechLineViewModel techLineViewModel)
        {
            if (ModelState.IsValid)
            {
                var techLine = new TechLine();
                techLine.Name = techLineViewModel.Name;
                try
                {
                    var appGroup = _techLineService.Add(techLine);

                    _techLineService.Save();

                    return request.CreateResponse(HttpStatusCode.OK, techLineViewModel);

                }
                catch (NameDuplicatedException dex)
                {
                    return request.CreateErrorResponse(HttpStatusCode.BadRequest, dex.Message);
                }

            }
            else
            {
                return request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        [HttpPut]
        [Route("update")]
        public async Task<HttpResponseMessage> Update(HttpRequestMessage request, TechLineViewModel techLineViewModel)
        {
            if (ModelState.IsValid)
            {
                var appGroup = _techLineService.GetDetail(techLineViewModel.ID);
                try
                {
                    appGroup.UpdateTechLine(techLineViewModel);
                    _techLineService.Update(appGroup);

                    _techLineService.Save();

                    return request.CreateResponse(HttpStatusCode.OK, techLineViewModel);
                }
                catch (NameDuplicatedException dex)
                {
                    return request.CreateErrorResponse(HttpStatusCode.BadRequest, dex.Message);
                }
            }
            else
            {
                return request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        [HttpDelete]
        [Route("delete")]
        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
        {
            var appGroup = _techLineService.Delete(id);
            _techLineService.Save();
            return request.CreateResponse(HttpStatusCode.OK, appGroup);
        }
    }
}
