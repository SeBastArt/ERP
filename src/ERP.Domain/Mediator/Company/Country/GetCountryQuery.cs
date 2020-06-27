using ERP.Domain.Requests;
using ERP.Domain.Responses;
using ERP.Domain.Services;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ERP.Domain.Mediator.Queries
{
    public class GetCountryQuery : ReqContainer<Guid>, IRequest<CountryResponse>
    {
        /// <summary>
        /// GetCountryQuery
        /// </summary>
        /// <param name="id"></param>
        public GetCountryQuery(Guid id) : base(id)
        { }
    }

    /// <summary>
    /// GetCountryQueryHandler
    /// </summary>
    public class GetCountryQueryHandler : IRequestHandler<GetCountryQuery, CountryResponse>
    {
        private readonly ILogger<IRequest> _logger;
        private readonly ICountryService _countryService;

        /// <summary>
        /// GetCountryQueryHandler
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="countryService"></param>
        public GetCountryQueryHandler(ILogger<IRequest> logger, ICountryService countryService)
        {
            _logger = logger;
            _countryService = countryService;
        }

        public async Task<CountryResponse> Handle(GetCountryQuery request, CancellationToken cancellationToken)
        {
            CountryResponse result = await _countryService.GetCountryAsync(request.Data);
            return result;
        }
    }
}
