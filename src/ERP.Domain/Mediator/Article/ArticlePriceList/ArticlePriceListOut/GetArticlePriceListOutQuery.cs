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
    public class GetArticlePriceListOutQuery : ReqContainer<Guid>, IRequest<ArticlePriceListOutResponse>
    {
        /// <summary>
        /// GetArticlePriceListOutQuery
        /// </summary>
        /// <param name="id"></param>
        public GetArticlePriceListOutQuery(Guid id) : base(id)
        { }
    }

    /// <summary>
    /// GetArticlePriceListOutQueryHandler
    /// </summary>
    public class GetArticlePriceListOutQueryHandler : IRequestHandler<GetArticlePriceListOutQuery, ArticlePriceListOutResponse>
    {
        private readonly ILogger<IRequest> _logger;
        private readonly IArticlePriceListOutService _articlePriceListOutService;

        /// <summary>
        /// GetArticlePriceListOutQueryHandler
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="articlePriceListOutService"></param>
        public GetArticlePriceListOutQueryHandler(ILogger<IRequest> logger, IArticlePriceListOutService articlePriceListOutService)
        {
            _logger = logger;
            _articlePriceListOutService = articlePriceListOutService;
        }

        public async Task<ArticlePriceListOutResponse> Handle(GetArticlePriceListOutQuery request, CancellationToken cancellationToken)
        {
            ArticlePriceListOutResponse result = await _articlePriceListOutService.GetArticlePriceListOutAsync(request.Data);
            return result;
        }
    }
}
