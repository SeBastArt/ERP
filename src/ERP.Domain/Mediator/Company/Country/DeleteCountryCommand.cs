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
    public class DelteCountryCommand : ReqContainer<DeleteCountryRequest>, IRequestWrapper<EmptyResponse>
    {
        public DelteCountryCommand(DeleteCountryRequest request) : base(request)
        { }
    }

    public class DelteCountryCommandHandler : IHandlerWrapper<DelteCountryCommand, EmptyResponse>
    {
        private readonly ICountryService _countryService;
        private readonly ICountryMapper _countryMapper;
        private readonly ILogger<IRequest> _logger;

        public DelteCountryCommandHandler(ICountryService countryService, ICountryMapper countryMapper, ILogger<IRequest> logger)
        {
            _countryService = countryService;
            _countryMapper = countryMapper;
            _logger = logger;
        }

        public async Task<RespContainer<EmptyResponse>> Handle(DelteCountryCommand request, CancellationToken cancellationToken)
        {
            await _countryService.DeleteCountryAsync(request.Data);
            _logger.LogInformation($"Entity with { request.Data.Id} deleted");
            return RespContainer.Ok(new EmptyResponse(), "Country deleted");
        }
    }
}
