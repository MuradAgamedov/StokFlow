using ModernWMC.Models.Concrete;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System;

namespace ModernWMC.Services.Abstract
{
    public interface ICompanyService
    {
        Task<IEnumerable<Company>> LoadAllAsync(Expression<Func<Company, bool>>? filter = null);
        Task<Company?> GetByIdAsync(int id);
        Task<int> AddAsync(Company company);
        Task<bool> UpdateAsync(Company company);
        Task<bool> DeleteAsync(int id);
    }
}
