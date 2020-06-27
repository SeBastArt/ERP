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
    public class GetCompanyTypeQuery : ReqContainer<Guid>, IRequest<CompanyTypeResponse>
    {
        /// <summary>
        /// GetCompanyTypeQuery
        /// </summary>
        /// <param name="id"></param>
        public GetCompanyTypeQuery(Guid id) : base(id)
        { }
    }

    /// <summary>
    /// GetCompanyTypeQueryHandler
    /// </summary>
    public class GetCompanyTypeQueryHandler : IRequestHandler<GetCompanyTypeQuery, CompanyTypeResponse>
    {
        private readonly ILogger<IRequest> _logger;
        private readonly ICompanyTypeService _companyTypeService;

        /// <summary>
        /// GetCompanyTypeQueryHandler
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="companyTypeService"></param>
        public GetCompanyTypeQueryHandler(ILogger<IRequest> logger, ICompanyTypeService companyTypeService)
        {
            _logger = logger;
            _companyTypeService = companyTypeService;
        }

        public async Task<CompanyTypeResponse> Handle(GetCompanyTypeQuery request, CancellationToken cancellationToken)
        {
            CompanyTypeResponse result = await _companyTypeService.GetCompanyTypeAsync(request.Data);
            return result;
        }
    }
}
