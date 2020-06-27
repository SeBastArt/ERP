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
    public class GetAllDocumentsQuery : ReqContainer<GetAllDocumentRequest>, IRequest<ApiResult<DocumentResponse>>
    {
        public GetAllDocumentsQuery(GetAllDocumentRequest getAllDocumentRequest) : base(getAllDocumentRequest)
        { }
    }
    public class GetAllDocumentsQueryHandler : IRequestHandler<GetAllDocumentsQuery, ApiResult<DocumentResponse>>
    {
        private readonly ILogger<IRequest> _logger;
        private readonly IDocumentService _documentService;

        public GetAllDocumentsQueryHandler(ILogger<IRequest> logger, IDocumentService documentService)
        {
            _logger = logger;
            _documentService = documentService;
        }

        public async Task<ApiResult<DocumentResponse>> Handle(GetAllDocumentsQuery request, CancellationToken cancellationToken)
        {
            IQueryable<DocumentResponse> result = _documentService.GetDocumentsQuery();
            return await ApiResult<DocumentResponse>.CreateAsync(
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
