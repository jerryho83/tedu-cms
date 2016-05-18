namespace TEDU.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class Addmoretable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ebooks",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 250),
                    Alias = c.String(nullable: false, maxLength: 250, unicode: false),
                    Image = c.String(maxLength: 500),
                    Description = c.String(maxLength: 250),
                    Content = c.String(),
                    DownloadLink = c.String(maxLength: 250),
                    DownloadCount = c.Int(nullable: false),
                    DisplayOrder = c.Int(),
                    CreatedDate = c.DateTime(nullable: false),
                    CreatedBy = c.String(maxLength: 20, unicode: false),
                    Status = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.ID);

            CreateTable(
                "dbo.Pages",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    Name = c.String(maxLength: 250),
                    Alias = c.String(maxLength: 250, unicode: false),
                    Content = c.String(),
                    CreatedDate = c.DateTime(nullable: false),
                    CreateBy = c.String(maxLength: 50, unicode: false),
                    Status = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.ID);
        }

        public override void Down()
        {
            DropTable("dbo.Pages");
            DropTable("dbo.Ebooks");
        }
    }
}