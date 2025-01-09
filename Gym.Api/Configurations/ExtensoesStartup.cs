namespace Gym.Api.Configurations
{
    public static class ExtensoesStartup
    {
        public static IHostBuilder ConfigurarPrograma(this IHostBuilder hostBuilder) {
            hostBuilder.ConfigureAppConfiguration(delegate (HostBuilderContext hostingContext, IConfigurationBuilder config) {
                IHostEnvironment env = hostingContext.HostingEnvironment;

                config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

                config.AddEnvironmentVariables();
            });

            return hostBuilder;
        }
    }

}

