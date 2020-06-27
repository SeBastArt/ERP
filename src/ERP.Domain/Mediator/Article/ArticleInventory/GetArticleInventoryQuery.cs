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
    public class GetArticleInventoryQuery : ReqContainer<Guid>, IRequest<ArticleInventoryResponse>
    {
        /// <summary>
        /// GetArticleInventoryQuery
        /// </summary>
        /// <param name="id"></param>
        public GetArticleInventoryQuery(Guid id) : base(id)
        { }
    }

    /// <summary>
    /// GetArticleInventoryQueryHandler
    /// </summary>
    public class GetArticleInventoryQueryHandler : IRequestHandler<GetArticleInventoryQuery, ArticleInventoryResponse>
    {
        private readonly ILogger<IRequest> _logger;
        private readonly IArticleInventoryService _articleInventoryService;

        /// <summary>
        /// GetArticleInventoryQueryHandler
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="articleInventoryService"></param>
        public GetArticleInventoryQueryHandler(ILogger<IRequest> logger, IArticleInventoryService articleInventoryService)
        {
            _logger = logger;
            _articleInventoryService = articleInventoryService;
        }

        public async Task<ArticleInventoryResponse> Handle(GetArticleInventoryQuery request, CancellationToken cancellationToken)
        {
            ArticleInventoryResponse result = await _articleInventoryService.GetArticleInventoryAsync(request.Data);
            return result;
        }
    }
}
