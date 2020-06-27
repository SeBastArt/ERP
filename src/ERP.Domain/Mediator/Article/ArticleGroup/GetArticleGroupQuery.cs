using ERP.Domain.Requests;
using ERP.Domain.Responses;
using ERP.Domain.Services;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ERP.Domain.Mediator.Queries
{
    public class GetArticleGroupQuery : ReqContainer<Guid>, IRequest<ArticleGroupResponse>
    {
        /// <summary>
        /// GetArticleGroupQuery
        /// </summary>
        /// <param name="id"></param>
        public GetArticleGroupQuery(Guid id) : base(id)
        { }
    }

    /// <summary>
    /// GetArticleGroupQueryHandler
    /// </summary>
    public class GetArticleGroupQueryHandler : IRequestHandler<GetArticleGroupQuery, ArticleGroupResponse>
    {
        private readonly ILogger<IRequest> _logger;
        private readonly IArticleGroupService _articleGroupService;

        /// <summary>
        /// GetArticleGroupQueryHandler
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="articleGroupService"></param>
        public GetArticleGroupQueryHandler(ILogger<IRequest> logger, IArticleGroupService articleGroupService)
        {
            _logger = logger;
            _articleGroupService = articleGroupService;
        }

        public async Task<ArticleGroupResponse> Handle(GetArticleGroupQuery request, CancellationToken cancellationToken)
        {
            ArticleGroupResponse result = await _articleGroupService.GetArticleGroupAsync(request.Data);
            return result;
        }
    }
}
