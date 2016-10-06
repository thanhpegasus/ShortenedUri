using ShortenedUri.Validators;
using System;
using System.ComponentModel.DataAnnotations;

namespace ShortenedUri.Models
{
    public class ShortenedUrlCreateModel
    {
        [Required]
        [Domain(ErrorMessage = "The URL is not from the mydeal.com.au domain or any subdomains or invalid URL")]
        public string LongUrl { get; set; }
    }
}