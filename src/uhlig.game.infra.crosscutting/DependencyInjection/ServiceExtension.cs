using uhlig.game.domain.Interfaces.Services;
using uhlig.game.services.Services;
using Microsoft.Extensions.DependencyInjection;
using uhlig.game.domain.Notifications;
using uhlig.game.domain.Notifications.StaticMessages;

namespace uhlig.game.infra.crosscutting.DependencyInjection
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IEmojiService, EmojiService>();
            services.AddScoped<IGameService, GameService>();
            services.AddScoped<IRoundService, RoundService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<NotificationsOptions>(x => new NotificationsOptions("pt-br"));
            services.AddScoped<DomainNotification>();

            return services;
        }
    }
}
