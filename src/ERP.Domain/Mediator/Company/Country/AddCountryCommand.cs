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
    public class AddCountryCommand : ReqContainer<AddCountryRequest>, IRequestWrapper<CountryResponse>
    {
        public AddCountryCommand(AddCountryRequest addCountryRequest) : base(addCountryRequest)
        {
        }
    }

    public class AddCountryCommandHandler : IHandlerWrapper<AddCountryCommand, CountryResponse>
    {
        private readonly ICountryRespository _countryRespository;
        private readonly ICountryMapper _countryMapper;
        private readonly ILogger<IRequest> _logger;

        public AddCountryCommandHandler(ICountryRespository countryRespository, ICountryMapper countryMapper, ILogger<IRequest> logger)
        {
            _countryRespository = countryRespository;
            _countryMapper = countryMapper;
            _logger = logger;
        }

        public async Task<RespContainer<CountryResponse>> Handle(AddCountryCommand request, CancellationToken cancellationToken)
        {
            Models.Country country = _countryMapper.Map(request.Data);
            Models.Country result = _countryRespository.Add(country);

            int modifiedRecords = await _countryRespository.UnitOfWork.SaveChangesAsync();

            _logger.LogInformation(Events.Add, Messages.NumberOfRecordAffected_modifiedRecords, modifiedRecords);
            _logger.LogInformation(Events.Add, Messages.ChangesApplied_id, result?.Id);

            return RespContainer.Ok(_countryMapper.Map(result), "Country Created");
        }
    }
}
