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
    public class EditDocumentCommand : ReqContainer<EditDocumentRequest>, IRequestWrapper<DocumentResponse>
    {
        public EditDocumentCommand(EditDocumentRequest editDocumentRequest) : base(editDocumentRequest)
        { }
    }

    public class EditDocumentCommandHandler : IHandlerWrapper<EditDocumentCommand, DocumentResponse>
    {

        private readonly IDocumentService _documentService;
        private readonly IDocumentMapper _documentMapper;
        private readonly ILogger<IRequest> _logger;

        public EditDocumentCommandHandler(IDocumentService documentService, IDocumentMapper documentMapper, ILogger<IRequest> logger)
        {
            _documentService = documentService;
            _documentMapper = documentMapper;
            _logger = logger;
        }

        public async Task<RespContainer<DocumentResponse>> Handle(EditDocumentCommand request, CancellationToken cancellationToken)
        {
            DocumentResponse result = await _documentService.EditDocumentAsync(request.Data);
            return RespContainer.Ok(result, "Document Updated");
        }
    }
}
