using ModernWMC.Data.Abstract;
using ModernWMC.Models.Concrete;

namespace ModernWMC.Data.Concrete.EntityFramework
{
    public class EFSystemModulesStaticDal : EFEntityRepositoryBase<SystemModulesStatic, StokFlowAppContext>, ISystemModulesStaticDal
    {
        public EFSystemModulesStaticDal(StokFlowAppContext context) : base(context)
        {
        }
    }
}
