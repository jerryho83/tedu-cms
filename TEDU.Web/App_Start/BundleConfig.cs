using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace TEDU.Web.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
               "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryplugins").Include(
               "~/scripts/jquery.slimscroll.min.js",
               "~/scripts/fastclick.js",
               "~/scripts/main.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/angularjs").Include(
                        "~/Scripts/angular.js",
                        "~/Scripts/angular-route.js",
                        "~/Scripts/angular-resource.js",
                        "~/Scripts/app/app.js",
                        "~/Scripts/app/home/homeCtrl.js",
                        "~/Scripts/app/home/categoryCtrl.js",
                        "~/Scripts/app/home/postCtrl.js"
                        ));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/scripts/bootstrap.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Contents/admin/css/bootstrap/bootstrap.min.css",
                      "~/Contents/admin/css/AdminLTE.min.css",
                      "~/Contents/admin/css/skins/_all-skins.min.css"));

            BundleTable.EnableOptimizations = false;
            //BundleTable.EnableOptimizations = true;
        }
    }
}