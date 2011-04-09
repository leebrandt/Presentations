using SFT.Core.Services.Authentication;
using SFT.Core.Services.Configuration;
using StructureMap.Configuration.DSL;

namespace SFT.Core.Dependencies
{
    public class ServiceRegistry : Registry
    {
        public ServiceRegistry()
        {
            For<AuthenticationService>().Use<WebAuthenticationService>();
            For<ConfigurationService>().Use<WebConfigurationService>();
        }
    }
}