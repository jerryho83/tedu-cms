namespace TEDU.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Categories", "Alias", c => c.String(nullable: false, maxLength: 250, unicode: false));
            AlterColumn("dbo.Posts", "Alias", c => c.String(nullable: false, maxLength: 250, unicode: false));
            AlterColumn("dbo.Posts", "Description", c => c.String(maxLength: 250));
            AlterColumn("dbo.Posts", "Source", c => c.String(maxLength: 250));
            AlterColumn("dbo.Posts", "Tags", c => c.String(maxLength: 250));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Posts", "Tags", c => c.String());
            AlterColumn("dbo.Posts", "Source", c => c.String());
            AlterColumn("dbo.Posts", "Description", c => c.String());
            AlterColumn("dbo.Posts", "Alias", c => c.String(nullable: false, maxLength: 250));
            AlterColumn("dbo.Categories", "Alias", c => c.String(nullable: false, maxLength: 250));
        }
    }
}
