using ERP.Domain.Models;
using ERP.Domain.Requests;
using ERP.Domain.Responses;

namespace ERP.Domain.Mappers
{
    public interface IFAGTextMapper
    {
        FAGText Map(AddFAGTextRequest request);
        FAGText Map(EditFAGTextRequest request);
        FAGTextResponse Map(FAGText item);
    }
}
