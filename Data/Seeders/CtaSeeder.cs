using ModernWMC.Data.Concrete.EntityFramework;
using ModernWMC.Models.Concrete;

namespace ModernWMC.Data.Seeders
{
    public static class CtaSeeder
    {
        public static void Seed(StokFlowAppContext context)
        {
            if (context.Ctas.Any())
                return;

            context.Ctas.Add(new Cta
            {
                Title = "Anbar İdarəçiliyini Bu Gün Rəqəmsallaşdırın",
                Description = "WMS Pro ilə vaxta və resurslara tam qənaət edərək, təchizat zəncirinizi tamamilə avtomatlaşdırın.",
                ButtonText = "İstifadəçi Panelini Yoxla",
                Url = "/login",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            });

            context.SaveChanges();
        }
    }
}
