using ModernWMC.Models.Concrete;
using System.Linq.Expressions;

namespace ModernWMC.Services.Abstract
{
    public interface IMapService
    {
        Task<IEnumerable<Map>> LoadAllAsync(Expression<Func<Map, bool>>? filter = null);
        Task<Map?> GetByIdAsync(int id);
        Task<int> AddAsync(Map map);
        Task<bool> UpdateAsync(Map map);
        Task<bool> DeleteAsync(int id);
    }
}
