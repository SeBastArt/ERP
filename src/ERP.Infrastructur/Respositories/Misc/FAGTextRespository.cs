using ERP.Domain.Models;
using ERP.Domain.Respositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Infrastructur.Respositories
{
    public class FAGTextRespository : IFAGTextRespository
    {
        private readonly ERPContext _context;

        public IUnitOfWork UnitOfWork => _context;

        public FAGTextRespository(ERPContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public FAGText Add(FAGText address)
        {
            return _context.FAGTexts.Add(address).Entity;
        }

        public async Task<IEnumerable<FAGText>> GetAsync()
        {
            return await _context.FAGTexts
                .AsNoTracking()
                .ToListAsync();
        }

        public IQueryable<FAGText> GetQuery()
        {
            return _context.FAGTexts
                .AsNoTracking();
        }

        public async Task<FAGText> GetAsync(Guid id)
        {
            FAGText address = await _context.FAGTexts.AsNoTracking().Where(x => x.Id == id).FirstOrDefaultAsync();
            return address;
        }

        public FAGText Update(FAGText address)
        {
            _context.Entry(address).State = EntityState.Modified;
            return address;
        }
    }
}
