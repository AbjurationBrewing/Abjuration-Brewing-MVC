using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq.Expressions;
using Abjuration.Models;

namespace Abjuration.Controllers
{
    public class BeersController : BaseController
    {
        public ActionResult Index()
        {
            var model = new BeersViewModel();

            return View(model);
        }

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "None")]
        public ActionResult Grid([ModelBinder(typeof(DataTableModelBinder))]DataTableParameterModel model)
        {
            IQueryable<Beer> query;
            List<List<string>> result = new List<List<string>>();
            string orderBy = "";
            Expression<Func<Beer, bool>> whereFunc;

            foreach (var col in model.Order)
            {
                if (orderBy != "")
                {
                    orderBy += ", ";
                }

                orderBy += (col.Column == 0 ? "Abbreviation " :
                            col.Column == 1 ? "Name " :
                       //     col.Column == 2 ? "Name " :
                            "");

                orderBy += col.Dir;
            }


            whereFunc = (c => (
                                    model.Search.Value == null ||
                                    model.Search.Value == "" ||
                                    (
                                        c.Abbreviation.ToUpper().Trim().Contains(model.Search.Value.ToUpper().Trim()) ||
                                        c.Name.ToUpper().Trim().Contains(model.Search.Value.ToUpper().Trim()) ||
                                        c.BeerVersions.Any(x => x.VersionNum.ToString().ToUpper().Trim().Contains(model.Search.Value.ToUpper().Trim()))
                                    )
                                ));

            using (var db = new Db())
            {
                var beers = db.Beers;

                query = beers
                        .Where(whereFunc)
                        .OrderBy(orderBy)
                        .Skip(model.Start)
                        .Take(model.Length);

                foreach (var beer in query)
                {
                    var version = beer.BeerVersions.OrderByDescending(x => x.VersionNum).FirstOrDefault();
                    string versionStr = version == null ? "1.0" : version.VersionNum.ToString();

                    if (versionStr.EndsWith(".00"))
                    {
                        versionStr = versionStr.Replace(".00", ".0");
                    }
                    else if (versionStr.EndsWith("0"))
                    {
                        versionStr = versionStr.Substring(0, versionStr.Length - 1);
                    }

                    result.Add(
                        new List<string>()
                        {
                            beer.Abbreviation,
                            beer.Name,
                            versionStr,
                            beer.BeerId.ToString()
                        });
                }

                return Json(new
                {
                    draw = model.Draw,
                    recordsTotal = beers.Count(),
                    recordsFiltered = beers.Where(whereFunc).Count(),
                    data = result
                },
                JsonRequestBehavior.AllowGet);
            }
        }
    }
}