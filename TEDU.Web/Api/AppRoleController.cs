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
    [RoutePrefix("api/appRole")]
    [Authorize]
    public class AppRoleController : ApiControllerBase
    {
        private IAppRoleService _appRoleService;
        private IUnitOfWork _unitOfWork;

        public AppRoleController(IErrorService errorService,
            IAppRoleService appRoleService, IUnitOfWork unitOfWork) : base(errorService)
        {
            _appRoleService = appRoleService;
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
                var model = _appRoleService.GetAll(page, pageSize, out totalRow, filter);
                IEnumerable<AppRoleViewModel> modelVm = Mapper.Map<IEnumerable<AppRole>, IEnumerable<AppRoleViewModel>>(model);

                PaginationSet<AppRoleViewModel> pagedSet = new PaginationSet<AppRoleViewModel>()
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
                var model = _appRoleService.GetAll();
                IEnumerable<AppRoleViewModel> modelVm = Mapper.Map<IEnumerable<AppRole>, IEnumerable<AppRoleViewModel>>(model);

                response = request.CreateResponse(HttpStatusCode.OK, modelVm);

                return response;
            });
        }
        [Route("detail/{id}")]
        [HttpGet]
        public HttpResponseMessage Details(HttpRequestMessage request, string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return request.CreateErrorResponse(HttpStatusCode.BadRequest, nameof(id) + " không có giá trị.");
            }
            AppRole AppRole = _appRoleService.GetDetail(id);
            if (AppRole == null)
            {
                return request.CreateErrorResponse(HttpStatusCode.NoContent, "No group");
            }
            return request.CreateResponse(HttpStatusCode.OK, AppRole);
        }

        [HttpPost]
        [Route("add")]
        public HttpResponseMessage Create(HttpRequestMessage request, AppRoleViewModel appRoleViewModel)
        {
            if (ModelState.IsValid)
            {
                var newAppRole = new AppRole();
                newAppRole.UpdateAppRole(appRoleViewModel);
                try
                {
                    _appRoleService.Add(newAppRole);
                    _appRoleService.Save();
                    return request.CreateResponse(HttpStatusCode.OK, appRoleViewModel);
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
        public HttpResponseMessage Update(HttpRequestMessage request, AppRoleViewModel appRoleViewModel)
        {
            if (ModelState.IsValid)
            {
                var appRole = _appRoleService.GetDetail(appRoleViewModel.Id);
                try
                {
                    appRole.UpdateAppRole(appRoleViewModel, "update");
                    _appRoleService.Update(appRole);
                    _appRoleService.Save();
                    return request.CreateResponse(HttpStatusCode.OK, appRole);
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
        public HttpResponseMessage Delete(HttpRequestMessage request, string id)
        {
            _appRoleService.Delete(id);
            _appRoleService.Save();
            return request.CreateResponse(HttpStatusCode.OK, id);
        }
    }
}