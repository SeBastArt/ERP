using ERP.Domain.Models;
using ERP.Domain.Requests;
using ERP.Domain.Responses;

namespace ERP.Domain.Mappers
{
    public interface IFAGBinaryMapper
    {
        FAGBinary Map(AddFAGBinaryRequest request);
        FAGBinary Map(EditFAGBinaryRequest request);
        FAGBinaryResponse Map(FAGBinary item);
    }
}
