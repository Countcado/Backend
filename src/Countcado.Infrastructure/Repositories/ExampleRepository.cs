using Countcado.Domain.Entities;
using Countcado.Domain.Interfaces.Repositories;

namespace Countcado.Infrastructure.Repositories;

/// <summary>
/// Repositorio en memoria de ejemplo.
/// Reemplaza la implementación cuando conectes tu base de datos (EF Core, Dapper, etc.).
/// </summary>
public class ExampleRepository : IRepository<ExampleEntity>
{
    private readonly List<ExampleEntity> _store = [];

    public Task<ExampleEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var entity = _store.FirstOrDefault(e => e.Id == id);
        return Task.FromResult(entity);
    }

    public Task<IReadOnlyList<ExampleEntity>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        IReadOnlyList<ExampleEntity> result = _store.AsReadOnly();
        return Task.FromResult(result);
    }

    public Task<ExampleEntity> AddAsync(ExampleEntity entity, CancellationToken cancellationToken = default)
    {
        _store.Add(entity);
        return Task.FromResult(entity);
    }

    public Task UpdateAsync(ExampleEntity entity, CancellationToken cancellationToken = default)
    {
        // Con EF Core simplemente llamas a SaveChangesAsync().
        return Task.CompletedTask;
    }

    public Task DeleteAsync(ExampleEntity entity, CancellationToken cancellationToken = default)
    {
        _store.Remove(entity);
        return Task.CompletedTask;
    }
}
