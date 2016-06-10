namespace TEDU.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Model.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    internal sealed class Configuration : DbMigrationsConfiguration<TEDU.Data.TeduDbContext>
    {
        private readonly TeduDbContext _db = new TeduDbContext();
        private readonly string[] _groupAdminRoleNames = { "CanEditUser", "CanEditGroup", "User" };

        private readonly string[] _initialGroupNames = { "SuperAdmins", "GroupAdmins", "UserAdmins", "Users" };


        private readonly string[] _superAdminRoleNames = { "Admin", "CanEditUser", "CanEditGroup", "CanEditRole", "User" };
        private readonly string[] _userAdminRoleNames = { "CanEditUser", "User" };
        private readonly string[] _userRoleNames = { "User" };
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(TEDU.Data.TeduDbContext context)
        {
            
        }

        public void AddGroups(TeduDbContext context)
        {
            foreach (var groupName in _initialGroupNames)
            {

                context.AppGroups.Add(new Model.Models.AppGroup()
                {
                    Name = groupName
                });
                context.SaveChanges();

            }
        }

        private void AddRoles(TeduDbContext context)
        {
            context.Roles.Add(new IdentityRole()
            {
                Id = "Admin",
                Name = "Global Access"
            });
            context.Roles.Add(new IdentityRole()
            {
                Id = "CanEditUser",
                Name = "Add, modify, and delete Users"
            });
            context.Roles.Add(new IdentityRole()
            {
                Id = "CanEditGroup",
                Name = "Global Access"
            });
            context.Roles.Add(new IdentityRole()
            {
                Id = "CanEditRole",
                Name = "Add, modify, and delete roles"
            });
            context.Roles.Add(new IdentityRole()
            {
                Id = "User",
                Name = "Restricted to business domain activity"
            });
            // Some example initial roles. These COULD BE much more granular:
            context.SaveChanges();
        }

        //private void AddRolesToGroups()
        //{
        //    // Add the Super-Admin Roles to the Super-Admin Group:
        //    IDbSet<AppGroup> allGroups = _db.AppGroups;
        //    AppGroup superAdmins = allGroups.First(g => g.Name == "SuperAdmins");
        //    foreach (string name in _superAdminRoleNames)
        //    {
        //        _idManager.AddRoleToGroup(superAdmins.Id, name);
        //    }

        //    // Add the Group-Admin Roles to the Group-Admin Group:
        //    AppGroup groupAdmins = _db.AppGroups.First(g => g.Name == "GroupAdmins");
        //    foreach (string name in _groupAdminRoleNames)
        //    {
        //        _idManager.AddRoleToGroup(groupAdmins.Id, name);
        //    }

        //    // Add the User-Admin Roles to the User-Admin Group:
        //    AppGroup userAdmins = _db.AppGroups.First(g => g.Name == "UserAdmins");
        //    foreach (string name in _userAdminRoleNames)
        //    {
        //        _idManager.AddRoleToGroup(userAdmins.Id, name);
        //    }

        //    // Add the User Roles to the Users Group:
        //    AppGroup users = _db.AppGroups.First(g => g.Name == "Users");
        //    foreach (string name in _userRoleNames)
        //    {
        //        _idManager.AddRoleToGroup(users.Id, name);
        //    }
        //}

        private void CreateUser(TeduDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            var manager = new UserManager<AppUser>(new UserStore<AppUser>(new TeduDbContext()));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new TeduDbContext()));

            var user = new AppUser()
            {
                UserName = "tedu",
                Email = "tedu.international@gmail.com",
                EmailConfirmed = true,
                BirthDate = DateTime.Now,
                Bio = "Demo",
                FullName = "Technology Education"

            };

            manager.Create(user, "123654$");

            var adminUser = manager.FindByEmail("tedu.international@gmail.com");

            manager.AddToRoles(adminUser.Id, _initialGroupNames);
        }

    }
}