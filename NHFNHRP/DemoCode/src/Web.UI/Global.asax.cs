using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Core.Data;
using Core.Data.NHibernate;
using NHibernate;
using StructureMap;
using StructureMap.Configuration.DSL;

namespace Web.UI
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        public static ISession CurrentSession
        {
            get { return (ISession)HttpContext.Current.Items["current.session"]; }
            set { HttpContext.Current.Items["current.session"] = value; }
        }

        public MvcApplication()
        {
            BeginRequest += delegate
                {
                    CurrentSession = ObjectFactory.GetInstance<ISessionFactory>().OpenSession();
                    ObjectFactory
                        .Configure(x=>x.For<ISession>().Use(CurrentSession));
                };
            EndRequest += delegate
                {
                    if (CurrentSession != null)
                        CurrentSession.Dispose();
                };
        }

        protected void Application_EndRequest()
        {
            CurrentSession.Dispose();
        }

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
            BootStrapStructureMap();
            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }

        public static void BootStrapStructureMap()
        {
            ObjectFactory.Initialize(x => x.Scan(scan =>
            {
                scan.TheCallingAssembly();
                scan.WithDefaultConventions();
                scan.LookForRegistries();
            }));

            DependencyResolver.SetResolver(new StructureMapDependencyResolver(ObjectFactory.Container));
            ControllerBuilder.Current.SetControllerFactory(new StructureMapControllerFactory());
        }

        public class StructureMapDependencyResolver : IDependencyResolver
        {
            private readonly IContainer _container;

            public StructureMapDependencyResolver(IContainer container)
            {
                _container = container;
            }

            public object GetService(Type serviceType)
            {
                if (serviceType == null) return null;
                try
                {
                    return serviceType.IsAbstract || serviceType.IsInterface
                             ? _container.TryGetInstance(serviceType)
                             : _container.GetInstance(serviceType);
                }
                catch
                {

                    return null;
                }
            }

            public IEnumerable<object> GetServices(Type serviceType)
            {
                return _container.GetAllInstances(serviceType).Cast<object>();
            }
        }

        public class StructureMapControllerFactory : DefaultControllerFactory
        {
            protected override IController GetControllerInstance(RequestContext requestContext, System.Type controllerType)
            {
                IController result = null;
                if (controllerType == null) return base.GetControllerInstance(requestContext, controllerType);
                result = ObjectFactory.GetInstance(controllerType) as Controller;
                return result;
            }
        }

        public class RepositoryRegistry : Registry
        {
            public RepositoryRegistry()
            {
                var pluginTypes = typeof(Repository).Assembly.GetTypes().Where(t => !t.Name.StartsWith("NHibernate") && t.Name.EndsWith("Repository"));
                foreach (var pluginType in pluginTypes)
                {
                    var concreteType =
                        typeof(NHibernateRepository).Assembly.GetTypes()
                            .FirstOrDefault(t =>
                                t.Name.StartsWith("NHibernate") &&
                                t.Name.EndsWith("Repository") &&
                                pluginType.IsAssignableFrom(t));

                    if (concreteType != null)
                        For(pluginType).Use(concreteType);
                }

                For<ISessionFactory>().UseSpecial(
                    x => x.ConstructedBy(
                        () => ObjectFactory.GetInstance<NHibernateConfiguration>()
                                  .CreateSessionFactory()))
                    .Singleton();
            }
        }
    }
}