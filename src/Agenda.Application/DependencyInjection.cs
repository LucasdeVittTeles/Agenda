using Agenda.Application.Services.Users;
using Microsoft.Extensions.DependencyInjection;

namespace Agenda.Application
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<ICreateUserService, CreateUserService>();

            return services;
        }

    }
}
