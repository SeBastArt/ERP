using ERP.API.Conventions;
using ERP.API.Filters;
using ERP.Domain.Mediator.Queries;
using ERP.Domain.Mediator.Commands;
using ERP.Domain.Requests;
using ERP.Domain.Responses;
using ERP.Domain.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ERP.API.V1.Controllers
{
    /// <summary>
    /// PersonController
    /// </summary>
    [Produces("application/json")]
    [Route("api/persons")]
    [ApiController]
    [ApiVersion("1.0")]
    [JsonException]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;
        private readonly IMediator _mediator;

        /// <summary>
        /// Constructor PersonController
        /// </summary>
        /// <param name="personService"></param>
        /// <param name="mediator"></param>
        public PersonController(IPersonService personService, IMediator mediator)
        {
            _personService = personService;
            _mediator = mediator;
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="sortColumn"></param>
        /// <param name="sortOrder"></param>
        /// <param name="filterColumn"></param>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpGet]
        [ApiConventionMethod(typeof(PersonApiConvention), nameof(PersonApiConvention.Get))]
        public async Task<IActionResult> Get([FromQuery] int pageSize = 10, [FromQuery] int pageIndex = 0, [FromQuery] string sortColumn = null, [FromQuery] string sortOrder = null,
            [FromQuery] string filterColumn = null, [FromQuery] string filterQuery = null)
        {
            GetAllPersonRequest request = new GetAllPersonRequest
            {
                PageSize = pageSize,
                PageIndex = pageIndex,
                SortColumn = sortColumn,
                SortOrder = sortOrder,
                FilterColumn = filterColumn,
                FilterQuery = filterQuery,
            };
            ApiResult<PersonResponse> result = await _mediator.Send(new GetAllPersonsQuery(request));
            return Ok(result);
        }

        /// <summary>
        /// GetById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:guid}")]
        [ApiConventionMethod(typeof(PersonApiConvention), nameof(PersonApiConvention.GetById))]
        public async Task<IActionResult> GetById(Guid id)
        {
            PersonResponse result = await _mediator.Send(new GetPersonQuery(id));
            return Ok(result);
        }

        /// <summary>
        /// Post
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [ApiConventionMethod(typeof(PersonApiConvention), nameof(PersonApiConvention.Create))]
        public async Task<IActionResult> Post(AddPersonRequest request)
        {
            RespContainer<PersonResponse> result = await _mediator.Send(new AddPersonCommand(request));
            return CreatedAtAction(nameof(GetById), new { id = result.Data.Id }, result);
        }

        /// <summary>
        /// Put
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("{id:guid}")]
        [ApiConventionMethod(typeof(PersonApiConvention), nameof(PersonApiConvention.Update))]
        public async Task<IActionResult> Put(Guid id, EditCompanyRequest request)
        {
            request.Id = id;
            return Ok(await _mediator.Send(new EditCompanyCommand(request)));
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:guid}")]
        [ApiConventionMethod(typeof(PersonApiConvention), nameof(PersonApiConvention.Delete))]
        public async Task<IActionResult> Delete(Guid id)
        {
            DeletePersonRequest request = new DeletePersonRequest { Id = id };
            return Ok(await _mediator.Send(new DeltePersonCommand(request)));
        }
    }
}