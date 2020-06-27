using EntityFramework.Testing;
using ERP.Domain.Requests;
using ERP.Domain.Responses;
using ERP.Domain.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RiskFirst.Hateoas;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ERP.Domain.Mediator.Queries
{
    public class GetAllItemsHateoasQuery : ReqContainer<GetAllItemRequest>, IRequest<ApiResult<HateoasResponse<ItemResponse>>>
    {
        public GetAllItemsHateoasQuery(GetAllItemRequest getAllItemRequest) : base(getAllItemRequest)
        { }
    }
    public class GetAllItemsHateoasQueryHandler : IRequestHandler<GetAllItemsHateoasQuery, ApiResult<HateoasResponse<ItemResponse>>>
    {
        private readonly ILogger<IRequest> _logger;
        private readonly IItemService _itemService;
        private readonly ILinksService _linksService;

        public GetAllItemsHateoasQueryHandler(ILogger<IRequest> logger, IItemService itemService, ILinksService linkService)
        {
            _logger = logger;
            _itemService = itemService;
            _linksService = linkService;
        }

        public async Task<ApiResult<HateoasResponse<ItemResponse>>> Handle(GetAllItemsHateoasQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<ItemResponse> itemList = await _itemService.GetItemsQuery().ToListAsync();

            List<HateoasResponse<ItemResponse>> hateoasResults = new List<HateoasResponse<ItemResponse>>();

            foreach (ItemResponse itemResponse in itemList)
            {
                HateoasResponse<ItemResponse> hateoasResult = new HateoasResponse<ItemResponse>
                {
                    Data = itemResponse
                };
                await _linksService.AddLinksAsync(hateoasResult);

                hateoasResults.Add(hateoasResult);
            }
          
            IQueryable<HateoasResponse<ItemResponse>> test = hateoasResults.AsQueryable();

            ApiResult<HateoasResponse<ItemResponse>> pagedItems = await ApiResult<HateoasResponse<ItemResponse>>.CreateAsync(
                test,
                request.Data.PageIndex,
                request.Data.PageSize,
                request.Data.SortColumn,
                request.Data.SortOrder,
                request.Data.FilterColumn,
                request.Data.FilterQuery);


            return pagedItems;
        }
    }
}
