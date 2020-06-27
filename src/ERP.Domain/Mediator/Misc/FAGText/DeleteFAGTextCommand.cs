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
    public class DelteFAGTextCommand : ReqContainer<DeleteFAGTextRequest>, IRequestWrapper<EmptyResponse>
    {
        public DelteFAGTextCommand(DeleteFAGTextRequest request) : base(request)
        { }
    }

    public class DelteFAGTextCommandHandler : IHandlerWrapper<DelteFAGTextCommand, EmptyResponse>
    {
        private readonly IFAGTextService _fagTextService;
        private readonly IFAGTextMapper _fagTextMapper;
        private readonly ILogger<IRequest> _logger;

        public DelteFAGTextCommandHandler(IFAGTextService fagTextService, IFAGTextMapper fagTextMapper, ILogger<IRequest> logger)
        {
            _fagTextService = fagTextService;
            _fagTextMapper = fagTextMapper;
            _logger = logger;
        }

        public async Task<RespContainer<EmptyResponse>> Handle(DelteFAGTextCommand request, CancellationToken cancellationToken)
        {
            await _fagTextService.DeleteFAGTextAsync(request.Data);
            _logger.LogInformation($"Entity with { request.Data.Id} deleted");
            return RespContainer.Ok(new EmptyResponse(), "FAGText deleted");
        }
    }
}
