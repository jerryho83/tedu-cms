namespace TEDU.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class changecode : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Categories", "Name", c => c.String(maxLength: 250));
            AlterColumn("dbo.Categories", "Alias", c => c.String(maxLength: 250, unicode: false));
            AlterColumn("dbo.Posts", "Name", c => c.String(maxLength: 250));
            AlterColumn("dbo.Posts", "Alias", c => c.String(maxLength: 250, unicode: false));
            AlterColumn("dbo.Posts", "PostType", c => c.String(maxLength: 20, unicode: false));
            AlterColumn("dbo.Posts", "Status", c => c.String(maxLength: 10, unicode: false));
            AlterColumn("dbo.Ebooks", "Name", c => c.String(maxLength: 250));
            AlterColumn("dbo.Ebooks", "Alias", c => c.String(maxLength: 250, unicode: false));
        }

        public override void Down()
        {
            AlterColumn("dbo.Ebooks", "Alias", c => c.String(nullable: false, maxLength: 250, unicode: false));
            AlterColumn("dbo.Ebooks", "Name", c => c.String(nullable: false, maxLength: 250));
            AlterColumn("dbo.Posts", "Status", c => c.String(nullable: false, maxLength: 10, unicode: false));
            AlterColumn("dbo.Posts", "PostType", c => c.String(nullable: false, maxLength: 10, unicode: false));
            AlterColumn("dbo.Posts", "Alias", c => c.String(nullable: false, maxLength: 250, unicode: false));
            AlterColumn("dbo.Posts", "Name", c => c.String(nullable: false, maxLength: 250));
            AlterColumn("dbo.Categories", "Alias", c => c.String(nullable: false, maxLength: 250, unicode: false));
            AlterColumn("dbo.Categories", "Name", c => c.String(nullable: false, maxLength: 250));
        }
    }
}