using uhlig.game.infra.data.Repositories;
using uhlig.game.domain.Interfaces.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace uhlig.game.infra.crosscutting.DependencyInjection
{
    public static class RepositoryExtension
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            //services.AddScoped<IBuyRepository, BuyRepository>();
            return services;
        }
    }
}
