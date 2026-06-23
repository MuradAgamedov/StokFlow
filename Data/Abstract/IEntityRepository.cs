using System.Linq.Expressions;
using ModernWMC.Models.Abstract;

namespace ModernWMC.Data.Abstract
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        Task<IEnumerable<T>> LoadAll(Expression<Func<T, bool>>? filter = null);
        public T LoadOne(Expression<Func<T, bool>> filter);
        Task<T> LoadFirst();
        public Task<T?> GetById(int id);

        public Task<int> Add(T entity);
        public Task<bool> Update(T entity);
        public void Delete(T entity);
    }
}
