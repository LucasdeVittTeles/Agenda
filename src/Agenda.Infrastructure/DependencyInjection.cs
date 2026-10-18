using Agenda.Application.Interfaces.Persistence;
using Agenda.Application.Interfaces.Repositories;
using Agenda.Infrastructure.Data;
using Agenda.Infrastructure.Persistence;
using Agenda.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Agenda.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IBusinessServiceRepository, BusinessServiceRepository>();
        services.AddScoped<IBusinessRepository, BusinessRepository>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<DbInitializer>();

        return services;
    }

}
