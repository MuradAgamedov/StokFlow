using ModernWMC.Models.Abstract;

namespace ModernWMC.Models.Concrete;

public class SystemModulesStatic : IEntity
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Subtitle { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}

