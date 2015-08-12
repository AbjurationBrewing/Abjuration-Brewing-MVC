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
                    .Include("Beer.BeerIterations")
                    .Include(x => x.GrainsToBeers)
                    .Include("GrainsToBeers.Grain")
                    .Include(x => x.HopsToBeers)
                    .Include("HopsToBeers.Hop")
                    .Include(x => x.Yeasts)
                    .Include(x => x.SpiceOthers)
                    .Where(x => x.BeerId == beerId && x.VersionNum == version).FirstOrDefault();

                model.BeerVersions = db.BeerVersions.Where(x => x.BeerId == beerId).Select(x => x.VersionNum).ToList();

                model.FormattedVersion = version.ToString();
            }

            return PartialView(model);
        }
    }
}