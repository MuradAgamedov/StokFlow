using ModernWMC.Data.Concrete.EntityFramework;
using ModernWMC.Models.Concrete;

namespace ModernWMC.Data.Seeders
{
    public interface SystemModulesStaticSeeder
    {
        public static void Seed(StokFlowAppContext context)
        {
            if (!context.SystemModulesStatics.Any())
            {
                context.SystemModulesStatics.Add(new SystemModulesStatic
                {
                    Title = "Sistem Modulları",
                    Subtitle = "Hər Şey Bir Yerdə, Tam Nəzarətdə",
                    Description = "Biznesinizin təchizat zəncirini və anbar loqistikasını tam idarə etmək üçün ehtiyacınız olan bütün modullar bir arada.",

                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                });

                context.SaveChanges();
            }
        }
    }
}
