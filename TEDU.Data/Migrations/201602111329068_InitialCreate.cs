namespace TEDU.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false),
                    Alias = c.String(nullable: false),
                    ParentID = c.Int(),
                    CreatedDate = c.DateTime(nullable: false),
                    CreatedBy = c.String(),
                    LastModifiedBy = c.String(),
                    LastModifiedDate = c.DateTime(nullable: false),
                    Status = c.String(nullable: false),
                })
                .PrimaryKey(t => t.ID);

            CreateTable(
                "dbo.Posts",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false),
                    Alias = c.String(nullable: false),
                    Description = c.String(),
                    CategoryID = c.Int(nullable: false),
                    Image = c.String(),
                    Content = c.String(),
                    PostType = c.String(nullable: false),
                    Source = c.String(),
                    Status = c.String(nullable: false),
                    ViewCount = c.Int(),
                    Tags = c.String(),
                    CreatedDate = c.DateTime(nullable: false),
                    CreateBy = c.String(),
                    LastModifiedDate = c.DateTime(nullable: false),
                    LastModifiedBy = c.String(),
                    OtherStatus = c.String(),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .Index(t => t.CategoryID);

        }

        public override void Down()
        {
            DropForeignKey("dbo.Posts", "CategoryID", "dbo.Categories");
            DropIndex("dbo.Posts", new[] { "CategoryID" });
            DropTable("dbo.Posts");
            DropTable("dbo.Categories");
        }
    }
}
