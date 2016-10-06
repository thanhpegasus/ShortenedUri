namespace ShortenedUri.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveMaxlength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ShortenedUrl", "ShortUrl", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ShortenedUrl", "ShortUrl", c => c.String(nullable: false, maxLength: 8));
        }
    }
}
