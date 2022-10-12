using RedRainLearningPortal.Domain.Interfaces;

namespace RedRainLearningPortal.Api.Configuration
{
    public class ApiConfig : IConfig
    {
        public string GetConnectionString(string connectionStringName) => GetIConfigurationRoot()[Domain.Models.Constants.ConfigKey.RedRainLearningPortalDbConfigSection];

        public static IConfigurationRoot GetIConfigurationRoot() =>
            new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
    }
}
