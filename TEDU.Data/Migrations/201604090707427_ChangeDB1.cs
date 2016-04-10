namespace TEDU.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class ChangeDB1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "SlideFlag", c => c.Boolean(nullable: false));
        }

        public override void Down()
        {
            AddColumn("dbo.Posts", "SlideFlag", c => c.Boolean(nullable: false));

            //AlterColumn("dbo.Posts", "HotFlag", c => c.DateTime());
            //AlterColumn("dbo.Categories", "ShowHome", c => c.DateTime());
            //DropColumn("dbo.Posts", "SlideFlag");
        }
    }
}
