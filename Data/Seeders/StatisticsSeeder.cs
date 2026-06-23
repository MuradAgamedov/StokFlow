using ModernWMC.Data.Concrete.EntityFramework;
using ModernWMC.Models.Concrete;

namespace ModernWMC.Data.Seeders;

public static class StatisticsSeeder
{
    public static void Seed(StokFlowAppContext context)
    {
        if (context.Statistics.Any())
            return;

        context.Statistics.AddRange(
            new Statistics
            {
                Title = "99.9% Dəqiqlik",
                Description = "Anbar inventarının yüksək dəqiqliklə idarə olunması.",
                Order = 1,
                IsActive = true,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new Statistics
            {
                Title = "10K+ Məhsul",
                Description = "Sistem üzərindən idarə olunan məhsul sayı.",
                Order = 2,
                IsActive = true,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new Statistics
            {
                Title = "50+ Anbar",
                Description = "Aktiv şəkildə idarə olunan fiziki anbarlar.",
                Order = 3,
                IsActive = true,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new Statistics
            {
                Title = "24/7 Monitorinq",
                Description = "Anbar əməliyyatlarının fasiləsiz izlənməsi.",
                Order = 4,
                IsActive = true,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            }
        );

        context.SaveChanges();
    }
}