using ModernWMC.Data.Concrete.EntityFramework;
using ModernWMC.Models.Concrete;
using System;
using System.Linq;
using System.Collections.Generic;

namespace ModernWMC.Data.Seeders
{
    public static class PurchaseOrderSeeder
    {
        public static void Seed(StokFlowAppContext context)
        {
            if (!context.PurchaseOrders.Any())
            {
                var deltaCompany = context.Companies.FirstOrDefault(c => c.Name == "Delta Elektroniks MMC");
                var logiCompany = context.Companies.FirstOrDefault(c => c.Name == "LogiLink Aksesuar LTD");
                var paperCompany = context.Companies.FirstOrDefault(c => c.Name == "Bakı İnşaat Materialları MMC");

                var centralWh = context.Warehouses.FirstOrDefault(w => w.Code == "WH-CENTRAL");
                var sumgayitWh = context.Warehouses.FirstOrDefault(w => w.Code == "WH-SUMGAYIT");

                var dellProduct = context.Inventories.FirstOrDefault(i => i.SKU == "PRD-DELL-XPS15");
                var lgProduct = context.Inventories.FirstOrDefault(i => i.SKU == "PRD-LG-27MON");
                var paperProduct = context.Inventories.FirstOrDefault(i => i.SKU == "PRD-PAP-A4");

                if (deltaCompany != null && logiCompany != null && paperCompany != null &&
                    centralWh != null && sumgayitWh != null &&
                    dellProduct != null && lgProduct != null && paperProduct != null)
                {
                    var po1 = new PurchaseOrder
                    {
                        OrderNumber = "PO-2026-0001",
                        SupplierId = deltaCompany.Id,
                        WarehouseId = centralWh.Id,
                        OrderDate = new DateTime(2026, 06, 15, 10, 05, 00, DateTimeKind.Utc),
                        TotalAmount = 34500.00m,
                        Status = "PendingApproval",
                        IsActive = true,
                        CreatedAt = DateTime.UtcNow,
                        UpdatedAt = DateTime.UtcNow
                    };

                    var po2 = new PurchaseOrder
                    {
                        OrderNumber = "PO-2026-0002",
                        SupplierId = logiCompany.Id,
                        WarehouseId = sumgayitWh.Id,
                        OrderDate = new DateTime(2026, 06, 10, 14, 30, 00, DateTimeKind.Utc),
                        TotalAmount = 4500.00m,
                        Status = "Ordered",
                        IsActive = true,
                        CreatedAt = DateTime.UtcNow,
                        UpdatedAt = DateTime.UtcNow
                    };

                    var po3 = new PurchaseOrder
                    {
                        OrderNumber = "PO-2026-0003",
                        SupplierId = paperCompany.Id,
                        WarehouseId = centralWh.Id,
                        OrderDate = new DateTime(2026, 06, 05, 11, 15, 00, DateTimeKind.Utc),
                        TotalAmount = 1200.00m,
                        Status = "Completed",
                        IsActive = true,
                        CreatedAt = DateTime.UtcNow,
                        UpdatedAt = DateTime.UtcNow
                    };

                    context.PurchaseOrders.AddRange(po1, po2, po3);
                    context.SaveChanges();

                    context.PurchaseOrderItems.AddRange(
                        new PurchaseOrderItem
                        {
                            PurchaseOrderId = po1.Id,
                            InventoryId = dellProduct.Id,
                            Quantity = 15,
                            UnitPrice = 2300.00m
                        },
                        new PurchaseOrderItem
                        {
                            PurchaseOrderId = po2.Id,
                            InventoryId = lgProduct.Id,
                            Quantity = 15,
                            UnitPrice = 300.00m
                        },
                        new PurchaseOrderItem
                        {
                            PurchaseOrderId = po3.Id,
                            InventoryId = paperProduct.Id,
                            Quantity = 300,
                            UnitPrice = 4.00m
                        }
                    );

                    context.SaveChanges();
                }
            }
        }
    }
}
