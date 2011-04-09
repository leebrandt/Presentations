using System.Configuration;

namespace SFT.Core.Services.Configuration
{
    public class WebConfigurationService : ConfigurationService
    {
        public string ConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings["default"].ConnectionString; }
        }
    }
}