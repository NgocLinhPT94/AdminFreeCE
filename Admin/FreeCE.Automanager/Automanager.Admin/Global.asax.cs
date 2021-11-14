using Automanager.Admin.App_Start;
using Automanager.Libraries.RepoImpl;
using System;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Automanager.Admin
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //disable "X-AspNetMvc-Version" header name
            MvcHandler.DisableMvcResponseHeader = true;
            AntiForgeryConfig.SuppressXFrameOptionsHeader = true;

            //initialize engine context
            EngineContext.Initialize(true);

            AreaRegistration.RegisterAllAreas();

            ModelBinderConfig.Register(ModelBinders.Binders);

            // Can cai gi thi dang ky

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
