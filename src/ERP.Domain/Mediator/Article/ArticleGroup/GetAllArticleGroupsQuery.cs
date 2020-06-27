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
    public class GetAllArticleGroupsQuery : ReqContainer<GetAllArticleGroupRequest>, IRequest<ApiResult<ArticleGroupResponse>>
    {
        public GetAllArticleGroupsQuery(GetAllArticleGroupRequest getAllArticleGroupRequest) : base(getAllArticleGroupRequest)
        { }
    }
    public class GetAllArticleGroupsQueryHandler : IRequestHandler<GetAllArticleGroupsQuery, ApiResult<ArticleGroupResponse>>
    {
        private readonly ILogger<IRequest> _logger;
        private readonly IArticleGroupService _articleGroupService;

        public GetAllArticleGroupsQueryHandler(ILogger<IRequest> logger, IArticleGroupService articleGroupService)
        {
            _logger = logger;
            _articleGroupService = articleGroupService;
        }

        public async Task<ApiResult<ArticleGroupResponse>> Handle(GetAllArticleGroupsQuery request, CancellationToken cancellationToken)
        {
            IQueryable<ArticleGroupResponse> result = _articleGroupService.GetArticleGroupsQuery();
            return await ApiResult<ArticleGroupResponse>.CreateAsync(
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
