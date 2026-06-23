using ModernWMC.Data.Abstract;
using ModernWMC.Models.Concrete;

namespace ModernWMC.Data.Concrete.EntityFramework
{
    public class EFMapDal : EFEntityRepositoryBase<Map, StokFlowAppContext>, IMapDal
    {
        public EFMapDal(StokFlowAppContext context) : base(context)
        {
        }
    }
}
