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
    public class HeaterTypeController : Controller
    {
        private RealtyContext DataContext = RealtyContext.Create();

        public ActionResult Index()
        {
            ViewData["heaterTypes"] = DataContext.HeaterTypes.ToList();

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
        public ActionResult Edit(int? HeaterTypeID)
        {
            if (HeaterTypeID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ViewData["currency"] = DataContext.HeaterTypes.Find(HeaterTypeID);

            return View();
        }

        [HttpPost, ActionName("Update")]
        [ValidateAntiForgeryToken]
        public RedirectResult Update(int? HeaterTypeID)
        {
            var Context = DataContext;
            Context.HeaterTypes.Find(HeaterTypeID)
                .Name = Request.Params["Name"];
            Context.SaveChanges();

            return Redirect(Url.Action("Index", "HeaterType"));
        }

        [HttpPost]
        public RedirectResult Delete(int? HeaterTypeID)
        {
            if (HeaterTypeID != null)
            {
                var Context = DataContext;
                Context.HeaterTypes.Remove(Context.HeaterTypes.Find(HeaterTypeID));
                Context.SaveChanges();
            }

            return Redirect(Url.Action("Index", "HeaterType"));
        }
    }
}