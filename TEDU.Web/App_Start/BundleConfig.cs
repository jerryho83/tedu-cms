using System.Web.Optimization;

namespace TEDU.Web.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new ScriptBundle("~/client/bundles/js").Include(
                        "~/Content/client/js/jquery-1.10.2.min.js",
                        "~/Content/client/js/html5.js",
                        "~/Content/client/js/bootstrap.min.js",
                        "~/Content/client/js/jquery.flexslider.js",
                        "~/Content/client/js/jquery.flexslider.init.js",
                        "~/Content/client/js/jquery.bxslider.js",
                        "~/Content/client/js/jquery.bxslider.init.js",
                        "~/Content/client/js/jquery.rating.js",
                        "~/Content/client/js/jquery.idTabs.min.js",
                        "~/Content/client/js/jquery.simplyscroll.js",
                        "~/Content/client/js/fluidvids.min.js",
                        "~/Content/client/js/jPages.js",
                        "~/Content/client/js/jquery.sidr.min.js",
                        "~/Content/client/js/jquery.touchSwipe.min.js",
                        "~/Content/client/js/custom.js"
                        ));

            bundles.Add(new StyleBundle("~/client/bundles/css")
                .Include("~/Content/client/css/swipemenu.css", new CssRewriteUrlTransform())
                .Include("~/Content/client/css/flexslider.css", new CssRewriteUrlTransform())
                .Include("~/Content/client/css/bootstrap.css", new CssRewriteUrlTransform())
                .Include("~/Content/client/css/bootstrap-responsive.css", new CssRewriteUrlTransform())
                .Include("~/Content/client/css/jquery.simplyscroll.css", new CssRewriteUrlTransform())
                .Include("~/Content/client/css/jPages.css", new CssRewriteUrlTransform())
                .Include("~/Content/client/css/jquery.rating.css", new CssRewriteUrlTransform())
                .Include("~/Content/client/css/ie.css", new CssRewriteUrlTransform())
                .Include("~/Content/client/css/font-awesome.min.css", new CssRewriteUrlTransform())
                .Include("~/Content/client/css/custom.css", new CssRewriteUrlTransform())
                .Include("~/Content/client/css/style.css", new CssRewriteUrlTransform())
                );

            BundleTable.EnableOptimizations = true;
            //BundleTable.EnableOptimizations = true;
        }
    }
}