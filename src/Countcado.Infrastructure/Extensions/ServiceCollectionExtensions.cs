using Countcado.Domain.Entities;
using Countcado.Domain.Interfaces.Repositories;
using Countcado.Infrastructure.Configuration;
using Countcado.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Countcado.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        // ── Configuración ──────────────────────────────────────────────────────
        services.Configure<ApiSettings>(configuration.GetSection(ApiSettings.SectionName));

        // ── Repositorios ───────────────────────────────────────────────────────
        // Agrega aquí tus pares interfaz → implementación de repositorios.
        services.AddScoped<IRepository<ExampleEntity>, ExampleRepository>();

        // ── HttpClients externos ───────────────────────────────────────────────
        // Ejemplo:
        // services.AddHttpClient<IMyExternalService, MyExternalService>(...);

        return services;
    }
}
