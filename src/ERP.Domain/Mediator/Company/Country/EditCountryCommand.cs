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
    public class EditCountryCommand : ReqContainer<EditCountryRequest>, IRequestWrapper<CountryResponse>
    {
        public EditCountryCommand(EditCountryRequest editCountryRequest) : base(editCountryRequest)
        { }
    }

    public class EditCountryCommandHandler : IHandlerWrapper<EditCountryCommand, CountryResponse>
    {

        private readonly ICountryService _countryService;
        private readonly ICountryMapper _countryMapper;
        private readonly ILogger<IRequest> _logger;

        public EditCountryCommandHandler(ICountryService countryService, ICountryMapper countryMapper, ILogger<IRequest> logger)
        {
            _countryService = countryService;
            _countryMapper = countryMapper;
            _logger = logger;
        }

        public async Task<RespContainer<CountryResponse>> Handle(EditCountryCommand request, CancellationToken cancellationToken)
        {
            CountryResponse result = await _countryService.EditCountryAsync(request.Data);
            return RespContainer.Ok(result, "Country Updated");
        }
    }
}
