using System.Web;
using System.Web.Optimization;

namespace QueAdsMvc4
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/angularjs").Include(
                        "~/Scripts/angular/angular.js",
                        "~/Scripts/angular/angular-route.js",
                        "~/Scripts/angular/angular-animate.js",
                        "~/Scripts/angular/angular-sanitize.js",
                        "~/Scripts/angular/angular-cookies.js",
                        "~/Scripts/angular/angular-file-upload-shim.min.js",
                        "~/Scripts/angular/angular-file-upload.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrapjs").Include(
                "~/Scripts/bootstrap/js/bootstrap.js",
                "~/Scripts/bootstrap/js/ui-bootstrap-tpls-0.14.3.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css"));
            bundles.Add(new StyleBundle("~/bundles/bootstrapcss").Include(
                "~/Content/bootstrap/css/bootstrap.css"));
        }
    }
}