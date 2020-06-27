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
    public class AddArticleGroupCommand : ReqContainer<AddArticleGroupRequest>, IRequestWrapper<ArticleGroupResponse>
    {
        public AddArticleGroupCommand(AddArticleGroupRequest addArticleGroupRequest) : base(addArticleGroupRequest)
        {
        }
    }

    public class AddArticleGroupCommandHandler : IHandlerWrapper<AddArticleGroupCommand, ArticleGroupResponse>
    {
        private readonly IArticleGroupRespository _articleGroupRespository;
        private readonly IArticleGroupMapper _articleGroupMapper;
        private readonly ILogger<IRequest> _logger;

        public AddArticleGroupCommandHandler(IArticleGroupRespository articleGroupRespository, IArticleGroupMapper articleGroupMapper, ILogger<IRequest> logger)
        {
            _articleGroupRespository = articleGroupRespository;
            _articleGroupMapper = articleGroupMapper;
            _logger = logger;
        }

        public async Task<RespContainer<ArticleGroupResponse>> Handle(AddArticleGroupCommand request, CancellationToken cancellationToken)
        {
            Models.ArticleGroup articleGroup = _articleGroupMapper.Map(request.Data);
            Models.ArticleGroup result = _articleGroupRespository.Add(articleGroup);

            int modifiedRecords = await _articleGroupRespository.UnitOfWork.SaveChangesAsync();

            _logger.LogInformation(Events.Add, Messages.NumberOfRecordAffected_modifiedRecords, modifiedRecords);
            _logger.LogInformation(Events.Add, Messages.ChangesApplied_id, result?.Id);

            return RespContainer.Ok(_articleGroupMapper.Map(result), "ArticleGroup Created");
        }
    }
}
