using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Stone.AppStore.Infraestructure.Context;
using Stone.AppStore.Infraestructure.Identity;
using System;

namespace Stone.AppStore.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<AppStoreDbContext>(options =>
             options.UseSqlServer(configuration.GetConnectionString("AppStoreConnection"
            ), b => b.MigrationsAssembly(typeof(AppStoreDbContext).Assembly.FullName)));

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<AppStoreDbContext>()
                .AddDefaultTokenProviders();

            services.AddScoped<IAuthenticate, AuthenticateService>();
            //services.AddScoped<ISeedUserRoleInitial, SeedUserRoleInitial>();

            //services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            var myhandlers = AppDomain.CurrentDomain.Load("Stone.AppStore.Application");
            services.AddMediatR(myhandlers);

            return services;
        }
    }
}
