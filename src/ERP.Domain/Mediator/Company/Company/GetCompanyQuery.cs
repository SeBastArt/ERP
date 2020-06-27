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
    public class GetCompanyQuery : ReqContainer<Guid>, IRequest<CompanyResponse>
    {
        /// <summary>
        /// GetCompanyQuery
        /// </summary>
        /// <param name="id"></param>
        public GetCompanyQuery(Guid id) : base(id)
        { }
    }

    /// <summary>
    /// GetCompanyQueryHandler
    /// </summary>
    public class GetCompanyQueryHandler : IRequestHandler<GetCompanyQuery, CompanyResponse>
    {
        private readonly ILogger<IRequest> _logger;
        private readonly ICompanyService _companyService;

        /// <summary>
        /// GetCompanyQueryHandler
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="companyService"></param>
        public GetCompanyQueryHandler(ILogger<IRequest> logger, ICompanyService companyService)
        {
            _logger = logger;
            _companyService = companyService;
        }

        public async Task<CompanyResponse> Handle(GetCompanyQuery request, CancellationToken cancellationToken)
        {
            CompanyResponse result = await _companyService.GetCompanyAsync(request.Data);
            return result;
        }
    }
}
