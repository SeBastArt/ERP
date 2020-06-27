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
    public class DelteArticleGroupCommand : ReqContainer<DeleteArticleGroupRequest>, IRequestWrapper<EmptyResponse>
    {
        public DelteArticleGroupCommand(DeleteArticleGroupRequest request) : base(request)
        { }
    }

    public class DelteArticleGroupCommandHandler : IHandlerWrapper<DelteArticleGroupCommand, EmptyResponse>
    {
        private readonly IArticleGroupService _articleGroupService;
        private readonly IArticleGroupMapper _articleGroupMapper;
        private readonly ILogger<IRequest> _logger;

        public DelteArticleGroupCommandHandler(IArticleGroupService articleGroupService, IArticleGroupMapper articleGroupMapper, ILogger<IRequest> logger)
        {
            _articleGroupService = articleGroupService;
            _articleGroupMapper = articleGroupMapper;
            _logger = logger;
        }

        public async Task<RespContainer<EmptyResponse>> Handle(DelteArticleGroupCommand request, CancellationToken cancellationToken)
        {
            await _articleGroupService.DeleteArticleGroupAsync(request.Data);
            _logger.LogInformation($"Entity with { request.Data.Id} deleted");
            return RespContainer.Ok(new EmptyResponse(), "ArticleGroup deleted");
        }
    }
}
