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
    public class AddDocumentCommand : ReqContainer<AddDocumentRequest>, IRequestWrapper<DocumentResponse>
    {
        public AddDocumentCommand(AddDocumentRequest addDocumentRequest) : base(addDocumentRequest)
        {
        }
    }

    public class AddDocumentCommandHandler : IHandlerWrapper<AddDocumentCommand, DocumentResponse>
    {
        private readonly IDocumentRespository _documentRespository;
        private readonly IDocumentMapper _documentMapper;
        private readonly ILogger<IRequest> _logger;

        public AddDocumentCommandHandler(IDocumentRespository documentRespository, IDocumentMapper documentMapper, ILogger<IRequest> logger)
        {
            _documentRespository = documentRespository;
            _documentMapper = documentMapper;
            _logger = logger;
        }

        public async Task<RespContainer<DocumentResponse>> Handle(AddDocumentCommand request, CancellationToken cancellationToken)
        {
            Models.Document document = _documentMapper.Map(request.Data);
            Models.Document result = _documentRespository.Add(document);

            int modifiedRecords = await _documentRespository.UnitOfWork.SaveChangesAsync();

            _logger.LogInformation(Events.Add, Messages.NumberOfRecordAffected_modifiedRecords, modifiedRecords);
            _logger.LogInformation(Events.Add, Messages.ChangesApplied_id, result?.Id);

            return RespContainer.Ok(_documentMapper.Map(result), "Document Created");
        }
    }
}
