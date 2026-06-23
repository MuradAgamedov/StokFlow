using ModernWMC.Models.Concrete;

namespace ModernWMC.ViewModels
{
    public class HomeViewModel
    {
        public Hero? Hero { get; set; }
        public SystemModulesStatic? SystemModulesStatic { get; set; }
        public IEnumerable<SystemModulesDynamic>? SystemModulesDynamics { get; set; }
        public IEnumerable<Statistics>? Statistics { get; set; }


    }
}
