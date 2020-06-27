using ERP.Domain.Requests;
using ERP.Domain.Responses;
using ERP.Domain.Services;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ERP.Domain.Mediator.Queries
{
    public class GetPersonQuery : ReqContainer<Guid>, IRequest<PersonResponse>
    {
        /// <summary>
        /// GetPersonQuery
        /// </summary>
        /// <param name="id"></param>
        public GetPersonQuery(Guid id) : base(id)
        { }
    }

    /// <summary>
    /// GetPersonQueryHandler
    /// </summary>
    public class GetPersonQueryHandler : IRequestHandler<GetPersonQuery, PersonResponse>
    {
        private readonly ILogger<IRequest> _logger;
        private readonly IPersonService _personService;

        /// <summary>
        /// GetPersonQueryHandler
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="personService"></param>
        public GetPersonQueryHandler(ILogger<IRequest> logger, IPersonService personService)
        {
            _logger = logger;
            _personService = personService;
        }

        public async Task<PersonResponse> Handle(GetPersonQuery request, CancellationToken cancellationToken)
        {
            PersonResponse result = await _personService.GetPersonAsync(request.Data);
            return result;
        }
    }
}
