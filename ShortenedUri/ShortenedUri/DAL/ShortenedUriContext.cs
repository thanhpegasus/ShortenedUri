using ShortenedUri.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ShortenedUri.DAL
{
    public class ShortenedUriContext : DbContext
    {
        public ShortenedUriContext() : base("ShortenedUriContext")
        {
        }

        public DbSet<ShortenedUrl> ShortenedUrls { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<ShortenedUrl>().HasKey(m => m.ID).Property(m => m.ID).IsRequired();
            modelBuilder.Entity<ShortenedUrl>().Property(m => m.ShortUrl).IsRequired();
            modelBuilder.Entity<ShortenedUrl>().Property(m => m.LongUrl).IsRequired().HasMaxLength(2083);
            modelBuilder.Entity<ShortenedUrl>().Property(m => m.CreatedOn).IsRequired();
            modelBuilder.Entity<ShortenedUrl>().Property(m => m.UpdatedOn).IsRequired();
        }
    }
}