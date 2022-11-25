﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WestWindSystem.BLL;
using WestWindSystem.DAL;

namespace WestwindSystem
{
    public static class StartupExtensions
    {
        public static void AddBackendDependencies(
            this IServiceCollection services,
            Action<DbContextOptionsBuilder> options)
        {
            services.AddDbContext<WestwindContext>(options);

            services.AddTransient<BuildVersionServices>(serviceProvider => {
                var context = serviceProvider.GetRequiredService<WestwindContext>();
                return new BuildVersionServices(context);
            });

            services.AddTransient<CategoryServices>(serviceProvider => {
                var context = serviceProvider.GetRequiredService<WestwindContext>();
                return new CategoryServices(context);
            });
            
            services.AddTransient<ProductServices>(serviceProvider =>
            {
                var context = serviceProvider.GetRequiredService<WestwindContext>();
                return new ProductServices(context);
            });
            services.AddTransient<SupplierServices>(serviceProvider =>
            {
                var context = serviceProvider.GetRequiredService<WestwindContext>();
                return new SupplierServices(context);
            });

        }
    }
}