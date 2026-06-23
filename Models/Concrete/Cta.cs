using ModernWMC.Models.Abstract;

namespace ModernWMC.Models.Concrete;

public class Cta : IEntity
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string ButtonText { get; set; }
    public string Url { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}