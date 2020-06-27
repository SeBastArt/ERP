using ERP.Domain.Models;
using ERP.Domain.Respositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Infrastructur.Respositories
{
    public class DocumentRespository : IDocumentRespository
    {
        private readonly ERPContext _context;

        public IUnitOfWork UnitOfWork => _context;

        public DocumentRespository(ERPContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Document Add(Document document)
        {
            return _context.Documents.Add(document).Entity;
        }

        public async Task<IEnumerable<Document>> GetAsync()
        {
            return await _context.Documents
                .Where(x => !x.IsInactive)
                .AsNoTracking()
                .ToListAsync();
        }

        public IQueryable<Document> GetQuery()
        {
            return _context.Documents
                .Where(x => !x.IsInactive)
                .Include(x => x.DocumentPerson)
                .Include(x => x.DocumentCompany)
                .Include(x => x.DeliveryPerson)
                .Include(x => x.DeliveryCompany)
                .Include(x => x.InvoicePerson)
                .Include(x => x.InvoiceCompany)
                .AsNoTracking();
        }

        public async Task<Document> GetAsync(Guid id)
        {
            Document document = await _context.Documents.AsNoTracking()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
            return document;
        }

        public Document Update(Document document)
        {
            _context.Entry(document).State = EntityState.Modified;
            return document;
        }
    }
}
