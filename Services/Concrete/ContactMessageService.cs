using ModernWMC.Data.Abstract;
using ModernWMC.Data.Concrete.EntityFramework;
using ModernWMC.Models.Abstract;
using ModernWMC.Models.Concrete;
using ModernWMC.Services.Abstract;

namespace ModernWMC.Services.Concrete
{
    public class ContactMessageService : IContactMessageService
    {
        private readonly IContactMessageDal _contactMessageDal;

        public ContactMessageService(IContactMessageDal contactMessageDal)
        {
            _contactMessageDal = contactMessageDal;
        }

        public async Task<int>? AddAsync(ContactMessage entity)
        {
            return await _contactMessageDal.Add(entity);
        }
    }
}
