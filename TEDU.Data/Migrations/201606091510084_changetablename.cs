namespace TEDU.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changetablename : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AppUserGroups", "AppRole_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.AppUserGroups", "AppRole_Id");
            AddForeignKey("dbo.AppUserGroups", "AppRole_Id", "dbo.AppRoles", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AppUserGroups", "AppRole_Id", "dbo.AppRoles");
            DropIndex("dbo.AppUserGroups", new[] { "AppRole_Id" });
            DropColumn("dbo.AppUserGroups", "AppRole_Id");
        }
    }
}
