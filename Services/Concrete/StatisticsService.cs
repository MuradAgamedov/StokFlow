using ModernWMC.Data.Abstract;
using ModernWMC.Data.Concrete.EntityFramework;
using ModernWMC.Models.Concrete;
using ModernWMC.Services.Abstract;
using System.Linq.Expressions;

namespace ModernWMC.Services.Concrete
{
    public class StatisticsService : IStatisticsService
    {
        private readonly IStatisticsDal _statisticsDal;

        public StatisticsService(IStatisticsDal statisticsDal)
        {
            _statisticsDal = statisticsDal;
        }

        public async Task<IEnumerable<Statistics>> LoadAllAsync(Expression<Func<Statistics, bool>>? filter = null)
        {
            return await _statisticsDal.LoadAll(filter);
        }

        public async Task<Statistics?> GetByIdAsync(int id)
        {
            return await _statisticsDal.GetById(id);
        }

        public async Task<int> AddAsync(Statistics statistics)
        {
            return await _statisticsDal.Add(statistics);
        }

        public async Task<bool> UpdateAsync(Statistics statistics)
        {
            return await _statisticsDal.Update(statistics);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var stats = await GetByIdAsync(id);
            if (stats != null)
            {
                _statisticsDal.Delete(stats);
                return true;
            }
            return false;
        }
    }
}
