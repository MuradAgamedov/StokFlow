using ModernWMC.Data.Concrete.EntityFramework;
using ModernWMC.Models.Concrete;

namespace ModernWMC.Data.Seeders;

public static class SystemModulesDynamicSeeder
{
    public static void Seed(StokFlowAppContext context)
    {
        if (context.SystemModulesDynamics.Any())
            return;

        context.SystemModulesDynamics.AddRange(
            new SystemModulesDynamic
            {
                Title = "Anbar & Stok",
                IconClass = "bx bx-package",
                Url = "#",
                Description = "Məhsul siyahılarını idarə edin, kritik həddə çatan mallara baxın və stok düzəlişlərini sürətlə həyata keçirin.",
                Order = 1,
                IsActive = true,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new SystemModulesDynamic
            {
                Title = "Vizual Rəf Xəritəsi",
                IconClass = "bx bx-grid-alt",
                Url = "#",
                Description = "Anbarın fiziki rəf grid modelini vizual xəritədə izləyin.",
                Order = 2,
                IsActive = true,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new SystemModulesDynamic
            {
                Title = "Kateqoriyalar",
                IconClass = "bx bx-purchase-tag",
                Url = "#",
                Description = "Məhsulları kateqoriyalar üzrə qruplaşdırın.",
                Order = 3,
                IsActive = true,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new SystemModulesDynamic
            {
                Title = "Fiziki Anbarlar",
                IconClass = "bx bx-building-house",
                Url = "#",
                Description = "Filial və anbarları idarə edin.",
                Order = 4,
                IsActive = true,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new SystemModulesDynamic
            {
                Title = "Satınalma & Sifarişlər",
                IconClass = "bx bx-cart",
                Url = "#",
                Description = "PO və sifariş proseslərini izləyin.",
                Order = 5,
                IsActive = true,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new SystemModulesDynamic
            {
                Title = "Anbarlararası Transfer",
                IconClass = "bx bx-transfer",
                Url = "#",
                Description = "Anbarlar arasında məhsul transferini idarə edin.",
                Order = 6,
                IsActive = true,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            }
        );

        context.SaveChanges();
    }
}