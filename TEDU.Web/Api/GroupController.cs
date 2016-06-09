using System.Net;
using System.Net.Http;
using System.Web.Mvc;
using TEDU.Data.Infrastructure;
using TEDU.Model.Models;
using TEDU.Service;
using TEDU.Web.Infrastructure.Core;
using TEDU.Web.Infrastructure.Extensions;
using TEDU.Web.ViewModels;

namespace TEDU.Web.Api
{
    [RoutePrefix("api/appGroup")]
    public class AppGroupController : ApiControllerBase
    {
        private IAppGroupService _appGroupService;
        private IUnitOfWork _unitOfWork;

        public AppGroupController(IErrorService errorService, IAppGroupService appGroupService, IUnitOfWork unitOfWork) : base(errorService)
        {
            _appGroupService = appGroupService;
            _unitOfWork = unitOfWork;
        }

        [System.Web.Http.Authorize(Roles = "Admin, CanEditAppGroup, CanEditUser")]
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

        [System.Web.Http.Authorize(Roles = "Admin, CanEditAppGroup")]
        [System.Web.Http.HttpPost]
        public HttpResponseMessage Create(HttpRequestMessage request, AppGroupViewModel appGroupViewModel)
        {
            if (ModelState.IsValid)
            {
                var newAppGroup = new AppGroup(appGroupViewModel.Name);
                _appGroupService.Add(newAppGroup);
                _appGroupService.Save();
                return request.CreateResponse(HttpStatusCode.OK, appGroupViewModel);
            }
            else
            {
                return request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        [System.Web.Http.Authorize(Roles = "Admin, CanEditAppGroup")]
        [System.Web.Http.HttpPost]
        [Route("update")]
        public HttpResponseMessage Update(HttpRequestMessage request, AppGroupViewModel appGroupViewModel)
        {
            if (ModelState.IsValid)
            {
                var appGroup = _appGroupService.GetDetail(appGroupViewModel.Id);
                appGroup.UpdateAppGroup(appGroupViewModel);
                return request.CreateResponse(HttpStatusCode.OK, appGroup);
            }
            else
            {
                return request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        [System.Web.Http.Authorize(Roles = "Admin, CanEditAppGroup")]
        [System.Web.Http.HttpPost, System.Web.Http.ActionName("Delete")]
        [Route("delete")]
        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
        {
            var appGroup = _appGroupService.Delete(id);
            return request.CreateResponse(HttpStatusCode.OK, appGroup);
        }
    }
}