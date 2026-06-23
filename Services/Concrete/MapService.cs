using ModernWMC.Data.Abstract;
using ModernWMC.Models.Concrete;
using ModernWMC.Services.Abstract;
using System.Linq.Expressions;

namespace ModernWMC.Services.Concrete
{
    public class MapService : IMapService
    {
        private readonly IMapDal _mapDal;

        public MapService(IMapDal mapDal)
        {
            _mapDal = mapDal;
        }

        public async Task<IEnumerable<Map>> LoadAllAsync(Expression<Func<Map, bool>>? filter = null)
        {
            return await _mapDal.LoadAll(filter);
        }

        public async Task<Map?> GetByIdAsync(int id)
        {
            return await _mapDal.GetById(id);
        }

        public async Task<int> AddAsync(Map map)
        {
            return await _mapDal.Add(map);
        }

        public async Task<bool> UpdateAsync(Map map)
        {
            return await _mapDal.Update(map);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var map = await GetByIdAsync(id);
            if (map != null)
            {
                _mapDal.Delete(map);
                return true;
            }
            return false;
        }
    }
}
