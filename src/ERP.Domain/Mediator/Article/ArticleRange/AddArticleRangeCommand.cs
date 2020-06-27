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
    public class AddArticleRangeCommand : ReqContainer<AddArticleRangeRequest>, IRequestWrapper<ArticleRangeResponse>
    {
        public AddArticleRangeCommand(AddArticleRangeRequest addArticleRangeRequest) : base(addArticleRangeRequest)
        {
        }
    }

    public class AddArticleRangeCommandHandler : IHandlerWrapper<AddArticleRangeCommand, ArticleRangeResponse>
    {
        private readonly IArticleRangeRespository _articleRangeRespository;
        private readonly IArticleRangeMapper _articleRangeMapper;
        private readonly ILogger<IRequest> _logger;

        public AddArticleRangeCommandHandler(IArticleRangeRespository articleRangeRespository, IArticleRangeMapper articleRangeMapper, ILogger<IRequest> logger)
        {
            _articleRangeRespository = articleRangeRespository;
            _articleRangeMapper = articleRangeMapper;
            _logger = logger;
        }

        public async Task<RespContainer<ArticleRangeResponse>> Handle(AddArticleRangeCommand request, CancellationToken cancellationToken)
        {
            Models.ArticleRange articleRange = _articleRangeMapper.Map(request.Data);
            Models.ArticleRange result = _articleRangeRespository.Add(articleRange);

            int modifiedRecords = await _articleRangeRespository.UnitOfWork.SaveChangesAsync();

            _logger.LogInformation(Events.Add, Messages.NumberOfRecordAffected_modifiedRecords, modifiedRecords);
            _logger.LogInformation(Events.Add, Messages.ChangesApplied_id, result?.Id);

            return RespContainer.Ok(_articleRangeMapper.Map(result), "ArticleRange Created");
        }
    }
}
