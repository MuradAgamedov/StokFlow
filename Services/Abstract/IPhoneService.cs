using ModernWMC.Models.Concrete;
using System.Linq.Expressions;

namespace ModernWMC.Services.Abstract
{
    public interface IPhoneService
    {
        Task<IEnumerable<Phone>> LoadAllAsync(Expression<Func<Phone, bool>>? filter = null);
        Task<Phone?> GetByIdAsync(int id);
        Task<int> AddAsync(Phone phone);
        Task<bool> UpdateAsync(Phone phone);
        Task<bool> DeleteAsync(int id);
    }
}
