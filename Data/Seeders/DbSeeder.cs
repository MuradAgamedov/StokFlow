using ModernWMC.Data.Concrete.EntityFramework;
using ModernWMC.Models.Concrete;

namespace ModernWMC.Data.Seeders
{
    public static class DbSeeder
    {
        public static void Seed(StokFlowAppContext context)
        {
            AboutSeeder.Seed(context);
            PrivacyPolicySeeder.Seed(context);
            TermsOfUseSeeder.Seed(context);
            HeroSeeder.Seed(context);
            SystemModulesStaticSeeder.Seed(context);
            SystemModulesDynamicSeeder.Seed(context);
            StatisticsSeeder.Seed(context);
            FAQSeeder.Seed(context);
            ContactSeeder.Seed(context);
            CtaSeeder.Seed(context);
            CategorySeeder.Seed(context);
            WarehouseSeeder.Seed(context);
            MeasureUnitSeeder.Seed(context);
            InventorySeeder.Seed(context);
            CompanySeeder.Seed(context);
            PurchaseOrderSeeder.Seed(context);
            TransferSeeder.Seed(context);
        }
    }
}
