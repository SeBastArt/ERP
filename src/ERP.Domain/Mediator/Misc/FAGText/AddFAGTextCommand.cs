using ERP.Domain.Logging;
using ERP.Domain.Mappers;
using ERP.Domain.Mediator.Wrapper;
using ERP.Domain.Requests;
using ERP.Domain.Responses;
using ERP.Domain.Respositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace ERP.Domain.Mediator.Commands
{
    public class AddFAGTextCommand : ReqContainer<AddFAGTextRequest>, IRequestWrapper<FAGTextResponse>
    {
        public AddFAGTextCommand(AddFAGTextRequest addFAGTextRequest) : base(addFAGTextRequest)
        {
        }
    }

    public class AddFAGTextCommandHandler : IHandlerWrapper<AddFAGTextCommand, FAGTextResponse>
    {
        private readonly IFAGTextRespository _fagTextRespository;
        private readonly IFAGTextMapper _fagTextMapper;
        private readonly ILogger<IRequest> _logger;

        public AddFAGTextCommandHandler(IFAGTextRespository fagTextRespository, IFAGTextMapper fagTextMapper, ILogger<IRequest> logger)
        {
            _fagTextRespository = fagTextRespository;
            _fagTextMapper = fagTextMapper;
            _logger = logger;
        }

        public async Task<RespContainer<FAGTextResponse>> Handle(AddFAGTextCommand request, CancellationToken cancellationToken)
        {
            Models.FAGText fagText = _fagTextMapper.Map(request.Data);
            Models.FAGText result = _fagTextRespository.Add(fagText);

            int modifiedRecords = await _fagTextRespository.UnitOfWork.SaveChangesAsync();

            _logger.LogInformation(Events.Add, Messages.NumberOfRecordAffected_modifiedRecords, modifiedRecords);
            _logger.LogInformation(Events.Add, Messages.ChangesApplied_id, result?.Id);

            return RespContainer.Ok(_fagTextMapper.Map(result), "FAGText Created");
        }
    }
}
