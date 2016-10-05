﻿using System;
using System.ComponentModel.DataAnnotations;

namespace ShortenedUri.Models
{
    public class ShortenedUrlModel
    {
        [Required]
        public int ID { get; set; }
        public string ShortUrl { get; set; }

        [Required]
        [RegularExpression(@"^https?://([a-z0-9-]+\.)*mydeal\.com\.au(/.*)?$", ErrorMessage = "Only accept URLs from the mydeal.com.au domain or any subdomains")]
        public string LongUrl { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public bool Deleted { get; set; }
    }
}