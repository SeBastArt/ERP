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
    public class EditArticlePlaceCommand : ReqContainer<EditArticlePlaceRequest>, IRequestWrapper<ArticlePlaceResponse>
    {
        public EditArticlePlaceCommand(EditArticlePlaceRequest editArticlePlaceRequest) : base(editArticlePlaceRequest)
        { }
    }

    public class EditArticlePlaceCommandHandler : IHandlerWrapper<EditArticlePlaceCommand, ArticlePlaceResponse>
    {

        private readonly IArticlePlaceService _articlePlaceService;
        private readonly IArticlePlaceMapper _articlePlaceMapper;
        private readonly ILogger<IRequest> _logger;

        public EditArticlePlaceCommandHandler(IArticlePlaceService articlePlaceService, IArticlePlaceMapper articlePlaceMapper, ILogger<IRequest> logger)
        {
            _articlePlaceService = articlePlaceService;
            _articlePlaceMapper = articlePlaceMapper;
            _logger = logger;
        }

        public async Task<RespContainer<ArticlePlaceResponse>> Handle(EditArticlePlaceCommand request, CancellationToken cancellationToken)
        {
            ArticlePlaceResponse result = await _articlePlaceService.EditArticlePlaceAsync(request.Data);
            return RespContainer.Ok(result, "ArticlePlace Updated");
        }
    }
}
