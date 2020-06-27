using ERP.Domain.Logging;
using ERP.Domain.Mappers;
using ERP.Domain.Mediator.Wrapper;
using ERP.Domain.Requests;
using ERP.Domain.Responses;
using ERP.Domain.Respositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace ERP.Domain.Mediator.Commands
{
    public class AddArticlePriceListInCommand : ReqContainer<AddArticlePriceListInRequest>, IRequestWrapper<ArticlePriceListInResponse>
    {
        public AddArticlePriceListInCommand(AddArticlePriceListInRequest addArticlePriceListInRequest) : base(addArticlePriceListInRequest)
        {
        }
    }

    public class AddArticlePriceListInCommandHandler : IHandlerWrapper<AddArticlePriceListInCommand, ArticlePriceListInResponse>
    {
        private readonly IArticlePriceListInRespository _articlePriceListInRespository;
        private readonly IArticlePriceListInMapper _articlePriceListInMapper;
        private readonly ILogger<IRequest> _logger;

        public AddArticlePriceListInCommandHandler(IArticlePriceListInRespository articlePriceListInRespository, IArticlePriceListInMapper articlePriceListInMapper, ILogger<IRequest> logger)
        {
            _articlePriceListInRespository = articlePriceListInRespository;
            _articlePriceListInMapper = articlePriceListInMapper;
            _logger = logger;
        }

        public async Task<RespContainer<ArticlePriceListInResponse>> Handle(AddArticlePriceListInCommand request, CancellationToken cancellationToken)
        {
            Models.ArticlePriceListIn articlePriceListIn = _articlePriceListInMapper.Map(request.Data);
            Models.ArticlePriceListIn result = _articlePriceListInRespository.Add(articlePriceListIn);

            int modifiedRecords = await _articlePriceListInRespository.UnitOfWork.SaveChangesAsync();

            _logger.LogInformation(Events.Add, Messages.NumberOfRecordAffected_modifiedRecords, modifiedRecords);
            _logger.LogInformation(Events.Add, Messages.ChangesApplied_id, result?.Id);

            return RespContainer.Ok(_articlePriceListInMapper.Map(result), "ArticlePriceListIn Created");
        }
    }
}
