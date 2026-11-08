using Microsoft.Extensions.DependencyInjection;
using Microsoft.SemanticKernel;
using Restaurant.Agent.Plugins;
using Restaurant.Data;
using Restaurant.Data.Repository.Interface;
using Restaurant.Data.Repository.Service;
using Restaurant.Agent.Agents;

namespace RestaurantApplication
{
    internal class AddServiceLayer
    {
        private record OpenRouterConfig(string Model, string ApiKey);

        public IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            // Data Layer
            services.AddSingleton<RestaurantDatabase>();
            services.AddSingleton<IMenuRepository, MenuRepository>();

            // Plugins
            services.AddSingleton<MenuPlugin>();

            // Agents
            services.AddSingleton<IMenuAgent, MenuAgent>();
            services.AddSingleton<IReservationAgent, ReservationAgent>();
            services.AddSingleton<ICoordinatorAgent, CoordinatorAgent>();

            var kernel = CreateAndBuildKernel(services);
            services.AddSingleton(kernel);

            return services.BuildServiceProvider();

        }

        private Kernel CreateAndBuildKernel(ServiceCollection services)
        {
            // Build Service Provider
            var serviceProvider = services.BuildServiceProvider();

            // Create kernel
            var kernelBuilder = Kernel.CreateBuilder();

            return BuildKernel(kernelBuilder, serviceProvider);
        }

        private Kernel BuildKernel(IKernelBuilder kernelBuilder, IServiceProvider serviceProvider)
        {
            var settings = GetModelAndKey();
            kernelBuilder.AddOpenAIChatCompletion(
                modelId: settings.Model,
                apiKey: settings.ApiKey,
                endpoint: new Uri("https://openrouter.ai/api/v1"));

            var kernel = kernelBuilder.Build();

            kernel.Plugins.AddFromObject(serviceProvider.GetRequiredService<MenuPlugin>(), "Menu");
            return kernel;
        }

        private OpenRouterConfig GetModelAndKey()
        {
            var config = ConfigHelper.GetConfigurationBuilder();
            var apiKey = config["OpenRouter:ApiKey"]
                        ?? throw new InvalidOperationException("Set the OPENROUTER_API_KEY.");
            var model = config["OpenRouter:Model"] ?? "openai/gpt-4o-mini";
            return new(model, apiKey);
        }
    }
}
