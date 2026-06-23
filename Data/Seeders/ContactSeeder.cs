using ModernWMC.Data.Concrete.EntityFramework;
using ModernWMC.Models.Concrete;

namespace ModernWMC.Data.Seeders
{
    public static class ContactSeeder
    {
        public static void Seed(StokFlowAppContext context)
        {
            SeedPhones(context);
            SeedEmails(context);
            SeedAddresses(context);
            SeedMaps(context);
        }

        private static void SeedPhones(StokFlowAppContext context)
        {
            if (context.Phones.Any())
                return;

            context.Phones.AddRange(
                new Phone
                {
                    Title = "Əsas Telefon",
                    Label = "+994 (12) 400-99-88",
                    EmbedMap = string.Empty,
                    order = 1,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Phone
                {
                    Title = "Mobil Telefon",
                    Label = "+994 (50) 200-11-22",
                    EmbedMap = string.Empty,
                    order = 2,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }
            );

            context.SaveChanges();
        }

        private static void SeedEmails(StokFlowAppContext context)
        {
            if (context.Emails.Any())
                return;

            context.Emails.AddRange(
                new Email
                {
                    Title = "İnfo E-poçt",
                    Label = "info@wmspro.az",
                    order = 1,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Email
                {
                    Title = "Dəstək E-poçtu",
                    Label = "support@wmspro.az",
                    order = 2,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }
            );

            context.SaveChanges();
        }

        private static void SeedAddresses(StokFlowAppContext context)
        {
            if (context.Addresses.Any())
                return;

            context.Addresses.AddRange(
                new Address
                {
                    Title = "Ünvanımız",
                    Label = "Bakı şəhəri, Nizami küçəsi 142, AZ1000, Azərbaycan",
                    Order = 1,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }
            );

            context.SaveChanges();
        }

        private static void SeedMaps(StokFlowAppContext context)
        {
            if (context.Maps.Any())
                return;

            context.Maps.AddRange(
                new Map
                {
                    Title = "Əsas Xəritə",
                    EmbedCode = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3039.4286748537574!2d49.8517564!3d40.3771908!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x40307d17b5f63457%3A0xc3cf9c916298dc1e!2sNizami%20St%2C%20Baku!5e0!3m2!1sen!2saz!4v1718465000000!5m2!1sen!2saz",
                    Order = 1,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }
            );

            context.SaveChanges();
        }
    }
}
