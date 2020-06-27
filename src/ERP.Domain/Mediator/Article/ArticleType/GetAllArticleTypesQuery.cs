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
    public class GetAllArticleTypesQuery : ReqContainer<GetAllArticleTypeRequest>, IRequest<ApiResult<ArticleTypeResponse>>
    {
        public GetAllArticleTypesQuery(GetAllArticleTypeRequest getAllArticleTypeRequest) : base(getAllArticleTypeRequest)
        { }
    }
    public class GetAllArticleTypesQueryHandler : IRequestHandler<GetAllArticleTypesQuery, ApiResult<ArticleTypeResponse>>
    {
        private readonly ILogger<IRequest> _logger;
        private readonly IArticleTypeService _articleTypeService;

        public GetAllArticleTypesQueryHandler(ILogger<IRequest> logger, IArticleTypeService articleTypeService)
        {
            _logger = logger;
            _articleTypeService = articleTypeService;
        }

        public async Task<ApiResult<ArticleTypeResponse>> Handle(GetAllArticleTypesQuery request, CancellationToken cancellationToken)
        {
            IQueryable<ArticleTypeResponse> result = _articleTypeService.GetArticleTypesQuery();
            return await ApiResult<ArticleTypeResponse>.CreateAsync(
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
