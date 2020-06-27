using ERP.Domain.Requests;
using ERP.Domain.Responses;
using ERP.Domain.Services;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ERP.Domain.Mediator.Queries
{
    public class GetAllPersonsQuery : ReqContainer<GetAllPersonRequest>, IRequest<ApiResult<PersonResponse>>
    {
        public GetAllPersonsQuery(GetAllPersonRequest getAllPersonRequest) : base(getAllPersonRequest)
        { }
    }
    public class GetAllPersonsQueryHandler : IRequestHandler<GetAllPersonsQuery, ApiResult<PersonResponse>>
    {
        private readonly ILogger<IRequest> _logger;
        private readonly IPersonService _personService;

        public GetAllPersonsQueryHandler(ILogger<IRequest> logger, IPersonService personService)
        {
            _logger = logger;
            _personService = personService;
        }

        public async Task<ApiResult<PersonResponse>> Handle(GetAllPersonsQuery request, CancellationToken cancellationToken)
        {
            IQueryable<PersonResponse> result = _personService.GetPersonsQuery();
            return await ApiResult<PersonResponse>.CreateAsync(
                result,
                request.Data.PageIndex,
                request.Data.PageSize,
                request.Data.SortColumn,
                request.Data.SortOrder,
                request.Data.FilterColumn,
                request.Data.FilterQuery);
        }
    }
}
