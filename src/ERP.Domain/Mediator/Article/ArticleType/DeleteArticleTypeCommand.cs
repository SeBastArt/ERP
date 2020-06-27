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
    public class DelteArticleTypeCommand : ReqContainer<DeleteArticleTypeRequest>, IRequestWrapper<EmptyResponse>
    {
        public DelteArticleTypeCommand(DeleteArticleTypeRequest request) : base(request)
        { }
    }

    public class DelteArticleTypeCommandHandler : IHandlerWrapper<DelteArticleTypeCommand, EmptyResponse>
    {
        private readonly IArticleTypeService _articleTypeService;
        private readonly IArticleTypeMapper _articleTypeMapper;
        private readonly ILogger<IRequest> _logger;

        public DelteArticleTypeCommandHandler(IArticleTypeService articleTypeService, IArticleTypeMapper articleTypeMapper, ILogger<IRequest> logger)
        {
            _articleTypeService = articleTypeService;
            _articleTypeMapper = articleTypeMapper;
            _logger = logger;
        }

        public async Task<RespContainer<EmptyResponse>> Handle(DelteArticleTypeCommand request, CancellationToken cancellationToken)
        {
            await _articleTypeService.DeleteArticleTypeAsync(request.Data);
            _logger.LogInformation($"Entity with { request.Data.Id} deleted");
            return RespContainer.Ok(new EmptyResponse(), "ArticleType deleted");
        }
    }
}
