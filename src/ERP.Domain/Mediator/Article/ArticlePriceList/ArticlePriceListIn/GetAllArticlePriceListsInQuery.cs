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
    public class GetAllArticlePriceListsInQuery : ReqContainer<GetAllArticlePriceListInRequest>, IRequest<ApiResult<ArticlePriceListInResponse>>
    {
        public GetAllArticlePriceListsInQuery(GetAllArticlePriceListInRequest getAllArticlePriceListInRequest) : base(getAllArticlePriceListInRequest)
        { }
    }
    public class GetAllArticlePriceListsInQueryHandler : IRequestHandler<GetAllArticlePriceListsInQuery, ApiResult<ArticlePriceListInResponse>>
    {
        private readonly ILogger<IRequest> _logger;
        private readonly IArticlePriceListInService _articlePriceListInService;

        public GetAllArticlePriceListsInQueryHandler(ILogger<IRequest> logger, IArticlePriceListInService articlePriceListInService)
        {
            _logger = logger;
            _articlePriceListInService = articlePriceListInService;
        }

        public async Task<ApiResult<ArticlePriceListInResponse>> Handle(GetAllArticlePriceListsInQuery request, CancellationToken cancellationToken)
        {
            IQueryable<ArticlePriceListInResponse> result = _articlePriceListInService.GetArticlePriceListsInQuery();
            return await ApiResult<ArticlePriceListInResponse>.CreateAsync(
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
