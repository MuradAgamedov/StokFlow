using ModernWMC.Data.Abstract;
using ModernWMC.Models.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ModernWMC.Data.Concrete.EntityFramework
{
    public class EFEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
       where TEntity : class, IEntity, new()
       where TContext : DbContext
    {
        protected readonly TContext _context;

        public EFEntityRepositoryBase(TContext context)
        {
            _context = context;
        }

        public async Task<int> Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            int result = await _context.SaveChangesAsync();
            return result;
        }

        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<TEntity>> LoadAll(Expression<Func<TEntity, bool>>? filter = null)
        {
            return filter == null
                ? _context.Set<TEntity>().ToList()
                : _context.Set<TEntity>().Where(filter).ToList();
        }

        public TEntity? LoadOne(Expression<Func<TEntity, bool>> filter)
        {
            return _context.Set<TEntity>().SingleOrDefault(filter);
        }

        public async Task<TEntity?> LoadFirst()
        {
            return await _context.Set<TEntity>()
                .OrderBy(d => d.Id)
                .FirstOrDefaultAsync();
        }

        public async Task<TEntity?> GetById(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task<bool> Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            int result = await _context.SaveChangesAsync();
            return result > 0;
        }
    }
}