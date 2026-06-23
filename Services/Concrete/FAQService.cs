using ModernWMC.Data.Abstract;
using ModernWMC.Models.Concrete;
using ModernWMC.Services.Abstract;
using System.Linq.Expressions;
namespace ModernWMC.Services.Concrete
{
    public class FAQService : IFAQService
    {
        private readonly IFAQDal _faqDal;

        public FAQService(IFAQDal faqDal)
        {
            _faqDal = faqDal;
        }

        public async Task<IEnumerable<FAQ>> LoadAllAsync(Expression<Func<FAQ, bool>>? filter = null)
        {
            return await _faqDal.LoadAll(filter);
        }

        public async Task<FAQ?> GetByIdAsync(int id)
        {
            return await _faqDal.GetById(id);
        }

        public async Task<int> AddAsync(FAQ faq)
        {
            return await _faqDal.Add(faq);
        }

        public async Task<bool> UpdateAsync(FAQ faq)
        {
            return await _faqDal.Update(faq);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var faq = await GetByIdAsync(id);
            if (faq != null)
            {
                _faqDal.Delete(faq);
                return true;
            }
            return false;
        }
    }
}
