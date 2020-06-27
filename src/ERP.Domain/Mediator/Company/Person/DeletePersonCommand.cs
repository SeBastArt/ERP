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
    public class DeltePersonCommand : ReqContainer<DeletePersonRequest>, IRequestWrapper<EmptyResponse>
    {
        public DeltePersonCommand(DeletePersonRequest request) : base(request)
        { }
    }

    public class DeltePersonCommandHandler : IHandlerWrapper<DeltePersonCommand, EmptyResponse>
    {
        private readonly IPersonService _personService;
        private readonly IPersonMapper _personMapper;
        private readonly ILogger<IRequest> _logger;

        public DeltePersonCommandHandler(IPersonService personService, IPersonMapper personMapper, ILogger<IRequest> logger)
        {
            _personService = personService;
            _personMapper = personMapper;
            _logger = logger;
        }

        public async Task<RespContainer<EmptyResponse>> Handle(DeltePersonCommand request, CancellationToken cancellationToken)
        {
            await _personService.DeletePersonAsync(request.Data);
            _logger.LogInformation($"Entity with { request.Data.Id} deleted");
            return RespContainer.Ok(new EmptyResponse(), "Person deleted");
        }
    }
}
