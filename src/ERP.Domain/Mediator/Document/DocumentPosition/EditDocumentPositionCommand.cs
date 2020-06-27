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
    public class EditDocumentPositionCommand : ReqContainer<EditDocumentPositionRequest>, IRequestWrapper<DocumentPositionResponse>
    {
        public EditDocumentPositionCommand(EditDocumentPositionRequest editDocumentPositionRequest) : base(editDocumentPositionRequest)
        { }
    }

    public class EditDocumentPositionCommandHandler : IHandlerWrapper<EditDocumentPositionCommand, DocumentPositionResponse>
    {

        private readonly IDocumentPositionService _documentPositionService;
        private readonly IDocumentPositionMapper _documentPositionMapper;
        private readonly ILogger<IRequest> _logger;

        public EditDocumentPositionCommandHandler(IDocumentPositionService documentPositionService, IDocumentPositionMapper documentPositionMapper, ILogger<IRequest> logger)
        {
            _documentPositionService = documentPositionService;
            _documentPositionMapper = documentPositionMapper;
            _logger = logger;
        }

        public async Task<RespContainer<DocumentPositionResponse>> Handle(EditDocumentPositionCommand request, CancellationToken cancellationToken)
        {
            DocumentPositionResponse result = await _documentPositionService.EditDocumentPositionAsync(request.Data);
            return RespContainer.Ok(result, "DocumentPosition Updated");
        }
    }
}
