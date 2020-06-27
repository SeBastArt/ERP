using ERP.Domain.Requests;
using ERP.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Domain.Services
{
    public interface IDocumentService
    {
        Task<IEnumerable<DocumentResponse>> GetDocumentsAsync();
        IQueryable<DocumentResponse> GetDocumentsQuery();
        Task<DocumentResponse> GetDocumentAsync(Guid id);
        Task<DocumentResponse> AddDocumentAsync(AddDocumentRequest request);
        Task<DocumentResponse> EditDocumentAsync(EditDocumentRequest request);
        Task<DocumentResponse> DeleteDocumentAsync(DeleteDocumentRequest request);
    }
}
