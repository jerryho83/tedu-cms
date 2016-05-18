namespace TEDU.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class addcolumnforebook2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ebooks", "MetaKeyword", c => c.String(maxLength: 250));
            AddColumn("dbo.Ebooks", "MetaDescription", c => c.String(maxLength: 250));
        }

        public override void Down()
        {
            DropColumn("dbo.Ebooks", "MetaDescription");
            DropColumn("dbo.PagEbookses", "MetaKeyword");
        }
    }
}