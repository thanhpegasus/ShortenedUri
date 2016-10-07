using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShortenedUri.Models
{
    public class ShortenedUrlItemModel
    {
        public int ID { get; set; }
        public string ShortUrl { get; set; }
        public string LongUrl { get; set; }
    }
}