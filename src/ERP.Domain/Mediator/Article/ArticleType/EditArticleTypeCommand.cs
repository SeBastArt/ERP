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
    public class EditArticleTypeCommand : ReqContainer<EditArticleTypeRequest>, IRequestWrapper<ArticleTypeResponse>
    {
        public EditArticleTypeCommand(EditArticleTypeRequest editArticleTypeRequest) : base(editArticleTypeRequest)
        { }
    }

    public class EditArticleTypeCommandHandler : IHandlerWrapper<EditArticleTypeCommand, ArticleTypeResponse>
    {

        private readonly IArticleTypeService _articleTypeService;
        private readonly IArticleTypeMapper _articleTypeMapper;
        private readonly ILogger<IRequest> _logger;

        public EditArticleTypeCommandHandler(IArticleTypeService articleTypeService, IArticleTypeMapper articleTypeMapper, ILogger<IRequest> logger)
        {
            _articleTypeService = articleTypeService;
            _articleTypeMapper = articleTypeMapper;
            _logger = logger;
        }

        public async Task<RespContainer<ArticleTypeResponse>> Handle(EditArticleTypeCommand request, CancellationToken cancellationToken)
        {
            ArticleTypeResponse result = await _articleTypeService.EditArticleTypeAsync(request.Data);
            return RespContainer.Ok(result, "ArticleType Updated");
        }
    }
}
