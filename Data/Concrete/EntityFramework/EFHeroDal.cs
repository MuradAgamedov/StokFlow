using ModernWMC.Data.Abstract;
using ModernWMC.Models.Concrete;

namespace ModernWMC.Data.Concrete.EntityFramework
{
    public class EFHeroDal : EFEntityRepositoryBase<Hero, StokFlowAppContext>, IHeroDal
    {
        public EFHeroDal(StokFlowAppContext context) : base(context)
        {
        }
    }
}
