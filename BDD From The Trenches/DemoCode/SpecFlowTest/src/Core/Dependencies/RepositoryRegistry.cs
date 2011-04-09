using System.Linq;
using NHibernate;
using SFT.Core.Data;
using SFT.Core.Data.NHibernate;
using StructureMap;
using StructureMap.Configuration.DSL;

namespace SFT.Core.Dependencies
{
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

            //For<ISessionFactory>().Singleton()
            //    .Use(ObjectFactory
            //        .GetInstance<AutoMappedConfiguration>()
            //        .CreateSessionFactory());
            For<ISessionFactory>().Singleton().TheDefault.Is.ConstructedBy(() => ObjectFactory.GetInstance<AutoMappedConfiguration>().CreateSessionFactory());
        }
    }
}