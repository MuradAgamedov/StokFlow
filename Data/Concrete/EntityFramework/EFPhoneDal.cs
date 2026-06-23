using ModernWMC.Data.Abstract;
using ModernWMC.Models.Concrete;

namespace ModernWMC.Data.Concrete.EntityFramework
{
    public class EFPhoneDal : EFEntityRepositoryBase<Phone, StokFlowAppContext>, IPhoneDal
    {
        public EFPhoneDal(StokFlowAppContext context) : base(context)
        {
        }
    }
}
