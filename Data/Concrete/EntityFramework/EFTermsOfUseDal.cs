using ModernWMC.Data.Abstract;
using ModernWMC.Models.Concrete;

namespace ModernWMC.Data.Concrete.EntityFramework
{
    public class EFTermsOfUseDal : EFEntityRepositoryBase<TermsOfUse, StokFlowAppContext>, ITermsOfUseDal
    {
        public EFTermsOfUseDal(StokFlowAppContext context) : base(context)
        {
        }
    }
}
