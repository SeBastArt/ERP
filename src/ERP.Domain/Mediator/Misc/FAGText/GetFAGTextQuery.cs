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
    public class GetFAGTextQuery : ReqContainer<Guid>, IRequest<FAGTextResponse>
    {
        /// <summary>
        /// GetFAGTextQuery
        /// </summary>
        /// <param name="id"></param>
        public GetFAGTextQuery(Guid id) : base(id)
        { }
    }

    /// <summary>
    /// GetFAGTextQueryHandler
    /// </summary>
    public class GetFAGTextQueryHandler : IRequestHandler<GetFAGTextQuery, FAGTextResponse>
    {
        private readonly ILogger<IRequest> _logger;
        private readonly IFAGTextService _fagTextService;

        /// <summary>
        /// GetFAGTextQueryHandler
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="fagTextService"></param>
        public GetFAGTextQueryHandler(ILogger<IRequest> logger, IFAGTextService fagTextService)
        {
            _logger = logger;
            _fagTextService = fagTextService;
        }

        public async Task<FAGTextResponse> Handle(GetFAGTextQuery request, CancellationToken cancellationToken)
        {
            FAGTextResponse result = await _fagTextService.GetFAGTextAsync(request.Data);
            return result;
        }
    }
}
