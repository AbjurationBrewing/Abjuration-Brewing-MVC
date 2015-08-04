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

                }
            }

            base.OnActionExecuted(filterContext);
        }
    }
}