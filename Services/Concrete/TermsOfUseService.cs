using ModernWMC.Data.Abstract;
using ModernWMC.Models.Concrete;
using ModernWMC.Services.Abstract;

namespace ModernWMC.Services.Concrete
{
    public class TermsOfUseService : ITermsOfUseService
    {
        private readonly ITermsOfUseDal _termsOfUseDal;

        public TermsOfUseService(ITermsOfUseDal termsOfUseDal)
        {
            _termsOfUseDal = termsOfUseDal;
        }

        public async Task<TermsOfUse>? LoadFirstAsync()
        {
            return await _termsOfUseDal.LoadFirst();
        }

        public async Task<bool> UpdateAsync(TermsOfUse termsOfUse)
        {
            return await _termsOfUseDal.Update(termsOfUse);
        }
    }
}
