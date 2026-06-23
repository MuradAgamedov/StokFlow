using ModernWMC.Data.Concrete.EntityFramework;
using ModernWMC.Models.Concrete;

namespace ModernWMC.Data.Seeders
{
    public class HeroSeeder
    {
        public static void Seed(StokFlowAppContext context)
        {
            if (!context.Heroes.Any())
            {
                context.Heroes.Add(new Hero
                {
                    Label = "Yeni Nəsil B2B & WMS Həlli v3.0",
                    Title = "Ağıllı Anbar və <br><span>Təchizat ERP</span> İdarəetməsi",
                    SubText = "WMS Pro ilə anbarlarınızın rəf doluluğunu vizual şəkildə izləyin, satınalma sifarişlərini idarə edin, anbarlararası transferləri və məhsul qruplarını tək platformadan nəzarətdə saxlayın.",
                    ImageUrl = "Image.jpg",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                });

                context.SaveChanges();
            }
        }
    }
}
