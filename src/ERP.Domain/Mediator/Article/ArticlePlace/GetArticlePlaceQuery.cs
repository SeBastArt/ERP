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
    public class GetArticlePlaceQuery : ReqContainer<Guid>, IRequest<ArticlePlaceResponse>
    {
        /// <summary>
        /// GetArticlePlaceQuery
        /// </summary>
        /// <param name="id"></param>
        public GetArticlePlaceQuery(Guid id) : base(id)
        { }
    }

    /// <summary>
    /// GetArticlePlaceQueryHandler
    /// </summary>
    public class GetArticlePlaceQueryHandler : IRequestHandler<GetArticlePlaceQuery, ArticlePlaceResponse>
    {
        private readonly ILogger<IRequest> _logger;
        private readonly IArticlePlaceService _articlePlaceService;

        /// <summary>
        /// GetArticlePlaceQueryHandler
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="articlePlaceService"></param>
        public GetArticlePlaceQueryHandler(ILogger<IRequest> logger, IArticlePlaceService articlePlaceService)
        {
            _logger = logger;
            _articlePlaceService = articlePlaceService;
        }

        public async Task<ArticlePlaceResponse> Handle(GetArticlePlaceQuery request, CancellationToken cancellationToken)
        {
            ArticlePlaceResponse result = await _articlePlaceService.GetArticlePlaceAsync(request.Data);
            return result;
        }
    }
}
