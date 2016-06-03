namespace TEDU.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcoursemodule : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CourseCategories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 250),
                        Alias = c.String(maxLength: 250, unicode: false),
                        DisplayOrder = c.Int(nullable: false),
                        MetaKeyword = c.String(maxLength: 250),
                        MetaDescription = c.String(maxLength: 250),
                        ShowHome = c.Boolean(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                        Alias = c.String(nullable: false, maxLength: 250, unicode: false),
                        Description = c.String(maxLength: 500),
                        CategoryId = c.Int(nullable: false),
                        Image = c.String(maxLength: 250),
                        Duration = c.Int(),
                        Price = c.Int(nullable: false),
                        PromotionPrice = c.Int(),
                        Content = c.String(),
                        Level = c.Int(nullable: false),
                        DisplayOrder = c.Int(nullable: false),
                        Status = c.String(maxLength: 10, unicode: false),
                        ViewCount = c.Int(),
                        TrainerId = c.String(maxLength: 128),
                        CreatedDate = c.DateTime(nullable: false),
                        CreateBy = c.String(maxLength: 50),
                        LastModifiedDate = c.DateTime(),
                        MetaKeyword = c.String(maxLength: 250),
                        MetaDescription = c.String(maxLength: 250),
                        HotFlag = c.Boolean(),
                        SlideFlag = c.Boolean(),
                        LastModifiedBy = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CourseCategories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Trainers", t => t.TrainerId)
                .Index(t => t.CategoryId)
                .Index(t => t.TrainerId);
            
            CreateTable(
                "dbo.Trainers",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        Name = c.String(maxLength: 128),
                        Portfolio = c.String(),
                        JobTitle = c.String(maxLength: 128),
                        Image = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.CourseReviews",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Mark = c.Int(),
                        Content = c.String(),
                        UserId = c.String(maxLength: 128),
                        CourseId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AppUsers", t => t.UserId)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.CourseTechLines",
                c => new
                    {
                        CourseId = c.Int(nullable: false),
                        TechLineId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CourseId, t.TechLineId });
            
            CreateTable(
                "dbo.CourseUsers",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        CourseId = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        PaymentMethodId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.CourseId })
                .ForeignKey("dbo.AppUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.PaymentMethods", t => t.PaymentMethodId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.CourseId)
                .Index(t => t.PaymentMethodId);
            
            CreateTable(
                "dbo.PaymentMethods",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                        Fee = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.CourseVideos",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                        Alias = c.String(nullable: false, maxLength: 250),
                        Path = c.String(nullable: false, maxLength: 250),
                        Duration = c.Int(nullable: false),
                        SlidePath = c.String(),
                        SourceCodePath = c.String(),
                        Reference = c.String(),
                        CourseId = c.Int(nullable: false),
                        Chapter = c.String(),
                        DisplayOrder = c.Int(nullable: false),
                        AllowTrialView = c.Boolean(nullable: false),
                        TrialViewTime = c.Int(nullable: false),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        LastModifiedBy = c.String(),
                        LastModifiedDate = c.DateTime(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.TechLines",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.VideoComments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        UserId = c.String(),
                        ParentId = c.Int(),
                        AttachImage = c.String(),
                        VideoId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CourseVideos", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.CourseUsers", "PaymentMethodId", "dbo.PaymentMethods");
            DropForeignKey("dbo.CourseUsers", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.CourseUsers", "UserId", "dbo.AppUsers");
            DropForeignKey("dbo.CourseReviews", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.CourseReviews", "UserId", "dbo.AppUsers");
            DropForeignKey("dbo.Courses", "TrainerId", "dbo.Trainers");
            DropForeignKey("dbo.Courses", "CategoryId", "dbo.CourseCategories");
            DropIndex("dbo.CourseVideos", new[] { "CourseId" });
            DropIndex("dbo.CourseUsers", new[] { "PaymentMethodId" });
            DropIndex("dbo.CourseUsers", new[] { "CourseId" });
            DropIndex("dbo.CourseUsers", new[] { "UserId" });
            DropIndex("dbo.CourseReviews", new[] { "CourseId" });
            DropIndex("dbo.CourseReviews", new[] { "UserId" });
            DropIndex("dbo.Courses", new[] { "TrainerId" });
            DropIndex("dbo.Courses", new[] { "CategoryId" });
            DropTable("dbo.VideoComments");
            DropTable("dbo.TechLines");
            DropTable("dbo.CourseVideos");
            DropTable("dbo.PaymentMethods");
            DropTable("dbo.CourseUsers");
            DropTable("dbo.CourseTechLines");
            DropTable("dbo.CourseReviews");
            DropTable("dbo.Trainers");
            DropTable("dbo.Courses");
            DropTable("dbo.CourseCategories");
        }
    }
}
