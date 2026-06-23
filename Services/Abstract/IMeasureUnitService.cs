using ModernWMC.Models.Concrete;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System;

namespace ModernWMC.Services.Abstract
{
    public interface IMeasureUnitService
    {
        Task<IEnumerable<MeasureUnit>> LoadAllAsync(Expression<Func<MeasureUnit, bool>>? filter = null);
        Task<MeasureUnit?> GetByIdAsync(int id);
        Task<int> AddAsync(MeasureUnit measureUnit);
        Task<bool> UpdateAsync(MeasureUnit measureUnit);
        Task<bool> DeleteAsync(int id);
    }
}
