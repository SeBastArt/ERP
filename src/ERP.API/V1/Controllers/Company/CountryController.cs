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
    /// CountryController
    /// </summary>
    [Produces("application/json")]
    [Route("api/countries")]
    [ApiController]
    [ApiVersion("1.0")]
    [JsonException]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _itemService;
        private readonly IMediator _mediator;

        /// <summary>
        /// Constructor CountryController
        /// </summary>
        /// <param name="itemService"></param>
        /// <param name="mediator"></param>
        public CountryController(ICountryService itemService, IMediator mediator)
        {
            _itemService = itemService;
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
        [ApiConventionMethod(typeof(CountryApiConvention), nameof(CountryApiConvention.Get))]
        public async Task<IActionResult> Get([FromQuery] int pageSize = 10, [FromQuery] int pageIndex = 0, [FromQuery] string sortColumn = null, [FromQuery] string sortOrder = null,
            [FromQuery] string filterColumn = null, [FromQuery] string filterQuery = null)
        {
            GetAllCountryRequest request = new GetAllCountryRequest
            {
                PageSize = pageSize,
                PageIndex = pageIndex,
                SortColumn = sortColumn,
                SortOrder = sortOrder,
                FilterColumn = filterColumn,
                FilterQuery = filterQuery,
            };
            ApiResult<CountryResponse> result = await _mediator.Send(new GetAllCountriesQuery(request));
            return Ok();
        }

        /// <summary>
        /// GetById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:guid}")]
        [ApiConventionMethod(typeof(CountryApiConvention), nameof(CountryApiConvention.GetById))]
        public async Task<IActionResult> GetById(Guid id)
        {
            CountryResponse result = await _mediator.Send(new GetCountryQuery(id));
            return Ok(result);
        }

        /// <summary>
        /// Post
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [ApiConventionMethod(typeof(CountryApiConvention), nameof(CountryApiConvention.Create))]
        public async Task<IActionResult> Post(AddCountryRequest request)
        {
            RespContainer<CountryResponse> result = await _mediator.Send(new AddCountryCommand(request));
            return CreatedAtAction(nameof(GetById), new { id = result.Data.Id }, result);
        }

        /// <summary>
        /// Put
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("{id:guid}")]
        [ApiConventionMethod(typeof(CountryApiConvention), nameof(CountryApiConvention.Update))]
        public async Task<IActionResult> Put(Guid id, EditCountryRequest request)
        {
            request.Id = id;
            return Ok(await _mediator.Send(new EditCountryCommand(request)));
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:guid}")]
        [ApiConventionMethod(typeof(CountryApiConvention), nameof(CountryApiConvention.Delete))]
        public async Task<IActionResult> Delete(Guid id)
        {
            DeleteCountryRequest request = new DeleteCountryRequest { Id = id };
            return Ok(await _mediator.Send(new DelteCountryCommand(request)));
        }
    }
}