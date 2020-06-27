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
    public class EditArticleRangeCommand : ReqContainer<EditArticleRangeRequest>, IRequestWrapper<ArticleRangeResponse>
    {
        public EditArticleRangeCommand(EditArticleRangeRequest editArticleRangeRequest) : base(editArticleRangeRequest)
        { }
    }

    public class EditArticleRangeCommandHandler : IHandlerWrapper<EditArticleRangeCommand, ArticleRangeResponse>
    {

        private readonly IArticleRangeService _articleRangeService;
        private readonly IArticleRangeMapper _articleRangeMapper;
        private readonly ILogger<IRequest> _logger;

        public EditArticleRangeCommandHandler(IArticleRangeService articleRangeService, IArticleRangeMapper articleRangeMapper, ILogger<IRequest> logger)
        {
            _articleRangeService = articleRangeService;
            _articleRangeMapper = articleRangeMapper;
            _logger = logger;
        }

        public async Task<RespContainer<ArticleRangeResponse>> Handle(EditArticleRangeCommand request, CancellationToken cancellationToken)
        {
            ArticleRangeResponse result = await _articleRangeService.EditArticleRangeAsync(request.Data);
            return RespContainer.Ok(result, "ArticleRange Updated");
        }
    }
}
