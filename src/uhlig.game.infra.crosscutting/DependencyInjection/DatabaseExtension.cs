using uhlig.game.infra.data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace uhlig.game.infra.crosscutting.DependencyInjection
{
    public static class DatabaseExtension
    {
        public static IServiceCollection AddDbConfiguration(this IServiceCollection service, bool test = false)
        {
            service.AddDbContext<EmojiGameContext>(options =>
                options.UseInMemoryDatabase(databaseName: test ? Guid.NewGuid().ToString() : "db-EmojiGame-dev")
            );
            return service;
        }
    }
}
