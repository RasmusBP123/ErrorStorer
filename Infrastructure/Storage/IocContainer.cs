using Domain;
using Domain.Repositories;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Infrastructure.Storage
{
    public static class IocContainer
    {
        public static IServiceCollection RegisterInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddDefaultIdentity<DbStorage>(opt =>
            //{ 
            //    opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            //});

            services.AddDbContext<DbStorage>(opt => 
            {
                opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddDefaultIdentity<ApplicationUser>()
                    .AddRoles<IdentityRole<Guid>>()
                    .AddEntityFrameworkStores<DbStorage>()
                    .AddDefaultTokenProviders();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ITicketRepository, TicketRepository>();
            services.AddScoped<IAuthenticationRepository, AuthentcationRepository>();

            return services;
        }
    }
}

