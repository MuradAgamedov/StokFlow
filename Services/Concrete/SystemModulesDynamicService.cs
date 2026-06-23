using System.Linq.Expressions;
using ModernWMC.Data.Abstract;
using ModernWMC.Data.Concrete.EntityFramework;
using ModernWMC.Models.Concrete;
using ModernWMC.Services.Abstract;

namespace ModernWMC.Services.Concrete
{
    public class SystemModulesDynamicService : ISystemModulesDynamicService
    {
        private readonly ISystemModulesDynamicDal _systemModulesDynamicDal;

        public SystemModulesDynamicService(ISystemModulesDynamicDal systemModulesDynamicDal)
        {
            _systemModulesDynamicDal = systemModulesDynamicDal;
        }
        public async Task<IEnumerable<SystemModulesDynamic>> LoadAllAsync(Expression<Func<SystemModulesDynamic, bool>>? filter = null)
        {
            return await _systemModulesDynamicDal.LoadAll(filter);
        }

        public async Task<SystemModulesDynamic?> GetByIdAsync(int id)
        {
            return await _systemModulesDynamicDal.GetById(id);
        }

        public async Task<bool> UpdateAsync(SystemModulesDynamic entity)
        {
            return await _systemModulesDynamicDal.Update(entity);
        }
    }
}
