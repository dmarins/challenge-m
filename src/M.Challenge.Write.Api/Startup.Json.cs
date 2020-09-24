using Microsoft.Extensions.DependencyInjection;

namespace M.Challenge.Write.Api
{
    public partial class Startup
    {
        private static void ConfigureJson(IServiceCollection services)
        {

            services
                .AddControllers()
                .AddNewtonsoftJson();
        }
    }
}
