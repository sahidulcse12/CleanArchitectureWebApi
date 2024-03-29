﻿using CleanArchitectureWebApi.Application.Common.Interfaces.Repositories;
using CleanArchitectureWebApi.Infrastructure.Data.DbContexts;
using CleanArchitectureWebApi.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitectureWebApi.Infrastructure
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddInfrastructureService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BlogDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("BlogDbContext"),
                    b => b.MigrationsAssembly("CleanArchitectureWebApi.Infrastructure"));
            });
            services.AddScoped<IBlogRepository, BlogRepository>();
            services.AddScoped<IUnitOfWork,UnitOfWork>();
            return services;
        }
    }
}
