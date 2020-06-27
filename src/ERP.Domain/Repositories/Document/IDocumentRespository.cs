using ERP.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Domain.Respositories
{
    public interface IDocumentRespository : IRespository
    {
        Task<IEnumerable<Document>> GetAsync();
        IQueryable<Document> GetQuery();
        Task<Document> GetAsync(Guid id);
        Document Add(Document item);
        Document Update(Document item);
    }
}
