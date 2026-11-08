using Microsoft.Extensions.Configuration;

namespace RestaurantApplication
{
    internal static class ConfigHelper
    {
        public static IConfigurationRoot GetConfigurationBuilder()
        {
            var config = new ConfigurationBuilder()
                            .AddUserSecrets<Program>()
                            .Build();
            return config;
        }

    }
}
