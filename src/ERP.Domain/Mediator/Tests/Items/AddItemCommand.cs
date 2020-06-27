using ERP.Domain.Logging;
using ERP.Domain.Mappers;
using ERP.Domain.Mediator.Wrapper;
using ERP.Domain.Requests;
using ERP.Domain.Responses;
using ERP.Domain.Respositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace ERP.Domain.Mediator.Commands
{
    public class AddItemCommand : ReqContainer<AddItemRequest>, IRequestWrapper<ItemResponse>
    {
        public AddItemCommand(AddItemRequest addItemRequest) : base(addItemRequest)
        {
        }
    }

    public class AddItemCommandHandler : IHandlerWrapper<AddItemCommand, ItemResponse>
    {
        private readonly IItemRespository _itemRespository;
        private readonly IItemMapper _itemMapper;
        private readonly ILogger<IRequest> _logger;

        public AddItemCommandHandler(IItemRespository itemRespository, IItemMapper itemMapper, ILogger<IRequest> logger)
        {
            _itemRespository = itemRespository;
            _itemMapper = itemMapper;
            _logger = logger;
        }

        public async Task<RespContainer<ItemResponse>> Handle(AddItemCommand request, CancellationToken cancellationToken)
        {
            Models.Item item = _itemMapper.Map(request.Data);
            Models.Item result = _itemRespository.Add(item);

            int modifiedRecords = await _itemRespository.UnitOfWork.SaveChangesAsync();

            _logger.LogInformation(Events.Add, Messages.NumberOfRecordAffected_modifiedRecords, modifiedRecords);
            _logger.LogInformation(Events.Add, Messages.ChangesApplied_id, result?.Id);

            return RespContainer.Ok(_itemMapper.Map(result), "Item Created");
        }
    }
}
