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
    public class GetArticlePriceListInQuery : ReqContainer<Guid>, IRequest<ArticlePriceListInResponse>
    {
        /// <summary>
        /// GetArticlePriceListInQuery
        /// </summary>
        /// <param name="id"></param>
        public GetArticlePriceListInQuery(Guid id) : base(id)
        { }
    }

    /// <summary>
    /// GetArticlePriceListInQueryHandler
    /// </summary>
    public class GetArticlePriceListInQueryHandler : IRequestHandler<GetArticlePriceListInQuery, ArticlePriceListInResponse>
    {
        private readonly ILogger<IRequest> _logger;
        private readonly IArticlePriceListInService _articlePriceListInService;

        /// <summary>
        /// GetArticlePriceListInQueryHandler
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="articlePriceListInService"></param>
        public GetArticlePriceListInQueryHandler(ILogger<IRequest> logger, IArticlePriceListInService articlePriceListInService)
        {
            _logger = logger;
            _articlePriceListInService = articlePriceListInService;
        }

        public async Task<ArticlePriceListInResponse> Handle(GetArticlePriceListInQuery request, CancellationToken cancellationToken)
        {
            ArticlePriceListInResponse result = await _articlePriceListInService.GetArticlePriceListInAsync(request.Data);
            return result;
        }
    }
}
