using ModernWMC.Data.Abstract;
using ModernWMC.Models.Concrete;
using ModernWMC.Services.Abstract;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System;

namespace ModernWMC.Services.Concrete
{
    public class MeasureUnitService : IMeasureUnitService
    {
        private readonly IMeasureUnitDal _measureUnitDal;

        public MeasureUnitService(IMeasureUnitDal measureUnitDal)
        {
            _measureUnitDal = measureUnitDal;
        }

        public async Task<IEnumerable<MeasureUnit>> LoadAllAsync(Expression<Func<MeasureUnit, bool>>? filter = null)
        {
            return await _measureUnitDal.LoadAll(filter);
        }

        public async Task<MeasureUnit?> GetByIdAsync(int id)
        {
            return await _measureUnitDal.GetById(id);
        }

        public async Task<int> AddAsync(MeasureUnit measureUnit)
        {
            return await _measureUnitDal.Add(measureUnit);
        }

        public async Task<bool> UpdateAsync(MeasureUnit measureUnit)
        {
            return await _measureUnitDal.Update(measureUnit);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var measureUnit = await GetByIdAsync(id);
            if (measureUnit != null)
            {
                _measureUnitDal.Delete(measureUnit);
                return true;
            }
            return false;
        }
    }
}
