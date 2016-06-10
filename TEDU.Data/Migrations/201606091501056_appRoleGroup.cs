namespace TEDU.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class appRoleGroup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AppRoleGroups",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        GroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RoleId, t.GroupId })
                .ForeignKey("dbo.AppGroups", t => t.GroupId, cascadeDelete: true)
                .ForeignKey("dbo.AppRoles", t => t.RoleId)
                .Index(t => t.RoleId)
                .Index(t => t.GroupId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AppRoleGroups", "RoleId", "dbo.AppRoles");
            DropForeignKey("dbo.AppRoleGroups", "GroupId", "dbo.AppGroups");
            DropIndex("dbo.AppRoleGroups", new[] { "GroupId" });
            DropIndex("dbo.AppRoleGroups", new[] { "RoleId" });
            DropTable("dbo.AppRoleGroups");
        }
    }
}
