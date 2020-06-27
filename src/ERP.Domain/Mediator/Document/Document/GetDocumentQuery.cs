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
    public class GetDocumentQuery : ReqContainer<Guid>, IRequest<DocumentResponse>
    {
        /// <summary>
        /// GetDocumentQuery
        /// </summary>
        /// <param name="id"></param>
        public GetDocumentQuery(Guid id) : base(id)
        { }
    }

    /// <summary>
    /// GetDocumentQueryHandler
    /// </summary>
    public class GetDocumentQueryHandler : IRequestHandler<GetDocumentQuery, DocumentResponse>
    {
        private readonly ILogger<IRequest> _logger;
        private readonly IDocumentService _documentService;

        /// <summary>
        /// GetDocumentQueryHandler
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="documentService"></param>
        public GetDocumentQueryHandler(ILogger<IRequest> logger, IDocumentService documentService)
        {
            _logger = logger;
            _documentService = documentService;
        }

        public async Task<DocumentResponse> Handle(GetDocumentQuery request, CancellationToken cancellationToken)
        {
            DocumentResponse result = await _documentService.GetDocumentAsync(request.Data);
            return result;
        }
    }
}
