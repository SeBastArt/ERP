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
    public class EditArticlePriceListOutCommand : ReqContainer<EditArticlePriceListOutRequest>, IRequestWrapper<ArticlePriceListOutResponse>
    {
        public EditArticlePriceListOutCommand(EditArticlePriceListOutRequest editArticlePriceListOutRequest) : base(editArticlePriceListOutRequest)
        { }
    }

    public class EditArticlePriceListOutCommandHandler : IHandlerWrapper<EditArticlePriceListOutCommand, ArticlePriceListOutResponse>
    {

        private readonly IArticlePriceListOutService _articlePriceListOutService;
        private readonly IArticlePriceListOutMapper _articlePriceListOutMapper;
        private readonly ILogger<IRequest> _logger;

        public EditArticlePriceListOutCommandHandler(IArticlePriceListOutService articlePriceListOutService, IArticlePriceListOutMapper articlePriceListOutMapper, ILogger<IRequest> logger)
        {
            _articlePriceListOutService = articlePriceListOutService;
            _articlePriceListOutMapper = articlePriceListOutMapper;
            _logger = logger;
        }

        public async Task<RespContainer<ArticlePriceListOutResponse>> Handle(EditArticlePriceListOutCommand request, CancellationToken cancellationToken)
        {
            ArticlePriceListOutResponse result = await _articlePriceListOutService.EditArticlePriceListOutAsync(request.Data);
            return RespContainer.Ok(result, "ArticlePriceListOut Updated");
        }
    }
}
