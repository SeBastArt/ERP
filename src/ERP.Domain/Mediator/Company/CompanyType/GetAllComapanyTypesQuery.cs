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
    public class GetAllCompanyTypesQuery : ReqContainer<GetAllCompanyTypeRequest>, IRequest<ApiResult<CompanyTypeResponse>>
    {
        public GetAllCompanyTypesQuery(GetAllCompanyTypeRequest getAllCompanyTypeRequest) : base(getAllCompanyTypeRequest)
        { }
    }
    public class GetAllCompanyTypesQueryHandler : IRequestHandler<GetAllCompanyTypesQuery, ApiResult<CompanyTypeResponse>>
    {
        private readonly ILogger<IRequest> _logger;
        private readonly ICompanyTypeService _companyTypeService;

        public GetAllCompanyTypesQueryHandler(ILogger<IRequest> logger, ICompanyTypeService companyTypeService)
        {
            _logger = logger;
            _companyTypeService = companyTypeService;
        }

        public async Task<ApiResult<CompanyTypeResponse>> Handle(GetAllCompanyTypesQuery request, CancellationToken cancellationToken)
        {
            IQueryable<CompanyTypeResponse> result = _companyTypeService.GetCompanyTypesQuery();
            return await ApiResult<CompanyTypeResponse>.CreateAsync(
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
