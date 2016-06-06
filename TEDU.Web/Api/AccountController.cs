using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using TEDU.Service;
using TEDU.Web.App_Start;
using TEDU.Web.Infrastructure.Core;
using TEDU.Web.ViewModels;

namespace TEDU.Web.Api
{
    [RoutePrefix("api/account")]
    [Authorize]
    public class AccountController : ApiControllerBase
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private IErrorService _errorService;

        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager,IErrorService errorService)
            : base(errorService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

     

        [AllowAnonymous]
        [Route("login")]
        [HttpPost]
        public async Task<HttpResponseMessage> Login(HttpRequestMessage request, LoginViewModel user)
        {
            if (!ModelState.IsValid)
            {
                return request.CreateResponse(HttpStatusCode.OK, new { success = false });
            }

            var result = await _signInManager.PasswordSignInAsync(user.UserName, user.Password, user.RememberMe, false);
            switch (result)
            {
                case SignInStatus.Success:
                    return request.CreateResponse(HttpStatusCode.OK, new { success = true });

                case SignInStatus.LockedOut:
                    return request.CreateResponse(HttpStatusCode.OK, new { success = false });

                case SignInStatus.Failure:
                default:
                    return request.CreateResponse(HttpStatusCode.OK, new { success = false });
            }
        }

        [HttpPost]
        [Authorize]
        [Route("logout")]
        public HttpResponseMessage LogOut(HttpRequestMessage request)
        {
            IAuthenticationManager authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
            authenticationManager.SignOut();
            return request.CreateResponse(HttpStatusCode.OK, new { success = true });
        }
    }
}