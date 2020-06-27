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
    public class GetDocumentPositionQuery : ReqContainer<Guid>, IRequest<DocumentPositionResponse>
    {
        /// <summary>
        /// GetDocumentPositionQuery
        /// </summary>
        /// <param name="id"></param>
        public GetDocumentPositionQuery(Guid id) : base(id)
        { }
    }

    /// <summary>
    /// GetDocumentPositionQueryHandler
    /// </summary>
    public class GetDocumentPositionQueryHandler : IRequestHandler<GetDocumentPositionQuery, DocumentPositionResponse>
    {
        private readonly ILogger<IRequest> _logger;
        private readonly IDocumentPositionService _documentPositionService;

        /// <summary>
        /// GetDocumentPositionQueryHandler
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="documentPositionService"></param>
        public GetDocumentPositionQueryHandler(ILogger<IRequest> logger, IDocumentPositionService documentPositionService)
        {
            _logger = logger;
            _documentPositionService = documentPositionService;
        }

        public async Task<DocumentPositionResponse> Handle(GetDocumentPositionQuery request, CancellationToken cancellationToken)
        {
            DocumentPositionResponse result = await _documentPositionService.GetDocumentPositionAsync(request.Data);
            return result;
        }
    }
}
