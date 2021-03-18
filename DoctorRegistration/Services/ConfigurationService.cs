using Microsoft.Extensions.Configuration;
using System.Data.Common;
using System.Data.SqlClient;

namespace DoctorRegistration.Services
{
    public static class ConfigurationService
    {
        public static IConfiguration Configuration { get; private set; }

        public static void Init()
        {
            DbProviderFactories.RegisterFactory("DoctorRegistrationProvider", SqlClientFactory.Instance);

            if (Configuration == null)
            {
                var configurationBuilder = new ConfigurationBuilder();
                Configuration = configurationBuilder.AddJsonFile("appSettings.json").Build();
            }
        }
    }
}
