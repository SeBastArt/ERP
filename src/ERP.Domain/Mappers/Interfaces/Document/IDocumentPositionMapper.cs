using ERP.Domain.Models;
using ERP.Domain.Requests;
using ERP.Domain.Responses;

namespace ERP.Domain.Mappers
{
    public interface IDocumentPositionMapper
    {
        DocumentPosition Map(AddDocumentPositionRequest request);
        DocumentPosition Map(EditDocumentPositionRequest request);
        DocumentPositionResponse Map(DocumentPosition item);
    }
}
