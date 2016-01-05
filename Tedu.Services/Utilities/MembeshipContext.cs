using System.Security.Principal;
using Tedu.Entities;

namespace Tedu.Services.Utilities
{
    public class MembershipContext
    {
        public IPrincipal Principal { get; set; }
        public User User { get; set; }

        public bool IsValid()
        {
            return Principal != null;
        }
    }
}