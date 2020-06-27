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
    public class EditArticleCommand : ReqContainer<EditArticleRequest>, IRequestWrapper<ArticleResponse>
    {
        public EditArticleCommand(EditArticleRequest editArticleRequest) : base(editArticleRequest)
        { }
    }

    public class EditArticleCommandHandler : IHandlerWrapper<EditArticleCommand, ArticleResponse>
    {

        private readonly IArticleService _articleService;
        private readonly IArticleMapper _articleMapper;
        private readonly ILogger<IRequest> _logger;

        public EditArticleCommandHandler(IArticleService articleService, IArticleMapper articleMapper, ILogger<IRequest> logger)
        {
            _articleService = articleService;
            _articleMapper = articleMapper;
            _logger = logger;
        }

        public async Task<RespContainer<ArticleResponse>> Handle(EditArticleCommand request, CancellationToken cancellationToken)
        {
            ArticleResponse result = await _articleService.EditArticleAsync(request.Data);
            return RespContainer.Ok(result, "Article Updated");
        }
    }
}
