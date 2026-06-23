using ModernWMC.Data.Concrete.EntityFramework;
using ModernWMC.Models.Concrete;

namespace ModernWMC.Data.Seeders
{
    public static class AboutSeeder
    {
        public static void Seed(StokFlowAppContext context)
        {
            if (!context.Abouts.Any())
            {
                context.Abouts.Add(new About
                {
                    WhoAreWeTitle = "Who We Are",
                    WhoAreWeDescription = "ModernWMC haqqında məlumat.",
                    OurMissionTitle = "Our Mission",
                    OurMissionDescription = "Müştərilərimizə keyfiyyətli xidmət göstərmək.",
                    WhoAreWeListTitle = "Why Choose Us",

                    WhoAreWeListFirstTextTitle = "Experience",
                    WhoAreWeListFirstText = "Years of experience in the industry.",

                    WhoAreWeListSecondTextTitle = "Quality",
                    WhoAreWeListSecondText = "We always prioritize quality.",

                    WhoAreWeListThirdTextTitle = "Support",
                    WhoAreWeListThirdText = "Professional customer support.",

                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                });

                context.SaveChanges();
            }
        }
    }
}
