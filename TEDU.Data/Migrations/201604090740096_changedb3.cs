namespace TEDU.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedb3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "SlideFlag", c => c.Boolean(nullable: true));

        }

        public override void Down()
        {
        }
    }
}
