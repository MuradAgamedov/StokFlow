using ModernWMC.Data.Abstract;
using ModernWMC.Models.Concrete;
using ModernWMC.Services.Abstract;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System;

namespace ModernWMC.Services.Concrete
{
    public class WarehouseService : IWarehouseService
    {
        private readonly IWarehouseDal _warehouseDal;

        public WarehouseService(IWarehouseDal warehouseDal)
        {
            _warehouseDal = warehouseDal;
        }

        public async Task<IEnumerable<Warehouse>> LoadAllAsync(Expression<Func<Warehouse, bool>>? filter = null)
        {
            return await _warehouseDal.LoadAll(filter);
        }

        public async Task<Warehouse?> GetByIdAsync(int id)
        {
            return await _warehouseDal.GetById(id);
        }

        public async Task<int> AddAsync(Warehouse warehouse)
        {
            return await _warehouseDal.Add(warehouse);
        }

        public async Task<bool> UpdateAsync(Warehouse warehouse)
        {
            return await _warehouseDal.Update(warehouse);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var warehouse = await GetByIdAsync(id);
            if (warehouse != null)
            {
                _warehouseDal.Delete(warehouse);
                return true;
            }
            return false;
        }
    }
}
