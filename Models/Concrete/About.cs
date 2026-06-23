using ModernWMC.Models.Abstract;

namespace ModernWMC.Models.Concrete;

public class About : IEntity
{
    public int Id { get; set; }
    public string WhoAreWeTitle { get; set; }
    public string WhoAreWeDescription { get; set; }
    public string OurMissionTitle { get; set; }
    public string OurMissionDescription { get; set; }
    public string WhoAreWeListTitle { get; set; }
    public string WhoAreWeListFirstTextTitle { get; set; }
    public string WhoAreWeListFirstText { get; set; }
    public string WhoAreWeListSecondTextTitle { get; set; }
    public string WhoAreWeListSecondText { get; set; }
    public string WhoAreWeListThirdTextTitle { get; set; }
    public string WhoAreWeListThirdText { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}