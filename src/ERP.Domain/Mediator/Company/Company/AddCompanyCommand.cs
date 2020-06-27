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
    public class AddCompanyCommand : ReqContainer<AddCompanyRequest>, IRequestWrapper<CompanyResponse>
    {
        public AddCompanyCommand(AddCompanyRequest addCompanyRequest) : base(addCompanyRequest)
        {
        }
    }

    public class AddCompanyCommandHandler : IHandlerWrapper<AddCompanyCommand, CompanyResponse>
    {
        private readonly ICompanyRespository _companyRespository;
        private readonly ICompanyMapper _companyMapper;
        private readonly ILogger<IRequest> _logger;

        public AddCompanyCommandHandler(ICompanyRespository companyRespository, ICompanyMapper companyMapper, ILogger<IRequest> logger)
        {
            _companyRespository = companyRespository;
            _companyMapper = companyMapper;
            _logger = logger;
        }

        public async Task<RespContainer<CompanyResponse>> Handle(AddCompanyCommand request, CancellationToken cancellationToken)
        {
            Models.Company company = _companyMapper.Map(request.Data);
            Models.Company result = _companyRespository.Add(company);

            int modifiedRecords = await _companyRespository.UnitOfWork.SaveChangesAsync();

            _logger.LogInformation(Events.Add, Messages.NumberOfRecordAffected_modifiedRecords, modifiedRecords);
            _logger.LogInformation(Events.Add, Messages.ChangesApplied_id, result?.Id);

            return RespContainer.Ok(_companyMapper.Map(result), "Company Created");
        }
    }
}
