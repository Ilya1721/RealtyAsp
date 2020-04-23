using Realty.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Realty.Models;
using Microsoft.AspNet.Identity;

namespace Realty.Controllers
{
    [Authorize]
    public class WishListController : Controller
    {
        private RealtyContext DataContext = RealtyContext.Create();

        public ActionResult Index()
        {
            List<WishFlatUserPivot> wishPivots = DataContext.WishFlatUserPivots.
                                                 Where(p => p.UserName == User.Identity.Name)
                                                 .ToList();
            var Ids = wishPivots.Select(p => p.FlatID);
            List<PhotoFlatPivot> pivots = new List<PhotoFlatPivot>();
            List<Photo> photos = new List<Photo>();

            List<Flat> flats = DataContext.Flats.Where(f => Ids.Contains(f.FlatID)).ToList();

            foreach (var flat in flats)
            {
                pivots = DataContext.PhotoFlatPivots.Where(p => p.FlatID == flat.FlatID).ToList();
                var photoIds = pivots.Select(piv => piv.PhotoID);
                photos.Add(DataContext.Photos.Where(p => photoIds.Contains(p.PhotoID)).ToList().First());
            }
            ViewData["posters"] = flats;
            ViewData["wishList"] = DataContext.WishFlatUserPivots
                                   .Where(wish => wish.UserName == User.Identity.Name)
                                   .ToList();
            ViewData["photos"] = photos;

            return View();
        }


        public ActionResult AddToList(int FlatID)
        {
            WishFlatUserPivot flatPivot = DataContext.WishFlatUserPivots.FirstOrDefault(p => p.FlatID == FlatID);
            if(flatPivot != null)
            {
                DataContext.WishFlatUserPivots.Remove(flatPivot);
            }
            else
            {
                DataContext.WishFlatUserPivots.Add(new WishFlatUserPivot
                {
                    UserName = User.Identity.Name,
                    FlatID = FlatID
                });
            }
            DataContext.SaveChanges();

            return Redirect(Url.Action("Index", "WishList"));
        }
    }
}