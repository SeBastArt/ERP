using ERP.Domain.Models;
using ERP.Domain.Respositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Infrastructur.Respositories
{
    public class CompanyTypeRespository : ICompanyTypeRespository
    {
        private readonly ERPContext _context;

        public IUnitOfWork UnitOfWork => _context;

        public CompanyTypeRespository(ERPContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public CompanyType Add(CompanyType companyType)
        {
            return _context.CompanyTypes.Add(companyType).Entity;
        }

        public async Task<IEnumerable<CompanyType>> GetAsync()
        {
            return await _context.CompanyTypes
                .Where(x => !x.IsInactive)
                .AsNoTracking()
                .ToListAsync();
        }

        public IQueryable<CompanyType> GetQuery()
        {
            return _context.CompanyTypes
                .Where(x => !x.IsInactive)
                .AsNoTracking();
        }

        public async Task<CompanyType> GetAsync(Guid id)
        {
            CompanyType companyType = await _context.CompanyTypes.AsNoTracking().Where(x => x.Id == id).FirstOrDefaultAsync();
            return companyType;
        }

        public CompanyType Update(CompanyType companyType)
        {
            _context.Entry(companyType).State = EntityState.Modified;
            return companyType;
        }
    }
}
