namespace PlantiaApp.Shared.Core.Entities;

using PlantiaApp.Shared.Core.Interfaces;

public abstract class BaseEntity : IBaseEntity
{
    public Guid Id { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTime UpdatedDate { get; set; }
    public DateTime ArquivedDate { get; set; }
}
