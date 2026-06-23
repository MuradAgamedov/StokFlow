using ModernWMC.Data.Abstract;
using ModernWMC.Models.Concrete;
using ModernWMC.Services.Abstract;
using System.Linq.Expressions;

namespace ModernWMC.Services.Concrete
{
    public class PhoneService : IPhoneService
    {
        private readonly IPhoneDal _phoneDal;

        public PhoneService(IPhoneDal phoneDal)
        {
            _phoneDal = phoneDal;
        }

        public async Task<IEnumerable<Phone>> LoadAllAsync(Expression<Func<Phone, bool>>? filter = null)
        {
            return await _phoneDal.LoadAll(filter);
        }

        public async Task<Phone?> GetByIdAsync(int id)
        {
            return await _phoneDal.GetById(id);
        }

        public async Task<int> AddAsync(Phone phone)
        {
            return await _phoneDal.Add(phone);
        }

        public async Task<bool> UpdateAsync(Phone phone)
        {
            return await _phoneDal.Update(phone);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var phone = await GetByIdAsync(id);
            if (phone != null)
            {
                _phoneDal.Delete(phone);
                return true;
            }
            return false;
        }
    }
}
