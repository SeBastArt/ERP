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
    public class GetAllItemsQuery : ReqContainer<GetAllItemRequest>, IRequest<ApiResult<ItemResponse>>
    {
        public GetAllItemsQuery(GetAllItemRequest getAllItemRequest) : base(getAllItemRequest)
        { }
    }
    public class GetAllItemsQueryHandler : IRequestHandler<GetAllItemsQuery, ApiResult<ItemResponse>>
    {
        private readonly ILogger<IRequest> _logger;
        private readonly IItemService _itemService;

        public GetAllItemsQueryHandler(ILogger<IRequest> logger, IItemService itemService)
        {
            _logger = logger;
            _itemService = itemService;
        }

        public async Task<ApiResult<ItemResponse>> Handle(GetAllItemsQuery request, CancellationToken cancellationToken)
        {
            IQueryable<ItemResponse> result = _itemService.GetItemsQuery();
            return await ApiResult<ItemResponse>.CreateAsync(
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
