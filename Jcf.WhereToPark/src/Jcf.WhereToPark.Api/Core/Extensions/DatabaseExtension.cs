﻿using Jcf.WhereToPark.Api.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Jcf.WhereToPark.Api.Core.Extensions
{
    public static class DatabaseExtension
    {
        public static IServiceCollection AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
        {
            var consoleLogger = LoggerFactory.Create(builder => builder.AddConsole());

            services.AddDbContext<AppDbContext>(options =>
            {
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
                options.EnableSensitiveDataLogging();

                if (environment.IsDevelopment())
                {
                    options.UseLoggerFactory(consoleLogger).EnableDetailedErrors();
                }
            });

            services.AddScoped<AppDapperContext>();

            return services;
        }
    }
}
