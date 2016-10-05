using ShortenedUri.DAL;
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
        public ActionResult GenerateShortenedUrl([Bind(Include = "LongUrl")] ShortenedUrlModel model)
        {
            if (ModelState.IsValid)
            {
                //TODO:
                var entity = new ShortenedUrlModel()
                {
                    CreatedOn = DateTime.UtcNow,
                    UpdatedOn = DateTime.UtcNow,
                    LongUrl = model.LongUrl,
                    ShortUrl = GenerateUniqueUrl(),
                };
                db.ShortenedUrls.Add(entity);
                db.SaveChanges();
                RedirectToAction("Index");
            }
            return View("Index");
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

        #region Utilites
        private string GenerateUniqueUrl()
        {
            return string.Empty;
        }

        #endregion

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