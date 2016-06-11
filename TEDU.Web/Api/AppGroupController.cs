using AutoMapper;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
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
    [RoutePrefix("api/appGroup")]
    [Authorize]
    public class AppGroupController : ApiControllerBase
    {
        private IAppGroupService _appGroupService;
        private IUnitOfWork _unitOfWork;

        public AppGroupController(IErrorService errorService, 
            IAppGroupService appGroupService, IUnitOfWork unitOfWork) : base(errorService)
        {
            _appGroupService = appGroupService;
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
                var model = _appGroupService.GetAll(page, pageSize, out totalRow, filter);
                IEnumerable<AppGroupViewModel> modelVm = Mapper.Map<IEnumerable<AppGroup>, IEnumerable<AppGroupViewModel>>(model);

                PaginationSet<AppGroupViewModel> pagedSet = new PaginationSet<AppGroupViewModel>()
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
                var model = _appGroupService.GetAll();
                IEnumerable<AppGroupViewModel> modelVm = Mapper.Map<IEnumerable<AppGroup>, IEnumerable<AppGroupViewModel>>(model);

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
            AppGroup appGroup = _appGroupService.GetDetail(id);
            if (appGroup == null)
            {
                return request.CreateErrorResponse(HttpStatusCode.NoContent, "No group");
            }
            return request.CreateResponse(HttpStatusCode.OK, appGroup);
        }

        [HttpPost]
        [Route("add")]
        public HttpResponseMessage Create(HttpRequestMessage request, AppGroupViewModel appGroupViewModel)
        {
            if (ModelState.IsValid)
            {
                var newAppGroup = new AppGroup();
                newAppGroup.Name = appGroupViewModel.Name;
                try
                {
                    _appGroupService.Add(newAppGroup);
                    _appGroupService.Save();
                    return request.CreateResponse(HttpStatusCode.OK, appGroupViewModel);
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
        public HttpResponseMessage Update(HttpRequestMessage request, AppGroupViewModel appGroupViewModel)
        {
            if (ModelState.IsValid)
            {
                var appGroup = _appGroupService.GetDetail(appGroupViewModel.Id);
                try
                {
                    appGroup.UpdateAppGroup(appGroupViewModel);
                    _appGroupService.Update(appGroup);
                    _appGroupService.Save();
                    return request.CreateResponse(HttpStatusCode.OK, appGroup);
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
            var appGroup = _appGroupService.Delete(id);
            _appGroupService.Save();
            return request.CreateResponse(HttpStatusCode.OK, appGroup);
        }
    }
}