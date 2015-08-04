﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Abjuration.Models;

namespace Abjuration.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            var model = new HomeViewModel();

            using (var db = new Db())
            {
                var untappds = db.Untappds.OrderBy(x => x.UntappdId).ToList();

                if (untappds.Count > 0)
                {
                    model.UpdateUntappd = (untappds[0].UpdateDate.AddMinutes(1) < DateTime.UtcNow);
                    model.UntappdHtml = untappds[0].Html;
                }
                else
                {
                    model.UpdateUntappd = true;
                }
            }

            return View(model);
        }
    }
}