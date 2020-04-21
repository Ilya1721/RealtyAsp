using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using Realty.DB;
using Realty.Models;
using Microsoft.AspNet.Identity;

namespace Realty.Controllers
{
    public class PosterController : Controller
    {
        private RealtyContext DataContext = RealtyContext.Create();

        public ActionResult Index()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-us");
            ViewData["posters"] = DataContext.Flats.ToList();
            ViewData["photoPivots"] = DataContext.PhotoFlatPivots.ToList();
            ViewData["wishList"] = DataContext.WishFlatUserPivots
                                   .Where(wish => wish.UserName == User.Identity.Name)
                                   .ToList();

            return View();
        }

        public ActionResult Show(int? posterID)
        {
            List<PhotoFlatPivot> pivots = DataContext.PhotoFlatPivots.Where(p => p.FlatID == posterID).ToList();
            var Ids = pivots.Select(piv => piv.PhotoID);
            List<Photo> photos = DataContext.Photos.Where(p => Ids.Contains(p.PhotoID)).ToList();

            ViewData["flat"] = DataContext.Flats.Find(posterID);
            ViewData["photos"] = photos;

            return View();
        }

        public FileContentResult GetImage(int? flatID, int photoID = 0)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-us");
            List<PhotoFlatPivot> pivots = DataContext.PhotoFlatPivots.Where(p => p.FlatID == flatID).ToList();
            var Ids = pivots.Select(piv => piv.PhotoID);
            List<Photo> photos = DataContext.Photos.Where(p => Ids.Contains(p.PhotoID)).ToList();

            Photo photo = photos[photoID];

            return photo != null ? File(photo.Image, photo.ImageMimeType) : null;
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewData["currencies"] = DataContext.Currencies.ToList();
            ViewData["heaterTypes"] = DataContext.HeaterTypes.ToList();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public RedirectResult Store()
        {
            var Context = DataContext;
            Context.Currencies.Add(new Models.Currency
            {
                Name = Request.Params["Name"]
            });
            Context.SaveChanges();

            return Redirect(Url.Action("Index", "Currency"));
        }
    }
}