using ModernWMC.Models.Concrete;

namespace ModernWMC.Services.Abstract
{
    public interface ITermsOfUseService
    {
        Task<TermsOfUse>? LoadFirstAsync();
        Task<bool> UpdateAsync(TermsOfUse termsOfUse);
    }
}
