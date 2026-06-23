using ModernWMC.Data.Abstract;
using ModernWMC.Data.Concrete.EntityFramework;
using ModernWMC.Models.Concrete;
using ModernWMC.Services.Abstract;

namespace ModernWMC.Services.Concrete
{
    public class AboutService : IAboutService
    {
        private readonly IAboutDal _aboutDal;

        public AboutService(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public async Task<About>? LoadFirstAsync()
        {
            return await _aboutDal.LoadFirst();
        }

        public async Task<bool>? UpdateAsync(About entity)
        {
            return await _aboutDal.Update(entity);
        }

    }
}
