using ModernWMC.Models.Concrete;

namespace ModernWMC.Services.Abstract
{
    public interface IPrivacyPolicyService
    {
        Task<PrivacyPolicy>? LoadFirstAsync();
        Task<bool> UpdateAsync(PrivacyPolicy privacyPolicy);
    }
}
