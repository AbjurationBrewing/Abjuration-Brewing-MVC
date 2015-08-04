using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Abjuration.Models;

namespace Abjuration.Controllers
{
    public class PartialViewController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "None")]
        public ActionResult BeerRecipe(int beerId, decimal version)
        {
            var model = new BeerRecipeViewModel();

            using (var db = new Db())
            {
                model.BeerVersion = db.BeerVersions
                    .Include(x => x.Beer)
                    .Include(x => x.Grains)
                    .Include(x => x.Hops)
                    .Include(x => x.Yeasts)
                    .Where(x => x.BeerId == beerId && x.VersionNum == version).FirstOrDefault();

                model.BeerVersions = db.BeerVersions.Where(x => x.BeerId == beerId).Select(x => x.VersionNum).ToList();
            }

            return PartialView(model);
        }
    }
}