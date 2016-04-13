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
            routes.MapRoute(
                 name: "Category",
                 url: "{alias}.html",
                 defaults: new { controller = "Post", action = "Category", id = UrlParameter.Optional },
                 namespaces: new string[] { "TEDU.Web.Controllers" }
             );
            //routes.MapRoute(
            //    name: "CVOnline",
            //    url: "cv-online.html",
            //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
            //    namespaces: new string[] { "TEDU.Web.Controllers" }

            //    );
            routes.MapRoute(
               name: "About",
               url: "gioi-thieu.html",
               defaults: new { controller = "About", action = "Index", id = UrlParameter.Optional },
               namespaces: new string[] { "TEDU.Web.Controllers" }
               );

            //routes.MapRoute(
            //    name: "Ebooks",
            //    url: "it-ebooks.html",
            //    defaults: new { controller = "Ebook", action = "Index", id = UrlParameter.Optional },
            //    namespaces: new string[] { "TEDU.Web.Controllers" }
            //   );

            //routes.MapRoute(
            //     name: "Posts",
            //     url: "{alias}-{id}.html",
            //     defaults: new { controller = "Post", action = "Detail", id = UrlParameter.Optional },
            //     namespaces: new string[] { "TEDU.Web.Controllers" }
            //    );


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "TEDU.Web.Controllers" }
            );
        }
    }
}