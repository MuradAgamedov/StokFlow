using ModernWMC.Data.Abstract;
using ModernWMC.Models.Concrete;

namespace ModernWMC.Data.Concrete.EntityFramework
{
    public class EFCategoryDal : EFEntityRepositoryBase<Category, StokFlowAppContext>, ICategoryDal
    {
        public EFCategoryDal(StokFlowAppContext context) : base(context)
        {
        }
    }
}
