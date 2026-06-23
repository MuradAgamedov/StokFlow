using ModernWMC.Data.Abstract;
using ModernWMC.Models.Concrete;

namespace ModernWMC.Data.Concrete.EntityFramework
{
    public class EFStatisticsDal : EFEntityRepositoryBase<Statistics, StokFlowAppContext>, IStatisticsDal
    {
        public EFStatisticsDal(StokFlowAppContext context) : base(context)
        {
        }
    }
}
