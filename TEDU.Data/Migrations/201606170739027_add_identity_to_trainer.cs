namespace TEDU.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_identity_to_trainer : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Courses", "TrainerId", "dbo.Trainers");
            DropTable("dbo.Trainers");
          
        }
        
        public override void Down()
        {
        }
    }
}
