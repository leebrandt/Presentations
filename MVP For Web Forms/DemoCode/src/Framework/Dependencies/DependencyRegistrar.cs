using StructureMap;

namespace BddDemo.Framework.Dependencies
{
    public class DependencyRegistrar
    {
        private static bool _isInitialized;
        public static void RegisterDependencies()
        {
            if (_isInitialized) return;
            ObjectFactory.Initialize(x =>
                                         {
                                             x.UseDefaultStructureMapConfigFile = false;
                                             x.AddRegistry<RepositoryRegistry>();
                                         });
            _isInitialized = true;
        }
    }
}