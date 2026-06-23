using ModernWMC.Data.Abstract;
using ModernWMC.Models.Concrete;

namespace ModernWMC.Data.Concrete.EntityFramework
{
    public class EFEmailDal : EFEntityRepositoryBase<Email, StokFlowAppContext>, IEmailDal
    {
        public EFEmailDal(StokFlowAppContext context) : base(context)
        {
        }
    }
}
