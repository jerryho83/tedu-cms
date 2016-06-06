using System.Web.Http;
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

            routes.MapRoute(
                 name: "Login",
                 url: "dang-nhap.html",
                 defaults: new { controller = "Account", action = "Login", id = UrlParameter.Optional },
                 namespaces: new string[] { "TEDU.Web.Controllers" }
             );
            routes.MapRoute(
                 name: "Register",
                 url: "dang-ky.html",
                 defaults: new { controller = "Account", action = "Register", id = UrlParameter.Optional },
                 namespaces: new string[] { "TEDU.Web.Controllers" }
             );
            routes.MapRoute(
               name: "CVOnline",
               url: "tim-kiem.html",
               defaults: new { controller = "Post", action = "Search", id = UrlParameter.Optional },
               namespaces: new string[] { "TEDU.Web.Controllers" }
             );
            routes.MapRoute(
               name: "About",
               url: "gioi-thieu.html",
               defaults: new { controller = "About", action = "Index", id = UrlParameter.Optional },
               namespaces: new string[] { "TEDU.Web.Controllers" }
            );

            routes.MapRoute(
                name: "Ebooks",
                url: "it-ebooks.html",
                defaults: new { controller = "Ebook", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "TEDU.Web.Controllers" }
            );

            routes.MapRoute(
                name: "Tags",
                url: "tag/{id}.html",
                defaults: new { controller = "Post", action = "PostByTag", id = UrlParameter.Optional },
                namespaces: new string[] { "TEDU.Web.Controllers" }
            );

            routes.MapRoute(
                 name: "Category",
                 url: "{alias}.html",
                 defaults: new { controller = "Post", action = "Category", id = UrlParameter.Optional },
                 namespaces: new string[] { "TEDU.Web.Controllers" }
             );
            routes.MapRoute(
                  name: "Posts",
                  url: "{categoryAlias}/{alias}-{id}.html",
                  defaults: new { controller = "Post", action = "Detail", id = UrlParameter.Optional },
                  namespaces: new string[] { "TEDU.Web.Controllers" }
             );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "TEDU.Web.Controllers" }
            );
        }
    }
}