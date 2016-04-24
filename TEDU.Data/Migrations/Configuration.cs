using System;
using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using TEDU.Model.Models;

namespace TEDU.Data.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<TEDU.Data.TEDUEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(TEDU.Data.TEDUEntities context)
        {
             //  This method will be called after migrating to the latest version.

            //var manager = new UserManager<AppUser>(new UserStore<AppUser>(new TEDUEntities()));
            
            //var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new TEDUEntities()));

            //var user = new AppUser()
            //{
            //    UserName = "tedu",
            //    Email = "tedu.international@gmail.com",
            //    EmailConfirmed = true,
            //    BirthDate = DateTime.Now,
            //    Bio = "Demo",
            //    FullName = "Technology Education"
                
            //};

            //manager.Create(user, "123654$");

            //if (!roleManager.Roles.Any())
            //{
            //    roleManager.Create(new IdentityRole { Name = "Admin"});
            //    roleManager.Create(new IdentityRole { Name = "User"});
            //}

            //var adminUser = manager.FindByName("SuperPowerUser");

            //manager.AddToRoles(adminUser.Id, new string[] { "Admin","User" });
          
        }
    }
}