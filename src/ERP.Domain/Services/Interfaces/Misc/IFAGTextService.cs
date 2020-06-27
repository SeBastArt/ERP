using ERP.Domain.Requests;
using ERP.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Domain.Services
{
    public interface IFAGTextService
    {
        Task<IEnumerable<FAGTextResponse>> GetFAGTextsAsync();
        IQueryable<FAGTextResponse> GetFAGTextsQuery();
        Task<FAGTextResponse> GetFAGTextAsync(Guid id);
        Task<FAGTextResponse> AddFAGTextAsync(AddFAGTextRequest request);
        Task<FAGTextResponse> EditFAGTextAsync(EditFAGTextRequest request);
        Task<FAGTextResponse> DeleteFAGTextAsync(DeleteFAGTextRequest request);
    }
}
