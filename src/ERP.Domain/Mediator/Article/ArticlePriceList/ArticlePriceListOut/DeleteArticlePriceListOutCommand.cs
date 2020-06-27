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
    public class DelteArticlePriceListOutCommand : ReqContainer<DeleteArticlePriceListOutRequest>, IRequestWrapper<EmptyResponse>
    {
        public DelteArticlePriceListOutCommand(DeleteArticlePriceListOutRequest request) : base(request)
        { }
    }

    public class DelteArticlePriceListOutCommandHandler : IHandlerWrapper<DelteArticlePriceListOutCommand, EmptyResponse>
    {
        private readonly IArticlePriceListOutService _articlePriceListOutService;
        private readonly IArticlePriceListOutMapper _articlePriceListOutMapper;
        private readonly ILogger<IRequest> _logger;

        public DelteArticlePriceListOutCommandHandler(IArticlePriceListOutService articlePriceListOutService, IArticlePriceListOutMapper articlePriceListOutMapper, ILogger<IRequest> logger)
        {
            _articlePriceListOutService = articlePriceListOutService;
            _articlePriceListOutMapper = articlePriceListOutMapper;
            _logger = logger;
        }

        public async Task<RespContainer<EmptyResponse>> Handle(DelteArticlePriceListOutCommand request, CancellationToken cancellationToken)
        {
            await _articlePriceListOutService.DeleteArticlePriceListOutAsync(request.Data);
            _logger.LogInformation($"Entity with { request.Data.Id} deleted");
            return RespContainer.Ok(new EmptyResponse(), "ArticlePriceListOut deleted");
        }
    }
}
