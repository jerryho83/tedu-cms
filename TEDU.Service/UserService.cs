using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEDU.Model.Models;

namespace TEDU.Service
{
    public interface IUserService
    {
        IdentityResult Create(AppUser user, string password);
        AppUser Find(string userName, string password);
    }
    public class UserService: IUserService
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;

        public UserService(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
        {
            this._roleManager = roleManager;
            this._userManager = userManager;
        }

        public IdentityResult Create(AppUser user, string password)
        {
           return _userManager.Create(user, password);
        }

        public AppUser Find(string userName, string password)
        {
            return _userManager.Find(userName, password);
        }
    }
}
