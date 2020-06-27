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
    public class GetFAGBinaryQuery : ReqContainer<Guid>, IRequest<FAGBinaryResponse>
    {
        /// <summary>
        /// GetFAGBinaryQuery
        /// </summary>
        /// <param name="id"></param>
        public GetFAGBinaryQuery(Guid id) : base(id)
        { }
    }

    /// <summary>
    /// GetFAGBinaryQueryHandler
    /// </summary>
    public class GetFAGBinaryQueryHandler : IRequestHandler<GetFAGBinaryQuery, FAGBinaryResponse>
    {
        private readonly ILogger<IRequest> _logger;
        private readonly IFAGBinaryService _fagBinaryService;

        /// <summary>
        /// GetFAGBinaryQueryHandler
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="fagBinaryService"></param>
        public GetFAGBinaryQueryHandler(ILogger<IRequest> logger, IFAGBinaryService fagBinaryService)
        {
            _logger = logger;
            _fagBinaryService = fagBinaryService;
        }

        public async Task<FAGBinaryResponse> Handle(GetFAGBinaryQuery request, CancellationToken cancellationToken)
        {
            FAGBinaryResponse result = await _fagBinaryService.GetFAGBinaryAsync(request.Data);
            return result;
        }
    }
}
