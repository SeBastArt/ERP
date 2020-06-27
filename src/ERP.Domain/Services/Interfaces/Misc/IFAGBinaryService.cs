using ERP.Domain.Requests;
using ERP.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Domain.Services
{
    public interface IFAGBinaryService
    {
        Task<IEnumerable<FAGBinaryResponse>> GetFAGBinariesAsync();
        IQueryable<FAGBinaryResponse> GetFAGBinariesQuery();
        Task<FAGBinaryResponse> GetFAGBinaryAsync(Guid id);
        Task<FAGBinaryResponse> AddFAGBinaryAsync(AddFAGBinaryRequest request);
        Task<FAGBinaryResponse> EditFAGBinaryAsync(EditFAGBinaryRequest request);
        Task<FAGBinaryResponse> DeleteFAGBinaryAsync(DeleteFAGBinaryRequest request);
    }
}
