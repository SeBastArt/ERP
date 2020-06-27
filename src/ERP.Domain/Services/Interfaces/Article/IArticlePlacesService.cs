using ERP.Domain.Requests;
using ERP.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Domain.Services
{
    public interface IArticlePlaceService
    {
        Task<IEnumerable<ArticlePlaceResponse>> GetArticlePlacesAsync();
        IQueryable<ArticlePlaceResponse> GetArticlePlacesQuery();
        Task<ArticlePlaceResponse> GetArticlePlaceAsync(Guid id);
        Task<ArticlePlaceResponse> AddArticlePlaceAsync(AddArticlePlaceRequest request);
        Task<ArticlePlaceResponse> EditArticlePlaceAsync(EditArticlePlaceRequest request);
        Task<ArticlePlaceResponse> DeleteArticlePlaceAsync(DeleteArticlePlaceRequest request);
    }
}
