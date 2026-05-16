namespace Countcado.Application.DTOs;

/// <summary>
/// DTO de respuesta. Reemplaza por tu entidad real.
/// </summary>
public record ExampleDto(Guid Id, string Name, string? Description, DateTime CreatedAt);

/// <summary>
/// DTO para crear una nueva entidad.
/// </summary>
public record CreateExampleDto(string Name, string? Description);

/// <summary>
/// DTO para actualizar una entidad existente.
/// </summary>
public record UpdateExampleDto(string Name, string? Description);
