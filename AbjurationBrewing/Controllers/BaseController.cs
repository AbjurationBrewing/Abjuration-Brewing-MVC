using System;
using System.Linq;
using System.Web.Mvc;
using Abjuration.Models;

namespace Abjuration.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext.Result is ViewResultBase)//Gets ViewResult and PartialViewResult
            {
                object viewModel = ((ViewResultBase)filterContext.Result).Model;

                if (viewModel != null && viewModel is BaseViewModel)
                {
                    var model = viewModel as BaseViewModel;

                    using (var db = new Db())
                    {
                        var untappds = db.Untappds.OrderBy(x => x.UntappdId).ToList();

                        if (untappds.Count > 0)
                        {
                            model.UpdateUntappd = (untappds[0].UpdateDate.AddMinutes(1) < DateTime.Now);
                            model.UntappdHtml = untappds[0].Html;
                        }
                        else
                        {
                            model.UpdateUntappd = true;
                        }
                    }
                }
            }

            base.OnActionExecuted(filterContext);
        }
    }
}