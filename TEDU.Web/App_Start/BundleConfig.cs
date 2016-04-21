using System.Web.Optimization;

namespace TEDU.Web.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
               "~/Scripts/plugins/jquery/dist/jquery.js"));

            bundles.Add(new ScriptBundle("~/bundles/plugins").Include(
                        "~/Scripts/plugins/toastr/toastr.js",
                        "~/Scripts/plugins/bootbox/bootbox.min.js",
                        "~/Scripts/plugins/ckeditor/ckeditor.js",
                        "~/Scripts/plugins/ckfinder/ckfinder.js",
                        "~/scripts/main.js",
                        "~/Scripts/plugins/angular/angular.js",
                        "~/Scripts/plugins/angular-route/angular-route.js",
                        "~/Scripts/plugins/angular-ui-router/release/angular-ui-router.js",
                        "~/Scripts/plugins/angular-cookies/angular-cookies.js",
                        "~/Scripts/plugins/angular-resource/angular-resource.js",
                        "~/Scripts/plugins/angular-validator/dist/angular-validator.js",
                        "~/Scripts/plugins/ngBootbox/ngBootbox.js",
                        "~/Scripts/plugins/angular-loading-bar/build/loading-bar.js",
                        "~/Scripts/plugins/ngckeditor/ng-ckeditor.js",
                        "~/Scripts/plugins/jquery-treegrid/js/jquery.treegrid.js"
                        ));
            bundles.Add(new ScriptBundle("~/bundles/spa").Include(
                       "~/app/modules/common.core.js",
                       "~/app/modules/common.ui.js",
                       "~/app/app.js",
                       "~/app/services/notificationService.js",
                       "~/app/services/modalService.js",
                       "~/app/services/apiService.js",
                       "~/app/services/commonService.js",
                       "~/app/layout/customPager.directive.js",
                       "~/app/layout/treegrid.directive.js",
                       "~/app/filters/boolStatus.filter.js",
                       "~/app/home/homeCtrl.js",
                       "~/app/categories/categoryCtrl.js",
                       "~/app/categories/addCategoryCtrl.js",
                       "~/app/categories/editCategoryCtrl.js",
                       "~/app/posts/postCtrl.js",
                       "~/app/posts/addPostCtrl.js",
                       "~/app/posts/editPostCtrl.js"
                       ));
            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/plugins/modernizr/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/scripts/plugins/bootstrap/dist/js/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Scripts/plugins/bootstrap/dist/css/bootstrap.css",
                      "~/Content/admin/css/AdminLTE.min.css",
                      "~/Content/admin/css/skins/_all-skins.min.css",
                      "~/Scripts/plugins/toastr/toastr.css",
                      "~/Scripts/plugins/angular-loading-bar/build/loading-bar.css",
                      "~/Scripts/plugins/jquery-treegrid/css/jquery.treegrid.css"
                       ));

            BundleTable.EnableOptimizations = false;
            //BundleTable.EnableOptimizations = true;
        }
    }
}