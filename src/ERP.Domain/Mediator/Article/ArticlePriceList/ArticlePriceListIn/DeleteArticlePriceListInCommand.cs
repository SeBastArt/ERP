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
    public class DelteArticlePriceListInCommand : ReqContainer<DeleteArticlePriceListInRequest>, IRequestWrapper<EmptyResponse>
    {
        public DelteArticlePriceListInCommand(DeleteArticlePriceListInRequest request) : base(request)
        { }
    }

    public class DelteArticlePriceListInCommandHandler : IHandlerWrapper<DelteArticlePriceListInCommand, EmptyResponse>
    {
        private readonly IArticlePriceListInService _articlePriceListInService;
        private readonly IArticlePriceListInMapper _articlePriceListInMapper;
        private readonly ILogger<IRequest> _logger;

        public DelteArticlePriceListInCommandHandler(IArticlePriceListInService articlePriceListInService, IArticlePriceListInMapper articlePriceListInMapper, ILogger<IRequest> logger)
        {
            _articlePriceListInService = articlePriceListInService;
            _articlePriceListInMapper = articlePriceListInMapper;
            _logger = logger;
        }

        public async Task<RespContainer<EmptyResponse>> Handle(DelteArticlePriceListInCommand request, CancellationToken cancellationToken)
        {
            await _articlePriceListInService.DeleteArticlePriceListInAsync(request.Data);
            _logger.LogInformation($"Entity with { request.Data.Id} deleted");
            return RespContainer.Ok(new EmptyResponse(), "ArticlePriceListIn deleted");
        }
    }
}
