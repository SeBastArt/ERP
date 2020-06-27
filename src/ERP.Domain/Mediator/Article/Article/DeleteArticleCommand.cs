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
    public class DelteArticleCommand : ReqContainer<DeleteArticleRequest>, IRequestWrapper<EmptyResponse>
    {
        public DelteArticleCommand(DeleteArticleRequest request) : base(request)
        { }
    }

    public class DelteArticleCommandHandler : IHandlerWrapper<DelteArticleCommand, EmptyResponse>
    {
        private readonly IArticleService _articleService;
        private readonly IArticleMapper _articleMapper;
        private readonly ILogger<IRequest> _logger;

        public DelteArticleCommandHandler(IArticleService articleService, IArticleMapper articleMapper, ILogger<IRequest> logger)
        {
            _articleService = articleService;
            _articleMapper = articleMapper;
            _logger = logger;
        }

        public async Task<RespContainer<EmptyResponse>> Handle(DelteArticleCommand request, CancellationToken cancellationToken)
        {
            await _articleService.DeleteArticleAsync(request.Data);
            _logger.LogInformation($"Entity with { request.Data.Id} deleted");
            return RespContainer.Ok(new EmptyResponse(), "Article deleted");
        }
    }
}
