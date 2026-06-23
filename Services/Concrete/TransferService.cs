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
    public class TransferService : ITransferService
    {
        private readonly ITransferDal _transferDal;
        private readonly IInventoryDal _inventoryDal;

        public TransferService(ITransferDal transferDal, IInventoryDal inventoryDal)
        {
            _transferDal = transferDal;
            _inventoryDal = inventoryDal;
        }

        public async Task<IEnumerable<Transfer>> LoadAllAsync(Expression<Func<Transfer, bool>>? filter = null)
        {
            return await _transferDal.LoadAll(filter);
        }

        public async Task<Transfer?> GetByIdAsync(int id)
        {
            return await _transferDal.GetById(id);
        }

        public async Task<int> AddAndShipAsync(Transfer transfer)
        {
            foreach (var item in transfer.Items)
            {
                var srcInventory = await _inventoryDal.GetById(item.InventoryId);
                if (srcInventory == null)
                {
                    throw new InvalidOperationException("Məhsul tapılmadı.");
                }

                if (srcInventory.Quantity < item.Quantity)
                {
                    throw new InvalidOperationException($"'{srcInventory.Name}' məhsulundan mənbə anbarında kifayət qədər yoxdur. Mövcud stok: {srcInventory.Quantity} {srcInventory.MeasureUnit?.Code ?? "ədəd"}.");
                }

                // Decrement stock from source warehouse
                srcInventory.Quantity -= item.Quantity;
                srcInventory.UpdatedAt = DateTime.UtcNow;
                await _inventoryDal.Update(srcInventory);
            }

            return await _transferDal.Add(transfer);
        }

        public async Task<bool> UpdateAsync(Transfer transfer)
        {
            return await _transferDal.Update(transfer);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var transfer = await GetByIdAsync(id);
            if (transfer != null)
            {
                _transferDal.Delete(transfer);
                return true;
            }
            return false;
        }

        public async Task<bool> CompleteAsync(int id)
        {
            var transfer = await GetByIdAsync(id);
            if (transfer == null || transfer.Status == "Completed")
            {
                return false;
            }

            transfer.Status = "Completed";
            transfer.UpdatedAt = DateTime.UtcNow;

            foreach (var item in transfer.Items)
            {
                var srcInventory = await _inventoryDal.GetById(item.InventoryId);
                if (srcInventory != null)
                {
                    // Find if there is an inventory item with the same SKU in the destination warehouse
                    var existingDestInv = (await _inventoryDal.LoadAll(
                        i => i.SKU == srcInventory.SKU && i.WarehouseId == transfer.DestinationWarehouseId
                    )).FirstOrDefault();

                    if (existingDestInv != null)
                    {
                        // Add quantity to existing record in destination warehouse
                        existingDestInv.Quantity += item.Quantity;
                        existingDestInv.UpdatedAt = DateTime.UtcNow;
                        await _inventoryDal.Update(existingDestInv);
                    }
                    else
                    {
                        // Create new inventory record in destination warehouse
                        var newInv = new Inventory
                        {
                            Name = srcInventory.Name,
                            SKU = srcInventory.SKU,
                            CategoryId = srcInventory.CategoryId,
                            MeasureUnitId = srcInventory.MeasureUnitId,
                            WarehouseId = transfer.DestinationWarehouseId,
                            LotNo = srcInventory.LotNo,
                            ExpirationDate = srcInventory.ExpirationDate,
                            ShelfLocation = srcInventory.ShelfLocation,
                            Quantity = item.Quantity,
                            CriticalLimit = srcInventory.CriticalLimit,
                            IsActive = true,
                            CreatedAt = DateTime.UtcNow,
                            UpdatedAt = DateTime.UtcNow
                        };
                        await _inventoryDal.Add(newInv);
                    }
                }
            }

            await _transferDal.Update(transfer);
            return true;
        }
    }
}
