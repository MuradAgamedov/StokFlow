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
    public class EFTransferDal : EFEntityRepositoryBase<Transfer, StokFlowAppContext>, ITransferDal
    {
        public EFTransferDal(StokFlowAppContext context) : base(context)
        {
        }

        public new async Task<IEnumerable<Transfer>> LoadAll(Expression<Func<Transfer, bool>>? filter = null)
        {
            var query = _context.Transfers
                .Include(t => t.SourceWarehouse)
                .Include(t => t.DestinationWarehouse)
                .Include(t => t.Items)
                    .ThenInclude(ti => ti.Inventory)
                        .ThenInclude(inv => inv!.MeasureUnit)
                .AsQueryable();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return await query.ToListAsync();
        }

        public new async Task<Transfer?> GetById(int id)
        {
            return await _context.Transfers
                .Include(t => t.SourceWarehouse)
                .Include(t => t.DestinationWarehouse)
                .Include(t => t.Items)
                    .ThenInclude(ti => ti.Inventory)
                        .ThenInclude(inv => inv!.MeasureUnit)
                .FirstOrDefaultAsync(t => t.Id == id);
        }
    }
}
