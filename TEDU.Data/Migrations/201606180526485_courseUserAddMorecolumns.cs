namespace TEDU.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class courseUserAddMorecolumns : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CourseUsers", "UserId", "dbo.AppUsers");
            DropIndex("dbo.CourseUsers", new[] { "UserId" });
            DropPrimaryKey("dbo.CourseUsers");
            AddColumn("dbo.CourseUsers", "ID", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.CourseUsers", "Status", c => c.Boolean(nullable: false));
            AlterColumn("dbo.CourseUsers", "UserId", c => c.String(maxLength: 128));
            AddPrimaryKey("dbo.CourseUsers", "ID");
            CreateIndex("dbo.CourseUsers", "UserId");
            AddForeignKey("dbo.CourseUsers", "UserId", "dbo.AppUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CourseUsers", "UserId", "dbo.AppUsers");
            DropIndex("dbo.CourseUsers", new[] { "UserId" });
            DropPrimaryKey("dbo.CourseUsers");
            AlterColumn("dbo.CourseUsers", "UserId", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.CourseUsers", "Status");
            DropColumn("dbo.CourseUsers", "ID");
            AddPrimaryKey("dbo.CourseUsers", new[] { "UserId", "CourseId" });
            CreateIndex("dbo.CourseUsers", "UserId");
            AddForeignKey("dbo.CourseUsers", "UserId", "dbo.AppUsers", "Id", cascadeDelete: true);
        }
    }
}
