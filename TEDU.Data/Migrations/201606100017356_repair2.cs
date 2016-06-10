namespace TEDU.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class repair2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AppRoleGroups","FK_dbo.AppRoleGroups_dbo.AppRoles_RoleId");
            DropForeignKey("dbo.AppUserGroups", "FK_dbo.AppUserGroups_dbo.AppRoles_AppRole_Id");
            DropTable("AppRoles");
            RenameTable(name: "dbo.IdentityRoles", newName: "AppRoles");
            RenameTable(name: "dbo.IdentityUserRoles", newName: "AppUserRoles");
            RenameTable(name: "dbo.IdentityUserLogins", newName: "AppUserLogins");
            AddColumn("dbo.AppRoles", "Description", c => c.String());
            AddColumn("dbo.AppRoles", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AppRoles", "Discriminator");
            DropColumn("dbo.AppRoles", "Description");
            RenameTable(name: "dbo.AppUserLogins", newName: "IdentityUserLogins");
            RenameTable(name: "dbo.AppUserRoles", newName: "IdentityUserRoles");
            RenameTable(name: "dbo.AppRoles", newName: "IdentityRoles");
        }
    }
}
