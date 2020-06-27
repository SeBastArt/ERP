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
    public class AddArticlePriceListOutCommand : ReqContainer<AddArticlePriceListOutRequest>, IRequestWrapper<ArticlePriceListOutResponse>
    {
        public AddArticlePriceListOutCommand(AddArticlePriceListOutRequest addArticlePriceListOutRequest) : base(addArticlePriceListOutRequest)
        {
        }
    }

    public class AddArticlePriceListOutCommandHandler : IHandlerWrapper<AddArticlePriceListOutCommand, ArticlePriceListOutResponse>
    {
        private readonly IArticlePriceListOutRespository _articlePriceListOutRespository;
        private readonly IArticlePriceListOutMapper _articlePriceListOutMapper;
        private readonly ILogger<IRequest> _logger;

        public AddArticlePriceListOutCommandHandler(IArticlePriceListOutRespository articlePriceListOutRespository, IArticlePriceListOutMapper articlePriceListOutMapper, ILogger<IRequest> logger)
        {
            _articlePriceListOutRespository = articlePriceListOutRespository;
            _articlePriceListOutMapper = articlePriceListOutMapper;
            _logger = logger;
        }

        public async Task<RespContainer<ArticlePriceListOutResponse>> Handle(AddArticlePriceListOutCommand request, CancellationToken cancellationToken)
        {
            Models.ArticlePriceListOut articlePriceListOut = _articlePriceListOutMapper.Map(request.Data);
            Models.ArticlePriceListOut result = _articlePriceListOutRespository.Add(articlePriceListOut);

            int modifiedRecords = await _articlePriceListOutRespository.UnitOfWork.SaveChangesAsync();

            _logger.LogInformation(Events.Add, Messages.NumberOfRecordAffected_modifiedRecords, modifiedRecords);
            _logger.LogInformation(Events.Add, Messages.ChangesApplied_id, result?.Id);

            return RespContainer.Ok(_articlePriceListOutMapper.Map(result), "ArticlePriceListOut Created");
        }
    }
}
