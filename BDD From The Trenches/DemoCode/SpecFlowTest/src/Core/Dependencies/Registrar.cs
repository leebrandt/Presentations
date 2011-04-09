using StructureMap;

namespace SFT.Core.Dependencies
{
    public class DependencyRegistrar
    {
        public static void RegisterDependencies()
        {
            ObjectFactory.Initialize(r =>
            {
                r.UseDefaultStructureMapConfigFile = false;
                r.AddRegistry<ServiceRegistry>();
                r.AddRegistry<RepositoryRegistry>();
            });
        }
    }
}