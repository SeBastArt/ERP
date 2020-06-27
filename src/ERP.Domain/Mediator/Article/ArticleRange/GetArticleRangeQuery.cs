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
    public class GetArticleRangeQuery : ReqContainer<Guid>, IRequest<ArticleRangeResponse>
    {
        /// <summary>
        /// GetArticleRangeQuery
        /// </summary>
        /// <param name="id"></param>
        public GetArticleRangeQuery(Guid id) : base(id)
        { }
    }

    /// <summary>
    /// GetArticleRangeQueryHandler
    /// </summary>
    public class GetArticleRangeQueryHandler : IRequestHandler<GetArticleRangeQuery, ArticleRangeResponse>
    {
        private readonly ILogger<IRequest> _logger;
        private readonly IArticleRangeService _articleRangeService;

        /// <summary>
        /// GetArticleRangeQueryHandler
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="articleRangeService"></param>
        public GetArticleRangeQueryHandler(ILogger<IRequest> logger, IArticleRangeService articleRangeService)
        {
            _logger = logger;
            _articleRangeService = articleRangeService;
        }

        public async Task<ArticleRangeResponse> Handle(GetArticleRangeQuery request, CancellationToken cancellationToken)
        {
            ArticleRangeResponse result = await _articleRangeService.GetArticleRangeAsync(request.Data);
            return result;
        }
    }
}
