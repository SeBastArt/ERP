using ERP.Domain.Requests;
using ERP.Domain.Responses;
using ERP.Domain.Services;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ERP.Domain.Mediator.Queries
{
    public class GetAllArticlePlacesQuery : ReqContainer<GetAllArticlePlaceRequest>, IRequest<ApiResult<ArticlePlaceResponse>>
    {
        public GetAllArticlePlacesQuery(GetAllArticlePlaceRequest getAllArticlePlaceRequest) : base(getAllArticlePlaceRequest)
        { }
    }
    public class GetAllArticlePlacesQueryHandler : IRequestHandler<GetAllArticlePlacesQuery, ApiResult<ArticlePlaceResponse>>
    {
        private readonly ILogger<IRequest> _logger;
        private readonly IArticlePlaceService _articlePlaceService;

        public GetAllArticlePlacesQueryHandler(ILogger<IRequest> logger, IArticlePlaceService articlePlaceService)
        {
            _logger = logger;
            _articlePlaceService = articlePlaceService;
        }

        public async Task<ApiResult<ArticlePlaceResponse>> Handle(GetAllArticlePlacesQuery request, CancellationToken cancellationToken)
        {
            IQueryable<ArticlePlaceResponse> result = _articlePlaceService.GetArticlePlacesQuery();
            return await ApiResult<ArticlePlaceResponse>.CreateAsync(
                result,
                request.Data.PageIndex,
                request.Data.PageSize,
                request.Data.SortColumn,
                request.Data.SortOrder,
                request.Data.FilterColumn,
                request.Data.FilterQuery);
        }
    }
}
