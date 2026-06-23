using ModernWMC.Data.Abstract;
using ModernWMC.Models.Concrete;

namespace ModernWMC.Data.Concrete.EntityFramework
{
    public class EFSystemModulesDynamicDal : EFEntityRepositoryBase<SystemModulesDynamic, StokFlowAppContext>, ISystemModulesDynamicDal
    {
        public EFSystemModulesDynamicDal(StokFlowAppContext context) : base(context)
        {
        }
    }
}
