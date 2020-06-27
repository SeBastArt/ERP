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
    public class GetArticleQuery : ReqContainer<Guid>, IRequest<ArticleResponse>
    {
        /// <summary>
        /// GetArticleQuery
        /// </summary>
        /// <param name="id"></param>
        public GetArticleQuery(Guid id) : base(id)
        { }
    }

    /// <summary>
    /// GetArticleQueryHandler
    /// </summary>
    public class GetArticleQueryHandler : IRequestHandler<GetArticleQuery, ArticleResponse>
    {
        private readonly ILogger<IRequest> _logger;
        private readonly IArticleService _articleService;

        /// <summary>
        /// GetArticleQueryHandler
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="articleService"></param>
        public GetArticleQueryHandler(ILogger<IRequest> logger, IArticleService articleService)
        {
            _logger = logger;
            _articleService = articleService;
        }

        public async Task<ArticleResponse> Handle(GetArticleQuery request, CancellationToken cancellationToken)
        {
            ArticleResponse result = await _articleService.GetArticleAsync(request.Data);
            return result;
        }
    }
}
