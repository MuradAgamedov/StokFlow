using ModernWMC.Data.Abstract;
using ModernWMC.Data.Concrete.EntityFramework;
using ModernWMC.Models.Concrete;
using ModernWMC.Services.Abstract;

namespace ModernWMC.Services.Concrete
{
    public class SystemModulesStaticService : ISystemModulesStaticService
    {
        private readonly ISystemModulesStaticDal _systemModulesStaticDal;

        public SystemModulesStaticService(ISystemModulesStaticDal systemModulesStaticDal)
        {
            _systemModulesStaticDal = systemModulesStaticDal;
        }

        public async Task<SystemModulesStatic>? LoadFirstAsync()
        {
            return await _systemModulesStaticDal.LoadFirst();
        }

        public async Task<bool> UpdateAsync(SystemModulesStatic entity)
        {
            return await _systemModulesStaticDal.Update(entity);
        }
    }
}
