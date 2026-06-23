using ModernWMC.Data.Abstract;
using ModernWMC.Models.Concrete;
using ModernWMC.Services.Abstract;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System;

namespace ModernWMC.Services.Concrete
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyDal _companyDal;

        public CompanyService(ICompanyDal companyDal)
        {
            _companyDal = companyDal;
        }

        public async Task<IEnumerable<Company>> LoadAllAsync(Expression<Func<Company, bool>>? filter = null)
        {
            return await _companyDal.LoadAll(filter);
        }

        public async Task<Company?> GetByIdAsync(int id)
        {
            return await _companyDal.GetById(id);
        }

        public async Task<int> AddAsync(Company company)
        {
            return await _companyDal.Add(company);
        }

        public async Task<bool> UpdateAsync(Company company)
        {
            return await _companyDal.Update(company);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var company = await GetByIdAsync(id);
            if (company != null)
            {
                _companyDal.Delete(company);
                return true;
            }
            return false;
        }
    }
}
