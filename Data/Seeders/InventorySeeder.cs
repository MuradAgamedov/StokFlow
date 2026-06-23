using ModernWMC.Data.Concrete.EntityFramework;
using ModernWMC.Models.Concrete;
using System;
using System.Linq;

namespace ModernWMC.Data.Seeders
{
    public static class InventorySeeder
    {
        public static void Seed(StokFlowAppContext context)
        {
            if (!context.Inventories.Any())
            {
                var elCategory = context.Categories.FirstOrDefault(c => c.CategoryCode == "CAT-EL");
                var akCategory = context.Categories.FirstOrDefault(c => c.CategoryCode == "CAT-AK");
                var kmCategory = context.Categories.FirstOrDefault(c => c.CategoryCode == "CAT-KM");

                var pieceUnit = context.MeasureUnits.FirstOrDefault(u => u.Code == "ədəd");
                var boxUnit = context.MeasureUnits.FirstOrDefault(u => u.Code == "qutu");

                var centralWh = context.Warehouses.FirstOrDefault(w => w.Code == "WH-CENTRAL");
                var sumgayitWh = context.Warehouses.FirstOrDefault(w => w.Code == "WH-SUMGAYIT");
                var ganjaWh = context.Warehouses.FirstOrDefault(w => w.Code == "WH-GANJA");

                if (elCategory != null && akCategory != null && kmCategory != null &&
                    pieceUnit != null && boxUnit != null &&
                    centralWh != null && sumgayitWh != null && ganjaWh != null)
                {
                    context.Inventories.AddRange(
                        new Inventory
                        {
                            Name = "Laptop Dell XPS 15",
                            SKU = "PRD-DELL-XPS15",
                            CategoryId = elCategory.Id,
                            MeasureUnitId = pieceUnit.Id,
                            WarehouseId = centralWh.Id,
                            ShelfLocation = "Zone-A / Rəf-04",
                            Quantity = 2,
                            CriticalLimit = 5,
                            LotNo = "LOT-84729",
                            ExpirationDate = null,
                            IsActive = true,
                            CreatedAt = DateTime.UtcNow,
                            UpdatedAt = DateTime.UtcNow
                        },
                        new Inventory
                        {
                            Name = "Printer Canon LBP236DW",
                            SKU = "PRD-CANON-LBP",
                            CategoryId = elCategory.Id,
                            MeasureUnitId = pieceUnit.Id,
                            WarehouseId = centralWh.Id,
                            ShelfLocation = "Zone-B / Rəf-01",
                            Quantity = 1,
                            CriticalLimit = 3,
                            LotNo = "LOT-92817",
                            ExpirationDate = null,
                            IsActive = true,
                            CreatedAt = DateTime.UtcNow,
                            UpdatedAt = DateTime.UtcNow
                        },
                        new Inventory
                        {
                            Name = "Monitor LG 27\" IPS",
                            SKU = "PRD-LG-27MON",
                            CategoryId = elCategory.Id,
                            MeasureUnitId = pieceUnit.Id,
                            WarehouseId = sumgayitWh.Id,
                            ShelfLocation = "Zone-C / Rəf-12",
                            Quantity = 15,
                            CriticalLimit = 5,
                            LotNo = "LOT-28192",
                            ExpirationDate = null,
                            IsActive = true,
                            CreatedAt = DateTime.UtcNow,
                            UpdatedAt = DateTime.UtcNow
                        },
                        new Inventory
                        {
                            Name = "Klaviatura Logitech MX Keys",
                            SKU = "PRD-LOGI-KEYS",
                            CategoryId = akCategory.Id,
                            MeasureUnitId = pieceUnit.Id,
                            WarehouseId = ganjaWh.Id,
                            ShelfLocation = "Zone-A / Rəf-02",
                            Quantity = 6,
                            CriticalLimit = 8,
                            LotNo = "LOT-10293",
                            ExpirationDate = new DateTime(2026, 07, 12),
                            IsActive = true,
                            CreatedAt = DateTime.UtcNow,
                            UpdatedAt = DateTime.UtcNow
                        },
                        new Inventory
                        {
                            Name = "Siçan Logitech MX Master 3",
                            SKU = "PRD-LOGI-MX3",
                            CategoryId = akCategory.Id,
                            MeasureUnitId = pieceUnit.Id,
                            WarehouseId = sumgayitWh.Id,
                            ShelfLocation = "Zone-A / Rəf-03",
                            Quantity = 24,
                            CriticalLimit = 10,
                            LotNo = "LOT-39281",
                            ExpirationDate = null,
                            IsActive = true,
                            CreatedAt = DateTime.UtcNow,
                            UpdatedAt = DateTime.UtcNow
                        },
                        new Inventory
                        {
                            Name = "Printer Kağızı A4 (500 vərəq)",
                            SKU = "PRD-PAP-A4",
                            CategoryId = kmCategory.Id,
                            MeasureUnitId = boxUnit.Id,
                            WarehouseId = centralWh.Id,
                            ShelfLocation = "Zone-D / Rəf-10",
                            Quantity = 350,
                            CriticalLimit = 50,
                            LotNo = "LOT-48291",
                            ExpirationDate = new DateTime(2026, 06, 01),
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
}
