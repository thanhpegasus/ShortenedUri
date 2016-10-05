namespace ShortenedUri.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDeletedField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ShortenedUrl", "Deleted", c => c.Boolean(nullable: false));
            AlterColumn("dbo.ShortenedUrl", "LongUrl", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ShortenedUrl", "LongUrl", c => c.String());
            DropColumn("dbo.ShortenedUrl", "Deleted");
        }
    }
}
