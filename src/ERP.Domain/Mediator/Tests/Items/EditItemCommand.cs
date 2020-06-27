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
    public class EditItemCommand : ReqContainer<EditItemRequest>, IRequestWrapper<ItemResponse>
    {
        public EditItemCommand(EditItemRequest editItemRequest) : base(editItemRequest)
        { }
    }

    public class EditItemCommandHandler : IHandlerWrapper<EditItemCommand, ItemResponse>
    {

        private readonly IItemService _itemService;
        private readonly IItemMapper _itemMapper;
        private readonly ILogger<IRequest> _logger;

        public EditItemCommandHandler(IItemService itemService, IItemMapper itemMapper, ILogger<IRequest> logger)
        {
            _itemService = itemService;
            _itemMapper = itemMapper;
            _logger = logger;
        }

        public async Task<RespContainer<ItemResponse>> Handle(EditItemCommand request, CancellationToken cancellationToken)
        {
            ItemResponse result = await _itemService.EditItemAsync(request.Data);
            return RespContainer.Ok(result, "Item Updated");
        }
    }
}
