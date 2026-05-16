namespace Countcado.Infrastructure.Configuration;

/// <summary>
/// Configuración de URLs y opciones globales de la API.
/// Se enlaza con la sección "ApiSettings" de appsettings.json.
/// </summary>
public sealed class ApiSettings
{
    public const string SectionName = "ApiSettings";

    public string FrontendUrl { get; init; } = "http://localhost:4200";
    public string BaseUrl { get; init; } = "http://localhost:5000";
}
