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
    public class GetAllFAGTextsQuery : ReqContainer<GetAllFAGTextRequest>, IRequest<ApiResult<FAGTextResponse>>
    {
        public GetAllFAGTextsQuery(GetAllFAGTextRequest getAllFAGTextRequest) : base(getAllFAGTextRequest)
        { }
    }
    public class GetAllFAGTextsQueryHandler : IRequestHandler<GetAllFAGTextsQuery, ApiResult<FAGTextResponse>>
    {
        private readonly ILogger<IRequest> _logger;
        private readonly IFAGTextService _fagTextService;

        public GetAllFAGTextsQueryHandler(ILogger<IRequest> logger, IFAGTextService fagTextService)
        {
            _logger = logger;
            _fagTextService = fagTextService;
        }

        public async Task<ApiResult<FAGTextResponse>> Handle(GetAllFAGTextsQuery request, CancellationToken cancellationToken)
        {
            IQueryable<FAGTextResponse> result = _fagTextService.GetFAGTextsQuery();
            return await ApiResult<FAGTextResponse>.CreateAsync(
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
