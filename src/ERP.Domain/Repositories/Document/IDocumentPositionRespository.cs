using ERP.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Domain.Respositories
{
    public interface IDocumentPositionRespository : IRespository
    {
        Task<IEnumerable<DocumentPosition>> GetAsync();
        IQueryable<DocumentPosition> GetQuery();
        Task<DocumentPosition> GetAsync(Guid id);
        DocumentPosition Add(DocumentPosition item);
        DocumentPosition Update(DocumentPosition item);
    }
}
