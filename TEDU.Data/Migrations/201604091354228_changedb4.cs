namespace TEDU.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedb4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PostTags",
                c => new
                    {
                        PostID = c.Int(nullable: false),
                        TagID = c.String(nullable: false, maxLength: 250, unicode: false),
                    })
                .PrimaryKey(t => new { t.PostID, t.TagID });
                
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 250, unicode: false),
                        Name = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tags");
            DropTable("dbo.PostTags");
        }
    }
}
