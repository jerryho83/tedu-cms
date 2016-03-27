namespace TEDU.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDB : DbMigration
    {
        public override void Up()
        {
            Sql("update dbo.Posts set Status = 'Publish'");
        }
        
        public override void Down()
        {
        }
    }
}
