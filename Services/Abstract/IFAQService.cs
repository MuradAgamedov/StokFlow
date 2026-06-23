using ModernWMC.Models.Concrete;
using System.Linq.Expressions;
namespace ModernWMC.Services.Abstract
{
    public interface IFAQService
    {
        Task<IEnumerable<FAQ>> LoadAllAsync(Expression<Func<FAQ, bool>>? filter = null);
        Task<FAQ?> GetByIdAsync(int id);
        Task<int> AddAsync(FAQ faq);
        Task<bool> UpdateAsync(FAQ faq);
        Task<bool> DeleteAsync(int id);
    }
}
