using ModernWMC.Data.Abstract;
using ModernWMC.Models.Concrete;

namespace ModernWMC.Data.Concrete.EntityFramework
{
    public class EFFAQDal : EFEntityRepositoryBase<FAQ, StokFlowAppContext>, IFAQDal
    {
        public EFFAQDal(StokFlowAppContext context) : base(context)
        {
        }
    }
}
