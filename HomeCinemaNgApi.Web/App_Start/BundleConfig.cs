using System.Web;
using System.Web.Optimization;

namespace HomeCinemaNgApi.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/vendors").Include(
                    "~/Scripts/Vendors/jquery.js",
                    "~/Scripts/Vendors/bootstrap.js",
                    "~/Scripts/Vendors/toastr.js",
                    "~/Scripts/Vendors/jquery.raty.js",
                    "~/Scripts/Vendors/respond.src.js",
                    "~/Scripts/Vendors/angular.js",
                    "~/Scripts/Vendors/angular-route.js",
                    "~/Scripts/Vendors/angular-cookies.js",
                    "~/Scripts/Vendors/angular-validator.js",
                    "~/Scripts/Vendors/angular-base64.js",
                    "~/Scripts/Vendors/angular-file-upload.js",
                    "~/Scripts/Vendors/angucomplete-alt.min.js",
                    "~/Scripts/Vendors/ui-bootstrap-tpls-0.13.1.js",
                    "~/Scripts/Vendors/underscore.js",
                    "~/Scripts/Vendors/raphael.js",
                    "~/Scripts/Vendors/morris.js",
                    "~/Scripts/Vendors/jquery.fancybox.js",
                    "~/Scripts/Vendors/jquery.fancybox-media.js",
                    "~/Scripts/Vendors/loading-bar.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/spa").Include(
                    "~/Scripts/spa/app.js"
                ));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js",
            //          "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                    "~/content/css/site.css",
                    "~/content/css/bootstrap.css",
                    "~/content/css/bootstrap-theme.css",
                    "~/content/css/font-awesome.css",
                    "~/content/css/morris.css",
                    "~/content/css/toastr.css",
                    "~/content/css/jquery.fancybox.css",
                    "~/content/css/loading-bar.css"
                ));

            BundleTable.EnableOptimizations = false;
        }
    }
}
