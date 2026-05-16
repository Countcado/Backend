using Countcado.Application.DTOs;
using Countcado.Application.Interfaces.Services;
using Countcado.Domain.Common.Exceptions;
using Countcado.Domain.Entities;
using Countcado.Domain.Interfaces.Repositories;

namespace Countcado.Application.Services;

/// <summary>
/// Implementación de ejemplo. Reemplaza "Example" por tu dominio real.
/// </summary>
public class ExampleService : IExampleService
{
    private readonly IRepository<ExampleEntity> _repository;

    public ExampleService(IRepository<ExampleEntity> repository)
    {
        _repository = repository;
    }

    public async Task<IReadOnlyList<ExampleDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return entities.Select(Map).ToList();
    }

    public async Task<ExampleDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var entity = await _repository.GetByIdAsync(id, cancellationToken);
        return entity is null ? null : Map(entity);
    }

    public async Task<ExampleDto> CreateAsync(CreateExampleDto dto, CancellationToken cancellationToken = default)
    {
        var entity = new ExampleEntity(dto.Name, dto.Description);
        await _repository.AddAsync(entity, cancellationToken);
        return Map(entity);
    }

    public async Task UpdateAsync(Guid id, UpdateExampleDto dto, CancellationToken cancellationToken = default)
    {
        var entity = await _repository.GetByIdAsync(id, cancellationToken)
            ?? throw new NotFoundException(nameof(ExampleEntity), id);

        entity.Update(dto.Name, dto.Description);
        await _repository.UpdateAsync(entity, cancellationToken);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var entity = await _repository.GetByIdAsync(id, cancellationToken)
            ?? throw new NotFoundException(nameof(ExampleEntity), id);

        await _repository.DeleteAsync(entity, cancellationToken);
    }

    private static ExampleDto Map(ExampleEntity e) =>
        new(e.Id, e.Name, e.Description, e.CreatedAt);
}
