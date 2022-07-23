using Cloud.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud.Persistance
{
   static class DependencyInjection
    {
        public static IServiceCollection AddPersistance (this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<CloudDbContext>(options =>
            {
                options.UseSqlite(connectionString);
            });
            services.AddScoped<ICloudDbContext>(provider => provider.GetService<CloudDbContext>());
            return services;
        }
    }
}
