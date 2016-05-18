namespace TEDU.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class addcolumnforpage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pages", "MetaKeyword", c => c.String(maxLength: 250));
            AddColumn("dbo.Pages", "MetaDescription", c => c.String(maxLength: 250));
        }

        public override void Down()
        {
            DropColumn("dbo.Pages", "MetaDescription");
            DropColumn("dbo.Pages", "MetaKeyword");
        }
    }
}