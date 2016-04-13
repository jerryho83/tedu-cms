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
            //var UserManager = new UserManager<AppUser>(new UserStore<AppUser>(context));
            //var RoleManager = new RoleManager<IdentityRole>(new
            //                             RoleStore<IdentityRole>(context));
            //string name = "admin";
            //string password = "123456";
            //if (!RoleManager.RoleExists(name))
            //{
            //    var roleresult = RoleManager.Create(new IdentityRole(name));
            //}

            //var user = new AppUser();
            //user.UserName = name;
            //user.BirthDate = DateTime.Now;
            //var adminresult = UserManager.Create(user, password);
            //if (adminresult.Succeeded)
            //{
            //    var result = UserManager.AddToRole(user.Id, name);
            //}
            //base.Seed(context);
        }
    }
}