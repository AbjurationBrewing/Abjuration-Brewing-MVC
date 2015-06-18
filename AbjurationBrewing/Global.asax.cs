using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Abjuration.Models;

namespace Abjuration
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception exception = Server.GetLastError().GetBaseException();
            HttpContext context = HttpContext.Current;
            string errorMessage = "";
            string url = "";

            for (Exception eCurrent = exception; eCurrent != null; eCurrent = eCurrent.InnerException)
            {
                errorMessage += "Message: " + eCurrent.Message + "\r\nSource: " + eCurrent.Source + "\r\nStack Trace: " + eCurrent.StackTrace;
                errorMessage += "\r\n";
            }

            if (context != null && context.Request != null && context.Request.Url != null)
            {
                url = context.Request.Url.ToString();
            }

            var error = new Error();
            error.ErrorDetail = errorMessage;
            error.ErrorIn = url;
            error.ErrorOn = DateTime.UtcNow;

            using (var db = new Db())
            {
                db.Errors.Add(error);
                db.SaveChanges();
            }
        }
    }
}