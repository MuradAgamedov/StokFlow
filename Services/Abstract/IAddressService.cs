using ModernWMC.Models.Concrete;
using System.Linq.Expressions;

namespace ModernWMC.Services.Abstract
{
    public interface IAddressService
    {
        Task<IEnumerable<Address>> LoadAllAsync(Expression<Func<Address, bool>>? filter = null);
        Task<Address?> GetByIdAsync(int id);
        Task<int> AddAsync(Address address);
        Task<bool> UpdateAsync(Address address);
        Task<bool> DeleteAsync(int id);
    }
}
