using ERP.Domain.Requests;
using ERP.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Domain.Services
{
    public interface IDocumentPositionService
    {
        Task<IEnumerable<DocumentPositionResponse>> GetDocumentPositionsAsync();
        IQueryable<DocumentPositionResponse> GetDocumentPositionsQuery();
        Task<DocumentPositionResponse> GetDocumentPositionAsync(Guid id);
        Task<DocumentPositionResponse> AddDocumentPositionAsync(AddDocumentPositionRequest request);
        Task<DocumentPositionResponse> EditDocumentPositionAsync(EditDocumentPositionRequest request);
        Task<DocumentPositionResponse> DeleteDocumentPositionAsync(DeleteDocumentPositionRequest request);
    }
}
