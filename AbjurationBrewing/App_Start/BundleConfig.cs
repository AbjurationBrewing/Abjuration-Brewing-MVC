using System.Web;
using System.Web.Optimization;

namespace Abjuration
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/js.bundle").Include(
                        "~/Scripts/min/toucheffects-min.js",
                        "~/Scripts/flickity.pkgd.js",
                        "~/Scripts/jquery.fancybox.pack.js",
                        "~/Scripts/retina.js",
                        "~/Scripts/waypoints.js",
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/scripts.js",
                        "~/Scripts/jquery.cookie.js",
                        "~/Scripts/instafeed.js",
                        "~/Scripts/global.js"
                        ));

            bundles.Add(new StyleBundle("~/css.bundle").Include(
                        "~/Content/bootstrap.css",
                        "~/Content/jquery.fancybox.css",
                        "~/Content/flickity.css",
                        "~/Content/animate.css",
                        "~/Content/styles.css",
                        "~/Content/queries.css",
                        "~/Content/fonts/fonts.css"
                        ));
        }
    }
}