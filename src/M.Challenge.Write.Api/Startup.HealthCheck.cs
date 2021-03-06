﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace M.Challenge.Write.Api
{
    public partial class Startup
    {
        private static void ConfigureHealthChecks(IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddHealthChecks()
                .AddMongoDb(configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
