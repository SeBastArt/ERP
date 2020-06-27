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
    /// FAGBinaryController
    /// </summary>
    [Produces("application/json")]
    [Route("api/fagbinaries")]
    [ApiController]
    [ApiVersion("1.0")]
    [JsonException]
    public class FAGBinaryController : ControllerBase
    {
        private readonly IFAGBinaryService _fagBinaryService;
        private readonly IMediator _mediator;

        /// <summary>
        /// Constructor FAGBinaryController
        /// </summary>
        /// <param name="fagBinaryService"></param>
        /// <param name="mediator"></param>
        public FAGBinaryController(IFAGBinaryService fagBinaryService, IMediator mediator)
        {
            _fagBinaryService = fagBinaryService;
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
        [ApiConventionMethod(typeof(FAGBinaryApiConvention), nameof(FAGBinaryApiConvention.Get))]
        public async Task<IActionResult> Get([FromQuery] int pageSize = 10, [FromQuery] int pageIndex = 0, [FromQuery] string sortColumn = null, [FromQuery] string sortOrder = null,
            [FromQuery] string filterColumn = null, [FromQuery] string filterQuery = null)
        {
            GetAllFAGBinaryRequest request = new GetAllFAGBinaryRequest
            {
                PageSize = pageSize,
                PageIndex = pageIndex,
                SortColumn = sortColumn,
                SortOrder = sortOrder,
                FilterColumn = filterColumn,
                FilterQuery = filterQuery,
            };
            ApiResult<FAGBinaryResponse> result = await _mediator.Send(new GetAllFAGBinariesQuery(request));
            return Ok(result);
        }

        /// <summary>
        /// GetById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:guid}")]
        [ApiConventionMethod(typeof(FAGBinaryApiConvention), nameof(FAGBinaryApiConvention.GetById))]
        public async Task<IActionResult> GetById(Guid id)
        {
            FAGBinaryResponse result = await _mediator.Send(new GetFAGBinaryQuery(id));
            return Ok(result);
        }

        /// <summary>
        /// Post
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [ApiConventionMethod(typeof(FAGBinaryApiConvention), nameof(FAGBinaryApiConvention.Create))]
        public async Task<IActionResult> Post(AddFAGBinaryRequest request)
        {
            RespContainer<FAGBinaryResponse> result = await _mediator.Send(new AddFAGBinaryCommand(request));
            return CreatedAtAction(nameof(GetById), new { id = result.Data.Id }, result);
        }

        /// <summary>
        /// Put
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("{id:guid}")]
        [ApiConventionMethod(typeof(FAGBinaryApiConvention), nameof(FAGBinaryApiConvention.Update))]
        public async Task<IActionResult> Put(Guid id, EditFAGBinaryRequest request)
        {
            request.Id = id;
            return Ok(await _mediator.Send(new EditFAGBinaryCommand(request)));
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:guid}")]
        [ApiConventionMethod(typeof(FAGBinaryApiConvention), nameof(FAGBinaryApiConvention.Delete))]
        public async Task<IActionResult> Delete(Guid id)
        {
            DeleteFAGBinaryRequest request = new DeleteFAGBinaryRequest { Id = id };
            return Ok(await _mediator.Send(new DelteFAGBinaryCommand(request)));
        }
    }
}