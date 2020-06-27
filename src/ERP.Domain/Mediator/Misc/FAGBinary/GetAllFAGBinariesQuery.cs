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
    public class GetAllFAGBinariesQuery : ReqContainer<GetAllFAGBinaryRequest>, IRequest<ApiResult<FAGBinaryResponse>>
    {
        public GetAllFAGBinariesQuery(GetAllFAGBinaryRequest getAllFAGBinaryRequest) : base(getAllFAGBinaryRequest)
        { }
    }
    public class GetAllFAGBinariesQueryHandler : IRequestHandler<GetAllFAGBinariesQuery, ApiResult<FAGBinaryResponse>>
    {
        private readonly ILogger<IRequest> _logger;
        private readonly IFAGBinaryService _fagBinaryService;

        public GetAllFAGBinariesQueryHandler(ILogger<IRequest> logger, IFAGBinaryService fagBinaryService)
        {
            _logger = logger;
            _fagBinaryService = fagBinaryService;
        }

        public async Task<ApiResult<FAGBinaryResponse>> Handle(GetAllFAGBinariesQuery request, CancellationToken cancellationToken)
        {
            IQueryable<FAGBinaryResponse> result = _fagBinaryService.GetFAGBinariesQuery();
            return await ApiResult<FAGBinaryResponse>.CreateAsync(
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
