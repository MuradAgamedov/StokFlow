using ModernWMC.Models.Concrete;
using System.Linq.Expressions;

namespace ModernWMC.Services.Abstract
{
    public interface IStatisticsService
    {
        Task<IEnumerable<Statistics>> LoadAllAsync(Expression<Func<Statistics, bool>>? filter = null);
        Task<Statistics?> GetByIdAsync(int id);
        Task<int> AddAsync(Statistics statistics);
        Task<bool> UpdateAsync(Statistics statistics);
        Task<bool> DeleteAsync(int id);
    }
}
