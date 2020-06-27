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
    public class EditArticleInventoryCommand : ReqContainer<EditArticleInventoryRequest>, IRequestWrapper<ArticleInventoryResponse>
    {
        public EditArticleInventoryCommand(EditArticleInventoryRequest editArticleInventoryRequest) : base(editArticleInventoryRequest)
        { }
    }

    public class EditArticleInventoryCommandHandler : IHandlerWrapper<EditArticleInventoryCommand, ArticleInventoryResponse>
    {

        private readonly IArticleInventoryService _articleInventoryService;
        private readonly IArticleInventoryMapper _articleInventoryMapper;
        private readonly ILogger<IRequest> _logger;

        public EditArticleInventoryCommandHandler(IArticleInventoryService articleInventoryService, IArticleInventoryMapper articleInventoryMapper, ILogger<IRequest> logger)
        {
            _articleInventoryService = articleInventoryService;
            _articleInventoryMapper = articleInventoryMapper;
            _logger = logger;
        }

        public async Task<RespContainer<ArticleInventoryResponse>> Handle(EditArticleInventoryCommand request, CancellationToken cancellationToken)
        {
            ArticleInventoryResponse result = await _articleInventoryService.EditArticleInventoryAsync(request.Data);
            return RespContainer.Ok(result, "ArticleInventory Updated");
        }
    }
}
