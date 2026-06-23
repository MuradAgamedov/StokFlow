using ModernWMC.Data.Concrete.EntityFramework;
using ModernWMC.Models.Concrete;
using System;
using System.Linq;

namespace ModernWMC.Data.Seeders
{
    public static class MeasureUnitSeeder
    {
        public static void Seed(StokFlowAppContext context)
        {
            if (!context.MeasureUnits.Any())
            {
                context.MeasureUnits.AddRange(
                    new MeasureUnit
                    {
                        Name = "Ədəd",
                        Code = "ədəd",
                        Description = "Say ölçü vahidi",
                        IsActive = true,
                        CreatedAt = DateTime.UtcNow,
                        UpdatedAt = DateTime.UtcNow
                    },
                    new MeasureUnit
                    {
                        Name = "Kiloqram",
                        Code = "kq",
                        Description = "Kütlə/çəki ölçü vahidi",
                        IsActive = true,
                        CreatedAt = DateTime.UtcNow,
                        UpdatedAt = DateTime.UtcNow
                    },
                    new MeasureUnit
                    {
                        Name = "Litr",
                        Code = "l",
                        Description = "Həcm/maye ölçü vahidi",
                        IsActive = true,
                        CreatedAt = DateTime.UtcNow,
                        UpdatedAt = DateTime.UtcNow
                    },
                    new MeasureUnit
                    {
                        Name = "Metr",
                        Code = "m",
                        Description = "Uzunluq ölçü vahidi",
                        IsActive = true,
                        CreatedAt = DateTime.UtcNow,
                        UpdatedAt = DateTime.UtcNow
                    },
                    new MeasureUnit
                    {
                        Name = "Qutu",
                        Code = "qutu",
                        Description = "Paketləmə ölçü vahidi",
                        IsActive = true,
                        CreatedAt = DateTime.UtcNow,
                        UpdatedAt = DateTime.UtcNow
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
