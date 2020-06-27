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
    public class DelteArticleInventoryCommand : ReqContainer<DeleteArticleInventoryRequest>, IRequestWrapper<EmptyResponse>
    {
        public DelteArticleInventoryCommand(DeleteArticleInventoryRequest request) : base(request)
        { }
    }

    public class DelteArticleInventoryCommandHandler : IHandlerWrapper<DelteArticleInventoryCommand, EmptyResponse>
    {
        private readonly IArticleInventoryService _articleInventoryService;
        private readonly IArticleInventoryMapper _articleInventoryMapper;
        private readonly ILogger<IRequest> _logger;

        public DelteArticleInventoryCommandHandler(IArticleInventoryService articleInventoryService, IArticleInventoryMapper articleInventoryMapper, ILogger<IRequest> logger)
        {
            _articleInventoryService = articleInventoryService;
            _articleInventoryMapper = articleInventoryMapper;
            _logger = logger;
        }

        public async Task<RespContainer<EmptyResponse>> Handle(DelteArticleInventoryCommand request, CancellationToken cancellationToken)
        {
            await _articleInventoryService.DeleteArticleInventoryAsync(request.Data);
            _logger.LogInformation($"Entity with { request.Data.Id} deleted");
            return RespContainer.Ok(new EmptyResponse(), "ArticleInventory deleted");
        }
    }
}
