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
using TEDU.Web.App_Start;
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
        private IAppRoleService _appRoleService;
        private IUnitOfWork _unitOfWork;
        private ApplicationUserManager _userManager;

        public AppGroupController(IErrorService errorService,
            IAppRoleService appRoleService,
            ApplicationUserManager userManager,
            IAppGroupService appGroupService, IUnitOfWork unitOfWork) : base(errorService)
        {
            _userManager = userManager;
            _appGroupService = appGroupService;
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
            var appGroupViewModel = Mapper.Map<AppGroup, AppGroupViewModel>(appGroup);
            appGroupViewModel.Roles = Mapper.Map<IEnumerable<AppRole>, IEnumerable<AppRoleViewModel>>(_appRoleService.GetListRoleByGroupId(id));

            if (appGroup == null)
            {
                return request.CreateErrorResponse(HttpStatusCode.NoContent, "No group");
            }
            return request.CreateResponse(HttpStatusCode.OK, appGroupViewModel);
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
                    var appGroup = _appGroupService.Add(newAppGroup);

                    //save group
                    var listRoleGroup = new List<AppRoleGroup>();
                    foreach(var role  in appGroupViewModel.Roles)
                    {
                        listRoleGroup.Add(new AppRoleGroup()
                        {
                            GroupId = appGroup.Id,
                            RoleId = role.Id
                        });
                    }
                    _appRoleService.AddRolesToGroup(listRoleGroup, appGroup.Id);
                    _appRoleService.Save();

                   

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
        public async Task<HttpResponseMessage> Update(HttpRequestMessage request, AppGroupViewModel appGroupViewModel)
        {
            if (ModelState.IsValid)
            {
                var appGroup = _appGroupService.GetDetail(appGroupViewModel.Id);
                try
                {
                    appGroup.UpdateAppGroup(appGroupViewModel);
                    _appGroupService.Update(appGroup);

                    var listRoleGroup = new List<AppRoleGroup>();
                    foreach (var role in appGroupViewModel.Roles)
                    {
                        listRoleGroup.Add(new AppRoleGroup()
                        {
                            GroupId = appGroup.Id,
                            RoleId = role.Id
                        });
                    }
                    _appRoleService.AddRolesToGroup(listRoleGroup, appGroup.Id);
                    _appRoleService.Save();

                    //add role to user
                    var listRole = _appRoleService.GetListRoleByGroupId(appGroup.Id);
                    var listUserInGroup = _appGroupService.GetListUserByGroupId(appGroup.Id);
                    foreach (var user in listUserInGroup)
                    {
                        var listRoleName = listRole.Select(x => x.Name).ToArray();
                        foreach(var roleName in listRoleName)
                        {
                            await _userManager.RemoveFromRoleAsync(user.Id, roleName);
                            await _userManager.AddToRoleAsync(user.Id, roleName);


                        }
                    }
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