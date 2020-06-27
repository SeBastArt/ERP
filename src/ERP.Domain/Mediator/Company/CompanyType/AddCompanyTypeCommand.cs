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
    public class AddCompanyTypeCommand : ReqContainer<AddCompanyTypeRequest>, IRequestWrapper<CompanyTypeResponse>
    {
        public AddCompanyTypeCommand(AddCompanyTypeRequest addCompanyTypeRequest) : base(addCompanyTypeRequest)
        {
        }
    }

    public class AddCompanyTypeCommandHandler : IHandlerWrapper<AddCompanyTypeCommand, CompanyTypeResponse>
    {
        private readonly ICompanyTypeRespository _companyTypeRespository;
        private readonly ICompanyTypeMapper _companyTypeMapper;
        private readonly ILogger<IRequest> _logger;

        public AddCompanyTypeCommandHandler(ICompanyTypeRespository companyTypeRespository, ICompanyTypeMapper companyTypeMapper, ILogger<IRequest> logger)
        {
            _companyTypeRespository = companyTypeRespository;
            _companyTypeMapper = companyTypeMapper;
            _logger = logger;
        }

        public async Task<RespContainer<CompanyTypeResponse>> Handle(AddCompanyTypeCommand request, CancellationToken cancellationToken)
        {
            Models.CompanyType companyType = _companyTypeMapper.Map(request.Data);
            Models.CompanyType result = _companyTypeRespository.Add(companyType);

            int modifiedRecords = await _companyTypeRespository.UnitOfWork.SaveChangesAsync();

            _logger.LogInformation(Events.Add, Messages.NumberOfRecordAffected_modifiedRecords, modifiedRecords);
            _logger.LogInformation(Events.Add, Messages.ChangesApplied_id, result?.Id);

            return RespContainer.Ok(_companyTypeMapper.Map(result), "CompanyType Created");
        }
    }
}
