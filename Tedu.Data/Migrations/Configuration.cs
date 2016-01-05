using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tedu.Entities;

namespace Tedu.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<TeduContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TeduContext context)
        {
         
            // create roles
            context.Roles.AddOrUpdate(r => r.Name, GenerateRoles());

            // username: chsakell, password: homecinema
            context.Users.AddOrUpdate(u => u.Email, new User[]{
                new User()
                {
                    Email="ngoctoan.dev@gmail.com",
                    Username="ngoctoan",
                    HashedPassword ="XwAQoiq84p1RUzhAyPfaMDKVgSwnn80NCtsE8dNv3XI=",
                    Salt = "mNKLRbEFCH8y1xIyTXP4qA==",
                    IsLocked = false,
                    DateCreated = DateTime.Now
                }
            });

            // // create user-admin for chsakell
            context.UserRoles.AddOrUpdate(new UserRole[] {
                new UserRole() {
                    RoleId = 1, // admin
                    UserId = 1  // chsakell
                }
            });
        }
        private Role[] GenerateRoles()
        {
            Role[] _roles = new Role[]{
                new Role()
                {
                    Name="Admin"
                }
            };

            return _roles;
        }
    }
}
