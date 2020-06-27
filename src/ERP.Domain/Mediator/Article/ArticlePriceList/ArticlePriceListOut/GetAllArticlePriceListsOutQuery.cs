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
    public class GetAllArticlePriceListsOutQuery : ReqContainer<GetAllArticlePriceListOutRequest>, IRequest<ApiResult<ArticlePriceListOutResponse>>
    {
        public GetAllArticlePriceListsOutQuery(GetAllArticlePriceListOutRequest getAllArticlePriceListOutRequest) : base(getAllArticlePriceListOutRequest)
        { }
    }
    public class GetAllArticlePriceListsOutQueryHandler : IRequestHandler<GetAllArticlePriceListsOutQuery, ApiResult<ArticlePriceListOutResponse>>
    {
        private readonly ILogger<IRequest> _logger;
        private readonly IArticlePriceListOutService _articlePriceListOutService;

        public GetAllArticlePriceListsOutQueryHandler(ILogger<IRequest> logger, IArticlePriceListOutService articlePriceListOutService)
        {
            _logger = logger;
            _articlePriceListOutService = articlePriceListOutService;
        }

        public async Task<ApiResult<ArticlePriceListOutResponse>> Handle(GetAllArticlePriceListsOutQuery request, CancellationToken cancellationToken)
        {
            IQueryable<ArticlePriceListOutResponse> result = _articlePriceListOutService.GetArticlePriceListsOutQuery();
            return await ApiResult<ArticlePriceListOutResponse>.CreateAsync(
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
