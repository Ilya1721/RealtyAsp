using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Realty.DB;
using Realty.Models;

namespace Realty.Controllers
{
    public class PosterController : Controller
    {
        private RealtyContext DataContext = RealtyContext.Create();

        public ActionResult Index()
        {
            ViewData["posters"] = DataContext.Flats.ToList();
            ViewData["photoPivots"] = DataContext.PhotoFlatPivots.ToList();

            return View();
        }

        public FileContentResult GetPriceImage(int? itemID)
        {
            Photo photo = DataContext.Photos.FirstOrDefault(p => p.PhotoID == itemID);

            return photo != null ? File(photo.Image, photo.ImageMimeType) : null;
        }
    }
}