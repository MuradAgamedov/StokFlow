using ModernWMC.Data.Abstract;
using ModernWMC.Models.Concrete;

namespace ModernWMC.Data.Concrete.EntityFramework
{
    public class EFCompanyDal : EFEntityRepositoryBase<Company, StokFlowAppContext>, ICompanyDal
    {
        public EFCompanyDal(StokFlowAppContext context) : base(context)
        {
        }
    }
}
