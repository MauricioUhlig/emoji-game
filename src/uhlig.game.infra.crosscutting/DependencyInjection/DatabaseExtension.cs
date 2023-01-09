using uhlig.game.infra.data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace uhlig.game.infra.crosscutting.DependencyInjection
{
    public static class DatabaseExtension
    {
        public static IServiceCollection AddDbConfiguration(this IServiceCollection service)
        {
            service.AddDbContext<EmojiGameContext>(options =>
                options.UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            );
            return service;
        }
    }
}
