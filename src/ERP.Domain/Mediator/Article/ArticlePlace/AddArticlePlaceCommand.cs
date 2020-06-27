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
    public class AddArticlePlaceCommand : ReqContainer<AddArticlePlaceRequest>, IRequestWrapper<ArticlePlaceResponse>
    {
        public AddArticlePlaceCommand(AddArticlePlaceRequest addArticlePlaceRequest) : base(addArticlePlaceRequest)
        {
        }
    }

    public class AddArticlePlaceCommandHandler : IHandlerWrapper<AddArticlePlaceCommand, ArticlePlaceResponse>
    {
        private readonly IArticlePlaceRespository _articlePlaceRespository;
        private readonly IArticlePlaceMapper _articlePlaceMapper;
        private readonly ILogger<IRequest> _logger;

        public AddArticlePlaceCommandHandler(IArticlePlaceRespository articlePlaceRespository, IArticlePlaceMapper articlePlaceMapper, ILogger<IRequest> logger)
        {
            _articlePlaceRespository = articlePlaceRespository;
            _articlePlaceMapper = articlePlaceMapper;
            _logger = logger;
        }

        public async Task<RespContainer<ArticlePlaceResponse>> Handle(AddArticlePlaceCommand request, CancellationToken cancellationToken)
        {
            Models.ArticlePlace articlePlace = _articlePlaceMapper.Map(request.Data);
            Models.ArticlePlace result = _articlePlaceRespository.Add(articlePlace);

            int modifiedRecords = await _articlePlaceRespository.UnitOfWork.SaveChangesAsync();

            _logger.LogInformation(Events.Add, Messages.NumberOfRecordAffected_modifiedRecords, modifiedRecords);
            _logger.LogInformation(Events.Add, Messages.ChangesApplied_id, result?.Id);

            return RespContainer.Ok(_articlePlaceMapper.Map(result), "ArticlePlace Created");
        }
    }
}
