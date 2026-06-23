using ModernWMC.Data.Abstract;
using ModernWMC.Models.Concrete;
using ModernWMC.Services.Abstract;

namespace ModernWMC.Services.Concrete
{
    public class PrivacyPolicyService : IPrivacyPolicyService
    {
        private readonly IPrivacyPolicyDal _privacyPolicyDal;

        public PrivacyPolicyService(IPrivacyPolicyDal privacyPolicyDal)
        {
            _privacyPolicyDal = privacyPolicyDal;
        }

        public async Task<PrivacyPolicy>? LoadFirstAsync()
        {
            return await _privacyPolicyDal.LoadFirst();
        }

        public async Task<bool> UpdateAsync(PrivacyPolicy privacyPolicy)
        {
            return await _privacyPolicyDal.Update(privacyPolicy);
        }
    }
}
