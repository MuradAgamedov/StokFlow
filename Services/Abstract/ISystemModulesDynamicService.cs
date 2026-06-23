using System.Linq.Expressions;
using ModernWMC.Models.Concrete;

namespace ModernWMC.Services.Abstract
{
    public interface ISystemModulesDynamicService
    {
        Task<IEnumerable<SystemModulesDynamic>> LoadAllAsync(Expression<Func<SystemModulesDynamic, bool>>? filter = null);
        Task<SystemModulesDynamic?> GetByIdAsync(int id);
        Task<bool> UpdateAsync(SystemModulesDynamic entity);
    }
}
