using ShortenedUri.Validators;
using System;
using System.ComponentModel.DataAnnotations;

namespace ShortenedUri.Entities
{
    public class ShortenedUrl
    {
        public int ID { get; set; }
        public string ShortUrl { get; set; }
        public string LongUrl { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public bool Deleted { get; set; }
    }
}