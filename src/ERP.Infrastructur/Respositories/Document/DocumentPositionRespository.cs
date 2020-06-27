using ERP.Domain.Models;
using ERP.Domain.Respositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Infrastructur.Respositories
{
    public class DocumentPositionRespository : IDocumentPositionRespository
    {
        private readonly ERPContext _context;

        public IUnitOfWork UnitOfWork => _context;

        public DocumentPositionRespository(ERPContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public DocumentPosition Add(DocumentPosition documentPosition)
        {
            return _context.DocumentPositions.Add(documentPosition).Entity;
        }

        public async Task<IEnumerable<DocumentPosition>> GetAsync()
        {
            return await _context.DocumentPositions
                .Where(x => !x.IsInactive)
                .AsNoTracking()
                .ToListAsync();
        }

        public IQueryable<DocumentPosition> GetQuery()
        {
            return _context.DocumentPositions
                .Where(x => !x.IsInactive)
                .AsNoTracking();
        }

        public async Task<DocumentPosition> GetAsync(Guid id)
        {
            DocumentPosition documentPosition = await _context.DocumentPositions
                .AsNoTracking()
                .Where(x => x.Id == id)
                .Include(x => x.Document)
                .FirstOrDefaultAsync();
            return documentPosition;
        }

        public DocumentPosition Update(DocumentPosition documentPosition)
        {
            _context.Entry(documentPosition).State = EntityState.Modified;
            return documentPosition;
        }
    }
}
