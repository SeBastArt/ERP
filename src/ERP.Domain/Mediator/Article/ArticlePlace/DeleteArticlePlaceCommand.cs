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
    public class DelteArticlePlaceCommand : ReqContainer<DeleteArticlePlaceRequest>, IRequestWrapper<EmptyResponse>
    {
        public DelteArticlePlaceCommand(DeleteArticlePlaceRequest request) : base(request)
        { }
    }

    public class DelteArticlePlaceCommandHandler : IHandlerWrapper<DelteArticlePlaceCommand, EmptyResponse>
    {
        private readonly IArticlePlaceService _articlePlaceService;
        private readonly IArticlePlaceMapper _articlePlaceMapper;
        private readonly ILogger<IRequest> _logger;

        public DelteArticlePlaceCommandHandler(IArticlePlaceService articlePlaceService, IArticlePlaceMapper articlePlaceMapper, ILogger<IRequest> logger)
        {
            _articlePlaceService = articlePlaceService;
            _articlePlaceMapper = articlePlaceMapper;
            _logger = logger;
        }

        public async Task<RespContainer<EmptyResponse>> Handle(DelteArticlePlaceCommand request, CancellationToken cancellationToken)
        {
            await _articlePlaceService.DeleteArticlePlaceAsync(request.Data);
            _logger.LogInformation($"Entity with { request.Data.Id} deleted");
            return RespContainer.Ok(new EmptyResponse(), "ArticlePlace deleted");
        }
    }
}
