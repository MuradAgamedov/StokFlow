using ModernWMC.Models.Concrete;
using ModernWMC.Models.Abstract;
using ModernWMC.Data.Abstract;

namespace ModernWMC.Data.Concrete.EntityFramework
{
    public class EFAboutDal : EFEntityRepositoryBase<About, StokFlowAppContext>, IAboutDal
    {
        public EFAboutDal(StokFlowAppContext context) : base(context)
        {
        }
    }
}
