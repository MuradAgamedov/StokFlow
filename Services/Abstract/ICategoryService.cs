using ModernWMC.Models.Concrete;
using System.Linq.Expressions;

namespace ModernWMC.Services.Abstract
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> LoadAllAsync(Expression<Func<Category, bool>>? filter = null);
        Task<Category?> GetByIdAsync(int id);
        Task<int> AddAsync(Category category);
        Task<bool> UpdateAsync(Category category);
        Task<bool> DeleteAsync(int id);
    }
}
