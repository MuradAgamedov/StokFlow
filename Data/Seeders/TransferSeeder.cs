using ModernWMC.Data.Concrete.EntityFramework;
using ModernWMC.Models.Concrete;
using System;
using System.Linq;
using System.Collections.Generic;

namespace ModernWMC.Data.Seeders
{
    public static class TransferSeeder
    {
        public static void Seed(StokFlowAppContext context)
        {
            if (!context.Transfers.Any())
            {
                var centralWh = context.Warehouses.FirstOrDefault(w => w.Code == "WH-CENTRAL");
                var sumgayitWh = context.Warehouses.FirstOrDefault(w => w.Code == "WH-SUMGAYIT");
                var ganjaWh = context.Warehouses.FirstOrDefault(w => w.Code == "WH-GANJA");

                var dellProduct = context.Inventories.FirstOrDefault(i => i.SKU == "PRD-DELL-XPS15");
                var lgProduct = context.Inventories.FirstOrDefault(i => i.SKU == "PRD-LG-27MON");
                var keysProduct = context.Inventories.FirstOrDefault(i => i.SKU == "PRD-LOGI-KEYS");

                if (centralWh != null && sumgayitWh != null && ganjaWh != null &&
                    dellProduct != null && lgProduct != null && keysProduct != null)
                {
                    var tr1 = new Transfer
                    {
                        TransferNumber = "TR-2026-0048",
                        SourceWarehouseId = centralWh.Id,
                        DestinationWarehouseId = sumgayitWh.Id,
                        SendDate = new DateTime(2026, 06, 15, 11, 20, 00, DateTimeKind.Utc),
                        Status = "InTransit",
                        IsActive = true,
                        CreatedAt = DateTime.UtcNow,
                        UpdatedAt = DateTime.UtcNow
                    };

                    var tr2 = new Transfer
                    {
                        TransferNumber = "TR-2026-0047",
                        SourceWarehouseId = centralWh.Id,
                        DestinationWarehouseId = ganjaWh.Id,
                        SendDate = new DateTime(2026, 06, 12, 09, 15, 00, DateTimeKind.Utc),
                        Status = "Completed",
                        IsActive = true,
                        CreatedAt = DateTime.UtcNow,
                        UpdatedAt = DateTime.UtcNow
                    };

                    var tr3 = new Transfer
                    {
                        TransferNumber = "TR-2026-0046",
                        SourceWarehouseId = ganjaWh.Id,
                        DestinationWarehouseId = sumgayitWh.Id,
                        SendDate = new DateTime(2026, 06, 10, 14, 00, 00, DateTimeKind.Utc),
                        Status = "Completed",
                        IsActive = true,
                        CreatedAt = DateTime.UtcNow,
                        UpdatedAt = DateTime.UtcNow
                    };

                    context.Transfers.AddRange(tr1, tr2, tr3);
                    context.SaveChanges();

                    context.TransferItems.AddRange(
                        new TransferItem
                        {
                            TransferId = tr1.Id,
                            InventoryId = dellProduct.Id,
                            Quantity = 5
                        },
                        new TransferItem
                        {
                            TransferId = tr2.Id,
                            InventoryId = lgProduct.Id,
                            Quantity = 10
                        },
                        new TransferItem
                        {
                            TransferId = tr3.Id,
                            InventoryId = keysProduct.Id,
                            Quantity = 4
                        }
                    );

                    context.SaveChanges();
                }
            }
        }
    }
}
