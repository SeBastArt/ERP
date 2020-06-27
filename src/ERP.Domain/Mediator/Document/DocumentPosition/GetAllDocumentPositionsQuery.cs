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
    public class GetAllDocumentPositionsQuery : ReqContainer<GetAllDocumentPositionRequest>, IRequest<ApiResult<DocumentPositionResponse>>
    {
        public GetAllDocumentPositionsQuery(GetAllDocumentPositionRequest getAllDocumentPositionRequest) : base(getAllDocumentPositionRequest)
        { }
    }
    public class GetAllDocumentPositionsQueryHandler : IRequestHandler<GetAllDocumentPositionsQuery, ApiResult<DocumentPositionResponse>>
    {
        private readonly ILogger<IRequest> _logger;
        private readonly IDocumentPositionService _documentPositionService;

        public GetAllDocumentPositionsQueryHandler(ILogger<IRequest> logger, IDocumentPositionService documentPositionService)
        {
            _logger = logger;
            _documentPositionService = documentPositionService;
        }

        public async Task<ApiResult<DocumentPositionResponse>> Handle(GetAllDocumentPositionsQuery request, CancellationToken cancellationToken)
        {
            IQueryable<DocumentPositionResponse> result = _documentPositionService.GetDocumentPositionsQuery();
            return await ApiResult<DocumentPositionResponse>.CreateAsync(
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
