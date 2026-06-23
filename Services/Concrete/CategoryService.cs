using ModernWMC.Data.Abstract;
using ModernWMC.Models.Concrete;
using ModernWMC.Services.Abstract;
using System.Linq.Expressions;

namespace ModernWMC.Services.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;

        public CategoryService(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public async Task<IEnumerable<Category>> LoadAllAsync(Expression<Func<Category, bool>>? filter = null)
        {
            return await _categoryDal.LoadAll(filter);
        }

        public async Task<Category?> GetByIdAsync(int id)
        {
            return await _categoryDal.GetById(id);
        }

        public async Task<int> AddAsync(Category category)
        {
            return await _categoryDal.Add(category);
        }

        public async Task<bool> UpdateAsync(Category category)
        {
            return await _categoryDal.Update(category);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var category = await GetByIdAsync(id);
            if (category != null)
            {
                _categoryDal.Delete(category);
                return true;
            }
            return false;
        }
    }
}
