using ERP.Domain.Models;
using ERP.Domain.Requests;
using ERP.Domain.Responses;

namespace ERP.Domain.Mappers
{
    public interface IDocumentMapper
    {
        Document Map(AddDocumentRequest request);
        Document Map(EditDocumentRequest request);
        DocumentResponse Map(Document document);
    }
}
