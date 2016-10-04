using System;
    
namespace ShortenedUri.Models
{
    public class ShortenedUrlModel
    {
        public int Id { get; set; }
        public string ShortUrl { get; set; }
        public string LongUrl { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}