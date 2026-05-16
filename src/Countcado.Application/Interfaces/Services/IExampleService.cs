using Countcado.Application.DTOs;

namespace Countcado.Application.Interfaces.Services;

/// <summary>
/// Ejemplo de interfaz de servicio. Reemplaza "Example" por el dominio real.
/// </summary>
public interface IExampleService
{
    Task<IReadOnlyList<ExampleDto>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<ExampleDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<ExampleDto> CreateAsync(CreateExampleDto dto, CancellationToken cancellationToken = default);
    Task UpdateAsync(Guid id, UpdateExampleDto dto, CancellationToken cancellationToken = default);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}
