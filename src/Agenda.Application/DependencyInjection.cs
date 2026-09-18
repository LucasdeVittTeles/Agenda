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

            return services;
        }

    }
}
