using ModernWMC.Models.Abstract;

namespace ModernWMC.Models.Concrete;

public class TermsOfUse : IEntity
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string SubText { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}

