namespace TEDU.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class repair3 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.IdentityUserClaims", newName: "AppUserClaims");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.AppUserClaims", newName: "IdentityUserClaims");
        }
    }
}
