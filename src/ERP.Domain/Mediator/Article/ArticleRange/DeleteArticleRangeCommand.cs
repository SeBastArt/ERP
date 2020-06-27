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
    public class DelteArticleRangeCommand : ReqContainer<DeleteArticleRangeRequest>, IRequestWrapper<EmptyResponse>
    {
        public DelteArticleRangeCommand(DeleteArticleRangeRequest request) : base(request)
        { }
    }

    public class DelteArticleRangeCommandHandler : IHandlerWrapper<DelteArticleRangeCommand, EmptyResponse>
    {
        private readonly IArticleRangeService _articleRangeService;
        private readonly IArticleRangeMapper _articleRangeMapper;
        private readonly ILogger<IRequest> _logger;

        public DelteArticleRangeCommandHandler(IArticleRangeService articleRangeService, IArticleRangeMapper articleRangeMapper, ILogger<IRequest> logger)
        {
            _articleRangeService = articleRangeService;
            _articleRangeMapper = articleRangeMapper;
            _logger = logger;
        }

        public async Task<RespContainer<EmptyResponse>> Handle(DelteArticleRangeCommand request, CancellationToken cancellationToken)
        {
            await _articleRangeService.DeleteArticleRangeAsync(request.Data);
            _logger.LogInformation($"Entity with { request.Data.Id} deleted");
            return RespContainer.Ok(new EmptyResponse(), "ArticleRange deleted");
        }
    }
}
