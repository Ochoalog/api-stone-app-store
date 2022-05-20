using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Stone.AppStore.Application.IntegrationEvents.Sender;
using Stone.AppStore.Application.Interfaces;
using Stone.AppStore.Application.Mappings;
using Stone.AppStore.Application.Services;
using Stone.AppStore.Domain.Entities;
using Stone.AppStore.Domain.Interfaces;
using Stone.AppStore.Infraestructure.Context;
using Stone.AppStore.Infraestructure.Identity;
using Stone.AppStore.Infraestructure.Repositories;
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

            services.AddScoped<IAppRepository, AppRepository>();
            services.AddScoped<IAppService, AppService>();
            services.AddScoped<IAuthenticate, AuthenticateService>();

            services.AddSingleton<IPaymentSender, PaymentSender>();


            services.AddAutoMapper(typeof(DomainToModelMappingProfile));

            var myhandlers = AppDomain.CurrentDomain.Load("Stone.AppStore.Application");
            services.AddMediatR(myhandlers);

            return services;
        }
    }
}
