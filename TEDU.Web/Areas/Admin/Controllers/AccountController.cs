using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using TEDU.Web.App_Start;
using TEDU.Web.ViewModels;

namespace TEDU.Web.Areas.Admin.Controllers
{
    [RoutePrefix("api/admin/Account")]
    public class AccountController : ApiController
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public AccountController()
        {
        }

        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.Current.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.Route("authenticate")]
        [System.Web.Mvc.HttpPost]
        public async Task<HttpResponseMessage> Login(HttpRequestMessage request, LoginViewModel user)
        {
            if (!ModelState.IsValid)
            {
                return request.CreateResponse(HttpStatusCode.OK, new { success = false });
            }

            var result = await SignInManager.PasswordSignInAsync(user.UserName, user.Password, user.RememberMe, shouldLockout: false);
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
        public async Task<HttpResponseMessage> LogOut(HttpRequestMessage request)
        {
            IAuthenticationManager authenticationManager =  HttpContext.Current.GetOwinContext().Authentication;
            authenticationManager.SignOut();
            return request.CreateResponse(HttpStatusCode.OK, new { success = true });
        }
    }
}