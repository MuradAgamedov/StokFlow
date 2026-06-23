using ModernWMC.Models.Concrete;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System;

namespace ModernWMC.Services.Abstract
{
    public interface IPurchaseOrderService
    {
        Task<IEnumerable<PurchaseOrder>> LoadAllAsync(Expression<Func<PurchaseOrder, bool>>? filter = null);
        Task<PurchaseOrder?> GetByIdAsync(int id);
        Task<int> AddAsync(PurchaseOrder order);
        Task<bool> UpdateAsync(PurchaseOrder order);
        Task<bool> DeleteAsync(int id);

        Task<bool> ApproveAsync(int id);
        Task<bool> CompleteAsync(int id);
    }
}
