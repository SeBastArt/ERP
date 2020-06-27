using ERP.Domain.Models;
using ERP.Domain.Respositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Infrastructur.Respositories
{
    public class CompanyRespository : ICompanyRespository
    {
        private readonly ERPContext _context;

        public IUnitOfWork UnitOfWork => _context;

        public CompanyRespository(ERPContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Company Add(Company address)
        {
            return _context.Companies.Add(address).Entity;
        }

        public async Task<IEnumerable<Company>> GetAsync()
        {
            return await _context.Companies
                .Where(x => !x.IsInactive)
                .AsNoTracking()
                .ToListAsync();
        }

        public IQueryable<Company> GetQuery()
        {
            return _context.Companies
                .Where(x => !x.IsInactive)
                .AsNoTracking();
        }

        public async Task<Company> GetAsync(Guid id)
        {
            Company address = await _context.Companies.AsNoTracking().Where(x => x.Id == id).Include(x => x.Country).Include(x => x.Logo).Include(x => x.CompanyType).FirstOrDefaultAsync();
            return address;
        }

        public Company Update(Company address)
        {
            _context.Entry(address).State = EntityState.Modified;
            return address;
        }
    }
}
