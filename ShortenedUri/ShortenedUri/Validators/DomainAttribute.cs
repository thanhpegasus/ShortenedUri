using System;
using System.ComponentModel.DataAnnotations;
using System.Configuration;

namespace ShortenedUri.Validators
{
    public class DomainAttribute : RegularExpressionAttribute
    {
        public DomainAttribute()
            : base(GetRegex())
        { }

        private static string GetRegex()
        {
            return ConfigurationManager.AppSettings["DomainRegex"] ?? @"^https?://([a-z0-9-]+\.)*mydeal\.com\.au(/.*)?$";
        }
    }
}