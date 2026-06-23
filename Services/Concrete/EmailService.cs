using ModernWMC.Data.Abstract;
using ModernWMC.Models.Concrete;
using ModernWMC.Services.Abstract;
using System.Linq.Expressions;

namespace ModernWMC.Services.Concrete
{
    public class EmailService : IEmailService
    {
        private readonly IEmailDal _emailDal;

        public EmailService(IEmailDal emailDal)
        {
            _emailDal = emailDal;
        }

        public async Task<IEnumerable<Email>> LoadAllAsync(Expression<Func<Email, bool>>? filter = null)
        {
            return await _emailDal.LoadAll(filter);
        }

        public async Task<Email?> GetByIdAsync(int id)
        {
            return await _emailDal.GetById(id);
        }

        public async Task<int> AddAsync(Email email)
        {
            return await _emailDal.Add(email);
        }

        public async Task<bool> UpdateAsync(Email email)
        {
            return await _emailDal.Update(email);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var email = await GetByIdAsync(id);
            if (email != null)
            {
                _emailDal.Delete(email);
                return true;
            }
            return false;
        }
    }
}
