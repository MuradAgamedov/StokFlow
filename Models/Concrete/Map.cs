using ModernWMC.Models.Abstract;

namespace ModernWMC.Models.Concrete
{
    public class Map : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string EmbedCode { get; set; }
        public int Order { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
