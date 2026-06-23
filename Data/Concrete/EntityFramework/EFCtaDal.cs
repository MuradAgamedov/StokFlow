using ModernWMC.Data.Abstract;
using ModernWMC.Models.Concrete;

namespace ModernWMC.Data.Concrete.EntityFramework
{
    public class EFCtaDal : EFEntityRepositoryBase<Cta, StokFlowAppContext>, ICtaDal
    {
        public EFCtaDal(StokFlowAppContext context) : base(context)
        {
        }
    }
}
