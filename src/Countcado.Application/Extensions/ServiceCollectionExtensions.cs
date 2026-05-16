using Countcado.Application.Interfaces.Services;
using Countcado.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Countcado.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        // AutoMapper: agrega tus perfiles cuando los necesites.
        // Ejemplo: services.AddAutoMapper(cfg => cfg.AddProfile<TuMappingProfile>());
        services.AddAutoMapper(cfg => { });

        // ── Servicios ──────────────────────────────────────────────────────────
        // Agrega aquí tus pares interfaz → implementación de servicios.
        services.AddScoped<IExampleService, ExampleService>();

        return services;
    }
}
