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
    public class EditCompanyTypeCommand : ReqContainer<EditCompanyTypeRequest>, IRequestWrapper<CompanyTypeResponse>
    {
        public EditCompanyTypeCommand(EditCompanyTypeRequest editCompanyTypeRequest) : base(editCompanyTypeRequest)
        { }
    }

    public class EditCompanyTypeCommandHandler : IHandlerWrapper<EditCompanyTypeCommand, CompanyTypeResponse>
    {

        private readonly ICompanyTypeService _companyTypeService;
        private readonly ICompanyTypeMapper _companyTypeMapper;
        private readonly ILogger<IRequest> _logger;

        public EditCompanyTypeCommandHandler(ICompanyTypeService companyTypeService, ICompanyTypeMapper companyTypeMapper, ILogger<IRequest> logger)
        {
            _companyTypeService = companyTypeService;
            _companyTypeMapper = companyTypeMapper;
            _logger = logger;
        }

        public async Task<RespContainer<CompanyTypeResponse>> Handle(EditCompanyTypeCommand request, CancellationToken cancellationToken)
        {
            CompanyTypeResponse result = await _companyTypeService.EditCompanyTypeAsync(request.Data);
            return RespContainer.Ok(result, "CompanyType Updated");
        }
    }
}
