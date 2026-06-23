using ModernWMC.Data.Concrete.EntityFramework;
using ModernWMC.Models.Concrete;

namespace ModernWMC.Data.Seeders
{
    public static class FAQSeeder
    {
        public static void Seed(StokFlowAppContext context)
        {
            if (context.FAQs.Any())
                return;

            context.FAQs.AddRange(
                new FAQ
                {
                    Question = "StokFlow nədir?",
                    Answer = "StokFlow müəssisələrin anbar, stok və məhsul idarəetmə proseslərini rəqəmsallaşdıran platformadır.",
                    Order = 1,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new FAQ
                {
                    Question = "Məhsul stokunu necə izləyə bilərəm?",
                    Answer = "Anbar və Stok bölməsindən məhsulların cari miqdarını, hərəkətlərini və kritik stok səviyyələrini izləyə bilərsiniz.",
                    Order = 2,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new FAQ
                {
                    Question = "Anbarlararası transfer mümkündürmü?",
                    Answer = "Bəli. Anbarlararası Transfer modulu vasitəsilə məhsulları müxtəlif anbarlar arasında köçürə bilərsiniz.",
                    Order = 3,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new FAQ
                {
                    Question = "Kritik stok xəbərdarlığı varmı?",
                    Answer = "Bəli. Məhsul stok səviyyəsi müəyyən edilmiş minimum həddən aşağı düşdükdə sistem xəbərdarlıq göstərir.",
                    Order = 4,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new FAQ
                {
                    Question = "Yeni məhsul necə əlavə edilir?",
                    Answer = "Anbar və Stok bölməsində 'Yeni Məhsul' əməliyyatından istifadə edərək məhsul əlavə edə bilərsiniz.",
                    Order = 5,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }
            );

            context.SaveChanges();
        }
    }
}