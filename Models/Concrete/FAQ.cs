using ModernWMC.Models.Abstract;

namespace ModernWMC.Models.Concrete
{
    public class FAQ : IEntity
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public int Order { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}
