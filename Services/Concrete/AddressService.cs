using ModernWMC.Data.Abstract;
using ModernWMC.Models.Concrete;
using ModernWMC.Services.Abstract;
using System.Linq.Expressions;

namespace ModernWMC.Services.Concrete
{
    public class AddressService : IAddressService
    {
        private readonly IAddressDal _addressDal;

        public AddressService(IAddressDal addressDal)
        {
            _addressDal = addressDal;
        }

        public async Task<IEnumerable<Address>> LoadAllAsync(Expression<Func<Address, bool>>? filter = null)
        {
            return await _addressDal.LoadAll(filter);
        }

        public async Task<Address?> GetByIdAsync(int id)
        {
            return await _addressDal.GetById(id);
        }

        public async Task<int> AddAsync(Address address)
        {
            return await _addressDal.Add(address);
        }

        public async Task<bool> UpdateAsync(Address address)
        {
            return await _addressDal.Update(address);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var address = await GetByIdAsync(id);
            if (address != null)
            {
                _addressDal.Delete(address);
                return true;
            }
            return false;
        }
    }
}
