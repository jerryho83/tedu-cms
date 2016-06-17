namespace TEDU.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changetrainer : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Courses", "TrainerId", "dbo.Trainers");
            DropIndex("dbo.Courses", new[] { "TrainerId" });
            DropPrimaryKey("dbo.Trainers");
            AlterColumn("dbo.Courses", "TrainerId", c => c.Int(nullable: false));
            AlterColumn("dbo.Trainers", "ID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Trainers", "ID");
            CreateIndex("dbo.Courses", "TrainerId");
            AddForeignKey("dbo.Courses", "TrainerId", "dbo.Trainers", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "TrainerId", "dbo.Trainers");
            DropIndex("dbo.Courses", new[] { "TrainerId" });
            DropPrimaryKey("dbo.Trainers");
            AlterColumn("dbo.Trainers", "ID", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Courses", "TrainerId", c => c.String(maxLength: 128));
            AddPrimaryKey("dbo.Trainers", "ID");
            CreateIndex("dbo.Courses", "TrainerId");
            AddForeignKey("dbo.Courses", "TrainerId", "dbo.Trainers", "ID");
        }
    }
}
