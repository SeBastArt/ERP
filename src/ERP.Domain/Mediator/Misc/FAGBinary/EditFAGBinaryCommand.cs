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
    public class EditFAGBinaryCommand : ReqContainer<EditFAGBinaryRequest>, IRequestWrapper<FAGBinaryResponse>
    {
        public EditFAGBinaryCommand(EditFAGBinaryRequest editFAGBinaryRequest) : base(editFAGBinaryRequest)
        { }
    }

    public class EditFAGBinaryCommandHandler : IHandlerWrapper<EditFAGBinaryCommand, FAGBinaryResponse>
    {

        private readonly IFAGBinaryService _fagBinaryService;
        private readonly IFAGBinaryMapper _fagBinaryMapper;
        private readonly ILogger<IRequest> _logger;

        public EditFAGBinaryCommandHandler(IFAGBinaryService fagBinaryService, IFAGBinaryMapper fagBinaryMapper, ILogger<IRequest> logger)
        {
            _fagBinaryService = fagBinaryService;
            _fagBinaryMapper = fagBinaryMapper;
            _logger = logger;
        }

        public async Task<RespContainer<FAGBinaryResponse>> Handle(EditFAGBinaryCommand request, CancellationToken cancellationToken)
        {
            FAGBinaryResponse result = await _fagBinaryService.EditFAGBinaryAsync(request.Data);
            return RespContainer.Ok(result, "FAGBinary Updated");
        }
    }
}
