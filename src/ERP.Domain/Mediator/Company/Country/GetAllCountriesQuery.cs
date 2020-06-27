using ERP.Domain.Requests;
using ERP.Domain.Responses;
using ERP.Domain.Services;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ERP.Domain.Mediator.Queries
{
    public class GetAllCountriesQuery : ReqContainer<GetAllCountryRequest>, IRequest<ApiResult<CountryResponse>>
    {
        public GetAllCountriesQuery(GetAllCountryRequest getAllCountryRequest) : base(getAllCountryRequest)
        { }
    }
    public class GetAllCountriesQueryHandler : IRequestHandler<GetAllCountriesQuery, ApiResult<CountryResponse>>
    {
        private readonly ILogger<IRequest> _logger;
        private readonly ICountryService _countryService;

        public GetAllCountriesQueryHandler(ILogger<IRequest> logger, ICountryService countryService)
        {
            _logger = logger;
            _countryService = countryService;
        }

        public async Task<ApiResult<CountryResponse>> Handle(GetAllCountriesQuery request, CancellationToken cancellationToken)
        {
            IQueryable<CountryResponse> result = _countryService.GetCountriesQuery();
            return await ApiResult<CountryResponse>.CreateAsync(
                result,
                request.Data.PageIndex,
                request.Data.PageSize,
                request.Data.SortColumn,
                request.Data.SortOrder,
                request.Data.FilterColumn,
                request.Data.FilterQuery);
        }
    }
}
