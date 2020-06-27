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
    public class EditPersonCommand : ReqContainer<EditPersonRequest>, IRequestWrapper<PersonResponse>
    {
        public EditPersonCommand(EditPersonRequest editPersonRequest) : base(editPersonRequest)
        { }
    }

    public class EditPersonCommandHandler : IHandlerWrapper<EditPersonCommand, PersonResponse>
    {

        private readonly IPersonService _personService;
        private readonly IPersonMapper _personMapper;
        private readonly ILogger<IRequest> _logger;

        public EditPersonCommandHandler(IPersonService personService, IPersonMapper personMapper, ILogger<IRequest> logger)
        {
            _personService = personService;
            _personMapper = personMapper;
            _logger = logger;
        }

        public async Task<RespContainer<PersonResponse>> Handle(EditPersonCommand request, CancellationToken cancellationToken)
        {
            PersonResponse result = await _personService.EditPersonAsync(request.Data);
            return RespContainer.Ok(result, "Person Updated");
        }
    }
}
