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
    public class DelteCompanyTypeCommand : ReqContainer<DeleteCompanyTypeRequest>, IRequestWrapper<EmptyResponse>
    {
        public DelteCompanyTypeCommand(DeleteCompanyTypeRequest request) : base(request)
        { }
    }

    public class DelteCompanyTypeCommandHandler : IHandlerWrapper<DelteCompanyTypeCommand, EmptyResponse>
    {
        private readonly ICompanyTypeService _companyTypeService;
        private readonly ICompanyTypeMapper _companyTypeMapper;
        private readonly ILogger<IRequest> _logger;

        public DelteCompanyTypeCommandHandler(ICompanyTypeService companyTypeService, ICompanyTypeMapper companyTypeMapper, ILogger<IRequest> logger)
        {
            _companyTypeService = companyTypeService;
            _companyTypeMapper = companyTypeMapper;
            _logger = logger;
        }

        public async Task<RespContainer<EmptyResponse>> Handle(DelteCompanyTypeCommand request, CancellationToken cancellationToken)
        {
            await _companyTypeService.DeleteCompanyTypeAsync(request.Data);
            _logger.LogInformation($"Entity with { request.Data.Id} deleted");
            return RespContainer.Ok(new EmptyResponse(), "CompanyType deleted");
        }
    }
}
