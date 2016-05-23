using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TEDU.Service;
using TEDU.Web.Infrastructure.Core;

namespace TEDU.Web.Api
{
    [Authorize]
    [RoutePrefix("api/home")]
    public class HomeController : ApiControllerBase
    {
        IErrorService _errorService;
        public HomeController(IErrorService errorService) : base(errorService)
        {
            this._errorService = errorService;
        }
        [HttpGet]
        [Route("TestMethod")]
        public string TestMethod()
        {
            return "Hello, C# Corner Member. ";
        }
    }
}
