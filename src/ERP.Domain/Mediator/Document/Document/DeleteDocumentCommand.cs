using ERP.Domain.Mappers;
using ERP.Domain.Mediator.Wrapper;
using ERP.Domain.Requests;
using ERP.Domain.Responses;
using ERP.Domain.Services;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace ERP.Domain.Mediator.Commands
{
    public class DelteDocumentCommand : ReqContainer<DeleteDocumentRequest>, IRequestWrapper<EmptyResponse>
    {
        public DelteDocumentCommand(DeleteDocumentRequest request) : base(request)
        { }
    }

    public class DelteDocumentCommandHandler : IHandlerWrapper<DelteDocumentCommand, EmptyResponse>
    {
        private readonly IDocumentService _documentService;
        private readonly IDocumentMapper _documentMapper;
        private readonly ILogger<IRequest> _logger;

        public DelteDocumentCommandHandler(IDocumentService documentService, IDocumentMapper documentMapper, ILogger<IRequest> logger)
        {
            _documentService = documentService;
            _documentMapper = documentMapper;
            _logger = logger;
        }

        public async Task<RespContainer<EmptyResponse>> Handle(DelteDocumentCommand request, CancellationToken cancellationToken)
        {
            await _documentService.DeleteDocumentAsync(request.Data);
            _logger.LogInformation($"Entity with { request.Data.Id} deleted");
            return RespContainer.Ok(new EmptyResponse(), "Document deleted");
        }
    }
}
