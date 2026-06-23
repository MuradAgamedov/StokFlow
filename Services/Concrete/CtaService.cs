using ModernWMC.Data.Abstract;
using ModernWMC.Models.Concrete;
using ModernWMC.Services.Abstract;

namespace ModernWMC.Services.Concrete
{
    public class CtaService : ICtaService
    {
        private readonly ICtaDal _ctaDal;

        public CtaService(ICtaDal ctaDal)
        {
            _ctaDal = ctaDal;
        }

        public async Task<Cta?> LoadAllAsync()
        {
            var list = await _ctaDal.LoadAll();
            return list.FirstOrDefault();
        }

        public async Task<bool> UpdateAsync(Cta cta)
        {
            return await _ctaDal.Update(cta);
        }
    }
}
