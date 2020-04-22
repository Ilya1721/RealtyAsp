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
using System.Net;
using System.IO;
using System.Drawing.Imaging;
using Realty.Infrastructure;
using System.Drawing;

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

        public ActionResult MyPosters()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-us");
            ViewData["posters"] = DataContext.Flats.Where(f => f.UserName ==
                                                               User.Identity.Name).ToList();
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
            string street;
            string district;
            string districtType;
            string house;
            string flatNumber;
            string description;
            int? buildYear;
            int priceDollar = 0;
            int priceGrn = 0;
            int roomCount = 0;
            double areaSize = 0;
            double kitchenSize = 0;
            int floor = 1;
            int maxFloor = 1;
            bool isExhange = false;
            bool isBarter = false;
            
            if(Request.Params["Street"] != null)
            {
                street = Request.Params["Street"];
            }
            else
            {
                street = "";
            }
            if (Request.Params["District"] != null)
            {
                district = Request.Params["District"];
            }
            else
            {
                district = "";
            }
            if (Request.Params["DistrictType"] != null)
            {
                districtType = Request.Params["DistrictType"];
            }
            else
            {
                districtType = "";
            }
            if (Request.Params["House"] != null)
            {
                house = Request.Params["House"];
            }
            else
            {
                house = "";
            }
            if (Request.Params["FlatNumber"] != null)
            {
                flatNumber = Request.Params["FlatNumber"];
            }
            else
            {
                flatNumber = "";
            }
            if (Request.Params["Description"] != null)
            {
                description = Request.Params["Description"];
            }
            else
            {
                description = "";
            }
            if (Request.Params["BuildYear"] != null)
            {
                buildYear = int.Parse(Request.Params["BuildYear"]);
            }
            else
            {
                buildYear = null;
            }
            if(Request.Params["PriceDollar"] != null)
            {
                try
                {
                    priceDollar = int.Parse(Request.Params["PriceDollar"]);
                    if(priceDollar < 0)
                    {
                        priceDollar = 0;
                    }
                }
                catch(Exception exc)
                {
                    return Redirect(Url.Action("Index", "Poster"));
                }
            }
            if (Request.Params["PriceGrn"] != null)
            {
                try
                {
                    priceGrn = int.Parse(Request.Params["PriceGrn"]);
                    if (priceGrn < 0)
                    {
                        priceGrn = 0;
                    }
                }
                catch (Exception exc)
                {
                    return Redirect(Url.Action("Index", "Poster"));
                }
            }
            if(Request.Params["RoomCount"] != null)
            {
                try
                {
                    roomCount = int.Parse(Request.Params["RoomCount"]);
                    if (roomCount < 0)
                    {
                        roomCount = 0;
                    }
                }
                catch (Exception exc)
                {
                    return Redirect(Url.Action("Index", "Poster"));
                }
            }
            if (Request.Params["AreaSize"] != null)
            {
                try
                {
                    areaSize = int.Parse(Request.Params["AreaSize"]);
                    if (areaSize < 0)
                    {
                        areaSize = 0;
                    }
                }
                catch (Exception exc)
                {
                    return Redirect(Url.Action("Index", "Poster"));
                }
            }
            if (Request.Params["KitchenSize"] != null)
            {
                try
                {
                    kitchenSize = int.Parse(Request.Params["KitchenSize"]);
                    if (kitchenSize < 0)
                    {
                        kitchenSize = 0;
                    }
                }
                catch (Exception exc)
                {
                    return Redirect(Url.Action("Index", "Poster"));
                }
            }
            if (Request.Params["Floor"] != null)
            {
                try
                {
                    floor = int.Parse(Request.Params["Floor"]);
                    if (floor < 0)
                    {
                        floor = 0;
                    }
                }
                catch (Exception exc)
                {
                    return Redirect(Url.Action("Index", "Poster"));
                }
            }
            if (Request.Params["MaxFloor"] != null)
            {
                try
                {
                    maxFloor = int.Parse(Request.Params["MaxFloor"]);
                    if (maxFloor < 0)
                    {
                        maxFloor = 0;
                    }
                }
                catch (Exception exc)
                {
                    return Redirect(Url.Action("Index", "Poster"));
                }
            }


            Flat flat = Context.Flats.Add(new Models.Flat
            {
                Street = street,
                District = district,
                DistrictType = districtType,
                House = house,
                FlatNumber = flatNumber,
                Description = description,
                PriceDollar = priceDollar,
                PriceGrn = priceGrn,
                CurrencyID = int.Parse(Request.Params["CurrencyID"]),
                UserName = User.Identity.Name,
                RoomCount = roomCount,
                AreaSize = areaSize,
                Floor = floor,
                MaxFloor = maxFloor,
                KitchenSize = kitchenSize,
                HeaterTypeID = int.Parse(Request.Params["HeaterTypeID"]),
                BuildYear = buildYear,
                IsExhange = isExhange,
                IsBarter = isBarter,
                Date = DateTime.Now
            });
            Context.SaveChanges();

            if (Request.Files.Count != 0)
            {
                for(int i = 0; i < Request.Files.Count; ++i)
                {
                    string fileName = System.IO.Path.GetFileName(Request.Files[i].FileName);
                    Request.Files[i].SaveAs(Server.MapPath("~/Content/img/" + fileName));
                    var extension = Path.GetExtension(Server.MapPath("~/Content/img/" + fileName)).ToLower();
                    ImageFormat imageFormat = ImageFormat.Jpeg;

                    switch (extension)
                    {
                        case ".jfif": imageFormat = ImageFormat.Jpeg; break;
                        case ".jpg": imageFormat = ImageFormat.Jpeg; break;
                        case ".png": imageFormat = ImageFormat.Png; break;
                        case ".gif": imageFormat = ImageFormat.Gif; break;
                        case ".icon": imageFormat = ImageFormat.Icon; break;
                    }

                    var FlatImage = ImageLoader.
                        ImageToByteArray(Image.FromFile(Server.MapPath("~/Content/img/" + fileName)), imageFormat);
                    var FlatImageMimeType = imageFormat;

                    Photo photo = Context.Photos.Add(new Photo
                    {
                        Image = FlatImage,
                        ImageMimeType = "image/" + extension.Substring(1)
                    });
                    Context.SaveChanges();

                    Context.PhotoFlatPivots.Add(new PhotoFlatPivot
                    {
                        FlatID = flat.FlatID,
                        PhotoID = photo.PhotoID
                    });
                    Context.SaveChanges();
                }
            }

            return Redirect(Url.Action("Index", "Poster"));
        }
    }
}