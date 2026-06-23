using ModernWMC.Data.Concrete.EntityFramework;
using ModernWMC.Models.Concrete;

namespace ModernWMC.Data.Seeders
{
    public static class CategorySeeder
    {
        public static void Seed(StokFlowAppContext context)
        {
            if (!context.Categories.Any())
            {
                context.Categories.AddRange(
                    new Category
                    {
                        Name = "Xammal",
                        CategoryCode = "CAT-RAW",
                        Description = "İstehsalat və emal üçün istifadə olunan əsas xammal və materiallar",
                        CreatedAt = DateTime.UtcNow,
                        UpdatedAt = DateTime.UtcNow
                    },
                    new Category
                    {
                        Name = "Hazır Məhsullar",
                        CategoryCode = "CAT-FG",
                        Description = "Satışa və müştərilərə göndərilməyə tam hazır olan son məhsullar",
                        CreatedAt = DateTime.UtcNow,
                        UpdatedAt = DateTime.UtcNow
                    },
                    new Category
                    {
                        Name = "Qablaşdırma Materialları",
                        CategoryCode = "CAT-PKG",
                        Description = "Məhsulların qablaşdırılması, qorunması və paletləşdirilməsi üçün materiallar",
                        CreatedAt = DateTime.UtcNow,
                        UpdatedAt = DateTime.UtcNow
                    },
                    new Category
                    {
                        Name = "Ehtiyat Hissələri",
                        CategoryCode = "CAT-SP",
                        Description = "Avadanlıqların və maşınların təmiri üçün istifadə olunan ehtiyat hissələri",
                        CreatedAt = DateTime.UtcNow,
                        UpdatedAt = DateTime.UtcNow
                    },
                    new Category
                    {
                        Name = "Yarımfabrikatlar",
                        CategoryCode = "CAT-SFG",
                        Description = "İstehsal prosesi tamamlanmamış, ara mərhələdə olan məhsullar",
                        CreatedAt = DateTime.UtcNow,
                        UpdatedAt = DateTime.UtcNow
                    },
                    new Category
                    {
                        Name = "Elektronika",
                        CategoryCode = "CAT-EL",
                        Description = "Müxtəlif növ elektron cihazlar və avadanlıqlar",
                        CreatedAt = DateTime.UtcNow,
                        UpdatedAt = DateTime.UtcNow
                    },
                    new Category
                    {
                        Name = "Ofis Ləvazimatları",
                        CategoryCode = "CAT-OF",
                        Description = "Ofis fəaliyyəti üçün zəruri olan materiallar",
                        CreatedAt = DateTime.UtcNow,
                        UpdatedAt = DateTime.UtcNow
                    },
                    new Category
                    {
                        Name = "Aksesuarlar",
                        CategoryCode = "CAT-AK",
                        Description = "Kompüter və digər cihazların aksesuarları",
                        CreatedAt = DateTime.UtcNow,
                        UpdatedAt = DateTime.UtcNow
                    },
                    new Category
                    {
                        Name = "Kağız Məhsulları",
                        CategoryCode = "CAT-KM",
                        Description = "Çap və yazı kağızları, dəftərxana məhsulları",
                        CreatedAt = DateTime.UtcNow,
                        UpdatedAt = DateTime.UtcNow
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
