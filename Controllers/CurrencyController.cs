using Realty.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Realty.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CurrencyController : Controller
    {
        private RealtyContext DataContext = RealtyContext.Create();

        public ActionResult Index()
        {
            ViewData["currencies"] = DataContext.Currencies.ToList();

            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
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

        [HttpGet]
        public ActionResult Edit(int? CurrencyID)
        {
            if (CurrencyID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ViewData["currency"] = DataContext.Currencies.Find(CurrencyID);

            return View();
        }

        [HttpPost, ActionName("Update")]
        [ValidateAntiForgeryToken]
        public RedirectResult Update(int? CurrencyID)
        {
            var Context = DataContext;
            Context.Currencies.Find(CurrencyID)
                .Name = Request.Params["Name"];
            Context.SaveChanges();

            return Redirect(Url.Action("Index", "Currency"));
        }

        [HttpPost]
        public RedirectResult Delete(int? CurrencyID)
        {
            if (CurrencyID != null)
            {
                var Context = DataContext;
                Context.Currencies.Remove(Context.Currencies.Find(CurrencyID));
                Context.SaveChanges();
            }

            return Redirect(Url.Action("Index", "Currency"));
        }
    }
}