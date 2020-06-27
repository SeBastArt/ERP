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
    public class AddArticleCommand : ReqContainer<AddArticleRequest>, IRequestWrapper<ArticleResponse>
    {
        public AddArticleCommand(AddArticleRequest addArticleRequest) : base(addArticleRequest)
        {
        }
    }

    public class AddArticleCommandHandler : IHandlerWrapper<AddArticleCommand, ArticleResponse>
    {
        private readonly IArticleRespository _articleRespository;
        private readonly IArticleMapper _articleMapper;
        private readonly ILogger<IRequest> _logger;

        public AddArticleCommandHandler(IArticleRespository articleRespository, IArticleMapper articleMapper, ILogger<IRequest> logger)
        {
            _articleRespository = articleRespository;
            _articleMapper = articleMapper;
            _logger = logger;
        }

        public async Task<RespContainer<ArticleResponse>> Handle(AddArticleCommand request, CancellationToken cancellationToken)
        {
            Models.Article article = _articleMapper.Map(request.Data);
            Models.Article result = _articleRespository.Add(article);

            int modifiedRecords = await _articleRespository.UnitOfWork.SaveChangesAsync();

            _logger.LogInformation(Events.Add, Messages.NumberOfRecordAffected_modifiedRecords, modifiedRecords);
            _logger.LogInformation(Events.Add, Messages.ChangesApplied_id, result?.Id);

            return RespContainer.Ok(_articleMapper.Map(result), "Article Created");
        }
    }
}
