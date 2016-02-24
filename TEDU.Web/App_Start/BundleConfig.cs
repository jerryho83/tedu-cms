using System.Web.Optimization;

namespace TEDU.Web.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
               "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/vendors").Include(
                        "~/scripts/jquery.slimscroll.min.js",
                        "~/scripts/fastclick.js",
                        "~/Scripts/toastr.js",
                        "~/scripts/main.js",
                        "~/Scripts/angular.js",
                        "~/Scripts/angular-route.js",
                        "~/Scripts/angular-resource.js"
                        ));
            bundles.Add(new ScriptBundle("~/bundles/spa").Include(
                       "~/Scripts/app/modules/common.core.js",
                       "~/Scripts/app/app.js",
                       "~/Scripts/app/home/homeCtrl.js",
                       "~/Scripts/app/categories/categoryCtrl.js",
                       "~/Scripts/app/posts/postCtrl.js"
                       ));
            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/scripts/bootstrap.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/admin/css/bootstrap/bootstrap.min.css",
                      "~/Content/admin/css/AdminLTE.min.css",
                      "~/Content/admin/css/skins/_all-skins.min.css",
                       "~/content/admin/toastr.css"));

            BundleTable.EnableOptimizations = false;
            //BundleTable.EnableOptimizations = true;
        }
    }
}