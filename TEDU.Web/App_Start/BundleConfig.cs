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
                        "~/Scripts/bootbox.min.js",
                        "~/Scripts/ckeditor/ckeditor.js",
                        "~/Scripts/ckfinder/ckfinder.js",
                        "~/scripts/main.js",
                        "~/Scripts/angular.js",
                        "~/Scripts/angular-route.js",
                        "~/Scripts/angular-ui-router.js",
                        "~/Scripts/angular-cookies.js",
                        "~/Scripts/angular-resource.js",
                        "~/Scripts/angular-validator.min.js",
                        "~/Scripts/ngBootbox.min.js",
                        "~/Scripts/angular-ui/ui-bootstrap-tpls.js",
                        "~/Scripts/loading-bar.js",
                        "~/Scripts/jquery.fancybox.js",
                        "~/Scripts/jquery.fancybox-media.js",
                        "~/Scripts/ng-ckeditor.min.js",
                        "~/Scripts/tree-grid-directive.js",
                        "~/Scripts/bower_components/ng-flow/dist/ng-flow.min.js"
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
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/scripts/bootstrap.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/admin/css/bootstrap/bootstrap.min.css",
                      "~/Content/admin/css/AdminLTE.min.css",
                      "~/Content/admin/css/skins/_all-skins.min.css",
                      "~/content/toastr.css",
                      "~/content/jquery.fancybox.css",
                      "~/content/loading-bar.css",
                       "~/content/treeGrid.css"
                       ));

            BundleTable.EnableOptimizations = false;
            //BundleTable.EnableOptimizations = true;
        }
    }
}