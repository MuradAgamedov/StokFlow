using ModernWMC.Models.Concrete;

namespace ModernWMC.Areas.Admin.ViewModels
{
    public class FeaturesViewModel
    {
        public SystemModulesStaticViewModel StaticHeaders { get; set; }
        public IEnumerable<SystemModulesDynamic> SystemModulesDynamics { get; set; }
        public SystemModulesDynamicViewModel SelectedCard { get; set; }
    }
}
