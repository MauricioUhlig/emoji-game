
using Microsoft.Extensions.DependencyInjection;

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