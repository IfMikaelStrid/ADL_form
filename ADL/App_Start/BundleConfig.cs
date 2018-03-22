using System.Web;
using System.Web.Optimization;

namespace ADL
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/colorPicker").Include(
                        "~/Scripts/bootstrap-colorpicker.min.js",
                        "~/Scripts/bootstrap-colorpicker.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/CSS/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/CSS/theme").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/CSS/CustomCss/css").Include(
                      "~/Content/CustomCss/Form.css"));

            bundles.Add(new StyleBundle("~/CSS/bootstrap-colorpicker/").Include(
                      "~/Content/bootstrap-colorpicker/css/*.css"
                      ));
        }
    }
}
