using ModernWMC.Data.Abstract;
using ModernWMC.Models.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace ModernWMC.Data.Concrete.EntityFramework
{
    public class EFInventoryDal : EFEntityRepositoryBase<Inventory, StokFlowAppContext>, IInventoryDal
    {
        public EFInventoryDal(StokFlowAppContext context) : base(context)
        {
        }

        public new async Task<IEnumerable<Inventory>> LoadAll(Expression<Func<Inventory, bool>>? filter = null)
        {
            var query = _context.Inventories
                .Include(i => i.Category)
                .Include(i => i.MeasureUnit)
                .Include(i => i.Warehouse)
                .AsQueryable();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return await query.ToListAsync();
        }

        public new async Task<Inventory?> GetById(int id)
        {
            return await _context.Inventories
                .Include(i => i.Category)
                .Include(i => i.MeasureUnit)
                .Include(i => i.Warehouse)
                .FirstOrDefaultAsync(i => i.Id == id);
        }
    }
}
