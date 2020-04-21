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
            ViewData["posters"] = DataContext.Flats.Where(f => Ids.Contains(f.FlatID)).ToList();
            ViewData["photoPivots"] = DataContext.PhotoFlatPivots.ToList();
            ViewData["wishList"] = DataContext.WishFlatUserPivots
                                   .Where(wish => wish.UserName == User.Identity.Name)
                                   .ToList();

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