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
    public class GetItemQuery : ReqContainer<Guid>, IRequest<ItemResponse>
    {
        /// <summary>
        /// GetItemQuery
        /// </summary>
        /// <param name="id"></param>
        public GetItemQuery(Guid id) : base(id)
        { }
    }

    /// <summary>
    /// GetItemQueryHandler
    /// </summary>
    public class GetItemQueryHandler : IRequestHandler<GetItemQuery, ItemResponse>
    {
        private readonly ILogger<IRequest> _logger;
        private readonly IItemService _itemService;

        /// <summary>
        /// GetItemQueryHandler
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="itemService"></param>
        public GetItemQueryHandler(ILogger<IRequest> logger, IItemService itemService)
        {
            _logger = logger;
            _itemService = itemService;
        }

        public async Task<ItemResponse> Handle(GetItemQuery request, CancellationToken cancellationToken)
        {
            ItemResponse result = await _itemService.GetItemAsync(request.Data);
            return result;
        }
    }
}
