using System.Collections.Generic;
using Tedu.Entities;
using Tedu.Services.Utilities;

namespace Tedu.Services
{
    public interface IMembershipService
    {
        MembershipContext ValidateUser(string username, string password);

        User CreateUser(string username, string email, string password, int[] roles);

        User GetUser(int userId);

        List<Role> GetUserRoles(string username);
    }
}