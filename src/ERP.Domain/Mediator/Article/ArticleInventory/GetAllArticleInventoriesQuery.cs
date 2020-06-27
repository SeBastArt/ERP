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
    public class GetAllArticleInventoriesQuery : ReqContainer<GetAllArticleInventoryRequest>, IRequest<ApiResult<ArticleInventoryResponse>>
    {
        public GetAllArticleInventoriesQuery(GetAllArticleInventoryRequest getAllArticleInventoryRequest) : base(getAllArticleInventoryRequest)
        { }
    }
    public class GetAllArticleInventoriesQueryHandler : IRequestHandler<GetAllArticleInventoriesQuery, ApiResult<ArticleInventoryResponse>>
    {
        private readonly ILogger<IRequest> _logger;
        private readonly IArticleInventoryService _articleInventoryService;

        public GetAllArticleInventoriesQueryHandler(ILogger<IRequest> logger, IArticleInventoryService articleInventoryService)
        {
            _logger = logger;
            _articleInventoryService = articleInventoryService;
        }

        public async Task<ApiResult<ArticleInventoryResponse>> Handle(GetAllArticleInventoriesQuery request, CancellationToken cancellationToken)
        {
            IQueryable<ArticleInventoryResponse> result = _articleInventoryService.GetArticleInventoriesQuery();
            return await ApiResult<ArticleInventoryResponse>.CreateAsync(
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
