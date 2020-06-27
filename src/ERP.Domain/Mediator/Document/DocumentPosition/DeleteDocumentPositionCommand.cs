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
    public class DelteDocumentPositionCommand : ReqContainer<DeleteDocumentPositionRequest>, IRequestWrapper<EmptyResponse>
    {
        public DelteDocumentPositionCommand(DeleteDocumentPositionRequest request) : base(request)
        { }
    }

    public class DelteDocumentPositionCommandHandler : IHandlerWrapper<DelteDocumentPositionCommand, EmptyResponse>
    {
        private readonly IDocumentPositionService _documentPositionService;
        private readonly IDocumentPositionMapper _documentPositionMapper;
        private readonly ILogger<IRequest> _logger;

        public DelteDocumentPositionCommandHandler(IDocumentPositionService documentPositionService, IDocumentPositionMapper documentPositionMapper, ILogger<IRequest> logger)
        {
            _documentPositionService = documentPositionService;
            _documentPositionMapper = documentPositionMapper;
            _logger = logger;
        }

        public async Task<RespContainer<EmptyResponse>> Handle(DelteDocumentPositionCommand request, CancellationToken cancellationToken)
        {
            await _documentPositionService.DeleteDocumentPositionAsync(request.Data);
            _logger.LogInformation($"Entity with { request.Data.Id} deleted");
            return RespContainer.Ok(new EmptyResponse(), "DocumentPosition deleted");
        }
    }
}
