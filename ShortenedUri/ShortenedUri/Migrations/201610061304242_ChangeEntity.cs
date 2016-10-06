namespace ShortenedUri.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeEntity : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ShortenedUrl", "ShortUrl", c => c.String(nullable: false, maxLength: 8));
            AlterColumn("dbo.ShortenedUrl", "LongUrl", c => c.String(nullable: false, maxLength: 2083));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ShortenedUrl", "LongUrl", c => c.String(nullable: false));
            AlterColumn("dbo.ShortenedUrl", "ShortUrl", c => c.String());
        }
    }
}
