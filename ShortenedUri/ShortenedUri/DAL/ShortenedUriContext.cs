using ShortenedUri.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ShortenedUri.DAL
{
    public class ShortenedUriContext : DbContext
    {
        public ShortenedUriContext() : base("ShortenedUriContext")
        {
        }

        public DbSet<ShortenedUrlModel> ShortenedUrls { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<ShortenedUrlModel>().ToTable("ShortenedUrl");
        }
    }
}