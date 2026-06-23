using ModernWMC.Models.Concrete;

namespace ModernWMC.Services.Abstract
{
    public interface ISystemModulesStaticService
    {
        Task<SystemModulesStatic>? LoadFirstAsync();
        Task<bool> UpdateAsync(SystemModulesStatic entity);
    }
}
