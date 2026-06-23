using ModernWMC.Models.Abstract;
using System;

namespace ModernWMC.Models.Concrete
{
    public class Warehouse : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string? ContactPerson { get; set; }
        public int? Capacity { get; set; }
        public string? Address { get; set; }
        public int OccupancyPercentage { get; set; } = 0;
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
