using ModernWMC.Models.Concrete;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System;

namespace ModernWMC.Services.Abstract
{
    public interface IInventoryService
    {
        Task<IEnumerable<Inventory>> LoadAllAsync(Expression<Func<Inventory, bool>>? filter = null);
        Task<Inventory?> GetByIdAsync(int id);
        Task<int> AddAsync(Inventory inventory);
        Task<bool> UpdateAsync(Inventory inventory);
        Task<bool> DeleteAsync(int id);
    }
}
