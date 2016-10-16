using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.WebPages;

namespace ClientFeatures {

    public class MvcApplication : System.Web.HttpApplication {
        protected void Application_Start() {

            DisplayModeProvider.Instance.Modes.Insert(0,
                new DefaultDisplayMode("OperaTablet") {
                    ContextCondition = (context => context.Request.UserAgent.IndexOf
                       ("Opera Tablet", StringComparison.OrdinalIgnoreCase) >= 0)
                });

            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
