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
    public class EFPurchaseOrderDal : EFEntityRepositoryBase<PurchaseOrder, StokFlowAppContext>, IPurchaseOrderDal
    {
        public EFPurchaseOrderDal(StokFlowAppContext context) : base(context)
        {
        }

        public new async Task<IEnumerable<PurchaseOrder>> LoadAll(Expression<Func<PurchaseOrder, bool>>? filter = null)
        {
            var query = _context.PurchaseOrders
                .Include(po => po.Supplier)
                .Include(po => po.Warehouse)
                .Include(po => po.Items)
                    .ThenInclude(poi => poi.Inventory)
                        .ThenInclude(inv => inv!.MeasureUnit)
                .AsQueryable();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return await query.ToListAsync();
        }

        public new async Task<PurchaseOrder?> GetById(int id)
        {
            return await _context.PurchaseOrders
                .Include(po => po.Supplier)
                .Include(po => po.Warehouse)
                .Include(po => po.Items)
                    .ThenInclude(poi => poi.Inventory)
                        .ThenInclude(inv => inv!.MeasureUnit)
                .FirstOrDefaultAsync(po => po.Id == id);
        }
    }
}
