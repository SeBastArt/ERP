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
    public class EditFAGTextCommand : ReqContainer<EditFAGTextRequest>, IRequestWrapper<FAGTextResponse>
    {
        public EditFAGTextCommand(EditFAGTextRequest editFAGTextRequest) : base(editFAGTextRequest)
        { }
    }

    public class EditFAGTextCommandHandler : IHandlerWrapper<EditFAGTextCommand, FAGTextResponse>
    {

        private readonly IFAGTextService _fagTextService;
        private readonly IFAGTextMapper _fagTextMapper;
        private readonly ILogger<IRequest> _logger;

        public EditFAGTextCommandHandler(IFAGTextService fagTextService, IFAGTextMapper fagTextMapper, ILogger<IRequest> logger)
        {
            _fagTextService = fagTextService;
            _fagTextMapper = fagTextMapper;
            _logger = logger;
        }

        public async Task<RespContainer<FAGTextResponse>> Handle(EditFAGTextCommand request, CancellationToken cancellationToken)
        {
            FAGTextResponse result = await _fagTextService.EditFAGTextAsync(request.Data);
            return RespContainer.Ok(result, "FAGText Updated");
        }
    }
}
