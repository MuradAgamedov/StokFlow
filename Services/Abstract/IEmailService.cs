using ModernWMC.Models.Concrete;
using System.Linq.Expressions;

namespace ModernWMC.Services.Abstract
{
    public interface IEmailService
    {
        Task<IEnumerable<Email>> LoadAllAsync(Expression<Func<Email, bool>>? filter = null);
        Task<Email?> GetByIdAsync(int id);
        Task<int> AddAsync(Email email);
        Task<bool> UpdateAsync(Email email);
        Task<bool> DeleteAsync(int id);
    }
}
