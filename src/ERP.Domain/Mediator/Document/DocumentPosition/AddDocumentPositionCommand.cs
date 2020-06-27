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
    public class AddDocumentPositionCommand : ReqContainer<AddDocumentPositionRequest>, IRequestWrapper<DocumentPositionResponse>
    {
        public AddDocumentPositionCommand(AddDocumentPositionRequest addDocumentPositionRequest) : base(addDocumentPositionRequest)
        {
        }
    }

    public class AddDocumentPositionCommandHandler : IHandlerWrapper<AddDocumentPositionCommand, DocumentPositionResponse>
    {
        private readonly IDocumentPositionRespository _documentPositionRespository;
        private readonly IDocumentPositionMapper _documentPositionMapper;
        private readonly ILogger<IRequest> _logger;

        public AddDocumentPositionCommandHandler(IDocumentPositionRespository documentPositionRespository, IDocumentPositionMapper documentPositionMapper, ILogger<IRequest> logger)
        {
            _documentPositionRespository = documentPositionRespository;
            _documentPositionMapper = documentPositionMapper;
            _logger = logger;
        }

        public async Task<RespContainer<DocumentPositionResponse>> Handle(AddDocumentPositionCommand request, CancellationToken cancellationToken)
        {
            Models.DocumentPosition documentPosition = _documentPositionMapper.Map(request.Data);
            Models.DocumentPosition result = _documentPositionRespository.Add(documentPosition);

            int modifiedRecords = await _documentPositionRespository.UnitOfWork.SaveChangesAsync();

            _logger.LogInformation(Events.Add, Messages.NumberOfRecordAffected_modifiedRecords, modifiedRecords);
            _logger.LogInformation(Events.Add, Messages.ChangesApplied_id, result?.Id);

            return RespContainer.Ok(_documentPositionMapper.Map(result), "DocumentPosition Created");
        }
    }
}
