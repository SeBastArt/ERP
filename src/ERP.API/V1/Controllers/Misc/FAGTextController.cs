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
    /// FAGTextController
    /// </summary>
    [Produces("application/json")]
    [Route("api/fagtexts")]
    [ApiController]
    [ApiVersion("1.0")]
    [JsonException]
    public class FAGTextController : ControllerBase
    {
        private readonly IFAGTextService _fagTextService;
        private readonly IMediator _mediator;

        /// <summary>
        /// Constructor FAGTextController
        /// </summary>
        /// <param name="fagTextService"></param>
        /// <param name="mediator"></param>
        public FAGTextController(IFAGTextService fagTextService, IMediator mediator)
        {
            _fagTextService = fagTextService;
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
        [ApiConventionMethod(typeof(FAGTextApiConvention), nameof(FAGTextApiConvention.Get))]
        public async Task<IActionResult> Get([FromQuery] int pageSize = 10, [FromQuery] int pageIndex = 0, [FromQuery] string sortColumn = null, [FromQuery] string sortOrder = null,
            [FromQuery] string filterColumn = null, [FromQuery] string filterQuery = null)
        {
            GetAllFAGTextRequest request = new GetAllFAGTextRequest
            {
                PageSize = pageSize,
                PageIndex = pageIndex,
                SortColumn = sortColumn,
                SortOrder = sortOrder,
                FilterColumn = filterColumn,
                FilterQuery = filterQuery,
            };
            ApiResult<FAGTextResponse> result = await _mediator.Send(new GetAllFAGTextsQuery(request));
            return Ok(result);
        }

        /// <summary>
        /// GetById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:guid}")]
        [ApiConventionMethod(typeof(FAGTextApiConvention), nameof(FAGTextApiConvention.GetById))]
        public async Task<IActionResult> GetById(Guid id)
        {
            FAGTextResponse result = await _mediator.Send(new GetFAGTextQuery(id));
            return Ok(result);
        }

        /// <summary>
        /// Post
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [ApiConventionMethod(typeof(FAGTextApiConvention), nameof(FAGTextApiConvention.Create))]
        public async Task<IActionResult> Post(AddFAGTextRequest request)
        {
            RespContainer<FAGTextResponse> result = await _mediator.Send(new AddFAGTextCommand(request));
            return CreatedAtAction(nameof(GetById), new { id = result.Data.Id }, result);
        }

        /// <summary>
        /// Put
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("{id:guid}")]
        [ApiConventionMethod(typeof(FAGTextApiConvention), nameof(FAGTextApiConvention.Update))]
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
        [ApiConventionMethod(typeof(FAGTextApiConvention), nameof(FAGTextApiConvention.Delete))]
        public async Task<IActionResult> Delete(Guid id)
        {
            DeleteFAGTextRequest request = new DeleteFAGTextRequest { Id = id };
            return Ok(await _mediator.Send(new DelteFAGTextCommand(request)));
        }
    }
}