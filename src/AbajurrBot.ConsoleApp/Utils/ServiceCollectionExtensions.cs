using AbajurrBot.ConsoleApp.Handlers;
using AbajurrBot.Core.Services;
using AbajurrBot.Core.Services.Interfaces;
using DSharpPlus.Entities;
using Microsoft.Extensions.DependencyInjection;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace AbajurrBot.ConsoleApp.Utils
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureAbajurrServices(this IServiceCollection services)
        {
            return services
                .AddHttpClient()
                .AddDiscordWebhook()
                .AddAbajurrServices()
                .AddCommandHandlers()
                .AddYamlDeserializer();
        }

        private static IServiceCollection AddHttpClient(this IServiceCollection services)
        {
            return services.AddSingleton<HttpClient>();
        }

        private static IServiceCollection AddYamlDeserializer(this IServiceCollection services)
        {
            var deserializer = new DeserializerBuilder()
                .WithNamingConvention(CamelCaseNamingConvention.Instance)
                .Build();

            return services.AddSingleton(deserializer);
        }

        private static IServiceCollection AddCommandHandlers(this IServiceCollection services)
        {
            return services.AddTransient<ServerCommandsHandler>();
        }

        private static IServiceCollection AddAbajurrServices(this IServiceCollection services)
        {
            return services
                .AddTransient<IServerService, ServerService>();
        }

        private static IServiceCollection AddDiscordWebhook(this IServiceCollection services)
        {
            return services.AddTransient<DiscordWebhookBuilder>();
        }
    }
}
