namespace TEDU.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class foregintechline : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.CourseTechLines", "CourseId");
            CreateIndex("dbo.CourseTechLines", "TechLineId");
            AddForeignKey("dbo.CourseTechLines", "CourseId", "dbo.Courses", "ID", cascadeDelete: true);
            AddForeignKey("dbo.CourseTechLines", "TechLineId", "dbo.TechLines", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CourseTechLines", "TechLineId", "dbo.TechLines");
            DropForeignKey("dbo.CourseTechLines", "CourseId", "dbo.Courses");
            DropIndex("dbo.CourseTechLines", new[] { "TechLineId" });
            DropIndex("dbo.CourseTechLines", new[] { "CourseId" });
        }
    }
}
