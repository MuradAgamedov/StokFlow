using ModernWMC.Models.Abstract;

namespace ModernWMC.Models.Concrete;

public class SystemModulesDynamic : IEntity
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string IconClass { get; set; }
    public string Url { get; set; }
    public string Description { get; set; }
    public int Order { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}

