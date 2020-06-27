using ERP.Domain.Mappers;
using ERP.Domain.Mediator.Wrapper;
using ERP.Domain.Requests;
using ERP.Domain.Responses;
using ERP.Domain.Services;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace ERP.Domain.Mediator.Commands
{
    public class DelteItemCommand : ReqContainer<DeleteItemRequest>, IRequestWrapper<EmptyResponse>
    {
        public DelteItemCommand(DeleteItemRequest request) : base(request)
        { }
    }

    public class DelteItemCommandHandler : IHandlerWrapper<DelteItemCommand, EmptyResponse>
    {
        private readonly IItemService _itemService;
        private readonly IItemMapper _itemMapper;
        private readonly ILogger<IRequest> _logger;

        public DelteItemCommandHandler(IItemService itemService, IItemMapper itemMapper, ILogger<IRequest> logger)
        {
            _itemService = itemService;
            _itemMapper = itemMapper;
            _logger = logger;
        }

        public async Task<RespContainer<EmptyResponse>> Handle(DelteItemCommand request, CancellationToken cancellationToken)
        {
            await _itemService.DeleteItemAsync(request.Data);
            _logger.LogInformation($"Entity with { request.Data.Id} deleted");
            return RespContainer.Ok(new EmptyResponse(), "Item deleted");
        }
    }
}
