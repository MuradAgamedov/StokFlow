using ModernWMC.Data.Abstract;
using ModernWMC.Models.Concrete;

namespace ModernWMC.Data.Concrete.EntityFramework
{
    public class EFMeasureUnitDal : EFEntityRepositoryBase<MeasureUnit, StokFlowAppContext>, IMeasureUnitDal
    {
        public EFMeasureUnitDal(StokFlowAppContext context) : base(context)
        {
        }
    }
}
