using System.Diagnostics;
using System.Web.Mvc;
using System.Web.Routing;
using SFT.Core.Dependencies;
using StructureMap;

namespace SFT.Web.UI
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            DependencyRegistrar.RegisterDependencies();          
            ControllerBuilder.Current.SetControllerFactory(new StructureMapControllerFactory());
            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }
    }

    public class StructureMapControllerFactory : DefaultControllerFactory
    {
        protected override IController GetControllerInstance(RequestContext requestContext, System.Type controllerType)
        {
            IController result = null;
            try
            {
                if (controllerType == null) return base.GetControllerInstance(requestContext, controllerType);
                result = ObjectFactory.GetInstance(controllerType) as Controller;

            }
            catch (StructureMapException)
            {
                Debug.WriteLine(ObjectFactory.WhatDoIHave());
                throw;
            }

            return result;
        }
    }
}