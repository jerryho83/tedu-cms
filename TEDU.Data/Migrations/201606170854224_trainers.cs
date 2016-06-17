namespace TEDU.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class trainers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
             "dbo.Trainers",
             c => new
             {
                 ID = c.Int(nullable: false, identity: true),
                 Name = c.String(maxLength: 128),
                 Portfolio = c.String(),
                 JobTitle = c.String(maxLength: 128),
                 Image = c.String(maxLength: 250),
             })
             .PrimaryKey(t => t.ID);

            AddForeignKey("dbo.Courses", "TrainerId", "dbo.Trainers", "ID");
        }

        public override void Down()
        {
            DropForeignKey("dbo.Courses", "TrainerId", "dbo.Trainers");
            DropTable("dbo.Trainers");

        }
    }
}
