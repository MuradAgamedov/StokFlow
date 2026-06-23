using ModernWMC.Data.Abstract;
using ModernWMC.Models.Concrete;
using ModernWMC.Services.Abstract;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System;

namespace ModernWMC.Services.Concrete
{
    public class InventoryService : IInventoryService
    {
        private readonly IInventoryDal _inventoryDal;

        public InventoryService(IInventoryDal inventoryDal)
        {
            _inventoryDal = inventoryDal;
        }

        public async Task<IEnumerable<Inventory>> LoadAllAsync(Expression<Func<Inventory, bool>>? filter = null)
        {
            return await _inventoryDal.LoadAll(filter);
        }

        public async Task<Inventory?> GetByIdAsync(int id)
        {
            return await _inventoryDal.GetById(id);
        }

        public async Task<int> AddAsync(Inventory inventory)
        {
            return await _inventoryDal.Add(inventory);
        }

        public async Task<bool> UpdateAsync(Inventory inventory)
        {
            return await _inventoryDal.Update(inventory);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var inventory = await GetByIdAsync(id);
            if (inventory != null)
            {
                _inventoryDal.Delete(inventory);
                return true;
            }
            return false;
        }
    }
}
