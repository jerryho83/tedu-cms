using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TEDU.Model;
using TEDU.Service;
using TEDU.Web.Infrastructure.Core;
using TEDU.Web.ViewModels;

namespace TEDU.Web.Areas.Admin.Controllers
{
    public class CategoryController : ApiControllerBase
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService,IErrorService errorService):
           base(errorService)
        {
            this.categoryService = categoryService;
        }

        [AllowAnonymous]
        public HttpResponseMessage Get(HttpRequestMessage request, int? page, int? pageSize, string filter = null)
        {
            int currentPage = page.Value;
            int currentPageSize = pageSize.Value;

            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                int totalRow;
                IEnumerable<Category> model = categoryService.GetCategories(currentPage, currentPageSize, out totalRow, filter);


                IEnumerable<CategoryViewModel> modelVM = Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryViewModel>>(model);

                PaginationSet<CategoryViewModel> pagedSet = new PaginationSet<CategoryViewModel>()
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
    }
}