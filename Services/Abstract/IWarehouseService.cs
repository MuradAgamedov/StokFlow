using ModernWMC.Models.Concrete;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System;

namespace ModernWMC.Services.Abstract
{
    public interface IWarehouseService
    {
        Task<IEnumerable<Warehouse>> LoadAllAsync(Expression<Func<Warehouse, bool>>? filter = null);
        Task<Warehouse?> GetByIdAsync(int id);
        Task<int> AddAsync(Warehouse warehouse);
        Task<bool> UpdateAsync(Warehouse warehouse);
        Task<bool> DeleteAsync(int id);
    }
}
