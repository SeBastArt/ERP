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
    public class AddPersonCommand : ReqContainer<AddPersonRequest>, IRequestWrapper<PersonResponse>
    {
        public AddPersonCommand(AddPersonRequest addPersonRequest) : base(addPersonRequest)
        {
        }
    }

    public class AddPersonCommandHandler : IHandlerWrapper<AddPersonCommand, PersonResponse>
    {
        private readonly IPersonRespository _personRespository;
        private readonly IPersonMapper _personMapper;
        private readonly ILogger<IRequest> _logger;

        public AddPersonCommandHandler(IPersonRespository personRespository, IPersonMapper personMapper, ILogger<IRequest> logger)
        {
            _personRespository = personRespository;
            _personMapper = personMapper;
            _logger = logger;
        }

        public async Task<RespContainer<PersonResponse>> Handle(AddPersonCommand request, CancellationToken cancellationToken)
        {
            Models.Person person = _personMapper.Map(request.Data);
            Models.Person result = _personRespository.Add(person);

            int modifiedRecords = await _personRespository.UnitOfWork.SaveChangesAsync();

            _logger.LogInformation(Events.Add, Messages.NumberOfRecordAffected_modifiedRecords, modifiedRecords);
            _logger.LogInformation(Events.Add, Messages.ChangesApplied_id, result?.Id);

            return RespContainer.Ok(_personMapper.Map(result), "Person Created");
        }
    }
}
