using ModernWMC.Data.Abstract;
using ModernWMC.Models.Concrete;

namespace ModernWMC.Data.Concrete.EntityFramework
{
    public class EFAddressDal : EFEntityRepositoryBase<Address, StokFlowAppContext>, IAddressDal
    {
        public EFAddressDal(StokFlowAppContext context) : base(context)
        {
        }
    }
}
