
using Microsoft.Extensions.DependencyInjection;
using uhlig.game.infra.crosscutting.DependencyInjection;

namespace uhlig.game.test
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddServices();
        }
    }
}