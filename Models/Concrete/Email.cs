using ModernWMC.Models.Abstract;

namespace ModernWMC.Models.Concrete;

public class Email : IEntity
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Label { get; set; }
    public int order { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}