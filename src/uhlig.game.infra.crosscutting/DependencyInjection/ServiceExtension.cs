using Microsoft.Extensions.Configuration;

using uhlig.game.domain.Interfaces.Services;
using uhlig.game.services.Services;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IEmojiService, EmojiService>();

            return services;
        }
    }
}
