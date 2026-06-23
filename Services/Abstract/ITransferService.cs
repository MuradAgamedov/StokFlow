using ModernWMC.Models.Concrete;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System;

namespace ModernWMC.Services.Abstract
{
    public interface ITransferService
    {
        Task<IEnumerable<Transfer>> LoadAllAsync(Expression<Func<Transfer, bool>>? filter = null);
        Task<Transfer?> GetByIdAsync(int id);
        Task<int> AddAndShipAsync(Transfer transfer);
        Task<bool> UpdateAsync(Transfer transfer);
        Task<bool> DeleteAsync(int id);

        Task<bool> CompleteAsync(int id);
    }
}
