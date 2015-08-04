using System.Web;
using System.Web.Optimization;

namespace Abjuration
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/layout.js.bundle").Include(
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

            bundles.Add(new ScriptBundle("~/home.js.bundle").Include(
                    "~/Scripts/Home.js"
                    ));

            bundles.Add(new ScriptBundle("~/beers.js.bundle").Include(
                "~/Scripts/Beers.js",
                "~/Scripts/DataTables/jquery.dataTables.js",
                "~/Scripts/DataTables/dataTables.responsive.js"
            ));

            bundles.Add(new StyleBundle("~/layout.css.bundle").Include(
                        "~/Content/bootstrap.css",
                        "~/Content/jquery.fancybox.css",
                        "~/Content/flickity.css",
                        "~/Content/animate.css",
                        "~/Content/styles.css",
                        "~/Content/queries.css",
                        "~/Content/fonts/fonts.css"
                        ));

            bundles.Add(new StyleBundle("~/beers.css.bundle").Include(
                        "~/Content/DataTables/css/jquery.dataTables.css"
                        ));
        }
    }
}