using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using TEDU.Model.Models;
using TEDU.Service;
using TEDU.Web.App_Start;
using TEDU.Web.Infrastructure.Core;
using TEDU.Web.ViewModels;

namespace TEDU.Web.Api
{
    public class RoleController : ApiControllerBase
    {
        private ApplicationRoleManager _roleManager;
        public RoleController(ApplicationRoleManager roleManager, IErrorService errorService) : base(errorService)
        {
            _roleManager = roleManager;
        }

        [Route("getlistpaging")]
        public HttpResponseMessage GetListPaging(HttpRequestMessage request, int page, int pageSize, string filter = null)
        {

            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                var model = _roleManager.Roles.OrderBy(x => x.Id).Skip(page * pageSize).Take(pageSize);
                int totalRow = _roleManager.Roles.Count();
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
    }
}
