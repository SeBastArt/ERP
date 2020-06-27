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
    public class DelteCompanyCommand : ReqContainer<DeleteCompanyRequest>, IRequestWrapper<EmptyResponse>
    {
        public DelteCompanyCommand(DeleteCompanyRequest request) : base(request)
        { }
    }

    public class DelteCompanyCommandHandler : IHandlerWrapper<DelteCompanyCommand, EmptyResponse>
    {
        private readonly ICompanyService _companyService;
        private readonly ICompanyMapper _companyMapper;
        private readonly ILogger<IRequest> _logger;

        public DelteCompanyCommandHandler(ICompanyService companyService, ICompanyMapper companyMapper, ILogger<IRequest> logger)
        {
            _companyService = companyService;
            _companyMapper = companyMapper;
            _logger = logger;
        }

        public async Task<RespContainer<EmptyResponse>> Handle(DelteCompanyCommand request, CancellationToken cancellationToken)
        {
            await _companyService.DeleteCompanyAsync(request.Data);
            _logger.LogInformation($"Entity with { request.Data.Id} deleted");
            return RespContainer.Ok(new EmptyResponse(), "Company deleted");
        }
    }
}
