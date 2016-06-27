using System.Web.Mvc;
using System.Web.Routing;

namespace TEDU.Web.App_Start
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // BotDetect requests must not be routed
            routes.IgnoreRoute("{*botdetect}", new { botdetect = @"(.*)BotDetectCaptcha\.ashx" });

            routes.MapRoute("Login", "dang-nhap.html",
                new { controller = "Account", action = "Login", id = UrlParameter.Optional },
                new[] { "TEDU.Web.Controllers" }
                );
            routes.MapRoute("Register", "dang-ky.html",
                new { controller = "Account", action = "Register", id = UrlParameter.Optional },
                new[] { "TEDU.Web.Controllers" }
                );
            routes.MapRoute("Course", "khoa-hoc.html",
                new { controller = "Course", action = "Index", id = UrlParameter.Optional }, new[] { "TEDU.Web.Controllers" }
                );
            routes.MapRoute("Course Detail", "khoa-hoc/{alias}-{id}.html",
               new { controller = "Course", action = "Index", id = UrlParameter.Optional }, new[] { "TEDU.Web.Controllers" }
               );
            routes.MapRoute("About", "gioi-thieu.html",
                new { controller = "About", action = "Index", id = UrlParameter.Optional }, new[] { "TEDU.Web.Controllers" }
                );

            routes.MapRoute("Ebooks", "it-ebooks.html",
                new { controller = "Ebook", action = "Index", id = UrlParameter.Optional }, new[] { "TEDU.Web.Controllers" }
                );

            routes.MapRoute("Tags", "tag/{id}.html",
                new { controller = "Post", action = "PostByTag", id = UrlParameter.Optional },
                new[] { "TEDU.Web.Controllers" }
                );

            routes.MapRoute("Category", "{alias}.html",
                new { controller = "Post", action = "Category", id = UrlParameter.Optional },
                new[] { "TEDU.Web.Controllers" }
                );
            routes.MapRoute("Posts", "{categoryAlias}/{alias}-{id}.html",
                new { controller = "Post", action = "Detail", id = UrlParameter.Optional }, new[] { "TEDU.Web.Controllers" }
                );

            routes.MapRoute("Default", "{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional }, new[] { "TEDU.Web.Controllers" }
                );
        }
    }
}