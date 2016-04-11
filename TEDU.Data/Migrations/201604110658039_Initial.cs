namespace TEDU.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "ShowHomeTemp", c => c.Boolean());
            DropColumn("dbo.Categories", "ShowHome");

            RenameColumn("dbo.Categories", "ShowHomeTemp", "ShowHome");

            AddColumn("dbo.Posts", "HotFlagTemp", c => c.Boolean());
            DropColumn("dbo.Posts", "HotFlag");
            RenameColumn("dbo.Posts", "HotFlagTemp", "HotFlag");

        }
        
        public override void Down()
        {
        }
    }
}
