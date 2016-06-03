namespace TEDU.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class videocomment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VideoComments", "Status", c => c.Boolean(nullable: false));
            AlterColumn("dbo.VideoComments", "Content", c => c.String(nullable: false));
            AlterColumn("dbo.VideoComments", "UserId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.VideoComments", "AttachImage", c => c.String(maxLength: 250));
            AlterColumn("dbo.VideoComments", "CreatedBy", c => c.String(maxLength: 128));
            CreateIndex("dbo.VideoComments", "UserId");
            CreateIndex("dbo.VideoComments", "ParentId");
            CreateIndex("dbo.VideoComments", "VideoId");
            AddForeignKey("dbo.VideoComments", "UserId", "dbo.AppUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.VideoComments", "VideoId", "dbo.CourseVideos", "ID", cascadeDelete: true);
            AddForeignKey("dbo.VideoComments", "ParentId", "dbo.VideoComments", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VideoComments", "ParentId", "dbo.VideoComments");
            DropForeignKey("dbo.VideoComments", "VideoId", "dbo.CourseVideos");
            DropForeignKey("dbo.VideoComments", "UserId", "dbo.AppUsers");
            DropIndex("dbo.VideoComments", new[] { "VideoId" });
            DropIndex("dbo.VideoComments", new[] { "ParentId" });
            DropIndex("dbo.VideoComments", new[] { "UserId" });
            AlterColumn("dbo.VideoComments", "CreatedBy", c => c.String());
            AlterColumn("dbo.VideoComments", "AttachImage", c => c.String());
            AlterColumn("dbo.VideoComments", "UserId", c => c.String());
            AlterColumn("dbo.VideoComments", "Content", c => c.String());
            DropColumn("dbo.VideoComments", "Status");
        }
    }
}
