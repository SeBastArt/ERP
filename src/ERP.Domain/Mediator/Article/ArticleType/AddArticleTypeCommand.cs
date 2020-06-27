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
    public class AddArticleTypeCommand : ReqContainer<AddArticleTypeRequest>, IRequestWrapper<ArticleTypeResponse>
    {
        public AddArticleTypeCommand(AddArticleTypeRequest addArticleTypeRequest) : base(addArticleTypeRequest)
        {
        }
    }

    public class AddArticleTypeCommandHandler : IHandlerWrapper<AddArticleTypeCommand, ArticleTypeResponse>
    {
        private readonly IArticleTypeRespository _articleTypeRespository;
        private readonly IArticleTypeMapper _articleTypeMapper;
        private readonly ILogger<IRequest> _logger;

        public AddArticleTypeCommandHandler(IArticleTypeRespository articleTypeRespository, IArticleTypeMapper articleTypeMapper, ILogger<IRequest> logger)
        {
            _articleTypeRespository = articleTypeRespository;
            _articleTypeMapper = articleTypeMapper;
            _logger = logger;
        }

        public async Task<RespContainer<ArticleTypeResponse>> Handle(AddArticleTypeCommand request, CancellationToken cancellationToken)
        {
            Models.ArticleType articleType = _articleTypeMapper.Map(request.Data);
            Models.ArticleType result = _articleTypeRespository.Add(articleType);

            int modifiedRecords = await _articleTypeRespository.UnitOfWork.SaveChangesAsync();

            _logger.LogInformation(Events.Add, Messages.NumberOfRecordAffected_modifiedRecords, modifiedRecords);
            _logger.LogInformation(Events.Add, Messages.ChangesApplied_id, result?.Id);

            return RespContainer.Ok(_articleTypeMapper.Map(result), "ArticleType Created");
        }
    }
}
