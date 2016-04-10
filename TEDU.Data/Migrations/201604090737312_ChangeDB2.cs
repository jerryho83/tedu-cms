namespace TEDU.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class ChangeDB2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "SlideFlag", c => c.Boolean(nullable: true));
        }

        public override void Down()
        {
            AddColumn("dbo.Posts", "SlideFlag", c => c.Boolean(nullable: true));

        }
    }
}
