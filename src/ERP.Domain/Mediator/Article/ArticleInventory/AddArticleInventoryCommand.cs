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
    public class AddArticleInventoryCommand : ReqContainer<AddArticleInventoryRequest>, IRequestWrapper<ArticleInventoryResponse>
    {
        public AddArticleInventoryCommand(AddArticleInventoryRequest addArticleInventoryRequest) : base(addArticleInventoryRequest)
        {
        }
    }

    public class AddArticleInventoryCommandHandler : IHandlerWrapper<AddArticleInventoryCommand, ArticleInventoryResponse>
    {
        private readonly IArticleInventoryRespository _articleInventoryRespository;
        private readonly IArticleInventoryMapper _articleInventoryMapper;
        private readonly ILogger<IRequest> _logger;

        public AddArticleInventoryCommandHandler(IArticleInventoryRespository articleInventoryRespository, IArticleInventoryMapper articleInventoryMapper, ILogger<IRequest> logger)
        {
            _articleInventoryRespository = articleInventoryRespository;
            _articleInventoryMapper = articleInventoryMapper;
            _logger = logger;
        }

        public async Task<RespContainer<ArticleInventoryResponse>> Handle(AddArticleInventoryCommand request, CancellationToken cancellationToken)
        {
            Models.ArticleInventory articleInventory = _articleInventoryMapper.Map(request.Data);
            Models.ArticleInventory result = _articleInventoryRespository.Add(articleInventory);

            int modifiedRecords = await _articleInventoryRespository.UnitOfWork.SaveChangesAsync();

            _logger.LogInformation(Events.Add, Messages.NumberOfRecordAffected_modifiedRecords, modifiedRecords);
            _logger.LogInformation(Events.Add, Messages.ChangesApplied_id, result?.Id);

            return RespContainer.Ok(_articleInventoryMapper.Map(result), "ArticleInventory Created");
        }
    }
}
