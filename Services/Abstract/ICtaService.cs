using ModernWMC.Models.Concrete;

namespace ModernWMC.Services.Abstract
{
    public interface ICtaService
    {
        Task<Cta?> LoadAllAsync();
        Task<bool> UpdateAsync(Cta cta);
    }
}
