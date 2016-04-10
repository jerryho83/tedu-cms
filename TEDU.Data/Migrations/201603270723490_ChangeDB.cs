namespace TEDU.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDB : DbMigration
    {
        public override void Up()
        {
            AddColumn("Categories", "ShowHome",c=>c.Boolean());
            AddColumn("Posts", "HotFlag", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("Categories", "ShowHome");
            DropColumn("Posts", "HotFlag");
        }
    }
}
