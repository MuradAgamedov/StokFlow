using ModernWMC.Data.Concrete.EntityFramework;
using ModernWMC.Models.Concrete;
using System;
using System.Linq;

namespace ModernWMC.Data.Seeders
{
    public static class WarehouseSeeder
    {
        public static void Seed(StokFlowAppContext context)
        {
            if (!context.Warehouses.Any())
            {
                context.Warehouses.AddRange(
                    new Warehouse
                    {
                        Name = "Mərkəzi Anbar",
                        Code = "WH-CENTRAL",
                        Address = "Bakı şəhəri, Babək prospekti 85",
                        ContactPerson = "Əli Məmmədov",
                        Capacity = 10000,
                        OccupancyPercentage = 65,
                        IsActive = true,
                        CreatedAt = DateTime.UtcNow,
                        UpdatedAt = DateTime.UtcNow
                    },
                    new Warehouse
                    {
                        Name = "Sumqayıt Filialı",
                        Code = "WH-SUMGAYIT",
                        Address = "Sumqayıt ŞH, Sülh küçəsi 4-cü məhəllə",
                        ContactPerson = "Vüsal Rzayev",
                        Capacity = 5000,
                        OccupancyPercentage = 82,
                        IsActive = true,
                        CreatedAt = DateTime.UtcNow,
                        UpdatedAt = DateTime.UtcNow
                    },
                    new Warehouse
                    {
                        Name = "Gəncə Logistika",
                        Code = "WH-GANJA",
                        Address = "Gəncə şəhəri, Şah İsmayıl Xətai prospekti",
                        ContactPerson = "Leyla Həsənova",
                        Capacity = 8000,
                        OccupancyPercentage = 30,
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
