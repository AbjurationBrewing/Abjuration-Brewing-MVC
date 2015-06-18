using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Abjuration.Models;

namespace Abjuration.Controllers
{
    public class AjaxController : Controller
    {
        [ValidateInput(false)]
        public JsonResult UpdateUntappd(string html)
        {
            using (var db = new Db())
            {
                db.Untappds.RemoveRange(db.Untappds);

                var untappd = new Untappd();
                untappd.UpdateDate = DateTime.UtcNow;
                untappd.Html = html;

                db.Untappds.Add(untappd);
                db.SaveChanges();
            }

            return Json(new
            {
                success = true
            },
            JsonRequestBehavior.AllowGet);
        }
    }
}