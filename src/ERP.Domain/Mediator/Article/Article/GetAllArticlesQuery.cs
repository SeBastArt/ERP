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
    public class GetAllArticlesQuery : ReqContainer<GetAllArticleRequest>, IRequest<ApiResult<ArticleResponse>>
    {
        public GetAllArticlesQuery(GetAllArticleRequest getAllArticleRequest) : base(getAllArticleRequest)
        { }
    }
    public class GetAllArticlesQueryHandler : IRequestHandler<GetAllArticlesQuery, ApiResult<ArticleResponse>>
    {
        private readonly ILogger<IRequest> _logger;
        private readonly IArticleService _articleService;

        public GetAllArticlesQueryHandler(ILogger<IRequest> logger, IArticleService articleService)
        {
            _logger = logger;
            _articleService = articleService;
        }

        public async Task<ApiResult<ArticleResponse>> Handle(GetAllArticlesQuery request, CancellationToken cancellationToken)
        {
            IQueryable<ArticleResponse> result = _articleService.GetArticlesQuery();
            return await ApiResult<ArticleResponse>.CreateAsync(
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
