using ModernWMC.Data.Abstract;
using ModernWMC.Models.Concrete;
using ModernWMC.Services.Abstract;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace ModernWMC.Services.Concrete
{
    public class PurchaseOrderService : IPurchaseOrderService
    {
        private readonly IPurchaseOrderDal _purchaseOrderDal;
        private readonly IInventoryDal _inventoryDal;

        public PurchaseOrderService(IPurchaseOrderDal purchaseOrderDal, IInventoryDal inventoryDal)
        {
            _purchaseOrderDal = purchaseOrderDal;
            _inventoryDal = inventoryDal;
        }

        public async Task<IEnumerable<PurchaseOrder>> LoadAllAsync(Expression<Func<PurchaseOrder, bool>>? filter = null)
        {
            return await _purchaseOrderDal.LoadAll(filter);
        }

        public async Task<PurchaseOrder?> GetByIdAsync(int id)
        {
            return await _purchaseOrderDal.GetById(id);
        }

        public async Task<int> AddAsync(PurchaseOrder order)
        {
            return await _purchaseOrderDal.Add(order);
        }

        public async Task<bool> UpdateAsync(PurchaseOrder order)
        {
            return await _purchaseOrderDal.Update(order);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var order = await GetByIdAsync(id);
            if (order != null)
            {
                _purchaseOrderDal.Delete(order);
                return true;
            }
            return false;
        }

        public async Task<bool> ApproveAsync(int id)
        {
            var order = await GetByIdAsync(id);
            if (order == null || order.Status != "PendingApproval")
            {
                return false;
            }

            order.Status = "Ordered";
            order.UpdatedAt = DateTime.UtcNow;
            await _purchaseOrderDal.Update(order);
            return true;
        }

        public async Task<bool> CompleteAsync(int id)
        {
            var order = await GetByIdAsync(id);
            if (order == null || order.Status == "Completed")
            {
                return false;
            }

            order.Status = "Completed";
            order.UpdatedAt = DateTime.UtcNow;

            foreach (var item in order.Items)
            {
                var invItem = await _inventoryDal.GetById(item.InventoryId);
                if (invItem != null)
                {
                    // Find if there is an inventory item with the same SKU in the destination warehouse
                    var existingInv = (await _inventoryDal.LoadAll(
                        i => i.SKU == invItem.SKU && i.WarehouseId == order.WarehouseId
                    )).FirstOrDefault();

                    if (existingInv != null)
                    {
                        // Add quantity to existing inventory record in the destination warehouse
                        existingInv.Quantity += item.Quantity;
                        existingInv.UpdatedAt = DateTime.UtcNow;
                        await _inventoryDal.Update(existingInv);
                    }
                    else
                    {
                        // Create a new inventory record for the destination warehouse
                        var newInv = new Inventory
                        {
                            Name = invItem.Name,
                            SKU = invItem.SKU,
                            CategoryId = invItem.CategoryId,
                            MeasureUnitId = invItem.MeasureUnitId,
                            WarehouseId = order.WarehouseId,
                            LotNo = invItem.LotNo,
                            ExpirationDate = invItem.ExpirationDate,
                            ShelfLocation = invItem.ShelfLocation,
                            Quantity = item.Quantity,
                            CriticalLimit = invItem.CriticalLimit,
                            IsActive = true,
                            CreatedAt = DateTime.UtcNow,
                            UpdatedAt = DateTime.UtcNow
                        };
                        await _inventoryDal.Add(newInv);
                    }
                }
            }

            await _purchaseOrderDal.Update(order);
            return true;
        }
    }
}
