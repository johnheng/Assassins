using System.Web;
using System.Web.Optimization;

namespace Assassins
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/assassins").Include(
                      "~/Scripts/assassins.js",
                      "~/Content/minimal/js/main.js"));

            bundles.Add(new ScriptBundle("~/bundles/timeago").Include(
                      "~/Scripts/jquery.timeago.js"));

            bundles.Add(new ScriptBundle("~/bundles/knob").Include(
                      "~/Scripts/jquery.knob.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/minimaljs").Include(
                      "~/Content/minimal/js/jquery.min.js",
                      "~/Content/minimal/js/bootstrap.js",
                      "~/Content/minimal/js/Chart.js",
                      "~/Content/minimal/js/smoothscroll.js"));

            bundles.Add(new StyleBundle("~/bundles/minimalcss").Include(
                      "~/Content/minimal/css/main.css",
                      "~/Content/bootstrap.css",
                      "~/Content/minimal/css/font-awesome.min.css"));
        }
    }
}
