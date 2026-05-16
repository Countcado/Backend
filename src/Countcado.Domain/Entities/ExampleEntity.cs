namespace Countcado.Domain.Entities;

/// <summary>
/// Entidad de ejemplo. Reemplaza por tu entidad de dominio real.
/// </summary>
public class ExampleEntity : BaseEntity
{
    public string Name { get; private set; }
    public string? Description { get; private set; }

    public ExampleEntity(string name, string? description = null)
    {
        Name = name;
        Description = description;
    }

    public void Update(string name, string? description)
    {
        Name = name;
        Description = description;
        SetUpdatedAt();
    }
}
