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
            var shortenedUrlListModel = new ShortenedUrlListModel();

            shortenedUrlListModel.ShortenedUrlItemModels = db.ShortenedUrls.Select(m => new ShortenedUrlItemModel
            {
                ID = m.ID,
                ShortUrl = m.ShortUrl,
                LongUrl = m.LongUrl
            }).ToList();

            return View(shortenedUrlListModel);
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
                    ShortUrl = "http://" + Request.Url.Authority + "/" + StringHelper.GenerateUniqueUrl(),
                };
                db.ShortenedUrls.Add(entity);
                db.SaveChanges();

                //TODO: should use AutoMapper here
                var shortenedUrlItemModel = new ShortenedUrlItemModel
                {
                    ID = entity.ID,
                    LongUrl = entity.LongUrl,
                    ShortUrl = entity.ShortUrl
                };

                return Json(shortenedUrlItemModel, JsonRequestBehavior.AllowGet);
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