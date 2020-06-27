using ERP.Domain.Models;
using ERP.Domain.Respositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Infrastructur.Respositories
{
    public class CountryRespository : ICountryRespository
    {
        private readonly ERPContext _context;

        public IUnitOfWork UnitOfWork => _context;

        public CountryRespository(ERPContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Country Add(Country country)
        {
            return _context.Countries.Add(country).Entity;
        }

        public async Task<IEnumerable<Country>> GetAsync()
        {
            return await _context.Countries
                .Where(x => !x.IsInactive)
                .AsNoTracking()
                .ToListAsync();
        }

        public IQueryable<Country> GetQuery()
        {
            return _context.Countries
                .Where(x => !x.IsInactive)
                .AsNoTracking();
        }

        public async Task<Country> GetAsync(Guid id)
        {
            Country country = await _context.Countries.AsNoTracking().Where(x => x.Id == id).Include(x => x.Adresss).FirstOrDefaultAsync();
            return country;
        }

        public Country Update(Country country)
        {
            _context.Entry(country).State = EntityState.Modified;
            return country;
        }
    }
}
