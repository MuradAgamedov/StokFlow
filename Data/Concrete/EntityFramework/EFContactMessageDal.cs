using ModernWMC.Data.Abstract;
using ModernWMC.Models.Concrete;

namespace ModernWMC.Data.Concrete.EntityFramework
{
    public class EFContactMessageDal : EFEntityRepositoryBase<ContactMessage, StokFlowAppContext>, IContactMessageDal
    {
        public EFContactMessageDal(StokFlowAppContext context) : base(context)
        {
        }
    }
}
