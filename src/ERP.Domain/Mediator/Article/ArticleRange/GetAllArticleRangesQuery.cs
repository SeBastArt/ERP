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
    public class GetAllArticleRangesQuery : ReqContainer<GetAllArticleRangeRequest>, IRequest<ApiResult<ArticleRangeResponse>>
    {
        public GetAllArticleRangesQuery(GetAllArticleRangeRequest getAllArticleRangeRequest) : base(getAllArticleRangeRequest)
        { }
    }
    public class GetAllArticleRangesQueryHandler : IRequestHandler<GetAllArticleRangesQuery, ApiResult<ArticleRangeResponse>>
    {
        private readonly ILogger<IRequest> _logger;
        private readonly IArticleRangeService _itemService;

        public GetAllArticleRangesQueryHandler(ILogger<IRequest> logger, IArticleRangeService itemService)
        {
            _logger = logger;
            _itemService = itemService;
        }

        public async Task<ApiResult<ArticleRangeResponse>> Handle(GetAllArticleRangesQuery request, CancellationToken cancellationToken)
        {
            IQueryable<ArticleRangeResponse> result = _itemService.GetArticleRangesQuery();
            return await ApiResult<ArticleRangeResponse>.CreateAsync(
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
