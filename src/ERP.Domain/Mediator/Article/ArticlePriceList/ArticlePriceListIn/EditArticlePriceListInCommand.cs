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
    public class EditArticlePriceListInCommand : ReqContainer<EditArticlePriceListInRequest>, IRequestWrapper<ArticlePriceListInResponse>
    {
        public EditArticlePriceListInCommand(EditArticlePriceListInRequest editArticlePriceListInRequest) : base(editArticlePriceListInRequest)
        { }
    }

    public class EditArticlePriceListInCommandHandler : IHandlerWrapper<EditArticlePriceListInCommand, ArticlePriceListInResponse>
    {

        private readonly IArticlePriceListInService _articlePriceListInService;
        private readonly IArticlePriceListInMapper _articlePriceListInMapper;
        private readonly ILogger<IRequest> _logger;

        public EditArticlePriceListInCommandHandler(IArticlePriceListInService articlePriceListInService, IArticlePriceListInMapper articlePriceListInMapper, ILogger<IRequest> logger)
        {
            _articlePriceListInService = articlePriceListInService;
            _articlePriceListInMapper = articlePriceListInMapper;
            _logger = logger;
        }

        public async Task<RespContainer<ArticlePriceListInResponse>> Handle(EditArticlePriceListInCommand request, CancellationToken cancellationToken)
        {
            ArticlePriceListInResponse result = await _articlePriceListInService.EditArticlePriceListInAsync(request.Data);
            return RespContainer.Ok(result, "ArticlePriceListIn Updated");
        }
    }
}
