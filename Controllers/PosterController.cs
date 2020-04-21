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
            ViewData["currencies"] = DataContext.Currencies.ToList();

            return View();
        }

        public ActionResult Filter()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-us");
            int priceFrom;
            int priceTo;
            int currencyID;
            int roomFrom;
            int roomTo;

            if(Request.Params["PriceFrom"] == "")
            {
                priceFrom = 0;
            }
            else
            {
                priceFrom = int.Parse(Request.Params["PriceFrom"]);
                if(priceFrom < 0)
                {
                    priceFrom = 0;
                }
            }

            if (Request.Params["PriceTo"] == "")
            {
                priceTo = 100000000;
            }
            else
            {
                priceTo = int.Parse(Request.Params["PriceTo"]);
                if(priceTo < 0)
                {
                    priceTo = 0;
                }
            }

            if (Request.Params["RoomFrom"] == "")
            {
                roomFrom = 1;
            }
            else
            {
                roomFrom = int.Parse(Request.Params["RoomFrom"]);
                if(roomFrom < 0)
                {
                    roomFrom = 0;
                }
            }

            if (Request.Params["RoomTo"] == "")
            {
                roomTo = 6;
            }
            else
            {
                roomTo = int.Parse(Request.Params["RoomTo"]);
                if(roomTo < 0)
                {
                    roomTo = 0;
                }
            }

            if (Request.Params["Currency"] == "")
            {
                currencyID = 1;
            }
            else
            {
                currencyID = int.Parse(Request.Params["Currency"]);
            }

            List<Flat> flats = DataContext.Flats.Where(f => f.CurrencyID == currencyID)
                                                   .Where(f => f.RoomCount >= roomFrom)
                                                   .Where(f => f.RoomCount <= roomTo).ToList();
            if(priceTo == 0)
            {
                ViewData["posters"] = flats;
            }
            else if(DataContext.Currencies.Find(currencyID).Name == "$")
            {
                ViewData["posters"] = flats.Where(f => f.PriceDollar >= priceFrom)
                                           .Where(f => f.PriceDollar <= priceTo).ToList();
            }
            else
            {
                ViewData["posters"] = flats.Where(f => f.PriceGrn >= priceFrom)
                                           .Where(f => f.PriceGrn <= priceTo).ToList();
            }
                                                   
            ViewData["photoPivots"] = DataContext.PhotoFlatPivots.ToList();
            ViewData["wishList"] = DataContext.WishFlatUserPivots
                                   .Where(wish => wish.UserName == User.Identity.Name)
                                   .ToList();
            ViewData["currencies"] = DataContext.Currencies.ToList();

            return View("Index");
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