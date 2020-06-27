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
    public class GetArticleTypeQuery : ReqContainer<Guid>, IRequest<ArticleTypeResponse>
    {
        /// <summary>
        /// GetArticleTypeQuery
        /// </summary>
        /// <param name="id"></param>
        public GetArticleTypeQuery(Guid id) : base(id)
        { }
    }

    /// <summary>
    /// GetArticleTypeQueryHandler
    /// </summary>
    public class GetArticleTypeQueryHandler : IRequestHandler<GetArticleTypeQuery, ArticleTypeResponse>
    {
        private readonly ILogger<IRequest> _logger;
        private readonly IArticleTypeService _articleTypeService;

        /// <summary>
        /// GetArticleTypeQueryHandler
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="articleTypeService"></param>
        public GetArticleTypeQueryHandler(ILogger<IRequest> logger, IArticleTypeService articleTypeService)
        {
            _logger = logger;
            _articleTypeService = articleTypeService;
        }

        public async Task<ArticleTypeResponse> Handle(GetArticleTypeQuery request, CancellationToken cancellationToken)
        {
            ArticleTypeResponse result = await _articleTypeService.GetArticleTypeAsync(request.Data);
            return result;
        }
    }
}
