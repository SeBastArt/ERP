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
    public class EditArticleGroupCommand : ReqContainer<EditArticleGroupRequest>, IRequestWrapper<ArticleGroupResponse>
    {
        public EditArticleGroupCommand(EditArticleGroupRequest editArticleGroupRequest) : base(editArticleGroupRequest)
        { }
    }

    public class EditArticleGroupCommandHandler : IHandlerWrapper<EditArticleGroupCommand, ArticleGroupResponse>
    {

        private readonly IArticleGroupService _articleGroupService;
        private readonly IArticleGroupMapper _articleGroupMapper;
        private readonly ILogger<IRequest> _logger;

        public EditArticleGroupCommandHandler(IArticleGroupService articleGroupService, IArticleGroupMapper articleGroupMapper, ILogger<IRequest> logger)
        {
            _articleGroupService = articleGroupService;
            _articleGroupMapper = articleGroupMapper;
            _logger = logger;
        }

        public async Task<RespContainer<ArticleGroupResponse>> Handle(EditArticleGroupCommand request, CancellationToken cancellationToken)
        {
            ArticleGroupResponse result = await _articleGroupService.EditArticleGroupAsync(request.Data);
            return RespContainer.Ok(result, "ArticleGroup Updated");
        }
    }
}
