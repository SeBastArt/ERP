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
    public class DelteFAGBinaryCommand : ReqContainer<DeleteFAGBinaryRequest>, IRequestWrapper<EmptyResponse>
    {
        public DelteFAGBinaryCommand(DeleteFAGBinaryRequest request) : base(request)
        { }
    }

    public class DelteFAGBinaryCommandHandler : IHandlerWrapper<DelteFAGBinaryCommand, EmptyResponse>
    {
        private readonly IFAGBinaryService _fagBinaryService;
        private readonly IFAGBinaryMapper _fagBinaryMapper;
        private readonly ILogger<IRequest> _logger;

        public DelteFAGBinaryCommandHandler(IFAGBinaryService fagBinaryService, IFAGBinaryMapper fagBinaryMapper, ILogger<IRequest> logger)
        {
            _fagBinaryService = fagBinaryService;
            _fagBinaryMapper = fagBinaryMapper;
            _logger = logger;
        }

        public async Task<RespContainer<EmptyResponse>> Handle(DelteFAGBinaryCommand request, CancellationToken cancellationToken)
        {
            await _fagBinaryService.DeleteFAGBinaryAsync(request.Data);
            _logger.LogInformation($"Entity with { request.Data.Id} deleted");
            return RespContainer.Ok(new EmptyResponse(), "FAGBinary deleted");
        }
    }
}
