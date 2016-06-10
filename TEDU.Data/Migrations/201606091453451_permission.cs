namespace TEDU.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class permission : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AppGroups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AppUserGroups",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        GroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.GroupId })
                .ForeignKey("dbo.AppGroups", t => t.GroupId, cascadeDelete: true)
                .ForeignKey("dbo.AppUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.GroupId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AppUserGroups", "UserId", "dbo.AppUsers");
            DropForeignKey("dbo.AppUserGroups", "GroupId", "dbo.AppGroups");
            DropIndex("dbo.AppUserGroups", new[] { "GroupId" });
            DropIndex("dbo.AppUserGroups", new[] { "UserId" });
            DropTable("dbo.AppUserGroups");
            DropTable("dbo.AppGroups");
        }
    }
}
