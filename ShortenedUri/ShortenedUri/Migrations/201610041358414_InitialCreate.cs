namespace ShortenedUri.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ShortenedUrl",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ShortUrl = c.String(),
                        LongUrl = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        UpdatedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ShortenedUrl");
        }
    }
}
