using ShortenedUri.DAL;
using ShortenedUri.Entities;
using ShortenedUri.Helpers;
using ShortenedUri.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShortenedUri.Controllers
{
    public class HomeController : Controller
    {
        private ShortenedUriContext db = new ShortenedUriContext();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GenerateShortenedUrl(ShortenedUrlCreateModel model)
        {
            if (ModelState.IsValid)
            {
                var entity = new ShortenedUrl()
                {
                    CreatedOn = DateTime.UtcNow,
                    UpdatedOn = DateTime.UtcNow,
                    LongUrl = model.LongUrl,
                    ShortUrl = Request.Url.Authority + "/" + StringHelper.GenerateUniqueUrl(),
                };
                db.ShortenedUrls.Add(entity);
                db.SaveChanges();
                RedirectToAction("Index");
            }
            return View("Index");
        }

        public ActionResult RedirectToLongUrl(string shortUrl)
        {
            var shortenedUrl = db.ShortenedUrls.FirstOrDefault(m => m.ShortUrl.EndsWith(shortUrl));
            if (shortenedUrl != null)
            {
                return Redirect(shortenedUrl.LongUrl);
            }
            return RedirectToAction("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Shortened Uri Service";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "My Contact";

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}