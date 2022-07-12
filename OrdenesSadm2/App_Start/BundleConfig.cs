using System.Web;
using System.Web.Optimization;

namespace OrdenesSadm2
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery1").Include(
                     "~/Scripts/jquery-3.4.1.min.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //          "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/libs").Include(
            "~/Content/LIBS/fontawesome.js",
            "~/Content/LIBS/jquery-1.10.2.min.js",
            "~/Content/LIBS/jquery-1.12.4.js",
            "~/Content/LIBS/select2.min.js",
            "~/Content/LIBS/solid.js"));

            bundles.Add(new StyleBundle("~/Content/libsSelect").Include(
           "~/Content/LIBS/bootstrap.min.css",
           "~/Content/LIBS/jquery-1.css",
           "~/Content/LIBS/select2.min.css",
           "~/Content/CSS/datatables.css",
           "~/Content/CSS/stylelogin.css",
           "~/Content/CSS/fontawesome.css"));

        }
    }
}
