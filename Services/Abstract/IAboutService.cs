using ModernWMC.Models.Concrete;

namespace ModernWMC.Services.Abstract
{
    public interface IAboutService
    {
        Task<About>? LoadFirstAsync();
        Task<bool>? UpdateAsync(About entity);
    }
}
