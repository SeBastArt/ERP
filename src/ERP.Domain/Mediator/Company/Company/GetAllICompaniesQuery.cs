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
    public class GetAllCompaniesQuery : ReqContainer<GetAllCompanyRequest>, IRequest<ApiResult<CompanyResponse>>
    {
        public GetAllCompaniesQuery(GetAllCompanyRequest getAllCompanyRequest) : base(getAllCompanyRequest)
        { }
    }
    public class GetAllCompaniesQueryHandler : IRequestHandler<GetAllCompaniesQuery, ApiResult<CompanyResponse>>
    {
        private readonly ILogger<IRequest> _logger;
        private readonly ICompanyService _companyService;

        public GetAllCompaniesQueryHandler(ILogger<IRequest> logger, ICompanyService companyService)
        {
            _logger = logger;
            _companyService = companyService;
        }

        public async Task<ApiResult<CompanyResponse>> Handle(GetAllCompaniesQuery request, CancellationToken cancellationToken)
        {
            IQueryable<CompanyResponse> result = _companyService.GetCompaniesQuery();
            return await ApiResult<CompanyResponse>.CreateAsync(
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
