using ERP.Domain.Mappers;
using ERP.Domain.Mediator.Wrapper;
using ERP.Domain.Requests;
using ERP.Domain.Responses;
using ERP.Domain.Services;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace ERP.Domain.Mediator.Commands
{
    public class EditCompanyCommand : ReqContainer<EditCompanyRequest>, IRequestWrapper<CompanyResponse>
    {
        public EditCompanyCommand(EditCompanyRequest editCompanyRequest) : base(editCompanyRequest)
        { }
    }

    public class EditCompanyCommandHandler : IHandlerWrapper<EditCompanyCommand, CompanyResponse>
    {

        private readonly ICompanyService _companyService;
        private readonly ICompanyMapper _companyMapper;
        private readonly ILogger<IRequest> _logger;

        public EditCompanyCommandHandler(ICompanyService companyService, ICompanyMapper companyMapper, ILogger<IRequest> logger)
        {
            _companyService = companyService;
            _companyMapper = companyMapper;
            _logger = logger;
        }

        public async Task<RespContainer<CompanyResponse>> Handle(EditCompanyCommand request, CancellationToken cancellationToken)
        {
            CompanyResponse result = await _companyService.EditCompanyAsync(request.Data);
            return RespContainer.Ok(result, "Company Updated");
        }
    }
}
