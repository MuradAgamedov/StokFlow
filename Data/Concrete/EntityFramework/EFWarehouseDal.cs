using ModernWMC.Data.Abstract;
using ModernWMC.Models.Concrete;

namespace ModernWMC.Data.Concrete.EntityFramework
{
    public class EFWarehouseDal : EFEntityRepositoryBase<Warehouse, StokFlowAppContext>, IWarehouseDal
    {
        public EFWarehouseDal(StokFlowAppContext context) : base(context)
        {
        }
    }
}
