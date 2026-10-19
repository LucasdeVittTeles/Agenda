using Agenda.Application.Services.Business;
using Agenda.Application.Services.Registration;
using Agenda.Application.Services.Services;
using Agenda.Application.Services.Users;
using Agenda.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Agenda.Application
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<ICreateUserService, CreateUserService>();

            services.AddScoped<IPasswordHasher<Users>, PasswordHasher<Users>>();

            services.AddScoped<IBusinessServicesService, BusinessServicesService>();

            services.AddScoped<IRegistrationService, RegistrationService>();

            services.AddScoped<IBusinessService, Services.Business.BusinessService>();

            return services;
        }

    }
}
