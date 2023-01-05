using uhlig.game.domain.Interfaces.Services;
using uhlig.game.services.Services;
using Microsoft.Extensions.DependencyInjection;

namespace uhlig.game.infra.crosscutting.DependencyInjection
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IEmojiService, EmojiService>();
            services.AddScoped<IGameService, GameService>();

            return services;
        }
    }
}
