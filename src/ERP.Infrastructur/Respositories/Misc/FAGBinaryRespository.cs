using ERP.Domain.Models;
using ERP.Domain.Respositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Infrastructur.Respositories
{
    public class FAGBinaryRespository : IFAGBinaryRespository
    {
        private readonly ERPContext _context;

        public IUnitOfWork UnitOfWork => _context;

        public FAGBinaryRespository(ERPContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public FAGBinary Add(FAGBinary country)
        {
            return _context.FAGBinaries.Add(country).Entity;
        }

        public async Task<IEnumerable<FAGBinary>> GetAsync()
        {
            return await _context.FAGBinaries
                .AsNoTracking()
                .ToListAsync();
        }

        public IQueryable<FAGBinary> GetQuery()
        {
            return _context.FAGBinaries
                .AsNoTracking();
        }

        public async Task<FAGBinary> GetAsync(Guid id)
        {
            FAGBinary country = await _context.FAGBinaries.AsNoTracking().Where(x => x.Id == id).FirstOrDefaultAsync();
            return country;
        }

        public FAGBinary Update(FAGBinary country)
        {
            _context.Entry(country).State = EntityState.Modified;
            return country;
        }
    }
}
