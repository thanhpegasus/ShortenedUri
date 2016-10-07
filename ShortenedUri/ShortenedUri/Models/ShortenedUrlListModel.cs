using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShortenedUri.Models
{
    public class ShortenedUrlListModel
    {
        public ShortenedUrlListModel()
        {
            ShortenedUrlCreateModel = new ShortenedUrlCreateModel();
            ShortenedUrlItemModels = new List<ShortenedUrlItemModel>();
        }

        public ShortenedUrlCreateModel ShortenedUrlCreateModel { get; set; }

        public IList<ShortenedUrlItemModel> ShortenedUrlItemModels { get; set; }
    }
}