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
    public class AddFAGBinaryCommand : ReqContainer<AddFAGBinaryRequest>, IRequestWrapper<FAGBinaryResponse>
    {
        public AddFAGBinaryCommand(AddFAGBinaryRequest addFAGBinaryRequest) : base(addFAGBinaryRequest)
        {
        }
    }

    public class AddFAGBinaryCommandHandler : IHandlerWrapper<AddFAGBinaryCommand, FAGBinaryResponse>
    {
        private readonly IFAGBinaryRespository _fagBinaryRespository;
        private readonly IFAGBinaryMapper _fagBinaryMapper;
        private readonly ILogger<IRequest> _logger;

        public AddFAGBinaryCommandHandler(IFAGBinaryRespository fagBinaryRespository, IFAGBinaryMapper fagBinaryMapper, ILogger<IRequest> logger)
        {
            _fagBinaryRespository = fagBinaryRespository;
            _fagBinaryMapper = fagBinaryMapper;
            _logger = logger;
        }

        public async Task<RespContainer<FAGBinaryResponse>> Handle(AddFAGBinaryCommand request, CancellationToken cancellationToken)
        {
            Models.FAGBinary fagBinary = _fagBinaryMapper.Map(request.Data);
            Models.FAGBinary result = _fagBinaryRespository.Add(fagBinary);

            int modifiedRecords = await _fagBinaryRespository.UnitOfWork.SaveChangesAsync();

            _logger.LogInformation(Events.Add, Messages.NumberOfRecordAffected_modifiedRecords, modifiedRecords);
            _logger.LogInformation(Events.Add, Messages.ChangesApplied_id, result?.Id);

            return RespContainer.Ok(_fagBinaryMapper.Map(result), "FAGBinary Created");
        }
    }
}
