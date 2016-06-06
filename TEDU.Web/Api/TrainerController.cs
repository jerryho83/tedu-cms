using TEDU.Service;
using TEDU.Web.App_Start;
using TEDU.Web.Infrastructure.Core;

namespace TEDU.Web.Api
{
    public class TrainerController : ApiControllerBase
    {
        private ApplicationUserManager _userManager;

        public TrainerController(IErrorService errorService, ApplicationUserManager userManager) : base(errorService)
        {
            this._userManager = userManager;
        }
    }
}