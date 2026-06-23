using ModernWMC.Data.Abstract;
using ModernWMC.Models.Concrete;

namespace ModernWMC.Data.Concrete.EntityFramework
{
    public class EFPrivacyPolicyDal : EFEntityRepositoryBase<PrivacyPolicy, StokFlowAppContext>, IPrivacyPolicyDal
    {
        public EFPrivacyPolicyDal(StokFlowAppContext context) : base(context)
        {
        }
    }
}
