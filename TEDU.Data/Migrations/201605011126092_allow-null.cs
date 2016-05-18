namespace TEDU.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class allownull : DbMigration
    {
        public override void Up()
        {
            Sql("ALTER TABLE Posts ALTER COLUMN HotFlag bit NULL");
        }

        public override void Down()
        {
        }
    }
}